<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyFlowLayoutPanel
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
        Me.FP = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.VS = New InitialDLauncher.NSVScrollBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FP
        '
        Me.FP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FP.AutoScroll = True
        Me.FP.ForeColor = System.Drawing.Color.Black
        Me.FP.Location = New System.Drawing.Point(0, 0)
        Me.FP.Name = "FP"
        Me.FP.Size = New System.Drawing.Size(516, 384)
        Me.FP.TabIndex = 60
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FP)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 384)
        Me.Panel1.TabIndex = 61
        '
        'VS
        '
        Me.VS._Percent = 0R
        Me.VS.Dock = System.Windows.Forms.DockStyle.Right
        Me.VS.LargeChange = 100
        Me.VS.Location = New System.Drawing.Point(498, 0)
        Me.VS.Maximum = 1000
        Me.VS.Minimum = 0
        Me.VS.Name = "VS"
        Me.VS.Size = New System.Drawing.Size(18, 384)
        Me.VS.SmallChange = 10
        Me.VS.TabIndex = 59
        Me.VS.Text = "NsvScrollBar1"
        Me.VS.Value = 0
        '
        'MyFlowLayoutPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.VS)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "MyFlowLayoutPanel"
        Me.Size = New System.Drawing.Size(516, 384)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VS As NSVScrollBar
    Friend WithEvents FP As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
End Class
