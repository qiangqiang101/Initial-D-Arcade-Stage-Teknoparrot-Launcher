Imports System.IO

Public Class CarCtrl

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
    Public Property CarName() As String
        Get
            Return lblCarName.Text
        End Get
        Set(value As String)
            lblCarName.Text = value
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

                'Me.Close()
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
                                lblCarName.Text = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 6)
                            Case 2
                                SetHex(_filename, &H124, GetHex(ofd.FileName, &H0, 96))
                                lblCarName.Text = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 6)
                            Case 3
                                SetHex(_filename, &H184, GetHex(ofd.FileName, &H0, 96))
                                lblCarName.Text = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 6)
                        End Select
                    Case "bin"
                        Select Case _slot
                            Case 1
                                SetHex(_filename, Plus3C(&HC4), GetHex(ofd.FileName, &H0, 96))
                                lblCarName.Text = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 6)
                            Case 2
                                SetHex(_filename, Plus3C(&H124), GetHex(ofd.FileName, &H0, 96))
                                lblCarName.Text = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 6)
                            Case 3
                                SetHex(_filename, Plus3C(&H184), GetHex(ofd.FileName, &H0, 96))
                                lblCarName.Text = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 6)
                        End Select
                End Select
                NSMessageBox.ShowOk(import_complete, MsgBoxStyle.Information, Me.Text)
                'Me.Close()
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
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Text = ReadCfgValue("EditCarMeText", langFile) & lblCarName.Text & "[" & _slot & "]"
            cbFullSpec.Text = ReadCfgValue("UnlockFullspec", langFile)
            cbEngineRollbar.Text = ReadCfgValue("EngineRollbar", langFile)
            TabPage3.Text = ReadCfgValue("PerformancePart", langFile) 'NsGroupBox1.Title
            Label1.Text = ReadCfgValue("SelectEngine", langFile)
            Label2.Text = ReadCfgValue("SelectRollbar", langFile)
            Label4.Text = ReadCfgValue("Color", langFile)
            btnApply.Text = ReadCfgValue("Apply", langFile)
            Label6.Text = ReadCfgValue("PlateNum", langFile)
            Label5.Text = ReadCfgValue("Hiragana", langFile)
            Label7.Text = ReadCfgValue("PlaceName", langFile)
            TabPage2.Text = ReadCfgValue("NumPlate", langFile) 'NsGroupBox2.Title
            TabPage1.Text = ReadCfgValue("EventSticker", langFile) ' NsGroupBox3.Title
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

    Private Sub CarCtrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Translate()

            If _version = 8 Then TabPage3.Enabled = False
            If Not _version = 8 Then tuple = GetCarPerformancePart(lblCarName.Text)
            colTuple = GetCarColor(lblCarName.Text)
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
                Case 2
                    tCar = _parentForm.car2
                Case 3
                    tCar = _parentForm.car3
            End Select

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
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub cbFullSpec_CheckedChanged(sender As Object) Handles cbFullSpec.CheckedChanged
        cbEngineRollbar.Enabled = cbFullSpec.Checked
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
