<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyWebBrowser
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
        Me.VS = New InitialDLauncher.NSVScrollBar()
        Me.WB = New System.Windows.Forms.WebBrowser()
        Me.HS = New InitialDLauncher.NSHScrollBar()
        Me.SuspendLayout()
        '
        'VS
        '
        Me.VS._Percent = 0R
        Me.VS.Dock = System.Windows.Forms.DockStyle.Right
        Me.VS.LargeChange = 10
        Me.VS.Location = New System.Drawing.Point(624, 0)
        Me.VS.Maximum = 100
        Me.VS.Minimum = 0
        Me.VS.Name = "VS"
        Me.VS.Size = New System.Drawing.Size(18, 441)
        Me.VS.SmallChange = 1
        Me.VS.TabIndex = 58
        Me.VS.Text = "NsvScrollBar1"
        Me.VS.Value = 0
        '
        'WB
        '
        Me.WB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WB.Location = New System.Drawing.Point(0, 0)
        Me.WB.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB.Name = "WB"
        Me.WB.ScrollBarsEnabled = False
        Me.WB.Size = New System.Drawing.Size(624, 423)
        Me.WB.TabIndex = 59
        '
        'HS
        '
        Me.HS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HS.LargeChange = 10
        Me.HS.Location = New System.Drawing.Point(0, 423)
        Me.HS.Maximum = 100
        Me.HS.Minimum = 0
        Me.HS.Name = "HS"
        Me.HS.Size = New System.Drawing.Size(624, 18)
        Me.HS.SmallChange = 1
        Me.HS.TabIndex = 60
        Me.HS.Text = "NshScrollBar1"
        Me.HS.Value = 0
        '
        'MyWebBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Controls.Add(Me.WB)
        Me.Controls.Add(Me.HS)
        Me.Controls.Add(Me.VS)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "MyWebBrowser"
        Me.Size = New System.Drawing.Size(642, 441)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VS As NSVScrollBar
    Friend WithEvents WB As WebBrowser
    Friend WithEvents HS As NSHScrollBar
End Class
