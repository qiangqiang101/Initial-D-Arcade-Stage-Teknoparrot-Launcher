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
        Me.GroupBox1.SuspendLayout()
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
        Me.cmbGender.Location = New System.Drawing.Point(94, 22)
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
        Me.Label3.Location = New System.Drawing.Point(9, 112)
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
        Me.cmbCar1.Location = New System.Drawing.Point(94, 109)
        Me.cmbCar1.Name = "cmbCar1"
        Me.cmbCar1.Size = New System.Drawing.Size(224, 23)
        Me.cmbCar1.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 141)
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
        Me.cmbCar2.Location = New System.Drawing.Point(94, 138)
        Me.cmbCar2.Name = "cmbCar2"
        Me.cmbCar2.Size = New System.Drawing.Size(224, 23)
        Me.cmbCar2.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 170)
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
        Me.cmbCar3.Location = New System.Drawing.Point(94, 167)
        Me.cmbCar3.Name = "cmbCar3"
        Me.cmbCar3.Size = New System.Drawing.Size(224, 23)
        Me.cmbCar3.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Level"
        '
        'txtLevel
        '
        Me.txtLevel.Location = New System.Drawing.Point(94, 51)
        Me.txtLevel.Name = "txtLevel"
        Me.txtLevel.Size = New System.Drawing.Size(111, 23)
        Me.txtLevel.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Chapter Level"
        '
        'txtChapLevel
        '
        Me.txtChapLevel.Location = New System.Drawing.Point(94, 80)
        Me.txtChapLevel.Name = "txtChapLevel"
        Me.txtChapLevel.Size = New System.Drawing.Size(111, 23)
        Me.txtChapLevel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(343, 268)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbLegend
        '
        Me.cbLegend.AutoSize = True
        Me.cbLegend.Location = New System.Drawing.Point(94, 196)
        Me.cbLegend.Name = "cbLegend"
        Me.cbLegend.Size = New System.Drawing.Size(150, 19)
        Me.cbLegend.TabIndex = 11
        Me.cbLegend.Text = "Unlock Legend Chapter"
        Me.cbLegend.UseVisualStyleBackColor = True
        '
        'cbCar1
        '
        Me.cbCar1.AutoSize = True
        Me.cbCar1.Location = New System.Drawing.Point(324, 111)
        Me.cbCar1.Name = "cbCar1"
        Me.cbCar1.Size = New System.Drawing.Size(70, 19)
        Me.cbCar1.TabIndex = 6
        Me.cbCar1.Text = "Confirm"
        Me.cbCar1.UseVisualStyleBackColor = True
        '
        'cbCar2
        '
        Me.cbCar2.AutoSize = True
        Me.cbCar2.Location = New System.Drawing.Point(324, 140)
        Me.cbCar2.Name = "cbCar2"
        Me.cbCar2.Size = New System.Drawing.Size(70, 19)
        Me.cbCar2.TabIndex = 8
        Me.cbCar2.Text = "Confirm"
        Me.cbCar2.UseVisualStyleBackColor = True
        '
        'cbCar3
        '
        Me.cbCar3.AutoSize = True
        Me.cbCar3.Location = New System.Drawing.Point(324, 169)
        Me.cbCar3.Name = "cbCar3"
        Me.cbCar3.Size = New System.Drawing.Size(70, 19)
        Me.cbCar3.TabIndex = 10
        Me.cbCar3.Text = "Confirm"
        Me.cbCar3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbGender)
        Me.GroupBox1.Controls.Add(Me.cbCar3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbCar2)
        Me.GroupBox1.Controls.Add(Me.cmbCar1)
        Me.GroupBox1.Controls.Add(Me.cbCar1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbLegend)
        Me.GroupBox1.Controls.Add(Me.cmbCar2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtChapLevel)
        Me.GroupBox1.Controls.Add(Me.cmbCar3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtLevel)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 221)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cheat"
        '
        'frmEdit
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 303)
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
End Class
