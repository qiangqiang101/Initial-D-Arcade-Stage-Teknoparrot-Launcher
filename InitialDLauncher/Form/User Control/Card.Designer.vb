<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Card
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnSelect = New InitialDLauncher.NSButton()
        Me.lblCar = New System.Windows.Forms.Label()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOptions = New InitialDLauncher.NSComboBox()
        Me.btnGo = New InitialDLauncher.NSButton()
        Me.GroupBox1 = New InitialDLauncher.NSGroupBox()
        Me.txtName = New InitialDLauncher.NSTextBox()
        Me.btnRenameCancel = New InitialDLauncher.NSButton()
        Me.btnRenameOK = New InitialDLauncher.NSButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(72, 11)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(184, 34)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "藤原文太"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(287, 243)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(87, 24)
        Me.btnSelect.TabIndex = 4
        Me.btnSelect.Text = "Select Card"
        '
        'lblCar
        '
        Me.lblCar.BackColor = System.Drawing.Color.Transparent
        Me.lblCar.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCar.Location = New System.Drawing.Point(76, 52)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New System.Drawing.Size(255, 19)
        Me.lblCar.TabIndex = 6
        Me.lblCar.Text = "IMPREZA STi Ver.V (GC8)"
        '
        'lblLevel
        '
        Me.lblLevel.BackColor = System.Drawing.Color.Transparent
        Me.lblLevel.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblLevel.Location = New System.Drawing.Point(258, 27)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(73, 42)
        Me.lblLevel.TabIndex = 7
        Me.lblLevel.Text = "E3"
        Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Options:"
        '
        'cmbOptions
        '
        Me.cmbOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbOptions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbOptions.FormattingEnabled = True
        Me.cmbOptions.Location = New System.Drawing.Point(65, 243)
        Me.cmbOptions.Name = "cmbOptions"
        Me.cmbOptions.Size = New System.Drawing.Size(156, 24)
        Me.cmbOptions.TabIndex = 10
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGo.Location = New System.Drawing.Point(227, 243)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(54, 24)
        Me.btnGo.TabIndex = 11
        Me.btnGo.Text = "GO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.btnRenameCancel)
        Me.GroupBox1.Controls.Add(Me.btnRenameOK)
        Me.GroupBox1.DrawSeperator = False
        Me.GroupBox1.Location = New System.Drawing.Point(56, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(267, 92)
        Me.GroupBox1.SubTitle = ""
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.Text = "NsGroupBox1"
        Me.GroupBox1.Title = "Rename File"
        Me.GroupBox1.Visible = False
        '
        'txtName
        '
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.Location = New System.Drawing.Point(6, 34)
        Me.txtName.MaxLength = 32767
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = False
        Me.txtName.Size = New System.Drawing.Size(255, 24)
        Me.txtName.TabIndex = 4
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtName.UseSystemPasswordChar = False
        '
        'btnRenameCancel
        '
        Me.btnRenameCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRenameCancel.Location = New System.Drawing.Point(198, 62)
        Me.btnRenameCancel.Name = "btnRenameCancel"
        Me.btnRenameCancel.Size = New System.Drawing.Size(63, 24)
        Me.btnRenameCancel.TabIndex = 5
        Me.btnRenameCancel.Text = "Cancel"
        '
        'btnRenameOK
        '
        Me.btnRenameOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRenameOK.Location = New System.Drawing.Point(129, 62)
        Me.btnRenameOK.Name = "btnRenameOK"
        Me.btnRenameOK.Size = New System.Drawing.Size(63, 24)
        Me.btnRenameOK.TabIndex = 3
        Me.btnRenameOK.Text = "OK"
        '
        'Card
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BackgroundImage = Global.InitialDLauncher.My.Resources.Resources.card8m
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.cmbOptions)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.lblCar)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lblName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "Card"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Size = New System.Drawing.Size(380, 273)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents btnSelect As NSButton
    Friend WithEvents lblCar As Label
    Friend WithEvents lblLevel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbOptions As NSComboBox
    Friend WithEvents btnGo As NSButton
    Friend WithEvents GroupBox1 As NSGroupBox
    Friend WithEvents txtName As NSTextBox
    Friend WithEvents btnRenameCancel As NSButton
    Friend WithEvents btnRenameOK As NSButton
End Class
