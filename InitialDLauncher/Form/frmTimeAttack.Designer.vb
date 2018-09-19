<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTimeAttack
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimeAttack))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.flPanel = New InitialDLauncher.MyFlowLayoutPanel()
        Me.NsControlButton3 = New InitialDLauncher.NSControlButton()
        Me.NsControlButton2 = New InitialDLauncher.NSControlButton()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.flPanel)
        Me.NsTheme1.Controls.Add(Me.NsControlButton3)
        Me.NsTheme1.Controls.Add(Me.NsControlButton2)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(938, 741)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 2
        Me.NsTheme1.Text = "Time Attack"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'flPanel
        '
        Me.flPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flPanel.BackColor = System.Drawing.Color.White
        Me.flPanel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flPanel.ForeColor = System.Drawing.Color.White
        Me.flPanel.Location = New System.Drawing.Point(12, 37)
        Me.flPanel.Name = "flPanel"
        Me.flPanel.Size = New System.Drawing.Size(914, 692)
        Me.flPanel.TabIndex = 82
        '
        'NsControlButton3
        '
        Me.NsControlButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton3.ControlButton = InitialDLauncher.NSControlButton.Button.Minimize
        Me.NsControlButton3.Location = New System.Drawing.Point(879, 3)
        Me.NsControlButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton3.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.Name = "NsControlButton3"
        Me.NsControlButton3.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.TabIndex = 63
        Me.NsControlButton3.Text = "NsControlButton3"
        '
        'NsControlButton2
        '
        Me.NsControlButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton2.ControlButton = InitialDLauncher.NSControlButton.Button.MaximizeRestore
        Me.NsControlButton2.Location = New System.Drawing.Point(897, 3)
        Me.NsControlButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton2.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.Name = "NsControlButton2"
        Me.NsControlButton2.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.TabIndex = 62
        Me.NsControlButton2.Text = "NsControlButton2"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(915, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 61
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'frmTimeAttack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 741)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTimeAttack"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Attack"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsControlButton3 As NSControlButton
    Friend WithEvents NsControlButton2 As NSControlButton
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents flPanel As MyFlowLayoutPanel
End Class
