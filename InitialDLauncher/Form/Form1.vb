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
        For Each file As String In IO.Directory.GetFiles("C:\Users\Barry\Desktop\Avatar D7\Background", "*.jpg")
            TextBox4.Text = String.Format("{0}{1}frame.Add({2}{3}{2}, fm.FM_{4})", TextBox4.Text, vbNewLine, """", num, IO.Path.GetFileNameWithoutExtension(file))
            num += 1
        Next

        'For Each file As String In IO.Directory.GetFiles("C:\Users\Barry\Desktop\Avatar D7\Background", "*.jpg")
        '    Dim fname As String = IO.Path.GetFileNameWithoutExtension(file)
        '    Dim fname1 As Char = fname.Substring(0, 1)
        '    Dim fname2 As String = fname
        '    If IsNumeric(fname1) Then fname2 = "_" & fname
        '    TextBox4.Text = String.Format("{0}{1}Public FM_{3} As New Bitmap(My.Resources.{4}) With {5}.Tag = {2}{3}{2}{6}", TextBox4.Text, vbNewLine, """", fname, fname2, "{", "}")
        'Next
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