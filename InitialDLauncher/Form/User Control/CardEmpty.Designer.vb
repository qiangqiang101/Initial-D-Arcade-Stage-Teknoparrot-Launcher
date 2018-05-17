<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardEmpty
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
        Me.lblNoCard = New System.Windows.Forms.Label()
        Me.btnScan = New InitialDLauncher.NSButton()
        Me.btnBrowse = New InitialDLauncher.NSButton()
        Me.SuspendLayout()
        '
        'lblNoCard
        '
        Me.lblNoCard.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNoCard.ForeColor = System.Drawing.Color.White
        Me.lblNoCard.Location = New System.Drawing.Point(6, 103)
        Me.lblNoCard.Name = "lblNoCard"
        Me.lblNoCard.Size = New System.Drawing.Size(368, 48)
        Me.lblNoCard.TabIndex = 10
        Me.lblNoCard.Text = "Whoa! No card found in this directory."
        Me.lblNoCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnScan
        '
        Me.btnScan.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnScan.Location = New System.Drawing.Point(193, 154)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(110, 24)
        Me.btnScan.TabIndex = 12
        Me.btnScan.Text = "Scan for Card"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBrowse.Location = New System.Drawing.Point(77, 154)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(110, 24)
        Me.btnBrowse.TabIndex = 11
        Me.btnBrowse.Text = "Browse Card"
        '
        'CardEmpty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblNoCard)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "CardEmpty"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Size = New System.Drawing.Size(380, 273)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNoCard As Label
    Friend WithEvents btnBrowse As NSButton
    Friend WithEvents btnScan As NSButton
End Class
