Public Module CFGread
    Public Function ReadCfgValue(ByVal key As String, ByVal file As String) As String
        Dim lines As String() = IO.File.ReadAllLines(file)
        Dim temp As String = Nothing
        Dim value As String = Nothing

        For Each l As String In lines
            If l.StartsWith(key) Then
                temp = l.Substring(key.Length + 1)
                value = temp.Replace(Chr(34), "")
                Exit For
            End If
        Next
        Return value
    End Function

    Public Sub WriteCfgValue(ByVal key As String, ByVal value As String, ByVal file__1 As String)
        Dim getext As String = file__1.Substring(file__1.LastIndexOf("."c))
        Dim tmp As String = file__1.Replace(getext, ".tmp")
        Using sr = New IO.StreamReader(file__1)
            Using wr = New IO.StreamWriter(tmp)
                Dim line As String
                Dim check As Boolean = False
                Do
                    line = sr.ReadLine()
                    If line Is Nothing Then Exit Do 'Check if line is null then Exit Loop

                    If line.StartsWith(key) Then
                        line = String.Format("{0} ""{1}""", key, value)
                        check = True
                    End If
                    wr.WriteLine(line)
                Loop
                If Not check Then
                    wr.WriteLine(String.Format("{0} ""{1}""", key, value))
                End If
                sr.Close()
                wr.Close()
            End Using
        End Using
        IO.File.Delete(file__1)
        IO.File.Move(tmp, file__1)
    End Sub
End Module