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
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRenameCancel = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnRenameOK = New System.Windows.Forms.Button()
        Me.lblCar = New System.Windows.Forms.Label()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(76, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(184, 34)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "藤原文太"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(287, 244)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(87, 23)
        Me.btnSelect.TabIndex = 4
        Me.btnSelect.Text = "Select Card"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(6, 244)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(87, 23)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit Card"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnUnselect
        '
        Me.btnUnselect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnselect.Location = New System.Drawing.Point(194, 244)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(87, 23)
        Me.btnUnselect.TabIndex = 3
        Me.btnUnselect.Text = "Deselect Card"
        Me.btnUnselect.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRename.Location = New System.Drawing.Point(99, 244)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(87, 23)
        Me.btnRename.TabIndex = 2
        Me.btnRename.Text = "Rename Card"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnRenameCancel)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.btnRenameOK)
        Me.GroupBox1.Location = New System.Drawing.Point(56, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 78)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rename File"
        Me.GroupBox1.Visible = False
        '
        'btnRenameCancel
        '
        Me.btnRenameCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRenameCancel.Location = New System.Drawing.Point(198, 49)
        Me.btnRenameCancel.Name = "btnRenameCancel"
        Me.btnRenameCancel.Size = New System.Drawing.Size(63, 23)
        Me.btnRenameCancel.TabIndex = 5
        Me.btnRenameCancel.Text = "Cancel"
        Me.btnRenameCancel.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(6, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(255, 23)
        Me.txtName.TabIndex = 4
        '
        'btnRenameOK
        '
        Me.btnRenameOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRenameOK.Location = New System.Drawing.Point(129, 49)
        Me.btnRenameOK.Name = "btnRenameOK"
        Me.btnRenameOK.Size = New System.Drawing.Size(63, 23)
        Me.btnRenameOK.TabIndex = 3
        Me.btnRenameOK.Text = "OK"
        Me.btnRenameOK.UseVisualStyleBackColor = True
        '
        'lblCar
        '
        Me.lblCar.BackColor = System.Drawing.Color.Transparent
        Me.lblCar.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCar.Location = New System.Drawing.Point(76, 52)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New System.Drawing.Size(241, 19)
        Me.lblCar.TabIndex = 6
        Me.lblCar.Text = "IMPREZA STi Ver.V (GC8)"
        '
        'lblLevel
        '
        Me.lblLevel.BackColor = System.Drawing.Color.Transparent
        Me.lblLevel.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblLevel.Location = New System.Drawing.Point(264, 27)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(59, 42)
        Me.lblLevel.TabIndex = 7
        Me.lblLevel.Text = "E3"
        Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Card
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InitialDLauncher.My.Resources.Resources.card
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.lblCar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRename)
        Me.Controls.Add(Me.btnUnselect)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lblName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "Card"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Size = New System.Drawing.Size(380, 273)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnUnselect As Button
    Friend WithEvents btnRename As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnRenameOK As Button
    Friend WithEvents btnRenameCancel As Button
    Friend WithEvents lblCar As Label
    Friend WithEvents lblLevel As Label
End Class
