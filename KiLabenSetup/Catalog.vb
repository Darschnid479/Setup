Imports System
Imports System.Runtime.InteropServices

Public Class AppPackage
    Public Property Id As String = ""
    Public Property Title As String = ""
    Public Property Source As Uri
    Public Property Page As String = ""
    Public Property AllowedHosts As String() = Array.Empty(Of String)()
    Public Property Publishers As String() = Array.Empty(Of String)()
    Public ReadOnly Property FileName As String
        Get
            Return Id & "-setup.exe"
        End Get
    End Property
End Class

Public Module Catalog
    Public Function IsBrowser(id As String) As Boolean
        Return id = "chrome" OrElse id = "firefox" OrElse id = "edge"
    End Function
    Public Function GetPackage(id As String, architecture As Architecture) As AppPackage
        If architecture <> Architecture.X64 Then
            Throw New PlatformNotSupportedException("Direkte nedlasting er satt opp for Windows x64. På ARM64 og andre systemer: bruk leverandørens nettside og velg riktig utgave.")
        End If
        Select Case id
            Case "discord"
                Return New AppPackage With {
                    .Id = id, .Title = "Discord", .Page = "https://discord.com/download",
                    .Source = New Uri("https://discord.com/api/download?platform=win"),
                    .AllowedHosts = {"discord.com", "discordapp.com", "discordapp.net"},
                    .Publishers = {"Discord Inc.", "Discord, Inc.", "Discord Inc"}}
            Case "chrome"
                Return New AppPackage With {
                    .Id = id, .Title = "Google Chrome", .Page = "https://www.google.com/chrome/",
                    .Source = New Uri("https://dl.google.com/chrome/install/ChromeStandaloneSetup64.exe"),
                    .AllowedHosts = {"dl.google.com", "dl-ssl.google.com", "edgedl.me.gvt1.com"}, .Publishers = {"Google LLC"}}
            Case "firefox"
                Return New AppPackage With {
                    .Id = id, .Title = "Mozilla Firefox", .Page = "https://www.firefox.com/",
                    .Source = New Uri("https://download.mozilla.org/?product=firefox-latest-ssl&os=win64&lang=nb-NO"),
                    .AllowedHosts = {"download.mozilla.org", "mozilla.net", "archive.mozilla.org", "ftp.mozilla.org"}, .Publishers = {"Mozilla Corporation"}}
            Case "edge"
                Return New AppPackage With {
                    .Id = id, .Title = "Microsoft Edge", .Page = "https://www.microsoft.com/edge/download",
                    .Source = New Uri("https://go.microsoft.com/fwlink/?linkid=2109047&Channel=Stable&language=nb"),
                    .AllowedHosts = {"go.microsoft.com", "download.microsoft.com", "msedge.sf.dl.delivery.mp.microsoft.com", "msedge.b.tlu.dl.delivery.mp.microsoft.com", "msedge.api.cdp.microsoft.com"},
                    .Publishers = {"Microsoft Corporation"}}
            Case Else
                Throw New ArgumentException("Ukjent programvalg.")
        End Select
    End Function
End Module
