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
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
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
                                _parentForm.cmbCar1.Text = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 6)
                            Case 2
                                SetHex(_filename, &H124, GetHex(ofd.FileName, &H0, 96))
                                _parentForm.cmbCar2.Text = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 6)
                            Case 3
                                SetHex(_filename, &H184, GetHex(ofd.FileName, &H0, 96))
                                _parentForm.cmbCar3.Text = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 6)
                        End Select
                    Case "bin"
                        Select Case _slot
                            Case 1
                                SetHex(_filename, Plus3C(&HC4), GetHex(ofd.FileName, &H0, 96))
                                _parentForm.cmbCar1.Text = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 6)
                            Case 2
                                SetHex(_filename, Plus3C(&H124), GetHex(ofd.FileName, &H0, 96))
                                _parentForm.cmbCar2.Text = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 6)
                            Case 3
                                SetHex(_filename, Plus3C(&H184), GetHex(ofd.FileName, &H0, 96))
                                _parentForm.cmbCar3.Text = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 6)
                        End Select
                End Select
                MsgBox(import_complete, MsgBoxStyle.Information, Me.Text)
                Me.Close()
                _parentForm.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Edit Car: " & _carname & "[" & _slot & "]"
                NsTheme1.Text = Me.Text
                Label3.Text = "Replace to"
                cbFullSpec.Text = "Unlock FullSpec"
                NsGroupBox1.Title = "Performance Parts"
                NsGroupBox1.SubTitle = "Edit this might overwrite your Visual Parts."
                Label1.Text = "Select Engine"
                Label2.Text = "Select Rollbar"
                Label4.Text = "Color"
                btnApply.Text = "Apply"
                Label6.Text = "Plate Number"
                Label5.Text = "Hiragana"
                Label7.Text = "Place Name"
                NsGroupBox2.Title = "Number Plate Design"
                NsGroupBox2.SubTitle = "Edit the Number Plate of this car."
                NsGroupBox3.Title = "Event Stickers"
                NsGroupBox3.SubTitle = "Edit the Hidden Event Stickers of this car."
                Label9.Text = "Sticker 1"
                Label8.Text = "Sticker 2"
                Label11.Text = "Sticker 3"
                Label10.Text = "Sticker 4"
                Label12.Text = "Class Code"
                btnSave.Text = "Export"
                btnLoad.Text = "Import"
                import_complete = "Car Import completed, Restart Card Editor to take effect."
            Case "Chinese"
                Me.Text = "改车: " & _carname & "[" & _slot & "]"
                NsTheme1.Text = Me.Text
                Label3.Text = "换成"
                cbFullSpec.Text = "解鎖 FullSpec"
                NsGroupBox1.Title = "性能零件"
                NsGroupBox1.SubTitle = "修改這個可能會導致外改裝件消失噢。"
                Label1.Text = "選擇引擎"
                Label2.Text = "選擇滾動條"
                Label4.Text = "顏色"
                btnApply.Text = "應用"
                Label6.Text = "車牌號碼"
                Label5.Text = "平假名"
                Label7.Text = "地名"
                NsGroupBox2.Title = "車牌設計"
                NsGroupBox2.SubTitle = "修改這輛車的車牌。"
                NsGroupBox3.Title = "活動貼紙"
                NsGroupBox3.SubTitle = "修改這輛車的活動貼紙。"
                Label9.Text = "貼紙1"
                Label8.Text = "貼紙2"
                Label11.Text = "貼紙3"
                Label10.Text = "貼紙4"
                Label12.Text = "分類編號"
                btnSave.Text = "導出"
                btnLoad.Text = "導入"
                import_complete = "導入完成，請重啟改卡視窗。"
            Case "French"
                Me.Text = "Edit Car: " & _carname & "[" & _slot & "]"
                NsTheme1.Text = Me.Text
                Label3.Text = "Replace to"
                cbFullSpec.Text = "déverrouiller les FullSpec"
                NsGroupBox1.Title = "Performance Parts"
                NsGroupBox1.SubTitle = "Edit this might overwrite your Visual Parts."
                Label1.Text = "Select Engine"
                Label2.Text = "Select Rollbar"
                Label4.Text = "Color"
                btnApply.Text = "Apply"
                Label6.Text = "Plate Number"
                Label5.Text = "Hiragana"
                Label7.Text = "Place Name"
                NsGroupBox2.Title = "Number Plate Design"
                NsGroupBox2.SubTitle = "Edit the Number Plate of this car."
                NsGroupBox3.Title = "Event Stickers"
                NsGroupBox3.SubTitle = "Edit the Hidden Event Stickers of this car."
                Label9.Text = "Sticker 1"
                Label8.Text = "Sticker 2"
                Label11.Text = "Sticker 3"
                Label10.Text = "Sticker 4"
                Label12.Text = "Class Code"
                btnSave.Text = "Export"
                btnLoad.Text = "Import"
                import_complete = "Car Import completed, Restart Card Editor to take effect."
        End Select
    End Sub

    Private Sub frmEditCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Translate()

            tuple = GetCarPerformancePart(_carname)
            colTuple = GetCarColor(_carname)
            If _version = 7 Then
                stkTuple = GetEventSticker()
            Else
                stkTuple = GetEventSticker(6)
            End If
            parameter = tuple.Item1
            engine = tuple.Item2
            engineName = tuple.Item3
            rollbar = tuple.Item4
            rollbarName = tuple.Item5
            carColor = colTuple.Item2
            carColorName = colTuple.Item3
            sticker = stkTuple.Item2
            stickerName = stkTuple.Item3

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
            'cmbColor.SelectedIndex = 0

            Dim stickerDic As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each item In sticker
                Dim i As Integer = sticker.IndexOf(item)
                If stickerDic.ContainsKey(item) Then
                    MsgBox(item & "/" & stickerName(i) & " is duplicated!")
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

            'If _extension = "crd" Then
            '    Select Case _slot
            '        Case 1
            '            cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 198, 1))
            '            txtNumberPlate.Text = GetPlateNumber(GetHex(_filename, Neg60(284), 1), GetHex(_filename, Neg60(285), 1), GetHex(_filename, Neg60(286), 1))
            '            cmbHiragana.SelectedIndex = GetLevel(GetHex(_filename, Neg60(281), 1), True)
            '            cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, Neg60(280), 1), True)
            '            cmbSticker1.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 208, 1))
            '            cmbSticker2.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 209, 1))
            '            cmbSticker3.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 210, 1))
            '            cmbSticker4.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 211, 1))
            '            txtClassCode.Text = GetPridePoint(GetHex(_filename, Neg3C(&H11A), 1), GetHex(_filename, Neg3C(&H11B), 1))
            '        Case 2
            '            cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 294, 1))
            '            txtNumberPlate.Text = GetPlateNumber(GetHex(_filename, Neg60(380), 1), GetHex(_filename, Neg60(381), 1), GetHex(_filename, Neg60(382), 1))
            '            cmbHiragana.SelectedIndex = GetLevel(GetHex(_filename, Neg60(377), 1), True)
            '            cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, Neg60(376), 1), True)
            '            cmbSticker1.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 304, 1))
            '            cmbSticker2.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 305, 1))
            '            cmbSticker3.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 306, 1))
            '            cmbSticker4.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 307, 1))
            '            txtClassCode.Text = GetPridePoint(GetHex(_filename, Neg3C(&H17A), 1), GetHex(_filename, Neg3C(&H17B), 1))
            '        Case 3
            '            cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 390, 1))
            '            txtNumberPlate.Text = GetPlateNumber(GetHex(_filename, Neg60(476), 1), GetHex(_filename, Neg60(477), 1), GetHex(_filename, Neg60(478), 1))
            '            cmbHiragana.SelectedIndex = GetLevel(GetHex(_filename, Neg60(473), 1), True)
            '            cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, Neg60(472), 1), True)
            '            cmbSticker1.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 400, 1))
            '            cmbSticker2.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 401, 1))
            '            cmbSticker3.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 402, 1))
            '            cmbSticker4.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 403, 1))
            '            txtClassCode.Text = GetPridePoint(GetHex(_filename, Neg3C(&H1DA), 1), GetHex(_filename, Neg3C(&H1DB), 1))
            '    End Select
            'Else
            '    Select Case _slot
            '        Case 1
            '            cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(198), 1))
            '            txtNumberPlate.Text = GetPlateNumber(GetHex(_filename, 284, 1), GetHex(_filename, 285, 1), GetHex(_filename, 286, 1))
            '            cmbHiragana.SelectedIndex = GetLevel(GetHex(_filename, 281, 1), True)
            '            cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, 280, 1), True)
            '            cmbSticker1.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(208), 1))
            '            cmbSticker2.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(209), 1))
            '            cmbSticker3.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(210), 1))
            '            cmbSticker4.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(211), 1))
            '            txtClassCode.Text = GetPridePoint(GetHex(_filename, &H11A, 1), GetHex(_filename, &H11B, 1))
            '        Case 2
            '            cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(294), 1))
            '            txtNumberPlate.Text = GetPlateNumber(GetHex(_filename, 380, 1), GetHex(_filename, 381, 1), GetHex(_filename, 382, 1))
            '            cmbHiragana.SelectedIndex = GetLevel(GetHex(_filename, 377, 1), True)
            '            cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, 376, 1), True)
            '            cmbSticker1.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(304), 1))
            '            cmbSticker2.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(305), 1))
            '            cmbSticker3.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(306), 1))
            '            cmbSticker4.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(307), 1))
            '            txtClassCode.Text = GetPridePoint(GetHex(_filename, &H17A, 1), GetHex(_filename, &H17B, 1))
            '        Case 3
            '            cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(390), 1))
            '            txtNumberPlate.Text = GetPlateNumber(GetHex(_filename, 476, 1), GetHex(_filename, 477, 1), GetHex(_filename, 478, 1))
            '            cmbHiragana.SelectedIndex = GetLevel(GetHex(_filename, 473, 1), True)
            '            cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, 472, 1), True)
            '            cmbSticker1.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(400), 1))
            '            cmbSticker2.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(401), 1))
            '            cmbSticker3.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(402), 1))
            '            cmbSticker4.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(403), 1))
            '            txtClassCode.Text = GetPridePoint(GetHex(_filename, &H1DA, 1), GetHex(_filename, &H1DB, 1))
            '    End Select
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            Dim tCar As Car = Nothing

            Select Case _slot
                Case 1
                    tCar = _parentForm.car1
                    If Not cmbCarList.SelectedItem = Nothing Then _parentForm.cmbCar1.Text = cmbCarList.SelectedItem
                Case 2
                    tCar = _parentForm.car2
                    If Not cmbCarList.SelectedItem = Nothing Then _parentForm.cmbCar2.Text = cmbCarList.SelectedItem
                Case 3
                    tCar = _parentForm.car3
                    If Not cmbCarList.SelectedItem = Nothing Then _parentForm.cmbCar3.Text = cmbCarList.SelectedItem
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
            tCar.Engine = cmbEngine.SelectedValue.ToString
            tCar.Rollbar = cmbRollbar.SelectedValue.ToString
            tCar.Param = parameter
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
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
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
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbFullSpec_CheckedChanged(sender As Object) Handles cbFullSpec.CheckedChanged
        cmbEngine.Enabled = cbFullSpec.Checked
        cmbRollbar.Enabled = cbFullSpec.Checked
        Label1.Enabled = cbFullSpec.Checked
        Label2.Enabled = cbFullSpec.Checked
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
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class