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
        Me.cmbCarList = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbFullSpec = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmbCarList
        '
        Me.cmbCarList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarList.FormattingEnabled = True
        Me.cmbCarList.Items.AddRange(New Object() {"", "TRUENO GT-APEX (AE86)", "LEVIN GT-APEX (AE86)", "LEVIN SR (AE85)", "86 GT (ZN6)", "MR2 G-Limited (SW20)", "MR-S (ZZW30)", "ALTEZZA RS200 (SXE10)", "SUPRA RZ (JZA80)", "PRIUS (ZVW30)", "SKYLINE GT-R (BNR32)", "SKYLINE GT-R (BNR34)", "SILVIA K's (S13)", "Silvia Q's (S14)", "Silvia spec-R (S15)", "180SX TYPE II (RPS13)", "FAIRLADY Z (Z33)", "GT-R (R35)", "Civic SiR・II (EG6)", "CIVIC TYPE R (EK9)", "INTEGRA TYPE R (DC2)", "S2000 (AP1)", "NSX (NA1)", "RX-7 ∞III (FC3S)", "RX-7 Type R (FD3S)", "RX-7 Type RS (FD3S)", "RX-8 Type S (SE3P)", "ROADSTER (NA6CE)", "ROADSTER RS (NB8C)", "IMPREZA STi Ver.V (GC8)", "IMPREZA STi (GDBA)", "IMPREZA STI (GDBF)", "LANCER Evolution III (CE9A)", "LANCER EVOLUTION IV (CN9A)", "LANCER Evolution VII (CT9A)", "LANCER Evolution IX (CT9A)", "LANCER EVOLUTION X (CZ4A)", "Cappuccino (EA11R)", "SILEIGHTY", "TRUENO 2door GT-APEX (AE86)", "G-FORCE SUPRA (JZA80-kai)", "MONSTER CIVIC R (EK9)", "NSX-R GT (NA2)", "RE Amemiya Genki-7 (FD3S)", "S2000 GT1 (AP1)", "ROADSTER C-SPEC (NA8C Kai)"})
        Me.cmbCarList.Location = New System.Drawing.Point(80, 12)
        Me.cmbCarList.Name = "cmbCarList"
        Me.cmbCarList.Size = New System.Drawing.Size(224, 23)
        Me.cmbCarList.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Change to"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(486, 268)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 51
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbFullSpec
        '
        Me.cbFullSpec.AutoSize = True
        Me.cbFullSpec.Location = New System.Drawing.Point(310, 14)
        Me.cbFullSpec.Name = "cbFullSpec"
        Me.cbFullSpec.Size = New System.Drawing.Size(113, 19)
        Me.cbFullSpec.TabIndex = 52
        Me.cbFullSpec.Text = "Unlock Full Spec"
        Me.cbFullSpec.UseVisualStyleBackColor = True
        '
        'frmEditCar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 303)
        Me.Controls.Add(Me.cbFullSpec)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbCarList)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditCar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Car"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbCarList As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cbFullSpec As CheckBox
End Class
