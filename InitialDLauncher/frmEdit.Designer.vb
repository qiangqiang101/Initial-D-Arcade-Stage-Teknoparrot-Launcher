<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEdit))
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCar1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCar2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCar3 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLevel = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtChapLevel = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbLegend = New System.Windows.Forms.CheckBox()
        Me.cbCar1 = New System.Windows.Forms.CheckBox()
        Me.cbCar2 = New System.Windows.Forms.CheckBox()
        Me.cbCar3 = New System.Windows.Forms.CheckBox()
        Me.ttCar1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttCar2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttCar3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTPride = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSPride = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbAvatar = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtHair = New System.Windows.Forms.TextBox()
        Me.txtAcc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEyes2 = New System.Windows.Forms.TextBox()
        Me.txtMouth = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCoat = New System.Windows.Forms.TextBox()
        Me.txtEyes = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEyebrown = New System.Windows.Forms.TextBox()
        Me.txtTorso = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPridePoint = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(97, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(224, 23)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Name"
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(86, 22)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(111, 23)
        Me.cmbGender.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Gender"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Car 1"
        '
        'cmbCar1
        '
        Me.cmbCar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCar1.FormattingEnabled = True
        Me.cmbCar1.Items.AddRange(New Object() {"", "TRUENO GT-APEX (AE86)", "LEVIN GT-APEX (AE86)", "LEVIN SR (AE85)", "86 GT (ZN6)", "MR2 G-Limited (SW20)", "MR-S (ZZW30)", "ALTEZZA RS200 (SXE10)", "SUPRA RZ (JZA80)", "PRIUS (ZVW30)", "SKYLINE GT-R (BNR32)", "SKYLINE GT-R (BNR34)", "SILVIA K's (S13)", "Silvia Q's (S14)", "Silvia spec-R (S15)", "180SX TYPE II (RPS13)", "FAIRLADY Z (Z33)", "GT-R (R35)", "Civic SiR・II (EG6)", "CIVIC TYPE R (EK9)", "INTEGRA TYPE R (DC2)", "S2000 (AP1)", "NSX (NA1)", "RX-7 ∞III (FC3S)", "RX-7 Type R (FD3S)", "RX-7 Type RS (FD3S)", "RX-8 Type S (SE3P)", "ROADSTER (NA6CE)", "ROADSTER RS (NB8C)", "IMPREZA STi Ver.V (GC8)", "IMPREZA STi (GDBA)", "IMPREZA STI (GDBF)", "LANCER Evolution III (CE9A)", "LANCER EVOLUTION IV (CN9A)", "LANCER Evolution VII (CT9A)", "LANCER Evolution IX (CT9A)", "LANCER EVOLUTION X (CZ4A)", "Cappuccino (EA11R)", "SILEIGHTY", "TRUENO 2door GT-APEX (AE86)", "G-FORCE SUPRA (JZA80-kai)", "MONSTER CIVIC R (EK9)", "NSX-R GT (NA2)", "RE Amemiya Genki-7 (FD3S)", "S2000 GT1 (AP1)", "ROADSTER C-SPEC (NA8C Kai)"})
        Me.cmbCar1.Location = New System.Drawing.Point(86, 51)
        Me.cmbCar1.Name = "cmbCar1"
        Me.cmbCar1.Size = New System.Drawing.Size(224, 23)
        Me.cmbCar1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Car 2"
        '
        'cmbCar2
        '
        Me.cmbCar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCar2.FormattingEnabled = True
        Me.cmbCar2.Items.AddRange(New Object() {"", "TRUENO GT-APEX (AE86)", "LEVIN GT-APEX (AE86)", "LEVIN SR (AE85)", "86 GT (ZN6)", "MR2 G-Limited (SW20)", "MR-S (ZZW30)", "ALTEZZA RS200 (SXE10)", "SUPRA RZ (JZA80)", "PRIUS (ZVW30)", "SKYLINE GT-R (BNR32)", "SKYLINE GT-R (BNR34)", "SILVIA K's (S13)", "Silvia Q's (S14)", "Silvia spec-R (S15)", "180SX TYPE II (RPS13)", "FAIRLADY Z (Z33)", "GT-R (R35)", "Civic SiR・II (EG6)", "CIVIC TYPE R (EK9)", "INTEGRA TYPE R (DC2)", "S2000 (AP1)", "NSX (NA1)", "RX-7 ∞III (FC3S)", "RX-7 Type R (FD3S)", "RX-7 Type RS (FD3S)", "RX-8 Type S (SE3P)", "ROADSTER (NA6CE)", "ROADSTER RS (NB8C)", "IMPREZA STi Ver.V (GC8)", "IMPREZA STi (GDBA)", "IMPREZA STI (GDBF)", "LANCER Evolution III (CE9A)", "LANCER EVOLUTION IV (CN9A)", "LANCER Evolution VII (CT9A)", "LANCER Evolution IX (CT9A)", "LANCER EVOLUTION X (CZ4A)", "Cappuccino (EA11R)", "SILEIGHTY", "TRUENO 2door GT-APEX (AE86)", "G-FORCE SUPRA (JZA80-kai)", "MONSTER CIVIC R (EK9)", "NSX-R GT (NA2)", "RE Amemiya Genki-7 (FD3S)", "S2000 GT1 (AP1)", "ROADSTER C-SPEC (NA8C Kai)"})
        Me.cmbCar2.Location = New System.Drawing.Point(86, 80)
        Me.cmbCar2.Name = "cmbCar2"
        Me.cmbCar2.Size = New System.Drawing.Size(224, 23)
        Me.cmbCar2.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Car 3"
        '
        'cmbCar3
        '
        Me.cmbCar3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCar3.FormattingEnabled = True
        Me.cmbCar3.Items.AddRange(New Object() {"", "TRUENO GT-APEX (AE86)", "LEVIN GT-APEX (AE86)", "LEVIN SR (AE85)", "86 GT (ZN6)", "MR2 G-Limited (SW20)", "MR-S (ZZW30)", "ALTEZZA RS200 (SXE10)", "SUPRA RZ (JZA80)", "PRIUS (ZVW30)", "SKYLINE GT-R (BNR32)", "SKYLINE GT-R (BNR34)", "SILVIA K's (S13)", "Silvia Q's (S14)", "Silvia spec-R (S15)", "180SX TYPE II (RPS13)", "FAIRLADY Z (Z33)", "GT-R (R35)", "Civic SiR・II (EG6)", "CIVIC TYPE R (EK9)", "INTEGRA TYPE R (DC2)", "S2000 (AP1)", "NSX (NA1)", "RX-7 ∞III (FC3S)", "RX-7 Type R (FD3S)", "RX-7 Type RS (FD3S)", "RX-8 Type S (SE3P)", "ROADSTER (NA6CE)", "ROADSTER RS (NB8C)", "IMPREZA STi Ver.V (GC8)", "IMPREZA STi (GDBA)", "IMPREZA STI (GDBF)", "LANCER Evolution III (CE9A)", "LANCER EVOLUTION IV (CN9A)", "LANCER Evolution VII (CT9A)", "LANCER Evolution IX (CT9A)", "LANCER EVOLUTION X (CZ4A)", "Cappuccino (EA11R)", "SILEIGHTY", "TRUENO 2door GT-APEX (AE86)", "G-FORCE SUPRA (JZA80-kai)", "MONSTER CIVIC R (EK9)", "NSX-R GT (NA2)", "RE Amemiya Genki-7 (FD3S)", "S2000 GT1 (AP1)", "ROADSTER C-SPEC (NA8C Kai)"})
        Me.cmbCar3.Location = New System.Drawing.Point(86, 109)
        Me.cmbCar3.Name = "cmbCar3"
        Me.cmbCar3.Size = New System.Drawing.Size(224, 23)
        Me.cmbCar3.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(203, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Level"
        '
        'txtLevel
        '
        Me.txtLevel.Location = New System.Drawing.Point(280, 22)
        Me.txtLevel.MaxLength = 2
        Me.txtLevel.Name = "txtLevel"
        Me.txtLevel.Size = New System.Drawing.Size(111, 23)
        Me.txtLevel.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Chapter Level"
        '
        'txtChapLevel
        '
        Me.txtChapLevel.Location = New System.Drawing.Point(94, 22)
        Me.txtChapLevel.MaxLength = 2
        Me.txtChapLevel.Name = "txtChapLevel"
        Me.txtChapLevel.Size = New System.Drawing.Size(111, 23)
        Me.txtChapLevel.TabIndex = 20
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(354, 418)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 50
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbLegend
        '
        Me.cbLegend.AutoSize = True
        Me.cbLegend.Location = New System.Drawing.Point(211, 24)
        Me.cbLegend.Name = "cbLegend"
        Me.cbLegend.Size = New System.Drawing.Size(150, 19)
        Me.cbLegend.TabIndex = 21
        Me.cbLegend.Text = "Unlock Legend Chapter"
        Me.cbLegend.UseVisualStyleBackColor = True
        '
        'cbCar1
        '
        Me.cbCar1.AutoSize = True
        Me.cbCar1.Location = New System.Drawing.Point(316, 53)
        Me.cbCar1.Name = "cbCar1"
        Me.cbCar1.Size = New System.Drawing.Size(70, 19)
        Me.cbCar1.TabIndex = 5
        Me.cbCar1.Text = "Confirm"
        Me.cbCar1.UseVisualStyleBackColor = True
        '
        'cbCar2
        '
        Me.cbCar2.AutoSize = True
        Me.cbCar2.Location = New System.Drawing.Point(316, 82)
        Me.cbCar2.Name = "cbCar2"
        Me.cbCar2.Size = New System.Drawing.Size(70, 19)
        Me.cbCar2.TabIndex = 7
        Me.cbCar2.Text = "Confirm"
        Me.cbCar2.UseVisualStyleBackColor = True
        '
        'cbCar3
        '
        Me.cbCar3.AutoSize = True
        Me.cbCar3.Location = New System.Drawing.Point(316, 111)
        Me.cbCar3.Name = "cbCar3"
        Me.cbCar3.Size = New System.Drawing.Size(70, 19)
        Me.cbCar3.TabIndex = 9
        Me.cbCar3.Text = "Confirm"
        Me.cbCar3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmbGender)
        Me.GroupBox1.Controls.Add(Me.cbCar3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbCar2)
        Me.GroupBox1.Controls.Add(Me.cmbCar1)
        Me.GroupBox1.Controls.Add(Me.cbCar1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbCar2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCar3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtLevel)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 371)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cheat"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTPride)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtSPride)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 371)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(404, 52)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Initial D 7 AAX"
        Me.GroupBox3.Visible = False
        '
        'txtTPride
        '
        Me.txtTPride.Location = New System.Drawing.Point(287, 22)
        Me.txtTPride.Name = "txtTPride"
        Me.txtTPride.Size = New System.Drawing.Size(111, 23)
        Me.txtTPride.TabIndex = 42
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(211, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Tag Pride"
        '
        'txtSPride
        '
        Me.txtSPride.Location = New System.Drawing.Point(94, 22)
        Me.txtSPride.Name = "txtSPride"
        Me.txtSPride.Size = New System.Drawing.Size(111, 23)
        Me.txtSPride.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Single Pride"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbAvatar)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.txtChapLevel)
        Me.GroupBox2.Controls.Add(Me.txtPridePoint)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cbLegend)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(404, 227)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Initial D 6 AA"
        '
        'cbAvatar
        '
        Me.cbAvatar.AutoSize = True
        Me.cbAvatar.Location = New System.Drawing.Point(211, 53)
        Me.cbAvatar.Name = "cbAvatar"
        Me.cbAvatar.Size = New System.Drawing.Size(183, 19)
        Me.cbAvatar.TabIndex = 23
        Me.cbAvatar.Text = "Change Avatar (Experimental)"
        Me.cbAvatar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtHair)
        Me.GroupBox4.Controls.Add(Me.txtAcc)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.txtEyes2)
        Me.GroupBox4.Controls.Add(Me.txtMouth)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.txtCoat)
        Me.GroupBox4.Controls.Add(Me.txtEyes)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtEyebrown)
        Me.GroupBox4.Controls.Add(Me.txtTorso)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(6, 80)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(392, 141)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Avatar"
        '
        'txtHair
        '
        Me.txtHair.Location = New System.Drawing.Point(253, 80)
        Me.txtHair.MaxLength = 3
        Me.txtHair.Name = "txtHair"
        Me.txtHair.Size = New System.Drawing.Size(111, 23)
        Me.txtHair.TabIndex = 29
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(253, 109)
        Me.txtAcc.MaxLength = 3
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(111, 23)
        Me.txtAcc.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(188, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 15)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Hair"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(188, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 15)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Accessory"
        '
        'txtEyes2
        '
        Me.txtEyes2.Location = New System.Drawing.Point(253, 22)
        Me.txtEyes2.MaxLength = 3
        Me.txtEyes2.Name = "txtEyes2"
        Me.txtEyes2.Size = New System.Drawing.Size(111, 23)
        Me.txtEyes2.TabIndex = 25
        '
        'txtMouth
        '
        Me.txtMouth.Location = New System.Drawing.Point(253, 51)
        Me.txtMouth.MaxLength = 3
        Me.txtMouth.Name = "txtMouth"
        Me.txtMouth.Size = New System.Drawing.Size(111, 23)
        Me.txtMouth.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(188, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Eyes 2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(188, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 15)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Mouth"
        '
        'txtCoat
        '
        Me.txtCoat.Location = New System.Drawing.Point(71, 80)
        Me.txtCoat.MaxLength = 3
        Me.txtCoat.Name = "txtCoat"
        Me.txtCoat.Size = New System.Drawing.Size(111, 23)
        Me.txtCoat.TabIndex = 28
        '
        'txtEyes
        '
        Me.txtEyes.Location = New System.Drawing.Point(71, 109)
        Me.txtEyes.MaxLength = 3
        Me.txtEyes.Name = "txtEyes"
        Me.txtEyes.Size = New System.Drawing.Size(111, 23)
        Me.txtEyes.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 15)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Coat"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 15)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Eyes"
        '
        'txtEyebrown
        '
        Me.txtEyebrown.Location = New System.Drawing.Point(71, 22)
        Me.txtEyebrown.MaxLength = 3
        Me.txtEyebrown.Name = "txtEyebrown"
        Me.txtEyebrown.Size = New System.Drawing.Size(111, 23)
        Me.txtEyebrown.TabIndex = 24
        '
        'txtTorso
        '
        Me.txtTorso.Location = New System.Drawing.Point(71, 51)
        Me.txtTorso.MaxLength = 3
        Me.txtTorso.Name = "txtTorso"
        Me.txtTorso.Size = New System.Drawing.Size(111, 23)
        Me.txtTorso.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Eyebrown"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 15)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Torso"
        '
        'txtPridePoint
        '
        Me.txtPridePoint.Location = New System.Drawing.Point(94, 51)
        Me.txtPridePoint.MaxLength = 5
        Me.txtPridePoint.Name = "txtPridePoint"
        Me.txtPridePoint.Size = New System.Drawing.Size(111, 23)
        Me.txtPridePoint.TabIndex = 22
        Me.txtPridePoint.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 15)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Pride Point"
        Me.Label7.Visible = False
        '
        'frmEdit
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 453)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Card"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCar1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCar2 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbCar3 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLevel As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtChapLevel As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents cbLegend As CheckBox
    Friend WithEvents cbCar1 As CheckBox
    Friend WithEvents cbCar2 As CheckBox
    Friend WithEvents cbCar3 As CheckBox
    Friend WithEvents ttCar1 As ToolTip
    Friend WithEvents ttCar2 As ToolTip
    Friend WithEvents ttCar3 As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPridePoint As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtSPride As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtTPride As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbAvatar As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtHair As TextBox
    Friend WithEvents txtAcc As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEyes2 As TextBox
    Friend WithEvents txtMouth As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCoat As TextBox
    Friend WithEvents txtEyes As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtEyebrown As TextBox
    Friend WithEvents txtTorso As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
End Class
