<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CarCtrl
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
        Me.pbCar = New System.Windows.Forms.PictureBox()
        Me.lblCarName = New InitialDLauncher.SpecialLabel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbSticker4 = New InitialDLauncher.NSComboBox()
        Me.cmbSticker3 = New InitialDLauncher.NSComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSticker2 = New InitialDLauncher.NSComboBox()
        Me.cmbSticker1 = New InitialDLauncher.NSComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbColor = New InitialDLauncher.NSComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClassCode = New InitialDLauncher.NSTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbPlace = New InitialDLauncher.NSComboBox()
        Me.cmbHiragana = New InitialDLauncher.NSComboBox()
        Me.txtNumberPlate = New InitialDLauncher.NSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEngineRollbar = New InitialDLauncher.NSCheckBox()
        Me.cmbRollbar = New InitialDLauncher.NSComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEngine = New InitialDLauncher.NSComboBox()
        Me.cbFullSpec = New InitialDLauncher.NSCheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NsTabControl1 = New InitialDLauncher.NSTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSave = New InitialDLauncher.NSButton()
        Me.btnLoad = New InitialDLauncher.NSButton()
        Me.btnApply = New InitialDLauncher.NSButton()
        Me.NsGroupBox1 = New InitialDLauncher.NSGroupBox()
        CType(Me.pbCar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pbCar.SuspendLayout()
        Me.NsTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.NsGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbCar
        '
        Me.pbCar.BackColor = System.Drawing.Color.White
        Me.pbCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbCar.Controls.Add(Me.lblCarName)
        Me.pbCar.Location = New System.Drawing.Point(3, 3)
        Me.pbCar.Name = "pbCar"
        Me.pbCar.Size = New System.Drawing.Size(218, 127)
        Me.pbCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCar.TabIndex = 0
        Me.pbCar.TabStop = False
        '
        'lblCarName
        '
        Me.lblCarName.BackColor = System.Drawing.Color.Transparent
        Me.lblCarName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCarName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarName.ForeColor = System.Drawing.Color.Black
        Me.lblCarName.Location = New System.Drawing.Point(0, 0)
        Me.lblCarName.Name = "lblCarName"
        Me.lblCarName.P = Me.pbCar
        Me.lblCarName.Size = New System.Drawing.Size(216, 33)
        Me.lblCarName.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(4, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 24)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Sticker 4"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSticker4
        '
        Me.cmbSticker4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSticker4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSticker4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSticker4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSticker4.FormattingEnabled = True
        Me.cmbSticker4.Location = New System.Drawing.Point(101, 96)
        Me.cmbSticker4.Name = "cmbSticker4"
        Me.cmbSticker4.Size = New System.Drawing.Size(150, 24)
        Me.cmbSticker4.TabIndex = 13
        '
        'cmbSticker3
        '
        Me.cmbSticker3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSticker3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSticker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSticker3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSticker3.FormattingEnabled = True
        Me.cmbSticker3.Location = New System.Drawing.Point(101, 66)
        Me.cmbSticker3.Name = "cmbSticker3"
        Me.cmbSticker3.Size = New System.Drawing.Size(150, 24)
        Me.cmbSticker3.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(4, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 24)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Sticker 3"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(4, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 24)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Sticker 2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSticker2
        '
        Me.cmbSticker2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSticker2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSticker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSticker2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSticker2.FormattingEnabled = True
        Me.cmbSticker2.Location = New System.Drawing.Point(101, 36)
        Me.cmbSticker2.Name = "cmbSticker2"
        Me.cmbSticker2.Size = New System.Drawing.Size(150, 24)
        Me.cmbSticker2.TabIndex = 11
        '
        'cmbSticker1
        '
        Me.cmbSticker1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSticker1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSticker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSticker1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSticker1.FormattingEnabled = True
        Me.cmbSticker1.Location = New System.Drawing.Point(101, 6)
        Me.cmbSticker1.Name = "cmbSticker1"
        Me.cmbSticker1.Size = New System.Drawing.Size(150, 24)
        Me.cmbSticker1.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 24)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Sticker 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(46, 136)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(175, 24)
        Me.cmbColor.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(4, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Color"
        '
        'txtClassCode
        '
        Me.txtClassCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClassCode.Location = New System.Drawing.Point(101, 36)
        Me.txtClassCode.MaxLength = 3
        Me.txtClassCode.Multiline = False
        Me.txtClassCode.Name = "txtClassCode"
        Me.txtClassCode.ReadOnly = False
        Me.txtClassCode.Size = New System.Drawing.Size(150, 24)
        Me.txtClassCode.TabIndex = 21
        Me.txtClassCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtClassCode.ToolTip = Nothing
        Me.txtClassCode.UseSystemPasswordChar = False
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 24)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "Class Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 24)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Place Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPlace
        '
        Me.cmbPlace.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbPlace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlace.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbPlace.FormattingEnabled = True
        Me.cmbPlace.Items.AddRange(New Object() {"札幌", "函館", "旭川", "室蘭", "釧路", "帯広", "北見", "青森", "八戸", "岩手", "宮城", "仙台", "福島", "いわき", "会津", "山形", "庄内", "秋田", "水戸", "土浦", "つくば", "栃木", "宇都宮", "とちぎ", "那須", "群馬", "高崎", "千葉", "野田", "習志野", "袖ヶ浦", "成田", "柏", "大宮", "熊谷", "春日部", "所沢", "川越", "品川", "足立", "練馬", "多摩", "八王子", "横浜", "川崎", "相模", "湘南", "山梨", "新潟", "長岡", "長野", "松本", "諏訪", "富山", "石川", "金沢", "名古屋", "三河", "尾張小牧", "豊橋", "豊田", "岡崎", "一宮", "静岡", "沼津", "浜松", "伊豆", "岐阜", "飛騨", "三重", "鈴鹿", "福井", "大阪", "なにわ", "和泉", "堺", "京都", "奈良", "滋賀", "和歌山", "神戸", "姫路", "広島", "福山", "鳥取", "島根", "岡山", "倉敷", "山口", "下関", "徳島", "香川", "愛媛", "高知", "福岡", "北九州", "筑豊", "久留米", "佐賀", "長崎", "佐世保", "熊本", "大分", "宮崎", "鹿児島", "沖縄", "富士山"})
        Me.cmbPlace.Location = New System.Drawing.Point(101, 96)
        Me.cmbPlace.Name = "cmbPlace"
        Me.cmbPlace.Size = New System.Drawing.Size(150, 24)
        Me.cmbPlace.TabIndex = 23
        '
        'cmbHiragana
        '
        Me.cmbHiragana.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbHiragana.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbHiragana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHiragana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbHiragana.FormattingEnabled = True
        Me.cmbHiragana.Items.AddRange(New Object() {"あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ", "を", "ん", "が", "ぎ", "ぐ", "げ", "ご", "ざ", "じ", "ず", "ぜ", "ぞ", "だ", "ぢ", "づ", "で", "ど", "ば", "び", "ぶ", "べ", "ぼ", "ぱ", "ぴ", "ぷ", "ぺ", "ぽ", "さ"})
        Me.cmbHiragana.Location = New System.Drawing.Point(101, 66)
        Me.cmbHiragana.Name = "cmbHiragana"
        Me.cmbHiragana.Size = New System.Drawing.Size(150, 24)
        Me.cmbHiragana.TabIndex = 22
        '
        'txtNumberPlate
        '
        Me.txtNumberPlate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumberPlate.Location = New System.Drawing.Point(101, 6)
        Me.txtNumberPlate.MaxLength = 5
        Me.txtNumberPlate.Multiline = False
        Me.txtNumberPlate.Name = "txtNumberPlate"
        Me.txtNumberPlate.ReadOnly = False
        Me.txtNumberPlate.Size = New System.Drawing.Size(150, 24)
        Me.txtNumberPlate.TabIndex = 20
        Me.txtNumberPlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNumberPlate.ToolTip = Nothing
        Me.txtNumberPlate.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 24)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Hiragana"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 24)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Plate Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEngineRollbar
        '
        Me.cbEngineRollbar.Checked = False
        Me.cbEngineRollbar.Enabled = False
        Me.cbEngineRollbar.Location = New System.Drawing.Point(6, 36)
        Me.cbEngineRollbar.Name = "cbEngineRollbar"
        Me.cbEngineRollbar.Size = New System.Drawing.Size(161, 24)
        Me.cbEngineRollbar.TabIndex = 54
        Me.cbEngineRollbar.Text = "Save Engine & Rollbar"
        '
        'cmbRollbar
        '
        Me.cmbRollbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbRollbar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRollbar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRollbar.Enabled = False
        Me.cmbRollbar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbRollbar.FormattingEnabled = True
        Me.cmbRollbar.Location = New System.Drawing.Point(101, 96)
        Me.cmbRollbar.Name = "cmbRollbar"
        Me.cmbRollbar.Size = New System.Drawing.Size(150, 24)
        Me.cmbRollbar.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 24)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Select Rollbar"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEngine
        '
        Me.cmbEngine.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbEngine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEngine.Enabled = False
        Me.cmbEngine.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbEngine.FormattingEnabled = True
        Me.cmbEngine.Location = New System.Drawing.Point(101, 68)
        Me.cmbEngine.Name = "cmbEngine"
        Me.cmbEngine.Size = New System.Drawing.Size(150, 24)
        Me.cmbEngine.TabIndex = 31
        '
        'cbFullSpec
        '
        Me.cbFullSpec.Checked = False
        Me.cbFullSpec.Location = New System.Drawing.Point(6, 6)
        Me.cbFullSpec.Name = "cbFullSpec"
        Me.cbFullSpec.Size = New System.Drawing.Size(161, 24)
        Me.cbFullSpec.TabIndex = 30
        Me.cbFullSpec.Text = "Save Performance Parts"
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Engine"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NsTabControl1
        '
        Me.NsTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.NsTabControl1.Controls.Add(Me.TabPage1)
        Me.NsTabControl1.Controls.Add(Me.TabPage2)
        Me.NsTabControl1.Controls.Add(Me.TabPage3)
        Me.NsTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.NsTabControl1.ItemSize = New System.Drawing.Size(50, 110)
        Me.NsTabControl1.Location = New System.Drawing.Point(227, 3)
        Me.NsTabControl1.Multiline = True
        Me.NsTabControl1.Name = "NsTabControl1"
        Me.NsTabControl1.SelectedIndex = 0
        Me.NsTabControl1.Size = New System.Drawing.Size(375, 157)
        Me.NsTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.NsTabControl1.TabIndex = 66
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cmbSticker1)
        Me.TabPage1.Controls.Add(Me.cmbSticker4)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cmbSticker3)
        Me.TabPage1.Controls.Add(Me.cmbSticker2)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Location = New System.Drawing.Point(114, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(257, 149)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Event Stickers"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.txtClassCode)
        Me.TabPage2.Controls.Add(Me.txtNumberPlate)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.cmbPlace)
        Me.TabPage2.Controls.Add(Me.cmbHiragana)
        Me.TabPage2.Location = New System.Drawing.Point(114, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(257, 149)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Number Plate"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.cmbRollbar)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.cbEngineRollbar)
        Me.TabPage3.Controls.Add(Me.cbFullSpec)
        Me.TabPage3.Controls.Add(Me.cmbEngine)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Location = New System.Drawing.Point(114, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(257, 149)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Performance    Parts"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(608, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 24)
        Me.btnSave.TabIndex = 67
        Me.btnSave.Text = "Save"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(608, 33)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(65, 24)
        Me.btnLoad.TabIndex = 68
        Me.btnLoad.Text = "Load"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(608, 115)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(65, 45)
        Me.btnApply.TabIndex = 69
        Me.btnApply.Text = "Apply"
        '
        'NsGroupBox1
        '
        Me.NsGroupBox1.Controls.Add(Me.btnApply)
        Me.NsGroupBox1.Controls.Add(Me.pbCar)
        Me.NsGroupBox1.Controls.Add(Me.btnLoad)
        Me.NsGroupBox1.Controls.Add(Me.Label4)
        Me.NsGroupBox1.Controls.Add(Me.btnSave)
        Me.NsGroupBox1.Controls.Add(Me.cmbColor)
        Me.NsGroupBox1.Controls.Add(Me.NsTabControl1)
        Me.NsGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsGroupBox1.DrawSeperator = False
        Me.NsGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.NsGroupBox1.Name = "NsGroupBox1"
        Me.NsGroupBox1.Size = New System.Drawing.Size(676, 163)
        Me.NsGroupBox1.SubTitle = ""
        Me.NsGroupBox1.TabIndex = 70
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = ""
        '
        'CarCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Controls.Add(Me.NsGroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "CarCtrl"
        Me.Size = New System.Drawing.Size(676, 163)
        CType(Me.pbCar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pbCar.ResumeLayout(False)
        Me.NsTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.NsGroupBox1.ResumeLayout(False)
        Me.NsGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbCar As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbSticker4 As NSComboBox
    Friend WithEvents cmbSticker3 As NSComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbSticker2 As NSComboBox
    Friend WithEvents cmbSticker1 As NSComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCarName As SpecialLabel
    Friend WithEvents cmbColor As NSComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtClassCode As NSTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbPlace As NSComboBox
    Friend WithEvents cmbHiragana As NSComboBox
    Friend WithEvents txtNumberPlate As NSTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEngineRollbar As NSCheckBox
    Friend WithEvents cmbRollbar As NSComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEngine As NSComboBox
    Friend WithEvents cbFullSpec As NSCheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NsTabControl1 As NSTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnSave As NSButton
    Friend WithEvents btnLoad As NSButton
    Friend WithEvents btnApply As NSButton
    Friend WithEvents NsGroupBox1 As NSGroupBox
End Class
