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

    'Translate
    Dim no_exe, no_name, name_is_taken, name_is_available As String

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt6.Text = My.Settings.Id6Path
            txt7.Text = My.Settings.Id7Path
            txtPlayerName.Text = My.Settings.UserName
            cbTest.Checked = My.Settings.TestMode
            cbDebug.Checked = My.Settings.DebugMode
            cbMP.Checked = My.Settings.Multiplayer
            cmbLang.SelectedItem = My.Settings.Language
            cmbCountry.SelectedItem = My.Settings.UserCountry

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
            If IO.File.Exists(SBUU_e2prom) Then cmbSeat6.SelectedItem = GetSeatName(GetHex(SBUU_e2prom, 116, 4), 6)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Load7Config()
        Try
            'cmbSeat7.SelectedItem = GetSeatName(GetHex(SBYD_e2prom, 116, 4), 7)
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
                'ElseIf txtPlayerName.Text = Nothing Then
                '    MsgBox(no_name, MsgBoxStyle.Critical, "Error")
                '    txtPlayerName.Focus()
            Else
                If Not txtPlayerName.Text = "" Then If My.Settings.UserCountry <> cmbCountry.SelectedItem.ToString Then UpdateUserCountry()

                My.Settings.Id6Path = txt6.Text
                My.Settings.Id7Path = txt7.Text
                My.Settings.UserName = txtPlayerName.Text
                My.Settings.TestMode = cbTest.Checked
                My.Settings.DebugMode = cbDebug.Checked
                My.Settings.Multiplayer = cbMP.Checked
                My.Settings.Language = cmbLang.SelectedItem
                My.Settings.UserCountry = cmbCountry.SelectedItem
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
            If cbSaveSeat.Checked Then SetSeatName(cmbSeat6.SelectedItem, 6)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            gotError = True
        End Try
    End Sub

    Private Sub Save7Config()
        Try
            'If cbSaveSeat.Checked Then SetSeatName(cmbSeat7.SelectedItem, 7)
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

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Control Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Back Then
            Return
        End If
        e.Handled = True
    End Sub

    Dim _allowedCharacters As String = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
    Private Sub txtPlayerName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlayerName.KeyPress
        If Not _allowedCharacters.Contains(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Settings"
                NsTheme1.Text = Me.Text
                Label1.Text = "Initial D 6AA Path"
                Label2.Text = "Initial D 7AAX Path"
                cbTest.Text = "Test Menu"
                cbDebug.Text = "Debug Mode"
                cbSaveSeat.Text = "Save Cabinet Seat"
                Label21.Text = "Launcher Language"
                gb6.Title = "Initial D 6AA Cabinet Seat (BETA)"
                gb7.Title = "Initial D 7AAX Cabinet Seat (BETA)"
                GroupBox1.Title = "Cabinet Seat (BETA)"
                btnSave.Text = "Save"
                no_exe = "Please Enter Path without file name."
                no_name = "Please Enter your User Name."
                name_is_taken = "This name is already taken."
                name_is_available = "This name is available."
                Label22.Text = "User Name"
                Label23.Text = "Country"
                cbMP.Text = "Multiplayer"
            Case "Chinese"
                Me.Text = "設定"
                NsTheme1.Text = Me.Text
                Label1.Text = "頭文字D6AA路徑"
                Label2.Text = "頭文字D7AAX路徑"
                cbTest.Text = "測試菜單"
                cbDebug.Text = "調試模式"
                cbSaveSeat.Text = "保存座位"
                Label21.Text = "登陸器語言"
                gb6.Title = "頭文字D6AA座位(BETA)"
                gb7.Title = "頭文字D7AAX座位(BETA)"
                GroupBox1.Title = "座位(BETA)"
                btnSave.Text = "保存"
                no_exe = "請輸入沒有文件名的路徑。"
                no_name = "請輸入您的用戶名。"
                name_is_taken = "這個名字已有人使用。"
                name_is_available = "這個名字可使用."
                Label22.Text = "用戶名"
                Label23.Text = "國家"
                cbMP.Text = "線上模式"
            Case "French"
                Me.Text = "Réglages"
                NsTheme1.Text = Me.Text
                Label1.Text = "Initial D 6AA Chemin"
                Label2.Text = "Initial D 7AAX Chemin"
                cbTest.Text = "Test Menu"
                cbDebug.Text = "Mode Debug"
                cbSaveSeat.Text = "Sauv Cabinet Seat"
                Label21.Text = "Langue"
                gb6.Title = "Initial D 6AA Cabinet Seat (BETA)"
                gb7.Title = "Initial D 7AAX Cabinet Seat (BETA)"
                GroupBox1.Title = "Cabinet Seat (BETA)"
                btnSave.Text = "Sauv"
                no_exe = "Veuillez entrer le chemin sans nom de fichier."
                no_name = "S'il vous plaît entrez votre nom d'utilisateur."
                name_is_taken = "Ce nom est déjà pris."
                name_is_available = "Ce nom est disponible."
                Label22.Text = "Nom d'utilisateur"
                Label23.Text = "Pays"
                cbMP.Text = "Multijoueur"
        End Select
    End Sub


    Dim UpdateUserCountryURL As String = "http://id.imnotmental.com/SetUserCountry.php?"
    Dim UpdateUserCountryURLCN As String = "http://www.emulot.cn/id/SetUserCountry.php?"
    Private Sub UpdateUserCountry()
        Try
            Dim client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            If My.Settings.Server = "World" Then
                client.DownloadString(Convert.ToString(UpdateUserCountryURL + "userEmail=" & My.Settings.UserEmail & "&userCountry=" & cmbCountry.SelectedItem.ToString))
            Else
                client.DownloadString(Convert.ToString(UpdateUserCountryURLCN + "userEmail=" & My.Settings.UserEmail & "&userCountry=" & cmbCountry.SelectedItem.ToString))
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class