Imports System
Imports System.Runtime.InteropServices
Imports System.Text.Json

Friend Module TestRunner
    Private Passed As Integer
    Public Sub Main()
        Try
            Check(Names.ToUsername("Fornavn Ekstra") = "fornavn", "Only first given-name token")
            Check(Names.ToUsername(" ÅSE ") = "ase", "Norwegian letter handling")
            Check(Names.ToUsername("Ægir") = "aegir", "AE handling")
            Check(Names.ToUsername("") = "", "Empty input")
            Check(Names.ToUsername("!!!") = "", "No usable name")
            Dim profile As New MemberProfile With {.FirstName = "Fornavn", .LastName = "Etternavn"}
            Check(profile.WorkEmail = "fornavn@ki-laben.no", "Surname not used in address")
            Dim stateJson = JsonSerializer.Serialize(New SetupState())
            Check(Not stateJson.Contains("Device") AndAlso Not stateJson.Contains("Goal"), "Removed fields not serialized")
            Check(UrlPolicy.AllowedDownload(New Uri("https://stable.dl2.discordapp.net/file.exe"), {"discordapp.net"}), "Vendor subdomain")
            Check(Not UrlPolicy.AllowedDownload(New Uri("https://discordapp.net.evil.invalid/file.exe"), {"discordapp.net"}), "Suffix attack rejected")
            Check(Not UrlPolicy.AllowedDownload(New Uri("http://discord.com/file.exe"), {"discord.com"}), "No HTTP download")
            Check(Not UrlPolicy.AllowedDownload(New Uri("https://example@discord.com/file.exe"), {"discord.com"}), "No userinfo")
            Check(Not UrlPolicy.AllowedDownload(New Uri("https://discord.com:444/file.exe"), {"discord.com"}), "Port fixed")
            Check(UrlPolicy.IsAiEndpoint("https://ai.example.invalid/api/assist"), "HTTPS gateway allowed")
            Check(Not UrlPolicy.IsAiEndpoint("http://ai.example.invalid/api/assist"), "Remote HTTP rejected")
            Check(UrlPolicy.IsAiEndpoint("http://127.0.0.1:5088/api/assist"), "Loopback development")
            Check(Not UrlPolicy.IsDiscordInvite("https://discord.gg/"), "Missing invite rejected")
            Check(UrlPolicy.IsDiscordInvite("https://discord.gg/TESTCODE"), "Full invite allowed")
            Check(Not UrlPolicy.IsDiscordInvite("https://discord.gg.evil.invalid/TESTCODE"), "Fake Discord rejected")
            For Each id In {"chrome", "firefox", "edge", "discord"}
                Dim package = Catalog.GetPackage(id, Architecture.X64)
                Check(UrlPolicy.AllowedDownload(package.Source, package.AllowedHosts), "Catalog source: " & id)
                Check(package.FileName.EndsWith(".exe", StringComparison.Ordinal) AndAlso package.Publishers.Length > 0, "EXE and publisher: " & id)
            Next
            Dim rejected = False
            Try
                Catalog.GetPackage("discord", Architecture.Arm64)
            Catch ex As PlatformNotSupportedException
                rejected = True
            End Try
            Check(rejected, "Unsupported architecture uses vendor page")
            Console.WriteLine("PASS: " & Passed & " tests. No network, account actions or installations performed.")
        Catch ex As Exception
            Console.Error.WriteLine(ex.Message)
            Environment.ExitCode = 1
        End Try
    End Sub
    Private Sub Check(value As Boolean, title As String)
        If Not value Then Throw New InvalidOperationException("FAIL: " & title)
        Passed += 1
    End Sub
End Module
