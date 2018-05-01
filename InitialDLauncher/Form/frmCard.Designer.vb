<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCard))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.txt7 = New InitialDLauncher.NSTextBox()
        Me.txt6 = New InitialDLauncher.NSTextBox()
        Me.NsControlButton3 = New InitialDLauncher.NSControlButton()
        Me.NsControlButton2 = New InitialDLauncher.NSControlButton()
        Me.nstcTab = New InitialDLauncher.NSTabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.flp6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.flp7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.flp8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txt8 = New InitialDLauncher.NSTextBox()
        Me.NsTheme1.SuspendLayout()
        Me.nstcTab.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.txt8)
        Me.NsTheme1.Controls.Add(Me.txt7)
        Me.NsTheme1.Controls.Add(Me.txt6)
        Me.NsTheme1.Controls.Add(Me.NsControlButton3)
        Me.NsTheme1.Controls.Add(Me.NsControlButton2)
        Me.NsTheme1.Controls.Add(Me.nstcTab)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.MinimumSize = New System.Drawing.Size(968, 648)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = True
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(968, 648)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 55
        Me.NsTheme1.Text = "Card Management"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'txt7
        '
        Me.txt7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt7.Location = New System.Drawing.Point(318, 613)
        Me.txt7.MaxLength = 32767
        Me.txt7.Multiline = False
        Me.txt7.Name = "txt7"
        Me.txt7.ReadOnly = True
        Me.txt7.Size = New System.Drawing.Size(300, 23)
        Me.txt7.TabIndex = 59
        Me.txt7.Text = "ID7 Card:"
        Me.txt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt7.UseSystemPasswordChar = False
        '
        'txt6
        '
        Me.txt6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt6.Location = New System.Drawing.Point(12, 613)
        Me.txt6.MaxLength = 32767
        Me.txt6.Multiline = False
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = True
        Me.txt6.Size = New System.Drawing.Size(300, 23)
        Me.txt6.TabIndex = 58
        Me.txt6.Text = "ID6 Card:"
        Me.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt6.UseSystemPasswordChar = False
        '
        'NsControlButton3
        '
        Me.NsControlButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton3.ControlButton = InitialDLauncher.NSControlButton.Button.Minimize
        Me.NsControlButton3.Location = New System.Drawing.Point(909, 3)
        Me.NsControlButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton3.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.Name = "NsControlButton3"
        Me.NsControlButton3.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.TabIndex = 57
        Me.NsControlButton3.Text = "NsControlButton3"
        '
        'NsControlButton2
        '
        Me.NsControlButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton2.ControlButton = InitialDLauncher.NSControlButton.Button.MaximizeRestore
        Me.NsControlButton2.Location = New System.Drawing.Point(927, 3)
        Me.NsControlButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton2.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.Name = "NsControlButton2"
        Me.NsControlButton2.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.TabIndex = 56
        Me.NsControlButton2.Text = "NsControlButton2"
        '
        'nstcTab
        '
        Me.nstcTab.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.nstcTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nstcTab.Controls.Add(Me.TabPage3)
        Me.nstcTab.Controls.Add(Me.TabPage4)
        Me.nstcTab.Controls.Add(Me.TabPage1)
        Me.nstcTab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.nstcTab.ItemSize = New System.Drawing.Size(50, 130)
        Me.nstcTab.Location = New System.Drawing.Point(12, 36)
        Me.nstcTab.Multiline = True
        Me.nstcTab.Name = "nstcTab"
        Me.nstcTab.SelectedIndex = 0
        Me.nstcTab.Size = New System.Drawing.Size(944, 571)
        Me.nstcTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.nstcTab.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.flp6)
        Me.TabPage3.Location = New System.Drawing.Point(134, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(806, 563)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "InitialD 6AA Cards"
        '
        'flp6
        '
        Me.flp6.AutoScroll = True
        Me.flp6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp6.Location = New System.Drawing.Point(3, 3)
        Me.flp6.Name = "flp6"
        Me.flp6.Size = New System.Drawing.Size(800, 557)
        Me.flp6.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.flp7)
        Me.TabPage4.Location = New System.Drawing.Point(134, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(806, 563)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "InitialD 7AAX Cards"
        '
        'flp7
        '
        Me.flp7.AutoScroll = True
        Me.flp7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp7.Location = New System.Drawing.Point(3, 3)
        Me.flp7.Name = "flp7"
        Me.flp7.Size = New System.Drawing.Size(800, 557)
        Me.flp7.TabIndex = 1
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(945, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 55
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.flp8)
        Me.TabPage1.Location = New System.Drawing.Point(134, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(806, 563)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "InitialD 8 Infinity Cards"
        '
        'flp8
        '
        Me.flp8.AutoScroll = True
        Me.flp8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp8.Location = New System.Drawing.Point(0, 0)
        Me.flp8.Name = "flp8"
        Me.flp8.Size = New System.Drawing.Size(806, 563)
        Me.flp8.TabIndex = 2
        '
        'txt8
        '
        Me.txt8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt8.Location = New System.Drawing.Point(624, 613)
        Me.txt8.MaxLength = 32767
        Me.txt8.Multiline = False
        Me.txt8.Name = "txt8"
        Me.txt8.ReadOnly = True
        Me.txt8.Size = New System.Drawing.Size(300, 23)
        Me.txt8.TabIndex = 60
        Me.txt8.Text = "ID8 Card:"
        Me.txt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt8.UseSystemPasswordChar = False
        '
        'frmCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 648)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(968, 648)
        Me.Name = "frmCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Card Management"
        Me.NsTheme1.ResumeLayout(False)
        Me.nstcTab.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flp6 As FlowLayoutPanel
    Friend WithEvents flp7 As FlowLayoutPanel
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents nstcTab As NSTabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents NsControlButton3 As NSControlButton
    Friend WithEvents NsControlButton2 As NSControlButton
    Friend WithEvents txt7 As NSTextBox
    Friend WithEvents txt6 As NSTextBox
    Friend WithEvents txt8 As NSTextBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents flp8 As FlowLayoutPanel
End Class
