Imports System.IO
Imports System.Text
Imports System.Xml

Module Helper

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

    Function IsCardFolderEmpty(path As String) As Boolean
        Return Not Directory.EnumerateFileSystemEntries(path).Any()
    End Function

    Function IsURLValid(url As String) As Boolean
        Dim result As Boolean = True
        Dim url1 As New System.Uri(url)
        Dim req As System.Net.WebRequest
        req = System.Net.WebRequest.Create(url)
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
        Catch ex As Exception
            req = Nothing
            result = False
        End Try
        Return result
    End Function
End Module
