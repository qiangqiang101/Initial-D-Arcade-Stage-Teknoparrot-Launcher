<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim NsListViewColumnHeader1 As InitialDLauncher.NSListView.NSListViewColumnHeader = New InitialDLauncher.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader2 As InitialDLauncher.NSListView.NSListViewColumnHeader = New InitialDLauncher.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader3 As InitialDLauncher.NSListView.NSListViewColumnHeader = New InitialDLauncher.NSListView.NSListViewColumnHeader()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.NsGroupBox1 = New InitialDLauncher.NSGroupBox()
        Me.lvPlugins = New InitialDLauncher.NSListView()
        Me.btnDonate = New InitialDLauncher.NSButton()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.wbAbout = New System.Windows.Forms.WebBrowser()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.llblWebsite = New System.Windows.Forms.LinkLabel()
        Me.NsTheme1.SuspendLayout()
        Me.NsGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsGroupBox1)
        Me.NsTheme1.Controls.Add(Me.btnDonate)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.wbAbout)
        Me.NsTheme1.Controls.Add(Me.lblTitle)
        Me.NsTheme1.Controls.Add(Me.lblVersion)
        Me.NsTheme1.Controls.Add(Me.llblWebsite)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(475, 692)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 54
        Me.NsTheme1.Text = "About"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsGroupBox1
        '
        Me.NsGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsGroupBox1.Controls.Add(Me.lvPlugins)
        Me.NsGroupBox1.DrawSeperator = True
        Me.NsGroupBox1.Location = New System.Drawing.Point(12, 530)
        Me.NsGroupBox1.Name = "NsGroupBox1"
        Me.NsGroupBox1.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox1.Size = New System.Drawing.Size(451, 150)
        Me.NsGroupBox1.SubTitle = ""
        Me.NsGroupBox1.TabIndex = 56
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = "Plugins"
        '
        'lvPlugins
        '
        Me.lvPlugins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NsListViewColumnHeader1.Text = "Plugin Name"
        NsListViewColumnHeader1.Width = 150
        NsListViewColumnHeader2.Text = "Version"
        NsListViewColumnHeader2.Width = 60
        NsListViewColumnHeader3.Text = "Author"
        NsListViewColumnHeader3.Width = 150
        Me.lvPlugins.Columns = New InitialDLauncher.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1, NsListViewColumnHeader2, NsListViewColumnHeader3}
        Me.lvPlugins.Items = New InitialDLauncher.NSListView.NSListViewItem(-1) {}
        Me.lvPlugins.Location = New System.Drawing.Point(6, 36)
        Me.lvPlugins.MultiSelect = True
        Me.lvPlugins.Name = "lvPlugins"
        Me.lvPlugins.Size = New System.Drawing.Size(439, 108)
        Me.lvPlugins.TabIndex = 10
        Me.lvPlugins.Text = "NsListView1"
        '
        'btnDonate
        '
        Me.btnDonate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnDonate.Location = New System.Drawing.Point(388, 36)
        Me.btnDonate.Name = "btnDonate"
        Me.btnDonate.Size = New System.Drawing.Size(75, 24)
        Me.btnDonate.TabIndex = 55
        Me.btnDonate.Text = "Donate"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(452, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 54
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'wbAbout
        '
        Me.wbAbout.Location = New System.Drawing.Point(12, 98)
        Me.wbAbout.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbAbout.Name = "wbAbout"
        Me.wbAbout.Size = New System.Drawing.Size(451, 426)
        Me.wbAbout.TabIndex = 53
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(12, 36)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(218, 19)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Initial D Arcade Stage Launcher"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(13, 55)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(79, 15)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version: Build"
        '
        'llblWebsite
        '
        Me.llblWebsite.AutoSize = True
        Me.llblWebsite.LinkColor = System.Drawing.Color.Aqua
        Me.llblWebsite.Location = New System.Drawing.Point(13, 70)
        Me.llblWebsite.Name = "llblWebsite"
        Me.llblWebsite.Size = New System.Drawing.Size(173, 15)
        Me.llblWebsite.TabIndex = 2
        Me.llblWebsite.TabStop = True
        Me.llblWebsite.Text = "https://www.imnotmental.com"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 692)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTheme1.PerformLayout()
        Me.NsGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents llblWebsite As LinkLabel
    Friend WithEvents wbAbout As WebBrowser
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents btnDonate As NSButton
    Friend WithEvents NsGroupBox1 As NSGroupBox
    Friend WithEvents lvPlugins As NSListView
End Class
