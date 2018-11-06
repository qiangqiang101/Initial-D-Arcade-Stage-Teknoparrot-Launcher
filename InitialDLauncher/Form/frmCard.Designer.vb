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
        Me.txt5 = New InitialDLauncher.NSTextBox()
        Me.txt4e = New InitialDLauncher.NSTextBox()
        Me.txt4 = New InitialDLauncher.NSTextBox()
        Me.txt8 = New InitialDLauncher.NSTextBox()
        Me.txt7 = New InitialDLauncher.NSTextBox()
        Me.txt6 = New InitialDLauncher.NSTextBox()
        Me.NsControlButton3 = New InitialDLauncher.NSControlButton()
        Me.NsControlButton2 = New InitialDLauncher.NSControlButton()
        Me.nstcTab = New InitialDLauncher.NSTabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.flp4 = New InitialDLauncher.MyFlowLayoutPanel()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.flp4e = New InitialDLauncher.MyFlowLayoutPanel()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.flp5 = New InitialDLauncher.MyFlowLayoutPanel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.flp6 = New InitialDLauncher.MyFlowLayoutPanel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.flp7 = New InitialDLauncher.MyFlowLayoutPanel()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.flp8 = New InitialDLauncher.MyFlowLayoutPanel()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.NsTheme1.SuspendLayout()
        Me.nstcTab.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
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
        Me.NsTheme1.Controls.Add(Me.txt5)
        Me.NsTheme1.Controls.Add(Me.txt4e)
        Me.NsTheme1.Controls.Add(Me.txt4)
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
        Me.NsTheme1.Size = New System.Drawing.Size(968, 664)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 55
        Me.NsTheme1.Text = "Card Management"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'txt5
        '
        Me.txt5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt5.Location = New System.Drawing.Point(646, 600)
        Me.txt5.MaxLength = 32767
        Me.txt5.Multiline = False
        Me.txt5.Name = "txt5"
        Me.txt5.ReadOnly = True
        Me.txt5.Size = New System.Drawing.Size(311, 23)
        Me.txt5.TabIndex = 63
        Me.txt5.Text = "ID5 Card:"
        Me.txt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt5.ToolTip = Nothing
        Me.txt5.UseSystemPasswordChar = False
        '
        'txt4e
        '
        Me.txt4e.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt4e.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt4e.Location = New System.Drawing.Point(329, 600)
        Me.txt4e.MaxLength = 32767
        Me.txt4e.Multiline = False
        Me.txt4e.Name = "txt4e"
        Me.txt4e.ReadOnly = True
        Me.txt4e.Size = New System.Drawing.Size(311, 23)
        Me.txt4e.TabIndex = 62
        Me.txt4e.Text = "ID4E Card:"
        Me.txt4e.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt4e.ToolTip = Nothing
        Me.txt4e.UseSystemPasswordChar = False
        '
        'txt4
        '
        Me.txt4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt4.Location = New System.Drawing.Point(12, 600)
        Me.txt4.MaxLength = 32767
        Me.txt4.Multiline = False
        Me.txt4.Name = "txt4"
        Me.txt4.ReadOnly = True
        Me.txt4.Size = New System.Drawing.Size(311, 23)
        Me.txt4.TabIndex = 61
        Me.txt4.Text = "ID4 Card:"
        Me.txt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt4.ToolTip = Nothing
        Me.txt4.UseSystemPasswordChar = False
        '
        'txt8
        '
        Me.txt8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt8.Location = New System.Drawing.Point(646, 629)
        Me.txt8.MaxLength = 32767
        Me.txt8.Multiline = False
        Me.txt8.Name = "txt8"
        Me.txt8.ReadOnly = True
        Me.txt8.Size = New System.Drawing.Size(311, 23)
        Me.txt8.TabIndex = 60
        Me.txt8.Text = "ID8 Card:"
        Me.txt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt8.ToolTip = Nothing
        Me.txt8.UseSystemPasswordChar = False
        '
        'txt7
        '
        Me.txt7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt7.Location = New System.Drawing.Point(329, 629)
        Me.txt7.MaxLength = 32767
        Me.txt7.Multiline = False
        Me.txt7.Name = "txt7"
        Me.txt7.ReadOnly = True
        Me.txt7.Size = New System.Drawing.Size(311, 23)
        Me.txt7.TabIndex = 59
        Me.txt7.Text = "ID7 Card:"
        Me.txt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt7.ToolTip = Nothing
        Me.txt7.UseSystemPasswordChar = False
        '
        'txt6
        '
        Me.txt6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt6.Location = New System.Drawing.Point(12, 629)
        Me.txt6.MaxLength = 32767
        Me.txt6.Multiline = False
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = True
        Me.txt6.Size = New System.Drawing.Size(311, 23)
        Me.txt6.TabIndex = 58
        Me.txt6.Text = "ID6 Card:"
        Me.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt6.ToolTip = Nothing
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
        Me.nstcTab.Controls.Add(Me.TabPage2)
        Me.nstcTab.Controls.Add(Me.TabPage5)
        Me.nstcTab.Controls.Add(Me.TabPage6)
        Me.nstcTab.Controls.Add(Me.TabPage3)
        Me.nstcTab.Controls.Add(Me.TabPage4)
        Me.nstcTab.Controls.Add(Me.TabPage1)
        Me.nstcTab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.nstcTab.ItemSize = New System.Drawing.Size(50, 130)
        Me.nstcTab.Location = New System.Drawing.Point(12, 36)
        Me.nstcTab.Multiline = True
        Me.nstcTab.Name = "nstcTab"
        Me.nstcTab.SelectedIndex = 0
        Me.nstcTab.Size = New System.Drawing.Size(945, 558)
        Me.nstcTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.nstcTab.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.flp4)
        Me.TabPage2.Location = New System.Drawing.Point(134, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(807, 550)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "InitialD 4 Cards"
        '
        'flp4
        '
        Me.flp4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.flp4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flp4.ForeColor = System.Drawing.Color.White
        Me.flp4.Location = New System.Drawing.Point(3, 3)
        Me.flp4.Name = "flp4"
        Me.flp4.Size = New System.Drawing.Size(801, 544)
        Me.flp4.TabIndex = 1
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.flp4e)
        Me.TabPage5.Location = New System.Drawing.Point(134, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(807, 550)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "InitialD 4 Export Cards"
        '
        'flp4e
        '
        Me.flp4e.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.flp4e.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp4e.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flp4e.ForeColor = System.Drawing.Color.White
        Me.flp4e.Location = New System.Drawing.Point(3, 3)
        Me.flp4e.Name = "flp4e"
        Me.flp4e.Size = New System.Drawing.Size(801, 544)
        Me.flp4e.TabIndex = 1
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.flp5)
        Me.TabPage6.Location = New System.Drawing.Point(134, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(807, 550)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "InitialD 5 Cards"
        '
        'flp5
        '
        Me.flp5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.flp5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flp5.ForeColor = System.Drawing.Color.White
        Me.flp5.Location = New System.Drawing.Point(3, 3)
        Me.flp5.Name = "flp5"
        Me.flp5.Size = New System.Drawing.Size(801, 544)
        Me.flp5.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.flp6)
        Me.TabPage3.Location = New System.Drawing.Point(134, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(807, 550)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "InitialD 6AA Cards"
        '
        'flp6
        '
        Me.flp6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.flp6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flp6.ForeColor = System.Drawing.Color.White
        Me.flp6.Location = New System.Drawing.Point(3, 3)
        Me.flp6.Name = "flp6"
        Me.flp6.Size = New System.Drawing.Size(801, 544)
        Me.flp6.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.flp7)
        Me.TabPage4.Location = New System.Drawing.Point(134, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(807, 550)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "InitialD 7AAX Cards"
        '
        'flp7
        '
        Me.flp7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.flp7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flp7.ForeColor = System.Drawing.Color.White
        Me.flp7.Location = New System.Drawing.Point(3, 3)
        Me.flp7.Name = "flp7"
        Me.flp7.Size = New System.Drawing.Size(801, 544)
        Me.flp7.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.flp8)
        Me.TabPage1.Location = New System.Drawing.Point(134, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(807, 550)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "InitialD 8 Infinity Cards"
        '
        'flp8
        '
        Me.flp8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.flp8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flp8.ForeColor = System.Drawing.Color.White
        Me.flp8.Location = New System.Drawing.Point(3, 3)
        Me.flp8.Name = "flp8"
        Me.flp8.Size = New System.Drawing.Size(801, 544)
        Me.flp8.TabIndex = 1
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
        'frmCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 664)
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
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents flp6 As MyFlowLayoutPanel
    Friend WithEvents flp7 As MyFlowLayoutPanel
    Friend WithEvents flp8 As MyFlowLayoutPanel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents flp4 As MyFlowLayoutPanel
    Friend WithEvents flp4e As MyFlowLayoutPanel
    Friend WithEvents flp5 As MyFlowLayoutPanel
    Friend WithEvents txt5 As NSTextBox
    Friend WithEvents txt4e As NSTextBox
    Friend WithEvents txt4 As NSTextBox
End Class
