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

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Edit Car: " & _carname
                Label3.Text = "Change to"
                cbFullSpec.Text = "Unlock Full Spec"
            Case "Chinese"
                Me.Text = "改车: " & _carname
                Label3.Text = "换成"
                cbFullSpec.Text = "解鎖完整的規格"
            Case "French"
                Me.Text = "Edit Car: " & _carname
                Label3.Text = "Change to"
                cbFullSpec.Text = "déverrouiller les spécifications complètes"
        End Select
    End Sub

    Private Sub frmEditCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _extension = "bin" Then
            Select Case _slot
                Case 1
                    If Not cmbCarList.SelectedItem.ToString = "" Then SetHex(_filename, &H100, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                Case 2
                    If Not cmbCarList.SelectedItem.ToString = "" Then SetHex(_filename, &H160, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                Case 3
                    If Not cmbCarList.SelectedItem.ToString = "" Then SetHex(_filename, &H1C0, HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
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
                    Case 2
                        Select Case GetTransmission(GetHex(_filename, 357, 1)) '165
                            Case Transmission.AT
                                SetHex(_filename, &H165, HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, &H165, HexStringToBinary("D0"))
                        End Select
                    Case 3
                        Select Case GetTransmission(GetHex(_filename, 453, 1)) '1c5
                            Case Transmission.AT
                                SetHex(_filename, &H1C5, HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, &H1C5, HexStringToBinary("D0"))
                        End Select
                End Select
            End If
        Else
            Select Case _slot
                Case 1
                    If Not cmbCarList.SelectedItem.ToString = "" Then SetHex(_filename, Neg3C(&H100), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                Case 2
                    If Not cmbCarList.SelectedItem.ToString = "" Then SetHex(_filename, Neg3C(&H160), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
                Case 3
                    If Not cmbCarList.SelectedItem.ToString = "" Then SetHex(_filename, Neg3C(&H1C0), HexStringToBinary(SetCar(cmbCarList.SelectedItem.ToString)))
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
                    Case 2
                        Select Case GetTransmission(GetHex(_filename, 357, 1)) '165
                            Case Transmission.AT
                                SetHex(_filename, Neg3C(&H165), HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, Neg3C(&H165), HexStringToBinary("D0"))
                        End Select
                    Case 3
                        Select Case GetTransmission(GetHex(_filename, 453, 1)) '1c5
                            Case Transmission.AT
                                SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("D0"))
                        End Select
                End Select
            End If
        End If

    End Sub
End Class