<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt6 = New InitialDLauncher.NSTextBox()
        Me.txt7 = New InitialDLauncher.NSTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New InitialDLauncher.NSButton()
        Me.cbTest = New InitialDLauncher.NSCheckBox()
        Me.cbDebug = New InitialDLauncher.NSCheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmbSeat6 = New InitialDLauncher.NSComboBox()
        Me.cmbSeat7 = New InitialDLauncher.NSComboBox()
        Me.cbSaveSeat = New InitialDLauncher.NSCheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbLang = New InitialDLauncher.NSComboBox()
        Me.txtPlayerName = New InitialDLauncher.NSTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbCountry = New InitialDLauncher.NSComboBox()
        Me.cbMP = New InitialDLauncher.NSCheckBox()
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.GroupBox1 = New InitialDLauncher.NSGroupBox()
        Me.gb7 = New InitialDLauncher.NSGroupBox()
        Me.gb6 = New InitialDLauncher.NSGroupBox()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPrefer = New InitialDLauncher.NSComboBox()
        Me.NsTheme1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gb7.SuspendLayout()
        Me.gb6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Initial D 6AA Path"
        '
        'txt6
        '
        Me.txt6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt6.Location = New System.Drawing.Point(137, 37)
        Me.txt6.MaxLength = 32767
        Me.txt6.Multiline = False
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = False
        Me.txt6.Size = New System.Drawing.Size(413, 24)
        Me.txt6.TabIndex = 1
        Me.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt6.UseSystemPasswordChar = False
        '
        'txt7
        '
        Me.txt7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt7.Location = New System.Drawing.Point(137, 66)
        Me.txt7.MaxLength = 32767
        Me.txt7.Multiline = False
        Me.txt7.Name = "txt7"
        Me.txt7.ReadOnly = False
        Me.txt7.Size = New System.Drawing.Size(413, 24)
        Me.txt7.TabIndex = 2
        Me.txt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt7.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Initial D 7AAX Path"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(475, 387)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        '
        'cbTest
        '
        Me.cbTest.Checked = False
        Me.cbTest.Location = New System.Drawing.Point(137, 213)
        Me.cbTest.Name = "cbTest"
        Me.cbTest.Size = New System.Drawing.Size(84, 24)
        Me.cbTest.TabIndex = 7
        Me.cbTest.Text = "Test Menu"
        '
        'cbDebug
        '
        Me.cbDebug.Checked = False
        Me.cbDebug.Enabled = False
        Me.cbDebug.Location = New System.Drawing.Point(225, 213)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(97, 24)
        Me.cbDebug.TabIndex = 8
        Me.cbDebug.Text = "Debug Mode"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'cmbSeat6
        '
        Me.cmbSeat6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSeat6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSeat6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeat6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSeat6.FormattingEnabled = True
        Me.cmbSeat6.Items.AddRange(New Object() {"Single", "A1", "A2", "B1", "B2", "C1", "C2", "D1", "D2", "Unknown"})
        Me.cmbSeat6.Location = New System.Drawing.Point(6, 36)
        Me.cmbSeat6.Name = "cmbSeat6"
        Me.cmbSeat6.Size = New System.Drawing.Size(225, 24)
        Me.cmbSeat6.TabIndex = 10
        '
        'cmbSeat7
        '
        Me.cmbSeat7.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSeat7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSeat7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeat7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSeat7.FormattingEnabled = True
        Me.cmbSeat7.Items.AddRange(New Object() {"Single", "A1", "A2", "B1", "B2", "C1", "C2", "D1", "D2", "Unknown"})
        Me.cmbSeat7.Location = New System.Drawing.Point(6, 36)
        Me.cmbSeat7.Name = "cmbSeat7"
        Me.cmbSeat7.Size = New System.Drawing.Size(225, 24)
        Me.cmbSeat7.TabIndex = 11
        Me.cmbSeat7.Visible = False
        '
        'cbSaveSeat
        '
        Me.cbSaveSeat.Checked = False
        Me.cbSaveSeat.Location = New System.Drawing.Point(6, 29)
        Me.cbSaveSeat.Name = "cbSaveSeat"
        Me.cbSaveSeat.Size = New System.Drawing.Size(133, 24)
        Me.cbSaveSeat.TabIndex = 9
        Me.cbSaveSeat.Text = "Save Cabinet Seat"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(9, 156)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(111, 15)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Launcher Language"
        '
        'cmbLang
        '
        Me.cmbLang.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbLang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbLang.FormattingEnabled = True
        Me.cmbLang.Items.AddRange(New Object() {"English", "Chinese", "French"})
        Me.cmbLang.Location = New System.Drawing.Point(137, 153)
        Me.cmbLang.Name = "cmbLang"
        Me.cmbLang.Size = New System.Drawing.Size(170, 24)
        Me.cmbLang.TabIndex = 5
        '
        'txtPlayerName
        '
        Me.txtPlayerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlayerName.Location = New System.Drawing.Point(137, 95)
        Me.txtPlayerName.MaxLength = 20
        Me.txtPlayerName.Multiline = False
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.ReadOnly = True
        Me.txtPlayerName.Size = New System.Drawing.Size(170, 24)
        Me.txtPlayerName.TabIndex = 3
        Me.txtPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPlayerName.UseSystemPasswordChar = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(9, 98)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 15)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Player Name"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(9, 127)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 15)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "Country"
        '
        'cmbCountry
        '
        Me.cmbCountry.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"Afghanistan", "Aland Islands", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua & Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia & Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Myanmar/Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominican Republic", "Dominica", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Great Britain", "Greece", "Grenada", "Guadeloupe", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard and Mcdonald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong, SAR China", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel and the Occupied Territories", "Italy", "Ivory Coast (Cote d'Ivoire)", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kosovo", "Kuwait", "Kyrgyz Republic (Kyrgyzstan)", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao, SAR China", "Republic of Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Korea, Democratic Republic of (North Korea)", "Norway", "Oman", "Pacific Islands", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint-Barthélemy", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint-Martin", "Saint Pierre and Miquelon", "Saint Vincent's & Grenadines", "Samoa", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovak Republic (Slovakia)", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "Korea, Republic of (South Korea)", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan, Republic of China", "Tajikistan", "Tanzania", "Thailand", "Timor Leste", "Togo", "Tokelau", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks & Caicos Islands", "Uganda", "Ukraine", "United Arab Emirates", "United States of America (USA)", "Uruguay", "US Minor Outlying Islands", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (UK)", "Virgin Islands (US)", "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"})
        Me.cmbCountry.Location = New System.Drawing.Point(137, 124)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(170, 24)
        Me.cmbCountry.TabIndex = 4
        '
        'cbMP
        '
        Me.cbMP.Checked = False
        Me.cbMP.Location = New System.Drawing.Point(326, 213)
        Me.cbMP.Name = "cbMP"
        Me.cbMP.Size = New System.Drawing.Size(88, 24)
        Me.cbMP.TabIndex = 9
        Me.cbMP.Text = "Multiplayer"
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.Label3)
        Me.NsTheme1.Controls.Add(Me.cmbPrefer)
        Me.NsTheme1.Controls.Add(Me.GroupBox1)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.cbMP)
        Me.NsTheme1.Controls.Add(Me.txt6)
        Me.NsTheme1.Controls.Add(Me.Label1)
        Me.NsTheme1.Controls.Add(Me.Label23)
        Me.NsTheme1.Controls.Add(Me.Label2)
        Me.NsTheme1.Controls.Add(Me.cmbCountry)
        Me.NsTheme1.Controls.Add(Me.txt7)
        Me.NsTheme1.Controls.Add(Me.txtPlayerName)
        Me.NsTheme1.Controls.Add(Me.btnSave)
        Me.NsTheme1.Controls.Add(Me.Label22)
        Me.NsTheme1.Controls.Add(Me.cbTest)
        Me.NsTheme1.Controls.Add(Me.Label21)
        Me.NsTheme1.Controls.Add(Me.cbDebug)
        Me.NsTheme1.Controls.Add(Me.cmbLang)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(562, 422)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 61
        Me.NsTheme1.Text = "Settings"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gb7)
        Me.GroupBox1.Controls.Add(Me.cbSaveSeat)
        Me.GroupBox1.Controls.Add(Me.gb6)
        Me.GroupBox1.DrawSeperator = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 243)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(495, 137)
        Me.GroupBox1.SubTitle = ""
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.Text = "NsGroupBox2"
        Me.GroupBox1.Title = "Cabinet Seat"
        '
        'gb7
        '
        Me.gb7.Controls.Add(Me.cmbSeat7)
        Me.gb7.DrawSeperator = False
        Me.gb7.Location = New System.Drawing.Point(249, 59)
        Me.gb7.Name = "gb7"
        Me.gb7.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.gb7.Size = New System.Drawing.Size(237, 69)
        Me.gb7.SubTitle = ""
        Me.gb7.TabIndex = 68
        Me.gb7.Text = "NsGroupBox2"
        Me.gb7.Title = "InitialD 7AAX Cabinet Seat (BETA)"
        Me.gb7.Visible = False
        '
        'gb6
        '
        Me.gb6.Controls.Add(Me.cmbSeat6)
        Me.gb6.DrawSeperator = False
        Me.gb6.Location = New System.Drawing.Point(6, 59)
        Me.gb6.Name = "gb6"
        Me.gb6.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.gb6.Size = New System.Drawing.Size(237, 69)
        Me.gb6.SubTitle = ""
        Me.gb6.TabIndex = 67
        Me.gb6.Text = "NsGroupBox1"
        Me.gb6.Title = "InitiaD 6AA Cabinet Seat (BETA)"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(539, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 66
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Prefer"
        '
        'cmbPrefer
        '
        Me.cmbPrefer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbPrefer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPrefer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrefer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbPrefer.FormattingEnabled = True
        Me.cmbPrefer.Items.AddRange(New Object() {"CRD", "BIN"})
        Me.cmbPrefer.Location = New System.Drawing.Point(137, 183)
        Me.cmbPrefer.Name = "cmbPrefer"
        Me.cmbPrefer.Size = New System.Drawing.Size(170, 24)
        Me.cmbPrefer.TabIndex = 6
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 422)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTheme1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gb7.ResumeLayout(False)
        Me.gb6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt6 As NSTextBox
    Friend WithEvents txt7 As NSTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As NSButton
    Friend WithEvents cbTest As NSCheckBox
    Friend WithEvents cbDebug As NSCheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmbSeat6 As NSComboBox
    Friend WithEvents cmbSeat7 As NSComboBox
    Friend WithEvents cbSaveSeat As NSCheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbLang As NSComboBox
    Friend WithEvents txtPlayerName As NSTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbCountry As NSComboBox
    Friend WithEvents cbMP As NSCheckBox
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents gb6 As NSGroupBox
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents gb7 As NSGroupBox
    Friend WithEvents GroupBox1 As NSGroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbPrefer As NSComboBox
End Class
