﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLauncher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLauncher))
        Me.lblStart6 = New System.Windows.Forms.Label()
        Me.lblStart7 = New System.Windows.Forms.Label()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.lblSetting = New System.Windows.Forms.Label()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.lblCardMan = New System.Windows.Forms.Label()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblStart6
        '
        Me.lblStart6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart6.AutoSize = True
        Me.lblStart6.BackColor = System.Drawing.Color.Transparent
        Me.lblStart6.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblStart6.ForeColor = System.Drawing.Color.White
        Me.lblStart6.Location = New System.Drawing.Point(630, 88)
        Me.lblStart6.Name = "lblStart6"
        Me.lblStart6.Size = New System.Drawing.Size(228, 37)
        Me.lblStart6.TabIndex = 1
        Me.lblStart6.Text = "Play Initial D 6 AA"
        Me.lblStart6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStart7
        '
        Me.lblStart7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart7.AutoSize = True
        Me.lblStart7.BackColor = System.Drawing.Color.Transparent
        Me.lblStart7.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblStart7.ForeColor = System.Drawing.Color.White
        Me.lblStart7.Location = New System.Drawing.Point(614, 125)
        Me.lblStart7.Name = "lblStart7"
        Me.lblStart7.Size = New System.Drawing.Size(244, 37)
        Me.lblStart7.TabIndex = 2
        Me.lblStart7.Text = "Play Initial D 7 AAX"
        Me.lblStart7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExit
        '
        Me.lblExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExit.AutoSize = True
        Me.lblExit.BackColor = System.Drawing.Color.Transparent
        Me.lblExit.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblExit.ForeColor = System.Drawing.Color.White
        Me.lblExit.Location = New System.Drawing.Point(713, 236)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(145, 37)
        Me.lblExit.TabIndex = 4
        Me.lblExit.Text = "Quit Game"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSetting
        '
        Me.lblSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSetting.AutoSize = True
        Me.lblSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblSetting.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblSetting.ForeColor = System.Drawing.Color.White
        Me.lblSetting.Location = New System.Drawing.Point(746, 199)
        Me.lblSetting.Name = "lblSetting"
        Me.lblSetting.Size = New System.Drawing.Size(112, 37)
        Me.lblSetting.TabIndex = 3
        Me.lblSetting.Text = "Settings"
        Me.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebug
        '
        Me.lblDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDebug.AutoSize = True
        Me.lblDebug.BackColor = System.Drawing.Color.Transparent
        Me.lblDebug.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblDebug.ForeColor = System.Drawing.Color.White
        Me.lblDebug.Location = New System.Drawing.Point(761, 273)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(97, 37)
        Me.lblDebug.TabIndex = 5
        Me.lblDebug.Text = "Debug"
        Me.lblDebug.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDebug.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(12, 510)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(81, 19)
        Me.lblVersion.TabIndex = 6
        Me.lblVersion.Text = "Version: 1.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbLogo
        '
        Me.pbLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLogo.BackColor = System.Drawing.Color.Transparent
        Me.pbLogo.Image = Global.InitialDLauncher.My.Resources.Resources.id_logo
        Me.pbLogo.Location = New System.Drawing.Point(564, 291)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(392, 250)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 0
        Me.pbLogo.TabStop = False
        '
        'lblCardMan
        '
        Me.lblCardMan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardMan.AutoSize = True
        Me.lblCardMan.BackColor = System.Drawing.Color.Transparent
        Me.lblCardMan.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblCardMan.ForeColor = System.Drawing.Color.White
        Me.lblCardMan.Location = New System.Drawing.Point(670, 162)
        Me.lblCardMan.Name = "lblCardMan"
        Me.lblCardMan.Size = New System.Drawing.Size(188, 37)
        Me.lblCardMan.TabIndex = 7
        Me.lblCardMan.Text = "Card Selection"
        Me.lblCardMan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmLauncher
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.InitialDLauncher.My.Resources.Resources.launcher_bg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(952, 538)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCardMan)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblDebug)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.lblSetting)
        Me.Controls.Add(Me.lblStart7)
        Me.Controls.Add(Me.lblStart6)
        Me.Controls.Add(Me.pbLogo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLauncher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Initial D Launcher"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents lblStart6 As Label
    Friend WithEvents lblStart7 As Label
    Friend WithEvents lblExit As Label
    Friend WithEvents lblSetting As Label
    Friend WithEvents lblDebug As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblCardMan As Label
End Class
