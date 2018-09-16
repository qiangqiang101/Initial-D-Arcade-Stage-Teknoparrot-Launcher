Imports System.Xml.Serialization
Imports System.IO

Public Structure ParrotData

    Private Shared _instance As ParrotData

    Public ReadOnly Property Instance As ParrotData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property XMLFileName() As String

    Public UseSto0ZDrivingHack As Boolean
    Public StoozPercent As Integer
    Public UseMouse As Boolean
    Public XInputMode As Boolean
    Public GunSensitivityPlayer1 As Integer
    Public GunSensitivityPlayer2 As Integer
    Public FullAxisGas As Boolean
    Public FullAxisBrake As Boolean
    Public ReverseAxisGas As Boolean
    Public ReverseAxisBrake As Boolean
    Public HapticDevice As String
    Public UseHaptic As Boolean
    Public HapticThrustmasterFix As Boolean
    Public ConstantBase As Integer
    Public SineBase As Integer
    Public FrictionBase As Integer
    Public SpringBase As Integer

    Public Sub New(fName As String, sto0zHack As Boolean, sto0zPercent As Integer, mouse As Boolean, xInput As Boolean, gunSensP1 As Integer, gunSensP2 As Integer, faGas As Boolean, faBrake As Boolean, raGas As Boolean, raBrake As Boolean, hapDevice As String, useHap As Boolean, thrust As Boolean, cBase As Integer, sBase As Integer, fBase As Integer, spBase As Integer)
        XMLFileName = fName
        UseSto0ZDrivingHack = sto0zHack
        StoozPercent = sto0zPercent
        UseMouse = mouse
        XInputMode = xInput
        GunSensitivityPlayer1 = gunSensP1
        GunSensitivityPlayer2 = gunSensP2
        FullAxisGas = faGas
        FullAxisBrake = faBrake
        ReverseAxisGas = raGas
        ReverseAxisBrake = raBrake
        HapticDevice = hapDevice
        UseHaptic = useHap
        HapticThrustmasterFix = thrust
        ConstantBase = cBase
        SineBase = sBase
        FrictionBase = fBase
        SpringBase = spBase
    End Sub

    Public Sub New(fName As String)
        XMLFileName = fName
    End Sub

    Public Sub Save()
        Try
            Dim ser = New XmlSerializer(GetType(ParrotData))
            Dim writer As TextWriter = New StreamWriter(XMLFileName)
            ser.Serialize(writer, Me)
            writer.Close()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Function ReadFromFile() As ParrotData
        If Not File.Exists(XMLFileName) Then
            Logger.Log(String.Format("Unable to load XML File {0}{1}{0}, file not found.", """", XMLFileName))
            Return New ParrotData(XMLFileName, UseSto0ZDrivingHack, StoozPercent, UseMouse, XInputMode, GunSensitivityPlayer1, GunSensitivityPlayer2, FullAxisGas, FullAxisBrake, ReverseAxisGas, ReverseAxisBrake, HapticDevice, UseHaptic, HapticThrustmasterFix, ConstantBase, SineBase, FrictionBase, SpringBase)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(ParrotData))
            Dim reader As TextReader = New StreamReader(XMLFileName)
            Dim instance = CType(ser.Deserialize(reader), ParrotData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
            Return New ParrotData(XMLFileName, UseSto0ZDrivingHack, StoozPercent, UseMouse, XInputMode, GunSensitivityPlayer1, GunSensitivityPlayer2, FullAxisGas, FullAxisBrake, ReverseAxisGas, ReverseAxisBrake, HapticDevice, UseHaptic, HapticThrustmasterFix, ConstantBase, SineBase, FrictionBase, SpringBase)
        End Try
    End Function
End Structure
