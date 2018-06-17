Public Class Form1
    Dim SBUU_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_e2prom-A2.bin"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SBUU_e2prom = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\" & TextBox2.Text
        TextBox1.Text = GetSeatName(GetHex(SBUU_e2prom, 116, 4), 7)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmLauncher.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim num As Integer = 1
        'For Each file As String In IO.Directory.GetFiles("C:\Users\Barry\Desktop\id8\frame", "*.png")
        '    TextBox4.Text = String.Format("{0}{1}frame.Add({2}{3}{2}, fm.FM_{4})", TextBox4.Text, vbNewLine, """", num, IO.Path.GetFileNameWithoutExtension(file).Replace("T", "X"))
        '    num += 1
        'Next

        'For Each file As String In IO.Directory.GetFiles("C:\Users\Barry\Desktop\id8\frame", "*.png")
        '    Dim fname As String = IO.Path.GetFileNameWithoutExtension(file)
        '    Dim fname1 As Char = fname.Substring(0, 1)
        '    Dim fname2 As String = fname
        '    Dim fname3 As String = fname.Replace("U", "X")
        '    If IsNumeric(fname1) Then fname2 = "_" & fname
        '    TextBox4.Text = String.Format("{0}{1}Public FM_{3} As New Bitmap(My.Resources.{4}) With {5}.Tag = {2}{3}{2}{6}", TextBox4.Text, vbNewLine, """", fname, fname2, "{", "}")
        'Next

        Dim num As Integer = 1
        For Each file As String In IO.Directory.GetFiles("D:\barry temp\d8 frame\" & TextBox6.Text, "*.png")
            Dim filename As String = IO.Path.GetFileNameWithoutExtension(file)
            Dim val As String = CInt(filename.Substring(0, filename.IndexOf(")"))).ToString("X2")
            Dim txt2del As String = filename.Substring(0, filename.IndexOf(")")) & ")"
            filename = filename.Replace(txt2del, "")
            TextBox4.Text = String.Format("{0}{1}D8_FR_{2} {3}{5} / {4}{3}", TextBox4.Text, vbNewLine, val, """", filename, TextBox5.Text)
            num += 1
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim p As String = "C:\Users\Barry\Desktop\id8\wmn\" & TextBox5.Text
        Dim np As String = "C:\Users\Barry\Desktop\id8\wmn\" & TextBox5.Text & "\naz\"
        For Each file As String In IO.Directory.GetFiles(p, "*.png")
            Dim oldf As String = IO.Path.GetFileNameWithoutExtension(file)
            Dim newf As String = oldf.Replace("T", "U")
            'My.Computer.FileSystem.RenameFile(file, newf & ".png")
            IO.File.Move(file, np & newf & ".png")
        Next

        'Dim s As String = "C:\Users\Barry\Desktop\id8\frame"
        'For Each file As String In IO.Directory.GetFiles(s, "*.png")
        '    Dim oldf As String = IO.Path.GetFileNameWithoutExtension(file)
        '    Dim parts As String() = oldf.Split(New Char() {")"c})
        '    Dim newf As String = s & "\naz\" & CInt(parts(0)).ToString("X2") & ".png"
        '    If Not IO.File.Exists(newf) Then
        '        IO.File.Move(file, newf)
        '    End If
        'Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox6.Text = ScoreToTime(TextBox5.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Avatar1.RefreshImage()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Avatar1.RefreshImage()
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    TextBox3.Text = HexStringToBinary(TextBox1.Text)
    'End Sub
End Class