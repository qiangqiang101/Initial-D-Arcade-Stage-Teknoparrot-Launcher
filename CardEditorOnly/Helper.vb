Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Management
Imports System.Net

Module Helper

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
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function Neg3C(offset As Long) As Long
        Return (offset - &H3C)
    End Function

    Function Plus3C(offset As Long) As Long
        Return (offset + &H3C)
    End Function

    Function GetCardVersion(hex As Byte()) As Integer
        Dim dec As Integer = CInt("&H" & BitConverter.ToString(hex).Replace("-", ""))
        Dim result As Integer = 0
        Select Case dec
            Case "1270"
                result = 7
            Case "1360"
                result = 6
        End Select
        Return result
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
            Case "GT-R (R35)"
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
            Case "TRUENO 2door GT-APEX (AE86)"
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
            Case "GT-R (R35)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"ULTIMATE METAL SILVER", "TITANIUM GRAY", "WHITE PEARL", "VIBRANT RED", "DARK METAL GRAY", "SUPER BLACK", "SILICA BRASS", "LIGHTNING YELLOW", "MIDNIGHT PURPLE Ⅱ", "BAYSIDE BLUE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
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
                'SUZUKI
            Case "Cappuccino (EA11R)"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"CORDOVA RED", "SATELLITE SILVER METALLIC", "DARK CLASSIC JADE PEARL", "DEEP BLUE PEARL", "SATURN BLACK METALLIC", "BRITISH GREEN PEARL", "YELLOW", "BLUE MICA", "WHITE", "ORANGE", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
                'INITIAL D
            Case "SILEIGHTY"
                result = New Tuple(Of String, List(Of String), List(Of String))(Nothing, New List(Of String)(New String() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D"}), New List(Of String)(New String() {"IMPACT BLUE", "YELLOWISH SILVER", "SUPER BLACK", "DARK GREY", "SUPER RED", "VELVET BLUE", "PURPLISH GREY", "WARM WHITE", "LIGHTNING YELLOW", "WINE RED", "SPECIAL GREEN/GRADATION", "SPECIAL　RED/GRADATION", "SPECIAL　BLUE/GRADATION", "SPECIAL　YELLOW/GRADATION"}))
            Case "TRUENO 2door GT-APEX (AE86)"
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
                    If ver = 7 Then
                        result = "86 GT (ZN6)"
                    Else
                        result = "FT-86 G Sports Concept"
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
                    result = "GT-R (R35)"
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
            Case "GT-R (R35)"
                result = "0701"
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

    Function GetLevel(hex As Byte(), Optional num As Boolean = False) As String
        Dim result As String = Nothing
        If num Then
            result = Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16)
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

    Function GetSeatName(hex As Byte(), version As Integer) As String
        Dim result As String = Nothing
        If version = 6 Then
            Select Case BitConverter.ToString(hex).Replace("-", "")
                Case "F9F0952A"
                    result = "A1"
                Case "AA12B0E9"
                    result = "A2"
                Case "A44E7C1E"
                    result = "B1"
                Case "4DD08AB4"
                    result = "B2"
                Case "438C4643"
                    result = "C1"
                Case "106E6380"
                    result = "C2"
                Case "1E32AF77"
                    result = "D1"
                Case "8355FF0E"
                    result = "D2"
                Case "F7AC59DD"
                    result = "Single"
                Case Else
                    result = "Unknown"
            End Select
        Else
            Select Case BitConverter.ToString(hex).Replace("-", "")
                Case "C8DA86D4"
                    result = "A1"
                Case "9B38A317"
                    result = "A2"
                Case "95646FE0"
                    result = "B1"
                Case "7CFA994A"
                    result = "B2"
                Case "72A655BD"
                    result = "C1"
                Case "2144707E"
                    result = "C2"
                Case "2F18BC89"
                    result = "D1"
                Case "B27FECF0"
                    result = "D2"
                Case "C6864A23"
                    result = "Single"
                Case Else
                    result = "Unknown"
            End Select
        End If

        Return result ' & " | " & BitConverter.ToString(hex)
    End Function

    Function HexStringToBinary(ByVal hexString As String) As Byte()
        Return Enumerable.Range(0, hexString.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(hexString.Substring(x, 2), 16)).ToArray()
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
End Module
