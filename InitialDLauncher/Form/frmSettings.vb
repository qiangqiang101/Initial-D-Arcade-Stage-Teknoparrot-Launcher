Imports System.IO
Imports System.Net

Public Class frmSettings

    Dim pattern As String
    Dim gotError As Boolean = False

    'Translate
    Dim no_exe, no_name, name_is_taken, name_is_available As String

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt6.Text = My.Settings.Id6Path
            txt7.Text = My.Settings.Id7Path
            txt8.Text = My.Settings.Id8Path
            txtPlayerName.Text = My.Settings.UserName
            cbTest.Checked = My.Settings.TestMode
            cbDebug.Checked = My.Settings.DebugMode
            cbMP.Checked = My.Settings.Multiplayer
            cmbLang.SelectedItem = My.Settings.Language
            cmbCountry.SelectedItem = My.Settings.UserCountry
            cmbPrefer.SelectedItem = My.Settings.PerferCardExt

            Translate()
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
            ElseIf txt8.Text.Contains(".exe") Then
                MsgBox(no_exe, MsgBoxStyle.Critical, "Error")
                txt8.Focus()
            Else
                If Not txtPlayerName.Text = "" Then If My.Settings.UserCountry <> cmbCountry.SelectedItem.ToString Then UpdateUserCountry()

                My.Settings.Id6Path = txt6.Text
                My.Settings.Id7Path = txt7.Text
                My.Settings.Id8Path = txt8.Text
                My.Settings.UserName = txtPlayerName.Text
                My.Settings.TestMode = cbTest.Checked
                My.Settings.DebugMode = cbDebug.Checked
                My.Settings.Multiplayer = cbMP.Checked
                My.Settings.Language = cmbLang.SelectedItem
                My.Settings.UserCountry = cmbCountry.SelectedItem
                My.Settings.PerferCardExt = cmbPrefer.SelectedItem
                My.Settings.Save()

                frmLauncher.id6GameDir = Path.Combine(My.Settings.Id6Path, "InidCrd000.crd")
                frmLauncher.id7GameDir = Path.Combine(My.Settings.Id7Path, "InidCrd000.crd")
                frmLauncher.id8GameDir = Path.Combine(My.Settings.Id8Path, "InidCrd000.crd")

                frmLauncher.lblDebug.Visible = cbDebug.Checked
                frmLauncher.Translate()
                If Not gotError Then Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            Exit Sub
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
                Label4.Text = "Initial D 8 Path"
                cbTest.Text = "Test Menu"
                cbDebug.Text = "Debug Mode"
                Label21.Text = "Launcher Language"
                btnSave.Text = "Save"
                no_exe = "Please Enter Path without file name."
                no_name = "Please Enter your User Name."
                name_is_taken = "This name is already taken."
                name_is_available = "This name is available."
                Label22.Text = "User Name"
                Label23.Text = "Country"
                cbMP.Text = "Multiplayer"
                Label3.Text = "Card Prefer"
                cbPicodaemon.Text = "Run Card Reader"
            Case "Chinese"
                Me.Text = "設定"
                NsTheme1.Text = Me.Text
                Label1.Text = "頭文字D6AA路徑"
                Label2.Text = "頭文字D7AAX路徑"
                Label4.Text = "頭文字D8路徑"
                cbTest.Text = "測試菜單"
                cbDebug.Text = "調試模式"
                Label21.Text = "登陸器語言"
                btnSave.Text = "保存"
                no_exe = "請輸入沒有文件名的路徑。"
                no_name = "請輸入您的用戶名。"
                name_is_taken = "這個名字已有人使用。"
                name_is_available = "這個名字可使用."
                Label22.Text = "用戶名"
                Label23.Text = "國家"
                cbMP.Text = "線上模式"
                Label3.Text = "默認選擇卡"
                cbPicodaemon.Text = "運行讀卡器"
            Case "French"
                Me.Text = "Réglages"
                NsTheme1.Text = Me.Text
                Label1.Text = "Initial D 6AA Chemin"
                Label2.Text = "Initial D 7AAX Chemin"
                Label4.Text = "Initial D 8 Chemin"
                cbTest.Text = "Test Menu"
                cbDebug.Text = "Mode Debug"
                Label21.Text = "Langue"
                btnSave.Text = "Sauv"
                no_exe = "Veuillez entrer le chemin sans nom de fichier."
                no_name = "S'il vous plaît entrez votre nom d'utilisateur."
                name_is_taken = "Ce nom est déjà pris."
                name_is_available = "Ce nom est disponible."
                Label22.Text = "Nom d'utilisateur"
                Label23.Text = "Pays"
                cbMP.Text = "Multijoueur"
                Label3.Text = "Card Prefer"
                cbPicodaemon.Text = "Run Card Reader"
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

    Private Sub frmSettings_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub
End Class