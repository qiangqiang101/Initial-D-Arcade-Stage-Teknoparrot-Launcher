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
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblWeather = New System.Windows.Forms.Label()
        Me.tcPanel = New InitialDLauncher.TransparentControl()
        Me.btnTimeAttack = New System.Windows.Forms.Button()
        Me.lblTypeWeather = New System.Windows.Forms.Label()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.tcPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblType
        '
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblType.ForeColor = System.Drawing.Color.White
        Me.lblType.Location = New System.Drawing.Point(9, 3)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(127, 21)
        Me.lblType.TabIndex = 1
        Me.lblType.Text = "Counterclockwise"
        Me.lblType.Visible = False
        '
        'lblWeather
        '
        Me.lblWeather.BackColor = System.Drawing.Color.Transparent
        Me.lblWeather.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblWeather.ForeColor = System.Drawing.Color.White
        Me.lblWeather.Location = New System.Drawing.Point(142, 3)
        Me.lblWeather.Name = "lblWeather"
        Me.lblWeather.Size = New System.Drawing.Size(80, 21)
        Me.lblWeather.TabIndex = 2
        Me.lblWeather.Text = "Dry"
        Me.lblWeather.Visible = False
        '
        'tcPanel
        '
        Me.tcPanel.Controls.Add(Me.btnTimeAttack)
        Me.tcPanel.Controls.Add(Me.lblTypeWeather)
        Me.tcPanel.Controls.Add(Me.lblCourse)
        Me.tcPanel.Controls.Add(Me.lblTime)
        Me.tcPanel.Location = New System.Drawing.Point(3, 111)
        Me.tcPanel.MinimumSize = New System.Drawing.Size(50, 20)
        Me.tcPanel.Name = "tcPanel"
        Me.tcPanel.Opacity = 0.5R
        Me.tcPanel.Size = New System.Drawing.Size(288, 54)
        Me.tcPanel.TabIndex = 4
        Me.tcPanel.Text = "TransparentControl1"
        Me.tcPanel.Transparent = True
        Me.tcPanel.TransparentColor = System.Drawing.Color.Black
        '
        'btnTimeAttack
        '
        Me.btnTimeAttack.Location = New System.Drawing.Point(172, 28)
        Me.btnTimeAttack.Name = "btnTimeAttack"
        Me.btnTimeAttack.Size = New System.Drawing.Size(113, 23)
        Me.btnTimeAttack.TabIndex = 1
        Me.btnTimeAttack.Text = "Submit Score"
        Me.btnTimeAttack.UseVisualStyleBackColor = True
        '
        'lblTypeWeather
        '
        Me.lblTypeWeather.BackColor = System.Drawing.Color.Transparent
        Me.lblTypeWeather.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTypeWeather.ForeColor = System.Drawing.Color.White
        Me.lblTypeWeather.Location = New System.Drawing.Point(4, 33)
        Me.lblTypeWeather.Name = "lblTypeWeather"
        Me.lblTypeWeather.Size = New System.Drawing.Size(157, 21)
        Me.lblTypeWeather.TabIndex = 4
        Me.lblTypeWeather.Text = "Counterclockwise / Dry"
        '
        'lblCourse
        '
        Me.lblCourse.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCourse.ForeColor = System.Drawing.Color.White
        Me.lblCourse.Location = New System.Drawing.Point(0, 0)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(164, 37)
        Me.lblCourse.TabIndex = 0
        Me.lblCourse.Text = "Lake Akina"
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.lblTime.ForeColor = System.Drawing.Color.White
        Me.lblTime.Location = New System.Drawing.Point(170, 1)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(116, 27)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "1'00""000"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimeAttack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InitialDLauncher.My.Resources.Resources.lakeAkina
        Me.Controls.Add(Me.tcPanel)
        Me.Controls.Add(Me.lblWeather)
        Me.Controls.Add(Me.lblType)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "TimeAttack"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Size = New System.Drawing.Size(295, 170)
        Me.tcPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCourse As Label
    Friend WithEvents lblType As Label
    Friend WithEvents lblWeather As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents btnTimeAttack As Button
    Friend WithEvents tcPanel As TransparentControl
    Friend WithEvents lblTypeWeather As Label
End Class
