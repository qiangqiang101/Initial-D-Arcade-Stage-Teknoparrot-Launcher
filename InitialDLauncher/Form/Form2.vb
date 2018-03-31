Imports System.IO

Public Class Form2

    Private _DraggingFileName As String
    Private result As String = Nothing
    Private resultT As String = Nothing

    Private Sub TextBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop
        Me.TextBox1.Text = My.Computer.FileSystem.ReadAllText(_DraggingFileName)
    End Sub

    Private Sub TextBox1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.DragLeave
        _DraggingFileName = String.Empty
    End Sub

    Private Sub TextBox1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragOver
        If _DraggingFileName = String.Empty Then 'only do this once
            Dim s As String
            _DraggingFileName = String.Empty
            For Each s In e.Data.GetFormats
                Select Case s
                    Case "FileNameW" 'this returns the full filename as an array of strings
                        Dim o As Object = e.Data.GetData(s)
                        If TypeOf o Is String() Then
                            _DraggingFileName = o(0)
                            'Is it a Text File
                            If _DraggingFileName.ToLower.EndsWith(".txt") Then
                                e.Effect = DragDropEffects.Copy
                            Else 'if not then reset the draggingfilename variable
                                e.Effect = DragDropEffects.None
                                _DraggingFileName = String.Empty
                            End If
                        Else
                            e.Effect = DragDropEffects.None
                        End If
                End Select
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If TextBox1.Lines.Count > 1 Then
        '    Dim newList As List(Of String) = TextBox1.Lines.ToList
        '    ' Remove the first line.  
        '    newList.RemoveAt(0)
        '    TextBox1.Lines = newList.ToArray
        'End If

        'If TextBox1.Lines.Count > 1 Then
        '    Dim newList As List(Of String) = TextBox1.Lines.ToList
        '    ' Remove the first line.  
        '    newList.RemoveAt(0)
        '    TextBox1.Lines = newList.ToArray
        'End If

        'If TextBox1.Lines.Count > 1 Then
        '    Dim newList As List(Of String) = TextBox1.Lines.ToList
        '    ' Remove the first line.  
        '    newList.RemoveAt(0)
        '    TextBox1.Lines = newList.ToArray
        'End If

        'For Each line In TextBox1.Lines
        '    Dim parts As String() = line.Split(New Char() {","c})
        '    result = result & """" & parts(19) & """" & ", "
        'Next

        'result = result.Remove(result.Length - 2)

        'TextBox2.Text = String.Format("                result = New Tuple(Of String, List(Of String), List(Of String))(nothing, New List(Of String)(New String() {1}{0}00{0}, {0}01{0}, {0}02{0}, {0}03{0}, {0}04{0}, {0}05{0}, {0}06{0}, {0}07{0}, {0}08{0}, {0}09{0}, {0}0A{0}, {0}0B{0}, {0}0C{0}, {0}0D{0}{2}), New List(Of String)(New String() {1}{3}{2}))", """", "{", "}", result)
        'My.Computer.Clipboard.SetText(TextBox2.Text)

        If TextBox1.Lines.Count > 1 Then
            Dim newList As List(Of String) = TextBox1.Lines.ToList
            ' Remove the first line.  
            newList.RemoveAt(0)
            TextBox1.Lines = newList.ToArray
        End If

        If TextBox1.Lines.Count > 1 Then
            Dim newList As List(Of String) = TextBox1.Lines.ToList
            ' Remove the first line.  
            newList.RemoveAt(0)
            TextBox1.Lines = newList.ToArray
        End If

        If TextBox1.Lines.Count > 1 Then
            Dim newList As List(Of String) = TextBox1.Lines.ToList
            ' Remove the first line.  
            newList.RemoveAt(0)
            TextBox1.Lines = newList.ToArray
        End If

        For Each line In TextBox1.Lines
            Dim parts As String() = line.Split(New Char() {","c})
            result = result & """" & parts(1) & """" & ", "
            resultT = resultT & """" & CInt(parts(4)).ToString("X2") & """" & ", "
        Next

        result = result.Remove(result.Length - 2)

        TextBox2.Text = String.Format("                result = New Tuple(Of String, List(Of String), List(Of String))(nothing, New List(Of String)(New String() {1}{4}{2}), New List(Of String)(New String() {1}{3}{2}))", """", "{", "}", result, resultT)
        My.Computer.Clipboard.SetText(TextBox2.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        result = Nothing
    End Sub

    'Private Sub TextBox1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragOver
    '    Dim file_name As String = Nothing
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        Dim Files() As String
    '        Files = e.Data.GetData(DataFormats.FileDrop)

    '        file_name = Path.GetFileName(Files(0))
    '    End If

    '    TextBox1.Text = File.ReadAllText(file_name)
    'End Sub

End Class