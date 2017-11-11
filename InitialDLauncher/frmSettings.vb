Imports System.IO
Imports System.Net

Public Class frmSettings

    Dim pattern As String
    Dim Id6Config As String = String.Format("{0}\config.ini", My.Settings.Id6Path)
    Dim Id7Config As String = String.Format("{0}\config.ini", My.Settings.Id7Path)
    Dim SBUU_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_e2prom.bin"
    'Dim SBYD_e2prom As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBYD_e2prom.bin"
    Dim bool As List(Of String) = New List(Of String) From {"true", "false"}
    Dim gotError As Boolean = False

    Dim GetUserURL As String = "http://id.imnotmental.com/CheckUser.php?"

    'Translate
    Dim no_exe, no_name, name_is_taken, name_is_available As String

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt6.Text = My.Settings.Id6Path
            txt7.Text = My.Settings.Id7Path
            txtPlayerName.Text = My.Settings.UserName
            cbTest.Checked = My.Settings.TestMode
            cbDebug.Checked = My.Settings.DebugMode
            cmbLang.SelectedItem = My.Settings.Language

            If Not My.Settings.Id6Path = String.Empty Then gb6.Enabled = True
            If Not My.Settings.Id7Path = String.Empty Then gb7.Enabled = True

            If gb6.Enabled Then Load6Config()
            If gb7.Enabled Then Load7Config()

            Translate()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Load6Config()
        Try
            cbFree6.Checked = Convert.ToBoolean(CInt(ReadIniValue(Id6Config, "General", "FreePlay")))
            If bool.Contains(ReadIniValue(Id6Config, "General", "Windowed").ToLower) Then cbWindow6.Checked = Convert.ToBoolean(ReadIniValue(Id6Config, "General", "Windowed"))
            If bool.Contains(ReadIniValue(Id6Config, "General", "EnableAmdFix").ToLower) Then cbAMDFix6.Checked = Convert.ToBoolean(ReadIniValue(Id6Config, "General", "EnableAmdFix"))
            If IO.File.Exists(SBUU_e2prom) Then cmbSeat6.SelectedItem = GetSeatName(GetHex(SBUU_e2prom, 116, 4), 6)

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
            If txt6.Text.Contains(".exe") Then
                MsgBox(no_exe, MsgBoxStyle.Critical, "Error")
                txt6.Focus()
            ElseIf txt7.Text.Contains(".exe") Then
                MsgBox(no_exe, MsgBoxStyle.Critical, "Error")
                txt7.Focus()
            ElseIf txtPlayerName.Text = Nothing Then
                MsgBox(no_name, MsgBoxStyle.Critical, "Error")
                txtPlayerName.Focus()
            Else
                My.Settings.Id6Path = txt6.Text
                My.Settings.Id7Path = txt7.Text
                My.Settings.UserName = txtPlayerName.Text
                My.Settings.TestMode = cbTest.Checked
                My.Settings.DebugMode = cbDebug.Checked
                My.Settings.Language = cmbLang.SelectedItem
                My.Settings.Save()

                If gb6.Enabled Then Save6Config()
                If gb7.Enabled Then Save7Config()

                frmLauncher.lblDebug.Visible = cbDebug.Checked
                frmLauncher.Translate()
                If Not gotError Then Me.Close()
            End If
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
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Control Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Back Then
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If txtPlayerName.Text = Nothing Then
            MsgBox(no_name, MsgBoxStyle.Critical, "Error")
            txtPlayerName.Focus()
        Else
            If IsNameTaken(txtPlayerName.Text) Then
                MsgBox(name_is_taken, MsgBoxStyle.Information, "Name Check")
            Else
                MsgBox(name_is_available, MsgBoxStyle.Information, "Name Check")
            End If
        End If
    End Sub

    Private Function IsNameTaken(name As String) As Boolean
        Dim result As Boolean = False

        Dim Client As WebClient = New WebClient
        Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserURL + "name=" & name)))
        Dim Source As String = reader.ReadToEnd
        If Source = "no" Then
            result = False
        Else
            result = True
        End If

        Return result
    End Function

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Settings"
                Label1.Text = "Initial D 6AA Path"
                Label2.Text = "Initial D 7AAX Path"
                cbTest.Text = "Test Menu"
                cbDebug.Text = "Debug Mode"
                cbSaveSeat.Text = "Save Cabinet Seat"
                Label21.Text = "Launcher Language"
                gb6.Text = "Initial D 6AA Config"
                gb7.Text = "Initial D 7AAX Config"
                GroupBox2.Text = "General"
                GroupBox6.Text = GroupBox2.Text
                GroupBox3.Text = "Network"
                GroupBox5.Text = GroupBox3.Text
                cbFree6.Text = "Free Play"
                cbFree7.Text = cbFree6.Text
                cbWindow6.Text = "Window Mode"
                cbWindow7.Text = cbWindow6.Text
                cbAMDFix6.Text = "AMD Fix"
                cbAMDFix7.Text = cbAMDFix6.Text
                Label11.Text = "Cabinet Seat (BETA)"
                Label20.Text = Label11.Text
                Label3.Text = "IP Address"
                Label19.Text = Label3.Text
                Label5.Text = "Subnet Mask"
                Label17.Text = Label5.Text
                Label4.Text = "Default Gateway"
                Label18.Text = Label4.Text
                Label10.Text = "Broadcast IP"
                Label14.Text = Label10.Text
                Label6.Text = "Primary DNS"
                Label16.Text = Label6.Text
                Label7.Text = "Secondary DNS"
                Label15.Text = Label7.Text
                Label9.Text = "Cabinet 1 IP"
                Label13.Text = Label9.Text
                Label8.Text = "Cabinet 2 IP"
                Label12.Text = Label8.Text
                btnSave.Text = "Save"
                no_exe = "Please Enter Path without file name."
                no_name = "Please Enter your User Name."
                name_is_taken = "This name is already taken."
                name_is_available = "This name is available."
                Label22.Text = "User Name"
                btnCheck.Text = "Check"
            Case "Chinese"
                Me.Text = "設定"
                Label1.Text = "頭文字D6AA路徑"
                Label2.Text = "頭文字D7AAX路徑"
                cbTest.Text = "測試菜單"
                cbDebug.Text = "調試模式"
                cbSaveSeat.Text = "保存座位"
                Label21.Text = "登陸器語言"
                gb6.Text = "頭文字D6AA配置"
                gb7.Text = "頭文字D7AAX配置"
                GroupBox2.Text = "一般"
                GroupBox6.Text = GroupBox2.Text
                GroupBox3.Text = "網絡"
                GroupBox5.Text = GroupBox3.Text
                cbFree6.Text = "免费玩"
                cbFree7.Text = cbFree6.Text
                cbWindow6.Text = "窗口模式"
                cbWindow7.Text = cbWindow6.Text
                cbAMDFix6.Text = "AMD修復"
                cbAMDFix7.Text = cbAMDFix6.Text
                Label11.Text = "座位(BETA)"
                Label20.Text = Label11.Text
                Label3.Text = "IP地址"
                Label19.Text = Label3.Text
                Label5.Text = "子網掩碼"
                Label17.Text = Label5.Text
                Label4.Text = "默認網關"
                Label18.Text = Label4.Text
                Label10.Text = "廣播IP"
                Label14.Text = Label10.Text
                Label6.Text = "主DNS"
                Label16.Text = Label6.Text
                Label7.Text = "副DNS"
                Label15.Text = Label7.Text
                Label9.Text = "座位1 IP"
                Label13.Text = Label9.Text
                Label8.Text = "座位2 IP"
                Label12.Text = Label8.Text
                btnSave.Text = "保存"
                no_exe = "請輸入沒有文件名的路徑。"
                no_name = "請輸入您的用戶名。"
                name_is_taken = "這個名字已有人使用。"
                name_is_available = "這個名字可使用."
                Label22.Text = "用戶名"
                btnCheck.Text = "檢測"
            Case "French"
                Me.Text = "Réglages"
                Label1.Text = "Initial D 6AA Chemin"
                Label2.Text = "Initial D 7AAX Chemin"
                cbTest.Text = "Test Menu"
                cbDebug.Text = "Mode Debug"
                cbSaveSeat.Text = "Sauv Cabinet Seat"
                Label21.Text = "Langue"
                gb6.Text = "Initial D 6AA Config"
                gb7.Text = "Initial D 7AAX Config"
                GroupBox2.Text = "General"
                GroupBox6.Text = GroupBox2.Text
                GroupBox3.Text = "Network"
                GroupBox5.Text = GroupBox3.Text
                cbFree6.Text = "Free Play"
                cbFree7.Text = cbFree6.Text
                cbWindow6.Text = "Fenetre Mod"
                cbWindow7.Text = cbWindow6.Text
                cbAMDFix6.Text = "AMD Fix"
                cbAMDFix7.Text = cbAMDFix6.Text
                Label11.Text = "Cabinet Seat (BETA)"
                Label20.Text = Label11.Text
                Label3.Text = "IP Address"
                Label19.Text = Label3.Text
                Label5.Text = "Subnet Mask"
                Label17.Text = Label5.Text
                Label4.Text = "Default Gateway"
                Label18.Text = Label4.Text
                Label10.Text = "Broadcast IP"
                Label14.Text = Label10.Text
                Label6.Text = "Primary DNS"
                Label16.Text = Label6.Text
                Label7.Text = "Secondary DNS"
                Label15.Text = Label7.Text
                Label9.Text = "Cabinet 1 IP"
                Label13.Text = Label9.Text
                Label8.Text = "Cabinet 2 IP"
                Label12.Text = Label8.Text
                btnSave.Text = "Sauv"
                no_exe = "Veuillez entrer le chemin sans nom de fichier."
                no_name = "S'il vous plaît entrez votre nom d'utilisateur."
                name_is_taken = "Ce nom est déjà pris."
                name_is_available = "Ce nom est disponible."
                Label22.Text = "Nom d'utilisateur"
                btnCheck.Text = "Vérifier"
        End Select
    End Sub

End Class