<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FieldInformationItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LabelText = New System.Windows.Forms.Label()
        Me.BoolField = New InitialDLauncher.NSOnOffBox()
        Me.TextField = New InitialDLauncher.NSTextBox()
        Me.SuspendLayout()
        '
        'LabelText
        '
        Me.LabelText.AutoSize = True
        Me.LabelText.ForeColor = System.Drawing.Color.White
        Me.LabelText.Location = New System.Drawing.Point(3, 6)
        Me.LabelText.Name = "LabelText"
        Me.LabelText.Size = New System.Drawing.Size(140, 15)
        Me.LabelText.TabIndex = 10
        Me.LabelText.Text = "General - Enable AMD Fix"
        '
        'BoolField
        '
        Me.BoolField.Checked = True
        Me.BoolField.Location = New System.Drawing.Point(199, 0)
        Me.BoolField.MaximumSize = New System.Drawing.Size(56, 24)
        Me.BoolField.MinimumSize = New System.Drawing.Size(56, 24)
        Me.BoolField.Name = "BoolField"
        Me.BoolField.Size = New System.Drawing.Size(56, 24)
        Me.BoolField.TabIndex = 14
        Me.BoolField.Text = "NsOnOffBox1"
        Me.BoolField.Visible = False
        '
        'TextField
        '
        Me.TextField.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextField.Location = New System.Drawing.Point(199, 0)
        Me.TextField.MaxLength = 20
        Me.TextField.Multiline = False
        Me.TextField.Name = "TextField"
        Me.TextField.ReadOnly = True
        Me.TextField.Size = New System.Drawing.Size(201, 24)
        Me.TextField.TabIndex = 11
        Me.TextField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TextField.UseSystemPasswordChar = False
        Me.TextField.Visible = False
        '
        'FieldInformationItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Controls.Add(Me.BoolField)
        Me.Controls.Add(Me.TextField)
        Me.Controls.Add(Me.LabelText)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "FieldInformationItem"
        Me.Size = New System.Drawing.Size(400, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelText As Label
    Friend WithEvents TextField As NSTextBox
    Friend WithEvents BoolField As NSOnOffBox
End Class
