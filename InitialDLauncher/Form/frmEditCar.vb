Imports System.IO

Public Class frmEditCar

    Private _version As Integer
    Public Property Version() As Integer
        Get
            Return _version
        End Get
        Set(value As Integer)
            _version = value
        End Set
    End Property

    Private _filename As String
    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Private _extension As String
    Public Property Extension() As String
        Get
            Return _extension
        End Get
        Set(value As String)
            _extension = value
        End Set
    End Property

    Private _slot As Integer
    Public Property CarSlot() As Integer
        Get
            Return _slot
        End Get
        Set(value As Integer)
            _slot = value
        End Set
    End Property

    Private _carname As String
    Public Property CarName() As String
        Get
            Return _carname
        End Get
        Set(value As String)
            _carname = value
        End Set
    End Property

    Private _car As Car
    Public Property Car() As Car
        Get
            Return _car
        End Get
        Set(value As Car)
            _car = value
        End Set
    End Property

    Public _parentForm As frmEdit
    Dim parameter As String
    Dim engine, engineName, rollbar, rollbarName, carColor, carColorName, sticker, stickerName As List(Of String)
    Dim tuple As Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))
    Dim colTuple As Tuple(Of String, List(Of String), List(Of String))
    Dim stkTuple As Tuple(Of String, List(Of String), List(Of String))

    'translate
    Dim import_complete As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Car files (*.car)|*.car"
            sfd.FilterIndex = 1
            sfd.RestoreDirectory = True
            sfd.InitialDirectory = My.Application.Info.DirectoryPath
            If sfd.ShowDialog() = DialogResult.OK Then
                If Not File.Exists(sfd.FileName) Then File.Create(sfd.FileName).Close()
                Select Case _extension
                    Case "crd"
                        Select Case _slot
                            Case 1
                                SetHex(sfd.FileName, &H0, GetHex(_filename, &HC4, 96))
                            Case 2
                                SetHex(sfd.FileName, &H0, GetHex(_filename, &H124, 96))
                            Case 3
                                SetHex(sfd.FileName, &H0, GetHex(_filename, &H184, 96))
                        End Select
                    Case "bin"
                        Select Case _slot
                            Case 1
                                SetHex(sfd.FileName, &H0, GetHex(_filename, Plus3C(&HC4), 96))
                            Case 2
                                SetHex(sfd.FileName, &H0, GetHex(_filename, Plus3C(&H124), 96))
                            Case 3
                                SetHex(sfd.FileName, &H0, GetHex(_filename, Plus3C(&H184), 96))
                        End Select
                End Select

                Me.Close()
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Filter = "Car files (*.car)|*.car"
            ofd.FilterIndex = 1
            ofd.RestoreDirectory = True
            ofd.InitialDirectory = My.Application.Info.DirectoryPath
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim newFileName As String = String.Format("{0}\{1}.bak", Path.GetDirectoryName(_filename), Path.GetFileName(_filename))
                File.Copy(_filename, newFileName, True)
                Select Case _extension
                    Case "crd"
                        Select Case _slot
                            Case 1
                                SetHex(_filename, &HC4, GetHex(ofd.FileName, &H0, 96))
                                '_parentForm.cmbCar1.Text = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 6)
                            Case 2
                                SetHex(_filename, &H124, GetHex(ofd.FileName, &H0, 96))
                                '_parentForm.cmbCar2.Text = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 6)
                            Case 3
                                SetHex(_filename, &H184, GetHex(ofd.FileName, &H0, 96))
                                ' _parentForm.cmbCar3.Text = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 6)
                        End Select
                    Case "bin"
                        Select Case _slot
                            Case 1
                                SetHex(_filename, Plus3C(&HC4), GetHex(ofd.FileName, &H0, 96))
                               ' _parentForm.cmbCar1.Text = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 6)
                            Case 2
                                SetHex(_filename, Plus3C(&H124), GetHex(ofd.FileName, &H0, 96))
                               ' _parentForm.cmbCar2.Text = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 6)
                            Case 3
                                SetHex(_filename, Plus3C(&H184), GetHex(ofd.FileName, &H0, 96))
                                ' _parentForm.cmbCar3.Text = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 6)
                        End Select
                End Select
                NSMessageBox.ShowOk(import_complete, MsgBoxStyle.Information, Me.Text)
                Me.Close()
                _parentForm.Close()
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub cbEngineRollbar_CheckedChanged(sender As Object) Handles cbEngineRollbar.CheckedChanged
        cmbEngine.Enabled = cbFullSpec.Checked
        cmbRollbar.Enabled = cbFullSpec.Checked
        Label1.Enabled = cbFullSpec.Checked
        Label2.Enabled = cbFullSpec.Checked
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Me.Text = ReadCfgValue("EditCarMeText", langFile) & _carname & "[" & _slot & "]"
            NsTheme1.Text = Me.Text
            Label3.Text = ReadCfgValue("ReplaceTo", langFile)
            cbFullSpec.Text = ReadCfgValue("UnlockFullspec", langFile)
            cbEngineRollbar.Text = ReadCfgValue("EngineRollbar", langFile)
            NsGroupBox1.Title = ReadCfgValue("PerformancePart", langFile)
            Label1.Text = ReadCfgValue("SelectEngine", langFile)
            Label2.Text = ReadCfgValue("SelectRollbar", langFile)
            Label4.Text = ReadCfgValue("Color", langFile)
            btnApply.Text = ReadCfgValue("Apply", langFile)
            Label6.Text = ReadCfgValue("PlateNum", langFile)
            Label5.Text = ReadCfgValue("Hiragana", langFile)
            Label7.Text = ReadCfgValue("PlaceName", langFile)
            NsGroupBox2.Title = ReadCfgValue("NumPlate", langFile)
            NsGroupBox3.Title = ReadCfgValue("EventSticker", langFile)
            Label9.Text = ReadCfgValue("Sticker1", langFile)
            Label8.Text = ReadCfgValue("Sticker2", langFile)
            Label11.Text = ReadCfgValue("Sticker3", langFile)
            Label10.Text = ReadCfgValue("Sticker4", langFile)
            Label12.Text = ReadCfgValue("ClassCode", langFile)
            btnSave.Text = ReadCfgValue("ExportBtn", langFile)
            btnLoad.Text = ReadCfgValue("ImportBtn", langFile)
            import_complete = ReadCfgValue("ImportComplete", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmEditCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Translate()

            Select Case _version
                Case 6
                    'TOYOTA
                    cmbCarList.Items.Add("TRUENO GT-APEX (AE86)")
                    cmbCarList.Items.Add("LEVIN GT-APEX (AE86)")
                    cmbCarList.Items.Add("LEVIN SR (AE85)")
                    cmbCarList.Items.Add("FT-86 G Sports Concept")
                    cmbCarList.Items.Add("MR2 G-Limited (SW20)")
                    cmbCarList.Items.Add("MR-S (ZZW30)")
                    cmbCarList.Items.Add("ALTEZZA RS200 (SXE10)")
                    cmbCarList.Items.Add("SUPRA RZ (JZA80)")
                    cmbCarList.Items.Add("PRIUS (ZVW30)")
                    'NISSAN
                    cmbCarList.Items.Add("SKYLINE GT-R (BNR32)")
                    cmbCarList.Items.Add("SKYLINE GT-R (BNR34)")
                    cmbCarList.Items.Add("SILVIA K's (S13)")
                    cmbCarList.Items.Add("Silvia Q's (S14)")
                    cmbCarList.Items.Add("Silvia spec-R (S15)")
                    cmbCarList.Items.Add("180SX TYPE II (RPS13)")
                    cmbCarList.Items.Add("FAIRLADY Z (Z33)")
                    cmbCarList.Items.Add("GT-R (R35)")
                    'HONDA
                    cmbCarList.Items.Add("Civic SiR・II (EG6)")
                    cmbCarList.Items.Add("CIVIC TYPE R (EK9)")
                    cmbCarList.Items.Add("INTEGRA TYPE R (DC2)")
                    cmbCarList.Items.Add("S2000 (AP1)")
                    cmbCarList.Items.Add("NSX (NA1)")
                    'MAZDA
                    cmbCarList.Items.Add("RX-7 ∞III (FC3S)")
                    cmbCarList.Items.Add("RX-7 Type R (FD3S)")
                    cmbCarList.Items.Add("RX-7 Type RS (FD3S)")
                    cmbCarList.Items.Add("RX-8 Type S (SE3P)")
                    cmbCarList.Items.Add("ROADSTER (NA6CE)")
                    cmbCarList.Items.Add("ROADSTER RS (NB8C)")
                    'SUBARU
                    cmbCarList.Items.Add("IMPREZA STi Ver.V (GC8)")
                    cmbCarList.Items.Add("IMPREZA STI (GDBF)")
                    'MITSUBISHI
                    cmbCarList.Items.Add("LANCER Evolution III (CE9A)")
                    cmbCarList.Items.Add("LANCER EVOLUTION IV (CN9A)")
                    cmbCarList.Items.Add("LANCER Evolution VII (CT9A)")
                    cmbCarList.Items.Add("LANCER Evolution IX (CT9A)")
                    cmbCarList.Items.Add("LANCER EVOLUTION X (CZ4A)")
                    'SUZUKI
                    cmbCarList.Items.Add("Cappuccino (EA11R)")
                    'INITIALD
                    cmbCarList.Items.Add("SILEIGHTY")
                Case 7
                    'TOYOTA
                    cmbCarList.Items.Add("TRUENO GT-APEX (AE86)")
                    cmbCarList.Items.Add("LEVIN GT-APEX (AE86)")
                    cmbCarList.Items.Add("LEVIN SR (AE85)")
                    cmbCarList.Items.Add("86 GT (ZN6)")
                    cmbCarList.Items.Add("MR2 G-Limited (SW20)")
                    cmbCarList.Items.Add("MR-S (ZZW30)")
                    cmbCarList.Items.Add("ALTEZZA RS200 (SXE10)")
                    cmbCarList.Items.Add("SUPRA RZ (JZA80)")
                    cmbCarList.Items.Add("PRIUS (ZVW30)")
                    cmbCarList.Items.Add("TRUENO 2door GT-APEX (AE86)")
                    'NISSAN
                    cmbCarList.Items.Add("SKYLINE GT-R (BNR32)")
                    cmbCarList.Items.Add("SKYLINE GT-R (BNR34)")
                    cmbCarList.Items.Add("SILVIA K's (S13)")
                    cmbCarList.Items.Add("Silvia Q's (S14)")
                    cmbCarList.Items.Add("Silvia spec-R (S15)")
                    cmbCarList.Items.Add("180SX TYPE II (RPS13)")
                    cmbCarList.Items.Add("FAIRLADY Z (Z33)")
                    cmbCarList.Items.Add("GT-R (R35)")
                    'HONDA
                    cmbCarList.Items.Add("Civic SiR・II (EG6)")
                    cmbCarList.Items.Add("CIVIC TYPE R (EK9)")
                    cmbCarList.Items.Add("INTEGRA TYPE R (DC2)")
                    cmbCarList.Items.Add("S2000 (AP1)")
                    cmbCarList.Items.Add("NSX (NA1)")
                    'MAZDA
                    cmbCarList.Items.Add("RX-7 ∞III (FC3S)")
                    cmbCarList.Items.Add("RX-7 Type R (FD3S)")
                    cmbCarList.Items.Add("RX-7 Type RS (FD3S)")
                    cmbCarList.Items.Add("RX-8 Type S (SE3P)")
                    cmbCarList.Items.Add("ROADSTER (NA6CE)")
                    cmbCarList.Items.Add("ROADSTER RS (NB8C)")
                    'SUBARU
                    cmbCarList.Items.Add("IMPREZA STi Ver.V (GC8)")
                    cmbCarList.Items.Add("IMPREZA STi (GDBA)")
                    cmbCarList.Items.Add("IMPREZA STI (GDBF)")
                    'MITSUBISHI
                    cmbCarList.Items.Add("LANCER Evolution III (CE9A)")
                    cmbCarList.Items.Add("LANCER EVOLUTION IV (CN9A)")
                    cmbCarList.Items.Add("LANCER Evolution VII (CT9A)")
                    cmbCarList.Items.Add("LANCER Evolution IX (CT9A)")
                    cmbCarList.Items.Add("LANCER EVOLUTION X (CZ4A)")
                    'SUZUKI
                    cmbCarList.Items.Add("Cappuccino (EA11R)")
                    'INITIALD
                    cmbCarList.Items.Add("SILEIGHTY")
                    'COMPLETE CAR
                    cmbCarList.Items.Add("G-FORCE SUPRA (JZA80-kai)")
                    cmbCarList.Items.Add("MONSTER CIVIC R (EK9)")
                    cmbCarList.Items.Add("NSX-R GT (NA2)")
                    cmbCarList.Items.Add("RE Amemiya Genki-7 (FD3S)")
                    cmbCarList.Items.Add("S2000 GT1 (AP1)")
                    cmbCarList.Items.Add("ROADSTER C-SPEC (NA8C Kai)")
                Case 8
                    'TOYOTA
                    cmbCarList.Items.Add("TRUENO GT-APEX (AE86)")
                    cmbCarList.Items.Add("LEVIN GT-APEX (AE86)")
                    cmbCarList.Items.Add("LEVIN SR (AE85)")
                    cmbCarList.Items.Add("86 GT (ZN6)")
                    cmbCarList.Items.Add("MR2 G-Limited (SW20)")
                    cmbCarList.Items.Add("MR-S (ZZW30)")
                    cmbCarList.Items.Add("ALTEZZA RS200 (SXE10)")
                    cmbCarList.Items.Add("SUPRA RZ (JZA80)")
                    cmbCarList.Items.Add("PRIUS (ZVW30)")
                    cmbCarList.Items.Add("SPRINTER TRUENO 2door GT-APEX (AE86)")
                    cmbCarList.Items.Add("CELICA GT-FOUR (ST205)")
                    'NISSAN
                    cmbCarList.Items.Add("SKYLINE GT-R (BNR32)")
                    cmbCarList.Items.Add("SKYLINE GT-R (BNR34)")
                    cmbCarList.Items.Add("SILVIA K's (S13)")
                    cmbCarList.Items.Add("Silvia Q's (S14)")
                    cmbCarList.Items.Add("Silvia spec-R (S15)")
                    cmbCarList.Items.Add("180SX TYPE II (RPS13)")
                    cmbCarList.Items.Add("FAIRLADY Z (Z33)")
                    cmbCarList.Items.Add("GT-R NISMO (R35)")
                    cmbCarList.Items.Add("SKYLINE 25GT TURBO (ER34)")
                    'HONDA
                    cmbCarList.Items.Add("Civic SiR・II (EG6)")
                    cmbCarList.Items.Add("CIVIC TYPE R (EK9)")
                    cmbCarList.Items.Add("INTEGRA TYPE R (DC2)")
                    cmbCarList.Items.Add("S2000 (AP1)")
                    cmbCarList.Items.Add("NSX (NA1)")
                    'MAZDA
                    cmbCarList.Items.Add("RX-7 ∞III (FC3S)")
                    cmbCarList.Items.Add("RX-7 Type R (FD3S)")
                    cmbCarList.Items.Add("RX-7 Type RS (FD3S)")
                    cmbCarList.Items.Add("RX-8 Type S (SE3P)")
                    cmbCarList.Items.Add("ROADSTER (NA6CE)")
                    cmbCarList.Items.Add("ROADSTER RS (NB8C)")
                    'SUBARU
                    cmbCarList.Items.Add("IMPREZA STi Ver.V (GC8)")
                    cmbCarList.Items.Add("IMPREZA STi (GDBA)")
                    cmbCarList.Items.Add("IMPREZA STI (GDBF)")
                    cmbCarList.Items.Add("BRZ S (ZC6)")
                    'MITSUBISHI
                    cmbCarList.Items.Add("LANCER Evolution III (CE9A)")
                    cmbCarList.Items.Add("LANCER EVOLUTION IV (CN9A)")
                    cmbCarList.Items.Add("LANCER Evolution VII (CT9A)")
                    cmbCarList.Items.Add("LANCER Evolution IX (CT9A)")
                    cmbCarList.Items.Add("LANCER EVOLUTION X (CZ4A)")
                    cmbCarList.Items.Add("LANCER GSR EVOLUTION VI T.M.EDITION (CP9A)")
                    cmbCarList.Items.Add("LANCER RS EVOLUTION V (CP9A)")
                    'SUZUKI
                    cmbCarList.Items.Add("Cappuccino (EA11R)")
                    'INITIALD
                    cmbCarList.Items.Add("SILEIGHTY")
                    'COMPLETE CAR
                    cmbCarList.Items.Add("G-FORCE SUPRA (JZA80-kai)")
                    cmbCarList.Items.Add("MONSTER CIVIC R (EK9)")
                    cmbCarList.Items.Add("NSX-R GT (NA2)")
                    cmbCarList.Items.Add("RE Amemiya Genki-7 (FD3S)")
                    cmbCarList.Items.Add("S2000 GT1 (AP1)")
                    cmbCarList.Items.Add("ROADSTER C-SPEC (NA8C Kai)")
            End Select

            If _version = 8 Then NsGroupBox1.Enabled = False
            If Not _version = 8 Then tuple = GetCarPerformancePart(_carname)
            colTuple = GetCarColor(_carname)
            If _version = 7 Then
                stkTuple = GetEventSticker()
            ElseIf _version = 6 Then
                stkTuple = GetEventSticker(6)
            ElseIf _version = 8 Then
                stkTuple = GetEventSticker(8)
            End If
            If Not _version = 8 Then
                parameter = tuple.Item1
                engine = tuple.Item2
                engineName = tuple.Item3
                rollbar = tuple.Item4
                rollbarName = tuple.Item5
            End If
            carColor = colTuple.Item2
            carColorName = colTuple.Item3
            sticker = stkTuple.Item2
            stickerName = stkTuple.Item3

            If Not _version = 8 Then
                Dim engineDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
                For Each item In engine
                    Dim i As Integer = engine.IndexOf(item)
                    engineDic.Add(item, engineName(i))
                Next
                cmbEngine.DisplayMember = "Value"
                cmbEngine.ValueMember = "Key"
                cmbEngine.DataSource = New BindingSource(engineDic, Nothing)
                cmbEngine.SelectedIndex = 0

                Dim rollbarDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
                For Each item In rollbar
                    Dim i As Integer = rollbar.IndexOf(item)
                    rollbarDic.Add(item, rollbarName(i))
                Next
                cmbRollbar.DisplayMember = "Value"
                cmbRollbar.ValueMember = "Key"
                cmbRollbar.DataSource = New BindingSource(rollbarDic, Nothing)
                cmbRollbar.SelectedIndex = 0
            End If

            Dim colorDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each item In carColor
                Dim i As Integer = carColor.IndexOf(item)
                colorDic.Add(item, carColorName(i))
            Next
            cmbColor.DisplayMember = "Value"
            cmbColor.ValueMember = "Key"
            cmbColor.DataSource = New BindingSource(colorDic, Nothing)
            'cmbColor.SelectedIndex = 0

            Dim stickerDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each item In sticker
                Dim i As Integer = sticker.IndexOf(item)
                If stickerDic.ContainsKey(item) Then
                    NSMessageBox.ShowOk(item & "/" & stickerName(i) & " is duplicated!", "Error")
                Else
                    stickerDic.Add(item, stickerName(i))
                End If
            Next
            cmbSticker1.DisplayMember = "Value"
            cmbSticker1.ValueMember = "Key"
            cmbSticker1.DataSource = New BindingSource(stickerDic, Nothing)
            cmbSticker2.DisplayMember = "Value"
            cmbSticker2.ValueMember = "Key"
            cmbSticker2.DataSource = New BindingSource(stickerDic, Nothing)
            cmbSticker3.DisplayMember = "Value"
            cmbSticker3.ValueMember = "Key"
            cmbSticker3.DataSource = New BindingSource(stickerDic, Nothing)
            cmbSticker4.DisplayMember = "Value"
            cmbSticker4.ValueMember = "Key"
            cmbSticker4.DataSource = New BindingSource(stickerDic, Nothing)

            cmbColor.SelectedValue = _car.CarColor
            txtNumberPlate.Text = _car.PlateNo
            cmbHiragana.SelectedIndex = _car.Hiragana
            cmbPlace.SelectedIndex = _car.PlaceName
            cmbSticker1.SelectedValue = _car.Sticker1
            cmbSticker2.SelectedValue = _car.Sticker2
            cmbSticker3.SelectedValue = _car.Sticker3
            cmbSticker4.SelectedValue = _car.Sticker4
            txtClassCode.Text = _car.ClassCode
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            Dim tCar As Car = Nothing

            Select Case _slot
                Case 1
                    tCar = _parentForm.car1
                   ' If Not cmbCarList.SelectedItem = Nothing Then _parentForm.cmbCar1.Text = cmbCarList.SelectedItem
                Case 2
                    tCar = _parentForm.car2
                   ' If Not cmbCarList.SelectedItem = Nothing Then _parentForm.cmbCar2.Text = cmbCarList.SelectedItem
                Case 3
                    tCar = _parentForm.car3
                    ' If Not cmbCarList.SelectedItem = Nothing Then _parentForm.cmbCar3.Text = cmbCarList.SelectedItem
            End Select

            tCar.ReplaceTo = cmbCarList.SelectedItem
            tCar.CarColor = cmbColor.SelectedValue.ToString
            tCar.PlateNo = txtNumberPlate.Text
            tCar.ClassCode = txtClassCode.Text
            tCar.Hiragana = cmbHiragana.SelectedIndex
            tCar.PlaceName = cmbPlace.SelectedIndex
            tCar.Sticker1 = cmbSticker1.SelectedValue.ToString
            tCar.Sticker2 = cmbSticker2.SelectedValue.ToString
            tCar.Sticker3 = cmbSticker3.SelectedValue.ToString
            tCar.Sticker4 = cmbSticker4.SelectedValue.ToString
            tCar.FullSpec = cbFullSpec.Checked
            tCar.SaveEngineRollbar = cbEngineRollbar.Checked
            If Not _version = 8 Then
                tCar.Engine = cmbEngine.SelectedValue.ToString
                tCar.Rollbar = cmbRollbar.SelectedValue.ToString
                tCar.Param = parameter
            End If
            tCar.Edited = True

            'If _extension = "bin" Then
            '    Select Case _slot
            '        Case 1
            '            If Not cmbCarList.SelectedItem = Nothing Then
            '                SetHex(_filename, &H100, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
            '                _parentForm.cmbCar1.Text = cmbCarList.SelectedItem
            '            End If
            '            SetHex(_filename, Plus3C(&HC6), HexStringToBinary(cmbColor.SelectedValue.ToString))
            '            SetHex(_filename, &H11C, HexStringToBinary(SetPlateNumber(txtNumberPlate.Text)))
            '            SetHex(_filename, &H119, SetValue(cmbHiragana.SelectedIndex))
            '            SetHex(_filename, &H118, SetValue(cmbPlace.SelectedIndex))
            '            SetHex(_filename, Plus3C(&HD0), HexStringToBinary(cmbSticker1.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&HD1), HexStringToBinary(cmbSticker2.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&HD2), HexStringToBinary(cmbSticker3.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&HD3), HexStringToBinary(cmbSticker4.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&HCA), HexStringToBinary("10"))
            '            SetHex(_filename, &H11A, HexStringToBinary(SetPridePoint(txtClassCode.Text)))
            '        Case 2
            '            If Not cmbCarList.SelectedItem = Nothing Then
            '                SetHex(_filename, &H160, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
            '                _parentForm.cmbCar2.Text = cmbCarList.SelectedItem
            '            End If
            '            SetHex(_filename, Plus3C(&H126), HexStringToBinary(cmbColor.SelectedValue.ToString))
            '            SetHex(_filename, &H17C, HexStringToBinary(SetPlateNumber(txtNumberPlate.Text)))
            '            SetHex(_filename, &H179, SetValue(cmbHiragana.SelectedIndex))
            '            SetHex(_filename, &H178, SetValue(cmbPlace.SelectedIndex))
            '            SetHex(_filename, Plus3C(&H130), HexStringToBinary(cmbSticker1.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H131), HexStringToBinary(cmbSticker2.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H132), HexStringToBinary(cmbSticker3.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H133), HexStringToBinary(cmbSticker4.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H12A), HexStringToBinary("10"))
            '            SetHex(_filename, &H17A, HexStringToBinary(SetPridePoint(txtClassCode.Text)))
            '        Case 3
            '            If Not cmbCarList.SelectedItem = Nothing Then
            '                SetHex(_filename, &H1C0, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
            '                _parentForm.cmbCar3.Text = cmbCarList.SelectedItem
            '            End If
            '            SetHex(_filename, Plus3C(&H186), HexStringToBinary(cmbColor.SelectedValue.ToString))
            '            SetHex(_filename, &H1DC, HexStringToBinary(SetPlateNumber(txtNumberPlate.Text)))
            '            SetHex(_filename, &H1D9, SetValue(cmbHiragana.SelectedIndex))
            '            SetHex(_filename, &H1D8, SetValue(cmbPlace.SelectedIndex))
            '            SetHex(_filename, Plus3C(&H190), HexStringToBinary(cmbSticker1.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H191), HexStringToBinary(cmbSticker2.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H192), HexStringToBinary(cmbSticker3.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H193), HexStringToBinary(cmbSticker4.SelectedValue.ToString))
            '            SetHex(_filename, Plus3C(&H18A), HexStringToBinary("10"))
            '            SetHex(_filename, &H1DA, HexStringToBinary(SetPridePoint(txtClassCode.Text)))
            '    End Select
            '    If cbFullSpec.Checked Then
            '        Select Case _slot
            '            Case 1
            '                Select Case GetTransmission(GetHex(_filename, 261, 1)) '105
            '                    Case Transmission.AT
            '                        SetHex(_filename, &H105, HexStringToBinary("50"))
            '                    Case Transmission.MT
            '                        SetHex(_filename, &H105, HexStringToBinary("D0"))
            '                End Select
            '                SetHex(_filename, Plus3C(&HCC), HexStringToBinary(parameter))
            '                SetHex(_filename, Plus3C(&HCE), HexStringToBinary(cmbEngine.SelectedValue.ToString))
            '                SetHex(_filename, Plus3C(&HE4), HexStringToBinary(cmbRollbar.SelectedValue.ToString))
            '            Case 2
            '                Select Case GetTransmission(GetHex(_filename, 357, 1)) '165
            '                    Case Transmission.AT
            '                        SetHex(_filename, &H165, HexStringToBinary("50"))
            '                    Case Transmission.MT
            '                        SetHex(_filename, &H165, HexStringToBinary("D0"))
            '                End Select
            '                SetHex(_filename, Plus3C(&H12C), HexStringToBinary(parameter))
            '                SetHex(_filename, Plus3C(&H12E), HexStringToBinary(cmbEngine.SelectedValue.ToString))
            '                SetHex(_filename, Plus3C(&H144), HexStringToBinary(cmbRollbar.SelectedValue.ToString))
            '            Case 3
            '                Select Case GetTransmission(GetHex(_filename, 453, 1)) '1c5
            '                    Case Transmission.AT
            '                        SetHex(_filename, &H1C5, HexStringToBinary("50"))
            '                    Case Transmission.MT
            '                        SetHex(_filename, &H1C5, HexStringToBinary("D0"))
            '                End Select
            '                SetHex(_filename, Plus3C(&H18C), HexStringToBinary(parameter))
            '                SetHex(_filename, Plus3C(&H18E), HexStringToBinary(cmbEngine.SelectedValue.ToString))
            '                SetHex(_filename, Plus3C(&H1A4), HexStringToBinary(cmbRollbar.SelectedValue.ToString))
            '        End Select
            '    End If
            'Else
            '    Select Case _slot
            '        Case 1
            '            If Not cmbCarList.SelectedItem = Nothing Then
            '                SetHex(_filename, Neg3C(&H100), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
            '                _parentForm.cmbCar1.Text = cmbCarList.SelectedItem
            '            End If
            '            SetHex(_filename, &HC6, HexStringToBinary(cmbColor.SelectedValue.ToString))
            '            SetHex(_filename, Neg3C(&H11C), HexStringToBinary(SetPlateNumber(txtNumberPlate.Text)))
            '            SetHex(_filename, Neg3C(&H119), SetValue(cmbHiragana.SelectedIndex))
            '            SetHex(_filename, Neg3C(&H118), SetValue(cmbPlace.SelectedIndex))
            '            SetHex(_filename, &HD0, HexStringToBinary(cmbSticker1.SelectedValue.ToString))
            '            SetHex(_filename, &HD1, HexStringToBinary(cmbSticker2.SelectedValue.ToString))
            '            SetHex(_filename, &HD2, HexStringToBinary(cmbSticker3.SelectedValue.ToString))
            '            SetHex(_filename, &HD3, HexStringToBinary(cmbSticker4.SelectedValue.ToString))
            '            SetHex(_filename, &HCA, HexStringToBinary("10"))
            '            SetHex(_filename, Neg3C(&H11A), HexStringToBinary(SetPridePoint(txtClassCode.Text)))
            '        Case 2
            '            If Not cmbCarList.SelectedItem = Nothing Then
            '                SetHex(_filename, Neg3C(&H160), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
            '                _parentForm.cmbCar2.Text = cmbCarList.SelectedItem
            '            End If
            '            SetHex(_filename, &H126, HexStringToBinary(cmbColor.SelectedValue.ToString))
            '            SetHex(_filename, Neg3C(&H17C), HexStringToBinary(SetPlateNumber(txtNumberPlate.Text)))
            '            SetHex(_filename, Neg3C(&H179), SetValue(cmbHiragana.SelectedIndex))
            '            SetHex(_filename, Neg3C(&H178), SetValue(cmbPlace.SelectedIndex))
            '            SetHex(_filename, &H130, HexStringToBinary(cmbSticker1.SelectedValue.ToString))
            '            SetHex(_filename, &H131, HexStringToBinary(cmbSticker2.SelectedValue.ToString))
            '            SetHex(_filename, &H132, HexStringToBinary(cmbSticker3.SelectedValue.ToString))
            '            SetHex(_filename, &H133, HexStringToBinary(cmbSticker4.SelectedValue.ToString))
            '            SetHex(_filename, &H12A, HexStringToBinary("10"))
            '            SetHex(_filename, Neg3C(&H17A), HexStringToBinary(SetPridePoint(txtClassCode.Text)))
            '        Case 3
            '            If Not cmbCarList.SelectedItem = Nothing Then
            '                SetHex(_filename, Neg3C(&H1C0), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
            '                _parentForm.cmbCar3.Text = cmbCarList.SelectedItem
            '            End If
            '            SetHex(_filename, &H186, HexStringToBinary(cmbColor.SelectedValue.ToString))
            '            SetHex(_filename, Neg3C(&H1DC), HexStringToBinary(SetPlateNumber(txtNumberPlate.Text)))
            '            SetHex(_filename, Neg3C(&H1D9), SetValue(cmbHiragana.SelectedIndex))
            '            SetHex(_filename, Neg3C(&H1D8), SetValue(cmbPlace.SelectedIndex))
            '            SetHex(_filename, &H190, HexStringToBinary(cmbSticker1.SelectedValue.ToString))
            '            SetHex(_filename, &H191, HexStringToBinary(cmbSticker2.SelectedValue.ToString))
            '            SetHex(_filename, &H192, HexStringToBinary(cmbSticker3.SelectedValue.ToString))
            '            SetHex(_filename, &H193, HexStringToBinary(cmbSticker4.SelectedValue.ToString))
            '            SetHex(_filename, &H18A, HexStringToBinary("10"))
            '            SetHex(_filename, Neg3C(&H1DA), HexStringToBinary(SetPridePoint(txtClassCode.Text)))
            '    End Select
            '    If cbFullSpec.Checked Then
            '        Select Case _slot
            '            Case 1
            '                Select Case GetTransmission(GetHex(_filename, Neg60(261), 1)) '105
            '                    Case Transmission.AT
            '                        SetHex(_filename, Neg3C(&H105), HexStringToBinary("50"))
            '                    Case Transmission.MT
            '                        SetHex(_filename, Neg3C(&H105), HexStringToBinary("D0"))
            '                End Select
            '                SetHex(_filename, &HCC, HexStringToBinary(parameter))
            '                SetHex(_filename, &HCE, HexStringToBinary(cmbEngine.SelectedValue.ToString))
            '                SetHex(_filename, &HE4, HexStringToBinary(cmbRollbar.SelectedValue.ToString))
            '            Case 2
            '                Select Case GetTransmission(GetHex(_filename, Neg60(357), 1)) '165
            '                    Case Transmission.AT
            '                        SetHex(_filename, Neg3C(&H165), HexStringToBinary("50"))
            '                    Case Transmission.MT
            '                        SetHex(_filename, Neg3C(&H165), HexStringToBinary("D0"))
            '                End Select
            '                SetHex(_filename, &H12C, HexStringToBinary(parameter))
            '                SetHex(_filename, &H12E, HexStringToBinary(cmbEngine.SelectedValue.ToString))
            '                SetHex(_filename, &H144, HexStringToBinary(cmbRollbar.SelectedValue.ToString))
            '            Case 3
            '                Select Case GetTransmission(GetHex(_filename, Neg60(453), 1)) '1c5
            '                    Case Transmission.AT
            '                        SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("50"))
            '                    Case Transmission.MT
            '                        SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("D0"))
            '                End Select
            '                SetHex(_filename, &H18C, HexStringToBinary(parameter))
            '                SetHex(_filename, &H18E, HexStringToBinary(cmbEngine.SelectedValue.ToString))
            '                SetHex(_filename, &H1A4, HexStringToBinary(cmbRollbar.SelectedValue.ToString))
            '        End Select
            '    End If
            'End If

            Me.Close()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub cmbCarList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCarList.SelectedIndexChanged
        Try
            If cmbCarList.SelectedIndex = 0 Then
                tuple = GetCarPerformancePart(_carname)
                colTuple = GetCarColor(_carname)
            Else
                tuple = GetCarPerformancePart(cmbCarList.SelectedItem)
                colTuple = GetCarColor(cmbCarList.SelectedItem)
            End If

            parameter = tuple.Item1
            engine = tuple.Item2
            engineName = tuple.Item3
            rollbar = tuple.Item4
            rollbarName = tuple.Item5
            carColor = colTuple.Item2
            carColorName = colTuple.Item3

            Dim engineDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each item In engine
                Dim i As Integer = engine.IndexOf(item)
                engineDic.Add(item, engineName(i))
            Next
            cmbEngine.DisplayMember = "Value"
            cmbEngine.ValueMember = "Key"
            cmbEngine.DataSource = New BindingSource(engineDic, Nothing)
            cmbEngine.SelectedIndex = 0

            Dim rollbarDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each item In rollbar
                Dim i As Integer = rollbar.IndexOf(item)
                rollbarDic.Add(item, rollbarName(i))
            Next
            cmbRollbar.DisplayMember = "Value"
            cmbRollbar.ValueMember = "Key"
            cmbRollbar.DataSource = New BindingSource(rollbarDic, Nothing)
            cmbRollbar.SelectedIndex = 0

            Dim colorDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each item In carColor
                Dim i As Integer = carColor.IndexOf(item)
                colorDic.Add(item, carColorName(i))
            Next
            cmbColor.DisplayMember = "Value"
            cmbColor.ValueMember = "Key"
            cmbColor.DataSource = New BindingSource(colorDic, Nothing)
            cmbColor.SelectedIndex = 0
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub cbFullSpec_CheckedChanged(sender As Object) Handles cbFullSpec.CheckedChanged
        cbEngineRollbar.Enabled = cbFullSpec.Checked
    End Sub

    Private Sub frmEditCar_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClassCode.KeyPress, txtNumberPlate.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Control Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Back Then
                Return
            End If
            e.Handled = True
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub
End Class