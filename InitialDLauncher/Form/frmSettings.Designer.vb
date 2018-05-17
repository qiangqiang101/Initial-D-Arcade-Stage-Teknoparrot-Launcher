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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.cbFullScreen = New InitialDLauncher.NSCheckBox()
        Me.cbVideo = New InitialDLauncher.NSCheckBox()
        Me.cbPicodaemon = New InitialDLauncher.NSCheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt8 = New InitialDLauncher.NSTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPrefer = New InitialDLauncher.NSComboBox()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.cbMP = New InitialDLauncher.NSCheckBox()
        Me.txt6 = New InitialDLauncher.NSTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCountry = New InitialDLauncher.NSComboBox()
        Me.txt7 = New InitialDLauncher.NSTextBox()
        Me.txtPlayerName = New InitialDLauncher.NSTextBox()
        Me.btnSave = New InitialDLauncher.NSButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbTest = New InitialDLauncher.NSCheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbDebug = New InitialDLauncher.NSCheckBox()
        Me.cmbLang = New InitialDLauncher.NSComboBox()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.cbFullScreen)
        Me.NsTheme1.Controls.Add(Me.cbVideo)
        Me.NsTheme1.Controls.Add(Me.cbPicodaemon)
        Me.NsTheme1.Controls.Add(Me.Label4)
        Me.NsTheme1.Controls.Add(Me.txt8)
        Me.NsTheme1.Controls.Add(Me.Label3)
        Me.NsTheme1.Controls.Add(Me.cmbPrefer)
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
        Me.NsTheme1.Size = New System.Drawing.Size(562, 341)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 61
        Me.NsTheme1.Text = "Settings"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'cbFullScreen
        '
        Me.cbFullScreen.Checked = False
        Me.cbFullScreen.Location = New System.Drawing.Point(351, 274)
        Me.cbFullScreen.Name = "cbFullScreen"
        Me.cbFullScreen.Size = New System.Drawing.Size(130, 24)
        Me.cbFullScreen.TabIndex = 14
        Me.cbFullScreen.Text = "Full Screen"
        '
        'cbVideo
        '
        Me.cbVideo.Checked = False
        Me.cbVideo.Location = New System.Drawing.Point(215, 274)
        Me.cbVideo.Name = "cbVideo"
        Me.cbVideo.Size = New System.Drawing.Size(130, 24)
        Me.cbVideo.TabIndex = 13
        Me.cbVideo.Text = "Video Background"
        '
        'cbPicodaemon
        '
        Me.cbPicodaemon.Checked = False
        Me.cbPicodaemon.Location = New System.Drawing.Point(79, 274)
        Me.cbPicodaemon.Name = "cbPicodaemon"
        Me.cbPicodaemon.Size = New System.Drawing.Size(130, 24)
        Me.cbPicodaemon.TabIndex = 12
        Me.cbPicodaemon.Text = "Run Card Reader"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Initial D 8 Path"
        '
        'txt8
        '
        Me.txt8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt8.Location = New System.Drawing.Point(137, 96)
        Me.txt8.MaxLength = 32767
        Me.txt8.Multiline = False
        Me.txt8.Name = "txt8"
        Me.txt8.ReadOnly = False
        Me.txt8.Size = New System.Drawing.Size(413, 24)
        Me.txt8.TabIndex = 3
        Me.txt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt8.UseSystemPasswordChar = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 217)
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
        Me.cmbPrefer.Location = New System.Drawing.Point(137, 214)
        Me.cmbPrefer.Name = "cmbPrefer"
        Me.cmbPrefer.Size = New System.Drawing.Size(170, 24)
        Me.cmbPrefer.TabIndex = 7
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
        'cbMP
        '
        Me.cbMP.Checked = False
        Me.cbMP.Location = New System.Drawing.Point(351, 244)
        Me.cbMP.Name = "cbMP"
        Me.cbMP.Size = New System.Drawing.Size(130, 24)
        Me.cbMP.TabIndex = 10
        Me.cbMP.Text = "Multiplayer"
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
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(9, 158)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 15)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "Country"
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
        'cmbCountry
        '
        Me.cmbCountry.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"Afghanistan", "Aland Islands", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua & Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia & Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Myanmar/Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominican Republic", "Dominica", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Great Britain", "Greece", "Grenada", "Guadeloupe", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard and Mcdonald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong, SAR China", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel and the Occupied Territories", "Italy", "Ivory Coast (Cote d'Ivoire)", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kosovo", "Kuwait", "Kyrgyz Republic (Kyrgyzstan)", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao, SAR China", "Republic of Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Korea, Democratic Republic of (North Korea)", "Norway", "Oman", "Pacific Islands", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint-Barthélemy", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint-Martin", "Saint Pierre and Miquelon", "Saint Vincent's & Grenadines", "Samoa", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovak Republic (Slovakia)", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "Korea, Republic of (South Korea)", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan, Republic of China", "Tajikistan", "Tanzania", "Thailand", "Timor Leste", "Togo", "Tokelau", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks & Caicos Islands", "Uganda", "Ukraine", "United Arab Emirates", "United States of America (USA)", "Uruguay", "US Minor Outlying Islands", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (UK)", "Virgin Islands (US)", "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"})
        Me.cmbCountry.Location = New System.Drawing.Point(137, 155)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(170, 24)
        Me.cmbCountry.TabIndex = 5
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
        'txtPlayerName
        '
        Me.txtPlayerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlayerName.Location = New System.Drawing.Point(137, 126)
        Me.txtPlayerName.MaxLength = 20
        Me.txtPlayerName.Multiline = False
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.ReadOnly = True
        Me.txtPlayerName.Size = New System.Drawing.Size(170, 24)
        Me.txtPlayerName.TabIndex = 4
        Me.txtPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPlayerName.UseSystemPasswordChar = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(475, 306)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(9, 129)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 15)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Player Name"
        '
        'cbTest
        '
        Me.cbTest.Checked = False
        Me.cbTest.Location = New System.Drawing.Point(79, 244)
        Me.cbTest.Name = "cbTest"
        Me.cbTest.Size = New System.Drawing.Size(130, 24)
        Me.cbTest.TabIndex = 8
        Me.cbTest.Text = "Test Menu"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(9, 187)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(111, 15)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Launcher Language"
        '
        'cbDebug
        '
        Me.cbDebug.Checked = False
        Me.cbDebug.Enabled = False
        Me.cbDebug.Location = New System.Drawing.Point(215, 244)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(130, 24)
        Me.cbDebug.TabIndex = 9
        Me.cbDebug.Text = "Debug Mode"
        '
        'cmbLang
        '
        Me.cmbLang.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbLang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbLang.FormattingEnabled = True
        Me.cmbLang.Location = New System.Drawing.Point(137, 184)
        Me.cmbLang.Name = "cmbLang"
        Me.cmbLang.Size = New System.Drawing.Size(170, 24)
        Me.cmbLang.TabIndex = 6
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 341)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTheme1.PerformLayout()
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
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbLang As NSComboBox
    Friend WithEvents txtPlayerName As NSTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbCountry As NSComboBox
    Friend WithEvents cbMP As NSCheckBox
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbPrefer As NSComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt8 As NSTextBox
    Friend WithEvents cbPicodaemon As NSCheckBox
    Friend WithEvents cbVideo As NSCheckBox
    Friend WithEvents cbFullScreen As NSCheckBox
End Class
