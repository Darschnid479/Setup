Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports Microsoft.Win32

Friend Module BrowserService
    Public Function FindInstalled(id As String) As String
        Dim exe As String
        Dim relative As String
        Select Case id
            Case "chrome" : exe = "chrome.exe" : relative = "Google\Chrome\Application\chrome.exe"
            Case "firefox" : exe = "firefox.exe" : relative = "Mozilla Firefox\firefox.exe"
            Case "edge" : exe = "msedge.exe" : relative = "Microsoft\Edge\Application\msedge.exe"
            Case "discord"
                Dim root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Discord")
                Try
                    If Directory.Exists(root) Then
                        For Each d In Directory.GetDirectories(root, "app-*")
                            If File.Exists(Path.Combine(d, "Discord.exe")) Then Return Path.Combine(d, "Discord.exe")
                        Next
                    End If
                Catch ex As IOException
                Catch ex As UnauthorizedAccessException
                End Try
                Return ""
            Case Else : Return ""
        End Select
        For Each hive In {RegistryHive.CurrentUser, RegistryHive.LocalMachine}
            For Each view In {RegistryView.Registry64, RegistryView.Registry32}
                Try
                    Using baseKey = RegistryKey.OpenBaseKey(hive, view)
                        Using key = baseKey.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" & exe)
                            Dim p = TryCast(key?.GetValue(Nothing), String)
                            If Not String.IsNullOrWhiteSpace(p) Then
                                p = Environment.ExpandEnvironmentVariables(p.Trim(""""c))
                                If File.Exists(p) Then Return p
                            End If
                        End Using
                    End Using
                Catch ex As System.Security.SecurityException
                Catch ex As UnauthorizedAccessException
                End Try
            Next
        Next
        For Each folder In {Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolder.ProgramFiles, Environment.SpecialFolder.ProgramFilesX86}
            Dim p = Path.Combine(Environment.GetFolderPath(folder), relative)
            If File.Exists(p) Then Return p
        Next
        Return ""
    End Function

    Public Function OpenWeb(url As String, browser As String) As Boolean
        Dim uri As Uri = Nothing
        If Not Uri.TryCreate(url, UriKind.Absolute, uri) OrElse uri.Scheme <> "https" Then Throw New ArgumentException("Kun HTTPS-lenker kan åpnes her.")
        Dim path = FindInstalled(browser)
        If path.Length = 0 Then
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            Return False ' The caller informs the user that the default browser was used.
        End If
        Dim start As New ProcessStartInfo(path) With {.UseShellExecute = False}
        start.ArgumentList.Add(url)
        Process.Start(start)
        Return True
    End Function
End Module
