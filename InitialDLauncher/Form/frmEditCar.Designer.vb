<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditCar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditCar))
        Me.NsTheme1 = New InitialDLauncher.NSTheme()
        Me.NsGroupBox3 = New InitialDLauncher.NSGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbSticker4 = New InitialDLauncher.NSComboBox()
        Me.cmbSticker3 = New InitialDLauncher.NSComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSticker2 = New InitialDLauncher.NSComboBox()
        Me.cmbSticker1 = New InitialDLauncher.NSComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NsGroupBox2 = New InitialDLauncher.NSGroupBox()
        Me.txtClassCode = New InitialDLauncher.NSTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbPlace = New InitialDLauncher.NSComboBox()
        Me.cmbHiragana = New InitialDLauncher.NSComboBox()
        Me.txtNumberPlate = New InitialDLauncher.NSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbColor = New InitialDLauncher.NSComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NsControlButton1 = New InitialDLauncher.NSControlButton()
        Me.NsGroupBox1 = New InitialDLauncher.NSGroupBox()
        Me.cmbRollbar = New InitialDLauncher.NSComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEngine = New InitialDLauncher.NSComboBox()
        Me.cbFullSpec = New InitialDLauncher.NSCheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCarList = New InitialDLauncher.NSComboBox()
        Me.btnSave = New InitialDLauncher.NSButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NsTheme1.SuspendLayout()
        Me.NsGroupBox3.SuspendLayout()
        Me.NsGroupBox2.SuspendLayout()
        Me.NsGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New InitialDLauncher.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsGroupBox3)
        Me.NsTheme1.Controls.Add(Me.NsGroupBox2)
        Me.NsTheme1.Controls.Add(Me.cmbColor)
        Me.NsTheme1.Controls.Add(Me.Label4)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.NsGroupBox1)
        Me.NsTheme1.Controls.Add(Me.cmbCarList)
        Me.NsTheme1.Controls.Add(Me.btnSave)
        Me.NsTheme1.Controls.Add(Me.Label3)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(374, 605)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 53
        Me.NsTheme1.Text = "Edit Car"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsGroupBox3
        '
        Me.NsGroupBox3.Controls.Add(Me.Label10)
        Me.NsGroupBox3.Controls.Add(Me.cmbSticker4)
        Me.NsGroupBox3.Controls.Add(Me.cmbSticker3)
        Me.NsGroupBox3.Controls.Add(Me.Label11)
        Me.NsGroupBox3.Controls.Add(Me.Label8)
        Me.NsGroupBox3.Controls.Add(Me.cmbSticker2)
        Me.NsGroupBox3.Controls.Add(Me.cmbSticker1)
        Me.NsGroupBox3.Controls.Add(Me.Label9)
        Me.NsGroupBox3.DrawSeperator = False
        Me.NsGroupBox3.Location = New System.Drawing.Point(12, 99)
        Me.NsGroupBox3.Name = "NsGroupBox3"
        Me.NsGroupBox3.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox3.Size = New System.Drawing.Size(350, 162)
        Me.NsGroupBox3.SubTitle = "Edit the Hidden Event Stickers of this car."
        Me.NsGroupBox3.TabIndex = 60
        Me.NsGroupBox3.Text = "NsGroupBox3"
        Me.NsGroupBox3.Title = "Event Stickers"
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 124)
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
        Me.cmbSticker4.Location = New System.Drawing.Point(104, 126)
        Me.cmbSticker4.Name = "cmbSticker4"
        Me.cmbSticker4.Size = New System.Drawing.Size(234, 24)
        Me.cmbSticker4.TabIndex = 13
        '
        'cmbSticker3
        '
        Me.cmbSticker3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSticker3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSticker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSticker3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSticker3.FormattingEnabled = True
        Me.cmbSticker3.Location = New System.Drawing.Point(104, 96)
        Me.cmbSticker3.Name = "cmbSticker3"
        Me.cmbSticker3.Size = New System.Drawing.Size(234, 24)
        Me.cmbSticker3.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 24)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Sticker 3"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 64)
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
        Me.cmbSticker2.Location = New System.Drawing.Point(104, 66)
        Me.cmbSticker2.Name = "cmbSticker2"
        Me.cmbSticker2.Size = New System.Drawing.Size(234, 24)
        Me.cmbSticker2.TabIndex = 11
        '
        'cmbSticker1
        '
        Me.cmbSticker1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbSticker1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSticker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSticker1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbSticker1.FormattingEnabled = True
        Me.cmbSticker1.Location = New System.Drawing.Point(104, 36)
        Me.cmbSticker1.Name = "cmbSticker1"
        Me.cmbSticker1.Size = New System.Drawing.Size(234, 24)
        Me.cmbSticker1.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 24)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Sticker 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NsGroupBox2
        '
        Me.NsGroupBox2.Controls.Add(Me.txtClassCode)
        Me.NsGroupBox2.Controls.Add(Me.Label12)
        Me.NsGroupBox2.Controls.Add(Me.Label7)
        Me.NsGroupBox2.Controls.Add(Me.cmbPlace)
        Me.NsGroupBox2.Controls.Add(Me.cmbHiragana)
        Me.NsGroupBox2.Controls.Add(Me.txtNumberPlate)
        Me.NsGroupBox2.Controls.Add(Me.Label5)
        Me.NsGroupBox2.Controls.Add(Me.Label6)
        Me.NsGroupBox2.DrawSeperator = False
        Me.NsGroupBox2.Location = New System.Drawing.Point(12, 267)
        Me.NsGroupBox2.Name = "NsGroupBox2"
        Me.NsGroupBox2.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox2.Size = New System.Drawing.Size(350, 160)
        Me.NsGroupBox2.SubTitle = "Edit the Number Plate of this car."
        Me.NsGroupBox2.TabIndex = 59
        Me.NsGroupBox2.Text = "NsGroupBox2"
        Me.NsGroupBox2.Title = "Number Plate"
        '
        'txtClassCode
        '
        Me.txtClassCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClassCode.Location = New System.Drawing.Point(104, 66)
        Me.txtClassCode.MaxLength = 3
        Me.txtClassCode.Multiline = False
        Me.txtClassCode.Name = "txtClassCode"
        Me.txtClassCode.ReadOnly = False
        Me.txtClassCode.Size = New System.Drawing.Size(234, 24)
        Me.txtClassCode.TabIndex = 21
        Me.txtClassCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtClassCode.UseSystemPasswordChar = False
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 24)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "Class Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 124)
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
        Me.cmbPlace.Location = New System.Drawing.Point(104, 126)
        Me.cmbPlace.Name = "cmbPlace"
        Me.cmbPlace.Size = New System.Drawing.Size(234, 24)
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
        Me.cmbHiragana.Location = New System.Drawing.Point(104, 96)
        Me.cmbHiragana.Name = "cmbHiragana"
        Me.cmbHiragana.Size = New System.Drawing.Size(234, 24)
        Me.cmbHiragana.TabIndex = 22
        '
        'txtNumberPlate
        '
        Me.txtNumberPlate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumberPlate.Location = New System.Drawing.Point(104, 36)
        Me.txtNumberPlate.MaxLength = 5
        Me.txtNumberPlate.Multiline = False
        Me.txtNumberPlate.Name = "txtNumberPlate"
        Me.txtNumberPlate.ReadOnly = False
        Me.txtNumberPlate.Size = New System.Drawing.Size(234, 24)
        Me.txtNumberPlate.TabIndex = 20
        Me.txtNumberPlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNumberPlate.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 24)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Hiragana"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 24)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Plate Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(81, 69)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(269, 24)
        Me.cmbColor.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Color"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = InitialDLauncher.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(351, 3)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 56
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'NsGroupBox1
        '
        Me.NsGroupBox1.Controls.Add(Me.cmbRollbar)
        Me.NsGroupBox1.Controls.Add(Me.Label2)
        Me.NsGroupBox1.Controls.Add(Me.cmbEngine)
        Me.NsGroupBox1.Controls.Add(Me.cbFullSpec)
        Me.NsGroupBox1.Controls.Add(Me.Label1)
        Me.NsGroupBox1.DrawSeperator = False
        Me.NsGroupBox1.Location = New System.Drawing.Point(12, 433)
        Me.NsGroupBox1.Name = "NsGroupBox1"
        Me.NsGroupBox1.Padding = New System.Windows.Forms.Padding(3, 33, 3, 3)
        Me.NsGroupBox1.Size = New System.Drawing.Size(350, 129)
        Me.NsGroupBox1.SubTitle = "Edit this might overwrite your Visual Parts"
        Me.NsGroupBox1.TabIndex = 53
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = "Performance Parts"
        '
        'cmbRollbar
        '
        Me.cmbRollbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbRollbar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRollbar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRollbar.Enabled = False
        Me.cmbRollbar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbRollbar.FormattingEnabled = True
        Me.cmbRollbar.Location = New System.Drawing.Point(104, 93)
        Me.cmbRollbar.Name = "cmbRollbar"
        Me.cmbRollbar.Size = New System.Drawing.Size(234, 24)
        Me.cmbRollbar.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 24)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Select Rollcage"
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
        Me.cmbEngine.Location = New System.Drawing.Point(104, 63)
        Me.cmbEngine.Name = "cmbEngine"
        Me.cmbEngine.Size = New System.Drawing.Size(234, 24)
        Me.cmbEngine.TabIndex = 31
        '
        'cbFullSpec
        '
        Me.cbFullSpec.Checked = False
        Me.cbFullSpec.Location = New System.Drawing.Point(6, 36)
        Me.cbFullSpec.Name = "cbFullSpec"
        Me.cbFullSpec.Size = New System.Drawing.Size(161, 24)
        Me.cbFullSpec.TabIndex = 30
        Me.cbFullSpec.Text = "Save Performance Parts"
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Engine"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCarList
        '
        Me.cmbCarList.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCarList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCarList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmbCarList.FormattingEnabled = True
        Me.cmbCarList.Items.AddRange(New Object() {"", "TRUENO GT-APEX (AE86)", "LEVIN GT-APEX (AE86)", "LEVIN SR (AE85)", "86 GT (ZN6)", "MR2 G-Limited (SW20)", "MR-S (ZZW30)", "ALTEZZA RS200 (SXE10)", "SUPRA RZ (JZA80)", "PRIUS (ZVW30)", "SKYLINE GT-R (BNR32)", "SKYLINE GT-R (BNR34)", "SILVIA K's (S13)", "Silvia Q's (S14)", "Silvia spec-R (S15)", "180SX TYPE II (RPS13)", "FAIRLADY Z (Z33)", "GT-R (R35)", "Civic SiR・II (EG6)", "CIVIC TYPE R (EK9)", "INTEGRA TYPE R (DC2)", "S2000 (AP1)", "NSX (NA1)", "RX-7 ∞III (FC3S)", "RX-7 Type R (FD3S)", "RX-7 Type RS (FD3S)", "RX-8 Type S (SE3P)", "ROADSTER (NA6CE)", "ROADSTER RS (NB8C)", "IMPREZA STi Ver.V (GC8)", "IMPREZA STi (GDBA)", "IMPREZA STI (GDBF)", "LANCER Evolution III (CE9A)", "LANCER EVOLUTION IV (CN9A)", "LANCER Evolution VII (CT9A)", "LANCER Evolution IX (CT9A)", "LANCER EVOLUTION X (CZ4A)", "Cappuccino (EA11R)", "SILEIGHTY", "TRUENO 2door GT-APEX (AE86)", "G-FORCE SUPRA (JZA80-kai)", "MONSTER CIVIC R (EK9)", "NSX-R GT (NA2)", "RE Amemiya Genki-7 (FD3S)", "S2000 GT1 (AP1)", "ROADSTER C-SPEC (NA8C Kai)"})
        Me.cmbCarList.Location = New System.Drawing.Point(81, 39)
        Me.cmbCarList.Name = "cmbCarList"
        Me.cmbCarList.Size = New System.Drawing.Size(269, 24)
        Me.cmbCarList.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(287, 570)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 40
        Me.btnSave.Text = "Save"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Change to"
        '
        'frmEditCar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 605)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditCar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Car"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTheme1.PerformLayout()
        Me.NsGroupBox3.ResumeLayout(False)
        Me.NsGroupBox2.ResumeLayout(False)
        Me.NsGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbCarList As NSComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As NSButton
    Friend WithEvents cbFullSpec As NSCheckBox
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents NsGroupBox1 As NSGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEngine As NSComboBox
    Friend WithEvents cmbRollbar As NSComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NsControlButton1 As NSControlButton
    Friend WithEvents cmbColor As NSComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NsGroupBox2 As NSGroupBox
    Friend WithEvents txtNumberPlate As NSTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbHiragana As NSComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbPlace As NSComboBox
    Friend WithEvents NsGroupBox3 As NSGroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbSticker4 As NSComboBox
    Friend WithEvents cmbSticker3 As NSComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbSticker2 As NSComboBox
    Friend WithEvents cmbSticker1 As NSComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtClassCode As NSTextBox
    Friend WithEvents Label12 As Label
End Class
