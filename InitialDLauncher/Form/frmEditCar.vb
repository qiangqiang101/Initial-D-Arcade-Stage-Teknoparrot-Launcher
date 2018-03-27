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

    Public parentForm As frmEdit
    Dim parameter As String
    Dim engine, engineName, rollbar, rollbarName, carColor, carColorName As List(Of String)
    Dim tuple As Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))
    Dim colTuple As Tuple(Of String, List(Of String), List(Of String))

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
                Label2.Text = "Select Rollcage"
                Label4.Text = "Color"
                btnSave.Text = "Save"
            Case "Chinese"
                Me.Text = "改车: " & _carname & "[" & _slot & "]"
                NsTheme1.Text = Me.Text
                Label3.Text = "换成"
                cbFullSpec.Text = "解鎖 FullSpec"
                NsGroupBox1.Title = "性能零件"
                NsGroupBox1.SubTitle = "修改這個可能會導致外改裝件消失噢。"
                Label1.Text = "選擇引擎"
                Label2.Text = "選擇防滾架"
                Label4.Text = "顏色"
                btnSave.Text = "保存"
            Case "French"
                Me.Text = "Edit Car: " & _carname & "[" & _slot & "]"
                NsTheme1.Text = Me.Text
                Label3.Text = "Replace to"
                cbFullSpec.Text = "déverrouiller les FullSpec"
                NsGroupBox1.Title = "Performance Parts"
                NsGroupBox1.SubTitle = "Edit this might overwrite your Visual Parts."
                Label1.Text = "Select Engine"
                Label2.Text = "Select Rollcage"
                Label4.Text = "Color"
                btnSave.Text = "Sauv"
        End Select
    End Sub

    Private Sub frmEditCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Translate()

            tuple = GetCarPerformancePart(_carname)
            colTuple = GetCarColor(_carname)
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
            'cmbColor.SelectedIndex = 0
            If _extension = "crd" Then
                Select Case _slot
                    Case 1
                        cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 198, 1))
                    Case 2
                        cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 294, 1))
                    Case 3
                        cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, 390, 1))
                End Select
            Else
                Select Case _slot
                    Case 1
                        cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(198), 1))
                    Case 2
                        cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(294), 1))
                    Case 3
                        cmbColor.SelectedValue = GetHexStringFromBinary(GetHex(_filename, Plus60(390), 1))
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If _extension = "bin" Then
                Select Case _slot
                    Case 1
                        If Not cmbCarList.SelectedItem = Nothing Then
                            SetHex(_filename, &H100, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                            parentForm.cmbCar1.Text = cmbCarList.SelectedItem
                        End If
                        SetHex(_filename, Plus3C(&HC6), HexStringToBinary(cmbColor.SelectedValue.ToString))
                    Case 2
                        If Not cmbCarList.SelectedItem = Nothing Then
                            SetHex(_filename, &H160, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                            parentForm.cmbCar2.Text = cmbCarList.SelectedItem
                        End If
                        SetHex(_filename, Plus3C(&H126), HexStringToBinary(cmbColor.SelectedValue.ToString))
                    Case 3
                        If Not cmbCarList.SelectedItem = Nothing Then
                            SetHex(_filename, &H1C0, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                            parentForm.cmbCar3.Text = cmbCarList.SelectedItem
                        End If
                        SetHex(_filename, Plus3C(&H186), HexStringToBinary(cmbColor.SelectedValue.ToString))
                End Select
                If cbFullSpec.Checked Then
                    Select Case _slot
                        Case 1
                            Select Case GetTransmission(GetHex(_filename, 261, 1)) '105
                                Case Transmission.AT
                                    SetHex(_filename, &H105, HexStringToBinary("50"))
                                Case Transmission.MT
                                    SetHex(_filename, &H105, HexStringToBinary("D0"))
                            End Select
                            SetHex(_filename, Plus3C(&HCC), HexStringToBinary(parameter))
                            SetHex(_filename, Plus3C(&HCE), HexStringToBinary(cmbEngine.SelectedValue.ToString))
                            SetHex(_filename, Plus3C(&HE4), HexStringToBinary(cmbRollbar.SelectedValue.ToString))
                        Case 2
                            Select Case GetTransmission(GetHex(_filename, 357, 1)) '165
                                Case Transmission.AT
                                    SetHex(_filename, &H165, HexStringToBinary("50"))
                                Case Transmission.MT
                                    SetHex(_filename, &H165, HexStringToBinary("D0"))
                            End Select
                            SetHex(_filename, Plus3C(&H12C), HexStringToBinary(parameter))
                            SetHex(_filename, Plus3C(&H12E), HexStringToBinary(cmbEngine.SelectedValue.ToString))
                            SetHex(_filename, Plus3C(&H144), HexStringToBinary(cmbRollbar.SelectedValue.ToString))
                        Case 3
                            Select Case GetTransmission(GetHex(_filename, 453, 1)) '1c5
                                Case Transmission.AT
                                    SetHex(_filename, &H1C5, HexStringToBinary("50"))
                                Case Transmission.MT
                                    SetHex(_filename, &H1C5, HexStringToBinary("D0"))
                            End Select
                            SetHex(_filename, Plus3C(&H18C), HexStringToBinary(parameter))
                            SetHex(_filename, Plus3C(&H18E), HexStringToBinary(cmbEngine.SelectedValue.ToString))
                            SetHex(_filename, Plus3C(&H1A4), HexStringToBinary(cmbRollbar.SelectedValue.ToString))
                    End Select
                End If
            Else
                Select Case _slot
                    Case 1
                        If Not cmbCarList.SelectedItem = Nothing Then
                            SetHex(_filename, Neg3C(&H100), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                            parentForm.cmbCar1.Text = cmbCarList.SelectedItem
                        End If
                        SetHex(_filename, &HC6, HexStringToBinary(cmbColor.SelectedValue.ToString))
                    Case 2
                        If Not cmbCarList.SelectedItem = Nothing Then
                            SetHex(_filename, Neg3C(&H160), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                            parentForm.cmbCar2.Text = cmbCarList.SelectedItem
                        End If
                        SetHex(_filename, &H126, HexStringToBinary(cmbColor.SelectedValue.ToString))
                    Case 3
                        If Not cmbCarList.SelectedItem = Nothing Then
                            SetHex(_filename, Neg3C(&H1C0), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                            parentForm.cmbCar3.Text = cmbCarList.SelectedItem
                        End If
                        SetHex(_filename, &H186, HexStringToBinary(cmbColor.SelectedValue.ToString))
                End Select
                If cbFullSpec.Checked Then
                    Select Case _slot
                        Case 1
                            Select Case GetTransmission(GetHex(_filename, 261, 1)) '105
                                Case Transmission.AT
                                    SetHex(_filename, Neg3C(&H105), HexStringToBinary("50"))
                                Case Transmission.MT
                                    SetHex(_filename, Neg3C(&H105), HexStringToBinary("D0"))
                            End Select
                            SetHex(_filename, &HCC, HexStringToBinary(parameter))
                            SetHex(_filename, &HCE, HexStringToBinary(cmbEngine.SelectedValue.ToString))
                            SetHex(_filename, &HE4, HexStringToBinary(cmbRollbar.SelectedValue.ToString))
                        Case 2
                            Select Case GetTransmission(GetHex(_filename, 357, 1)) '165
                                Case Transmission.AT
                                    SetHex(_filename, Neg3C(&H165), HexStringToBinary("50"))
                                Case Transmission.MT
                                    SetHex(_filename, Neg3C(&H165), HexStringToBinary("D0"))
                            End Select
                            SetHex(_filename, &H12C, HexStringToBinary(parameter))
                            SetHex(_filename, &H12E, HexStringToBinary(cmbEngine.SelectedValue.ToString))
                            SetHex(_filename, &H144, HexStringToBinary(cmbRollbar.SelectedValue.ToString))
                        Case 3
                            Select Case GetTransmission(GetHex(_filename, 453, 1)) '1c5
                                Case Transmission.AT
                                    SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("50"))
                                Case Transmission.MT
                                    SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("D0"))
                            End Select
                            SetHex(_filename, &H18C, HexStringToBinary(parameter))
                            SetHex(_filename, &H18E, HexStringToBinary(cmbEngine.SelectedValue.ToString))
                            SetHex(_filename, &H1A4, HexStringToBinary(cmbRollbar.SelectedValue.ToString))
                    End Select
                End If
            End If

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
End Class