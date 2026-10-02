Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.Json
Imports System.Threading
Imports System.Threading.Tasks

Friend Module SignatureVerifier
    Public Async Function VerifyAsync(path As String, publishers As String(), cancellation As CancellationToken) As Task(Of String)
        ' Run only the Windows built-in Authenticode verifier. Never bypass execution policy.
        Dim ps = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "WindowsPowerShell\v1.0\powershell.exe")
        If Not File.Exists(ps) Then Throw New InvalidOperationException("Windows-signaturkontroll er ikke tilgjengelig. Installasjonen startes ikke.")
        Dim script = "$ErrorActionPreference='Stop'; $s=Get-AuthenticodeSignature -LiteralPath '" & path.Replace("'", "''") & "';" &
            "[pscustomobject]@{Status=$s.Status.ToString();Publisher=$(if($s.SignerCertificate){$s.SignerCertificate.GetNameInfo([System.Security.Cryptography.X509Certificates.X509NameType]::SimpleName,$false)}else{''})}|ConvertTo-Json -Compress"
        Dim info As New ProcessStartInfo(ps) With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True, .RedirectStandardError = True}
        For Each arg In {"-NoLogo", "-NoProfile", "-NonInteractive", "-EncodedCommand", Convert.ToBase64String(Encoding.Unicode.GetBytes(script))}
            info.ArgumentList.Add(arg)
        Next
        Using timer = CancellationTokenSource.CreateLinkedTokenSource(cancellation)
            timer.CancelAfter(TimeSpan.FromSeconds(45))
            Using proc As New Process With {.StartInfo = info}
                proc.Start()
                Dim output = proc.StandardOutput.ReadToEndAsync()
                Dim errors = proc.StandardError.ReadToEndAsync()
                Try
                    Await proc.WaitForExitAsync(timer.Token)
                Catch
                    Try
                        If Not proc.HasExited Then proc.Kill(True)
                    Catch ex As InvalidOperationException
                    End Try
                    Throw
                End Try
                Dim raw = Await output
                Dim ignored = Await errors
                If proc.ExitCode <> 0 Then Throw New InvalidDataException("Windows kunne ikke kontrollere signaturen. Filen blir ikke startet.")
                Using doc = JsonDocument.Parse(raw.Trim().TrimStart(ChrW(&HFEFF)))
                    Dim status = doc.RootElement.GetProperty("Status").GetString()
                    Dim signer = doc.RootElement.GetProperty("Publisher").GetString()
                    If status <> "Valid" OrElse Not publishers.Any(Function(p) String.Equals(p, signer, StringComparison.OrdinalIgnoreCase)) Then
                        Throw New InvalidDataException("Signatur eller utgiver kunne ikke godkjennes (" & status & "). Bruk leverandørens offisielle nettside eller kontakt veileder.")
                    End If
                    Return If(signer, "")
                End Using
            End Using
        End Using
    End Function
End Module
