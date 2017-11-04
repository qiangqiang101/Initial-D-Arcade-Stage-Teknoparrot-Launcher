Public Class frmSettings

    Dim pattern As String
    Dim Id6Config As String = String.Format("{0}\config.ini", My.Settings.Id6Path)
    Dim Id7Config As String = String.Format("{0}\config.ini", My.Settings.Id7Path)
    Dim SBUU_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_e2prom.bin"
    'Dim SBYD_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBYD_e2prom.bin"
    Dim bool As List(Of String) = New List(Of String) From {"true", "false"}
    Dim gotError As Boolean = False

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt6.Text = My.Settings.Id6Path
            txt7.Text = My.Settings.Id7Path
            cbTest.Checked = My.Settings.TestMode
            cbDebug.Checked = My.Settings.DebugMode

            If Not My.Settings.Id6Path = String.Empty Then gb6.Enabled = True
            If Not My.Settings.Id7Path = String.Empty Then gb7.Enabled = True

            If gb6.Enabled Then Load6Config()
            If gb7.Enabled Then Load7Config()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Load6Config()
        Try
            cbFree6.Checked = Convert.ToBoolean(CInt(ReadIniValue(Id6Config, "General", "FreePlay")))
            If bool.Contains(ReadIniValue(Id6Config, "General", "Windowed").ToLower) Then cbWindow6.Checked = Convert.ToBoolean(ReadIniValue(Id6Config, "General", "Windowed"))
            If bool.Contains(ReadIniValue(Id6Config, "General", "EnableAmdFix").ToLower) Then cbAMDFix6.Checked = Convert.ToBoolean(ReadIniValue(Id6Config, "General", "EnableAmdFix"))
            cmbSeat6.SelectedItem = GetSeatName(GetHex(SBUU_e2prom, 116, 4), 6)

            txtIP6.Text = ReadIniValue(Id6Config, "Network", "Ip")
            txtMask6.Text = ReadIniValue(Id6Config, "Network", "Mask")
            txtGateway6.Text = ReadIniValue(Id6Config, "Network", "Gateway")
            txtDNSP6.Text = ReadIniValue(Id6Config, "Network", "Dns1")
            txtDNSS6.Text = ReadIniValue(Id6Config, "Network", "Dns2")
            txtBroadcast6.Text = ReadIniValue(Id6Config, "Network", "BroadcastIP")
            txtCab1IP6.Text = ReadIniValue(Id6Config, "Network", "Cab1IP")
            txtCab2IP6.Text = ReadIniValue(Id6Config, "Network", "Cab2IP")
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Load7Config()
        Try
            cbFree7.Checked = Convert.ToBoolean(CInt(ReadIniValue(Id7Config, "General", "FreePlay")))
            If bool.Contains(ReadIniValue(Id7Config, "General", "Windowed").ToLower) Then cbWindow7.Checked = Convert.ToBoolean(ReadIniValue(Id7Config, "General", "Windowed"))
            If bool.Contains(ReadIniValue(Id7Config, "General", "EnableAmdFix").ToLower) Then cbAMDFix7.Checked = Convert.ToBoolean(ReadIniValue(Id7Config, "General", "EnableAmdFix"))
            'cmbSeat7.SelectedItem = GetSeatName(GetHex(SBYD_e2prom, 116, 4), 7)

            txtIP7.Text = ReadIniValue(Id7Config, "Network", "Ip")
            txtMask7.Text = ReadIniValue(Id7Config, "Network", "Mask")
            txtGateway7.Text = ReadIniValue(Id7Config, "Network", "Gateway")
            txtDNSP7.Text = ReadIniValue(Id7Config, "Network", "Dns1")
            txtDNSS7.Text = ReadIniValue(Id7Config, "Network", "Dns2")
            txtBroadcast7.Text = ReadIniValue(Id7Config, "Network", "BroadcastIP")
            txtCab1IP7.Text = ReadIniValue(Id7Config, "Network", "Cab1IP")
            txtCab2IP7.Text = ReadIniValue(Id7Config, "Network", "Cab2IP")
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            My.Settings.Id6Path = txt6.Text
            My.Settings.Id7Path = txt7.Text
            My.Settings.TestMode = cbTest.Checked
            My.Settings.DebugMode = cbDebug.Checked
            My.Settings.Save()

            If gb6.Enabled Then Save6Config()
            If gb7.Enabled Then Save7Config()

            frmLauncher.lblDebug.Visible = cbDebug.Checked
            If Not gotError Then Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Save6Config()
        Try
            WriteIniValue(Id6Config, "General", "FreePlay", Convert.ToInt32(cbFree6.Checked))
            WriteIniValue(Id6Config, "General", "Windowed", cbWindow6.Checked.ToString.ToLower)
            WriteIniValue(Id6Config, "General", "EnableAmdFix", cbAMDFix6.Checked.ToString.ToLower)

            If cbSaveSeat.Checked Then SetSeatName(cmbSeat6.SelectedItem, 6)

            WriteIniValue(Id6Config, "Network", "Ip", txtIP6.Text)
            WriteIniValue(Id6Config, "Network", "Mask", txtMask6.Text)
            WriteIniValue(Id6Config, "Network", "Gateway", txtGateway6.Text)
            WriteIniValue(Id6Config, "Network", "Dns1", txtDNSP6.Text)
            WriteIniValue(Id6Config, "Network", "Dns2", txtDNSS6.Text)
            WriteIniValue(Id6Config, "Network", "BroadcastIP", txtBroadcast6.Text)
            WriteIniValue(Id6Config, "Network", "Cab1IP", txtCab1IP6.Text)
            WriteIniValue(Id6Config, "Network", "Cab2IP", txtCab2IP6.Text)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            gotError = True
        End Try
    End Sub

    Private Sub Save7Config()
        Try
            WriteIniValue(Id7Config, "General", "FreePlay", Convert.ToInt32(cbFree7.Checked))
            WriteIniValue(Id7Config, "General", "Windowed", cbWindow7.Checked.ToString.ToLower)
            WriteIniValue(Id7Config, "General", "EnableAmdFix", cbAMDFix7.Checked.ToString.ToLower)

            'If cbSaveSeat.Checked Then SetSeatName(cmbSeat7.SelectedItem, 7)

            WriteIniValue(Id7Config, "Network", "Ip", txtIP7.Text)
            WriteIniValue(Id7Config, "Network", "Mask", txtMask7.Text)
            WriteIniValue(Id7Config, "Network", "Gateway", txtGateway7.Text)
            WriteIniValue(Id7Config, "Network", "Dns1", txtDNSP7.Text)
            WriteIniValue(Id7Config, "Network", "Dns2", txtDNSS7.Text)
            WriteIniValue(Id7Config, "Network", "BroadcastIP", txtBroadcast7.Text)
            WriteIniValue(Id7Config, "Network", "Cab1IP", txtCab1IP7.Text)
            WriteIniValue(Id7Config, "Network", "Cab2IP", txtCab2IP7.Text)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            gotError = True
        End Try
    End Sub

    Private Sub frmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        pattern = pattern & "1"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        pattern = pattern & "2"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If pattern = "12121" Then cbDebug.Enabled = True
    End Sub

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIP6.KeyPress, txtBroadcast6.KeyPress, txtCab1IP6.KeyPress, txtCab2IP6.KeyPress, txtDNSP6.KeyPress, txtDNSS6.KeyPress, txtGateway6.KeyPress, txtMask6.KeyPress, txtBroadcast7.KeyPress, txtCab1IP7.KeyPress, txtCab2IP7.KeyPress, txtDNSP7.KeyPress, txtDNSS7.KeyPress, txtGateway7.KeyPress, txtIP7.KeyPress, txtMask7.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = Keys.Delete Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Back Then
            Return
        End If
        e.Handled = True
    End Sub

End Class