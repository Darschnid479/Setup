Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class MainForm
    Private _state As New SetupState()
    Private _settings As New SetupSettings()
    Private _loading As Boolean = True
    Private _ready As Boolean
    Private _busy As Boolean
    Private _operation As CancellationTokenSource
    Private _motion As UiMotion
    Private _logo As Bitmap
    Private _nav As Button()
    Private _checks As Dictionary(Of String, CheckBox)
    Private ReadOnly _downloads As New Dictionary(Of String, VerifiedDownload)(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly _downloader As New DownloadService()
    Private _aiContext As Integer
    Private _lastOperation As String = ""

    Public Sub New()
        InitializeComponent()
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        _ready = True
        DoubleBuffered = True
        _nav = {btnStepProfile, btnStepBrowser, btnStepEmail, btnStepGoogle, btnStepChatGPT, btnStepDiscord, btnStepDrive, btnStepAi, btnStepFinish}
        _checks = New Dictionary(Of String, CheckBox) From {
            {"browser", chkBrowser}, {"email", chkEmail}, {"google", chkGoogle},
            {"chatgpt", chkChatGPT}, {"discord", chkDiscord}, {"drive", chkDrive}}
        _logo = BrandAssets.LoadLogo()
        picLogo.Image = _logo ' embedded official pixels, white on the permanent dark logo panel
        tabWizard.Appearance = TabAppearance.FlatButtons
        tabWizard.SizeMode = TabSizeMode.Fixed
        tabWizard.ItemSize = New Size(1, 1)
        tabWizard.Multiline = True
        tabWizard.TabStop = False
        sidebar.AutoScroll = True
        sidebar.AutoScrollMinSize = New Size(0, 810)
        For Each page As TabPage In tabWizard.TabPages
            page.AutoScrollMinSize = New Size(945, 630)
        Next
        pnlNavIndicator.BackColor = Color.FromArgb(98, 229, 214)
        pnlProgressFill.BackColor = Color.FromArgb(98, 229, 214)
        _motion = New UiMotion(Me, pnlNavIndicator, pnlProgressTrack, pnlProgressFill, pnlHeroArt)
        For Each item In Children(Me)
            If TypeOf item Is Button Then
                Dim b = DirectCast(item, Button)
                b.FlatAppearance.BorderColor = Color.FromArgb(46, 62, 86)
                b.FlatAppearance.BorderSize = 1
                UiMotion.Round(b, 9)
                AddHandler b.SizeChanged, Sub() UiMotion.Round(b, 9)
                If Not b.Name.StartsWith("btnStep", StringComparison.Ordinal) Then _motion.Register(b)
            End If
        Next
        UiMotion.Round(cardProfile, 15)
        WireEvents()
        Dim settingsWarning As String = ""
        _settings = StateStorage.LoadSettings(settingsWarning)
        Dim stateWarning As String = ""
        _state = StateStorage.Load(stateWarning)
        If Not _state.Remember Then _state.SelectedBrowser = _settings.DefaultBrowser
        RestoreState()
        _loading = False
        RefreshUi()
        If settingsWarning.Length > 0 Then ShowStatus(settingsWarning, True)
        If stateWarning.Length > 0 Then ShowStatus(stateWarning, True)
    End Sub

    Private Shared Iterator Function Children(parent As Control) As IEnumerable(Of Control)
        For Each child As Control In parent.Controls
            Yield child
            For Each other In Children(child)
                Yield other
            Next
        Next
    End Function

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        If Not _ready Then Return
        Dim area = Screen.FromControl(Me).WorkingArea
        MinimumSize = New Size(Math.Min(MinimumSize.Width, area.Width), Math.Min(MinimumSize.Height, area.Height))
        Size = New Size(Math.Min(Width, area.Width), Math.Min(Height, area.Height))
        CenterToScreen()
        txtFirstName.Focus()
    End Sub

    Private Sub WireEvents()
        For i As Integer = 0 To _nav.Length - 1
            Dim index = i
            AddHandler _nav(i).Click, Sub() Navigate(index)
        Next
        AddHandler txtFirstName.TextChanged, AddressOf ProfileChanged
        AddHandler txtLastName.TextChanged, AddressOf ProfileChanged
        AddHandler cmbRole.SelectedIndexChanged, AddressOf ProfileChanged
        AddHandler cmbExperience.SelectedIndexChanged, AddressOf ProfileChanged
        AddHandler chkRemember.CheckedChanged, Sub()
                                                  If _loading Then Return
                                                  _state.Remember = chkRemember.Checked
                                                  Persist()
                                              End Sub
        AddHandler chkMotion.CheckedChanged, Sub()
                                                If _loading Then Return
                                                _state.Animations = chkMotion.Checked
                                                _motion.Enabled = chkMotion.Checked
                                                Persist()
                                            End Sub
        For Each pair In _checks
            Dim key = pair.Key
            AddHandler pair.Value.CheckedChanged, Sub() ConfirmChanged(key)
        Next
        AddHandler rbChrome.CheckedChanged, Sub() BrowserChanged("chrome", rbChrome.Checked)
        AddHandler rbFirefox.CheckedChanged, Sub() BrowserChanged("firefox", rbFirefox.Checked)
        AddHandler rbEdge.CheckedChanged, Sub() BrowserChanged("edge", rbEdge.Checked)
        AddHandler btnBack.Click, Sub() Navigate(Math.Max(0, tabWizard.SelectedIndex - 1))
        AddHandler btnNext.Click, AddressOf NextClicked
        AddHandler btnReset.Click, AddressOf ResetClicked
        AddHandler btnNewMember.Click, AddressOf ResetClicked
        AddHandler btnBrowserDownload.Click, AddressOf BrowserDownloadClicked
        AddHandler btnDiscordDownload.Click, AddressOf DiscordDownloadClicked
        AddHandler btnStarterPack.Click, AddressOf StarterPackClicked
        AddHandler btnBrowserInstall.Click, AddressOf BrowserInstallClicked
        AddHandler btnDiscordInstall.Click, AddressOf DiscordInstallClicked
        AddHandler btnBrowserPage.Click, Sub() OpenPackagePage(_state.SelectedBrowser)
        AddHandler btnDiscordPage.Click, Sub() OpenSite("https://discord.com/download")
        AddHandler btnRefreshApps.Click, Sub() RefreshApps()
        AddHandler btnDefaultBrowser.Click, Sub()
                                                Try
                                                    Process.Start(New ProcessStartInfo("ms-settings:defaultapps") With {.UseShellExecute = True})
                                                Catch
                                                    ShowStatus("Åpne Windows-innstillinger > Apper > Standardapper manuelt.", True)
                                                End Try
                                            End Sub
        AddHandler btnDownloadsFolder.Click, Sub()
                                                Try
                                                    Directory.CreateDirectory(DownloadService.DownloadFolder)
                                                    Process.Start(New ProcessStartInfo(DownloadService.DownloadFolder) With {.UseShellExecute = True})
                                                Catch
                                                    ShowStatus("Kunne ikke åpne nedlastingsmappen.", True)
                                                End Try
                                            End Sub
        AddHandler btnCancel.Click, Sub()
                                        _operation?.Cancel()
                                        ShowStatus("Avbryter pågående forespørsel ...")
                                    End Sub
        AddHandler btnCopyEmail.Click, Sub() CopyEmail()
        AddHandler btnOpenWebmail.Click, Sub() OpenSite(ExternalLinks.Webmail)
        AddHandler btnOpenGoogle.Click, Sub()
                                           If Not ValidProfile() Then Return
                                           CopyEmail()
                                           OpenSite(ExternalLinks.GoogleSignup)
                                       End Sub
        AddHandler btnWorkspace.Click, Sub() OpenSite(ExternalLinks.Workspace)
        AddHandler btnChatWebmail.Click, Sub() OpenSite(ExternalLinks.Webmail)
        AddHandler btnOpenChatGPT.Click, Sub() OpenSite(ExternalLinks.ChatGpt)
        AddHandler btnDiscordApp.Click, Sub() OpenSite(ExternalLinks.DiscordApp)
        AddHandler btnDiscordInvite.Click, AddressOf InviteClicked
        AddHandler btnDrive.Click, Sub() OpenSite(ExternalLinks.Drive)
        AddHandler btnDocs.Click, Sub() OpenSite(ExternalLinks.Docs)
        AddHandler btnHelpEmail.Click, Sub() OpenHelp(2)
        AddHandler btnHelpGoogle.Click, Sub() OpenHelp(3)
        AddHandler btnHelpChatGPT.Click, Sub() OpenHelp(4)
        AddHandler btnHelpDrive.Click, Sub() OpenHelp(6)
        AddHandler btnLocalHelp.Click, Sub()
                                           Dim i = Math.Max(0, cmbAiStep.SelectedIndex)
                                           txtAiAnswer.Text = "LOKAL STEGVEILEDNING (ikke AI)" & vbCrLf & vbCrLf & Steps.Guides(i)
                                       End Sub
        AddHandler btnAsk.Click, AddressOf AskClicked
        AddHandler btnAiClear.Click, Sub()
                                        If _busy Then Return
                                        txtQuestion.Clear() : txtAiAnswer.Clear() : txtAiCode.Clear()
                                        chkAiConsent.Checked = False
                                        ShowStatus("AI-tekst og tilgangskode er tømt fra programmet.")
                                    End Sub
        AddHandler btnCopyReport.Click, Sub() CopyText(txtReport.Text)
        AddHandler btnSaveReport.Click, AddressOf SaveReportClicked
        AddHandler Activated, Sub()
                                  If _ready AndAlso Not _loading Then RefreshApps()
                              End Sub
    End Sub

    Private Sub RestoreState()
        _loading = True
        txtFirstName.Text = _state.Profile.FirstName
        txtLastName.Text = _state.Profile.LastName
        Dim role = cmbRole.Items.IndexOf(_state.Profile.Role)
        cmbRole.SelectedIndex = If(role < 0, 0, role)
        Dim experience = cmbExperience.Items.IndexOf(_state.Profile.Experience)
        cmbExperience.SelectedIndex = If(experience < 0, 0, experience)
        rbChrome.Checked = _state.SelectedBrowser = "chrome"
        rbFirefox.Checked = _state.SelectedBrowser = "firefox"
        rbEdge.Checked = _state.SelectedBrowser = "edge"
        chkRemember.Checked = _state.Remember
        chkMotion.Checked = _state.Animations AndAlso UiMotion.SystemAllowsMotion()
        _motion.Enabled = chkMotion.Checked
        For Each pair In _checks
            pair.Value.Checked = IsDone(pair.Key)
        Next
        cmbAiStep.SelectedIndex = 0
        tabWizard.SelectedIndex = Math.Clamp(_state.CurrentStep, 0, 8)
        lblEmailGuide.Text = Steps.Guides(2)
        lblGoogleGuide.Text = Steps.Guides(3)
        lblChatGPTGuide.Text = Steps.Guides(4)
        lblDriveGuide.Text = Steps.Guides(6)
        txtAiAnswer.Text = "Spør om kontoer, nedlasting eller neste steg. En veileder må koble til KI-Labens AI-server først. Lokal stegveiledning er alltid tilgjengelig."
        _loading = False
    End Sub

    Private Sub ProfileChanged(sender As Object, e As EventArgs)
        If _loading Then Return
        Dim previous = _state.Profile.WorkEmail
        _state.Profile.FirstName = txtFirstName.Text.Trim()
        _state.Profile.LastName = txtLastName.Text.Trim()
        _state.Profile.Role = cmbRole.Text
        _state.Profile.Experience = cmbExperience.Text
        If previous <> _state.Profile.WorkEmail Then
            _state.Completed.Clear()
            _loading = True
            For Each chk In _checks.Values
                chk.Checked = False
            Next
            _loading = False
            ShowStatus("Arbeidsadresse oppdatert. Veileder må kontrollere at den er ledig eller tilhører deg.")
        End If
        RefreshUi() : Persist()
    End Sub

    Private Function ValidProfile() As Boolean
        Dim valid = _state.Profile.Username.Length > 0 AndAlso _state.Profile.Username.Length <= 64 AndAlso
            _state.Profile.FirstName.Length <= 100 AndAlso _state.Profile.LastName.Length <= 100 AndAlso
            Not _state.Profile.FirstName.Contains("@") AndAlso Not _state.Profile.LastName.Contains("@")
        If Not valid Then ShowStatus("Fyll inn gyldig fornavn først. Ingen privat e-postadresse skal skrives her.", True)
        Return valid
    End Function

    Private Sub ConfirmChanged(key As String)
        If _loading Then Return
        If Not ValidProfile() Then
            _loading = True : _checks(key).Checked = False : _loading = False
            Return
        End If
        _state.Completed(key) = _checks(key).Checked
        RefreshUi() : Persist()
        Dim index = Array.IndexOf(Steps.Keys, key)
        If _state.Completed(key) AndAlso tabWizard.SelectedIndex = index Then
            Navigate(If(index = 6, 8, index + 1))
        End If
    End Sub

    Private Sub BrowserChanged(id As String, isChecked As Boolean)
        If _loading OrElse Not isChecked Then Return
        If _state.SelectedBrowser <> id Then
            _state.SelectedBrowser = id
            _state.Completed("browser") = False
            _loading = True : chkBrowser.Checked = False : _loading = False
        End If
        RefreshUi() : Persist()
    End Sub

    Private Function IsDone(key As String) As Boolean
        Return _state.Completed.ContainsKey(key) AndAlso _state.Completed(key)
    End Function

    Private Sub Navigate(index As Integer)
        If index < 0 OrElse index > 8 Then Return
        If index = 7 AndAlso tabWizard.SelectedIndex < 7 Then
            _aiContext = tabWizard.SelectedIndex
            cmbAiStep.SelectedIndex = _aiContext
        End If
        tabWizard.SelectedIndex = index : _state.CurrentStep = index
        RefreshUi() : Persist()
    End Sub

    Private Sub OpenHelp(index As Integer)
        Navigate(7)
        _aiContext = index : cmbAiStep.SelectedIndex = index
        txtAiAnswer.Text = "LOKAL STEGVEILEDNING (ikke AI)" & vbCrLf & vbCrLf & Steps.Guides(index)
    End Sub

    Private Sub NextClicked(sender As Object, e As EventArgs)
        Dim i = tabWizard.SelectedIndex
        If i = 0 Then
            If Not ValidProfile() Then Return
            _state.Completed("profile") = True
        ElseIf i < 7 Then
            If Not IsDone(Steps.Keys(i)) Then
                ShowStatus("Bekreft steget når det faktisk fungerer. Åpnet lenke eller nedlastet fil er ikke en ferdig konto.", True)
                Return
            End If
        ElseIf i = 8 Then
            If Not Steps.Keys.All(Function(k) IsDone(k)) Then
                ShowStatus("Det gjenstår steg. Se rapporten og gå tilbake til de som mangler.", True)
            Else
                ShowStatus("Alle steg er bekreftet. Du kan lagre rapporten og starte med et nytt medlem.")
            End If
            Return
        End If
        Navigate(If(i = 6, 8, i + 1))
    End Sub

    Private Sub RefreshUi()
        If Not _ready Then Return
        Dim index = tabWizard.SelectedIndex
        lblHeader.Text = Steps.Titles(index)
        lblKicker.Text = If(index = 7, "HJELP NÅR DU TRENGER DET", "OPPSTART  /  KI-LABEN")
        lblHeaderSub.Text = If(index = 7, "AI gir råd. Du godkjenner handlingene.", "Vi guider deg videre. Kontoer bekreftes av deg.")
        txtUsername.Text = _state.Profile.Username
        For Each l In {lblEmailAccount, lblGoogleAccount, lblChatGPTAccount, lblDriveAccount}
            l.Text = _state.Profile.WorkEmail
        Next
        For i = 0 To _nav.Length - 1
            _nav(i).BackColor = If(i = index, Color.FromArgb(28, 69, 79), Color.FromArgb(17, 29, 50))
            _nav(i).FlatAppearance.BorderColor = If(i = index, Color.FromArgb(98, 229, 214), Color.FromArgb(34, 48, 71))
        Next
        Dim count = Steps.Keys.Count(Function(k) IsDone(k))
        lblProgress.Text = count.ToString() & " av 7 steg bekreftet"
        _motion.Target(_nav(index).Top, count / 7.0R)
        btnBack.Enabled = index > 0 AndAlso Not _busy
        btnNext.Enabled = Not _busy
        btnNext.Text = If(index = 8, "Fullfør", If(index = 7, "Til oppsummering", "Fortsett  →"))
        If String.IsNullOrWhiteSpace(_settings.AiEndpoint) Then
            lblAiConnection.Text = "AI: ikke konfigurert. Lokal stegveiledning virker."
        Else
            Dim u As New Uri(_settings.AiEndpoint)
            lblAiConnection.Text = "AI-server konfigurert: " & u.Host & "  |  tilgang kontrolleres når du spør"
        End If
        lblDiscordInvite.Text = If(String.IsNullOrWhiteSpace(_settings.DiscordInvite),
            "Invitasjonskode mangler. Be veileder om KI-Labens faktiske Discord-invitasjon.",
            "KI-Labens serverinvitasjon er konfigurert. Godta den i Discord når du er klar.")
        btnDiscordInvite.Enabled = Not String.IsNullOrWhiteSpace(_settings.DiscordInvite)
        RefreshApps() : UpdateReport()
    End Sub

    Private Sub RefreshApps()
        If _loading OrElse Not _ready Then Return
        Dim found = BrowserService.FindInstalled(_state.SelectedBrowser)
        lblBrowserDetected.Text = If(found.Length > 0,
            "Valgt nettleser ble funnet på maskinen. Du kan bruke den eller laste ned på nytt.",
            "Valgt nettleser ble ikke funnet i standardplasseringene. Last ned, installer og sjekk på nytt.")
        For Each pair In New Dictionary(Of RadioButton, String) From {{rbChrome, "chrome"}, {rbFirefox, "firefox"}, {rbEdge, "edge"}}
            pair.Key.FlatAppearance.BorderColor = If(pair.Value = _state.SelectedBrowser, Color.FromArgb(98, 229, 214), Color.FromArgb(44, 61, 83))
            pair.Key.BackColor = If(pair.Value = _state.SelectedBrowser, Color.FromArgb(23, 52, 63), Color.FromArgb(17, 29, 50))
        Next
        btnBrowserInstall.Enabled = Not _busy AndAlso _downloads.ContainsKey(_state.SelectedBrowser)
        btnDiscordInstall.Enabled = Not _busy AndAlso _downloads.ContainsKey("discord")
    End Sub

    Private Sub Persist()
        If _loading Then Return
        Dim warning As String = ""
        If Not StateStorage.Save(_state, warning) Then ShowStatus(warning, True)
    End Sub

    Private Sub SetBusy(value As Boolean)
        _busy = value
        _motion.Busy = value
        btnCancel.Visible = value
        For Each b In {btnBrowserDownload, btnDiscordDownload, btnStarterPack, btnAsk, btnBrowserInstall, btnDiscordInstall, btnNext, btnBack, btnReset, btnNewMember}
            b.Enabled = Not value
        Next
        For Each radio In {rbChrome, rbFirefox, rbEdge}
            radio.Enabled = Not value
        Next
        txtFirstName.Enabled = Not value
        txtLastName.Enabled = Not value
        If Not value Then RefreshUi()
    End Sub

    Private Async Sub BrowserDownloadClicked(sender As Object, e As EventArgs)
        Await RunDownloadsAsync(New String() {_state.SelectedBrowser}, False)
    End Sub
    Private Async Sub DiscordDownloadClicked(sender As Object, e As EventArgs)
        Await RunDownloadsAsync(New String() {"discord"}, False)
    End Sub
    Private Async Sub StarterPackClicked(sender As Object, e As EventArgs)
        Await RunDownloadsAsync(New String() {_state.SelectedBrowser, "discord"}, True)
    End Sub

    Private Async Function RunDownloadsAsync(ids As IEnumerable(Of String), skipInstalled As Boolean) As Task
        If _busy Then Return
        Dim queue = ids.Where(Function(id) Not skipInstalled OrElse BrowserService.FindInstalled(id).Length = 0).ToArray()
        If queue.Length = 0 Then
            ShowStatus("Valgt nettleser og Discord er allerede funnet. Test innlogging og servertilgang før du bekrefter stegene.")
            Return
        End If
        SetBusy(True)
        _operation = New CancellationTokenSource()
        Dim activeId As String = ""
        Try
            For Each id In queue
                activeId = id
                _downloads.Remove(id)
                Dim package = Catalog.GetPackage(id, RuntimeInformation.OSArchitecture)
                _lastOperation = "Laster ned " & package.Title
                ShowStatus(_lastOperation)
                Dim reporter As IProgress(Of TransferProgress) = New Progress(Of TransferProgress)(Sub(p) UpdateTransfer(id, p))
                Dim item = Await _downloader.DownloadAsync(package, reporter, _operation.Token)
                _downloads(id) = item
            Next
            ShowStatus("Nedlasting og signaturkontroll ferdig. Trykk Start installasjon for hvert program.")
        Catch ex As OperationCanceledException
            If activeId.Length > 0 Then
                Dim label = If(activeId = "discord", lblDiscordTransfer, lblBrowserTransfer)
                label.Text = "Nedlasting avbrutt. Ingen ny kontrollert fil klar."
            End If
            ShowStatus("Nedlasting avbrutt eller tidsavbrutt. Ufullstendige filer er forsøkt slettet.", True)
        Catch ex As Exception
            If activeId.Length > 0 Then
                Dim label = If(activeId = "discord", lblDiscordTransfer, lblBrowserTransfer)
                label.Text = "Nedlasting stoppet. Se statusmeldingen eller bruk offisiell nettside."
            End If
            ShowStatus("Nedlasting stoppet: " & ex.Message, True)
        Finally
            _operation.Dispose() : _operation = Nothing
            barBrowser.Style = ProgressBarStyle.Continuous
            barDiscord.Style = ProgressBarStyle.Continuous
            SetBusy(False)
            UpdateReport()
        End Try
    End Function

    Private Sub UpdateTransfer(id As String, p As TransferProgress)
        If IsDisposed Then Return
        Dim bar = If(id = "discord", barDiscord, barBrowser)
        Dim lbl = If(id = "discord", lblDiscordTransfer, lblBrowserTransfer)
        Dim details = p.Title & "  |  " & p.Message & "  |  " & (p.Received / 1048576.0R).ToString("0.0") & " MB"
        If p.Total.HasValue AndAlso p.Total.Value > 0 Then
            bar.Style = ProgressBarStyle.Continuous
            bar.Value = Math.Clamp(CInt(Math.Floor(100.0R * p.Received / p.Total.Value)), 0, 100)
            details &= " / " & (p.Total.Value / 1048576.0R).ToString("0.0") & " MB"
        Else
            bar.Style = If(chkMotion.Checked, ProgressBarStyle.Marquee, ProgressBarStyle.Continuous)
        End If
        If p.BytesPerSecond > 0 Then details &= "  |  " & (p.BytesPerSecond / 1048576.0R).ToString("0.0") & " MB/s"
        lbl.Text = details
    End Sub

    Private Async Sub BrowserInstallClicked(sender As Object, e As EventArgs)
        Await StartInstallerAsync(_state.SelectedBrowser)
    End Sub
    Private Async Sub DiscordInstallClicked(sender As Object, e As EventArgs)
        Await StartInstallerAsync("discord")
    End Sub
    Private Async Function StartInstallerAsync(id As String) As Task
        If _busy OrElse Not _downloads.ContainsKey(id) Then Return
        Dim item = _downloads(id)
        If MessageBox.Show(Me, "Starte installasjonen av " & item.Package.Title & "?" & vbCrLf & vbCrLf &
            "Digital signatur: " & item.Publisher & vbCrLf & "Windows kan be om godkjenning. Programmet blir ikke installert skjult.",
            "Bekreft installasjon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        SetBusy(True) : _operation = New CancellationTokenSource()
        Try
            ShowStatus("Kontrollerer filen på nytt før oppstart ...")
            Await _downloader.LaunchAsync(item, _operation.Token)
            ShowStatus("Installasjonsprogrammet er startet. Fullfør det og trykk Sjekk på nytt. Kontoen er ikke automatisk bekreftet.")
        Catch ex As OperationCanceledException
            ShowStatus("Oppstart av installasjonsprogrammet ble avbrutt.", True)
        Catch ex As Exception
            ShowStatus("Installasjonen ble ikke startet: " & ex.Message, True)
        Finally
            _operation.Dispose() : _operation = Nothing
            SetBusy(False)
        End Try
    End Function

    Private Sub OpenPackagePage(id As String)
        Select Case id
            Case "chrome" : OpenSite("https://www.google.com/chrome/")
            Case "firefox" : OpenSite("https://www.firefox.com/")
            Case "edge" : OpenSite("https://www.microsoft.com/edge/download")
        End Select
    End Sub

    Private Sub OpenSite(url As String)
        Try
            Dim usedChoice = BrowserService.OpenWeb(url, _state.SelectedBrowser)
            ShowStatus(If(usedChoice, "Åpnet i valgt nettleser.", "Valgt nettleser ble ikke funnet. Lenken ble åpnet i Windows-standardnettleseren."))
        Catch
            ShowStatus("Kunne ikke åpne lenken. Be veileder kontrollere nettleseroppsettet.", True)
        End Try
    End Sub

    Private Sub InviteClicked(sender As Object, e As EventArgs)
        If Not UrlPolicy.IsDiscordInvite(_settings.DiscordInvite) Then
            ShowStatus("KI-Labens Discord-invitasjon mangler. discord.gg alene er ikke en serverinvitasjon.", True)
            Return
        End If
        OpenSite(_settings.DiscordInvite)
    End Sub

    Private Sub CopyEmail()
        If Not ValidProfile() Then Return
        CopyText(_state.Profile.WorkEmail)
    End Sub
    Private Sub CopyText(text As String)
        Try
            If text.Length > 0 Then Clipboard.SetText(text)
            ShowStatus("Kopiert. Lim inn der du trenger det.")
        Catch ex As ExternalException
            ShowStatus("Utklippstavlen er opptatt. Prøv igjen.", True)
        End Try
    End Sub

    Private Async Sub AskClicked(sender As Object, e As EventArgs)
        If _busy Then Return
        If Not chkAiConsent.Checked Then
            ShowStatus("Bekreft at spørsmålet kan sendes. Ikke ta med passord eller personopplysninger.", True)
            Return
        End If
        If txtQuestion.Text.Trim().Length = 0 Then
            ShowStatus("Skriv spørsmålet først.", True)
            Return
        End If
        SetBusy(True) : _operation = New CancellationTokenSource()
        Try
            ShowStatus("Venter på AI-serveren ...")
            Dim key = Steps.Keys(Math.Clamp(cmbAiStep.SelectedIndex, 0, 6))
            Dim ai As New AiClient()
            Dim answer = Await ai.AskAsync(_settings.AiEndpoint, txtAiCode.Text.Trim(), txtQuestion.Text, key, _operation.Token)
            txtAiAnswer.Text = "AI-SVAR - kontroller viktige opplysninger med veileder" & vbCrLf & vbCrLf & answer
            ShowStatus("AI-svar mottatt. Ingen handlinger eller kontosteg er utført av AI.")
        Catch ex As OperationCanceledException
            ShowStatus("AI-forespørselen ble avbrutt eller tok for lang tid.", True)
        Catch ex As Exception
            txtAiAnswer.Text = "AI SVARTE IKKE" & vbCrLf & ex.Message & vbCrLf & vbCrLf &
                "LOKAL STEGVEILEDNING (ikke AI)" & vbCrLf & Steps.Guides(Math.Clamp(cmbAiStep.SelectedIndex, 0, 6))
            ShowStatus(ex.Message, True)
        Finally
            _operation.Dispose() : _operation = Nothing
            SetBusy(False)
        End Try
    End Sub

    Private Sub UpdateReport()
        Dim b As New StringBuilder()
        b.AppendLine("KI-LABEN | OPPSTARTSRAPPORT")
        b.AppendLine("Navn: " & _state.Profile.FullName)
        b.AppendLine("Arbeidsadresse: " & _state.Profile.WorkEmail)
        b.AppendLine("Rolle: " & _state.Profile.Role)
        b.AppendLine("Erfaring: " & _state.Profile.Experience)
        b.AppendLine("Valgt nettleser: " & _state.SelectedBrowser)
        b.AppendLine()
        b.AppendLine("BEKREFTET AV MEDLEMMET")
        For i = 0 To 6
            b.AppendLine(If(IsDone(Steps.Keys(i)), "[OK] ", "[  ] ") & Steps.Titles(i))
        Next
        b.AppendLine()
        b.AppendLine("NEDLASTINGER I DENNE ØKTEN (ikke installasjonsbevis)")
        If _downloads.Count = 0 Then b.AppendLine("Ingen kontrollerte nedlastinger i denne økten.")
        For Each item In _downloads.Values
            b.AppendLine(item.Package.Title & " - signatur godkjent: " & item.Publisher)
            b.AppendLine("SHA-256: " & item.Sha256)
        Next
        b.AppendLine()
        b.AppendLine("AI er et veiledningstillegg. AI-spørsmål og tilgangskode er ikke med i rapporten.")
        b.AppendLine("Tidspunkt: " & DateTime.Now.ToString("dd.MM.yyyy HH:mm"))
        txtReport.Text = b.ToString()
    End Sub

    Private Sub SaveReportClicked(sender As Object, e As EventArgs)
        Using dialog As New SaveFileDialog With {.Filter = "Tekstfil (*.txt)|*.txt", .FileName = "KI-Laben-oppstartsrapport.txt"}
            If dialog.ShowDialog(Me) <> DialogResult.OK Then Return
            Try
                File.WriteAllText(dialog.FileName, txtReport.Text, New UTF8Encoding(False))
                ShowStatus("Rapporten er lagret der du valgte. Den inneholder arbeidsnavn og arbeidsadresse.")
            Catch ex As Exception
                ShowStatus("Rapporten kunne ikke lagres: " & ex.Message, True)
            End Try
        End Using
    End Sub

    Private Sub ResetClicked(sender As Object, e As EventArgs)
        If _busy Then Return
        If MessageBox.Show(Me, "Tømme profil, lokal fremdrift og AI-felter?" & vbCrLf & vbCrLf &
            "Dette logger ikke ut nettsider i nettleseren og sletter ikke eksporterte rapporter. Logg ut av kontoene manuelt på en delt PC.",
            "Nytt medlem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Dim warning As String = ""
        If Not StateStorage.Clear(warning) Then
            ShowStatus(warning, True) : Return
        End If
        Try
            If Clipboard.ContainsText() AndAlso Clipboard.GetText() = _state.Profile.WorkEmail Then Clipboard.Clear()
        Catch ex As ExternalException
        End Try
        _state = New SetupState With {.SelectedBrowser = _settings.DefaultBrowser}
        _downloads.Clear()
        txtAiCode.Clear() : txtQuestion.Clear() : txtAiAnswer.Clear() : chkAiConsent.Checked = False
        RestoreState() : RefreshUi()
        ShowStatus("Klar for neste medlem. Husk å logge ut av tjenestene på en delt maskin.")
    End Sub

    Private Sub ShowStatus(text As String, Optional failure As Boolean = False)
        lblStatus.Text = text
        lblStatus.ForeColor = If(failure, Color.FromArgb(255, 187, 118), Color.FromArgb(166, 181, 207))
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If _busy Then
            _operation?.Cancel()
            e.Cancel = True
            ShowStatus("Avbryter. Lukk vinduet når forespørselen er avsluttet.")
            Return
        End If
        If _ready Then Persist()
        MyBase.OnFormClosing(e)
    End Sub
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        _motion?.Dispose()
        If _logo IsNot Nothing Then _logo.Dispose()
        _operation?.Dispose()
        MyBase.OnFormClosed(e)
    End Sub
End Class
