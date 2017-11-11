<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLeaderboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeaderboard))
        Me.tcGames = New System.Windows.Forms.TabControl()
        Me.tp6 = New System.Windows.Forms.TabPage()
        Me.btnRefresh6 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCourse6 = New System.Windows.Forms.ComboBox()
        Me.lv6 = New System.Windows.Forms.ListView()
        Me.chNo6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCar6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTime6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbWeather6 = New System.Windows.Forms.ComboBox()
        Me.cmbType6 = New System.Windows.Forms.ComboBox()
        Me.tp7 = New System.Windows.Forms.TabPage()
        Me.btnRefresh7 = New System.Windows.Forms.Button()
        Me.lv7 = New System.Windows.Forms.ListView()
        Me.chNo7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCar7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTime7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCourse7 = New System.Windows.Forms.ComboBox()
        Me.cmbWeather7 = New System.Windows.Forms.ComboBox()
        Me.cmbType7 = New System.Windows.Forms.ComboBox()
        Me.tcGames.SuspendLayout()
        Me.tp6.SuspendLayout()
        Me.tp7.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcGames
        '
        Me.tcGames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcGames.Controls.Add(Me.tp6)
        Me.tcGames.Controls.Add(Me.tp7)
        Me.tcGames.Location = New System.Drawing.Point(12, 12)
        Me.tcGames.Name = "tcGames"
        Me.tcGames.SelectedIndex = 0
        Me.tcGames.Size = New System.Drawing.Size(760, 538)
        Me.tcGames.TabIndex = 0
        '
        'tp6
        '
        Me.tp6.Controls.Add(Me.btnRefresh6)
        Me.tp6.Controls.Add(Me.Label2)
        Me.tp6.Controls.Add(Me.Label1)
        Me.tp6.Controls.Add(Me.Label3)
        Me.tp6.Controls.Add(Me.cmbCourse6)
        Me.tp6.Controls.Add(Me.lv6)
        Me.tp6.Controls.Add(Me.cmbWeather6)
        Me.tp6.Controls.Add(Me.cmbType6)
        Me.tp6.Location = New System.Drawing.Point(4, 24)
        Me.tp6.Name = "tp6"
        Me.tp6.Padding = New System.Windows.Forms.Padding(3)
        Me.tp6.Size = New System.Drawing.Size(752, 510)
        Me.tp6.TabIndex = 0
        Me.tp6.Text = "Initial D 6 AA"
        Me.tp6.UseVisualStyleBackColor = True
        '
        'btnRefresh6
        '
        Me.btnRefresh6.Location = New System.Drawing.Point(615, 6)
        Me.btnRefresh6.Name = "btnRefresh6"
        Me.btnRefresh6.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh6.TabIndex = 4
        Me.btnRefresh6.Text = "Refresh"
        Me.btnRefresh6.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(412, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Weather"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Course"
        '
        'cmbCourse6
        '
        Me.cmbCourse6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse6.FormattingEnabled = True
        Me.cmbCourse6.Location = New System.Drawing.Point(83, 6)
        Me.cmbCourse6.Name = "cmbCourse6"
        Me.cmbCourse6.Size = New System.Drawing.Size(120, 23)
        Me.cmbCourse6.TabIndex = 1
        '
        'lv6
        '
        Me.lv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv6.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNo6, Me.chName6, Me.chCar6, Me.chTime6})
        Me.lv6.GridLines = True
        Me.lv6.Location = New System.Drawing.Point(6, 35)
        Me.lv6.MultiSelect = False
        Me.lv6.Name = "lv6"
        Me.lv6.Size = New System.Drawing.Size(740, 469)
        Me.lv6.TabIndex = 0
        Me.lv6.UseCompatibleStateImageBehavior = False
        Me.lv6.View = System.Windows.Forms.View.Details
        '
        'chNo6
        '
        Me.chNo6.Text = "No."
        '
        'chName6
        '
        Me.chName6.Text = "Name"
        Me.chName6.Width = 150
        '
        'chCar6
        '
        Me.chCar6.Text = "Car"
        Me.chCar6.Width = 200
        '
        'chTime6
        '
        Me.chTime6.Text = "Time"
        Me.chTime6.Width = 100
        '
        'cmbWeather6
        '
        Me.cmbWeather6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeather6.FormattingEnabled = True
        Me.cmbWeather6.Location = New System.Drawing.Point(489, 6)
        Me.cmbWeather6.Name = "cmbWeather6"
        Me.cmbWeather6.Size = New System.Drawing.Size(120, 23)
        Me.cmbWeather6.TabIndex = 3
        '
        'cmbType6
        '
        Me.cmbType6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType6.FormattingEnabled = True
        Me.cmbType6.Location = New System.Drawing.Point(286, 6)
        Me.cmbType6.Name = "cmbType6"
        Me.cmbType6.Size = New System.Drawing.Size(120, 23)
        Me.cmbType6.TabIndex = 2
        '
        'tp7
        '
        Me.tp7.Controls.Add(Me.btnRefresh7)
        Me.tp7.Controls.Add(Me.lv7)
        Me.tp7.Controls.Add(Me.Label4)
        Me.tp7.Controls.Add(Me.Label5)
        Me.tp7.Controls.Add(Me.Label6)
        Me.tp7.Controls.Add(Me.cmbCourse7)
        Me.tp7.Controls.Add(Me.cmbWeather7)
        Me.tp7.Controls.Add(Me.cmbType7)
        Me.tp7.Location = New System.Drawing.Point(4, 24)
        Me.tp7.Name = "tp7"
        Me.tp7.Padding = New System.Windows.Forms.Padding(3)
        Me.tp7.Size = New System.Drawing.Size(752, 510)
        Me.tp7.TabIndex = 1
        Me.tp7.Text = "Initial D 7 AAX"
        Me.tp7.UseVisualStyleBackColor = True
        '
        'btnRefresh7
        '
        Me.btnRefresh7.Location = New System.Drawing.Point(615, 6)
        Me.btnRefresh7.Name = "btnRefresh7"
        Me.btnRefresh7.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh7.TabIndex = 14
        Me.btnRefresh7.Text = "Refresh"
        Me.btnRefresh7.UseVisualStyleBackColor = True
        '
        'lv7
        '
        Me.lv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv7.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNo7, Me.chName7, Me.chCar7, Me.chTime7})
        Me.lv7.GridLines = True
        Me.lv7.Location = New System.Drawing.Point(6, 35)
        Me.lv7.MultiSelect = False
        Me.lv7.Name = "lv7"
        Me.lv7.Size = New System.Drawing.Size(740, 469)
        Me.lv7.TabIndex = 16
        Me.lv7.UseCompatibleStateImageBehavior = False
        Me.lv7.View = System.Windows.Forms.View.Details
        '
        'chNo7
        '
        Me.chNo7.Text = "No."
        '
        'chName7
        '
        Me.chName7.Text = "Name"
        Me.chName7.Width = 150
        '
        'chCar7
        '
        Me.chCar7.Text = "Car"
        Me.chCar7.Width = 200
        '
        'chTime7
        '
        Me.chTime7.Text = "Time"
        Me.chTime7.Width = 100
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(412, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Weather"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(209, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Course"
        '
        'cmbCourse7
        '
        Me.cmbCourse7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse7.FormattingEnabled = True
        Me.cmbCourse7.Location = New System.Drawing.Point(83, 6)
        Me.cmbCourse7.Name = "cmbCourse7"
        Me.cmbCourse7.Size = New System.Drawing.Size(120, 23)
        Me.cmbCourse7.TabIndex = 11
        '
        'cmbWeather7
        '
        Me.cmbWeather7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeather7.FormattingEnabled = True
        Me.cmbWeather7.Location = New System.Drawing.Point(489, 6)
        Me.cmbWeather7.Name = "cmbWeather7"
        Me.cmbWeather7.Size = New System.Drawing.Size(120, 23)
        Me.cmbWeather7.TabIndex = 13
        '
        'cmbType7
        '
        Me.cmbType7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType7.FormattingEnabled = True
        Me.cmbType7.Location = New System.Drawing.Point(286, 6)
        Me.cmbType7.Name = "cmbType7"
        Me.cmbType7.Size = New System.Drawing.Size(120, 23)
        Me.cmbType7.TabIndex = 12
        '
        'frmLeaderboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.tcGames)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeaderboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Attack Leaderboard"
        Me.tcGames.ResumeLayout(False)
        Me.tp6.ResumeLayout(False)
        Me.tp6.PerformLayout()
        Me.tp7.ResumeLayout(False)
        Me.tp7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcGames As TabControl
    Friend WithEvents tp6 As TabPage
    Friend WithEvents tp7 As TabPage
    Friend WithEvents lv6 As ListView
    Friend WithEvents chNo6 As ColumnHeader
    Friend WithEvents chName6 As ColumnHeader
    Friend WithEvents chCar6 As ColumnHeader
    Friend WithEvents chTime6 As ColumnHeader
    Friend WithEvents cmbWeather6 As ComboBox
    Friend WithEvents cmbType6 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCourse6 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lv7 As ListView
    Friend WithEvents chNo7 As ColumnHeader
    Friend WithEvents chName7 As ColumnHeader
    Friend WithEvents chCar7 As ColumnHeader
    Friend WithEvents chTime7 As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCourse7 As ComboBox
    Friend WithEvents cmbWeather7 As ComboBox
    Friend WithEvents cmbType7 As ComboBox
    Friend WithEvents btnRefresh6 As Button
    Friend WithEvents btnRefresh7 As Button
End Class
