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
        For Each file As String In IO.Directory.GetFiles("F:\Users\Bartholomew\Documents\GitHub\Initial-D-Arcade-Stage-Teknoparrot-Launcher\InitialDLauncher\bin\Release\LAUNCHER\MALE\HAIR", "*.png")
            TextBox4.Text = String.Format("{0}{1}hair_m.Add({2}{3}{2}, mha.HA_{4})", TextBox4.Text, vbNewLine, """", num, IO.Path.GetFileNameWithoutExtension(file).Replace("Y", "X"))
            num += 1
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim p As String = "F:\Users\Bartholomew\Documents\GitHub\Initial-D-Arcade-Stage-Teknoparrot-Launcher\InitialDLauncher\bin\Release\LAUNCHER\MALE\SKIN\LTK"
        Dim np As String = "F:\Users\Bartholomew\Documents\GitHub\Initial-D-Arcade-Stage-Teknoparrot-Launcher\InitialDLauncher\bin\Release\LAUNCHER\MALE\SKIN\"
        For Each file As String In IO.Directory.GetFiles(p, "*.png")
            Dim oldf As String = IO.Path.GetFileNameWithoutExtension(file)
            Dim newf As String = oldf.Replace("x", "Y")
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