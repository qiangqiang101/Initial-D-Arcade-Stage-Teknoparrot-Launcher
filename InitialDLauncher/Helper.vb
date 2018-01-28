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

    Sub RunParrotLoaderUI(ByVal arg As String, wait As Boolean, Optional test As Boolean = False)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = My.Application.Info.DirectoryPath & "\TeknoParrotUi.exe"
        startInfo.WindowStyle = ProcessWindowStyle.Minimized
        If test Then
            startInfo.Arguments = String.Format("""{0}"" {1}", arg, "--test")
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

    Sub RunTeknoParrotOnline(wait As Boolean)
        Process.Start("steam://rungameid/0")
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = My.Application.Info.DirectoryPath & "\TeknoParrotOnline.exe"
        startInfo.WindowStyle = ProcessWindowStyle.Normal
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
            If File.Exists(My.Application.Info.DirectoryPath & "\UserProfiles\ID6.xml") Then
                Dim xd As New XmlDocument()
                xd.Load(My.Application.Info.DirectoryPath & "\UserProfiles\ID6.xml")
                Using items As XmlNodeList = xd.DocumentElement.SelectNodes("/GameProfile")
                    For Each item As XmlNode In items
                        Dim GamePath As String = item.SelectSingleNode("GamePath").InnerText
                        My.Settings.Id6Path = Path.GetDirectoryName(GamePath)
                        My.Settings.Save()
                    Next
                End Using
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\UserProfiles\ID7.xml") Then
                Dim xd As New XmlDocument()
                xd.Load(My.Application.Info.DirectoryPath & "\UserProfiles\ID7.xml")
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
            Dim reader As StreamReader
            If My.Settings.Server = "World" Then
                reader = New StreamReader(Client.OpenRead(Convert.ToString("http://id.imnotmental.com/isban.php?cpuid=" & getNewCPUID())))
            Else
                reader = New StreamReader(Client.OpenRead(Convert.ToString("http://www.emulot.cn/id/isban.php?cpuid=" & getNewCPUID())))
            End If
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
            Dim reader As StreamReader
            If My.Settings.Server = "World" Then
                reader = New StreamReader(Client.OpenRead(Convert.ToString(String.Format("http://id.imnotmental.com/isrecordexist.php?cpuid={0}&score={1}&track={2}&coursetype={3}&gameversion={4}&weather={5}", getNewCPUID, score, track, coursetype, version, weather))))
            Else
                reader = New StreamReader(Client.OpenRead(Convert.ToString(String.Format("http://www.emulot.cn/id/isrecordexist.php?cpuid={0}&score={1}&track={2}&coursetype={3}&gameversion={4}&weather={5}", getNewCPUID, score, track, coursetype, version, weather))))
            End If
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

End Module
