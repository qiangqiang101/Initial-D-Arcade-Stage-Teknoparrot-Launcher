<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditCar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditCar))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.cmbColor = New InitialDLauncher.NSComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.NsGroupBox1 = New InitialDLauncher.NSGroupBox()
        Me.cmbRollbar = New InitialDLauncher.NSComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEngine = New InitialDLauncher.NSComboBox()
        Me.cbFullSpec = New InitialDLauncher.NSCheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCarList = New InitialDLauncher.NSComboBox()
        Me.btnSave = New InitialDLauncher.NSButton()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.NsTheme1.Controls.Add(Me.cmbColor)
        Me.NsTheme1.Controls.Add(Me.Label4)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.NsGroupBox1)
        Me.NsTheme1.Controls.Add(Me.cmbCarList)
        Me.NsTheme1.Controls.Add(Me.btnSave)
        Me.NsTheme1.Controls.Add(Me.Label3)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(373, 276)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 53
        Me.NsTheme1.Text = "Edit Car"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(81, 69)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(269, 24)
        Me.cmbColor.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Color"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(350, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 56
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'NsGroupBox1
        '
        Me.NsGroupBox1.Controls.Add(Me.cmbRollbar)
        Me.NsGroupBox1.Controls.Add(Me.Label2)
        Me.NsGroupBox1.Controls.Add(Me.cmbEngine)
        Me.NsGroupBox1.Controls.Add(Me.cbFullSpec)
        Me.NsGroupBox1.Controls.Add(Me.Label1)
        Me.NsGroupBox1.DrawSeperator = False
        Me.NsGroupBox1.Location = New System.Drawing.Point(12, 106)
        Me.NsGroupBox1.Name = "NsGroupBox1"
        Me.NsGroupBox1.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox1.Size = New System.Drawing.Size(350, 129)
        Me.NsGroupBox1.SubTitle = "Edit this might overwrite your Visual Parts"
        Me.NsGroupBox1.TabIndex = 53
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = "Performance Parts"
        '
        'cmbRollbar
        '
        Me.cmbRollbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbRollbar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRollbar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRollbar.Enabled = False
        Me.cmbRollbar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbRollbar.FormattingEnabled = True
        Me.cmbRollbar.Location = New System.Drawing.Point(104, 93)
        Me.cmbRollbar.Name = "cmbRollbar"
        Me.cmbRollbar.Size = New System.Drawing.Size(234, 24)
        Me.cmbRollbar.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 24)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Select Rollcage"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEngine
        '
        Me.cmbEngine.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbEngine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEngine.Enabled = False
        Me.cmbEngine.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbEngine.FormattingEnabled = True
        Me.cmbEngine.Location = New System.Drawing.Point(104, 63)
        Me.cmbEngine.Name = "cmbEngine"
        Me.cmbEngine.Size = New System.Drawing.Size(234, 24)
        Me.cmbEngine.TabIndex = 13
        '
        'cbFullSpec
        '
        Me.cbFullSpec.Checked = False
        Me.cbFullSpec.Location = New System.Drawing.Point(6, 36)
        Me.cbFullSpec.Name = "cbFullSpec"
        Me.cbFullSpec.Size = New System.Drawing.Size(161, 24)
        Me.cbFullSpec.TabIndex = 52
        Me.cbFullSpec.Text = "Save Performance Parts"
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Engine"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCarList
        '
        Me.cmbCarList.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCarList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCarList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCarList.FormattingEnabled = True
        Me.cmbCarList.Items.AddRange(New Object() {"", "TRUENO GT-APEX (AE86)", "LEVIN GT-APEX (AE86)", "LEVIN SR (AE85)", "86 GT (ZN6)", "MR2 G-Limited (SW20)", "MR-S (ZZW30)", "ALTEZZA RS200 (SXE10)", "SUPRA RZ (JZA80)", "PRIUS (ZVW30)", "SKYLINE GT-R (BNR32)", "SKYLINE GT-R (BNR34)", "SILVIA K's (S13)", "Silvia Q's (S14)", "Silvia spec-R (S15)", "180SX TYPE II (RPS13)", "FAIRLADY Z (Z33)", "GT-R (R35)", "Civic SiR・II (EG6)", "CIVIC TYPE R (EK9)", "INTEGRA TYPE R (DC2)", "S2000 (AP1)", "NSX (NA1)", "RX-7 ∞III (FC3S)", "RX-7 Type R (FD3S)", "RX-7 Type RS (FD3S)", "RX-8 Type S (SE3P)", "ROADSTER (NA6CE)", "ROADSTER RS (NB8C)", "IMPREZA STi Ver.V (GC8)", "IMPREZA STi (GDBA)", "IMPREZA STI (GDBF)", "LANCER Evolution III (CE9A)", "LANCER EVOLUTION IV (CN9A)", "LANCER Evolution VII (CT9A)", "LANCER Evolution IX (CT9A)", "LANCER EVOLUTION X (CZ4A)", "Cappuccino (EA11R)", "SILEIGHTY", "TRUENO 2door GT-APEX (AE86)", "G-FORCE SUPRA (JZA80-kai)", "MONSTER CIVIC R (EK9)", "NSX-R GT (NA2)", "RE Amemiya Genki-7 (FD3S)", "S2000 GT1 (AP1)", "ROADSTER C-SPEC (NA8C Kai)"})
        Me.cmbCarList.Location = New System.Drawing.Point(81, 39)
        Me.cmbCarList.Name = "cmbCarList"
        Me.cmbCarList.Size = New System.Drawing.Size(269, 24)
        Me.cmbCarList.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(286, 241)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 51
        Me.btnSave.Text = "Save"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Change to"
        '
        'frmEditCar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 276)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditCar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Car"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTheme1.PerformLayout()
        Me.NsGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbCarList As NSComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As NSButton
    Friend WithEvents cbFullSpec As NSCheckBox
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsGroupBox1 As NSGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEngine As NSComboBox
    Friend WithEvents cmbRollbar As NSComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents cmbColor As NSComboBox
    Friend WithEvents Label4 As Label
End Class
