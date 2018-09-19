Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Management
Imports System.Net
Imports System.Runtime.CompilerServices

Module Helper

    Public SBUU_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_e2prom.bin"
    Public SBYD_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBYD_e2prom.bin"
    Public SBZZ_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBZZ_e2prom.bin"

    Sub GetGamePath()
        'Dim pList As List(Of String) = New List(Of String) From {My.Settings.Id6Path, My.Settings.Id7Path, My.Settings.Id8Path}
        'If pList.Contains(String.Empty) Then
        '    If File.Exists(My.Application.Info.DirectoryPath & "\UserProfiles\ID6.xml") Then
        '        Dim xd As New XmlDocument()
        '        xd.Load(My.Application.Info.DirectoryPath & "\UserProfiles\ID6.xml")
        '        Using items As XmlNodeList = xd.DocumentElement.SelectNodes("/GameProfile")
        '            For Each item As XmlNode In items
        '                Dim GamePath As String = item.SelectSingleNode("GamePath").InnerText
        '                If Not GamePath = "" Then
        '                    My.Settings.Id6Path = Path.GetDirectoryName(GamePath)
        '                    My.Settings.Save()
        '                End If
        '            Next
        '        End Using
        '    End If
        '    If File.Exists(My.Application.Info.DirectoryPath & "\UserProfiles\ID7.xml") Then
        '        Dim xd As New XmlDocument()
        '        xd.Load(My.Application.Info.DirectoryPath & "\UserProfiles\ID7.xml")
        '        Using items As XmlNodeList = xd.DocumentElement.SelectNodes("/GameProfile")
        '            For Each item As XmlNode In items
        '                Dim GamePath As String = item.SelectSingleNode("GamePath").InnerText
        '                If Not GamePath = "" Then
        '                    My.Settings.Id7Path = Path.GetDirectoryName(GamePath)
        '                    My.Settings.Save()
        '                End If
        '            Next
        '        End Using
        '    End If
        '    If File.Exists(My.Application.Info.DirectoryPath & "\UserProfiles\ID8.xml") Then
        '        Dim xd As New XmlDocument()
        '        xd.Load(My.Application.Info.DirectoryPath & "\UserProfiles\ID8.xml")
        '        Using items As XmlNodeList = xd.DocumentElement.SelectNodes("/GameProfile")
        '            For Each item As XmlNode In items
        '                Dim GamePath As String = item.SelectSingleNode("GamePath").InnerText
        '                If Not GamePath = "" Then
        '                    My.Settings.Id8Path = Path.GetDirectoryName(GamePath)
        '                    My.Settings.Save()
        '                End If
        '            Next
        '        End Using
        '    End If
        'End If
    End Sub

    Function GetHex(filename As String, offset As Integer, requiredBytes As Integer) As Byte()
        Dim value(0 To requiredBytes - 1) As Byte
        Using reader As New BinaryReader(File.Open(filename, FileMode.Open))
            ' Loop through length of file.
            Dim fileLength As Long = reader.BaseStream.Length
            Dim byteCount As Integer = 0
            reader.BaseStream.Seek(offset, SeekOrigin.Begin)
            While offset < fileLength And byteCount < requiredBytes
                value(byteCount) = reader.ReadByte()
                offset += 1
                byteCount += 1
            End While
        End Using

        Return value
    End Function

    Function Neg60(offset As Integer) As Integer
        Return (offset - 60)
    End Function

    Function Plus60(offset As Integer) As Integer
        Return (offset + 60)
    End Function

    Sub SetHex(filename As String, offset As Long, value As Byte())
        Try
            Dim fs As New FileStream(filename, FileMode.Open)
            Dim reader As New BinaryReader(fs)
            fs.Position = offset
            For Each num As Byte In value
                If num.ToString() = String.Empty Then
                    Exit For
                End If
                reader.BaseStream.WriteByte(num)
            Next
            reader.Close()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Function Neg3C(offset As Long) As Long
        Return (offset - &H3C)
    End Function

    Function Plus3C(offset As Long) As Long
        Return (offset + &H3C)
    End Function

    Enum Transmission
        AT
        MT
        Unk
    End Enum

    Function GetTransmission(hex As Byte()) As Transmission
        Dim tResult As Transmission = Transmission.Unk
        Dim result As Integer = CInt("&H" & BitConverter.ToString(hex).Replace("-", ""))
        Select Case result
            Case 0 To 80
                tResult = Transmission.AT
            Case 128 To 208
                tResult = Transmission.MT
            Case Else
                tResult = Transmission.Unk
        End Select
        Return tResult
    End Function

    '01灼熱
    '02旋風
    '03雷光
    '04邪気
    '05覇王
    '06飛翔

    Enum D7Aura
        None = 0
        ScorchingHot = 1
        Whirlwind = 2
        Lightning = 3
        EvilSpirit = 4
        Overlord = 5
        Fly = 6
    End Enum

    Function GetID7Aura(hex As Byte()) As D7Aura
        Dim result As Integer = CInt("&H" & BitConverter.ToString(hex).Replace("-", ""))
        Return result
    End Function

    Function GetTachometer(hex As Byte()) As Integer
        Dim result As Integer = CInt("&H" & BitConverter.ToString(hex).Replace("-", ""))
        Return result
    End Function

    Function GetName(hex As Byte()) As String
        Dim enc = Encoding.GetEncoding("shift-jis")
        Dim value = enc.GetString(hex)
        Return value
    End Function

    Function GetCarPerformancePart(carname As String) As Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))
        Dim result As Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String)) = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {Nothing}), New List(Of String)(New String() {Nothing}), New List(Of String)(New String() {Nothing}), New List(Of String)(New String() {Nothing}))
        Dim back As String = "00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF"
        Dim back2 As String = "00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF"
        Dim none As String = "00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF"
        Select Case carname
            'TOYOTA
            Case "TRUENO GT-APEX (AE86)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("1754", New List(Of String)(New String() {"21", "22", "70"}), New List(Of String)(New String() {"Turbo", "Supercharger", "Racing"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "LEVIN GT-APEX (AE86)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("1754", New List(Of String)(New String() {"21", "22", "20"}), New List(Of String)(New String() {"Turbo", "Supercharger", "Stock"}), New List(Of String)(New String() {"01BC0194" & back, "02BC0194" & back}), New List(Of String)(New String() {"Rollbar 1", "Rollbar 2"}))
            Case "LEVIN SR (AE85)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("0754", New List(Of String)(New String() {"21", "22", "20"}), New List(Of String)(New String() {"Turbo", "Supercharger", "Stock"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "86 GT (ZN6)", "FT-86 G Sports Concept"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("332C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "MR2 G-Limited (SW20)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2251", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "MR-S (ZZW30)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2261", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "ALTEZZA RS200 (SXE10)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("333C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "SUPRA RZ (JZA80)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("222C", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "PRIUS (ZVW30)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("1722", New List(Of String)(New String() {"A0"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
                'NISSAN
            Case "SKYLINE GT-R (BNR32)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3316", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "SKYLINE GT-R (BNR34)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("442E", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "SILVIA K's (S13)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2254", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "Silvia Q's (S14)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2214", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "Silvia spec-R (S15)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("227C", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "180SX TYPE II (RPS13)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3354", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "FAIRLADY Z (Z33)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("222C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "GT-R (R35)", "GT-R NISMO (R35)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("222E", New List(Of String)(New String() {"00"}), New List(Of String)(New String() {"None"}), New List(Of String)(New String() {none}), New List(Of String)(New String() {"None"}))
                'HONDA
            Case "Civic SiR・II (EG6)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("4452", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "CIVIC TYPE R (EK9)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("5552", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "INTEGRA TYPE R (DC2)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("5552", New List(Of String)(New String() {"21", "20"}), New List(Of String)(New String() {"Turbo", "Stock"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "S2000 (AP1)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("662C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "NSX (NA1)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("4411", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
                'MAZDA
            Case "RX-7 ∞III (FC3S)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2254", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "RX-7 Type R (FD3S)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3314", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2, "02BC019401BF" & back2}), New List(Of String)(New String() {"Keisuke Rollbar", "Kyoko Rollbar"}))
            Case "RX-7 Type RS (FD3S)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3324", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "RX-8 Type S (SE3P)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("662C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "ROADSTER (NA6CE)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3354", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "ROADSTER RS (NB8C)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("336C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
                'SUBARU
            Case "IMPREZA STi Ver.V (GC8)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3356", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "IMPREZA STi (GDBA)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("442E", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "IMPREZA STI (GDBF)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("442E", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
                'MITSUBISHI
            Case "LANCER Evolution III (CE9A)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2256", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "LANCER EVOLUTION IV (CN9A)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2256", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "LANCER Evolution VII (CT9A)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("2226", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "LANCER Evolution IX (CT9A)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("222E", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "LANCER EVOLUTION X (CZ4A)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("222E", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
                'SUZUKI
            Case "Cappuccino (EA11R)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("55C4", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
                'INITIAL D
            Case "SILEIGHTY"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3354", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "TRUENO 2door GT-APEX (AE86)", "SPRINTER TRUENO 2door GT-APEX (AE86)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("1154", New List(Of String)(New String() {"21", "22", "20"}), New List(Of String)(New String() {"Turbo", "Supercharger", "Stock"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
                'COMPLETE
            Case "G-FORCE SUPRA (JZA80-kai)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("222C", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "MONSTER CIVIC R (EK9)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("5522", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "NSX-R GT (NA2)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("4429", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "RE Amemiya Genki-7 (FD3S)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3324", New List(Of String)(New String() {"21"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC019401BF" & back2}), New List(Of String)(New String() {"None"}))
            Case "S2000 GT1 (AP1)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("442C", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
            Case "ROADSTER C-SPEC (NA8C Kai)"
                result = New Tuple(Of String, List(Of String), List(Of String), List(Of String), List(Of String))("3324", New List(Of String)(New String() {"20"}), New List(Of String)(New String() {"Fullspec"}), New List(Of String)(New String() {"01BC0194" & back}), New List(Of String)(New String() {"None"}))
        End Select
        Return result
    End Function

    Function GetCarColor(carname As String) As Tuple(Of String, List(Of String), List(Of String))
        Dim result As Tuple(Of String, List(Of String), List(Of String)) = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {Nothing}), New List(Of String)(New String() {Nothing}))

        Select Case carname
            'TOYOTA
            Case "TRUENO GT-APEX (AE86)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"HIGH TECH TWO TONE", "HIGH FLASH TWO TONE", "HIGH METAL TWO TONE", "WHITE", "YELLOW", "BLUE", "RED", "BLACK", "ORANGE", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LEVIN GT-APEX (AE86)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"HIGH TECH TWO TONE", "HIGH FLASH TWO TONE", "HIGH METAL TWO TONE", "WHITE", "YELLOW", "BLUE", "RED", "BLACK", "LIGHT GREEN", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LEVIN SR (AE85)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"WHITE", "RED", "SILVER METALLIC", "YELLOW", "BLUE", "LIGHT BLUE", "BLACK", "ORANGE", "LIGHT GREEN", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "86 GT (ZN6)", "FT-86 G Sports Concept"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"LIGHTNING RED", "SATIN WHITE PEARL", "STERLING SILVER METALLIC", "DARK GREY METALLIC", "CRYSTAL BLACK SILICA", "ORANGE METALLIC", "GALAXY BLUE SILICA", "HIGH TECH TWO TONE", "HIGH FLASH TWO TONE", "STERLING SILVER TWO TONE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "MR2 G-Limited (SW20)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"STRONG BLUE METALLIC", "SUPER WHITE Ⅱ", "BLUISH GREY ARGENTUM MICA", "BLACK", "SUPER RED Ⅱ", "SUPER BRIGHT YELLOW", "DARK GREEN MICA", "DARK PURPLE MICA", "ORANGE MICA METALLIC", "BEIGE MICA METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "MR-S (ZZW30)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SILVER METALLIC", "SUPER WHITE Ⅱ", "BLACK", "SUPER RED", "SUPER BRIGHT YELLOW", "GREEN MICA METALLIC", "BLUE MICA", "DARK PURPLE MICA", "ORANGE MICA METALLIC", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "ALTEZZA RS200 (SXE10)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SILVER METALLIC", "SUPER WHITE Ⅱ", "DARK GREY MICA METALLIC", "BLACK", "RED MICA METALLIC", "SUPER BRIGHT YELLOW", "DARK GREEN MICA", "BLUE MICA", "WINE RED", "ORANGE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "SUPRA RZ (JZA80)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SUPER WHITE Ⅱ", "DARK BROWNISH GREY MICA METALLIC", "SILVER METALLIC", "BLACK", "SUPER RED Ⅳ", "DEEP TEAL METALLIC", "SUPER BRIGHT YELLOW", "BLUE MICA", "ORANGE MICA METALLIC", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "PRIUS (ZVW30)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SUPER WHITE Ⅱ", "DARK BROWNISH GREY MICA METALLIC", "SILVER METALLIC", "BLACK", "RED MICA METALLIC", "AQUA BLUE METALLIC", "DARK BLUE METALLIC", "ICEBERG SILVER MICA METALLIC", "ORANGE MICA METALLIC", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "CELICA GT-FOUR (ST205)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"BLACK", "SUPER WHITE �U", "SILVER METALLIC", "SUPER RED �W", "LIGHT GREEN METALLIC", "BLUE MICA METALLIC", "YELLOW", "DARK PURPLE MICA", "ORANGE MICA METALLIC", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL RED/GRADATION", "SPECIAL BLUE/GRADATION", "SPECIAL YELLOW/GRADATION"}))
                'NISSAN
            Case "SKYLINE GT-R (BNR32)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"BLACK PEARL METALLIC", "GUN GREY METALLIC", "CRYSTAL WHITE", "SPARKLE SILVER METALLIC", "RED PEARL", "BLUE", "ACTIVE RED", "LIGHTNING YELLOW", "MIDNIGHT PURPLE", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "SKYLINE GT-R (BNR34)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"MILLENNIUM JADE", "BAYSIDE BLUE", "WHITE PEARL", "WHITE", "SPARKLING SILVER", "BLACK PEARL", "SILICA BRASS", "LIGHTNING YELLOW", "MIDNIGHT PURPLE Ⅱ", "DARK RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "SILVIA K's (S13)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"LIME GREEN TWO TONE", "BLUISH SILVER TWO TONE", "WARM WHITE TWO TONE", "VELVET BLUE", "CRANBERRY RED", "SUPER BLACK", "SUPER RED", "YELLOW", "ORANGE", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "Silvia Q's (S14)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SUPER CLEAR RED", "GREENISH BLUE", "SUPER BLACK", "BLUISH SILVER", "PEARL WHITE", "BRILLIANT BLUE", "RED", "LIGHTNING YELLOW", "ORANGE", "PURPLE METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "Silvia spec-R (S15)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SPARKLING SILVER", "BRILLIANT BLUE", "PEARL WHITE", "SUPER RED", "SUPER BLACK", "LIGHTNING YELLOW", "GREEN", "GOLD", "ORANGE", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "180SX TYPE II (RPS13)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"WARM WHITE", "YELLOWISH SILVER", "SUPER BLACK", "DARK GREY", "SUPER RED", "VELVET BLUE", "PURPLISH GREY", "RED PEARL METALLIC", "LIGHTNING YELLOW", "ORANGE METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "FAIRLADY Z (Z33)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"BURNING RED", "MONTEREY BLUE", "SUNSET ORANGE", "WHITE PEARL", "DIAMOND SILVER", "SPARKLING SILVER", "SUPER BLACK", "PINK", "MIDNIGHT PURPLE", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "GT-R (R35)", "GT-R NISMO (R35)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"ULTIMATE METAL SILVER", "TITANIUM GRAY", "WHITE PEARL", "VIBRANT RED", "DARK METAL GRAY", "SUPER BLACK", "SILICA BRASS", "LIGHTNING YELLOW", "MIDNIGHT PURPLE Ⅱ", "BAYSIDE BLUE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "SKYLINE 25GT TURBO (ER34)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"DARK BLUE PEARL", "BLACK PEARL", "LIGHTNING YELLOW", "ATHLETE SILVER", "SONIC SILVER", "ACTIVE RED", "WHITE", "PINK", "MIDNIGHT PURPLE", "CHAMPAGNE GOLD", "SPECIAL GREEN/GRADATION", "SPECIAL RED/GRADATION", "SPECIAL BLUE/GRADATION", "SPECIAL YELLOW/GRADATION"}))
                'HONDA
            Case "Civic SiR・II (EG6)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"MILANO RED", "CAPTIVA BLUE PEARL", "FROST WHITE", "PEWTER GREY METALLIC", "CARNIVAL YELLOW", "BRILLIANT BLACK", "VOGUE SILVER METALLIC", "BLUE", "NEW IMOLA ORANGE PEARL", "SAMBA GREEN PEARL", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "CIVIC TYPE R (EK9)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SUNLIGHT YELLOW", "CHAMPIONSHIP WHITE", "STARLIGHT BLACK PEARL", "VOGUE SILVER METALLIC", "ARCTIC BLUE PEARL", "MILANO RED", "MOONROCK METALLIC", "ROYAL NAVY BLUE PEARL", "NEW IMOLA ORANGE PEARL", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "INTEGRA TYPE R (DC2)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CHAMPIONSHIP WHITE", "GRANADA BLACK PEARL", "MILANO RED", "VOGUE SILVER METALLIC", "ARCTIC BLUE PEARL", "SUNLIGHT YELLOW", "MOONROCK METALLIC", "ROYAL NAVY BLUE PEARL", "NEW IMOLA ORANGE PEARL", "PURPLE METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "S2000 (AP1)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"LONG BEACH BLUE PEARL", "SILVERSTONE METALLIC", "BERLINA BLACK", "NEW FORMULA RED", "MONTE CARLO BLUE PEARL", "INDY YELLOW PEARL", "GRAND PRIX WHITE", "DEEP BURGUNDY METALLIC", "NEW IMOLA ORANGE PEARL", "LIME GREEN METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "NSX (NA1)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"NEW FORMULA RED", "SEBRING SILVER METALLIC", "KAISER SILVER METALLIC", "BERLINA BLACK", "CHARLOTTE GREEN PEARL", "NEUTRON WHITE PEARL", "INDY YELLOW PEARL", "CHAMPIONSHIP WHITE", "NEW IMOLA ORANGE PEARL", "MONTE CARLO BLUE PEARL", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
                'MAZDA
            Case "RX-7 ∞III (FC3S)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CRYSTAL WHITE", "BRILLIANT BLACK", "SHADOW SILVER", "WINNING SILVER", "BLAZE RED", "HARBOR BLUE", "SHADE GREEN", "YELLOW", "ORANGE METALLIC", "INNOCENT BLUE MICA", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "RX-7 Type R (FD3S)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"COMPETITION YELLOW MICA", "BRILLIANT BLACK", "VINTAGE RED", "SILVERSTONE METALLIC", "MONTEGO BLUE MICA", "CHASTE WHITE", "INNOCENT BLUE MICA", "SUNBURST YELLOW", "ORANGE", "BLUE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "RX-7 Type RS (FD3S)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"VINTAGE RED", "INNOCENT BLUE MICA", "SUNLIGHT SILVER METALLIC", "BRILLIANT BLACK", "PURE WHITE", "METALLIC MAZENDA", "GREEN", "SUNBURST YELLOW", "TITANIUM GRAY METALLIC", "BLUE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "RX-8 Type S (SE3P)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"VELOCITY RED MICA", "STORMY BLUE MICA", "GALAXY GREY MICA", "WINNING SILVER METALLIC", "SUNLIGHT SILVER METALLIC", "CRYSTAL WHITE PEARL MICA", "PHANTOM BLUE MICA", "BRILLIANT BLACK", "LIGHTNING YELLOW", "GREEN", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "ROADSTER (NA6CE)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CLASSIC RED", "SILVERSTONE METALLIC", "CRYSTAL WHITE", "MARINER BLUE", "NEO GREEN", "ARTVIN RED MICA", "SATELLITE BLUE MICA", "LAGUNA BLUE METALLIC", "SPARKLING GREEN METALLIC", "SUNBURST YELLOW", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "ROADSTER RS (NB8C)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"EVOLUTION ORANGE MICA", "CLASSIC RED", "TWILIGHT BLUE MICA", "HIGHLIGHT SILVER METALLIC", "BRILLIANT BLACK", "SHASTE WHITE", "GRACE GREEN MICA", "CRYSTAL BLUE METALLIC", "RADIANT EBONY MICA", "SUNBURST YELLOW", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
                'SUBARU
            Case "IMPREZA STi Ver.V (GC8)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SONIC BLUE MICA", "PURE WHITE", "ARCTIC SILVER METALLIC", "BLACK MICA", "COOL GREY METALLIC", "ROSE RED MICA", "SPORTS YELLOW", "COSMIC BLUE MICA", "ORANGE METALLIC", "YELLOW", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "IMPREZA STi (GDBA)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"WR BLUE MICA", "MIDNIGHT BLACK MICA", "PREMIUM SILVER METALLIC", "PURE WHITE", "URBAN GREY METALLIC", "SOLID RED", "YELLOW", "ASTRAL YELLOW", "ORANGE METALLIC", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "IMPREZA STI (GDBF)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"WR BLUE MICA", "OBSIDIAN BLACK PEARL", "PREMIUM SILVER METALLIC", "PURE WHITE", "URBAN GREY METALLIC", "SOLID RED", "YELLOW", "ASTRAL YELLOW", "ORANGE METALLIC", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "BRZ S (ZC6)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C"}), New List(Of String)(New String() {"WR BLUE MICA", "SATIN WHITE PEARL", "STERLING SILVER METALLIC", "DARK GREY METALLIC", "CRYSTAL BLACK SILICA", "LIGHTNING RED", "GALAXY BLUE SILICA", "SPORTS YELLOW", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL RED/GRADATION", "SPECIAL BLUE/GRADATION", "SPECIAL YELLOW/GRADATION"}))
                'MITSUBISHI
            Case "LANCER Evolution III (CE9A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"PYRENEES BLACK", "SCOTIA WHITE", "QUEEN'S SILVER", "DANDELION YELLOW", "MONACO RED", "MOON LIGHT BLUE", "ORANGE", "DEEP PURPLE METALLIC", "WINE RED", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LANCER EVOLUTION IV (CN9A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SCOTIA WHITE", "STEEL SILVER", "PYRENEES BLACK", "PALMA RED", "IJSSEL BLUE", "MOON LIGHT BLUE", "ORANGE", "LEMON YELLOW", "WINE RED", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LANCER Evolution VII (CT9A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"DANDELION YELLOW", "FRENCH BLUE", "SATELLITE SILVER", "AMETHYST BLACK", "EISEN GREY METALLIC", "PALMA RED", "SCOTIA WHITE", "YELLOW　METALLIC", "WINE RED", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LANCER Evolution IX (CT9A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"COOL SILVER METALLIC", "BLACK MICA", "BLUE MICA", "SOLID YELLOW", "SOLID RED", "SOLID WHITE", "MEDIUM PURPLISH GREY MICA", "LEMON YELLOW", "WINE RED", "PURPLE METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LANCER EVOLUTION X (CZ4A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"RED METALLIC", "LIGHTNING BLUE MICA", "COOL SILVER METALLIC", "PHANTOM BLACK PEARL", "WHITE PEARL", "SOLID RED", "MEDIUM PURPLISH GREY MICA", "LEMON YELLOW", "GREEN", "PURPLE METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "LANCER RS EVOLUTION V (CP9A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SCOTIA WHITE", "SATELLITE SILVER", "PYRENEES BLACK", "PALMA RED", "DANDELION YELLOW", "DEEP BLUE MICA", "ORANGE", "LEMON YELLOW", "WINE RED", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL RED/GRADATION", "SPECIAL BLUE/GRADATION", "SPECIAL YELLOW/GRADATION"}))
            Case "LANCER GSR EVOLUTION VI T.M.EDITION (CP9A)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SCOTIA WHITE", "SATELLITE SILVER", "PYRENEES BLACK", "CANAL BLUE", "PASSION RED", "MOON LIGHT BLUE", "ORANGE", "LEMON YELLOW", "WINE RED", "GREEN", "SPECIAL GREEN/GRADATION", "SPECIAL RED/GRADATION", "SPECIAL BLUE/GRADATION", "SPECIAL YELLOW/GRADATION"}))
                'SUZUKI
            Case "Cappuccino (EA11R)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CORDOVA RED", "SATELLITE SILVER METALLIC", "DARK CLASSIC JADE PEARL", "DEEP BLUE PEARL", "SATURN BLACK METALLIC", "BRITISH GREEN PEARL", "YELLOW", "BLUE MICA", "WHITE", "ORANGE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
                'INITIAL D
            Case "SILEIGHTY"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"IMPACT BLUE", "YELLOWISH SILVER", "SUPER BLACK", "DARK GREY", "SUPER RED", "VELVET BLUE", "PURPLISH GREY", "WARM WHITE", "LIGHTNING YELLOW", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "TRUENO 2door GT-APEX (AE86)", "SPRINTER TRUENO 2door GT-APEX (AE86)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"HIGH TECH TWO TONE", "HIGH FLASH TWO TONE", "HIGH METAL TWO TONE", "WHITE", "YELLOW", "BLUE", "RED", "BLACK", "ORANGE", "PINK", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
                'COMPLETE
            Case "G-FORCE SUPRA (JZA80-kai)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"TOP SECRET GOLD", "SUPER WHITE Ⅱ", "DARK BROWNISH GREY MICA METALLIC", "SILVER METALLIC", "BLACK", "SUPER RED Ⅳ", "DEEP TEAL METALLIC", "SUPER BRIGHT YELLOW", "BLUE MICA", "ORANGE MICA METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "MONSTER CIVIC R (EK9)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CHAMPIONSHIP WHITE", "SUNLIGHT YELLOW", "STARLIGHT BLACK PEARL", "VOGUE SILVER METALLIC", "ARCTIC BLUE PEARL", "MILANO RED", "MOONROCK METALLIC", "ROYAL NAVY BLUE PEARL", "NEW IMOLA ORANGE PEARL", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "NSX-R GT (NA2)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CHAMPIONSHIP WHITE", "NEW FORMULA RED", "NEW INDY YELLOW PEARL", "SEBRING SILVER METALLIC", "BERLINA BLACK", "SILVERSTONE METALLIC", "KAISER SILVER METALLIC", "CHARLOTTE GREEN PEARL", "NEW IMOLA ORANGE PEARL", "MONTE CARLO BLUE PEARL", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "RE Amemiya Genki-7 (FD3S)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"DEEP BLUE", "LIGHT BLUE", "VINTAGE RED", "SUNLIGHT SILVER METALLIC", "BRILLIANT BLACK", "PURE WHITE", "METALLIC MAZENDA", "GREEN", "SUNBURST YELLOW", "TITANIUM GRAY METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "S2000 GT1 (AP1)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"GRAND PRIX WHITE", "NEW FORMULA RED", "LONG BEACH BLUE PEARL", "SILVERSTONE METALLIC", "BERLINA BLACK", "MONTE CARLO BLUE PEARL", "INDY YELLOW PEARL", "DEEP BURGUNDY METALLIC", "NEW IMOLA ORANGE PEARL", "LIME GREEN METALLIC", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "ROADSTER C-SPEC (NA8C Kai)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"SILVERSTONE METALLIC", "CLASSIC RED", "NEO GREEN", "SHASTE WHITE", "TWILIGHT BLUE MICA", "EVOLUTION ORANGE MICA", "BRILLIANT BLACK", "GRACE GREEN MICA", "RADIANT EBONY MICA", "SUNBURST YELLOW", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
        End Select
        Return result
    End Function

    Function GetEventSticker(Optional ver As Integer = 7) As Tuple(Of String, List(Of String), List(Of String))
        Dim result As Tuple(Of String, List(Of String), List(Of String)) = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"FF", "95", "96", "01", "7D", "22", "28", "7A", "76", "5E", "1B", "7B", "21", "81", "8F", "73", "91", "4A", "14", "31", "42", "02", "5F", "5D", "56", "48", "03", "5B", "70", "37", "04", "57", "67", "32", "69", "61", "51", "11", "0E", "05", "75", "72", "93", "24", "84", "25", "16", "36", "06", "65", "40", "77", "60", "2D", "23", "26", "07", "74", "43", "78", "1D", "1E", "2C", "54", "6C", "39", "8C", "92", "3E", "8E", "44", "12", "49", "68", "94", "4D", "6E", "15", "6B", "52", "00", "6D", "3D", "29", "7E", "0F", "4F", "79", "10", "45", "3A", "4E", "58", "A0", "A6", "46", "47", "80", "17", "63", "3F", "59", "1C", "2B", "83", "1A", "2A", "85", "4B", "53", "19", "1F", "6A", "0C", "5C", "86", "62", "0A", "27", "2F", "0D", "71", "13", "82", "7C", "8B", "38", "87", "4C", "7F", "30", "89", "8A", "A4", "A3", "A2", "A5", "35", "50", "33", "09", "20", "64", "88", "2E", "66", "3C", "90", "6F", "8D", "41", "18", "A1", "34", "5A", "55", "08", "A7", "A8", "A9", "AA", "AB", "97", "98"}), New List(Of String)(New String() {"None", "週刊ヤングマガジン", "頭文字D", "TOYOTA", "TRD", "C-ONE", "Crystal Body Yokohama", "TOM'S", "TARGET", "ネッツトヨタ", "ブーム", "TOOL BOX", "Complete Speed", "UGO", "横浜レーシング＆スポーツ", "スティルウェイ", "YSS", "IMPUL", "BEE☆R", "FPS", "HASEMI MOTOR SPORT", "NISSAN", "nismo", "Myumyu Papa Factory", "MARGA HILLS PRODUCTS", "HONDA TWINCAM", "Honda", "無限", "SPOON", "GARAGE VARY", "MAZDA", "MAZDASPEED", "RE雨宮", "藤田エンジニアリング", "R Magic", "PAN SPEED", "KNIGHT SPORTS", "AutoExe", "AQUA", "SUBARU", "SYMS", "STI", "ZERO/SPORTS", "CREATIVE-SPORTS", "VALDI sport", "CRUISE", "BFMフルブラスト", "Garage HRS", "MITSUBISHI", "RALLIART", "HALFWAY", "TAKE OFF", "NRF", "エリートSPL", "コスミック・ガレージ", "Crux", "SUZUKI", "SUZUKI SPORT", "HEARTLAND", "Techno PRO Spirit", "BOZZ SPEED", "CASHIEWスポーツ", "EAST BEAR SPORTS", "車工房リキ", "SARD", "GIALLA", "WIN CORPORATION", "ZEAL", "グランドスラム習志野", "ワークスベル", "Hippo sleek", "オートステージ", "アイメック", "レイブロス", "けつばん", "J'S RACING", "シグナル", "Besiege", "サンアイワークス", "K-ONE", "けつばん", "シーケンシャル", "グレネード", "CUSCO", "TRUTH", "ARC", "JUN", "テトラクリエイト", "ARP SPORT", "HKS", "GOOD LINE", "Jubiride", "MCR", "ADVANCE", "AUTO PRODUCE BOSS", "HKS関西", "HKS九州", "TRUST", "BLITZ", "RS☆R", "圭オフィス", "Mine's", "BORDER", "D.speed", "浮谷商会", "BOMEX", "C-WEST", "VARIS", "ings", "KSAUTO×BURNOUT", "BN Sports", "CHARGE SPEED", "ルーキー", "アレスクリエイト", "MYTHOS", "VeilSide", "PHOENIX's POWER", "Abflag", "CRUX_other", "ファースト", "エアロステーション", "STOUT", "AXIA SPORTS", "URAS", "TOP SECRET", "WEST YOKOHAMA", "Gコーポレーション", "VERTEX", "j.blood", "TRIAL", "First Molding", "VOLTEX", "VOLTEX(ボツ)", "Route KS", "GP SPORTS", "FreeStyle", "Garage Kagotani", "GarageBB", "柿本改", "FUJITSUBO", "5ZIGEN", "CIBIE", "RS-Watanabe", "VOLK RACING", "ENKEI", "RAYS", "GRAM LIGHTS", "YOKOHAMA", "SPEED STAR WHEEL", "WORK", "Racing Hart", "B.I.M creativestudio", "BBS", "GANADOR", "monster", "ラ・アンスポーツ", "DAIHATSU", "ASI", "TOMMYKAIRA", "power house amuse", "TOP SECRET", "MODELLISTA", "頭文字D簡体字版", "GACKT"}))
        If ver = 6 Then result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"FF", "95", "96", "01", "7D", "22", "28", "7A", "76", "5E", "1B", "7B", "21", "81", "8F", "73", "91", "4A", "14", "31", "42", "02", "5F", "5D", "56", "48", "03", "5B", "70", "37", "04", "57", "67", "32", "69", "61", "51", "11", "0E", "05", "75", "72", "93", "24", "84", "25", "16", "36", "06", "65", "40", "77", "60", "2D", "23", "26", "07", "74", "43", "78", "1D", "1E", "2C", "54", "6C", "39", "8C", "92", "3E", "8E", "44", "12", "49", "68", "94", "4D", "6E", "15", "6B", "52", "00", "6D", "3D", "29", "7E", "0F", "4F", "79", "10", "45", "3A", "4E", "58", "A0", "A6", "46", "47", "80", "17", "63", "3F", "59", "1C", "2B", "83", "1A", "2A", "85", "4B", "53", "19", "1F", "6A", "0C", "5C", "86", "62", "0A", "27", "2F", "0D", "71", "13", "82", "7C", "8B", "38", "87", "4C", "7F", "30", "89", "8A", "A4", "A3", "A2", "A5", "35", "50", "33", "09", "20", "64", "88", "2E", "66", "3C", "90", "6F", "8D", "41", "18", "A1", "34", "5A", "55", "08", "A7", "A8"}), New List(Of String)(New String() {"None", "週刊ヤングマガジン", "頭文字D", "TOYOTA", "TRD", "C-ONE", "Crystal Body Yokohama", "TOM'S", "TARGET", "ネッツトヨタ", "ブーム", "TOOL BOX", "Complete Speed", "UGO", "横浜レーシング＆スポーツ", "スティルウェイ", "YSS", "IMPUL", "BEE☆R", "FPS", "HASEMI MOTOR SPORT", "NISSAN", "nismo", "Myumyu Papa Factory", "MARGA HILLS PRODUCTS", "HONDA TWINCAM", "Honda", "無限", "SPOON", "GARAGE VARY", "MAZDA", "MAZDASPEED", "RE雨宮", "藤田エンジニアリング", "R Magic", "PAN SPEED", "KNIGHT SPORTS", "AutoExe", "AQUA", "SUBARU", "SYMS", "STI", "ZERO/SPORTS", "CREATIVE-SPORTS", "VALDI sport", "CRUISE", "BFMフルブラスト", "Garage HRS", "MITSUBISHI", "RALLIART", "HALFWAY", "TAKE OFF", "NRF", "エリートSPL", "コスミック・ガレージ", "Crux", "SUZUKI", "SUZUKI SPORT", "HEARTLAND", "Techno PRO Spirit", "BOZZ SPEED", "CASHIEWスポーツ", "EAST BEAR SPORTS", "車工房リキ", "SARD", "GIALLA", "WIN CORPORATION", "ZEAL", "グランドスラム習志野", "ワークスベル", "Hippo sleek", "オートステージ", "アイメック", "レイブロス", "けつばん", "J'S RACING", "シグナル", "Besiege", "サンアイワークス", "K-ONE", "けつばん", "シーケンシャル", "グレネード", "CUSCO", "TRUTH", "ARC", "JUN", "テトラクリエイト", "ARP SPORT", "HKS", "GOOD LINE", "Jubiride", "MCR", "ADVANCE", "AUTO PRODUCE BOSS", "HKS関西", "HKS九州", "TRUST", "BLITZ", "RS☆R", "圭オフィス", "Mine's", "BORDER", "D.speed", "浮谷商会", "BOMEX", "C-WEST", "VARIS", "ings", "KSAUTO×BURNOUT", "BN Sports", "CHARGE SPEED", "ルーキー", "アレスクリエイト", "MYTHOS", "VeilSide", "PHOENIX's POWER", "Abflag", "CRUX_other", "ファースト", "エアロステーション", "STOUT", "AXIA SPORTS", "URAS", "TOP SECRET", "WEST YOKOHAMA", "Gコーポレーション", "VERTEX", "j.blood", "TRIAL", "First Molding", "VOLTEX", "VOLTEX(ボツ)", "Route KS", "GP SPORTS", "FreeStyle", "Garage Kagotani", "GarageBB", "柿本改", "FUJITSUBO", "5ZIGEN", "CIBIE", "RS-Watanabe", "VOLK RACING", "ENKEI", "RAYS", "GRAM LIGHTS", "YOKOHAMA", "SPEED STAR WHEEL", "WORK", "Racing Hart", "B.I.M creativestudio", "BBS", "GANADOR", "monster", "ラ・アンスポーツ", "DAIHATSU", "ASI", "TOMMYKAIRA"}))
        Return result
    End Function

    Function GetCar(hex As Byte(), hex2 As Byte(), Optional ver As Integer = 7) As String
        Dim result As String = Nothing
        Dim ff As String = BitConverter.ToString(hex2).Replace("-", "")
        If Not ff = "00" Then
            Select Case BitConverter.ToString(hex).Replace("-", "")
            'TOYOTA
                Case "0000"
                    result = "TRUENO GT-APEX (AE86)"
                Case "0100"
                    result = "LEVIN GT-APEX (AE86)"
                Case "0200"
                    result = "LEVIN SR (AE85)"
                Case "0700"
                    If ver = 6 Then
                        result = "FT-86 G Sports Concept"
                    Else
                        result = "86 GT (ZN6)"
                    End If
                Case "0300"
                    result = "MR2 G-Limited (SW20)"
                Case "0500"
                    result = "MR-S (ZZW30)"
                Case "0400"
                    result = "ALTEZZA RS200 (SXE10)"
                Case "0600"
                    result = "SUPRA RZ (JZA80)"
                Case "0800"
                    result = "PRIUS (ZVW30)"
                Case "0900"
                    result = "SPRINTER TRUENO 2door GT-APEX (AE86)"
                Case "0A00"
                    result = "CELICA GT-FOUR (ST205)"
                'NISSAN
                Case "0001"
                    result = "SKYLINE GT-R (BNR32)"
                Case "0101"
                    result = "SKYLINE GT-R (BNR34)"
                Case "0201"
                    result = "SILVIA K's (S13)"
                Case "0301"
                    result = "Silvia Q's (S14)"
                Case "0401"
                    result = "Silvia spec-R (S15)"
                Case "0501"
                    result = "180SX TYPE II (RPS13)"
                Case "0601"
                    result = "FAIRLADY Z (Z33)"
                Case "0701"
                    If ver = 8 Then
                        result = "GT-R NISMO (R35)"
                    Else
                        result = "GT-R (R35)"
                    End If
                Case "0801"
                    result = "SKYLINE 25GT TURBO (ER34)"
               'HONDA
                Case "0002"
                    result = "Civic SiR・II (EG6)"
                Case "0102"
                    result = "CIVIC TYPE R (EK9)"
                Case "0202"
                    result = "INTEGRA TYPE R (DC2)"
                Case "0302"
                    result = "S2000 (AP1)"
                Case "0402"
                    result = "NSX (NA1)"
                'MAZDA
                Case "0003"
                    result = "RX-7 ∞III (FC3S)"
                Case "0103"
                    result = "RX-7 Type R (FD3S)"
                Case "0503"
                    result = "RX-7 Type RS (FD3S)"
                Case "0203"
                    result = "RX-8 Type S (SE3P)"
                Case "0303"
                    result = "ROADSTER (NA6CE)"
                Case "0403"
                    result = "ROADSTER RS (NB8C)"
                'SUBARU
                Case "0004"
                    result = "IMPREZA STi Ver.V (GC8)"
                Case "0204"
                    result = "IMPREZA STi (GDBA)"
                Case "0104"
                    result = "IMPREZA STI (GDBF)"
                Case "0304"
                    result = "BRZ S (ZC6)"
                'MITSUBISHI
                Case "0005"
                    result = "LANCER Evolution III (CE9A)"
                Case "0105"
                    result = "LANCER EVOLUTION IV (CN9A)"
                Case "0305"
                    result = "LANCER Evolution VII (CT9A)"
                Case "0205"
                    result = "LANCER Evolution IX (CT9A)"
                Case "0405"
                    result = "LANCER EVOLUTION X (CZ4A)"
                Case "0605"
                    result = "LANCER GSR EVOLUTION VI T.M.EDITION (CP9A)"
                Case "0505"
                    result = "LANCER RS EVOLUTION V (CP9A)"
                'SUZUKI
                Case "0006"
                    result = "Cappuccino (EA11R)"
                'INITIAL D
                Case "0007"
                    result = "SILEIGHTY"
                Case "0107"
                    result = "TRUENO 2door GT-APEX (AE86)"
                'COMPLETE
                Case "0308"
                    result = "G-FORCE SUPRA (JZA80-kai)"
                Case "0108"
                    result = "MONSTER CIVIC R (EK9)"
                Case "0508"
                    result = "NSX-R GT (NA2)"
                Case "0008"
                    result = "RE Amemiya Genki-7 (FD3S)"
                Case "0208"
                    result = "S2000 GT1 (AP1)"
                Case "0408"
                    result = "ROADSTER C-SPEC (NA8C Kai)"
                Case Else
                    result = BitConverter.ToString(hex).Replace("-", "")
            End Select
        Else
            result = ""
        End If
        Return result
    End Function

    Function SetCar(carName As String) As String
        Dim result As String = Nothing
        Select Case carName
            'TOYOTA
            Case "TRUENO GT-APEX (AE86)"
                result = "0000"
            Case "LEVIN GT-APEX (AE86)"
                result = "0100"
            Case "LEVIN SR (AE85)"
                result = "0200"
            Case "86 GT (ZN6)", "FT-86 G Sports Concept"
                result = "0700"
            Case "MR2 G-Limited (SW20)"
                result = "0300"
            Case "MR-S (ZZW30)"
                result = "0500"
            Case "ALTEZZA RS200 (SXE10)"
                result = "0400"
            Case "SUPRA RZ (JZA80)"
                result = "0600"
            Case "PRIUS (ZVW30)"
                result = "0800"
            Case "CELICA GT-FOUR (ST205)"
                result = "0A00"
            Case "SPRINTER TRUENO 2door GT-APEX (AE86)"
                result = "0900"
                'NISSAN
            Case "SKYLINE GT-R (BNR32)"
                result = "0001"
            Case "SKYLINE GT-R (BNR34)"
                result = "0101"
            Case "SILVIA K's (S13)"
                result = "0201"
            Case "Silvia Q's (S14)"
                result = "0301"
            Case "Silvia spec-R (S15)"
                result = "0401"
            Case "180SX TYPE II (RPS13)"
                result = "0501"
            Case "FAIRLADY Z (Z33)"
                result = "0601"
            Case "GT-R (R35)", "GT-R NISMO (R35)"
                result = "0701"
            Case "SKYLINE 25GT TURBO (ER34)"
                result = "0801"
                'HONDA
            Case "Civic SiR・II (EG6)"
                result = "0002"
            Case "CIVIC TYPE R (EK9)"
                result = "0102"
            Case "INTEGRA TYPE R (DC2)"
                result = "0202"
            Case "S2000 (AP1)"
                result = "0302"
            Case "NSX (NA1)"
                result = "0402"
                'MAZDA
            Case "RX-7 ∞III (FC3S)"
                result = "0003"
            Case "RX-7 Type R (FD3S)"
                result = "0103"
            Case "RX-7 Type RS (FD3S)"
                result = "0503"
            Case "RX-8 Type S (SE3P)"
                result = "0203"
            Case "ROADSTER (NA6CE)"
                result = "0303"
            Case "ROADSTER RS (NB8C)"
                result = "0403"
                'SUBARU
            Case "IMPREZA STi Ver.V (GC8)"
                result = "0004"
            Case "IMPREZA STi (GDBA)"
                result = "0204"
            Case "IMPREZA STI (GDBF)"
                result = "0104"
            Case "BRZ S (ZC6)"
                result = "0304"
                'MITSUBISHI
            Case "LANCER Evolution III (CE9A)"
                result = "0005"
            Case "LANCER EVOLUTION IV (CN9A)"
                result = "0105"
            Case "LANCER Evolution VII (CT9A)"
                result = "0305"
            Case "LANCER Evolution IX (CT9A)"
                result = "0205"
            Case "LANCER EVOLUTION X (CZ4A)"
                result = "0405"
            Case "LANCER RS EVOLUTION V (CP9A)"
                result = "0505"
            Case "LANCER GSR EVOLUTION VI T.M.EDITION (CP9A)"
                result = "0605"
                'SUZUKI
            Case "Cappuccino (EA11R)"
                result = "0006"
                'INITIAL D
            Case "SILEIGHTY"
                result = "0007"
            Case "TRUENO 2door GT-APEX (AE86)"
                result = "0107"
                'COMPLETE
            Case "G-FORCE SUPRA (JZA80-kai)"
                result = "0308"
            Case "MONSTER CIVIC R (EK9)"
                result = "0108"
            Case "NSX-R GT (NA2)"
                result = "0508"
            Case "RE Amemiya Genki-7 (FD3S)"
                result = "0008"
            Case "S2000 GT1 (AP1)"
                result = "0208"
            Case "ROADSTER C-SPEC (NA8C Kai)"
                result = "0408"
            Case Else
                result = "FFFF"
        End Select
        Return result
    End Function

    Function GetChapterLevel(hex As Byte()) As String
        Return Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
    End Function

    Function GetPridePoint(hex1 As Byte(), hex2 As Byte()) As String
        Return CInt("&H" & BitConverter.ToString(hex2).Replace("-", "") & BitConverter.ToString(hex1).Replace("-", ""))
    End Function

    Function SetPridePoint(pPoint As Integer) As String
        Dim hexString As String = pPoint.ToString("X4")
        Dim F2 = hexString.Substring(0, 2)
        Dim L2 = hexString.Substring(2)
        Return L2 & F2
    End Function

    Function GetMilelage(hex1 As Byte(), hex2 As Byte(), hex3 As Byte(), hex4 As Byte()) As String
        Return CInt("&H" & BitConverter.ToString(hex4).Replace("-", "") & BitConverter.ToString(hex3).Replace("-", "") & BitConverter.ToString(hex2).Replace("-", "") & BitConverter.ToString(hex1).Replace("-", ""))
    End Function

    Function GetPlateNumber(hex1 As Byte(), hex2 As Byte(), hex3 As Byte()) As String
        Return CInt("&H" & BitConverter.ToString(hex3).Replace("-", "") & BitConverter.ToString(hex2).Replace("-", "") & BitConverter.ToString(hex1).Replace("-", ""))
    End Function

    Function SetMilelage(mileage As Integer) As String
        Dim hexString As String = mileage.ToString("X8")

        Dim F4 = hexString.Substring(0, 4)
        Dim L4 = hexString.Substring(4)
        Dim F2 = F4.Substring(0, 2)
        Dim L2 = F4.Substring(2)
        Dim _F2 = L4.Substring(0, 2)
        Dim _L2 = L4.Substring(2)
        Return _L2 & _F2 & L2 & F2
    End Function

    Function SetPlateNumber(plate As Integer) As String
        Dim hexString As String = plate.ToString("X6")

        Dim F4 = hexString.Substring(0, 4)
        Dim L4 = hexString.Substring(4)
        Dim F2 = F4.Substring(0, 2)
        Dim L2 = F4.Substring(2)
        Return L4 & L2 & F2
    End Function

    Function GetLevel(hex As Byte(), Optional num As Boolean = False, Optional d8 As Boolean = False) As String
        Dim result As String = Nothing
        If num Then
            result = Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
        Else
            If d8 Then
                Select Case Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
                    Case 1
                        result = "E3"
                    Case 2
                        result = "E2"
                    Case 3
                        result = "E1"
                    Case 4
                        result = "D3"
                    Case 5
                        result = "D2"
                    Case 6
                        result = "D1"
                    Case 7
                        result = "C3"
                    Case 8
                        result = "C2"
                    Case 9
                        result = "C1"
                    Case 10
                        result = "B3"
                    Case 11
                        result = "B2"
                    Case 12
                        result = "B1"
                    Case 13
                        result = "A3"
                    Case 14
                        result = "A2"
                    Case 15
                        result = "A1"
                    Case 16
                        result = "S3"
                    Case 17
                        result = "S2"
                    Case 18
                        result = "S1"
                    Case 19
                        result = "SS3"
                    Case 20
                        result = "SS2"
                    Case 21
                        result = "SS1"
                    Case 22
                        result = "∞"
                    Case Else
                        result = Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
                End Select
            Else
                Select Case Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
                    Case 1
                        result = "E3"
                    Case 2
                        result = "E2"
                    Case 3
                        result = "E1"
                    Case 4
                        result = "D3"
                    Case 5
                        result = "D2"
                    Case 6
                        result = "D1"
                    Case 7
                        result = "C3"
                    Case 8
                        result = "C2"
                    Case 9
                        result = "C1"
                    Case 10
                        result = "B3"
                    Case 11
                        result = "B2"
                    Case 12
                        result = "B1"
                    Case 13
                        result = "A3"
                    Case 14
                        result = "A2"
                    Case 15
                        result = "A1"
                    Case 16
                        result = "S3"
                    Case 17
                        result = "S2"
                    Case 18
                        result = "S1"
                    Case 19
                        result = "SS3"
                    Case 20
                        result = "SS2"
                    Case 21
                        result = "SS1"
                    Case 22
                        result = "SSS"
                    Case 23
                        result = "X3"
                    Case 24
                        result = "X2"
                    Case 25
                        result = "X1"
                    Case 26
                        result = "X"
                    Case Else
                        result = Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
                End Select
            End If

        End If
        Return result
    End Function

    Enum Gender
        male
        female
    End Enum

    Function GetHexStringFromBinary(hex As Byte()) As String
        Return BitConverter.ToString(hex).Replace("-", "")
    End Function


    Function GetGender(hex As Byte()) As Gender
        Dim result As Gender = Nothing
        Select Case BitConverter.ToString(hex).Replace("-", "")
            Case "00"
                result = Gender.male
            Case "01"
                result = Gender.female
        End Select
        Return result
    End Function

    Function SetName(val As String) As Byte()
        Dim enc = Encoding.GetEncoding("shift-jis")
        Return enc.GetBytes(val)
    End Function

    Function SetValue(val As Integer) As Byte()
        Return HexStringToBinary(val.ToString("X2"))
    End Function

    Function SetValue4(val As Integer) As Byte()
        Return HexStringToBinary(val.ToString("X4"))
    End Function

    Function IsCardFolderEmpty(path As String) As Boolean
        Return Not Directory.EnumerateFileSystemEntries(path).Any()
    End Function

    Function IsURLValid(url As String) As Boolean
        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 5000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(url)))
            Dim Source As String = reader.ReadToEnd
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Function GetSeatName(hex As Byte()) As String
        Dim result As String = Nothing
        Select Case BitConverter.ToString(hex).Replace("-", "")
            Case "01"
                result = "A1"
            Case "02"
                result = "A2"
            Case "03"
                result = "B1"
            Case "04"
                result = "B2"
            Case "05"
                result = "C1"
            Case "06"
                result = "C2"
            Case "07"
                result = "D1"
            Case "08"
                result = "D2"
            Case "00"
                result = "Single"
        End Select

        Return result ' & " | " & BitConverter.ToString(hex)
    End Function

    Sub SetSeatName(str As String, e2promFile As String)
        Dim _042A As String = BitConverter.ToString(GetHex(e2promFile, &H4, 39)).Replace("-", "")
        Dim _2C73 As String = BitConverter.ToString(GetHex(e2promFile, &H2C, 72)).Replace("-", "")
        Dim _2B As String = Nothing

        Select Case str
            Case "A1"
                _2B = "01"
            Case "A2"
                _2B = "02"
            Case "B1"
                _2B = "03"
            Case "B2"
                _2B = "04"
            Case "C1"
                _2B = "05"
            Case "C2"
                _2B = "06"
            Case "D1"
                _2B = "07"
            Case "D2"
                _2B = "08"
            Case "Single"
                _2B = "00"
        End Select

        Dim result As String = CalculateCRC32(_042A & _2B & _2C73)
        Dim whole As String = result & _042A & _2B & _2C73 & result & _042A & _2B & _2C73

        SetHex(e2promFile, &H0, HexStringToBinary(whole))
    End Sub

    Function CalculateCRC32(hexString As String) As String
        Dim crc As New Crc32()
        Dim rbytes As Byte() = crc.ComputeHash(HexStringToBinary(hexString))
        Dim result As String = BitConverter.ToUInt32(rbytes, 0).ToString("X8")
        Dim F4 = result.Substring(0, 4)
        Dim L4 = result.Substring(4)
        Dim F2 = F4.Substring(0, 2)
        Dim L2 = F4.Substring(2)
        Dim _F2 = L4.Substring(0, 2)
        Dim _L2 = L4.Substring(2)
        Dim _0003 As String = _L2 & _F2 & L2 & F2
        Return _0003
    End Function

    Function HexStringToBinary(ByVal hexString As String) As Byte()
        Return Enumerable.Range(0, hexString.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(hexString.Substring(x, 2), 16)).ToArray()
    End Function

    Function SafeImageFromFile(path As String) As Image
        Dim bytes = File.ReadAllBytes(path)
        Using ms As New MemoryStream(bytes)
            Dim img = Image.FromStream(ms)
            Return img
        End Using
    End Function

    Function ScoreToTime(score As String) As String
        Dim milliseconds As Double = score
        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(milliseconds)
        Dim m As String = ts.Minutes.ToString("#")
        Dim s As String = ts.Seconds.ToString("D2")
        Dim ms As String = ts.Milliseconds.ToString("D3")
        If m = "" Then m = "0"
        If s = "" Then s = "00"
        If ms = "" Then ms = "000"
        Return String.Format("{0}'{1}""{2}", m, s, ms)
    End Function

    Function GetTimeResult(filename As String, pos As Integer, Optional num As Boolean = False) As String
        Dim result As String = Nothing
        Dim a = BitConverter.ToString(GetHex(filename, pos, 1))
        pos += 1
        Dim b = BitConverter.ToString(GetHex(filename, pos, 1))
        pos += 1
        Dim c = BitConverter.ToString(GetHex(filename, pos, 1))
        Dim d = c & b & a
        If num Then result = Convert.ToInt64(d, 16).ToString Else result = ScoreToTime(Convert.ToInt64(d, 16).ToString)
        Return result
    End Function

    Function Md5Sum(strToEncrypt As String) As String
        Dim ue As New System.Text.UTF8Encoding()
        Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
        Dim md5 As New MD5CryptoServiceProvider()
        Dim hashBytes As Byte() = md5.ComputeHash(bytes)
        Dim hashString As String = ""
        For i As Integer = 0 To hashBytes.Length - 1
            hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
        Next
        Return hashString.PadLeft(32, "0"c)
    End Function

    Function GetProcessorId() As String
        Dim strProcessorId As String = String.Empty
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next
        Return strProcessorId
    End Function

    Function GetMACAddress() As String
        Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        Dim MACAddress As String = String.Empty
        For Each mo As ManagementObject In moc
            If (MACAddress.Equals(String.Empty)) Then
                If CBool(mo("IPEnabled")) Then MACAddress = mo("MacAddress").ToString()
                mo.Dispose()
            End If
            MACAddress = MACAddress.Replace(":", String.Empty)
        Next
        Return MACAddress
    End Function

    Function GetVolumeSerial(Optional ByVal strDriveLetter As String = "C") As String
        Dim disk As ManagementObject = New ManagementObject(String.Format("win32_logicaldisk.deviceid=""{0}:""", strDriveLetter))
        disk.Get()
        Return disk("VolumeSerialNumber").ToString()
    End Function

    Function GetMotherBoardID() As String

        Dim strMotherBoardID As String = String.Empty
        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strMotherBoardID = info("SerialNumber").ToString()
        Next
        Return strMotherBoardID
    End Function

    Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Function getNewCPUID() As String
        Return getMD5Hash(GetMotherBoardID() & GetVolumeSerial() & GetMACAddress() & GetProcessorId()).Substring(0, 14).ToUpper
    End Function

    Function IsMeBanned() As Boolean
        Dim result As Boolean = False

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString("http://id.imnotmental.com/isban.php?cpuid=" & getNewCPUID())))
            Dim Source As String = reader.ReadToEnd
            If Source = "no" Then
                result = False
            Else
                result = True
            End If
        Catch ex As Exception
            result = True
        End Try

        Return result
    End Function

    Function DoesRecordExists(score As String, track As String, coursetype As String, weather As String, version As Integer) As Boolean
        Dim result As Boolean = True

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}
            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(String.Format("http://id.imnotmental.com/isrecordexist.php?cpuid={0}&score={1}&track={2}&coursetype={3}&gameversion={4}&weather={5}", getNewCPUID, score, track, coursetype, version, weather))))
            Dim Source As String = reader.ReadToEnd
            If Source = "no" Then
                result = False
            Else
                result = True
            End If
        Catch ex As Exception
            result = True
        End Try

        Return result
    End Function

    Function EncryptSHA256Managed(ByVal ClearString As String) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(ClearString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

    Function GetCountryCode() As String
        Dim cc As String = Nothing
        Select Case My.Settings.UserCountry
            Case "Afghanistan"
                cc = "AFG"
            Case "Albania"
                cc = "ALA"
            Case "Algeria"
                cc = "DZA"
            Case "Andorra"
                cc = "AND"
            Case "Angola"
                cc = "AGO"
            Case "Anguilla"
                cc = "AIA"
            Case "Antigua & Barbuda"
                cc = "ATG"
            Case "Argentina"
                cc = "ARG"
            Case "Armenia"
                cc = "ARM"
            Case "Australia"
                cc = "AUS"
            Case "Austria"
                cc = "AUT"
            Case "Azerbaijan"
                cc = "AZE"
            Case "Bahamas"
                cc = "BHS"
            Case "Bahrain"
                cc = "BHR"
            Case "Bangladesh"
                cc = "BGD"
            Case "Barbados"
                cc = "BRB"
            Case "Belarus"
                cc = "BLR"
            Case "Belgium"
                cc = "BEL"
            Case "Belize"
                cc = "BLZ"
            Case "Benin"
                cc = "BEN"
            Case "Bermuda"
                cc = "BMU"
            Case "Bhutan"
                cc = "BTN"
            Case "Bolivia"
                cc = "BOL"
            Case "Bosnia & Herzegovina"
                cc = "BIH"
            Case "Botswana"
                cc = "BWA"
            Case "Brazil"
                cc = "BRA"
            Case "Brunei Darussalam"
                cc = "BRN"
            Case "Bulgaria"
                cc = "BGR"
            Case "Burkina Faso"
                cc = "BFA"
            Case "Myanmar/ Burma"
                cc = "MMR"
            Case "Burundi"
                cc = "BDI"
            Case "Cambodia"
                cc = "KHM"
            Case "Cameroon"
                cc = "CMR"
            Case "Canada"
                cc = "CAN"
            Case "Cape Verde"
                cc = "CPV"
            Case "Cayman Islands"
                cc = "CYM"
            Case "Central African Republic"
                cc = "CAF"
            Case "Chad"
                cc = "TCD"
            Case "Chile"
                cc = "CHL"
            Case "China"
                cc = "CHN"
            Case "Colombia"
                cc = "COL"
            Case "Comoros"
                cc = "COM"
            Case "Congo"
                cc = "COG"
            Case "Costa Rica"
                cc = "CRI"
            Case "Croatia"
                cc = "HRV"
            Case "Cuba"
                cc = "CUB"
            Case "Cyprus"
                cc = "CYP"
            Case "Czech Republic"
                cc = "CZE"
            Case "Democratic Republic of the Congo"
                cc = "COD"
            Case "Denmark"
                cc = "DNK"
            Case "Djibouti"
                cc = "DJI"
            Case "Dominican Republic"
                cc = "DOM"
            Case "Dominica"
                cc = "DMA"
            Case "Ecuador"
                cc = "ECU"
            Case "Egypt"
                cc = "EGY"
            Case "El Salvador"
                cc = "SLV"
            Case "Equatorial Guinea"
                cc = "GNQ"
            Case "Eritrea"
                cc = "ERI"
            Case "Estonia"
                cc = "EST"
            Case "Ethiopia"
                cc = "ETH"
            Case "Fiji"
                cc = "FJI"
            Case "Finland"
                cc = "FIN"
            Case "France"
                cc = "FRA"
            Case "French Guiana"
                cc = "GUF"
            Case "Gabon"
                cc = "GAB"
            Case "Gambia"
                cc = "GMB"
            Case "Georgia"
                cc = "GEO"
            Case "Germany"
                cc = "DEU"
            Case "Ghana"
                cc = "GHA"
            Case "Great Britain"
                cc = "GBR"
            Case "Greece"
                cc = "GRC"
            Case "Grenada"
                cc = "GRD"
            Case "Guadeloupe"
                cc = "GLP"
            Case "Guatemala"
                cc = "GTM"
            Case "Guinea"
                cc = "GIN"
            Case "Guinea-Bissau"
                cc = "GNB"
            Case "Guyana"
                cc = "GUY"
            Case "Haiti"
                cc = "HTI"
            Case "Honduras"
                cc = "HND"
            Case "Hungary"
                cc = "HUN"
            Case "Iceland"
                cc = "ISL"
            Case "India"
                cc = "IND"
            Case "Indonesia"
                cc = "IDN"
            Case "Iran"
                cc = "IRN"
            Case "Iraq"
                cc = "IRQ"
            Case "Israel And the Occupied Territories"
                cc = "ISR"
            Case "Italy"
                cc = "ITA"
            Case "Ivory Coast(Cote d'Ivoire)"
                cc = "CIV"
            Case "Jamaica"
                cc = "JAM"
            Case "Japan"
                cc = "JPN"
            Case "Jordan"
                cc = "JOR"
            Case "Kazakhstan"
                cc = "KAZ"
            Case "Kenya"
                cc = "KEN"
            Case "Kosovo"
                cc = "XK"
            Case "Kuwait"
                cc = "KWT"
            Case "Kyrgyz Republic(Kyrgyzstan)"
                cc = "KGZ"
            Case "Laos"
                cc = "LAO"
            Case "Latvia"
                cc = "LVA"
            Case "Lebanon"
                cc = "LBN"
            Case "Lesotho"
                cc = "LSO"
            Case "Liberia"
                cc = "LBR"
            Case "Libya"
                cc = "LBY"
            Case "Liechtenstein"
                cc = "LIE"
            Case "Lithuania"
                cc = "LTU"
            Case "Luxembourg"
                cc = "LUX"
            Case "Republic of Macedonia"
                cc = "MKD"
            Case "Madagascar"
                cc = "MDG"
            Case "Malawi"
                cc = "MWI"
            Case "Malaysia"
                cc = "MYS"
            Case "Maldives"
                cc = "MDV"
            Case "Mali"
                cc = "MLI"
            Case "Malta"
                cc = "MLT"
            Case "Martinique"
                cc = "MTQ"
            Case "Mauritania"
                cc = "MRT"
            Case "Mauritius"
                cc = "MUS"
            Case "Mayotte"
                cc = "MYT"
            Case "Mexico"
                cc = "MEX"
            Case "Moldova, Republic of"
                cc = "MDA"
            Case "Monaco"
                cc = "MCO"
            Case "Mongolia"
                cc = "MNG"
            Case "Montenegro"
                cc = "MNE"
            Case "Montserrat"
                cc = "MSR"
            Case "Morocco"
                cc = "MAR"
            Case "Mozambique"
                cc = "MOZ"
            Case "Namibia"
                cc = "NAM"
            Case "Nepal"
                cc = "NPL"
            Case "Netherlands"
                cc = "NLD"
            Case "New Zealand"
                cc = "NZL"
            Case "Nicaragua"
                cc = "NIC"
            Case "Niger"
                cc = "NER"
            Case "Nigeria"
                cc = "NGA"
            Case "Korea, Democratic Republic of (North Korea)"
                cc = "PRK"
            Case "Norway"
                cc = "NOR"
            Case "Oman"
                cc = "OMN"
            Case "Pacific Islands"
                cc = "PCI"
            Case "Pakistan"
                cc = "PAK"
            Case "Panama"
                cc = "PAN"
            Case "Papua New Guinea"
                cc = "PNG"
            Case "Paraguay"
                cc = "PRY"
            Case "Peru"
                cc = "PER"
            Case "Philippines"
                cc = "PHL"
            Case "Poland"
                cc = "POL"
            Case "Portugal"
                cc = "PRT"
            Case "Puerto Rico"
                cc = "PRI"
            Case "Qatar"
                cc = "QAT"
            Case "Reunion"
                cc = "REU"
            Case "Romania"
                cc = "ROU"
            Case "Russian Federation"
                cc = "RUS"
            Case "Rwanda"
                cc = "RWA"
            Case "Saint Kitts And Nevis"
                cc = "KNA"
            Case "Saint Lucia"
                cc = "LCA"
            Case "Saint Vincent's & Grenadines"
                cc = "VCT"
            Case "Samoa"
                cc = "WSM"
            Case "Sao Tome And Principe"
                cc = "STP"
            Case "Saudi Arabia"
                cc = "SAU"
            Case "Senegal"
                cc = "SEN"
            Case "Serbia"
                cc = "SRB"
            Case "Seychelles"
                cc = "SYC"
            Case "Sierra Leone"
                cc = "SLE"
            Case "Singapore"
                cc = "SGP"
            Case "Slovak Republic(Slovakia)"
                cc = "SVK"
            Case "Slovenia"
                cc = "SVN"
            Case "Solomon Islands"
                cc = "SLB"
            Case "Somalia"
                cc = "SOM"
            Case "South Africa"
                cc = "ZAF"
            Case "Korea, Republic of (South Korea)"
                cc = "KOR"
            Case "South Sudan"
                cc = "SSD"
            Case "Spain"
                cc = "ESP"
            Case "Sri Lanka"
                cc = "LKA"
            Case "Sudan"
                cc = "SDN"
            Case "Suriname"
                cc = "SUR"
            Case "Swaziland"
                cc = "SWZ"
            Case "Sweden"
                cc = "SWE"
            Case "Switzerland"
                cc = "CHE"
            Case "Syria"
                cc = "SYR"
            Case "Tajikistan"
                cc = "TJK"
            Case "Tanzania"
                cc = "TZA"
            Case "Thailand"
                cc = "THA"
            Case "Timor Leste"
                cc = "TLS"
            Case "Togo"
                cc = "TGO"
            Case "Trinidad & Tobago"
                cc = "TTO"
            Case "Tunisia"
                cc = "TUN"
            Case "Turkey"
                cc = "TUR"
            Case "Turkmenistan"
                cc = "TKM"
            Case "Turks & Caicos Islands"
                cc = "TCA"
            Case "Uganda"
                cc = "UGA"
            Case "Ukraine"
                cc = "UKR"
            Case "United Arab Emirates"
                cc = "ARE"
            Case "United States of America (USA)"
                cc = "USA"
            Case "Uruguay"
                cc = "URY"
            Case "Uzbekistan"
                cc = "UZB"
            Case "Venezuela"
                cc = "VEN"
            Case "Vietnam"
                cc = "VNM"
            Case "Virgin Islands(UK)"
                cc = "VGB"
            Case "Virgin Islands(US)"
                cc = "VIR"
            Case "Yemen"
                cc = "YEM"
            Case "Zambia"
                cc = "ZMB"
            Case "Zimbabwe"
                cc = "ZWE"
            Case "Aland Islands"
                cc = "ALA"
            Case "Antarctica"
                cc = "ATA"
            Case "Hong Kong, SAR China"
                cc = "HKG"
            Case "Taiwan, Republic of China"
                cc = "TWN"
            Case "Macao, SAR China"
                cc = "MAC"
            Case "Bouvet Island"
                cc = "BVT"
            Case "British Indian Ocean Territory"
                cc = "IOT"
            Case "Christmas Island"
                cc = "CXR"
            Case "Cook Islands"
                cc = "COK"
            Case "Falkland Islands (Malvinas)"
                cc = "FLK"
            Case "Faroe Islands"
                cc = "FRO"
            Case "French Southern Territories"
                cc = "ATF"
            Case "French Polynesia"
                cc = "PYF"
            Case "Heard and Mcdonald Islands"
                cc = "HMD"
            Case "Holy See (Vatican City State)"
                cc = "VAT"
            Case "Isle of Man"
                cc = "IMN"
            Case "Ireland"
                cc = "IRL"
            Case "Jersey"
                cc = "JEY"
            Case "Netherlands Antilles"
                cc = "ANT"
            Case "New Caledonia"
                cc = "NCL"
            Case "Niue"
                cc = "NIU"
            Case "Norfolk Island"
                cc = "NFK"
            Case "Northern Mariana Islands"
                cc = "MNP"
            Case "Saint-Barthélemy"
                cc = "BLM"
            Case "Saint Helena"
                cc = "SHN"
            Case "Saint-Martin"
                cc = "MAF"
            Case "Saint Pierre and Miquelon"
                cc = "SPM"
            Case "South Georgia and the South Sandwich Islands"
                cc = "SGS"
            Case "Svalbard and Jan Mayen Islands"
                cc = "SJM"
            Case "Tokelau"
                cc = "TKL"
            Case "US Minor Outlying Islands"
                cc = "UMI"
            Case "Wallis and Futuna Islands"
                cc = "WLF"
            Case "Western Sahara"
                cc = "ESH"
            Case Else
                cc = "UNK"
        End Select
        Return cc
    End Function

    Sub wait(ByVal interval As Integer)
        Dim stopW As New Stopwatch
        stopW.Start()
        Do While stopW.ElapsedMilliseconds < interval
            ' Allows your UI to remain responsive
            Application.DoEvents()
        Loop
        stopW.Stop()
    End Sub

    Function GetCardVersion(hex As Byte()) As Integer
        Dim result As Integer = 0
        Select Case BitConverter.ToString(hex).Replace("-", "")
            Case "1270"
                result = 7
            Case "1360"
                result = 6
            Case "1580"
                result = 8
            Case Else
                result = -1
        End Select
        Return result
    End Function

    Function HexToBinary(hexString As String) As String
        Dim result As String = Nothing
        Dim num As Integer = CInt("&H" & hexString)
        Do While num > 0
            result = (num Mod 2).ToString & result
            num = num \ 2
        Loop
        Return result
    End Function

    Function BinaryToHex(binaryString As String) As String
        Return Convert.ToString(Convert.ToInt32(binaryString, 2), 16).ToUpper
    End Function

    Private sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_JIS")
    <Extension()>
    Public Function IsWideEastAsianWidth_SJIS(ByVal c As Char) As Boolean
        Dim byteCount As Integer = sjis.GetByteCount(c.ToString())
        Return byteCount = 2
    End Function

    Public Function FindFocussedControl(ByVal ctr As Control) As Control
        Dim container As ContainerControl = TryCast(ctr, ContainerControl)
        Do While (container IsNot Nothing)
            ctr = container.ActiveControl
            container = TryCast(ctr, ContainerControl)
        Loop
        Return ctr
    End Function
End Module
