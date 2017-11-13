Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Management
Imports System.Net

Module Helper

    Dim SBUU_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_e2prom.bin"
    Dim SBYD_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBYD_e2prom.bin"

    Sub RunParrotLoader(ByVal arg As String, wait As Boolean, Optional test As Boolean = False)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = My.Application.Info.DirectoryPath & "\ParrotLoader.exe"
        startInfo.WindowStyle = ProcessWindowStyle.Minimized
        If test Then
            startInfo.Arguments = String.Format("""{0}"" {1}", arg, "-t")
        Else
            startInfo.Arguments = """" & arg & """"
        End If
        frmLauncher.proc = Process.Start(startInfo)
        If wait Then
            frmLauncher.proc.EnableRaisingEvents = True
            frmLauncher.proc.WaitForExit()
        Else
            frmLauncher.proc.EnableRaisingEvents = False
        End If
    End Sub

    Sub GetGamePath()
        Dim pList As List(Of String) = New List(Of String) From {My.Settings.Id6Path, My.Settings.Id7Path}
        If pList.Contains(String.Empty) Then
            If File.Exists(My.Application.Info.DirectoryPath & "\GameProfiles\ID6.xml") Then
                Dim xd As New XmlDocument()
                xd.Load(My.Application.Info.DirectoryPath & "\GameProfiles\ID6.xml")
                Using items As XmlNodeList = xd.DocumentElement.SelectNodes("/GameProfile")
                    For Each item As XmlNode In items
                        Dim GamePath As String = item.SelectSingleNode("GamePath").InnerText
                        My.Settings.Id6Path = Path.GetDirectoryName(GamePath)
                        My.Settings.Save()
                    Next
                End Using
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\GameProfiles\ID7.xml") Then
                Dim xd As New XmlDocument()
                xd.Load(My.Application.Info.DirectoryPath & "\GameProfiles\ID7.xml")
                Using items As XmlNodeList = xd.DocumentElement.SelectNodes("/GameProfile")
                    For Each item As XmlNode In items
                        Dim GamePath As String = item.SelectSingleNode("GamePath").InnerText
                        My.Settings.Id7Path = Path.GetDirectoryName(GamePath)
                        My.Settings.Save()
                    Next
                End Using
            End If
        End If
    End Sub

    Function GetHex(filename As String, pos As Integer, requiredBytes As Integer) As Byte()
        Dim value(0 To requiredBytes - 1) As Byte
        Using reader As New BinaryReader(File.Open(filename, FileMode.Open))
            ' Loop through length of file.
            Dim fileLength As Long = reader.BaseStream.Length
            Dim byteCount As Integer = 0
            reader.BaseStream.Seek(pos, SeekOrigin.Begin)
            While pos < fileLength And byteCount < requiredBytes
                value(byteCount) = reader.ReadByte()
                pos += 1
                byteCount += 1
            End While
        End Using

        Return value
    End Function

    Function GetName(hex As Byte()) As String
        Dim enc = Encoding.GetEncoding("shift-jis")
        Dim value = enc.GetString(hex)
        Return value
    End Function

    Function GetCar(hex As Byte(), hex2 As Byte()) As String
        Dim result As String = Nothing
        Dim ff As String = BitConverter.ToString(hex2).Replace("-", "")
        If ff = "FF" Then
            Select Case BitConverter.ToString(hex).Replace("-", "")
            'TOYOTA
                Case "0000"
                    result = "TRUENO GT-APEX (AE86)"
                Case "0100"
                    result = "LEVIN GT-APEX (AE86)"
                Case "0200"
                    result = "LEVIN SR (AE85)"
                Case "0700"
                    result = "86 GT (ZN6)"
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
            Case "86 GT (ZN6)"
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

    Function GetTagPride(hex As Byte(), hex2 As Byte()) As String
        Return Convert.ToInt64(BitConverter.ToString(hex).Replace("-", ""), 16) + Convert.ToInt64(BitConverter.ToString(hex2).Replace("-", ""), 16)
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
                    result = "SS3"
                Case 23
                    result = "SS2"
                Case 24
                    result = "SS1"
                Case 25
                    result = "SSS3"
                Case 26
                    result = "SSS2"
                Case 27
                    result = "SSS1"
                Case 28
                    result = "X3"
                Case 29
                    result = "X2"
                Case 30
                    result = "X1"
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

    Sub SetSeatName(str As String, version As Integer)
        If version = 6 Then
            Select Case str
                Case "A1"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("F9F0952A"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("F9F0952A"))
                Case "A2"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("AA12B0E9"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("AA12B0E9"))
                Case "B1"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("A44E7C1E"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("A44E7C1E"))
                Case "B2"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("4DD08AB4"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("4DD08AB4"))
                Case "C1"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("438C4643"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("438C4643"))
                Case "C2"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("106E6380"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("106E6380"))
                Case "D1"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("1E32AF77"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("1E32AF77"))
                Case "D2"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("8355FF0E"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("8355FF0E"))
                Case "Single"
                    SetHex(SBUU_e2prom, CLng("&H00"), HexStringToBinary("F7AC59DD"))
                    SetHex(SBUU_e2prom, CLng("&H74"), HexStringToBinary("F7AC59DD"))
                Case Else
                    MsgBox("Please change your Cabinet!")
            End Select
        Else
            Select Case str
                Case "A1"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("C8DA86D4"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("C8DA86D4"))
                Case "A2"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("9B38A317"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("9B38A317"))
                Case "B1"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("95646FE0"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("95646FE0"))
                Case "B2"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("7CFA994A"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("7CFA994A"))
                Case "C1"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("72A655BD"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("72A655BD"))
                Case "C2"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("2144707E"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("2144707E"))
                Case "D1"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("2F18BC89"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("2F18BC89"))
                Case "D2"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("B27FECF0"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("B27FECF0"))
                Case "Single"
                    SetHex(SBYD_e2prom, CLng("&H00"), HexStringToBinary("C6864A23"))
                    SetHex(SBYD_e2prom, CLng("&H74"), HexStringToBinary("C6864A23"))
                Case Else
                    MsgBox("Please change your Cabinet!")
            End Select
        End If
    End Sub

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

    Function IsMeBanned() As Boolean
        Dim result As Boolean = False

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}
            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString("http://id.imnotmental.com/isban.php?cpuid=" & GetProcessorId())))
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
            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(String.Format("http://id.imnotmental.com/isrecordexist.php?cpuid={0}&score={1}&track={2}&coursetype={3}&gameversion={4}&weather={5}", GetProcessorId, score, track, coursetype, version, weather))))
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

End Module
