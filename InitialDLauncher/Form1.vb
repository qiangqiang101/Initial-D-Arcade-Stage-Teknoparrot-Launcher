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
        Dim num As Integer = 1
        For Each file As String In IO.Directory.GetFiles("E:\TeknoParrot\LAUNCHER\FEMALE\SHIRT", "*.png")
            TextBox4.Text = String.Format("{0}{1}shirt_f.Add({2}{3}{2}, {2}{4}{2})", TextBox4.Text, vbNewLine, """", num, IO.Path.GetFileNameWithoutExtension(file))
            num += 1
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim p As String = "E:\TeknoParrot\LAUNCHER\FEMALE\SHIRT\FF"
        Dim np As String = "E:\TeknoParrot\LAUNCHER\FEMALE\SHIRT\"
        For Each file As String In IO.Directory.GetFiles(p, "*.png")
            Dim oldf As String = IO.Path.GetFileNameWithoutExtension(file)
            Dim newf As String = oldf.Replace("x", "X")
            'My.Computer.FileSystem.RenameFile(file, newf & ".png")
            IO.File.Move(file, np & newf & ".png")
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox6.Text = ScoreToTime(TextBox5.Text)
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    TextBox3.Text = HexStringToBinary(TextBox1.Text)
    'End Sub
End Class