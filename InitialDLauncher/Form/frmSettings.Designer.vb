<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
        Dim NsListViewColumnHeader1 As InitialDLauncher.NSListView.NSListViewColumnHeader = New InitialDLauncher.NSListView.NSListViewColumnHeader()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.NsTabControl1 = New InitialDLauncher.NSTabControl()
        Me.tpLauncher = New System.Windows.Forms.TabPage()
        Me.cbDebug = New InitialDLauncher.NSCheckBox()
        Me.NsGroupBox1 = New InitialDLauncher.NSGroupBox()
        Me.btnRemove = New InitialDLauncher.NSButton()
        Me.btnAdd = New InitialDLauncher.NSButton()
        Me.lvELO = New InitialDLauncher.NSListView()
        Me.NsSeperator2 = New InitialDLauncher.NSSeperator()
        Me.txtPlayerName = New InitialDLauncher.NSTextBox()
        Me.cmbLang = New InitialDLauncher.NSComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbFullScreen = New InitialDLauncher.NSCheckBox()
        Me.cbTest = New InitialDLauncher.NSCheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbPicodaemon = New InitialDLauncher.NSCheckBox()
        Me.cmbCountry = New InitialDLauncher.NSComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbMP = New InitialDLauncher.NSCheckBox()
        Me.tpId6 = New System.Windows.Forms.TabPage()
        Me.flp6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NsSeperator3 = New InitialDLauncher.NSSeperator()
        Me.btnBrowse6 = New InitialDLauncher.NSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt6 = New InitialDLauncher.NSTextBox()
        Me.tpId7 = New System.Windows.Forms.TabPage()
        Me.flp7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NsSeperator4 = New InitialDLauncher.NSSeperator()
        Me.btnBrowse7 = New InitialDLauncher.NSButton()
        Me.txt7 = New InitialDLauncher.NSTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpId8 = New System.Windows.Forms.TabPage()
        Me.flp8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NsSeperator5 = New InitialDLauncher.NSSeperator()
        Me.btnBrowse8 = New InitialDLauncher.NSButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt8 = New InitialDLauncher.NSTextBox()
        Me.tpTPEmu = New System.Windows.Forms.TabPage()
        Me.NsGroupBox5 = New InitialDLauncher.NSGroupBox()
        Me.btnRefreshHaptic = New InitialDLauncher.NSButton()
        Me.txtConstant = New InitialDLauncher.NSTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFriction = New InitialDLauncher.NSTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSpring = New InitialDLauncher.NSTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSine = New InitialDLauncher.NSTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbHapticDevice = New InitialDLauncher.NSComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbUseFFB = New InitialDLauncher.NSCheckBox()
        Me.cbThrustmaster = New InitialDLauncher.NSCheckBox()
        Me.NsGroupBox4 = New InitialDLauncher.NSGroupBox()
        Me.cbReverseAxisBrake = New InitialDLauncher.NSCheckBox()
        Me.cbReverseAxisGas = New InitialDLauncher.NSCheckBox()
        Me.cbFullAxisBrake = New InitialDLauncher.NSCheckBox()
        Me.cbFullAxisGas = New InitialDLauncher.NSCheckBox()
        Me.cmbJoyInterface = New InitialDLauncher.NSComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NsGroupBox2 = New InitialDLauncher.NSGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSto0zPercent = New System.Windows.Forms.Label()
        Me.tbSto0z = New InitialDLauncher.NSTrackBar()
        Me.cbSto0z = New InitialDLauncher.NSCheckBox()
        Me.NsSeperator1 = New InitialDLauncher.NSSeperator()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.btnSave = New InitialDLauncher.NSButton()
        Me.NsTheme1.SuspendLayout()
        Me.NsTabControl1.SuspendLayout()
        Me.tpLauncher.SuspendLayout()
        Me.NsGroupBox1.SuspendLayout()
        Me.tpId6.SuspendLayout()
        Me.tpId7.SuspendLayout()
        Me.tpId8.SuspendLayout()
        Me.tpTPEmu.SuspendLayout()
        Me.NsGroupBox5.SuspendLayout()
        Me.NsGroupBox4.SuspendLayout()
        Me.NsGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsTabControl1)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.btnSave)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(711, 451)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 61
        Me.NsTheme1.Text = "Settings"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsTabControl1
        '
        Me.NsTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.NsTabControl1.Controls.Add(Me.tpLauncher)
        Me.NsTabControl1.Controls.Add(Me.tpId6)
        Me.NsTabControl1.Controls.Add(Me.tpId7)
        Me.NsTabControl1.Controls.Add(Me.tpId8)
        Me.NsTabControl1.Controls.Add(Me.tpTPEmu)
        Me.NsTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.NsTabControl1.ItemSize = New System.Drawing.Size(50, 110)
        Me.NsTabControl1.Location = New System.Drawing.Point(12, 38)
        Me.NsTabControl1.Multiline = True
        Me.NsTabControl1.Name = "NsTabControl1"
        Me.NsTabControl1.SelectedIndex = 0
        Me.NsTabControl1.Size = New System.Drawing.Size(687, 372)
        Me.NsTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.NsTabControl1.TabIndex = 79
        '
        'tpLauncher
        '
        Me.tpLauncher.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tpLauncher.Controls.Add(Me.cbDebug)
        Me.tpLauncher.Controls.Add(Me.NsGroupBox1)
        Me.tpLauncher.Controls.Add(Me.NsSeperator2)
        Me.tpLauncher.Controls.Add(Me.txtPlayerName)
        Me.tpLauncher.Controls.Add(Me.cmbLang)
        Me.tpLauncher.Controls.Add(Me.Label21)
        Me.tpLauncher.Controls.Add(Me.cbFullScreen)
        Me.tpLauncher.Controls.Add(Me.cbTest)
        Me.tpLauncher.Controls.Add(Me.Label22)
        Me.tpLauncher.Controls.Add(Me.cbPicodaemon)
        Me.tpLauncher.Controls.Add(Me.cmbCountry)
        Me.tpLauncher.Controls.Add(Me.Label23)
        Me.tpLauncher.Controls.Add(Me.cbMP)
        Me.tpLauncher.Location = New System.Drawing.Point(114, 4)
        Me.tpLauncher.Name = "tpLauncher"
        Me.tpLauncher.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLauncher.Size = New System.Drawing.Size(569, 364)
        Me.tpLauncher.TabIndex = 0
        Me.tpLauncher.Text = "This Launcher Settings"
        '
        'cbDebug
        '
        Me.cbDebug.Checked = False
        Me.cbDebug.Location = New System.Drawing.Point(434, 8)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(130, 24)
        Me.cbDebug.TabIndex = 12
        Me.cbDebug.Text = "Debug Mode"
        '
        'NsGroupBox1
        '
        Me.NsGroupBox1.Controls.Add(Me.btnRemove)
        Me.NsGroupBox1.Controls.Add(Me.btnAdd)
        Me.NsGroupBox1.Controls.Add(Me.lvELO)
        Me.NsGroupBox1.DrawSeperator = True
        Me.NsGroupBox1.Location = New System.Drawing.Point(12, 114)
        Me.NsGroupBox1.Name = "NsGroupBox1"
        Me.NsGroupBox1.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox1.Size = New System.Drawing.Size(552, 239)
        Me.NsGroupBox1.SubTitle = ""
        Me.NsGroupBox1.TabIndex = 77
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = "Extra Launch Options"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(522, 66)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(24, 24)
        Me.btnRemove.TabIndex = 19
        Me.btnRemove.Text = "-"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(522, 36)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(24, 24)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "+"
        '
        'lvELO
        '
        Me.lvELO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NsListViewColumnHeader1.Text = "Programs"
        NsListViewColumnHeader1.Width = 500
        Me.lvELO.Columns = New InitialDLauncher.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1}
        Me.lvELO.Items = New InitialDLauncher.NSListView.NSListViewItem(-1) {}
        Me.lvELO.Location = New System.Drawing.Point(6, 36)
        Me.lvELO.MultiSelect = True
        Me.lvELO.Name = "lvELO"
        Me.lvELO.Size = New System.Drawing.Size(510, 197)
        Me.lvELO.TabIndex = 17
        Me.lvELO.Text = "NsListView1"
        '
        'NsSeperator2
        '
        Me.NsSeperator2.Location = New System.Drawing.Point(12, 98)
        Me.NsSeperator2.Name = "NsSeperator2"
        Me.NsSeperator2.Size = New System.Drawing.Size(552, 23)
        Me.NsSeperator2.TabIndex = 78
        Me.NsSeperator2.Text = "NsSeperator2"
        '
        'txtPlayerName
        '
        Me.txtPlayerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlayerName.Location = New System.Drawing.Point(137, 6)
        Me.txtPlayerName.MaxLength = 20
        Me.txtPlayerName.Multiline = False
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.ReadOnly = True
        Me.txtPlayerName.Size = New System.Drawing.Size(155, 24)
        Me.txtPlayerName.TabIndex = 7
        Me.txtPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPlayerName.ToolTip = Nothing
        Me.txtPlayerName.UseSystemPasswordChar = False
        '
        'cmbLang
        '
        Me.cmbLang.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbLang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbLang.FormattingEnabled = True
        Me.cmbLang.Location = New System.Drawing.Point(137, 64)
        Me.cmbLang.Name = "cmbLang"
        Me.cmbLang.Size = New System.Drawing.Size(155, 24)
        Me.cmbLang.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(9, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(111, 15)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Launcher Language"
        '
        'cbFullScreen
        '
        Me.cbFullScreen.Checked = False
        Me.cbFullScreen.Location = New System.Drawing.Point(434, 38)
        Me.cbFullScreen.Name = "cbFullScreen"
        Me.cbFullScreen.Size = New System.Drawing.Size(130, 24)
        Me.cbFullScreen.TabIndex = 16
        Me.cbFullScreen.Text = "Full Screen"
        '
        'cbTest
        '
        Me.cbTest.Checked = False
        Me.cbTest.Location = New System.Drawing.Point(298, 8)
        Me.cbTest.Name = "cbTest"
        Me.cbTest.Size = New System.Drawing.Size(130, 24)
        Me.cbTest.TabIndex = 11
        Me.cbTest.Text = "Test Menu"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(9, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 15)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Player Name"
        '
        'cbPicodaemon
        '
        Me.cbPicodaemon.Checked = False
        Me.cbPicodaemon.Location = New System.Drawing.Point(298, 38)
        Me.cbPicodaemon.Name = "cbPicodaemon"
        Me.cbPicodaemon.Size = New System.Drawing.Size(130, 24)
        Me.cbPicodaemon.TabIndex = 13
        Me.cbPicodaemon.Text = "Run Card Reader"
        '
        'cmbCountry
        '
        Me.cmbCountry.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"Afghanistan", "Aland Islands", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua & Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia & Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Myanmar/Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominican Republic", "Dominica", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Great Britain", "Greece", "Grenada", "Guadeloupe", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard and Mcdonald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong, SAR China", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel and the Occupied Territories", "Italy", "Ivory Coast (Cote d'Ivoire)", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kosovo", "Kuwait", "Kyrgyz Republic (Kyrgyzstan)", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao, SAR China", "Republic of Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Korea, Democratic Republic of (North Korea)", "Norway", "Oman", "Pacific Islands", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint-Barthélemy", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint-Martin", "Saint Pierre and Miquelon", "Saint Vincent's & Grenadines", "Samoa", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovak Republic (Slovakia)", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "Korea, Republic of (South Korea)", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan, Republic of China", "Tajikistan", "Tanzania", "Thailand", "Timor Leste", "Togo", "Tokelau", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks & Caicos Islands", "Uganda", "Ukraine", "United Arab Emirates", "United States of America (USA)", "Uruguay", "US Minor Outlying Islands", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (UK)", "Virgin Islands (US)", "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"})
        Me.cmbCountry.Location = New System.Drawing.Point(137, 35)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(155, 24)
        Me.cmbCountry.TabIndex = 8
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(9, 38)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 15)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "Country"
        '
        'cbMP
        '
        Me.cbMP.Checked = False
        Me.cbMP.Location = New System.Drawing.Point(298, 68)
        Me.cbMP.Name = "cbMP"
        Me.cbMP.Size = New System.Drawing.Size(130, 24)
        Me.cbMP.TabIndex = 15
        Me.cbMP.Text = "Multiplayer"
        '
        'tpId6
        '
        Me.tpId6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tpId6.Controls.Add(Me.flp6)
        Me.tpId6.Controls.Add(Me.NsSeperator3)
        Me.tpId6.Controls.Add(Me.btnBrowse6)
        Me.tpId6.Controls.Add(Me.Label1)
        Me.tpId6.Controls.Add(Me.txt6)
        Me.tpId6.Location = New System.Drawing.Point(114, 4)
        Me.tpId6.Name = "tpId6"
        Me.tpId6.Padding = New System.Windows.Forms.Padding(3)
        Me.tpId6.Size = New System.Drawing.Size(569, 364)
        Me.tpId6.TabIndex = 1
        Me.tpId6.Text = "InitialD 6AA Settings"
        '
        'flp6
        '
        Me.flp6.AutoScroll = True
        Me.flp6.Location = New System.Drawing.Point(6, 54)
        Me.flp6.Name = "flp6"
        Me.flp6.Size = New System.Drawing.Size(558, 304)
        Me.flp6.TabIndex = 75
        '
        'NsSeperator3
        '
        Me.NsSeperator3.Location = New System.Drawing.Point(6, 36)
        Me.NsSeperator3.Name = "NsSeperator3"
        Me.NsSeperator3.Size = New System.Drawing.Size(558, 23)
        Me.NsSeperator3.TabIndex = 74
        Me.NsSeperator3.Text = "NsSeperator3"
        '
        'btnBrowse6
        '
        Me.btnBrowse6.Location = New System.Drawing.Point(537, 6)
        Me.btnBrowse6.Name = "btnBrowse6"
        Me.btnBrowse6.Size = New System.Drawing.Size(27, 24)
        Me.btnBrowse6.TabIndex = 2
        Me.btnBrowse6.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Initial D 6AA Path"
        '
        'txt6
        '
        Me.txt6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt6.Location = New System.Drawing.Point(137, 6)
        Me.txt6.MaxLength = 32767
        Me.txt6.Multiline = False
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = True
        Me.txt6.Size = New System.Drawing.Size(394, 24)
        Me.txt6.TabIndex = 1
        Me.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt6.ToolTip = Nothing
        Me.txt6.UseSystemPasswordChar = False
        '
        'tpId7
        '
        Me.tpId7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tpId7.Controls.Add(Me.flp7)
        Me.tpId7.Controls.Add(Me.NsSeperator4)
        Me.tpId7.Controls.Add(Me.btnBrowse7)
        Me.tpId7.Controls.Add(Me.txt7)
        Me.tpId7.Controls.Add(Me.Label2)
        Me.tpId7.Location = New System.Drawing.Point(114, 4)
        Me.tpId7.Name = "tpId7"
        Me.tpId7.Padding = New System.Windows.Forms.Padding(3)
        Me.tpId7.Size = New System.Drawing.Size(569, 364)
        Me.tpId7.TabIndex = 2
        Me.tpId7.Text = "InitialD 7AAX Settings"
        '
        'flp7
        '
        Me.flp7.AutoScroll = True
        Me.flp7.Location = New System.Drawing.Point(6, 54)
        Me.flp7.Name = "flp7"
        Me.flp7.Size = New System.Drawing.Size(558, 304)
        Me.flp7.TabIndex = 75
        '
        'NsSeperator4
        '
        Me.NsSeperator4.Location = New System.Drawing.Point(6, 36)
        Me.NsSeperator4.Name = "NsSeperator4"
        Me.NsSeperator4.Size = New System.Drawing.Size(558, 23)
        Me.NsSeperator4.TabIndex = 76
        Me.NsSeperator4.Text = "NsSeperator4"
        '
        'btnBrowse7
        '
        Me.btnBrowse7.Location = New System.Drawing.Point(537, 6)
        Me.btnBrowse7.Name = "btnBrowse7"
        Me.btnBrowse7.Size = New System.Drawing.Size(27, 24)
        Me.btnBrowse7.TabIndex = 4
        Me.btnBrowse7.Text = "..."
        '
        'txt7
        '
        Me.txt7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt7.Location = New System.Drawing.Point(137, 6)
        Me.txt7.MaxLength = 32767
        Me.txt7.Multiline = False
        Me.txt7.Name = "txt7"
        Me.txt7.ReadOnly = True
        Me.txt7.Size = New System.Drawing.Size(394, 24)
        Me.txt7.TabIndex = 3
        Me.txt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt7.ToolTip = Nothing
        Me.txt7.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Initial D 7AAX Path"
        '
        'tpId8
        '
        Me.tpId8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tpId8.Controls.Add(Me.flp8)
        Me.tpId8.Controls.Add(Me.NsSeperator5)
        Me.tpId8.Controls.Add(Me.btnBrowse8)
        Me.tpId8.Controls.Add(Me.Label4)
        Me.tpId8.Controls.Add(Me.txt8)
        Me.tpId8.Location = New System.Drawing.Point(114, 4)
        Me.tpId8.Name = "tpId8"
        Me.tpId8.Padding = New System.Windows.Forms.Padding(3)
        Me.tpId8.Size = New System.Drawing.Size(569, 364)
        Me.tpId8.TabIndex = 3
        Me.tpId8.Text = "Initial D8 ∞ Settings"
        '
        'flp8
        '
        Me.flp8.AutoScroll = True
        Me.flp8.Location = New System.Drawing.Point(6, 54)
        Me.flp8.Name = "flp8"
        Me.flp8.Size = New System.Drawing.Size(558, 304)
        Me.flp8.TabIndex = 75
        '
        'NsSeperator5
        '
        Me.NsSeperator5.Location = New System.Drawing.Point(6, 36)
        Me.NsSeperator5.Name = "NsSeperator5"
        Me.NsSeperator5.Size = New System.Drawing.Size(558, 23)
        Me.NsSeperator5.TabIndex = 78
        Me.NsSeperator5.Text = "NsSeperator5"
        '
        'btnBrowse8
        '
        Me.btnBrowse8.Location = New System.Drawing.Point(537, 6)
        Me.btnBrowse8.Name = "btnBrowse8"
        Me.btnBrowse8.Size = New System.Drawing.Size(27, 24)
        Me.btnBrowse8.TabIndex = 6
        Me.btnBrowse8.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Initial D 8 Path"
        '
        'txt8
        '
        Me.txt8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt8.Location = New System.Drawing.Point(137, 6)
        Me.txt8.MaxLength = 32767
        Me.txt8.Multiline = False
        Me.txt8.Name = "txt8"
        Me.txt8.ReadOnly = True
        Me.txt8.Size = New System.Drawing.Size(394, 24)
        Me.txt8.TabIndex = 5
        Me.txt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt8.ToolTip = Nothing
        Me.txt8.UseSystemPasswordChar = False
        '
        'tpTPEmu
        '
        Me.tpTPEmu.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tpTPEmu.Controls.Add(Me.NsGroupBox5)
        Me.tpTPEmu.Controls.Add(Me.NsGroupBox4)
        Me.tpTPEmu.Controls.Add(Me.cmbJoyInterface)
        Me.tpTPEmu.Controls.Add(Me.Label5)
        Me.tpTPEmu.Controls.Add(Me.NsGroupBox2)
        Me.tpTPEmu.Controls.Add(Me.NsSeperator1)
        Me.tpTPEmu.Location = New System.Drawing.Point(114, 4)
        Me.tpTPEmu.Name = "tpTPEmu"
        Me.tpTPEmu.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTPEmu.Size = New System.Drawing.Size(569, 364)
        Me.tpTPEmu.TabIndex = 4
        Me.tpTPEmu.Text = "TP Emulation Settings"
        '
        'NsGroupBox5
        '
        Me.NsGroupBox5.Controls.Add(Me.btnRefreshHaptic)
        Me.NsGroupBox5.Controls.Add(Me.txtConstant)
        Me.NsGroupBox5.Controls.Add(Me.Label13)
        Me.NsGroupBox5.Controls.Add(Me.txtFriction)
        Me.NsGroupBox5.Controls.Add(Me.Label12)
        Me.NsGroupBox5.Controls.Add(Me.txtSpring)
        Me.NsGroupBox5.Controls.Add(Me.Label11)
        Me.NsGroupBox5.Controls.Add(Me.txtSine)
        Me.NsGroupBox5.Controls.Add(Me.Label10)
        Me.NsGroupBox5.Controls.Add(Me.cmbHapticDevice)
        Me.NsGroupBox5.Controls.Add(Me.Label9)
        Me.NsGroupBox5.Controls.Add(Me.cbUseFFB)
        Me.NsGroupBox5.Controls.Add(Me.cbThrustmaster)
        Me.NsGroupBox5.DrawSeperator = True
        Me.NsGroupBox5.Location = New System.Drawing.Point(6, 165)
        Me.NsGroupBox5.Name = "NsGroupBox5"
        Me.NsGroupBox5.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox5.Size = New System.Drawing.Size(558, 159)
        Me.NsGroupBox5.SubTitle = ""
        Me.NsGroupBox5.TabIndex = 84
        Me.NsGroupBox5.Text = "NsGroupBox5"
        Me.NsGroupBox5.Title = "Force Feedback"
        '
        'btnRefreshHaptic
        '
        Me.btnRefreshHaptic.Location = New System.Drawing.Point(401, 36)
        Me.btnRefreshHaptic.Name = "btnRefreshHaptic"
        Me.btnRefreshHaptic.Size = New System.Drawing.Size(151, 24)
        Me.btnRefreshHaptic.TabIndex = 93
        Me.btnRefreshHaptic.Text = "Refresh Haptic Devices"
        '
        'txtConstant
        '
        Me.txtConstant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConstant.Location = New System.Drawing.Point(397, 126)
        Me.txtConstant.MaxLength = 4
        Me.txtConstant.Multiline = False
        Me.txtConstant.Name = "txtConstant"
        Me.txtConstant.ReadOnly = False
        Me.txtConstant.Size = New System.Drawing.Size(155, 24)
        Me.txtConstant.TabIndex = 91
        Me.txtConstant.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtConstant.ToolTip = Nothing
        Me.txtConstant.UseSystemPasswordChar = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(288, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 15)
        Me.Label13.TabIndex = 92
        Me.Label13.Text = "Constant Base"
        '
        'txtFriction
        '
        Me.txtFriction.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFriction.Location = New System.Drawing.Point(397, 96)
        Me.txtFriction.MaxLength = 4
        Me.txtFriction.Multiline = False
        Me.txtFriction.Name = "txtFriction"
        Me.txtFriction.ReadOnly = False
        Me.txtFriction.Size = New System.Drawing.Size(155, 24)
        Me.txtFriction.TabIndex = 89
        Me.txtFriction.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFriction.ToolTip = Nothing
        Me.txtFriction.UseSystemPasswordChar = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(288, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 15)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Friction Base"
        '
        'txtSpring
        '
        Me.txtSpring.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSpring.Location = New System.Drawing.Point(115, 126)
        Me.txtSpring.MaxLength = 4
        Me.txtSpring.Multiline = False
        Me.txtSpring.Name = "txtSpring"
        Me.txtSpring.ReadOnly = False
        Me.txtSpring.Size = New System.Drawing.Size(155, 24)
        Me.txtSpring.TabIndex = 87
        Me.txtSpring.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSpring.ToolTip = Nothing
        Me.txtSpring.UseSystemPasswordChar = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "Spring Base"
        '
        'txtSine
        '
        Me.txtSine.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSine.Location = New System.Drawing.Point(115, 96)
        Me.txtSine.MaxLength = 4
        Me.txtSine.Multiline = False
        Me.txtSine.Name = "txtSine"
        Me.txtSine.ReadOnly = False
        Me.txtSine.Size = New System.Drawing.Size(155, 24)
        Me.txtSine.TabIndex = 85
        Me.txtSine.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSine.ToolTip = Nothing
        Me.txtSine.UseSystemPasswordChar = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Sine Base"
        '
        'cmbHapticDevice
        '
        Me.cmbHapticDevice.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbHapticDevice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbHapticDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHapticDevice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbHapticDevice.FormattingEnabled = True
        Me.cmbHapticDevice.Location = New System.Drawing.Point(115, 66)
        Me.cmbHapticDevice.Name = "cmbHapticDevice"
        Me.cmbHapticDevice.Size = New System.Drawing.Size(437, 24)
        Me.cmbHapticDevice.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Haptic Device"
        '
        'cbUseFFB
        '
        Me.cbUseFFB.Checked = False
        Me.cbUseFFB.Location = New System.Drawing.Point(6, 36)
        Me.cbUseFFB.Name = "cbUseFFB"
        Me.cbUseFFB.Size = New System.Drawing.Size(188, 24)
        Me.cbUseFFB.TabIndex = 13
        Me.cbUseFFB.Text = "Use Force Feedback"
        '
        'cbThrustmaster
        '
        Me.cbThrustmaster.Checked = False
        Me.cbThrustmaster.Location = New System.Drawing.Point(200, 36)
        Me.cbThrustmaster.Name = "cbThrustmaster"
        Me.cbThrustmaster.Size = New System.Drawing.Size(188, 24)
        Me.cbThrustmaster.TabIndex = 14
        Me.cbThrustmaster.Text = "Thrustmaster Fix"
        '
        'NsGroupBox4
        '
        Me.NsGroupBox4.Controls.Add(Me.cbReverseAxisBrake)
        Me.NsGroupBox4.Controls.Add(Me.cbReverseAxisGas)
        Me.NsGroupBox4.Controls.Add(Me.cbFullAxisBrake)
        Me.NsGroupBox4.Controls.Add(Me.cbFullAxisGas)
        Me.NsGroupBox4.DrawSeperator = True
        Me.NsGroupBox4.Location = New System.Drawing.Point(288, 51)
        Me.NsGroupBox4.Name = "NsGroupBox4"
        Me.NsGroupBox4.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox4.Size = New System.Drawing.Size(276, 108)
        Me.NsGroupBox4.SubTitle = ""
        Me.NsGroupBox4.TabIndex = 83
        Me.NsGroupBox4.Text = "NsGroupBox4"
        Me.NsGroupBox4.Title = "Direct Input Wheel"
        '
        'cbReverseAxisBrake
        '
        Me.cbReverseAxisBrake.Checked = False
        Me.cbReverseAxisBrake.Location = New System.Drawing.Point(138, 66)
        Me.cbReverseAxisBrake.Name = "cbReverseAxisBrake"
        Me.cbReverseAxisBrake.Size = New System.Drawing.Size(126, 24)
        Me.cbReverseAxisBrake.TabIndex = 16
        Me.cbReverseAxisBrake.Text = "Reverse Axis Brake"
        '
        'cbReverseAxisGas
        '
        Me.cbReverseAxisGas.Checked = False
        Me.cbReverseAxisGas.Location = New System.Drawing.Point(138, 36)
        Me.cbReverseAxisGas.Name = "cbReverseAxisGas"
        Me.cbReverseAxisGas.Size = New System.Drawing.Size(126, 24)
        Me.cbReverseAxisGas.TabIndex = 15
        Me.cbReverseAxisGas.Text = "Reverse Axis Gas"
        '
        'cbFullAxisBrake
        '
        Me.cbFullAxisBrake.Checked = False
        Me.cbFullAxisBrake.Location = New System.Drawing.Point(6, 66)
        Me.cbFullAxisBrake.Name = "cbFullAxisBrake"
        Me.cbFullAxisBrake.Size = New System.Drawing.Size(126, 24)
        Me.cbFullAxisBrake.TabIndex = 14
        Me.cbFullAxisBrake.Text = "Full Axis Brake"
        '
        'cbFullAxisGas
        '
        Me.cbFullAxisGas.Checked = False
        Me.cbFullAxisGas.Location = New System.Drawing.Point(6, 36)
        Me.cbFullAxisGas.Name = "cbFullAxisGas"
        Me.cbFullAxisGas.Size = New System.Drawing.Size(126, 24)
        Me.cbFullAxisGas.TabIndex = 13
        Me.cbFullAxisGas.Text = "Full Axis Gas"
        '
        'cmbJoyInterface
        '
        Me.cmbJoyInterface.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbJoyInterface.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJoyInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJoyInterface.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbJoyInterface.FormattingEnabled = True
        Me.cmbJoyInterface.Items.AddRange(New Object() {"Direct Input", "XInput"})
        Me.cmbJoyInterface.Location = New System.Drawing.Point(127, 6)
        Me.cmbJoyInterface.Name = "cmbJoyInterface"
        Me.cmbJoyInterface.Size = New System.Drawing.Size(155, 24)
        Me.cmbJoyInterface.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Joystick Interface"
        '
        'NsGroupBox2
        '
        Me.NsGroupBox2.Controls.Add(Me.Label6)
        Me.NsGroupBox2.Controls.Add(Me.lblSto0zPercent)
        Me.NsGroupBox2.Controls.Add(Me.tbSto0z)
        Me.NsGroupBox2.Controls.Add(Me.cbSto0z)
        Me.NsGroupBox2.DrawSeperator = True
        Me.NsGroupBox2.Location = New System.Drawing.Point(6, 51)
        Me.NsGroupBox2.Name = "NsGroupBox2"
        Me.NsGroupBox2.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox2.Size = New System.Drawing.Size(276, 108)
        Me.NsGroupBox2.SubTitle = ""
        Me.NsGroupBox2.TabIndex = 78
        Me.NsGroupBox2.Text = "NsGroupBox2"
        Me.NsGroupBox2.Title = "Sto0z Zone"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Sto0z Percentage"
        '
        'lblSto0zPercent
        '
        Me.lblSto0zPercent.AutoSize = True
        Me.lblSto0zPercent.ForeColor = System.Drawing.Color.White
        Me.lblSto0zPercent.Location = New System.Drawing.Point(235, 84)
        Me.lblSto0zPercent.Name = "lblSto0zPercent"
        Me.lblSto0zPercent.Size = New System.Drawing.Size(23, 15)
        Me.lblSto0zPercent.TabIndex = 57
        Me.lblSto0zPercent.Text = "0%"
        '
        'tbSto0z
        '
        Me.tbSto0z.Location = New System.Drawing.Point(6, 81)
        Me.tbSto0z.Maximum = 100
        Me.tbSto0z.Minimum = 0
        Me.tbSto0z.Name = "tbSto0z"
        Me.tbSto0z.Size = New System.Drawing.Size(223, 23)
        Me.tbSto0z.TabIndex = 14
        Me.tbSto0z.Text = "NsTrackBar1"
        Me.tbSto0z.Value = 0
        '
        'cbSto0z
        '
        Me.cbSto0z.Checked = False
        Me.cbSto0z.Location = New System.Drawing.Point(6, 36)
        Me.cbSto0z.Name = "cbSto0z"
        Me.cbSto0z.Size = New System.Drawing.Size(190, 24)
        Me.cbSto0z.TabIndex = 13
        Me.cbSto0z.Text = "Enable Sto0z Zone"
        '
        'NsSeperator1
        '
        Me.NsSeperator1.Location = New System.Drawing.Point(6, 36)
        Me.NsSeperator1.Name = "NsSeperator1"
        Me.NsSeperator1.Size = New System.Drawing.Size(558, 23)
        Me.NsSeperator1.TabIndex = 80
        Me.NsSeperator1.Text = "NsSeperator1"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(688, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 66
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(624, 416)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 451)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTabControl1.ResumeLayout(False)
        Me.tpLauncher.ResumeLayout(False)
        Me.tpLauncher.PerformLayout()
        Me.NsGroupBox1.ResumeLayout(False)
        Me.tpId6.ResumeLayout(False)
        Me.tpId6.PerformLayout()
        Me.tpId7.ResumeLayout(False)
        Me.tpId7.PerformLayout()
        Me.tpId8.ResumeLayout(False)
        Me.tpId8.PerformLayout()
        Me.tpTPEmu.ResumeLayout(False)
        Me.tpTPEmu.PerformLayout()
        Me.NsGroupBox5.ResumeLayout(False)
        Me.NsGroupBox5.PerformLayout()
        Me.NsGroupBox4.ResumeLayout(False)
        Me.NsGroupBox2.ResumeLayout(False)
        Me.NsGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt6 As NSTextBox
    Friend WithEvents txt7 As NSTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As NSButton
    Friend WithEvents cbTest As NSCheckBox
    Friend WithEvents cbDebug As NSCheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbLang As NSComboBox
    Friend WithEvents txtPlayerName As NSTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbCountry As NSComboBox
    Friend WithEvents cbMP As NSCheckBox
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents Label4 As Label
    Friend WithEvents txt8 As NSTextBox
    Friend WithEvents cbPicodaemon As NSCheckBox
    Friend WithEvents cbFullScreen As NSCheckBox
    Friend WithEvents NsGroupBox1 As NSGroupBox
    Friend WithEvents lvELO As NSListView
    Friend WithEvents btnBrowse8 As NSButton
    Friend WithEvents btnBrowse7 As NSButton
    Friend WithEvents btnBrowse6 As NSButton
    Friend WithEvents NsSeperator2 As NSSeperator
    Friend WithEvents btnRemove As NSButton
    Friend WithEvents btnAdd As NSButton
    Friend WithEvents NsTabControl1 As NSTabControl
    Friend WithEvents tpLauncher As TabPage
    Friend WithEvents tpId6 As TabPage
    Friend WithEvents tpId7 As TabPage
    Friend WithEvents tpId8 As TabPage
    Friend WithEvents tpTPEmu As TabPage
    Friend WithEvents NsSeperator3 As NSSeperator
    Friend WithEvents flp6 As FlowLayoutPanel
    Friend WithEvents flp7 As FlowLayoutPanel
    Friend WithEvents NsSeperator4 As NSSeperator
    Friend WithEvents flp8 As FlowLayoutPanel
    Friend WithEvents NsSeperator5 As NSSeperator
    Friend WithEvents NsGroupBox5 As NSGroupBox
    Friend WithEvents btnRefreshHaptic As NSButton
    Friend WithEvents txtConstant As NSTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFriction As NSTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSpring As NSTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSine As NSTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbHapticDevice As NSComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbUseFFB As NSCheckBox
    Friend WithEvents cbThrustmaster As NSCheckBox
    Friend WithEvents NsGroupBox4 As NSGroupBox
    Friend WithEvents cbReverseAxisBrake As NSCheckBox
    Friend WithEvents cbReverseAxisGas As NSCheckBox
    Friend WithEvents cbFullAxisBrake As NSCheckBox
    Friend WithEvents cbFullAxisGas As NSCheckBox
    Friend WithEvents cmbJoyInterface As NSComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents NsGroupBox2 As NSGroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSto0zPercent As Label
    Friend WithEvents tbSto0z As NSTrackBar
    Friend WithEvents cbSto0z As NSCheckBox
    Friend WithEvents NsSeperator1 As NSSeperator
End Class
