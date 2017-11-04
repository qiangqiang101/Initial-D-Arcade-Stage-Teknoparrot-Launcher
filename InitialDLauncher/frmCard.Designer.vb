<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCard))
        Me.tcTab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.flp6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.flp7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbl6 = New System.Windows.Forms.Label()
        Me.lbl7 = New System.Windows.Forms.Label()
        Me.tcTab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcTab
        '
        Me.tcTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcTab.Controls.Add(Me.TabPage1)
        Me.tcTab.Controls.Add(Me.TabPage2)
        Me.tcTab.Location = New System.Drawing.Point(12, 12)
        Me.tcTab.Name = "tcTab"
        Me.tcTab.SelectedIndex = 0
        Me.tcTab.Size = New System.Drawing.Size(814, 501)
        Me.tcTab.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.flp6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(806, 473)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Initial D 6AA"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'flp6
        '
        Me.flp6.AutoScroll = True
        Me.flp6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp6.Location = New System.Drawing.Point(3, 3)
        Me.flp6.Name = "flp6"
        Me.flp6.Size = New System.Drawing.Size(800, 467)
        Me.flp6.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.flp7)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(806, 473)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Initial D 7AAX"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'flp7
        '
        Me.flp7.AutoScroll = True
        Me.flp7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp7.Location = New System.Drawing.Point(3, 3)
        Me.flp7.Name = "flp7"
        Me.flp7.Size = New System.Drawing.Size(800, 467)
        Me.flp7.TabIndex = 1
        '
        'lbl6
        '
        Me.lbl6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl6.AutoSize = True
        Me.lbl6.Location = New System.Drawing.Point(12, 516)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(55, 15)
        Me.lbl6.TabIndex = 53
        Me.lbl6.Text = "ID6 Card:"
        '
        'lbl7
        '
        Me.lbl7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl7.AutoSize = True
        Me.lbl7.Location = New System.Drawing.Point(12, 531)
        Me.lbl7.Name = "lbl7"
        Me.lbl7.Size = New System.Drawing.Size(55, 15)
        Me.lbl7.TabIndex = 54
        Me.lbl7.Text = "ID7 Card:"
        '
        'frmCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 555)
        Me.Controls.Add(Me.lbl7)
        Me.Controls.Add(Me.lbl6)
        Me.Controls.Add(Me.tcTab)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Card Management"
        Me.tcTab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tcTab As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents flp6 As FlowLayoutPanel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents flp7 As FlowLayoutPanel
    Friend WithEvents lbl6 As Label
    Friend WithEvents lbl7 As Label
End Class
