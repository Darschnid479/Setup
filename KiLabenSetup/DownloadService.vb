Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Friend Class TransferProgress
    Public Property Title As String = ""
    Public Property Received As Long
    Public Property Total As Long?
    Public Property BytesPerSecond As Double
    Public Property Message As String = ""
End Class

Friend Class VerifiedDownload
    Public Property Package As AppPackage
    Public Property FullPath As String = ""
    Public Property Sha256 As String = ""
    Public Property Publisher As String = ""
End Class

Friend NotInheritable Class DownloadService
    Private Const MaxBytes As Long = 512L * 1024L * 1024L
    Public Shared ReadOnly DownloadFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KiLabenSetupLaunchpad", "Downloads")

    Public Async Function DownloadAsync(package As AppPackage, report As IProgress(Of TransferProgress), cancellation As CancellationToken) As Task(Of VerifiedDownload)
        Directory.CreateDirectory(DownloadFolder)
        Dim destination = Path.Combine(DownloadFolder, Guid.NewGuid().ToString("N") & "-" & package.FileName)
        Dim temporaryPath = destination & ".part"
        Dim result As VerifiedDownload = Nothing
        Using limit = CancellationTokenSource.CreateLinkedTokenSource(cancellation)
            limit.CancelAfter(TimeSpan.FromMinutes(15))
            Dim ct = limit.Token
            Using handler As New HttpClientHandler With {.AllowAutoRedirect = False, .AutomaticDecompression = DecompressionMethods.None}
                Using client As New HttpClient(handler) With {.Timeout = Timeout.InfiniteTimeSpan}
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("KiLabenSetup/3.0")
                    Dim response As HttpResponseMessage = Nothing
                    Try
                        Dim address = package.Source
                        For hop As Integer = 0 To 6
                            If Not UrlPolicy.AllowedDownload(address, package.AllowedHosts) Then Throw New InvalidDataException("Nedlastingsadressen er ikke på listen over tillatte leverandørdomener.")
                            response = Await client.GetAsync(address, HttpCompletionOption.ResponseHeadersRead, ct)
                            Dim code = CInt(response.StatusCode)
                            If code = 301 OrElse code = 302 OrElse code = 303 OrElse code = 307 OrElse code = 308 Then
                                Dim location = response.Headers.Location
                                If location Is Nothing Then Throw New InvalidDataException("Ufullstendig videresending fra nedlastingstjenesten.")
                                Dim following = If(location.IsAbsoluteUri, location, New Uri(address, location))
                                response.Dispose() : response = Nothing
                                address = following
                            Else
                                Exit For
                            End If
                        Next
                        If response Is Nothing Then Throw New InvalidDataException("For mange videresendinger. Bruk leverandørens nettside.")
                        response.EnsureSuccessStatusCode()
                        Dim media = response.Content.Headers.ContentType?.MediaType
                        If media IsNot Nothing AndAlso (media.StartsWith("text/", StringComparison.OrdinalIgnoreCase) OrElse media.Contains("json")) Then
                            Throw New InvalidDataException("Serveren leverte en nettside, ikke et installasjonsprogram.")
                        End If
                        Dim total = response.Content.Headers.ContentLength
                        If total.HasValue AndAlso (total.Value < 1024 OrElse total.Value > MaxBytes) Then Throw New InvalidDataException("Uventet filstørrelse. Nedlastingen stoppes.")
                        Dim received As Long = 0
                        Dim clock = Stopwatch.StartNew()
                        Dim lastUpdate As Long = -200
                        Using input = Await response.Content.ReadAsStreamAsync(ct)
                            Using output As New FileStream(temporaryPath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 65536, True)
                                Dim buffer(65535) As Byte
                                While True
                                    Dim read = Await input.ReadAsync(buffer.AsMemory(0, buffer.Length), ct)
                                    If read = 0 Then Exit While
                                    received += read
                                    If received > MaxBytes Then Throw New InvalidDataException("Filen overstiger nedlastingsgrensen.")
                                    Await output.WriteAsync(buffer.AsMemory(0, read), ct)
                                    If clock.ElapsedMilliseconds - lastUpdate >= 100 Then
                                        report.Report(New TransferProgress With {.Title = package.Title, .Received = received, .Total = total,
                                            .BytesPerSecond = received / Math.Max(0.1, clock.Elapsed.TotalSeconds), .Message = "Laster ned"})
                                        lastUpdate = clock.ElapsedMilliseconds
                                    End If
                                End While
                                Await output.FlushAsync(ct)
                            End Using
                        End Using
                        If received < 1024 OrElse (total.HasValue AndAlso received <> total.Value) Then Throw New InvalidDataException("Filen ble ikke lastet ned fullstendig.")
                        Using f = File.OpenRead(temporaryPath)
                            If f.ReadByte() <> 77 OrElse f.ReadByte() <> 90 Then Throw New InvalidDataException("Filen er ikke en Windows EXE-fil.")
                        End Using
                        File.Move(temporaryPath, destination)
                        ' Keep Windows' Internet-zone protection. Do not remove it from installers.
                        File.WriteAllText(destination & ":Zone.Identifier", "[ZoneTransfer]" & vbCrLf & "ZoneId=3" & vbCrLf & "HostUrl=" & address.AbsoluteUri & vbCrLf, Encoding.ASCII)
                        report.Report(New TransferProgress With {.Title = package.Title, .Received = received, .Total = received, .Message = "Kontrollerer Windows-signatur"})
                        Dim publisher = Await SignatureVerifier.VerifyAsync(destination, package.Publishers, ct)
                        Dim hash As String
                        Using f = File.OpenRead(destination)
                            hash = Convert.ToHexString(Await SHA256.HashDataAsync(f, ct))
                        End Using
                        result = New VerifiedDownload With {.Package = package, .FullPath = destination, .Sha256 = hash, .Publisher = publisher}
                        report.Report(New TransferProgress With {.Title = package.Title, .Received = received, .Total = received, .Message = "Klar. Signatur: " & publisher})
                        Return result
                    Finally
                        If response IsNot Nothing Then response.Dispose()
                        If File.Exists(temporaryPath) Then TryDelete(temporaryPath)
                        If result Is Nothing AndAlso File.Exists(destination) Then TryDelete(destination)
                    End Try
                End Using
            End Using
        End Using
    End Function

    Public Async Function LaunchAsync(item As VerifiedDownload, cancellation As CancellationToken) As Task
        ' Re-check the exact bytes before launch. No arguments or silent installation.
        Using lockedFile As New FileStream(item.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim currentHash = Convert.ToHexString(Await SHA256.HashDataAsync(lockedFile, cancellation))
            If Not String.Equals(currentHash, item.Sha256, StringComparison.Ordinal) Then Throw New InvalidDataException("Installasjonsfilen er endret. Last den ned på nytt.")
            Dim publisher = Await SignatureVerifier.VerifyAsync(item.FullPath, item.Package.Publishers, cancellation)
            Dim started = Process.Start(New ProcessStartInfo(item.FullPath) With {.UseShellExecute = True})
            If started IsNot Nothing Then started.Dispose()
        End Using
    End Function

    Private Shared Sub TryDelete(path As String)
        Try
            File.Delete(path)
        Catch ex As IOException
        Catch ex As UnauthorizedAccessException
        End Try
    End Sub
End Class
