<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLeaderboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeaderboard))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.tcGames = New InitialDLauncher.NSTabControl()
        Me.tp6 = New System.Windows.Forms.TabPage()
        Me.btnReport6 = New InitialDLauncher.NSButton()
        Me.btnRefresh6 = New InitialDLauncher.NSButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCourse6 = New InitialDLauncher.NSComboBox()
        Me.lv6 = New System.Windows.Forms.ListView()
        Me.chNo6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCar6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTime6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDate6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbWeather6 = New InitialDLauncher.NSComboBox()
        Me.cmbType6 = New InitialDLauncher.NSComboBox()
        Me.tp7 = New System.Windows.Forms.TabPage()
        Me.btnReport7 = New InitialDLauncher.NSButton()
        Me.btnRefresh7 = New InitialDLauncher.NSButton()
        Me.lv7 = New System.Windows.Forms.ListView()
        Me.chNo7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCar7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTime7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDate7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCourse7 = New InitialDLauncher.NSComboBox()
        Me.cmbWeather7 = New InitialDLauncher.NSComboBox()
        Me.cmbType7 = New InitialDLauncher.NSComboBox()
        Me.tp8 = New System.Windows.Forms.TabPage()
        Me.btnReport8 = New InitialDLauncher.NSButton()
        Me.btnRefresh8 = New InitialDLauncher.NSButton()
        Me.lv8 = New System.Windows.Forms.ListView()
        Me.chNo8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCar8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTime8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDate8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCourse8 = New InitialDLauncher.NSComboBox()
        Me.cmbWeather8 = New InitialDLauncher.NSComboBox()
        Me.cmbType8 = New InitialDLauncher.NSComboBox()
        Me.NsControlButton3 = New InitialDLauncher.NSControlButton()
        Me.NsControlButton2 = New InitialDLauncher.NSControlButton()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.NsTheme1.SuspendLayout()
        Me.tcGames.SuspendLayout()
        Me.tp6.SuspendLayout()
        Me.tp7.SuspendLayout()
        Me.tp8.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.tcGames)
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
        Me.NsTheme1.Size = New System.Drawing.Size(991, 562)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 1
        Me.NsTheme1.Text = "Time Attack Leaderboard"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'tcGames
        '
        Me.tcGames.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tcGames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcGames.Controls.Add(Me.tp6)
        Me.tcGames.Controls.Add(Me.tp7)
        Me.tcGames.Controls.Add(Me.tp8)
        Me.tcGames.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcGames.ItemSize = New System.Drawing.Size(50, 130)
        Me.tcGames.Location = New System.Drawing.Point(12, 39)
        Me.tcGames.Multiline = True
        Me.tcGames.Name = "tcGames"
        Me.tcGames.SelectedIndex = 0
        Me.tcGames.Size = New System.Drawing.Size(967, 511)
        Me.tcGames.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcGames.TabIndex = 0
        '
        'tp6
        '
        Me.tp6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tp6.Controls.Add(Me.btnReport6)
        Me.tp6.Controls.Add(Me.btnRefresh6)
        Me.tp6.Controls.Add(Me.Label2)
        Me.tp6.Controls.Add(Me.Label1)
        Me.tp6.Controls.Add(Me.Label3)
        Me.tp6.Controls.Add(Me.cmbCourse6)
        Me.tp6.Controls.Add(Me.lv6)
        Me.tp6.Controls.Add(Me.cmbWeather6)
        Me.tp6.Controls.Add(Me.cmbType6)
        Me.tp6.Location = New System.Drawing.Point(134, 4)
        Me.tp6.Name = "tp6"
        Me.tp6.Padding = New System.Windows.Forms.Padding(3)
        Me.tp6.Size = New System.Drawing.Size(829, 503)
        Me.tp6.TabIndex = 0
        Me.tp6.Text = "Initial D 6 AA"
        '
        'btnReport6
        '
        Me.btnReport6.Enabled = False
        Me.btnReport6.Location = New System.Drawing.Point(696, 6)
        Me.btnReport6.Name = "btnReport6"
        Me.btnReport6.Size = New System.Drawing.Size(75, 24)
        Me.btnReport6.TabIndex = 5
        Me.btnReport6.Text = "Report"
        Me.btnReport6.Visible = False
        '
        'btnRefresh6
        '
        Me.btnRefresh6.Location = New System.Drawing.Point(615, 6)
        Me.btnRefresh6.Name = "btnRefresh6"
        Me.btnRefresh6.Size = New System.Drawing.Size(75, 24)
        Me.btnRefresh6.TabIndex = 4
        Me.btnRefresh6.Text = "Refresh"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(412, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Weather"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(209, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Course"
        '
        'cmbCourse6
        '
        Me.cmbCourse6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCourse6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCourse6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCourse6.FormattingEnabled = True
        Me.cmbCourse6.Location = New System.Drawing.Point(83, 6)
        Me.cmbCourse6.Name = "cmbCourse6"
        Me.cmbCourse6.Size = New System.Drawing.Size(120, 24)
        Me.cmbCourse6.TabIndex = 1
        '
        'lv6
        '
        Me.lv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv6.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNo6, Me.chName6, Me.chCar6, Me.chTime6, Me.chDate6})
        Me.lv6.FullRowSelect = True
        Me.lv6.GridLines = True
        Me.lv6.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv6.Location = New System.Drawing.Point(6, 35)
        Me.lv6.MultiSelect = False
        Me.lv6.Name = "lv6"
        Me.lv6.Size = New System.Drawing.Size(817, 462)
        Me.lv6.TabIndex = 0
        Me.lv6.UseCompatibleStateImageBehavior = False
        Me.lv6.View = System.Windows.Forms.View.Details
        '
        'chNo6
        '
        Me.chNo6.Text = "No."
        '
        'chName6
        '
        Me.chName6.Text = "Name"
        Me.chName6.Width = 150
        '
        'chCar6
        '
        Me.chCar6.Text = "Car"
        Me.chCar6.Width = 200
        '
        'chTime6
        '
        Me.chTime6.Text = "Time"
        Me.chTime6.Width = 100
        '
        'chDate6
        '
        Me.chDate6.Text = "Date"
        Me.chDate6.Width = 200
        '
        'cmbWeather6
        '
        Me.cmbWeather6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbWeather6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbWeather6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeather6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbWeather6.FormattingEnabled = True
        Me.cmbWeather6.Location = New System.Drawing.Point(489, 6)
        Me.cmbWeather6.Name = "cmbWeather6"
        Me.cmbWeather6.Size = New System.Drawing.Size(120, 24)
        Me.cmbWeather6.TabIndex = 3
        '
        'cmbType6
        '
        Me.cmbType6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbType6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbType6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbType6.FormattingEnabled = True
        Me.cmbType6.Location = New System.Drawing.Point(286, 6)
        Me.cmbType6.Name = "cmbType6"
        Me.cmbType6.Size = New System.Drawing.Size(120, 24)
        Me.cmbType6.TabIndex = 2
        '
        'tp7
        '
        Me.tp7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tp7.Controls.Add(Me.btnReport7)
        Me.tp7.Controls.Add(Me.btnRefresh7)
        Me.tp7.Controls.Add(Me.lv7)
        Me.tp7.Controls.Add(Me.Label4)
        Me.tp7.Controls.Add(Me.Label5)
        Me.tp7.Controls.Add(Me.Label6)
        Me.tp7.Controls.Add(Me.cmbCourse7)
        Me.tp7.Controls.Add(Me.cmbWeather7)
        Me.tp7.Controls.Add(Me.cmbType7)
        Me.tp7.Location = New System.Drawing.Point(134, 4)
        Me.tp7.Name = "tp7"
        Me.tp7.Padding = New System.Windows.Forms.Padding(3)
        Me.tp7.Size = New System.Drawing.Size(829, 503)
        Me.tp7.TabIndex = 1
        Me.tp7.Text = "Initial D 7 AAX"
        '
        'btnReport7
        '
        Me.btnReport7.Enabled = False
        Me.btnReport7.Location = New System.Drawing.Point(696, 6)
        Me.btnReport7.Name = "btnReport7"
        Me.btnReport7.Size = New System.Drawing.Size(75, 24)
        Me.btnReport7.TabIndex = 15
        Me.btnReport7.Text = "Report"
        Me.btnReport7.Visible = False
        '
        'btnRefresh7
        '
        Me.btnRefresh7.Location = New System.Drawing.Point(615, 6)
        Me.btnRefresh7.Name = "btnRefresh7"
        Me.btnRefresh7.Size = New System.Drawing.Size(75, 24)
        Me.btnRefresh7.TabIndex = 14
        Me.btnRefresh7.Text = "Refresh"
        '
        'lv7
        '
        Me.lv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv7.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNo7, Me.chName7, Me.chCar7, Me.chTime7, Me.chDate7})
        Me.lv7.FullRowSelect = True
        Me.lv7.GridLines = True
        Me.lv7.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv7.Location = New System.Drawing.Point(6, 35)
        Me.lv7.MultiSelect = False
        Me.lv7.Name = "lv7"
        Me.lv7.Size = New System.Drawing.Size(816, 462)
        Me.lv7.TabIndex = 16
        Me.lv7.UseCompatibleStateImageBehavior = False
        Me.lv7.View = System.Windows.Forms.View.Details
        '
        'chNo7
        '
        Me.chNo7.Text = "No."
        '
        'chName7
        '
        Me.chName7.Text = "Name"
        Me.chName7.Width = 150
        '
        'chCar7
        '
        Me.chCar7.Text = "Car"
        Me.chCar7.Width = 200
        '
        'chTime7
        '
        Me.chTime7.Text = "Time"
        Me.chTime7.Width = 100
        '
        'chDate7
        '
        Me.chDate7.Text = "Date"
        Me.chDate7.Width = 200
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(412, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Weather"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(209, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Course"
        '
        'cmbCourse7
        '
        Me.cmbCourse7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCourse7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCourse7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCourse7.FormattingEnabled = True
        Me.cmbCourse7.Location = New System.Drawing.Point(83, 6)
        Me.cmbCourse7.Name = "cmbCourse7"
        Me.cmbCourse7.Size = New System.Drawing.Size(120, 24)
        Me.cmbCourse7.TabIndex = 11
        '
        'cmbWeather7
        '
        Me.cmbWeather7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbWeather7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbWeather7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeather7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbWeather7.FormattingEnabled = True
        Me.cmbWeather7.Location = New System.Drawing.Point(489, 6)
        Me.cmbWeather7.Name = "cmbWeather7"
        Me.cmbWeather7.Size = New System.Drawing.Size(120, 24)
        Me.cmbWeather7.TabIndex = 13
        '
        'cmbType7
        '
        Me.cmbType7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbType7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbType7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbType7.FormattingEnabled = True
        Me.cmbType7.Location = New System.Drawing.Point(286, 6)
        Me.cmbType7.Name = "cmbType7"
        Me.cmbType7.Size = New System.Drawing.Size(120, 24)
        Me.cmbType7.TabIndex = 12
        '
        'tp8
        '
        Me.tp8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tp8.Controls.Add(Me.btnReport8)
        Me.tp8.Controls.Add(Me.btnRefresh8)
        Me.tp8.Controls.Add(Me.lv8)
        Me.tp8.Controls.Add(Me.Label7)
        Me.tp8.Controls.Add(Me.Label8)
        Me.tp8.Controls.Add(Me.Label9)
        Me.tp8.Controls.Add(Me.cmbCourse8)
        Me.tp8.Controls.Add(Me.cmbWeather8)
        Me.tp8.Controls.Add(Me.cmbType8)
        Me.tp8.Location = New System.Drawing.Point(134, 4)
        Me.tp8.Name = "tp8"
        Me.tp8.Padding = New System.Windows.Forms.Padding(3)
        Me.tp8.Size = New System.Drawing.Size(829, 503)
        Me.tp8.TabIndex = 2
        Me.tp8.Text = "Initial D 8 ∞"
        '
        'btnReport8
        '
        Me.btnReport8.Enabled = False
        Me.btnReport8.Location = New System.Drawing.Point(696, 6)
        Me.btnReport8.Name = "btnReport8"
        Me.btnReport8.Size = New System.Drawing.Size(75, 24)
        Me.btnReport8.TabIndex = 23
        Me.btnReport8.Text = "Report"
        Me.btnReport8.Visible = False
        '
        'btnRefresh8
        '
        Me.btnRefresh8.Location = New System.Drawing.Point(615, 6)
        Me.btnRefresh8.Name = "btnRefresh8"
        Me.btnRefresh8.Size = New System.Drawing.Size(75, 24)
        Me.btnRefresh8.TabIndex = 21
        Me.btnRefresh8.Text = "Refresh"
        '
        'lv8
        '
        Me.lv8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv8.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNo8, Me.chName8, Me.chCar8, Me.chTime8, Me.chDate8})
        Me.lv8.FullRowSelect = True
        Me.lv8.GridLines = True
        Me.lv8.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv8.Location = New System.Drawing.Point(6, 35)
        Me.lv8.MultiSelect = False
        Me.lv8.Name = "lv8"
        Me.lv8.Size = New System.Drawing.Size(816, 462)
        Me.lv8.TabIndex = 25
        Me.lv8.UseCompatibleStateImageBehavior = False
        Me.lv8.View = System.Windows.Forms.View.Details
        '
        'chNo8
        '
        Me.chNo8.Text = "No."
        '
        'chName8
        '
        Me.chName8.Text = "Name"
        Me.chName8.Width = 150
        '
        'chCar8
        '
        Me.chCar8.Text = "Car"
        Me.chCar8.Width = 200
        '
        'chTime8
        '
        Me.chTime8.Text = "Time"
        Me.chTime8.Width = 100
        '
        'chDate8
        '
        Me.chDate8.Text = "Date"
        Me.chDate8.Width = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(412, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Weather"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(209, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Type"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Course"
        '
        'cmbCourse8
        '
        Me.cmbCourse8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCourse8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCourse8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCourse8.FormattingEnabled = True
        Me.cmbCourse8.Location = New System.Drawing.Point(83, 6)
        Me.cmbCourse8.Name = "cmbCourse8"
        Me.cmbCourse8.Size = New System.Drawing.Size(120, 24)
        Me.cmbCourse8.TabIndex = 17
        '
        'cmbWeather8
        '
        Me.cmbWeather8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbWeather8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbWeather8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeather8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbWeather8.FormattingEnabled = True
        Me.cmbWeather8.Location = New System.Drawing.Point(489, 6)
        Me.cmbWeather8.Name = "cmbWeather8"
        Me.cmbWeather8.Size = New System.Drawing.Size(120, 24)
        Me.cmbWeather8.TabIndex = 20
        '
        'cmbType8
        '
        Me.cmbType8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbType8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbType8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbType8.FormattingEnabled = True
        Me.cmbType8.Location = New System.Drawing.Point(286, 6)
        Me.cmbType8.Name = "cmbType8"
        Me.cmbType8.Size = New System.Drawing.Size(120, 24)
        Me.cmbType8.TabIndex = 18
        '
        'NsControlButton3
        '
        Me.NsControlButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton3.ControlButton = InitialDLauncher.NSControlButton.Button.Minimize
        Me.NsControlButton3.Location = New System.Drawing.Point(932, 3)
        Me.NsControlButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton3.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.Name = "NsControlButton3"
        Me.NsControlButton3.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.TabIndex = 60
        Me.NsControlButton3.Text = "NsControlButton3"
        '
        'NsControlButton2
        '
        Me.NsControlButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton2.ControlButton = InitialDLauncher.NSControlButton.Button.MaximizeRestore
        Me.NsControlButton2.Location = New System.Drawing.Point(950, 3)
        Me.NsControlButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton2.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.Name = "NsControlButton2"
        Me.NsControlButton2.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.TabIndex = 59
        Me.NsControlButton2.Text = "NsControlButton2"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(968, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 58
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'frmLeaderboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 562)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeaderboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Attack Leaderboard"
        Me.NsTheme1.ResumeLayout(False)
        Me.tcGames.ResumeLayout(False)
        Me.tp6.ResumeLayout(False)
        Me.tp6.PerformLayout()
        Me.tp7.ResumeLayout(False)
        Me.tp7.PerformLayout()
        Me.tp8.ResumeLayout(False)
        Me.tp8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcGames As NSTabControl
    Friend WithEvents tp6 As TabPage
    Friend WithEvents tp7 As TabPage
    Friend WithEvents lv6 As ListView
    Friend WithEvents chNo6 As ColumnHeader
    Friend WithEvents chName6 As ColumnHeader
    Friend WithEvents chCar6 As ColumnHeader
    Friend WithEvents chTime6 As ColumnHeader
    Friend WithEvents cmbWeather6 As NSComboBox
    Friend WithEvents cmbType6 As NSComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCourse6 As NSComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lv7 As ListView
    Friend WithEvents chNo7 As ColumnHeader
    Friend WithEvents chName7 As ColumnHeader
    Friend WithEvents chCar7 As ColumnHeader
    Friend WithEvents chTime7 As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCourse7 As NSComboBox
    Friend WithEvents cmbWeather7 As NSComboBox
    Friend WithEvents cmbType7 As NSComboBox
    Friend WithEvents btnRefresh6 As NSButton
    Friend WithEvents btnRefresh7 As NSButton
    Friend WithEvents btnReport6 As NSButton
    Friend WithEvents btnReport7 As NSButton
    Friend WithEvents chDate6 As ColumnHeader
    Friend WithEvents chDate7 As ColumnHeader
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsControlButton3 As NSControlButton
    Friend WithEvents NsControlButton2 As NSControlButton
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents tp8 As TabPage
    Friend WithEvents btnReport8 As NSButton
    Friend WithEvents btnRefresh8 As NSButton
    Friend WithEvents lv8 As ListView
    Friend WithEvents chNo8 As ColumnHeader
    Friend WithEvents chName8 As ColumnHeader
    Friend WithEvents chCar8 As ColumnHeader
    Friend WithEvents chTime8 As ColumnHeader
    Friend WithEvents chDate8 As ColumnHeader
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbCourse8 As NSComboBox
    Friend WithEvents cmbWeather8 As NSComboBox
    Friend WithEvents cmbType8 As NSComboBox
End Class
