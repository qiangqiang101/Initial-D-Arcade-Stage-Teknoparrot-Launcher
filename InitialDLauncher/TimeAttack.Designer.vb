<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeAttack
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
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblWeather = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnTimeAttack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCourse
        '
        Me.lblCourse.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCourse.Location = New System.Drawing.Point(6, 3)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(127, 21)
        Me.lblCourse.TabIndex = 0
        Me.lblCourse.Text = "Lake Akina"
        '
        'lblType
        '
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(139, 3)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(127, 21)
        Me.lblType.TabIndex = 1
        Me.lblType.Text = "Counterclockwise"
        '
        'lblWeather
        '
        Me.lblWeather.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeather.Location = New System.Drawing.Point(272, 3)
        Me.lblWeather.Name = "lblWeather"
        Me.lblWeather.Size = New System.Drawing.Size(80, 21)
        Me.lblWeather.TabIndex = 2
        Me.lblWeather.Text = "Dry"
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(358, 3)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(127, 21)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "1'00""000"
        '
        'btnTimeAttack
        '
        Me.btnTimeAttack.Location = New System.Drawing.Point(491, 1)
        Me.btnTimeAttack.Name = "btnTimeAttack"
        Me.btnTimeAttack.Size = New System.Drawing.Size(113, 23)
        Me.btnTimeAttack.TabIndex = 1
        Me.btnTimeAttack.Text = "Submit Score"
        Me.btnTimeAttack.UseVisualStyleBackColor = True
        '
        'TimeAttack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnTimeAttack)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblWeather)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblCourse)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "TimeAttack"
        Me.Size = New System.Drawing.Size(615, 25)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCourse As Label
    Friend WithEvents lblType As Label
    Friend WithEvents lblWeather As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents btnTimeAttack As Button
End Class
