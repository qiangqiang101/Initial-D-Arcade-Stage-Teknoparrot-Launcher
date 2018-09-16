Imports System.Xml.Serialization
Imports System.IO
Imports TeknoParrotUi.Common

Public Structure GameProfile

    Private Shared _instance As GameProfile

    Public ReadOnly Property Instance As GameProfile
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property XMLFileName() As String

    Public GameName As String
    Public GamePath As String
    Public TestMenuParameter As String
    Public TestMenuIsExecutable As Boolean
    Public ExtraParameters As String
    Public TestMenuExtraParameters As String
    Public IconName As String
    Public ConfigValues As List(Of FieldInformation)
    Public JoystickButtons As List(Of JoystickButtons)
    Public EmulationProfile As String
    Public GameProfileRevision As Integer
    Public HasSeparateTestMode As Boolean
    Public Is64Bit As Boolean

    Public Sub New(fName As String, gName As String, gPath As String, tmParam As String, tmiExe As Boolean, eParam As String, tmeParam As String, iName As String, cVal As List(Of FieldInformation), jBtn As List(Of JoystickButtons), eProf As String, gpRev As Integer, hsTestM As Boolean, is64B As Boolean)
        XMLFileName = fName
        GameName = gName
        GamePath = gPath
        TestMenuParameter = tmParam
        TestMenuIsExecutable = tmiExe
        ExtraParameters = eParam
        TestMenuExtraParameters = tmeParam
        IconName = iName
        ConfigValues = cVal
        JoystickButtons = jBtn
        EmulationProfile = eProf
        GameProfileRevision = gpRev
        HasSeparateTestMode = hsTestM
        Is64Bit = is64B
    End Sub

    Public Sub New(fName As String)
        XMLFileName = fName
    End Sub

    Public Sub Save()
        Try
            Dim ser = New XmlSerializer(GetType(GameProfile))
            Dim writer As TextWriter = New StreamWriter(XMLFileName)
            ser.Serialize(writer, Me)
            writer.Close()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Function ReadFromFile() As GameProfile
        If Not File.Exists(XMLFileName) Then
            Logger.Log(String.Format("Unable to load XML File {0}{1}{0}, file not found.", """", XMLFileName))
            Return New GameProfile(XMLFileName, GameName, GamePath, TestMenuParameter, TestMenuExtraParameters, ExtraParameters, TestMenuExtraParameters, IconName, ConfigValues, JoystickButtons, EmulationProfile, GameProfileRevision, HasSeparateTestMode, Is64Bit)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(GameProfile))
            Dim reader As TextReader = New StreamReader(XMLFileName)
            Dim instance = CType(ser.Deserialize(reader), GameProfile)
            reader.Close()
            Return instance
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
            Return New GameProfile(XMLFileName, GameName, GamePath, TestMenuParameter, TestMenuExtraParameters, ExtraParameters, TestMenuExtraParameters, IconName, ConfigValues, JoystickButtons, EmulationProfile, GameProfileRevision, HasSeparateTestMode, Is64Bit)
        End Try
    End Function

End Structure

Public Structure FieldInformation

    Public CategoryName As String
    Public FieldName As String
    Public FieldValue As String
    Public FieldType As String

    Public Sub New(catName As String, fldName As String, fldVal As String, fldType As String)
        CategoryName = catName
        FieldName = fldName
        FieldValue = fldVal
        FieldType = fldType
    End Sub

End Structure

