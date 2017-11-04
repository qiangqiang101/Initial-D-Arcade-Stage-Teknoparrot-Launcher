Public Class Form1
    Dim SBUU_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_e2prom-A2.bin"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SBUU_e2prom = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\" & TextBox2.Text
        TextBox1.Text = GetSeatName(GetHex(SBUU_e2prom, 116, 4), 7)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmLauncher.Show()
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    TextBox3.Text = HexStringToBinary(TextBox1.Text)
    'End Sub
End Class