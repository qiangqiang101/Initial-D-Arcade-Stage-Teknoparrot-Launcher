﻿Imports System.IO

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
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If txtEmail.Text = Nothing Then
                NSMessageBox.ShowOk(no_email, MsgBoxStyle.Critical, "Error")
                txtEmail.Focus()
            ElseIf txtPassword.Text = Nothing Then
                NSMessageBox.ShowOk(no_password, MsgBoxStyle.Critical, "Error")
                txtPassword.Focus()
            ElseIf Not IsUserEmailPasswordValid(txtEmail.Text, txtPassword.Text) Then
                NSMessageBox.ShowOk(got_error, MsgBoxStyle.Critical, "Error")
                txtEmail.Text = ""
                txtPassword.Text = ""
                txtEmail.Focus()
            Else
                My.Settings.LoggedIn = True
                If cbRemember.Checked Then My.Settings.UserEmail = txtEmail.Text
                My.Settings.UserName = GetUserName(txtEmail.Text)
                My.Settings.UserCountry = GetUserCountry(txtEmail.Text)
                My.Settings.Save()
                NSMessageBox.ShowOk(String.Format(welcome_user, My.Settings.UserName), MsgBoxStyle.Information, "Login")
                frmLauncher.Translate()
                Me.Close()
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Me.Text = ReadCfgValue("LoginMeText", langFile)
            NsTheme1.Text = Me.Text
            Label2.Text = ReadCfgValue("Email", langFile)
            Label1.Text = ReadCfgValue("Password", langFile)
            cbRemember.Text = ReadCfgValue("Remember", langFile)
            btnLogin.Text = ReadCfgValue("Login", langFile)
            llblRegister.Text = ReadCfgValue("Register", langFile)
            got_error = ReadCfgValue("GotError", langFile)
            no_email = ReadCfgValue("NoEmail", langFile)
            no_password = ReadCfgValue("NoPassword", langFile)
            welcome_user = ReadCfgValue("WelcomeUser", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub llblRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRegister.LinkClicked
        Process.Start("http://id.imnotmental.com/member/register.php")
    End Sub

    Private Function IsUserEmailPasswordValid(email As String, pass As String) As Boolean
        Dim result As Boolean = False

        Dim sha256 As String = EncryptSHA256Managed(pass)
        Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

        Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(GetLoginURL + "userEmail=" & email & "&userPass=" & sha256)))
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

        Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserNameURL + "userEmail=" & email)))
        Return reader.ReadToEnd
    End Function

    Private Function GetUserCountry(email As String) As String
        Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

        Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(GetUserCountryURL + "userEmail=" & email)))
        Return reader.ReadToEnd
    End Function

    Private Sub frmLogin_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub
End Class