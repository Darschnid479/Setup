<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SuspendLayout()
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1380, 850)
        Me.MinimumSize = New System.Drawing.Size(1080, 720)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0F)
        Me.Text = "KI-Laben Setup | Launchpad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootLayout.ColumnCount = 2
        Me.rootLayout.RowCount = 1
        Me.rootLayout.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.rootLayout.Padding = New System.Windows.Forms.Padding(0)
        Me.rootLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0F))
        Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
        Me.sidebar = New System.Windows.Forms.Panel()
        Me.sidebar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sidebar.Size = New System.Drawing.Size(250, 820)
        Me.sidebar.Margin = New System.Windows.Forms.Padding(0)
        Me.sidebar.BackColor = System.Drawing.Color.FromArgb(13, 22, 40)
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.pnlLogo.Location = New System.Drawing.Point(24, 22)
        Me.pnlLogo.Size = New System.Drawing.Size(86, 86)
        Me.pnlLogo.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.picLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.Padding = New System.Windows.Forms.Padding(9)
        Me.picLogo.AccessibleName = "KI-Laben logo"
        Me.picLogo.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.lblBrand.Text = "KI-LABEN"
        Me.lblBrand.Location = New System.Drawing.Point(24, 125)
        Me.lblBrand.Size = New System.Drawing.Size(214, 32)
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI", 17.0F, System.Drawing.FontStyle.Bold)
        Me.lblBrand.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblBrand.BackColor = System.Drawing.Color.Transparent
        Me.lblEdition = New System.Windows.Forms.Label()
        Me.lblEdition.Text = "SETUP  /  LAUNCHPAD"
        Me.lblEdition.Location = New System.Drawing.Point(24, 159)
        Me.lblEdition.Size = New System.Drawing.Size(214, 26)
        Me.lblEdition.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblEdition.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblEdition.BackColor = System.Drawing.Color.Transparent
        Me.btnStepProfile = New System.Windows.Forms.Button()
        Me.btnStepProfile.Text = "01   Din profil"
        Me.btnStepProfile.Location = New System.Drawing.Point(20, 212)
        Me.btnStepProfile.Size = New System.Drawing.Size(210, 44)
        Me.btnStepProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepProfile.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepProfile.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepProfile.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepProfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepProfile.UseVisualStyleBackColor = False
        Me.btnStepProfile.TabIndex = 6
        Me.btnStepBrowser = New System.Windows.Forms.Button()
        Me.btnStepBrowser.Text = "02   Velg nettleser"
        Me.btnStepBrowser.Location = New System.Drawing.Point(20, 258)
        Me.btnStepBrowser.Size = New System.Drawing.Size(210, 44)
        Me.btnStepBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepBrowser.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepBrowser.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepBrowser.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepBrowser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepBrowser.UseVisualStyleBackColor = False
        Me.btnStepBrowser.TabIndex = 7
        Me.btnStepEmail = New System.Windows.Forms.Button()
        Me.btnStepEmail.Text = "03   Arbeids-e-post"
        Me.btnStepEmail.Location = New System.Drawing.Point(20, 304)
        Me.btnStepEmail.Size = New System.Drawing.Size(210, 44)
        Me.btnStepEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepEmail.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepEmail.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepEmail.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepEmail.UseVisualStyleBackColor = False
        Me.btnStepEmail.TabIndex = 8
        Me.btnStepGoogle = New System.Windows.Forms.Button()
        Me.btnStepGoogle.Text = "04   Google / Workspace"
        Me.btnStepGoogle.Location = New System.Drawing.Point(20, 350)
        Me.btnStepGoogle.Size = New System.Drawing.Size(210, 44)
        Me.btnStepGoogle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepGoogle.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepGoogle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepGoogle.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepGoogle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepGoogle.UseVisualStyleBackColor = False
        Me.btnStepGoogle.TabIndex = 9
        Me.btnStepChatGPT = New System.Windows.Forms.Button()
        Me.btnStepChatGPT.Text = "05   ChatGPT"
        Me.btnStepChatGPT.Location = New System.Drawing.Point(20, 396)
        Me.btnStepChatGPT.Size = New System.Drawing.Size(210, 44)
        Me.btnStepChatGPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepChatGPT.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepChatGPT.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepChatGPT.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepChatGPT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepChatGPT.UseVisualStyleBackColor = False
        Me.btnStepChatGPT.TabIndex = 10
        Me.btnStepDiscord = New System.Windows.Forms.Button()
        Me.btnStepDiscord.Text = "06   Discord"
        Me.btnStepDiscord.Location = New System.Drawing.Point(20, 442)
        Me.btnStepDiscord.Size = New System.Drawing.Size(210, 44)
        Me.btnStepDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepDiscord.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepDiscord.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepDiscord.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepDiscord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepDiscord.UseVisualStyleBackColor = False
        Me.btnStepDiscord.TabIndex = 11
        Me.btnStepDrive = New System.Windows.Forms.Button()
        Me.btnStepDrive.Text = "07   Drive"
        Me.btnStepDrive.Location = New System.Drawing.Point(20, 488)
        Me.btnStepDrive.Size = New System.Drawing.Size(210, 44)
        Me.btnStepDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepDrive.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepDrive.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepDrive.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepDrive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepDrive.UseVisualStyleBackColor = False
        Me.btnStepDrive.TabIndex = 12
        Me.btnStepAi = New System.Windows.Forms.Button()
        Me.btnStepAi.Text = "08   AI-hjelp"
        Me.btnStepAi.Location = New System.Drawing.Point(20, 534)
        Me.btnStepAi.Size = New System.Drawing.Size(210, 44)
        Me.btnStepAi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepAi.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepAi.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepAi.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepAi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepAi.UseVisualStyleBackColor = False
        Me.btnStepAi.TabIndex = 13
        Me.btnStepFinish = New System.Windows.Forms.Button()
        Me.btnStepFinish.Text = "09   Oppsummering"
        Me.btnStepFinish.Location = New System.Drawing.Point(20, 580)
        Me.btnStepFinish.Size = New System.Drawing.Size(210, 44)
        Me.btnStepFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStepFinish.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnStepFinish.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnStepFinish.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStepFinish.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStepFinish.UseVisualStyleBackColor = False
        Me.btnStepFinish.TabIndex = 14
        Me.pnlNavIndicator = New System.Windows.Forms.Panel()
        Me.pnlNavIndicator.Location = New System.Drawing.Point(8, 212)
        Me.pnlNavIndicator.Size = New System.Drawing.Size(3, 44)
        Me.pnlNavIndicator.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.lblSidebarTip = New System.Windows.Forms.Label()
        Me.lblSidebarTip.Text = "Jobbkontoer." & vbCrLf & "Ingen private adresser."
        Me.lblSidebarTip.Location = New System.Drawing.Point(24, 650)
        Me.lblSidebarTip.Size = New System.Drawing.Size(210, 58)
        Me.lblSidebarTip.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblSidebarTip.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblSidebarTip.BackColor = System.Drawing.Color.Transparent
        Me.pnlProgressTrack = New System.Windows.Forms.Panel()
        Me.pnlProgressTrack.Location = New System.Drawing.Point(24, 735)
        Me.pnlProgressTrack.Size = New System.Drawing.Size(202, 8)
        Me.pnlProgressTrack.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.pnlProgressFill = New System.Windows.Forms.Panel()
        Me.pnlProgressFill.Location = New System.Drawing.Point(0, 0)
        Me.pnlProgressFill.Size = New System.Drawing.Size(0, 8)
        Me.pnlProgressFill.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblProgress.Text = "0 av 7 steg bekreftet"
        Me.lblProgress.Location = New System.Drawing.Point(24, 752)
        Me.lblProgress.Size = New System.Drawing.Size(210, 30)
        Me.lblProgress.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblProgress.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.mainLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainLayout.ColumnCount = 1
        Me.mainLayout.RowCount = 3
        Me.mainLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.mainLayout.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.mainLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148.0F))
        Me.mainLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
        Me.mainLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72.0F))
        Me.header = New System.Windows.Forms.Panel()
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Size = New System.Drawing.Size(1130, 148)
        Me.header.Margin = New System.Windows.Forms.Padding(0)
        Me.header.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblKicker = New System.Windows.Forms.Label()
        Me.lblKicker.Text = "DITT NESTE STEG"
        Me.lblKicker.Location = New System.Drawing.Point(28, 17)
        Me.lblKicker.Size = New System.Drawing.Size(500, 24)
        Me.lblKicker.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblKicker.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblKicker.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblHeader.Text = "Velkommen til KI-Laben."
        Me.lblHeader.Location = New System.Drawing.Point(26, 47)
        Me.lblHeader.Size = New System.Drawing.Size(775, 48)
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 27.0F, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.lblHeaderSub.Text = "Kontoer, apper og hjelp. Samlet på ett sted."
        Me.lblHeaderSub.Location = New System.Drawing.Point(28, 105)
        Me.lblHeaderSub.Size = New System.Drawing.Size(760, 24)
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblHeaderSub.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblHeaderSub.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.pnlHeroArt = New System.Windows.Forms.Panel()
        Me.pnlHeroArt.Location = New System.Drawing.Point(940, 0)
        Me.pnlHeroArt.Size = New System.Drawing.Size(170, 144)
        Me.pnlHeroArt.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.pnlHeroArt.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabWizard = New System.Windows.Forms.TabControl()
        Me.tabWizard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabWizard.Size = New System.Drawing.Size(1130, 600)
        Me.tabWizard.Margin = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.tabWizard.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.tabProfile = New System.Windows.Forms.TabPage()
        Me.tabProfile.Text = "Din profil"
        Me.tabProfile.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabProfile.Size = New System.Drawing.Size(1090, 580)
        Me.tabProfile.AutoScroll = True
        Me.tabProfile.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabProfile.Padding = New System.Windows.Forms.Padding(0)
        Me.tabBrowser = New System.Windows.Forms.TabPage()
        Me.tabBrowser.Text = "Velg nettleser"
        Me.tabBrowser.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabBrowser.Size = New System.Drawing.Size(1090, 580)
        Me.tabBrowser.AutoScroll = True
        Me.tabBrowser.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabBrowser.Padding = New System.Windows.Forms.Padding(0)
        Me.tabEmail = New System.Windows.Forms.TabPage()
        Me.tabEmail.Text = "Arbeids-e-post"
        Me.tabEmail.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabEmail.Size = New System.Drawing.Size(1090, 580)
        Me.tabEmail.AutoScroll = True
        Me.tabEmail.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabEmail.Padding = New System.Windows.Forms.Padding(0)
        Me.tabGoogle = New System.Windows.Forms.TabPage()
        Me.tabGoogle.Text = "Google / Workspace"
        Me.tabGoogle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabGoogle.Size = New System.Drawing.Size(1090, 580)
        Me.tabGoogle.AutoScroll = True
        Me.tabGoogle.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabGoogle.Padding = New System.Windows.Forms.Padding(0)
        Me.tabChatGPT = New System.Windows.Forms.TabPage()
        Me.tabChatGPT.Text = "ChatGPT"
        Me.tabChatGPT.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabChatGPT.Size = New System.Drawing.Size(1090, 580)
        Me.tabChatGPT.AutoScroll = True
        Me.tabChatGPT.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabChatGPT.Padding = New System.Windows.Forms.Padding(0)
        Me.tabDiscord = New System.Windows.Forms.TabPage()
        Me.tabDiscord.Text = "Discord"
        Me.tabDiscord.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabDiscord.Size = New System.Drawing.Size(1090, 580)
        Me.tabDiscord.AutoScroll = True
        Me.tabDiscord.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabDiscord.Padding = New System.Windows.Forms.Padding(0)
        Me.tabDrive = New System.Windows.Forms.TabPage()
        Me.tabDrive.Text = "Drive"
        Me.tabDrive.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabDrive.Size = New System.Drawing.Size(1090, 580)
        Me.tabDrive.AutoScroll = True
        Me.tabDrive.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabDrive.Padding = New System.Windows.Forms.Padding(0)
        Me.tabAi = New System.Windows.Forms.TabPage()
        Me.tabAi.Text = "AI-hjelp"
        Me.tabAi.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabAi.Size = New System.Drawing.Size(1090, 580)
        Me.tabAi.AutoScroll = True
        Me.tabAi.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabAi.Padding = New System.Windows.Forms.Padding(0)
        Me.tabFinish = New System.Windows.Forms.TabPage()
        Me.tabFinish.Text = "Oppsummering"
        Me.tabFinish.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.tabFinish.Size = New System.Drawing.Size(1090, 580)
        Me.tabFinish.AutoScroll = True
        Me.tabFinish.AutoScrollMinSize = New System.Drawing.Size(760, 590)
        Me.tabFinish.Padding = New System.Windows.Forms.Padding(0)
        Me.footer = New System.Windows.Forms.Panel()
        Me.footer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.footer.Size = New System.Drawing.Size(1130, 72)
        Me.footer.Margin = New System.Windows.Forms.Padding(0)
        Me.footer.BackColor = System.Drawing.Color.FromArgb(13, 22, 40)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblStatus.Text = "Klar til å starte."
        Me.lblStatus.Location = New System.Drawing.Point(24, 14)
        Me.lblStatus.Size = New System.Drawing.Size(650, 49)
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnBack.Text = "Tilbake"
        Me.btnBack.Location = New System.Drawing.Point(810, 15)
        Me.btnBack.Size = New System.Drawing.Size(108, 44)
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnBack.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBack.UseVisualStyleBackColor = False
        Me.btnBack.TabIndex = 38
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnNext.Text = "Fortsett  →"
        Me.btnNext.Location = New System.Drawing.Point(932, 15)
        Me.btnNext.Size = New System.Drawing.Size(172, 44)
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnNext.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.UseVisualStyleBackColor = False
        Me.btnNext.TabIndex = 39
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCancel.Text = "Avbryt"
        Me.btnCancel.Location = New System.Drawing.Point(690, 15)
        Me.btnCancel.Size = New System.Drawing.Size(108, 44)
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.TabIndex = 40
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnCancel.Visible = False
        Me.lblProfileTitle = New System.Windows.Forms.Label()
        Me.lblProfileTitle.Text = "Mindre utfylling. Mer flyt."
        Me.lblProfileTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblProfileTitle.Size = New System.Drawing.Size(925, 38)
        Me.lblProfileTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblProfileTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblProfileTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblProfileTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblProfileHelp = New System.Windows.Forms.Label()
        Me.lblProfileHelp.Text = "Navn, rolle og erfaring. Arbeidsadressen lages fra fornavnet. Veileder sjekker at adressen finnes og ikke er opptatt."
        Me.lblProfileHelp.Location = New System.Drawing.Point(28, 75)
        Me.lblProfileHelp.Size = New System.Drawing.Size(925, 55)
        Me.lblProfileHelp.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblProfileHelp.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblProfileHelp.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblProfileHelp.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.cardProfile = New System.Windows.Forms.Panel()
        Me.cardProfile.Location = New System.Drawing.Point(26, 149)
        Me.cardProfile.Size = New System.Drawing.Size(965, 302)
        Me.cardProfile.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.cardProfile.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblFirstName.Text = "FORNAVN"
        Me.lblFirstName.Location = New System.Drawing.Point(24, 20)
        Me.lblFirstName.Size = New System.Drawing.Size(300, 25)
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblFirstName.BackColor = System.Drawing.Color.Transparent
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblLastName.Text = "ETTERNAVN"
        Me.lblLastName.Location = New System.Drawing.Point(462, 20)
        Me.lblLastName.Size = New System.Drawing.Size(330, 25)
        Me.lblLastName.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblLastName.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblLastName.BackColor = System.Drawing.Color.Transparent
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtFirstName.Location = New System.Drawing.Point(24, 49)
        Me.txtFirstName.Size = New System.Drawing.Size(390, 32)
        Me.txtFirstName.Multiline = False
        Me.txtFirstName.ReadOnly = False
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtLastName.Location = New System.Drawing.Point(462, 49)
        Me.txtLastName.Size = New System.Drawing.Size(390, 32)
        Me.txtLastName.Multiline = False
        Me.txtLastName.ReadOnly = False
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtLastName.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblAddress.Text = "DIN ARBEIDSADRESSE"
        Me.lblAddress.Location = New System.Drawing.Point(24, 111)
        Me.lblAddress.Size = New System.Drawing.Size(800, 25)
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblAddress.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtUsername.Location = New System.Drawing.Point(24, 142)
        Me.txtUsername.Size = New System.Drawing.Size(390, 38)
        Me.txtUsername.Multiline = False
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblDomain = New System.Windows.Forms.Label()
        Me.lblDomain.Text = "@ki-laben.no"
        Me.lblDomain.Location = New System.Drawing.Point(429, 143)
        Me.lblDomain.Size = New System.Drawing.Size(370, 38)
        Me.lblDomain.Font = New System.Drawing.Font("Segoe UI", 19.0F, System.Drawing.FontStyle.Bold)
        Me.lblDomain.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblDomain.BackColor = System.Drawing.Color.Transparent
        Me.lblRole = New System.Windows.Forms.Label()
        Me.lblRole.Text = "ROLLE"
        Me.lblRole.Location = New System.Drawing.Point(24, 207)
        Me.lblRole.Size = New System.Drawing.Size(300, 25)
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblRole.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblRole.BackColor = System.Drawing.Color.Transparent
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        Me.cmbRole.Location = New System.Drawing.Point(24, 239)
        Me.cmbRole.Size = New System.Drawing.Size(390, 32)
        Me.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRole.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.cmbRole.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.cmbRole.Items.AddRange(New Object() {"Deltaker", "Veileder", "Admin", "Gjest"})
        Me.chkRemember = New System.Windows.Forms.CheckBox()
        Me.chkRemember.Text = "Husk fremdriften lokalt for denne Windows-brukeren"
        Me.chkRemember.Location = New System.Drawing.Point(28, 467)
        Me.chkRemember.Size = New System.Drawing.Size(900, 48)
        Me.chkRemember.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkRemember.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkRemember.AutoCheck = True
        Me.chkRemember.UseVisualStyleBackColor = False
        Me.chkRemember.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.chkMotion = New System.Windows.Forms.CheckBox()
        Me.chkMotion.Text = "Animasjoner"
        Me.chkMotion.Location = New System.Drawing.Point(28, 520)
        Me.chkMotion.Size = New System.Drawing.Size(300, 48)
        Me.chkMotion.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkMotion.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkMotion.AutoCheck = True
        Me.chkMotion.UseVisualStyleBackColor = False
        Me.chkMotion.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnReset.Text = "Nytt medlem"
        Me.btnReset.Location = New System.Drawing.Point(698, 519)
        Me.btnReset.Size = New System.Drawing.Size(250, 44)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.UseVisualStyleBackColor = False
        Me.btnReset.TabIndex = 55
        Me.lblBrowserTitle = New System.Windows.Forms.Label()
        Me.lblBrowserTitle.Text = "Din nettleser. Ditt valg."
        Me.lblBrowserTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblBrowserTitle.Size = New System.Drawing.Size(925, 38)
        Me.lblBrowserTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblBrowserTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblBrowserTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblBrowserTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblBrowserHelp = New System.Windows.Forms.Label()
        Me.lblBrowserHelp.Text = "Programmet finner installerte nettlesere og laster ned den du velger. Ingen endringer gjøres i Windows-standardvalg uten ditt klikk."
        Me.lblBrowserHelp.Location = New System.Drawing.Point(28, 76)
        Me.lblBrowserHelp.Size = New System.Drawing.Size(925, 57)
        Me.lblBrowserHelp.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblBrowserHelp.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblBrowserHelp.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblBrowserHelp.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.rbChrome = New System.Windows.Forms.RadioButton()
        Me.rbChrome.Text = "Google Chrome" & vbCrLf & "GOOGLE"
        Me.rbChrome.Location = New System.Drawing.Point(28, 154)
        Me.rbChrome.Size = New System.Drawing.Size(268, 80)
        Me.rbChrome.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbChrome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbChrome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbChrome.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.rbChrome.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.rbChrome.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        Me.rbChrome.UseVisualStyleBackColor = False
        Me.rbFirefox = New System.Windows.Forms.RadioButton()
        Me.rbFirefox.Text = "Mozilla Firefox" & vbCrLf & "MOZILLA"
        Me.rbFirefox.Location = New System.Drawing.Point(316, 154)
        Me.rbFirefox.Size = New System.Drawing.Size(268, 80)
        Me.rbFirefox.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbFirefox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbFirefox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbFirefox.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.rbFirefox.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.rbFirefox.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        Me.rbFirefox.UseVisualStyleBackColor = False
        Me.rbEdge = New System.Windows.Forms.RadioButton()
        Me.rbEdge.Text = "Microsoft Edge" & vbCrLf & "MICROSOFT"
        Me.rbEdge.Location = New System.Drawing.Point(604, 154)
        Me.rbEdge.Size = New System.Drawing.Size(268, 80)
        Me.rbEdge.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbEdge.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.rbEdge.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.rbEdge.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        Me.rbEdge.UseVisualStyleBackColor = False
        Me.lblBrowserDetected = New System.Windows.Forms.Label()
        Me.lblBrowserDetected.Text = "Velg nettleser for å sjekke lokal installasjon."
        Me.lblBrowserDetected.Location = New System.Drawing.Point(28, 251)
        Me.lblBrowserDetected.Size = New System.Drawing.Size(925, 45)
        Me.lblBrowserDetected.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblBrowserDetected.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblBrowserDetected.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblBrowserDetected.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnBrowserDownload = New System.Windows.Forms.Button()
        Me.btnBrowserDownload.Text = "Last ned valgt nettleser"
        Me.btnBrowserDownload.Location = New System.Drawing.Point(28, 310)
        Me.btnBrowserDownload.Size = New System.Drawing.Size(238, 44)
        Me.btnBrowserDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowserDownload.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnBrowserDownload.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnBrowserDownload.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnBrowserDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowserDownload.UseVisualStyleBackColor = False
        Me.btnBrowserDownload.TabIndex = 62
        Me.btnBrowserInstall = New System.Windows.Forms.Button()
        Me.btnBrowserInstall.Text = "Start installasjon"
        Me.btnBrowserInstall.Location = New System.Drawing.Point(280, 310)
        Me.btnBrowserInstall.Size = New System.Drawing.Size(205, 44)
        Me.btnBrowserInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowserInstall.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnBrowserInstall.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnBrowserInstall.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnBrowserInstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowserInstall.UseVisualStyleBackColor = False
        Me.btnBrowserInstall.TabIndex = 63
        Me.btnBrowserPage = New System.Windows.Forms.Button()
        Me.btnBrowserPage.Text = "Leverandørens nettside"
        Me.btnBrowserPage.Location = New System.Drawing.Point(499, 310)
        Me.btnBrowserPage.Size = New System.Drawing.Size(242, 44)
        Me.btnBrowserPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowserPage.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnBrowserPage.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnBrowserPage.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnBrowserPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowserPage.UseVisualStyleBackColor = False
        Me.btnBrowserPage.TabIndex = 64
        Me.lblBrowserTransfer = New System.Windows.Forms.Label()
        Me.lblBrowserTransfer.Text = "Nedlastingen vises her."
        Me.lblBrowserTransfer.Location = New System.Drawing.Point(28, 368)
        Me.lblBrowserTransfer.Size = New System.Drawing.Size(925, 40)
        Me.lblBrowserTransfer.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblBrowserTransfer.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblBrowserTransfer.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblBrowserTransfer.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.barBrowser = New System.Windows.Forms.ProgressBar()
        Me.barBrowser.Location = New System.Drawing.Point(28, 414)
        Me.barBrowser.Size = New System.Drawing.Size(911, 10)
        Me.barBrowser.Minimum = 0
        Me.barBrowser.Maximum = 100
        Me.barBrowser.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Top
        Me.btnStarterPack = New System.Windows.Forms.Button()
        Me.btnStarterPack.Text = "Hent nettleser + Discord"
        Me.btnStarterPack.Location = New System.Drawing.Point(28, 451)
        Me.btnStarterPack.Size = New System.Drawing.Size(264, 44)
        Me.btnStarterPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStarterPack.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnStarterPack.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnStarterPack.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnStarterPack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStarterPack.UseVisualStyleBackColor = False
        Me.btnStarterPack.TabIndex = 67
        Me.btnDefaultBrowser = New System.Windows.Forms.Button()
        Me.btnDefaultBrowser.Text = "Standardnettleser i Windows"
        Me.btnDefaultBrowser.Location = New System.Drawing.Point(309, 451)
        Me.btnDefaultBrowser.Size = New System.Drawing.Size(275, 44)
        Me.btnDefaultBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefaultBrowser.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnDefaultBrowser.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnDefaultBrowser.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDefaultBrowser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDefaultBrowser.UseVisualStyleBackColor = False
        Me.btnDefaultBrowser.TabIndex = 68
        Me.btnRefreshApps = New System.Windows.Forms.Button()
        Me.btnRefreshApps.Text = "Sjekk på nytt"
        Me.btnRefreshApps.Location = New System.Drawing.Point(600, 451)
        Me.btnRefreshApps.Size = New System.Drawing.Size(178, 44)
        Me.btnRefreshApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshApps.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnRefreshApps.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnRefreshApps.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnRefreshApps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefreshApps.UseVisualStyleBackColor = False
        Me.btnRefreshApps.TabIndex = 69
        Me.chkBrowser = New System.Windows.Forms.CheckBox()
        Me.chkBrowser.Text = "Jeg har valgt og testet nettleseren min"
        Me.chkBrowser.Location = New System.Drawing.Point(28, 514)
        Me.chkBrowser.Size = New System.Drawing.Size(920, 48)
        Me.chkBrowser.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkBrowser.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkBrowser.AutoCheck = True
        Me.chkBrowser.UseVisualStyleBackColor = False
        Me.chkBrowser.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.lblEmailTitle = New System.Windows.Forms.Label()
        Me.lblEmailTitle.Text = "Arbeidskontoen først."
        Me.lblEmailTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblEmailTitle.Size = New System.Drawing.Size(925, 44)
        Me.lblEmailTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblEmailTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblEmailTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblEmailTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblEmailAccount = New System.Windows.Forms.Label()
        Me.lblEmailAccount.Text = ""
        Me.lblEmailAccount.Location = New System.Drawing.Point(28, 91)
        Me.lblEmailAccount.Size = New System.Drawing.Size(925, 40)
        Me.lblEmailAccount.Font = New System.Drawing.Font("Segoe UI", 16.0F, System.Drawing.FontStyle.Bold)
        Me.lblEmailAccount.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblEmailAccount.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblEmailAccount.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblEmailGuide = New System.Windows.Forms.Label()
        Me.lblEmailGuide.Text = ""
        Me.lblEmailGuide.Location = New System.Drawing.Point(28, 164)
        Me.lblEmailGuide.Size = New System.Drawing.Size(925, 223)
        Me.lblEmailGuide.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Regular)
        Me.lblEmailGuide.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblEmailGuide.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblEmailGuide.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnCopyEmail = New System.Windows.Forms.Button()
        Me.btnCopyEmail.Text = "Kopier arbeidsadresse"
        Me.btnCopyEmail.Location = New System.Drawing.Point(28, 410)
        Me.btnCopyEmail.Size = New System.Drawing.Size(265, 44)
        Me.btnCopyEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyEmail.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnCopyEmail.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnCopyEmail.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnCopyEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyEmail.UseVisualStyleBackColor = False
        Me.btnCopyEmail.TabIndex = 74
        Me.btnOpenWebmail = New System.Windows.Forms.Button()
        Me.btnOpenWebmail.Text = "Åpne webmail"
        Me.btnOpenWebmail.Location = New System.Drawing.Point(308, 410)
        Me.btnOpenWebmail.Size = New System.Drawing.Size(265, 44)
        Me.btnOpenWebmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenWebmail.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnOpenWebmail.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnOpenWebmail.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnOpenWebmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenWebmail.UseVisualStyleBackColor = False
        Me.btnOpenWebmail.TabIndex = 75
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.chkEmail.Text = "Jeg mottar e-post på KI-Laben-adressen"
        Me.chkEmail.Location = New System.Drawing.Point(28, 492)
        Me.chkEmail.Size = New System.Drawing.Size(925, 48)
        Me.chkEmail.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkEmail.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkEmail.AutoCheck = True
        Me.chkEmail.UseVisualStyleBackColor = False
        Me.chkEmail.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnHelpEmail = New System.Windows.Forms.Button()
        Me.btnHelpEmail.Text = "Få hjelp med dette steget"
        Me.btnHelpEmail.Location = New System.Drawing.Point(28, 552)
        Me.btnHelpEmail.Size = New System.Drawing.Size(265, 44)
        Me.btnHelpEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelpEmail.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnHelpEmail.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnHelpEmail.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnHelpEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelpEmail.UseVisualStyleBackColor = False
        Me.btnHelpEmail.TabIndex = 77
        Me.lblGoogleTitle = New System.Windows.Forms.Label()
        Me.lblGoogleTitle.Text = "Google uten privat e-post."
        Me.lblGoogleTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblGoogleTitle.Size = New System.Drawing.Size(925, 44)
        Me.lblGoogleTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblGoogleTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblGoogleTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblGoogleTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblGoogleAccount = New System.Windows.Forms.Label()
        Me.lblGoogleAccount.Text = ""
        Me.lblGoogleAccount.Location = New System.Drawing.Point(28, 91)
        Me.lblGoogleAccount.Size = New System.Drawing.Size(925, 40)
        Me.lblGoogleAccount.Font = New System.Drawing.Font("Segoe UI", 16.0F, System.Drawing.FontStyle.Bold)
        Me.lblGoogleAccount.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblGoogleAccount.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblGoogleAccount.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblGoogleGuide = New System.Windows.Forms.Label()
        Me.lblGoogleGuide.Text = ""
        Me.lblGoogleGuide.Location = New System.Drawing.Point(28, 164)
        Me.lblGoogleGuide.Size = New System.Drawing.Size(925, 223)
        Me.lblGoogleGuide.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Regular)
        Me.lblGoogleGuide.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblGoogleGuide.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblGoogleGuide.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnOpenGoogle = New System.Windows.Forms.Button()
        Me.btnOpenGoogle.Text = "Kopier + åpne Google"
        Me.btnOpenGoogle.Location = New System.Drawing.Point(28, 410)
        Me.btnOpenGoogle.Size = New System.Drawing.Size(265, 44)
        Me.btnOpenGoogle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenGoogle.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnOpenGoogle.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnOpenGoogle.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnOpenGoogle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenGoogle.UseVisualStyleBackColor = False
        Me.btnOpenGoogle.TabIndex = 81
        Me.btnWorkspace = New System.Windows.Forms.Button()
        Me.btnWorkspace.Text = "Workspace Essentials"
        Me.btnWorkspace.Location = New System.Drawing.Point(308, 410)
        Me.btnWorkspace.Size = New System.Drawing.Size(265, 44)
        Me.btnWorkspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkspace.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnWorkspace.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnWorkspace.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnWorkspace.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWorkspace.UseVisualStyleBackColor = False
        Me.btnWorkspace.TabIndex = 82
        Me.chkGoogle = New System.Windows.Forms.CheckBox()
        Me.chkGoogle.Text = "Jeg er logget inn og har riktig Google / Workspace-tilgang"
        Me.chkGoogle.Location = New System.Drawing.Point(28, 492)
        Me.chkGoogle.Size = New System.Drawing.Size(925, 48)
        Me.chkGoogle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkGoogle.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkGoogle.AutoCheck = True
        Me.chkGoogle.UseVisualStyleBackColor = False
        Me.chkGoogle.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnHelpGoogle = New System.Windows.Forms.Button()
        Me.btnHelpGoogle.Text = "Få hjelp med dette steget"
        Me.btnHelpGoogle.Location = New System.Drawing.Point(28, 552)
        Me.btnHelpGoogle.Size = New System.Drawing.Size(265, 44)
        Me.btnHelpGoogle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelpGoogle.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnHelpGoogle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnHelpGoogle.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnHelpGoogle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelpGoogle.UseVisualStyleBackColor = False
        Me.btnHelpGoogle.TabIndex = 84
        Me.lblChatGPTTitle = New System.Windows.Forms.Label()
        Me.lblChatGPTTitle.Text = "Invitasjonen gir deg tilgang."
        Me.lblChatGPTTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblChatGPTTitle.Size = New System.Drawing.Size(925, 44)
        Me.lblChatGPTTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblChatGPTTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblChatGPTTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblChatGPTTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblChatGPTAccount = New System.Windows.Forms.Label()
        Me.lblChatGPTAccount.Text = ""
        Me.lblChatGPTAccount.Location = New System.Drawing.Point(28, 91)
        Me.lblChatGPTAccount.Size = New System.Drawing.Size(925, 40)
        Me.lblChatGPTAccount.Font = New System.Drawing.Font("Segoe UI", 16.0F, System.Drawing.FontStyle.Bold)
        Me.lblChatGPTAccount.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblChatGPTAccount.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblChatGPTAccount.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblChatGPTGuide = New System.Windows.Forms.Label()
        Me.lblChatGPTGuide.Text = ""
        Me.lblChatGPTGuide.Location = New System.Drawing.Point(28, 164)
        Me.lblChatGPTGuide.Size = New System.Drawing.Size(925, 223)
        Me.lblChatGPTGuide.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Regular)
        Me.lblChatGPTGuide.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblChatGPTGuide.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblChatGPTGuide.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnChatWebmail = New System.Windows.Forms.Button()
        Me.btnChatWebmail.Text = "1. Åpne invitasjonen"
        Me.btnChatWebmail.Location = New System.Drawing.Point(28, 410)
        Me.btnChatWebmail.Size = New System.Drawing.Size(265, 44)
        Me.btnChatWebmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChatWebmail.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnChatWebmail.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnChatWebmail.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnChatWebmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChatWebmail.UseVisualStyleBackColor = False
        Me.btnChatWebmail.TabIndex = 88
        Me.btnOpenChatGPT = New System.Windows.Forms.Button()
        Me.btnOpenChatGPT.Text = "2. Åpne ChatGPT"
        Me.btnOpenChatGPT.Location = New System.Drawing.Point(308, 410)
        Me.btnOpenChatGPT.Size = New System.Drawing.Size(265, 44)
        Me.btnOpenChatGPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenChatGPT.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnOpenChatGPT.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnOpenChatGPT.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnOpenChatGPT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenChatGPT.UseVisualStyleBackColor = False
        Me.btnOpenChatGPT.TabIndex = 89
        Me.chkChatGPT = New System.Windows.Forms.CheckBox()
        Me.chkChatGPT.Text = "Jeg har godtatt invitasjonen og testet KI-Laben-arbeidsområdet"
        Me.chkChatGPT.Location = New System.Drawing.Point(28, 492)
        Me.chkChatGPT.Size = New System.Drawing.Size(925, 48)
        Me.chkChatGPT.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkChatGPT.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkChatGPT.AutoCheck = True
        Me.chkChatGPT.UseVisualStyleBackColor = False
        Me.chkChatGPT.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnHelpChatGPT = New System.Windows.Forms.Button()
        Me.btnHelpChatGPT.Text = "Få hjelp med dette steget"
        Me.btnHelpChatGPT.Location = New System.Drawing.Point(28, 552)
        Me.btnHelpChatGPT.Size = New System.Drawing.Size(265, 44)
        Me.btnHelpChatGPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelpChatGPT.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnHelpChatGPT.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnHelpChatGPT.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnHelpChatGPT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelpChatGPT.UseVisualStyleBackColor = False
        Me.btnHelpChatGPT.TabIndex = 91
        Me.lblDriveTitle = New System.Windows.Forms.Label()
        Me.lblDriveTitle.Text = "Alt arbeidet på rett sted."
        Me.lblDriveTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblDriveTitle.Size = New System.Drawing.Size(925, 44)
        Me.lblDriveTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblDriveTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblDriveTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDriveTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblDriveAccount = New System.Windows.Forms.Label()
        Me.lblDriveAccount.Text = ""
        Me.lblDriveAccount.Location = New System.Drawing.Point(28, 91)
        Me.lblDriveAccount.Size = New System.Drawing.Size(925, 40)
        Me.lblDriveAccount.Font = New System.Drawing.Font("Segoe UI", 16.0F, System.Drawing.FontStyle.Bold)
        Me.lblDriveAccount.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblDriveAccount.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDriveAccount.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblDriveGuide = New System.Windows.Forms.Label()
        Me.lblDriveGuide.Text = ""
        Me.lblDriveGuide.Location = New System.Drawing.Point(28, 164)
        Me.lblDriveGuide.Size = New System.Drawing.Size(925, 223)
        Me.lblDriveGuide.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Regular)
        Me.lblDriveGuide.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblDriveGuide.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDriveGuide.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnDrive = New System.Windows.Forms.Button()
        Me.btnDrive.Text = "Åpne Google Drive"
        Me.btnDrive.Location = New System.Drawing.Point(28, 410)
        Me.btnDrive.Size = New System.Drawing.Size(265, 44)
        Me.btnDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDrive.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnDrive.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnDrive.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDrive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDrive.UseVisualStyleBackColor = False
        Me.btnDrive.TabIndex = 95
        Me.btnDocs = New System.Windows.Forms.Button()
        Me.btnDocs.Text = "Åpne Google Docs"
        Me.btnDocs.Location = New System.Drawing.Point(308, 410)
        Me.btnDocs.Size = New System.Drawing.Size(265, 44)
        Me.btnDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDocs.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnDocs.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnDocs.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDocs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDocs.UseVisualStyleBackColor = False
        Me.btnDocs.TabIndex = 96
        Me.chkDrive = New System.Windows.Forms.CheckBox()
        Me.chkDrive.Text = "Jeg ser riktige mapper og kan lagre dokumenter"
        Me.chkDrive.Location = New System.Drawing.Point(28, 492)
        Me.chkDrive.Size = New System.Drawing.Size(925, 48)
        Me.chkDrive.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkDrive.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkDrive.AutoCheck = True
        Me.chkDrive.UseVisualStyleBackColor = False
        Me.chkDrive.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnHelpDrive = New System.Windows.Forms.Button()
        Me.btnHelpDrive.Text = "Få hjelp med dette steget"
        Me.btnHelpDrive.Location = New System.Drawing.Point(28, 552)
        Me.btnHelpDrive.Size = New System.Drawing.Size(265, 44)
        Me.btnHelpDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelpDrive.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnHelpDrive.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnHelpDrive.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnHelpDrive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelpDrive.UseVisualStyleBackColor = False
        Me.btnHelpDrive.TabIndex = 98
        Me.lblDiscordTitle = New System.Windows.Forms.Label()
        Me.lblDiscordTitle.Text = "Bli en del av samtalen."
        Me.lblDiscordTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblDiscordTitle.Size = New System.Drawing.Size(925, 44)
        Me.lblDiscordTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblDiscordTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblDiscordTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDiscordTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblDiscordGuide = New System.Windows.Forms.Label()
        Me.lblDiscordGuide.Text = "Last ned Discord direkte fra leverandøren. Filen kontrolleres før du kan starte den. En installasjon er ikke det samme som medlemskap på serveren."
        Me.lblDiscordGuide.Location = New System.Drawing.Point(28, 85)
        Me.lblDiscordGuide.Size = New System.Drawing.Size(925, 66)
        Me.lblDiscordGuide.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblDiscordGuide.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblDiscordGuide.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDiscordGuide.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnDiscordDownload = New System.Windows.Forms.Button()
        Me.btnDiscordDownload.Text = "Last ned Discord.exe"
        Me.btnDiscordDownload.Location = New System.Drawing.Point(28, 182)
        Me.btnDiscordDownload.Size = New System.Drawing.Size(240, 44)
        Me.btnDiscordDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscordDownload.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnDiscordDownload.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnDiscordDownload.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDiscordDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscordDownload.UseVisualStyleBackColor = False
        Me.btnDiscordDownload.TabIndex = 101
        Me.btnDiscordInstall = New System.Windows.Forms.Button()
        Me.btnDiscordInstall.Text = "Start installasjon"
        Me.btnDiscordInstall.Location = New System.Drawing.Point(284, 182)
        Me.btnDiscordInstall.Size = New System.Drawing.Size(222, 44)
        Me.btnDiscordInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscordInstall.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnDiscordInstall.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnDiscordInstall.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDiscordInstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscordInstall.UseVisualStyleBackColor = False
        Me.btnDiscordInstall.TabIndex = 102
        Me.btnDiscordPage = New System.Windows.Forms.Button()
        Me.btnDiscordPage.Text = "Offisiell nedlastingsside"
        Me.btnDiscordPage.Location = New System.Drawing.Point(522, 182)
        Me.btnDiscordPage.Size = New System.Drawing.Size(267, 44)
        Me.btnDiscordPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscordPage.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnDiscordPage.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnDiscordPage.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDiscordPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscordPage.UseVisualStyleBackColor = False
        Me.btnDiscordPage.TabIndex = 103
        Me.lblDiscordTransfer = New System.Windows.Forms.Label()
        Me.lblDiscordTransfer.Text = "Ingen nedlasting startet."
        Me.lblDiscordTransfer.Location = New System.Drawing.Point(28, 247)
        Me.lblDiscordTransfer.Size = New System.Drawing.Size(925, 40)
        Me.lblDiscordTransfer.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblDiscordTransfer.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblDiscordTransfer.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDiscordTransfer.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.barDiscord = New System.Windows.Forms.ProgressBar()
        Me.barDiscord.Location = New System.Drawing.Point(28, 297)
        Me.barDiscord.Size = New System.Drawing.Size(911, 10)
        Me.barDiscord.Minimum = 0
        Me.barDiscord.Maximum = 100
        Me.barDiscord.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Top
        Me.lblDiscordInvite = New System.Windows.Forms.Label()
        Me.lblDiscordInvite.Text = "Serverinvitasjon: må settes av veileder."
        Me.lblDiscordInvite.Location = New System.Drawing.Point(28, 341)
        Me.lblDiscordInvite.Size = New System.Drawing.Size(925, 54)
        Me.lblDiscordInvite.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblDiscordInvite.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblDiscordInvite.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblDiscordInvite.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnDiscordInvite = New System.Windows.Forms.Button()
        Me.btnDiscordInvite.Text = "Bli med på KI-Laben"
        Me.btnDiscordInvite.Location = New System.Drawing.Point(28, 415)
        Me.btnDiscordInvite.Size = New System.Drawing.Size(253, 44)
        Me.btnDiscordInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscordInvite.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnDiscordInvite.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnDiscordInvite.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDiscordInvite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscordInvite.UseVisualStyleBackColor = False
        Me.btnDiscordInvite.TabIndex = 107
        Me.btnDiscordApp = New System.Windows.Forms.Button()
        Me.btnDiscordApp.Text = "Åpne Discord i nettleser"
        Me.btnDiscordApp.Location = New System.Drawing.Point(297, 415)
        Me.btnDiscordApp.Size = New System.Drawing.Size(276, 44)
        Me.btnDiscordApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscordApp.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnDiscordApp.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnDiscordApp.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDiscordApp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscordApp.UseVisualStyleBackColor = False
        Me.btnDiscordApp.TabIndex = 108
        Me.btnDownloadsFolder = New System.Windows.Forms.Button()
        Me.btnDownloadsFolder.Text = "Se nedlastede filer"
        Me.btnDownloadsFolder.Location = New System.Drawing.Point(589, 415)
        Me.btnDownloadsFolder.Size = New System.Drawing.Size(205, 44)
        Me.btnDownloadsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownloadsFolder.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnDownloadsFolder.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnDownloadsFolder.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnDownloadsFolder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDownloadsFolder.UseVisualStyleBackColor = False
        Me.btnDownloadsFolder.TabIndex = 109
        Me.chkDiscord = New System.Windows.Forms.CheckBox()
        Me.chkDiscord.Text = "Jeg er inne på riktig server og kan sende en testmelding"
        Me.chkDiscord.Location = New System.Drawing.Point(28, 490)
        Me.chkDiscord.Size = New System.Drawing.Size(925, 48)
        Me.chkDiscord.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkDiscord.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkDiscord.AutoCheck = True
        Me.chkDiscord.UseVisualStyleBackColor = False
        Me.chkDiscord.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.lblAiTitle = New System.Windows.Forms.Label()
        Me.lblAiTitle.Text = "Står du fast? Spør."
        Me.lblAiTitle.Location = New System.Drawing.Point(28, 20)
        Me.lblAiTitle.Size = New System.Drawing.Size(925, 40)
        Me.lblAiTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblAiTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblAiTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblAiTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblAiConnection = New System.Windows.Forms.Label()
        Me.lblAiConnection.Text = "AI er ikke koblet til."
        Me.lblAiConnection.Location = New System.Drawing.Point(28, 69)
        Me.lblAiConnection.Size = New System.Drawing.Size(925, 32)
        Me.lblAiConnection.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.lblAiConnection.ForeColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.lblAiConnection.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblAiConnection.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblAiToken = New System.Windows.Forms.Label()
        Me.lblAiToken.Text = "MIDLERTIDIG TILGANGSKODE FRA VEILEDER"
        Me.lblAiToken.Location = New System.Drawing.Point(28, 111)
        Me.lblAiToken.Size = New System.Drawing.Size(445, 24)
        Me.lblAiToken.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblAiToken.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblAiToken.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.txtAiCode = New System.Windows.Forms.TextBox()
        Me.txtAiCode.Location = New System.Drawing.Point(28, 140)
        Me.txtAiCode.Size = New System.Drawing.Size(420, 32)
        Me.txtAiCode.Multiline = False
        Me.txtAiCode.ReadOnly = False
        Me.txtAiCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAiCode.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtAiCode.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtAiCode.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.txtAiCode.UseSystemPasswordChar = True
        Me.txtAiCode.MaxLength = 240
        Me.lblAiStep = New System.Windows.Forms.Label()
        Me.lblAiStep.Text = "HVILKET STEG?"
        Me.lblAiStep.Location = New System.Drawing.Point(477, 111)
        Me.lblAiStep.Size = New System.Drawing.Size(430, 24)
        Me.lblAiStep.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblAiStep.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblAiStep.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.cmbAiStep = New System.Windows.Forms.ComboBox()
        Me.cmbAiStep.Location = New System.Drawing.Point(477, 140)
        Me.cmbAiStep.Size = New System.Drawing.Size(427, 32)
        Me.cmbAiStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAiStep.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.cmbAiStep.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.cmbAiStep.Items.AddRange(New Object() {"Profil", "Nettleser", "E-post", "Google", "ChatGPT", "Discord", "Drive"})
        Me.txtAiAnswer = New System.Windows.Forms.TextBox()
        Me.txtAiAnswer.Location = New System.Drawing.Point(28, 193)
        Me.txtAiAnswer.Size = New System.Drawing.Size(910, 205)
        Me.txtAiAnswer.Multiline = True
        Me.txtAiAnswer.ReadOnly = True
        Me.txtAiAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAiAnswer.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtAiAnswer.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtAiAnswer.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.txtAiAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAiAnswer.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.txtQuestion.Location = New System.Drawing.Point(28, 415)
        Me.txtQuestion.Size = New System.Drawing.Size(910, 74)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.ReadOnly = False
        Me.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuestion.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtQuestion.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtQuestion.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuestion.PlaceholderText = "Skriv spørsmålet ditt. Ikke del passord, koder eller personopplysninger."
        Me.txtQuestion.MaxLength = 1600
        Me.txtQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.chkAiConsent = New System.Windows.Forms.CheckBox()
        Me.chkAiConsent.Text = "Send spørsmålet og valgt steg til KI-Labens AI-server og OpenAI"
        Me.chkAiConsent.Location = New System.Drawing.Point(28, 492)
        Me.chkAiConsent.Size = New System.Drawing.Size(915, 48)
        Me.chkAiConsent.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.chkAiConsent.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular)
        Me.chkAiConsent.AutoCheck = True
        Me.chkAiConsent.UseVisualStyleBackColor = False
        Me.chkAiConsent.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        Me.btnAsk = New System.Windows.Forms.Button()
        Me.btnAsk.Text = "Spør AI"
        Me.btnAsk.Location = New System.Drawing.Point(28, 550)
        Me.btnAsk.Size = New System.Drawing.Size(180, 44)
        Me.btnAsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsk.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnAsk.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnAsk.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnAsk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAsk.UseVisualStyleBackColor = False
        Me.btnAsk.TabIndex = 120
        Me.btnLocalHelp = New System.Windows.Forms.Button()
        Me.btnLocalHelp.Text = "Vis lokal stegveiledning"
        Me.btnLocalHelp.Location = New System.Drawing.Point(222, 550)
        Me.btnLocalHelp.Size = New System.Drawing.Size(256, 44)
        Me.btnLocalHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLocalHelp.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnLocalHelp.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnLocalHelp.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnLocalHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLocalHelp.UseVisualStyleBackColor = False
        Me.btnLocalHelp.TabIndex = 121
        Me.btnAiClear = New System.Windows.Forms.Button()
        Me.btnAiClear.Text = "Tøm samtalen"
        Me.btnAiClear.Location = New System.Drawing.Point(492, 550)
        Me.btnAiClear.Size = New System.Drawing.Size(197, 44)
        Me.btnAiClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAiClear.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnAiClear.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnAiClear.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnAiClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAiClear.UseVisualStyleBackColor = False
        Me.btnAiClear.TabIndex = 122
        Me.lblFinishTitle = New System.Windows.Forms.Label()
        Me.lblFinishTitle.Text = "Klar for din første dag."
        Me.lblFinishTitle.Location = New System.Drawing.Point(28, 26)
        Me.lblFinishTitle.Size = New System.Drawing.Size(925, 44)
        Me.lblFinishTitle.Font = New System.Drawing.Font("Segoe UI", 21.0F, System.Drawing.FontStyle.Bold)
        Me.lblFinishTitle.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.lblFinishTitle.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblFinishTitle.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.lblFinishHelp = New System.Windows.Forms.Label()
        Me.lblFinishHelp.Text = "Rapporten skiller bekreftede kontoer fra nedlastede programmer. Ingen passord eller AI-samtaler tas med."
        Me.lblFinishHelp.Location = New System.Drawing.Point(28, 82)
        Me.lblFinishHelp.Size = New System.Drawing.Size(925, 55)
        Me.lblFinishHelp.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.lblFinishHelp.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.lblFinishHelp.BackColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.lblFinishHelp.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.txtReport = New System.Windows.Forms.TextBox()
        Me.txtReport.Location = New System.Drawing.Point(28, 157)
        Me.txtReport.Size = New System.Drawing.Size(910, 325)
        Me.txtReport.Multiline = True
        Me.txtReport.ReadOnly = True
        Me.txtReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReport.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.txtReport.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.txtReport.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Regular)
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReport.Font = New System.Drawing.Font("Consolas", 10.0F)
        Me.txtReport.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.btnCopyReport = New System.Windows.Forms.Button()
        Me.btnCopyReport.Text = "Kopier rapport"
        Me.btnCopyReport.Location = New System.Drawing.Point(28, 514)
        Me.btnCopyReport.Size = New System.Drawing.Size(212, 44)
        Me.btnCopyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyReport.BackColor = System.Drawing.Color.FromArgb(98, 229, 214)
        Me.btnCopyReport.ForeColor = System.Drawing.Color.FromArgb(9, 15, 30)
        Me.btnCopyReport.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnCopyReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyReport.UseVisualStyleBackColor = False
        Me.btnCopyReport.TabIndex = 126
        Me.btnSaveReport = New System.Windows.Forms.Button()
        Me.btnSaveReport.Text = "Lagre som tekstfil"
        Me.btnSaveReport.Location = New System.Drawing.Point(256, 514)
        Me.btnSaveReport.Size = New System.Drawing.Size(231, 44)
        Me.btnSaveReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveReport.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnSaveReport.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnSaveReport.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnSaveReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveReport.UseVisualStyleBackColor = False
        Me.btnSaveReport.TabIndex = 127
        Me.btnNewMember = New System.Windows.Forms.Button()
        Me.btnNewMember.Text = "Start nytt medlem"
        Me.btnNewMember.Location = New System.Drawing.Point(503, 514)
        Me.btnNewMember.Size = New System.Drawing.Size(247, 44)
        Me.btnNewMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewMember.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.btnNewMember.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.btnNewMember.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
        Me.btnNewMember.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNewMember.UseVisualStyleBackColor = False
        Me.btnNewMember.TabIndex = 128
        Me.tabFinish.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFinishTitle, Me.lblFinishHelp, Me.txtReport, Me.btnCopyReport, Me.btnSaveReport, Me.btnNewMember})
        Me.tabAi.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAiTitle, Me.lblAiConnection, Me.lblAiToken, Me.txtAiCode, Me.lblAiStep, Me.cmbAiStep, Me.txtAiAnswer, Me.txtQuestion, Me.chkAiConsent, Me.btnAsk, Me.btnLocalHelp, Me.btnAiClear})
        Me.tabDiscord.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDiscordTitle, Me.lblDiscordGuide, Me.btnDiscordDownload, Me.btnDiscordInstall, Me.btnDiscordPage, Me.lblDiscordTransfer, Me.barDiscord, Me.lblDiscordInvite, Me.btnDiscordInvite, Me.btnDiscordApp, Me.btnDownloadsFolder, Me.chkDiscord})
        Me.tabDrive.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDriveTitle, Me.lblDriveAccount, Me.lblDriveGuide, Me.btnDrive, Me.btnDocs, Me.chkDrive, Me.btnHelpDrive})
        Me.tabChatGPT.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblChatGPTTitle, Me.lblChatGPTAccount, Me.lblChatGPTGuide, Me.btnChatWebmail, Me.btnOpenChatGPT, Me.chkChatGPT, Me.btnHelpChatGPT})
        Me.tabGoogle.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGoogleTitle, Me.lblGoogleAccount, Me.lblGoogleGuide, Me.btnOpenGoogle, Me.btnWorkspace, Me.chkGoogle, Me.btnHelpGoogle})
        Me.tabEmail.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEmailTitle, Me.lblEmailAccount, Me.lblEmailGuide, Me.btnCopyEmail, Me.btnOpenWebmail, Me.chkEmail, Me.btnHelpEmail})
        Me.tabBrowser.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBrowserTitle, Me.lblBrowserHelp, Me.rbChrome, Me.rbFirefox, Me.rbEdge, Me.lblBrowserDetected, Me.btnBrowserDownload, Me.btnBrowserInstall, Me.btnBrowserPage, Me.lblBrowserTransfer, Me.barBrowser, Me.btnStarterPack, Me.btnDefaultBrowser, Me.btnRefreshApps, Me.chkBrowser})
        Me.lblExperience = New System.Windows.Forms.Label()
        Me.lblExperience.Text = "ERFARING"
        Me.lblExperience.Location = New System.Drawing.Point(462, 207)
        Me.lblExperience.Size = New System.Drawing.Size(330, 25)
        Me.lblExperience.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
        Me.lblExperience.BackColor = System.Drawing.Color.Transparent
        Me.lblExperience.ForeColor = System.Drawing.Color.FromArgb(166, 181, 207)
        Me.cmbExperience = New System.Windows.Forms.ComboBox()
        Me.cmbExperience.Location = New System.Drawing.Point(462, 239)
        Me.cmbExperience.Size = New System.Drawing.Size(390, 32)
        Me.cmbExperience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExperience.BackColor = System.Drawing.Color.FromArgb(17, 29, 50)
        Me.cmbExperience.ForeColor = System.Drawing.Color.FromArgb(243, 247, 255)
        Me.cmbExperience.Items.AddRange(New Object() {"Helt ny", "Litt erfaring", "God erfaring"})
        Me.txtFirstName.MaxLength = 100
        Me.txtLastName.MaxLength = 100
        Me.txtFirstName.PlaceholderText = "Fornavn"
        Me.txtLastName.PlaceholderText = "Etternavn"
        Me.lblStatus.AutoEllipsis = True
        Me.cardProfile.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFirstName, Me.lblLastName, Me.txtFirstName, Me.txtLastName, Me.lblAddress, Me.txtUsername, Me.lblDomain, Me.lblRole, Me.cmbRole, Me.lblExperience, Me.cmbExperience})
        Me.tabProfile.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProfileTitle, Me.lblProfileHelp, Me.cardProfile, Me.chkRemember, Me.chkMotion, Me.btnReset})
        Me.footer.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStatus, Me.btnBack, Me.btnNext, Me.btnCancel})
        Me.tabWizard.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabProfile, Me.tabBrowser, Me.tabEmail, Me.tabGoogle, Me.tabChatGPT, Me.tabDiscord, Me.tabDrive, Me.tabAi, Me.tabFinish})
        Me.header.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblKicker, Me.lblHeader, Me.lblHeaderSub, Me.pnlHeroArt})
        Me.pnlProgressTrack.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlProgressFill})
        Me.pnlLogo.Controls.AddRange(New System.Windows.Forms.Control() {Me.picLogo})
        Me.sidebar.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlLogo, Me.lblBrand, Me.lblEdition, Me.btnStepProfile, Me.btnStepBrowser, Me.btnStepEmail, Me.btnStepGoogle, Me.btnStepChatGPT, Me.btnStepDiscord, Me.btnStepDrive, Me.btnStepAi, Me.btnStepFinish, Me.pnlNavIndicator, Me.lblSidebarTip, Me.pnlProgressTrack, Me.lblProgress})
        Me.rootLayout.Controls.Add(Me.sidebar, 0, 0)
        Me.rootLayout.Controls.Add(Me.mainLayout, 1, 0)
        Me.mainLayout.Controls.Add(Me.header, 0, 0)
        Me.mainLayout.Controls.Add(Me.tabWizard, 0, 1)
        Me.mainLayout.Controls.Add(Me.footer, 0, 2)
        Me.Controls.Add(Me.rootLayout)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents rootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents sidebar As System.Windows.Forms.Panel
    Friend WithEvents pnlLogo As System.Windows.Forms.Panel
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents lblEdition As System.Windows.Forms.Label
    Friend WithEvents btnStepProfile As System.Windows.Forms.Button
    Friend WithEvents btnStepBrowser As System.Windows.Forms.Button
    Friend WithEvents btnStepEmail As System.Windows.Forms.Button
    Friend WithEvents btnStepGoogle As System.Windows.Forms.Button
    Friend WithEvents btnStepChatGPT As System.Windows.Forms.Button
    Friend WithEvents btnStepDiscord As System.Windows.Forms.Button
    Friend WithEvents btnStepDrive As System.Windows.Forms.Button
    Friend WithEvents btnStepAi As System.Windows.Forms.Button
    Friend WithEvents btnStepFinish As System.Windows.Forms.Button
    Friend WithEvents pnlNavIndicator As System.Windows.Forms.Panel
    Friend WithEvents lblSidebarTip As System.Windows.Forms.Label
    Friend WithEvents pnlProgressTrack As System.Windows.Forms.Panel
    Friend WithEvents pnlProgressFill As System.Windows.Forms.Panel
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents mainLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents header As System.Windows.Forms.Panel
    Friend WithEvents lblKicker As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents pnlHeroArt As System.Windows.Forms.Panel
    Friend WithEvents tabWizard As System.Windows.Forms.TabControl
    Friend WithEvents tabProfile As System.Windows.Forms.TabPage
    Friend WithEvents tabBrowser As System.Windows.Forms.TabPage
    Friend WithEvents tabEmail As System.Windows.Forms.TabPage
    Friend WithEvents tabGoogle As System.Windows.Forms.TabPage
    Friend WithEvents tabChatGPT As System.Windows.Forms.TabPage
    Friend WithEvents tabDiscord As System.Windows.Forms.TabPage
    Friend WithEvents tabDrive As System.Windows.Forms.TabPage
    Friend WithEvents tabAi As System.Windows.Forms.TabPage
    Friend WithEvents tabFinish As System.Windows.Forms.TabPage
    Friend WithEvents footer As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblProfileTitle As System.Windows.Forms.Label
    Friend WithEvents lblProfileHelp As System.Windows.Forms.Label
    Friend WithEvents cardProfile As System.Windows.Forms.Panel
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblDomain As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents lblExperience As System.Windows.Forms.Label
    Friend WithEvents cmbExperience As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRole As System.Windows.Forms.ComboBox
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents chkMotion As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblBrowserTitle As System.Windows.Forms.Label
    Friend WithEvents lblBrowserHelp As System.Windows.Forms.Label
    Friend WithEvents rbChrome As System.Windows.Forms.RadioButton
    Friend WithEvents rbFirefox As System.Windows.Forms.RadioButton
    Friend WithEvents rbEdge As System.Windows.Forms.RadioButton
    Friend WithEvents lblBrowserDetected As System.Windows.Forms.Label
    Friend WithEvents btnBrowserDownload As System.Windows.Forms.Button
    Friend WithEvents btnBrowserInstall As System.Windows.Forms.Button
    Friend WithEvents btnBrowserPage As System.Windows.Forms.Button
    Friend WithEvents lblBrowserTransfer As System.Windows.Forms.Label
    Friend WithEvents barBrowser As System.Windows.Forms.ProgressBar
    Friend WithEvents btnStarterPack As System.Windows.Forms.Button
    Friend WithEvents btnDefaultBrowser As System.Windows.Forms.Button
    Friend WithEvents btnRefreshApps As System.Windows.Forms.Button
    Friend WithEvents chkBrowser As System.Windows.Forms.CheckBox
    Friend WithEvents lblEmailTitle As System.Windows.Forms.Label
    Friend WithEvents lblEmailAccount As System.Windows.Forms.Label
    Friend WithEvents lblEmailGuide As System.Windows.Forms.Label
    Friend WithEvents btnCopyEmail As System.Windows.Forms.Button
    Friend WithEvents btnOpenWebmail As System.Windows.Forms.Button
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents btnHelpEmail As System.Windows.Forms.Button
    Friend WithEvents lblGoogleTitle As System.Windows.Forms.Label
    Friend WithEvents lblGoogleAccount As System.Windows.Forms.Label
    Friend WithEvents lblGoogleGuide As System.Windows.Forms.Label
    Friend WithEvents btnOpenGoogle As System.Windows.Forms.Button
    Friend WithEvents btnWorkspace As System.Windows.Forms.Button
    Friend WithEvents chkGoogle As System.Windows.Forms.CheckBox
    Friend WithEvents btnHelpGoogle As System.Windows.Forms.Button
    Friend WithEvents lblChatGPTTitle As System.Windows.Forms.Label
    Friend WithEvents lblChatGPTAccount As System.Windows.Forms.Label
    Friend WithEvents lblChatGPTGuide As System.Windows.Forms.Label
    Friend WithEvents btnChatWebmail As System.Windows.Forms.Button
    Friend WithEvents btnOpenChatGPT As System.Windows.Forms.Button
    Friend WithEvents chkChatGPT As System.Windows.Forms.CheckBox
    Friend WithEvents btnHelpChatGPT As System.Windows.Forms.Button
    Friend WithEvents lblDriveTitle As System.Windows.Forms.Label
    Friend WithEvents lblDriveAccount As System.Windows.Forms.Label
    Friend WithEvents lblDriveGuide As System.Windows.Forms.Label
    Friend WithEvents btnDrive As System.Windows.Forms.Button
    Friend WithEvents btnDocs As System.Windows.Forms.Button
    Friend WithEvents chkDrive As System.Windows.Forms.CheckBox
    Friend WithEvents btnHelpDrive As System.Windows.Forms.Button
    Friend WithEvents lblDiscordTitle As System.Windows.Forms.Label
    Friend WithEvents lblDiscordGuide As System.Windows.Forms.Label
    Friend WithEvents btnDiscordDownload As System.Windows.Forms.Button
    Friend WithEvents btnDiscordInstall As System.Windows.Forms.Button
    Friend WithEvents btnDiscordPage As System.Windows.Forms.Button
    Friend WithEvents lblDiscordTransfer As System.Windows.Forms.Label
    Friend WithEvents barDiscord As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDiscordInvite As System.Windows.Forms.Label
    Friend WithEvents btnDiscordInvite As System.Windows.Forms.Button
    Friend WithEvents btnDiscordApp As System.Windows.Forms.Button
    Friend WithEvents btnDownloadsFolder As System.Windows.Forms.Button
    Friend WithEvents chkDiscord As System.Windows.Forms.CheckBox
    Friend WithEvents lblAiTitle As System.Windows.Forms.Label
    Friend WithEvents lblAiConnection As System.Windows.Forms.Label
    Friend WithEvents lblAiToken As System.Windows.Forms.Label
    Friend WithEvents txtAiCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAiStep As System.Windows.Forms.Label
    Friend WithEvents cmbAiStep As System.Windows.Forms.ComboBox
    Friend WithEvents txtAiAnswer As System.Windows.Forms.TextBox
    Friend WithEvents txtQuestion As System.Windows.Forms.TextBox
    Friend WithEvents chkAiConsent As System.Windows.Forms.CheckBox
    Friend WithEvents btnAsk As System.Windows.Forms.Button
    Friend WithEvents btnLocalHelp As System.Windows.Forms.Button
    Friend WithEvents btnAiClear As System.Windows.Forms.Button
    Friend WithEvents lblFinishTitle As System.Windows.Forms.Label
    Friend WithEvents lblFinishHelp As System.Windows.Forms.Label
    Friend WithEvents txtReport As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyReport As System.Windows.Forms.Button
    Friend WithEvents btnSaveReport As System.Windows.Forms.Button
    Friend WithEvents btnNewMember As System.Windows.Forms.Button
End Class
