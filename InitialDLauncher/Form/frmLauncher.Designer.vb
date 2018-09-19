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
        Me.btnMin = New InitialDLauncher.TextButton()
        Me.btnExit = New InitialDLauncher.TextButton()
        Me.lblStart6 = New InitialDLauncher.TextButton()
        Me.lblStart7 = New InitialDLauncher.TextButton()
        Me.lblLeaderboard = New InitialDLauncher.TextButton()
        Me.lblLogout = New InitialDLauncher.TextButton()
        Me.lblStart8 = New InitialDLauncher.TextButton()
        Me.lblVersion = New InitialDLauncher.TextButton()
        Me.lblCardMan = New InitialDLauncher.TextButton()
        Me.lblExit = New InitialDLauncher.TextButton()
        Me.lblSetting = New InitialDLauncher.TextButton()
        Me.lblDebug = New InitialDLauncher.TextButton()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'btnMin
        '
        Me.btnMin.AddEffect = False
        Me.btnMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMin.BackColor = System.Drawing.Color.Transparent
        Me.btnMin.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnMin.EffectAfter = ""
        Me.btnMin.EffectBefore = Nothing
        Me.btnMin.EffectWidth = 39
        Me.btnMin.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.btnMin.ForeColor = System.Drawing.Color.Silver
        Me.btnMin.Location = New System.Drawing.Point(792, 9)
        Me.btnMin.MouseHoverColor = System.Drawing.Color.White
        Me.btnMin.MousePressedColor = System.Drawing.Color.Gold
        Me.btnMin.Name = "btnMin"
        Me.btnMin.NormalColor = System.Drawing.Color.Silver
        Me.btnMin.P = Me
        Me.btnMin.Size = New System.Drawing.Size(19, 19)
        Me.btnMin.TabIndex = 10
        Me.btnMin.Text = "0"
        Me.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.AddEffect = False
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.DisabledColor = System.Drawing.Color.DarkGray
        Me.btnExit.EffectAfter = ""
        Me.btnExit.EffectBefore = Nothing
        Me.btnExit.EffectWidth = 39
        Me.btnExit.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.btnExit.ForeColor = System.Drawing.Color.Silver
        Me.btnExit.Location = New System.Drawing.Point(817, 8)
        Me.btnExit.MouseHoverColor = System.Drawing.Color.White
        Me.btnExit.MousePressedColor = System.Drawing.Color.Gold
        Me.btnExit.Name = "btnExit"
        Me.btnExit.NormalColor = System.Drawing.Color.Silver
        Me.btnExit.P = Me
        Me.btnExit.Size = New System.Drawing.Size(19, 19)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "r"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStart6
        '
        Me.lblStart6.AddEffect = True
        Me.lblStart6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart6.BackColor = System.Drawing.Color.Transparent
        Me.lblStart6.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblStart6.EffectAfter = " <<"
        Me.lblStart6.EffectBefore = Nothing
        Me.lblStart6.EffectWidth = 39
        Me.lblStart6.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblStart6.ForeColor = System.Drawing.Color.Silver
        Me.lblStart6.Location = New System.Drawing.Point(441, 201)
        Me.lblStart6.MouseHoverColor = System.Drawing.Color.White
        Me.lblStart6.MousePressedColor = System.Drawing.Color.Gold
        Me.lblStart6.Name = "lblStart6"
        Me.lblStart6.NormalColor = System.Drawing.Color.Silver
        Me.lblStart6.P = Me
        Me.lblStart6.Size = New System.Drawing.Size(359, 32)
        Me.lblStart6.TabIndex = 2
        Me.lblStart6.Text = "Play Initial D 6 AA"
        Me.lblStart6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStart7
        '
        Me.lblStart7.AddEffect = True
        Me.lblStart7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart7.BackColor = System.Drawing.Color.Transparent
        Me.lblStart7.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblStart7.EffectAfter = " <<"
        Me.lblStart7.EffectBefore = Nothing
        Me.lblStart7.EffectWidth = 39
        Me.lblStart7.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblStart7.ForeColor = System.Drawing.Color.Silver
        Me.lblStart7.Location = New System.Drawing.Point(441, 233)
        Me.lblStart7.MouseHoverColor = System.Drawing.Color.White
        Me.lblStart7.MousePressedColor = System.Drawing.Color.Gold
        Me.lblStart7.Name = "lblStart7"
        Me.lblStart7.NormalColor = System.Drawing.Color.Silver
        Me.lblStart7.P = Me
        Me.lblStart7.Size = New System.Drawing.Size(359, 32)
        Me.lblStart7.TabIndex = 3
        Me.lblStart7.Text = "Play Initial D 7 AAX"
        Me.lblStart7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLeaderboard
        '
        Me.lblLeaderboard.AddEffect = True
        Me.lblLeaderboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLeaderboard.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaderboard.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblLeaderboard.EffectAfter = " <<"
        Me.lblLeaderboard.EffectBefore = Nothing
        Me.lblLeaderboard.EffectWidth = 39
        Me.lblLeaderboard.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblLeaderboard.ForeColor = System.Drawing.Color.Silver
        Me.lblLeaderboard.Location = New System.Drawing.Point(441, 317)
        Me.lblLeaderboard.MouseHoverColor = System.Drawing.Color.White
        Me.lblLeaderboard.MousePressedColor = System.Drawing.Color.Gold
        Me.lblLeaderboard.Name = "lblLeaderboard"
        Me.lblLeaderboard.NormalColor = System.Drawing.Color.Silver
        Me.lblLeaderboard.P = Me
        Me.lblLeaderboard.Size = New System.Drawing.Size(359, 32)
        Me.lblLeaderboard.TabIndex = 5
        Me.lblLeaderboard.Text = "TA Leaderboard"
        Me.lblLeaderboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLogout
        '
        Me.lblLogout.AddEffect = False
        Me.lblLogout.AutoSize = True
        Me.lblLogout.BackColor = System.Drawing.Color.Transparent
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
        Me.lblLogout.Size = New System.Drawing.Size(60, 19)
        Me.lblLogout.TabIndex = 0
        Me.lblLogout.Text = "User: {0}"
        Me.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStart8
        '
        Me.lblStart8.AddEffect = True
        Me.lblStart8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart8.BackColor = System.Drawing.Color.Transparent
        Me.lblStart8.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblStart8.EffectAfter = " <<"
        Me.lblStart8.EffectBefore = Nothing
        Me.lblStart8.EffectWidth = 39
        Me.lblStart8.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblStart8.ForeColor = System.Drawing.Color.Silver
        Me.lblStart8.Location = New System.Drawing.Point(441, 265)
        Me.lblStart8.MouseHoverColor = System.Drawing.Color.White
        Me.lblStart8.MousePressedColor = System.Drawing.Color.Gold
        Me.lblStart8.Name = "lblStart8"
        Me.lblStart8.NormalColor = System.Drawing.Color.Silver
        Me.lblStart8.P = Me
        Me.lblStart8.Size = New System.Drawing.Size(359, 32)
        Me.lblStart8.TabIndex = 4
        Me.lblStart8.Text = "Play Initial D 8 Infinity"
        Me.lblStart8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersion
        '
        Me.lblVersion.AddEffect = False
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblVersion.EffectAfter = " <<"
        Me.lblVersion.EffectBefore = Nothing
        Me.lblVersion.EffectWidth = 43
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblVersion.ForeColor = System.Drawing.Color.Silver
        Me.lblVersion.Location = New System.Drawing.Point(12, 452)
        Me.lblVersion.MouseHoverColor = System.Drawing.Color.White
        Me.lblVersion.MousePressedColor = System.Drawing.Color.Gold
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.NormalColor = System.Drawing.Color.Silver
        Me.lblVersion.P = Me
        Me.lblVersion.Size = New System.Drawing.Size(81, 19)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Version: 1.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCardMan
        '
        Me.lblCardMan.AddEffect = True
        Me.lblCardMan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardMan.BackColor = System.Drawing.Color.Transparent
        Me.lblCardMan.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblCardMan.EffectAfter = " <<"
        Me.lblCardMan.EffectBefore = Nothing
        Me.lblCardMan.EffectWidth = 39
        Me.lblCardMan.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblCardMan.ForeColor = System.Drawing.Color.Silver
        Me.lblCardMan.Location = New System.Drawing.Point(441, 349)
        Me.lblCardMan.MouseHoverColor = System.Drawing.Color.White
        Me.lblCardMan.MousePressedColor = System.Drawing.Color.Gold
        Me.lblCardMan.Name = "lblCardMan"
        Me.lblCardMan.NormalColor = System.Drawing.Color.Silver
        Me.lblCardMan.P = Me
        Me.lblCardMan.Size = New System.Drawing.Size(359, 32)
        Me.lblCardMan.TabIndex = 6
        Me.lblCardMan.Text = "Card Selection"
        Me.lblCardMan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExit
        '
        Me.lblExit.AddEffect = True
        Me.lblExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExit.BackColor = System.Drawing.Color.Transparent
        Me.lblExit.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblExit.EffectAfter = " <<"
        Me.lblExit.EffectBefore = Nothing
        Me.lblExit.EffectWidth = 39
        Me.lblExit.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblExit.ForeColor = System.Drawing.Color.Silver
        Me.lblExit.Location = New System.Drawing.Point(441, 413)
        Me.lblExit.MouseHoverColor = System.Drawing.Color.White
        Me.lblExit.MousePressedColor = System.Drawing.Color.Gold
        Me.lblExit.Name = "lblExit"
        Me.lblExit.NormalColor = System.Drawing.Color.Silver
        Me.lblExit.P = Me
        Me.lblExit.Size = New System.Drawing.Size(359, 32)
        Me.lblExit.TabIndex = 8
        Me.lblExit.Text = "Quit Game"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSetting
        '
        Me.lblSetting.AddEffect = True
        Me.lblSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblSetting.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblSetting.EffectAfter = " <<"
        Me.lblSetting.EffectBefore = Nothing
        Me.lblSetting.EffectWidth = 39
        Me.lblSetting.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblSetting.ForeColor = System.Drawing.Color.Silver
        Me.lblSetting.Location = New System.Drawing.Point(441, 381)
        Me.lblSetting.MouseHoverColor = System.Drawing.Color.White
        Me.lblSetting.MousePressedColor = System.Drawing.Color.Gold
        Me.lblSetting.Name = "lblSetting"
        Me.lblSetting.NormalColor = System.Drawing.Color.Silver
        Me.lblSetting.P = Me
        Me.lblSetting.Size = New System.Drawing.Size(359, 32)
        Me.lblSetting.TabIndex = 7
        Me.lblSetting.Text = "Settings"
        Me.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebug
        '
        Me.lblDebug.AddEffect = True
        Me.lblDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDebug.BackColor = System.Drawing.Color.Transparent
        Me.lblDebug.DisabledColor = System.Drawing.Color.DarkGray
        Me.lblDebug.EffectAfter = " <<"
        Me.lblDebug.EffectBefore = Nothing
        Me.lblDebug.EffectWidth = 39
        Me.lblDebug.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.lblDebug.ForeColor = System.Drawing.Color.Silver
        Me.lblDebug.Location = New System.Drawing.Point(441, 169)
        Me.lblDebug.MouseHoverColor = System.Drawing.Color.White
        Me.lblDebug.MousePressedColor = System.Drawing.Color.Gold
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.NormalColor = System.Drawing.Color.Silver
        Me.lblDebug.P = Me
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
        Me.BackgroundImage = Global.InitialDLauncher.My.Resources.Resources.new_bg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(848, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblStart6)
        Me.Controls.Add(Me.lblStart7)
        Me.Controls.Add(Me.lblLeaderboard)
        Me.Controls.Add(Me.lblLogout)
        Me.Controls.Add(Me.lblStart8)
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
        Me.Name = "frmLauncher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InitialD Arcade Stage Launcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblStart6 As TextButton
    Friend WithEvents lblStart7 As TextButton
    Friend WithEvents lblExit As TextButton
    Friend WithEvents lblSetting As TextButton
    Friend WithEvents lblDebug As TextButton
    Friend WithEvents lblVersion As TextButton
    Friend WithEvents lblCardMan As TextButton
    Friend WithEvents lblLeaderboard As TextButton
    Friend WithEvents lblLogout As TextButton
    Friend WithEvents lblStart8 As TextButton
    Friend WithEvents btnMin As TextButton
    Friend WithEvents btnExit As TextButton
End Class
