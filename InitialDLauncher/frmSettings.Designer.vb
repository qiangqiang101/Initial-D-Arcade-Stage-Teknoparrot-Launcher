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
        Me.txt6 = New System.Windows.Forms.TextBox()
        Me.txt7 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbTest = New System.Windows.Forms.CheckBox()
        Me.cbDebug = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gb6 = New System.Windows.Forms.GroupBox()
        Me.cmbSeat6 = New System.Windows.Forms.ComboBox()
        Me.gb7 = New System.Windows.Forms.GroupBox()
        Me.cmbSeat7 = New System.Windows.Forms.ComboBox()
        Me.cbSaveSeat = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbLang = New System.Windows.Forms.ComboBox()
        Me.txtPlayerName = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbCountry = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbMP = New System.Windows.Forms.CheckBox()
        Me.gb6.SuspendLayout()
        Me.gb7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Initial D 6AA Path"
        '
        'txt6
        '
        Me.txt6.Location = New System.Drawing.Point(137, 12)
        Me.txt6.Name = "txt6"
        Me.txt6.Size = New System.Drawing.Size(413, 23)
        Me.txt6.TabIndex = 1
        '
        'txt7
        '
        Me.txt7.Location = New System.Drawing.Point(137, 41)
        Me.txt7.Name = "txt7"
        Me.txt7.Size = New System.Drawing.Size(413, 23)
        Me.txt7.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Initial D 7AAX Path"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(475, 302)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 51
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbTest
        '
        Me.cbTest.AutoSize = True
        Me.cbTest.Location = New System.Drawing.Point(137, 157)
        Me.cbTest.Name = "cbTest"
        Me.cbTest.Size = New System.Drawing.Size(82, 19)
        Me.cbTest.TabIndex = 6
        Me.cbTest.Text = "Test Menu"
        Me.cbTest.UseVisualStyleBackColor = True
        '
        'cbDebug
        '
        Me.cbDebug.AutoSize = True
        Me.cbDebug.Enabled = False
        Me.cbDebug.Location = New System.Drawing.Point(225, 157)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(95, 19)
        Me.cbDebug.TabIndex = 7
        Me.cbDebug.Text = "Debug Mode"
        Me.cbDebug.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'gb6
        '
        Me.gb6.Controls.Add(Me.cmbSeat6)
        Me.gb6.Enabled = False
        Me.gb6.Location = New System.Drawing.Point(6, 47)
        Me.gb6.Name = "gb6"
        Me.gb6.Size = New System.Drawing.Size(207, 55)
        Me.gb6.TabIndex = 6
        Me.gb6.TabStop = False
        Me.gb6.Text = "Initial D 6AA Cabinet Seat (BETA)"
        '
        'cmbSeat6
        '
        Me.cmbSeat6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeat6.FormattingEnabled = True
        Me.cmbSeat6.Items.AddRange(New Object() {"Single", "A1", "A2", "B1", "B2", "C1", "C2", "D1", "D2", "Unknown"})
        Me.cmbSeat6.Location = New System.Drawing.Point(6, 22)
        Me.cmbSeat6.Name = "cmbSeat6"
        Me.cmbSeat6.Size = New System.Drawing.Size(195, 23)
        Me.cmbSeat6.TabIndex = 14
        '
        'gb7
        '
        Me.gb7.Controls.Add(Me.cmbSeat7)
        Me.gb7.Enabled = False
        Me.gb7.Location = New System.Drawing.Point(219, 47)
        Me.gb7.Name = "gb7"
        Me.gb7.Size = New System.Drawing.Size(207, 55)
        Me.gb7.TabIndex = 7
        Me.gb7.TabStop = False
        Me.gb7.Text = "Initial D 7AAX Cabinet Seat (BETA)"
        Me.gb7.Visible = False
        '
        'cmbSeat7
        '
        Me.cmbSeat7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeat7.FormattingEnabled = True
        Me.cmbSeat7.Items.AddRange(New Object() {"Single", "A1", "A2", "B1", "B2", "C1", "C2", "D1", "D2", "Unknown"})
        Me.cmbSeat7.Location = New System.Drawing.Point(6, 22)
        Me.cmbSeat7.Name = "cmbSeat7"
        Me.cmbSeat7.Size = New System.Drawing.Size(195, 23)
        Me.cmbSeat7.TabIndex = 34
        Me.cmbSeat7.Visible = False
        '
        'cbSaveSeat
        '
        Me.cbSaveSeat.AutoSize = True
        Me.cbSaveSeat.Location = New System.Drawing.Point(12, 22)
        Me.cbSaveSeat.Name = "cbSaveSeat"
        Me.cbSaveSeat.Size = New System.Drawing.Size(119, 19)
        Me.cbSaveSeat.TabIndex = 8
        Me.cbSaveSeat.Text = "Save Cabinet Seat"
        Me.cbSaveSeat.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 131)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(111, 15)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Launcher Language"
        '
        'cmbLang
        '
        Me.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLang.FormattingEnabled = True
        Me.cmbLang.Items.AddRange(New Object() {"English", "Chinese", "French"})
        Me.cmbLang.Location = New System.Drawing.Point(137, 128)
        Me.cmbLang.Name = "cmbLang"
        Me.cmbLang.Size = New System.Drawing.Size(170, 23)
        Me.cmbLang.TabIndex = 9
        '
        'txtPlayerName
        '
        Me.txtPlayerName.Location = New System.Drawing.Point(137, 70)
        Me.txtPlayerName.MaxLength = 20
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.ReadOnly = True
        Me.txtPlayerName.Size = New System.Drawing.Size(170, 23)
        Me.txtPlayerName.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 15)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Player Name"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 102)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 15)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "Country"
        '
        'cmbCountry
        '
        Me.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"Afghanistan", "Aland Islands", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua & Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia & Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Myanmar/Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominican Republic", "Dominica", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Great Britain", "Greece", "Grenada", "Guadeloupe", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard and Mcdonald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong, SAR China", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel and the Occupied Territories", "Italy", "Ivory Coast (Cote d'Ivoire)", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kosovo", "Kuwait", "Kyrgyz Republic (Kyrgyzstan)", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao, SAR China", "Republic of Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Korea, Democratic Republic of (North Korea)", "Norway", "Oman", "Pacific Islands", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint-Barthélemy", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint-Martin", "Saint Pierre and Miquelon", "Saint Vincent's & Grenadines", "Samoa", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovak Republic (Slovakia)", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "Korea, Republic of (South Korea)", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan, Republic of China", "Tajikistan", "Tanzania", "Thailand", "Timor Leste", "Togo", "Tokelau", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks & Caicos Islands", "Uganda", "Ukraine", "United Arab Emirates", "United States of America (USA)", "Uruguay", "US Minor Outlying Islands", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (UK)", "Virgin Islands (US)", "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"})
        Me.cmbCountry.Location = New System.Drawing.Point(137, 99)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(170, 23)
        Me.cmbCountry.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSaveSeat)
        Me.GroupBox1.Controls.Add(Me.gb6)
        Me.GroupBox1.Controls.Add(Me.gb7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 112)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cabinet Seat"
        '
        'cbMP
        '
        Me.cbMP.AutoSize = True
        Me.cbMP.Location = New System.Drawing.Point(326, 157)
        Me.cbMP.Name = "cbMP"
        Me.cbMP.Size = New System.Drawing.Size(86, 19)
        Me.cbMP.TabIndex = 60
        Me.cbMP.Text = "Multiplayer"
        Me.cbMP.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 337)
        Me.Controls.Add(Me.cbMP)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Me.txtPlayerName)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cmbLang)
        Me.Controls.Add(Me.cbDebug)
        Me.Controls.Add(Me.cbTest)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txt7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt6)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.gb6.ResumeLayout(False)
        Me.gb7.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt6 As TextBox
    Friend WithEvents txt7 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cbTest As CheckBox
    Friend WithEvents cbDebug As CheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents gb6 As GroupBox
    Friend WithEvents cmbSeat6 As ComboBox
    Friend WithEvents gb7 As GroupBox
    Friend WithEvents cmbSeat7 As ComboBox
    Friend WithEvents cbSaveSeat As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbLang As ComboBox
    Friend WithEvents txtPlayerName As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbCountry As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbMP As CheckBox
End Class
