Imports System
Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports System.Collections.Generic

Friend Module StateStorage
    ' New schema/path: removed fields from older versions are not imported.
    Private ReadOnly FolderPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KiLabenSetupLaunchpad")
    Private ReadOnly StatePath As String = Path.Combine(FolderPath, "progress.json")
    Private ReadOnly JsonOptions As New JsonSerializerOptions With {.WriteIndented = True, .PropertyNameCaseInsensitive = True}

    Public Function Load(ByRef warning As String) As SetupState
        warning = ""
        Try
            If Not File.Exists(StatePath) Then Return New SetupState()
            If New FileInfo(StatePath).Length > 100000 Then Throw New InvalidDataException()
            Dim s = JsonSerializer.Deserialize(Of SetupState)(File.ReadAllText(StatePath, Encoding.UTF8), JsonOptions)
            If s Is Nothing OrElse Not s.Remember Then Return New SetupState()
            If s.Profile Is Nothing Then s.Profile = New MemberProfile()
            s.Profile.FirstName = If(s.Profile.FirstName, "")
            s.Profile.LastName = If(s.Profile.LastName, "")
            s.Profile.Role = If(s.Profile.Role, "Deltaker")
            s.Profile.Experience = If(s.Profile.Experience, "Helt ny")
            If s.Completed Is Nothing Then s.Completed = New Dictionary(Of String, Boolean)()
            s.CurrentStep = Math.Clamp(s.CurrentStep, 0, 8)
            If Not Catalog.IsBrowser(s.SelectedBrowser) Then s.SelectedBrowser = "chrome"
            Return s
        Catch
            warning = "Lagret fremdrift kunne ikke leses. Starter et tomt oppsett."
            Return New SetupState()
        End Try
    End Function

    Public Function Save(s As SetupState, ByRef warning As String) As Boolean
        warning = ""
        Try
            If Not s.Remember Then Return Clear(warning)
            Directory.CreateDirectory(FolderPath)
            File.WriteAllText(StatePath & ".tmp", JsonSerializer.Serialize(s, JsonOptions), New UTF8Encoding(False))
            File.Move(StatePath & ".tmp", StatePath, True)
            Return True
        Catch
            warning = "Kunne ikke lagre fremdrift. Oppsettet virker fortsatt i denne økten."
            Return False
        End Try
    End Function

    Public Function Clear(ByRef warning As String) As Boolean
        warning = ""
        Try
            If File.Exists(StatePath) Then File.Delete(StatePath)
            If File.Exists(StatePath & ".tmp") Then File.Delete(StatePath & ".tmp")
            Return True
        Catch
            warning = "Lokal fremdrift kunne ikke slettes. Be veileder hjelpe."
            Return False
        End Try
    End Function

    Public Function LoadSettings(ByRef warning As String) As SetupSettings
        warning = ""
        Try
            Dim p = Path.Combine(AppContext.BaseDirectory, "setup.settings.json")
            If Not File.Exists(p) Then Return New SetupSettings()
            If New FileInfo(p).Length > 16000 Then Throw New InvalidDataException()
            Dim s = JsonSerializer.Deserialize(Of SetupSettings)(File.ReadAllText(p), JsonOptions)
            If s Is Nothing Then Return New SetupSettings()
            If Not Catalog.IsBrowser(s.DefaultBrowser) Then s.DefaultBrowser = "chrome"
            If Not String.IsNullOrWhiteSpace(s.AiEndpoint) AndAlso Not UrlPolicy.IsAiEndpoint(s.AiEndpoint) Then Throw New InvalidDataException()
            If Not String.IsNullOrWhiteSpace(s.DiscordInvite) AndAlso Not UrlPolicy.IsDiscordInvite(s.DiscordInvite) Then Throw New InvalidDataException()
            Return s
        Catch
            warning = "Innstillingsfilen er ugyldig. Bruker standardvalg uten AI-server og serverinvitasjon."
            Return New SetupSettings()
        End Try
    End Function
End Module
