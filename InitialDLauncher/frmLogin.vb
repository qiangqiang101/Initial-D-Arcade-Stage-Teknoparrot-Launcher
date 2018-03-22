Imports System.IO

Public Class frmLogin

    Dim GetLoginURL As String = "http://id.imnotmental.com/isuserexist.php?"
    Dim GetLoginURLCN As String = "http://www.emulot.cn/id/isuserexist.php?"
    Dim GetUserNameURL As String = "http://id.imnotmental.com/GetUserName.php?"
    Dim GetUserNameURLCN As String = "http://www.emulot.cn/id/GetUserName.php?"
    Dim GetUserCountryURL As String = "http://id.imnotmental.com/GetUserCountry.php?"
    Dim GetUserCountryURLCN As String = "http://www.emulot.cn/id/GetUserCountry.php?"

    'Translate
    Dim got_error, no_email, no_password, welcome_user As String

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()

        cmbServer.SelectedIndex = 0
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.WindowState = FormWindowState.Normal
        frmLauncher.Enabled = True
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtEmail.Text = Nothing Then
            MsgBox(no_email, MsgBoxStyle.Critical, "Error")
            txtEmail.Focus()
        ElseIf txtPassword.Text = Nothing Then
            MsgBox(no_password, MsgBoxStyle.Critical, "Error")
            txtPassword.Focus()
        ElseIf Not IsUserEmailPasswordValid(txtEmail.Text, txtPassword.Text) Then
            MsgBox(got_error, MsgBoxStyle.Critical, "Error")
            txtEmail.Clear()
            txtPassword.Clear()
            txtEmail.Focus()
        Else
            My.Settings.LoggedIn = True
            My.Settings.Server = cmbServer.SelectedItem.ToString
            If cbRemember.Checked Then My.Settings.UserEmail = txtEmail.Text
            My.Settings.UserName = GetUserName(txtEmail.Text)
            My.Settings.UserCountry = GetUserCountry(txtEmail.Text)
            My.Settings.Save()
            MsgBox(String.Format(welcome_user, My.Settings.UserName), MsgBoxStyle.Information, "Login")
            frmLauncher.Translate()
            Me.Close()
        End If
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Login"
                Label23.Text = "Server"
                Label2.Text = "Email"
                Label1.Text = "Password"
                cbRemember.Text = "Remember me"
                btnLogin.Text = "Login"
                llblRegister.Text = "Click here to Register"
                got_error = "Invalid Email or Password."
                no_email = "Please Enter your Email Address."
                no_password = "Please Enter your Password."
                welcome_user = "Welcome back {0}, Login Successful."
            Case "Chinese"
                Me.Text = "登錄"
                Label23.Text = "服務器"
                Label2.Text = "電郵"
                Label1.Text = "密碼"
                cbRemember.Text = "記住我"
                btnLogin.Text = "登錄"
                llblRegister.Text = "點這裡註冊帳號"
                got_error = "無效的郵件或密碼。"
                no_email = "請輸入你的電子郵件。"
                no_password = "請輸入你的密碼。"
                welcome_user = "熱烈歡迎 {0}，登錄成功。"
            Case "French"
                Me.Text = "S'identifier"
                Label23.Text = "Serveur"
                Label2.Text = "Email"
                Label1.Text = "Mot de passe"
                cbRemember.Text = "Souviens-toi de moi"
                btnLogin.Text = "Login"
                llblRegister.Text = "Cliquez ici pour vous inscrire"
                got_error = "Email ou mot de passe invalide."
                no_email = "S'il vous plaît entrez votre adresse e-mail."
                no_password = "S'il vous plait entrez votre mot de passe."
                welcome_user = "Bienvenue, {0}, Connexion réussie."
        End Select
    End Sub

    Private Sub llblRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRegister.LinkClicked
        Select Case cmbServer.SelectedItem
            Case "World"
                Process.Start("http://id.imnotmental.com/member/register.php")
            Case "China"
                Process.Start("http://www.emulot.cn/id/member/register.php")
        End Select
    End Sub

    Private Function IsUserEmailPasswordValid(email As String, pass As String) As Boolean
        Dim result As Boolean = False

        Dim sha256 As String = EncryptSHA256Managed(pass)
        Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}
        Dim reader As StreamReader
        If cmbServer.SelectedItem.ToString = "World" Then
            reader = New StreamReader(Client.OpenRead(Convert.ToString(GetLoginURL + "userEmail=" & email & "&userPass=" & sha256)))
        Else
            reader = New StreamReader(Client.OpenRead(Convert.ToString(GetLoginURLCN + "userEmail=" & email & "&userPass=" & sha256)))
        End If
        Dim Source As String = reader.ReadToEnd
        If Source = "no" Then
            result = False
        Else
            result = True
        End If

        Return result
    End Function

    Private Function GetUserName(email As String) As String
        Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}
        Dim reader As StreamReader
        If My.Settings.Server = "World" Then
            reader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserNameURL + "userEmail=" & email)))
        Else
            reader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserNameURLCN + "userEmail=" & email)))
        End If
        Return reader.ReadToEnd
    End Function

    Private Function GetUserCountry(email As String) As String
        Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}
        Dim reader As StreamReader
        If My.Settings.Server = "World" Then
            reader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserCountryURL + "userEmail=" & email)))
        Else
            reader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserCountryURLCN + "userEmail=" & email)))
        End If
        Return reader.ReadToEnd
    End Function
End Class