Imports System
Imports System.Linq

Public Module UrlPolicy
    Public Function AllowedDownload(uri As Uri, suffixes As String()) As Boolean
        If uri Is Nothing OrElse uri.Scheme <> Uri.UriSchemeHttps OrElse uri.Port <> 443 OrElse uri.UserInfo.Length > 0 Then Return False
        Return suffixes.Any(Function(s) uri.IdnHost.Equals(s, StringComparison.OrdinalIgnoreCase) OrElse uri.IdnHost.EndsWith("." & s, StringComparison.OrdinalIgnoreCase))
    End Function
    Public Function IsAiEndpoint(value As String) As Boolean
        Dim u As Uri = Nothing
        If Not Uri.TryCreate(value, UriKind.Absolute, u) OrElse u.UserInfo.Length > 0 OrElse u.Fragment.Length > 0 Then Return False
        If u.Scheme = "https" Then Return True
        Return u.Scheme = "http" AndAlso (u.Host = "127.0.0.1" OrElse u.Host = "localhost" OrElse u.Host = "[::1]" OrElse u.Host = "::1")
    End Function
    Public Function IsDiscordInvite(value As String) As Boolean
        Dim u As Uri = Nothing
        If Not Uri.TryCreate(value, UriKind.Absolute, u) OrElse u.Scheme <> "https" OrElse u.UserInfo.Length > 0 OrElse u.Port <> 443 Then Return False
        If u.Host.Equals("discord.gg", StringComparison.OrdinalIgnoreCase) Then Return u.AbsolutePath.Trim("/"c).Length > 0
        Return u.Host.Equals("discord.com", StringComparison.OrdinalIgnoreCase) AndAlso u.AbsolutePath.StartsWith("/invite/", StringComparison.Ordinal) AndAlso u.AbsolutePath.Length > 8
    End Function
End Module
