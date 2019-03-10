<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLauncher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLauncher))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tcPlay = New InitialDLauncher.TransparentControl()
        Me.btnExit2 = New InitialDLauncher.TextButton()
        Me.btnStart8 = New InitialDLauncher.TextButton()
        Me.btnStart7 = New InitialDLauncher.TextButton()
        Me.btnStart6 = New InitialDLauncher.TextButton()
        Me.btnStart5 = New InitialDLauncher.TextButton()
        Me.btnStart4e = New InitialDLauncher.TextButton()
        Me.btnStart4 = New InitialDLauncher.TextButton()
        Me.btnMin = New InitialDLauncher.TextButton()
        Me.btnExit = New InitialDLauncher.TextButton()
        Me.lblLeaderboard = New InitialDLauncher.TextButton()
        Me.lblLogout = New InitialDLauncher.TextButton()
        Me.lblStart = New InitialDLauncher.TextButton()
        Me.lblVersion = New InitialDLauncher.TextButton()
        Me.lblCardMan = New InitialDLauncher.TextButton()
        Me.lblExit = New InitialDLauncher.TextButton()
        Me.lblSetting = New InitialDLauncher.TextButton()
        Me.lblDebug = New InitialDLauncher.TextButton()
        Me.tcPlay.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'tcPlay
        '
        Me.tcPlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tcPlay.Controls.Add(Me.btnExit2)
        Me.tcPlay.Controls.Add(Me.btnStart8)
        Me.tcPlay.Controls.Add(Me.btnStart7)
        Me.tcPlay.Controls.Add(Me.btnStart6)
        Me.tcPlay.Controls.Add(Me.btnStart5)
        Me.tcPlay.Controls.Add(Me.btnStart4e)
        Me.tcPlay.Controls.Add(Me.btnStart4)
        Me.tcPlay.Location = New System.Drawing.Point(351, 176)
        Me.tcPlay.MinimumSize = New System.Drawing.Size(50, 20)
        Me.tcPlay.Name = "tcPlay"
        Me.tcPlay.Opacity = 0.7R
        Me.tcPlay.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPlay.Size = New System.Drawing.Size(289, 240)
        Me.tcPlay.TabIndex = 12
        Me.tcPlay.Transparent = True
        Me.tcPlay.TransparentColor = System.Drawing.Color.Black
        Me.tcPlay.Visible = False
        '
        'btnExit2
        '
        Me.btnExit2.AddEffect = False
        Me.btnExit2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit2.BackColor = System.Drawing.Color.Transparent
        Me.btnExit2.BorderColor = System.Drawing.Color.Black
        Me.btnExit2.BorderSize = 3.0!
        Me.btnExit2.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnExit2.EffectAfter = ""
        Me.btnExit2.EffectBefore = Nothing
        Me.btnExit2.EffectWidth = 39
        Me.btnExit2.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.btnExit2.ForeColor = System.Drawing.Color.Silver
        Me.btnExit2.Location = New System.Drawing.Point(267, 4)
        Me.btnExit2.MouseHoverColor = System.Drawing.Color.White
        Me.btnExit2.MousePressedColor = System.Drawing.Color.Gold
        Me.btnExit2.Name = "btnExit2"
        Me.btnExit2.NormalColor = System.Drawing.Color.Silver
        Me.btnExit2.P = Me.tcPlay
        Me.btnExit2.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnExit2.Size = New System.Drawing.Size(19, 19)
        Me.btnExit2.TabIndex = 17
        Me.btnExit2.Text = "r"
        Me.btnExit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart8
        '
        Me.btnStart8.AddEffect = False
        Me.btnStart8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart8.BackColor = System.Drawing.Color.Transparent
        Me.btnStart8.BorderColor = System.Drawing.Color.Black
        Me.btnStart8.BorderSize = 3.0!
        Me.btnStart8.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnStart8.EffectAfter = ""
        Me.btnStart8.EffectBefore = Nothing
        Me.btnStart8.EffectWidth = 39
        Me.btnStart8.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnStart8.ForeColor = System.Drawing.Color.Silver
        Me.btnStart8.Location = New System.Drawing.Point(6, 168)
        Me.btnStart8.MouseHoverColor = System.Drawing.Color.White
        Me.btnStart8.MousePressedColor = System.Drawing.Color.Gold
        Me.btnStart8.Name = "btnStart8"
        Me.btnStart8.NormalColor = System.Drawing.Color.Silver
        Me.btnStart8.P = Me.tcPlay
        Me.btnStart8.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnStart8.Size = New System.Drawing.Size(283, 25)
        Me.btnStart8.TabIndex = 16
        Me.btnStart8.Text = "Initial D 8 Infinity"
        Me.btnStart8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart7
        '
        Me.btnStart7.AddEffect = False
        Me.btnStart7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart7.BackColor = System.Drawing.Color.Transparent
        Me.btnStart7.BorderColor = System.Drawing.Color.Black
        Me.btnStart7.BorderSize = 3.0!
        Me.btnStart7.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnStart7.EffectAfter = ""
        Me.btnStart7.EffectBefore = Nothing
        Me.btnStart7.EffectWidth = 39
        Me.btnStart7.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnStart7.ForeColor = System.Drawing.Color.Silver
        Me.btnStart7.Location = New System.Drawing.Point(6, 143)
        Me.btnStart7.MouseHoverColor = System.Drawing.Color.White
        Me.btnStart7.MousePressedColor = System.Drawing.Color.Gold
        Me.btnStart7.Name = "btnStart7"
        Me.btnStart7.NormalColor = System.Drawing.Color.Silver
        Me.btnStart7.P = Me.tcPlay
        Me.btnStart7.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnStart7.Size = New System.Drawing.Size(283, 25)
        Me.btnStart7.TabIndex = 15
        Me.btnStart7.Text = "Initial D 7 AAX"
        Me.btnStart7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart6
        '
        Me.btnStart6.AddEffect = False
        Me.btnStart6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart6.BackColor = System.Drawing.Color.Transparent
        Me.btnStart6.BorderColor = System.Drawing.Color.Black
        Me.btnStart6.BorderSize = 3.0!
        Me.btnStart6.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnStart6.EffectAfter = ""
        Me.btnStart6.EffectBefore = Nothing
        Me.btnStart6.EffectWidth = 39
        Me.btnStart6.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnStart6.ForeColor = System.Drawing.Color.Silver
        Me.btnStart6.Location = New System.Drawing.Point(6, 118)
        Me.btnStart6.MouseHoverColor = System.Drawing.Color.White
        Me.btnStart6.MousePressedColor = System.Drawing.Color.Gold
        Me.btnStart6.Name = "btnStart6"
        Me.btnStart6.NormalColor = System.Drawing.Color.Silver
        Me.btnStart6.P = Me.tcPlay
        Me.btnStart6.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnStart6.Size = New System.Drawing.Size(283, 25)
        Me.btnStart6.TabIndex = 14
        Me.btnStart6.Text = "Initial D 6 AA"
        Me.btnStart6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart5
        '
        Me.btnStart5.AddEffect = False
        Me.btnStart5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart5.BackColor = System.Drawing.Color.Transparent
        Me.btnStart5.BorderColor = System.Drawing.Color.Black
        Me.btnStart5.BorderSize = 3.0!
        Me.btnStart5.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnStart5.EffectAfter = ""
        Me.btnStart5.EffectBefore = Nothing
        Me.btnStart5.EffectWidth = 39
        Me.btnStart5.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnStart5.ForeColor = System.Drawing.Color.Silver
        Me.btnStart5.Location = New System.Drawing.Point(6, 93)
        Me.btnStart5.MouseHoverColor = System.Drawing.Color.White
        Me.btnStart5.MousePressedColor = System.Drawing.Color.Gold
        Me.btnStart5.Name = "btnStart5"
        Me.btnStart5.NormalColor = System.Drawing.Color.Silver
        Me.btnStart5.P = Me.tcPlay
        Me.btnStart5.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnStart5.Size = New System.Drawing.Size(283, 25)
        Me.btnStart5.TabIndex = 13
        Me.btnStart5.Text = "Initial D 5"
        Me.btnStart5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart4e
        '
        Me.btnStart4e.AddEffect = False
        Me.btnStart4e.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart4e.BackColor = System.Drawing.Color.Transparent
        Me.btnStart4e.BorderColor = System.Drawing.Color.Black
        Me.btnStart4e.BorderSize = 3.0!
        Me.btnStart4e.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnStart4e.EffectAfter = ""
        Me.btnStart4e.EffectBefore = Nothing
        Me.btnStart4e.EffectWidth = 39
        Me.btnStart4e.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnStart4e.ForeColor = System.Drawing.Color.Silver
        Me.btnStart4e.Location = New System.Drawing.Point(6, 68)
        Me.btnStart4e.MouseHoverColor = System.Drawing.Color.White
        Me.btnStart4e.MousePressedColor = System.Drawing.Color.Gold
        Me.btnStart4e.Name = "btnStart4e"
        Me.btnStart4e.NormalColor = System.Drawing.Color.Silver
        Me.btnStart4e.P = Me.tcPlay
        Me.btnStart4e.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnStart4e.Size = New System.Drawing.Size(283, 25)
        Me.btnStart4e.TabIndex = 12
        Me.btnStart4e.Text = "Initial D 4 Export"
        Me.btnStart4e.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart4
        '
        Me.btnStart4.AddEffect = False
        Me.btnStart4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart4.BackColor = System.Drawing.Color.Transparent
        Me.btnStart4.BorderColor = System.Drawing.Color.Black
        Me.btnStart4.BorderSize = 3.0!
        Me.btnStart4.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnStart4.EffectAfter = ""
        Me.btnStart4.EffectBefore = Nothing
        Me.btnStart4.EffectWidth = 39
        Me.btnStart4.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnStart4.ForeColor = System.Drawing.Color.Silver
        Me.btnStart4.Location = New System.Drawing.Point(6, 43)
        Me.btnStart4.MouseHoverColor = System.Drawing.Color.White
        Me.btnStart4.MousePressedColor = System.Drawing.Color.Gold
        Me.btnStart4.Name = "btnStart4"
        Me.btnStart4.NormalColor = System.Drawing.Color.Silver
        Me.btnStart4.P = Me.tcPlay
        Me.btnStart4.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnStart4.Size = New System.Drawing.Size(283, 25)
        Me.btnStart4.TabIndex = 11
        Me.btnStart4.Text = "Initial D 4"
        Me.btnStart4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMin
        '
        Me.btnMin.AddEffect = False
        Me.btnMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.BorderColor = System.Drawing.Color.Black
        Me.btnMin.BorderSize = 3.0!
        Me.btnMin.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnMin.EffectAfter = ""
        Me.btnMin.EffectBefore = Nothing
        Me.btnMin.EffectWidth = 39
        Me.btnMin.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.btnMin.ForeColor = System.Drawing.Color.Silver
        Me.btnMin.Location = New System.Drawing.Point(934, 10)
        Me.btnMin.MouseHoverColor = System.Drawing.Color.White
        Me.btnMin.MousePressedColor = System.Drawing.Color.Gold
        Me.btnMin.Name = "btnMin"
        Me.btnMin.NormalColor = System.Drawing.Color.Silver
        Me.btnMin.P = Me
        Me.btnMin.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnMin.Size = New System.Drawing.Size(19, 19)
        Me.btnMin.TabIndex = 8
        Me.btnMin.Text = "0"
        Me.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.AddEffect = False
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BorderColor = System.Drawing.Color.Black
        Me.btnExit.BorderSize = 3.0!
        Me.btnExit.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnExit.EffectAfter = ""
        Me.btnExit.EffectBefore = Nothing
        Me.btnExit.EffectWidth = 39
        Me.btnExit.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.btnExit.ForeColor = System.Drawing.Color.Silver
        Me.btnExit.Location = New System.Drawing.Point(959, 9)
        Me.btnExit.MouseHoverColor = System.Drawing.Color.White
        Me.btnExit.MousePressedColor = System.Drawing.Color.Gold
        Me.btnExit.Name = "btnExit"
        Me.btnExit.NormalColor = System.Drawing.Color.Silver
        Me.btnExit.P = Me
        Me.btnExit.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.btnExit.Size = New System.Drawing.Size(19, 19)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "r"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLeaderboard
        '
        Me.lblLeaderboard.AddEffect = False
        Me.lblLeaderboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLeaderboard.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaderboard.BorderColor = System.Drawing.Color.Black
        Me.lblLeaderboard.BorderSize = 3.0!
        Me.lblLeaderboard.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblLeaderboard.EffectAfter = " <<"
        Me.lblLeaderboard.EffectBefore = Nothing
        Me.lblLeaderboard.EffectWidth = 39
        Me.lblLeaderboard.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblLeaderboard.ForeColor = System.Drawing.Color.Silver
        Me.lblLeaderboard.Location = New System.Drawing.Point(603, 435)
        Me.lblLeaderboard.MouseHoverColor = System.Drawing.Color.White
        Me.lblLeaderboard.MousePressedColor = System.Drawing.Color.Gold
        Me.lblLeaderboard.Name = "lblLeaderboard"
        Me.lblLeaderboard.NormalColor = System.Drawing.Color.Silver
        Me.lblLeaderboard.P = Me
        Me.lblLeaderboard.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblLeaderboard.Size = New System.Drawing.Size(359, 32)
        Me.lblLeaderboard.TabIndex = 3
        Me.lblLeaderboard.Text = "TA Leaderboard"
        Me.lblLeaderboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLogout
        '
        Me.lblLogout.AddEffect = False
        Me.lblLogout.BackColor = System.Drawing.Color.Transparent
        Me.lblLogout.BorderColor = System.Drawing.Color.Black
        Me.lblLogout.BorderSize = 3.0!
        Me.lblLogout.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblLogout.EffectAfter = " <<"
        Me.lblLogout.EffectBefore = Nothing
        Me.lblLogout.EffectWidth = 43
        Me.lblLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblLogout.ForeColor = System.Drawing.Color.Silver
        Me.lblLogout.Location = New System.Drawing.Point(12, 9)
        Me.lblLogout.MouseHoverColor = System.Drawing.Color.White
        Me.lblLogout.MousePressedColor = System.Drawing.Color.Gold
        Me.lblLogout.Name = "lblLogout"
        Me.lblLogout.NormalColor = System.Drawing.Color.Silver
        Me.lblLogout.P = Me
        Me.lblLogout.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblLogout.Size = New System.Drawing.Size(900, 19)
        Me.lblLogout.TabIndex = 0
        Me.lblLogout.Text = "User: {0}"
        Me.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStart
        '
        Me.lblStart.AddEffect = False
        Me.lblStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart.BackColor = System.Drawing.Color.Transparent
        Me.lblStart.BorderColor = System.Drawing.Color.Black
        Me.lblStart.BorderSize = 3.0!
        Me.lblStart.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblStart.EffectAfter = " <<"
        Me.lblStart.EffectBefore = Nothing
        Me.lblStart.EffectWidth = 39
        Me.lblStart.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblStart.ForeColor = System.Drawing.Color.Silver
        Me.lblStart.Location = New System.Drawing.Point(603, 383)
        Me.lblStart.MouseHoverColor = System.Drawing.Color.White
        Me.lblStart.MousePressedColor = System.Drawing.Color.Gold
        Me.lblStart.Name = "lblStart"
        Me.lblStart.NormalColor = System.Drawing.Color.Silver
        Me.lblStart.P = Me
        Me.lblStart.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblStart.Size = New System.Drawing.Size(359, 32)
        Me.lblStart.TabIndex = 2
        Me.lblStart.Text = "Play"
        Me.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersion
        '
        Me.lblVersion.AddEffect = False
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.BorderColor = System.Drawing.Color.Black
        Me.lblVersion.BorderSize = 3.0!
        Me.lblVersion.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblVersion.EffectAfter = " <<"
        Me.lblVersion.EffectBefore = Nothing
        Me.lblVersion.EffectWidth = 43
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblVersion.ForeColor = System.Drawing.Color.Silver
        Me.lblVersion.Location = New System.Drawing.Point(12, 562)
        Me.lblVersion.MouseHoverColor = System.Drawing.Color.White
        Me.lblVersion.MousePressedColor = System.Drawing.Color.Gold
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.NormalColor = System.Drawing.Color.Silver
        Me.lblVersion.P = Me
        Me.lblVersion.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblVersion.Size = New System.Drawing.Size(481, 19)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "Version: 1.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCardMan
        '
        Me.lblCardMan.AddEffect = False
        Me.lblCardMan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardMan.BackColor = System.Drawing.Color.Transparent
        Me.lblCardMan.BorderColor = System.Drawing.Color.Black
        Me.lblCardMan.BorderSize = 3.0!
        Me.lblCardMan.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblCardMan.EffectAfter = " <<"
        Me.lblCardMan.EffectBefore = Nothing
        Me.lblCardMan.EffectWidth = 39
        Me.lblCardMan.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblCardMan.ForeColor = System.Drawing.Color.Silver
        Me.lblCardMan.Location = New System.Drawing.Point(603, 467)
        Me.lblCardMan.MouseHoverColor = System.Drawing.Color.White
        Me.lblCardMan.MousePressedColor = System.Drawing.Color.Gold
        Me.lblCardMan.Name = "lblCardMan"
        Me.lblCardMan.NormalColor = System.Drawing.Color.Silver
        Me.lblCardMan.P = Me
        Me.lblCardMan.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblCardMan.Size = New System.Drawing.Size(359, 32)
        Me.lblCardMan.TabIndex = 4
        Me.lblCardMan.Text = "Card Selection"
        Me.lblCardMan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExit
        '
        Me.lblExit.AddEffect = False
        Me.lblExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExit.BackColor = System.Drawing.Color.Transparent
        Me.lblExit.BorderColor = System.Drawing.Color.Black
        Me.lblExit.BorderSize = 3.0!
        Me.lblExit.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblExit.EffectAfter = " <<"
        Me.lblExit.EffectBefore = Nothing
        Me.lblExit.EffectWidth = 39
        Me.lblExit.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblExit.ForeColor = System.Drawing.Color.Silver
        Me.lblExit.Location = New System.Drawing.Point(603, 531)
        Me.lblExit.MouseHoverColor = System.Drawing.Color.White
        Me.lblExit.MousePressedColor = System.Drawing.Color.Gold
        Me.lblExit.Name = "lblExit"
        Me.lblExit.NormalColor = System.Drawing.Color.Silver
        Me.lblExit.P = Me
        Me.lblExit.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblExit.Size = New System.Drawing.Size(359, 32)
        Me.lblExit.TabIndex = 6
        Me.lblExit.Text = "Quit Game"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSetting
        '
        Me.lblSetting.AddEffect = False
        Me.lblSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblSetting.BorderColor = System.Drawing.Color.Black
        Me.lblSetting.BorderSize = 3.0!
        Me.lblSetting.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblSetting.EffectAfter = " <<"
        Me.lblSetting.EffectBefore = Nothing
        Me.lblSetting.EffectWidth = 39
        Me.lblSetting.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblSetting.ForeColor = System.Drawing.Color.Silver
        Me.lblSetting.Location = New System.Drawing.Point(603, 499)
        Me.lblSetting.MouseHoverColor = System.Drawing.Color.White
        Me.lblSetting.MousePressedColor = System.Drawing.Color.Gold
        Me.lblSetting.Name = "lblSetting"
        Me.lblSetting.NormalColor = System.Drawing.Color.Silver
        Me.lblSetting.P = Me
        Me.lblSetting.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblSetting.Size = New System.Drawing.Size(359, 32)
        Me.lblSetting.TabIndex = 5
        Me.lblSetting.Text = "Settings"
        Me.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebug
        '
        Me.lblDebug.AddEffect = False
        Me.lblDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDebug.BackColor = System.Drawing.Color.Transparent
        Me.lblDebug.BorderColor = System.Drawing.Color.Black
        Me.lblDebug.BorderSize = 3.0!
        Me.lblDebug.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblDebug.EffectAfter = " <<"
        Me.lblDebug.EffectBefore = Nothing
        Me.lblDebug.EffectWidth = 39
        Me.lblDebug.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblDebug.ForeColor = System.Drawing.Color.Silver
        Me.lblDebug.Location = New System.Drawing.Point(603, 349)
        Me.lblDebug.MouseHoverColor = System.Drawing.Color.White
        Me.lblDebug.MousePressedColor = System.Drawing.Color.Gold
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.NormalColor = System.Drawing.Color.Silver
        Me.lblDebug.P = Me
        Me.lblDebug.Padding = New System.Windows.Forms.Padding(0, 0, 10, 50)
        Me.lblDebug.Size = New System.Drawing.Size(359, 32)
        Me.lblDebug.TabIndex = 1
        Me.lblDebug.Text = "Debug"
        Me.lblDebug.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDebug.Visible = False
        '
        'frmLauncher
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.InitialDLauncher.My.Resources.Resources.ADVload030_bg_05_n_D8
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(990, 590)
        Me.ControlBox = False
        Me.Controls.Add(Me.tcPlay)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblLeaderboard)
        Me.Controls.Add(Me.lblLogout)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblCardMan)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.lblSetting)
        Me.Controls.Add(Me.lblDebug)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(990, 590)
        Me.Name = "frmLauncher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InitialD Arcade Stage Launcher"
        Me.tcPlay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblExit As TextButton
    Friend WithEvents lblSetting As TextButton
    Friend WithEvents lblDebug As TextButton
    Friend WithEvents lblVersion As TextButton
    Friend WithEvents lblCardMan As TextButton
    Friend WithEvents lblLeaderboard As TextButton
    Friend WithEvents lblLogout As TextButton
    Friend WithEvents lblStart As TextButton
    Friend WithEvents btnMin As TextButton
    Friend WithEvents btnExit As TextButton
    Friend WithEvents tcPlay As TransparentControl
    Friend WithEvents btnStart8 As TextButton
    Friend WithEvents btnStart7 As TextButton
    Friend WithEvents btnStart6 As TextButton
    Friend WithEvents btnStart5 As TextButton
    Friend WithEvents btnStart4e As TextButton
    Friend WithEvents btnStart4 As TextButton
    Friend WithEvents btnExit2 As TextButton
End Class
