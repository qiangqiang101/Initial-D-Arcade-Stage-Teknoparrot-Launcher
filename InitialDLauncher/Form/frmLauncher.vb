Imports System.IO
Imports System.Net
Imports System.Threading
Imports PluginContract

Public Class frmLauncher

    Dim widthx As Integer = 43
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public WithEvents proc As Process
    Dim debug As Boolean = My.Settings.DebugMode
    Dim threadU As Thread
    Dim shadow As Dropshadow
    Dim curVer As Integer = 30
    Public buildDate As String = "18/04/2018"

    Dim id6AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBUU_card.bin")
    Dim id7AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBYD_card.bin")
    Public Shared id6GameDir As String = Path.Combine(My.Settings.Id6Path, "InidCrd000.crd")
    Public Shared id7GameDir As String = Path.Combine(My.Settings.Id7Path, "InidCrd000.crd")
    Public id6CardPath As String = My.Settings.Id6CardName
    Public id7CardPath As String = My.Settings.Id7CardName
    Dim id6CardDir As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardDir As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)

    Dim selPath As String = String.Empty
    Dim lastGame As Integer = 0
    Public Shared isGameRunning As Boolean = False
    Public Shared hideMe As Boolean = False
    Public Shared endMe As Boolean = False

    Public Shared cheat As Boolean = False
    Dim pattern As String = Nothing

    Public plugins As ICollection(Of iPlugin) = PluginLoader.LoadPlugins("Plugins")

    'Translation
    Dim new_version, no_card_selected As String

    Private Sub frmLauncher_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, pbLogo.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmLauncher_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, pbLogo.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmLauncher_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, pbLogo.MouseUp
        drag = False
    End Sub

    Private Sub lblStart6_MouseEnter(sender As Object, e As EventArgs) Handles lblStart6.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblStart6.ForeColor = Color.Gold
        lblStart6.Size = New Size(lblStart6.Size.Width + widthx, lblStart6.Size.Height)
        lblStart6.Text = lblStart6.Text & " <<"
    End Sub

    Private Sub lblStart6_MouseLeave(sender As Object, e As EventArgs) Handles lblStart6.MouseLeave
        Me.Cursor = Cursors.Default
        lblStart6.ForeColor = Color.White
        lblStart6.Size = New Size(lblStart6.Size.Width - widthx, lblStart6.Size.Height)
        lblStart6.Text = lblStart6.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblStart7_MouseEnter(sender As Object, e As EventArgs) Handles lblStart7.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblStart7.ForeColor = Color.Gold
        lblStart7.Size = New Size(lblStart7.Size.Width + widthx, lblStart7.Size.Height)
        lblStart7.Text = lblStart7.Text & " <<"
    End Sub

    Private Sub lblStart7_MouseLeave(sender As Object, e As EventArgs) Handles lblStart7.MouseLeave
        Me.Cursor = Cursors.Default
        lblStart7.ForeColor = Color.White
        lblStart7.Size = New Size(lblStart7.Size.Width - widthx, lblStart7.Size.Height)
        lblStart7.Text = lblStart7.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblSetting_MouseEnter(sender As Object, e As EventArgs) Handles lblSetting.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblSetting.ForeColor = Color.Gold
        lblSetting.Size = New Size(lblSetting.Size.Width + widthx, lblSetting.Size.Height)
        lblSetting.Text = lblSetting.Text & " <<"
    End Sub

    Private Sub lblSetting_MouseLeave(sender As Object, e As EventArgs) Handles lblSetting.MouseLeave
        Me.Cursor = Cursors.Default
        lblSetting.ForeColor = Color.White
        lblSetting.Size = New Size(lblSetting.Size.Width - widthx, lblSetting.Size.Height)
        lblSetting.Text = lblSetting.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblExit.ForeColor = Color.Gold
        lblExit.Size = New Size(lblExit.Size.Width + widthx, lblExit.Size.Height)
        lblExit.Text = lblExit.Text & " <<"
    End Sub

    Private Sub lblExit_MouseLeave(sender As Object, e As EventArgs) Handles lblExit.MouseLeave
        Me.Cursor = Cursors.Default
        lblExit.ForeColor = Color.White
        lblExit.Size = New Size(lblExit.Size.Width - widthx, lblExit.Size.Height)
        lblExit.Text = lblExit.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblDebug_MouseEnter(sender As Object, e As EventArgs) Handles lblDebug.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblDebug.ForeColor = Color.Gold
        lblDebug.Size = New Size(lblDebug.Size.Width + widthx, lblDebug.Size.Height)
        lblDebug.Text = lblDebug.Text & " <<"
    End Sub

    Private Sub lblDebug_MouseLeave(sender As Object, e As EventArgs) Handles lblDebug.MouseLeave
        Me.Cursor = Cursors.Default
        lblDebug.ForeColor = Color.White
        lblDebug.Size = New Size(lblDebug.Size.Width - widthx, lblDebug.Size.Height)
        lblDebug.Text = lblDebug.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblCardMan_MouseEnter(sender As Object, e As EventArgs) Handles lblCardMan.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblCardMan.ForeColor = Color.Gold
        lblCardMan.Size = New Size(lblCardMan.Size.Width + widthx, lblCardMan.Size.Height)
        lblCardMan.Text = lblCardMan.Text & " <<"
    End Sub

    Private Sub lblCardMan_MouseLeave(sender As Object, e As EventArgs) Handles lblCardMan.MouseLeave
        Me.Cursor = Cursors.Default
        lblCardMan.ForeColor = Color.White
        lblCardMan.Size = New Size(lblCardMan.Size.Width - widthx, lblCardMan.Size.Height)
        lblCardMan.Text = lblCardMan.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblLeaderboard_MouseEnter(sender As Object, e As EventArgs) Handles lblLeaderboard.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblLeaderboard.ForeColor = Color.Gold
        lblLeaderboard.Size = New Size(lblLeaderboard.Size.Width + widthx, lblLeaderboard.Size.Height)
        lblLeaderboard.Text = lblLeaderboard.Text & " <<"
    End Sub

    Private Sub lblLeaderboard_MouseLeave(sender As Object, e As EventArgs) Handles lblLeaderboard.MouseLeave
        Me.Cursor = Cursors.Default
        lblLeaderboard.ForeColor = Color.White
        lblLeaderboard.Size = New Size(lblLeaderboard.Size.Width - widthx, lblLeaderboard.Size.Height)
        lblLeaderboard.Text = lblLeaderboard.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.UserPaint, True)

            If Not Directory.Exists(id6CardDir) Then Directory.CreateDirectory(id6CardDir)
            If Not Directory.Exists(id7CardDir) Then Directory.CreateDirectory(id7CardDir)

            shadow = New Dropshadow(Me) With {.ShadowBlur = 30, .ShadowSpread = 1, .ShadowColor = Color.Black}
            shadow.RefreshShadow()

            lblDebug.Visible = debug
            CheckForIllegalCrossThreadCalls = False
            GetGamePath()

            If Not File.Exists(id6CardPath) Then
                My.Settings.Id6CardName = ""
                My.Settings.Save()
            End If
            If Not File.Exists(id7CardPath) Then
                My.Settings.Id7CardName = ""
                My.Settings.Save()
            End If

            If My.Settings.Id6Path = Nothing Then lblStart6.Enabled = False
            If My.Settings.Id7Path = Nothing Then lblStart7.Enabled = False

            Translate()

            For Each item In plugins
                item.DoSomething()
                Dim timer As System.Windows.Forms.Timer = New System.Windows.Forms.Timer With {.Interval = 60, .Enabled = True}
                AddHandler timer.Tick, AddressOf item.TimerTick
            Next

            'AutoCardMove()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub

    Private Function CheckForUpdate() As Integer
        Dim client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

        Dim reader As StreamReader = New StreamReader(client.OpenRead("https://raw.githubusercontent.com/qiangqiang101/Initial-D-Arcade-Stage-Teknoparrot-Launcher/master/ver/ver.txt"))
        Return reader.ReadToEnd
    End Function

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        Me.Enabled = False
        Thread.Sleep(2000)
        End
    End Sub

    Private Sub RunGame(CardDir As String, CardPath As String, GameID As Integer, AppData As String, MySettingGameDir As String, Profile As String)
        Try
            My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)

            If Not IsCardFolderEmpty(CardDir) AndAlso CardPath = Nothing Then
                Dim result As Integer = MessageBox.Show(no_card_selected, "Initial D Launcher", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    selPath = CardPath
                    lastGame = GameID
                    Me.WindowState = FormWindowState.Minimized

                    If File.Exists(CardPath) Then If Not File.Exists(AppData) Then File.Move(CardPath, AppData)
                    If IO.Path.GetExtension(AppData) = ".bin" Then RunParrotLoader(String.Format("{0}\picodaemon.exe", MySettingGameDir), False)
                    If My.Settings.Multiplayer Then
                        RunTeknoParrotOnline(True)
                    Else
                        RunParrotLoaderUI(Profile, True, My.Settings.TestMode)
                    End If
                End If
            Else
                selPath = CardPath
                lastGame = GameID
                Me.WindowState = FormWindowState.Minimized

                If File.Exists(CardPath) Then If Not File.Exists(AppData) Then File.Move(CardPath, AppData)
                If IO.Path.GetExtension(AppData) = ".bin" Then RunParrotLoader(String.Format("{0}\picodaemon.exe", MySettingGameDir), False)
                If My.Settings.Multiplayer Then
                    RunTeknoParrotOnline(True)
                Else
                    RunParrotLoaderUI(Profile, True, My.Settings.TestMode)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub lblStart6_Click(sender As Object, e As EventArgs) Handles lblStart6.Click
        isGameRunning = True
        wait(500)

        Select Case IO.Path.GetExtension(My.Settings.Id6CardName)
            Case ".bin"
                RunGame(id6CardDir, id6CardPath, 6, id6AppData, My.Settings.Id6Path, "--profile=ID6.xml")
            Case ".crd"
                RunGame(id6CardDir, id6CardPath, 6, id6GameDir, My.Settings.Id6Path, "--profile=ID6.xml")
            Case Else
                Select Case My.Settings.PerferCardExt
                    Case "CRD"
                        RunGame(id6CardDir, id6CardPath, 6, id6GameDir, My.Settings.Id6Path, "--profile=ID6.xml")
                    Case "BIN"
                        RunGame(id6CardDir, id6CardPath, 6, id6AppData, My.Settings.Id6Path, "--profile=ID6.xml")
                End Select
        End Select
    End Sub

    Private Sub lblStart7_Click(sender As Object, e As EventArgs) Handles lblStart7.Click
        isGameRunning = True
        wait(500)

        Select Case IO.Path.GetExtension(My.Settings.Id7CardName)
            Case ".bin"
                RunGame(id7CardDir, id7CardPath, 7, id7AppData, My.Settings.Id7Path, "--profile=ID7.xml")
            Case ".crd"
                RunGame(id7CardDir, id7CardPath, 7, id7GameDir, My.Settings.Id7Path, "--profile=ID7.xml")
            Case Else
                Select Case My.Settings.PerferCardExt
                    Case "CRD"
                        RunGame(id7CardDir, id7CardPath, 7, id7GameDir, My.Settings.Id7Path, "--profile=ID7.xml")
                    Case "BIN"
                        RunGame(id7CardDir, id7CardPath, 7, id7AppData, My.Settings.Id7Path, "--profile=ID7.xml")
                End Select
        End Select
    End Sub

    Private Sub lblSetting_Click(sender As Object, e As EventArgs) Handles lblSetting.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        frmSettings.Show()
        Me.Enabled = False
    End Sub

    Private Sub frmLauncher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not proc.HasExited Then
            e.Cancel = False
        Else
            isGameRunning = False
        End If
    End Sub

    Private Sub lblDebug_Click(sender As Object, e As EventArgs) Handles lblDebug.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        MsgBox(String.Format("ID6 AppData Path: {0}{1}ID7 AppData Path: {2}{1}{1}ID6 GameDir Path: {3}{1}ID7 GameDir Path: {4}{1}{1}ID6 Card File Path: {5}{1}ID7 Card File Path: {6}{1}{1}ID6 Game Path: {7}{1}ID7 Game Path: {8}{1}{1}ID6 Selected Card: {9}{1}ID7 Selected Card: {10}{1}{1}CPU ID: {11}", id6AppData, vbNewLine, id7AppData, id6GameDir, id7GameDir, id6CardPath, id7CardPath, My.Settings.Id6Path, My.Settings.Id7Path, My.Settings.Id6CardName, My.Settings.Id7CardName, getNewCPUID))
    End Sub

    Private Sub lblCardMan_Click(sender As Object, e As EventArgs) Handles lblCardMan.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        frmCard.Show()
        Me.Enabled = False
    End Sub

    Private Sub lblLeaderboard_Click(sender As Object, e As EventArgs) Handles lblLeaderboard.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        frmLeaderboard.Show()
        Me.Enabled = False
    End Sub

    Private Sub Proc_Exited() Handles proc.Exited
        Try
            If selPath = Nothing Then
                Select Case lastGame
                    Case 6
                        'Select Case IO.Path.GetExtension(My.Settings.Id6CardName)
                        '    Case ".bin"
                        '        selPath = String.Format("{0}\ID6_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        '        If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                        '    Case ".crd"
                        '        selPath = String.Format("{0}\ID6_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        '        If File.Exists(id6GameDir) Then File.Move(id6GameDir, selPath)
                        '    Case Else
                        'End Select
                        selPath = String.Format("{0}\ID6_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        If File.Exists(id6GameDir) Then File.Move(id6GameDir, selPath)
                    Case 7
                        'Select Case IO.Path.GetExtension(My.Settings.Id6CardName)
                        '    Case ".bin"
                        '        selPath = String.Format("{0}\ID7_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        '        If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                        '    Case ".crd"
                        '        selPath = String.Format("{0}\ID7_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        '        If File.Exists(id7GameDir) Then File.Move(id7GameDir, selPath)
                        '    Case Else
                        'End Select
                        selPath = String.Format("{0}\ID7_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        If File.Exists(id7GameDir) Then File.Move(id7GameDir, selPath)
                End Select
            Else
                Select Case lastGame
                    Case 6
                        If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                        If File.Exists(id6GameDir) Then File.Move(id6GameDir, selPath)
                    Case 7
                        If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                        If File.Exists(id7GameDir) Then File.Move(id7GameDir, selPath)
                End Select
            End If

            Me.WindowState = FormWindowState.Normal
            isGameRunning = False
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click
        frmAbout.Show()
    End Sub

    Private Sub lblVersion_MouseEnter(sender As Object, e As EventArgs) Handles lblVersion.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblVersion.ForeColor = Color.Gold
    End Sub

    Private Sub lblVersion_MouseLeave(sender As Object, e As EventArgs) Handles lblVersion.MouseLeave
        Me.Cursor = Cursors.Default
        lblVersion.ForeColor = Color.White
    End Sub

    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click
        My.Settings.LoggedIn = False
        My.Settings.UserEmail = Nothing
        My.Settings.UserName = Nothing
        My.Settings.UserCountry = Nothing
        My.Settings.Save()
        Translate()
        frmLogin.Show()
        Me.Enabled = False
    End Sub

    Private Sub lblLogout_MouseEnter(sender As Object, e As EventArgs) Handles lblLogout.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblLogout.ForeColor = Color.Gold
    End Sub

    Private Sub lblLogout_MouseLeave(sender As Object, e As EventArgs) Handles lblLogout.MouseLeave
        Me.Cursor = Cursors.Default
        lblLogout.ForeColor = Color.White
    End Sub

    Private Sub frmLauncher_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        pattern = pattern & e.KeyChar
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            If Not cheat Then
                If pattern.Substring(pattern.Length - 13) = "imnoobcheater" Then
                    My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
                    cheat = True
                End If
            End If

            If Not debug Then
                If pattern.Substring(pattern.Length - 7) = "debugon" Then
                    My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
                    My.Settings.DebugMode = True
                    My.Settings.Save()
                    debug = True
                    lblDebug.Visible = debug
                End If
            End If

            If debug Then
                If pattern.Substring(pattern.Length - 8) = "debugoff" Then
                    My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
                    My.Settings.DebugMode = False
                    My.Settings.Save()
                    debug = False
                    lblDebug.Visible = debug
                End If
            End If

            If hideMe Then
                Me.Hide()
            Else
                Me.Show()
            End If

            If endMe Then Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()
            threadU = New Thread(AddressOf CheckUpdate)
            threadU.Start()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub AutoCardMove()
        If File.Exists(id6AppData) Then If Not File.Exists(Path.Combine(id6CardDir, "SBUU_card.bin")) Then File.Move(id6AppData, id6CardDir)
        If File.Exists(id6GameDir) Then If Not File.Exists(Path.Combine(id6CardDir, "InidCrd000.crd")) Then File.Move(id6GameDir, id6CardDir)
        If File.Exists(id7AppData) Then If Not File.Exists(Path.Combine(id7CardDir, "SBYD_card.bin")) Then File.Move(id7AppData, id7CardDir)
        If File.Exists(id7GameDir) Then If Not File.Exists(Path.Combine(id7CardDir, "InidCrd000.crd")) Then File.Move(id7GameDir, id7CardDir)
    End Sub

    Private Sub CheckUpdate()
        Try
            If curVer <> CheckForUpdate() Then
                Dim result As Integer = MessageBox.Show(new_version, "Initial D Launcher", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    If IsURLValid("https://www.imnotmental.com/tool/initial-d-arcade-stage-launcher-teknoparrot/") Then
                        Process.Start("https://www.imnotmental.com/tool/initial-d-arcade-stage-launcher-teknoparrot/")
                        End
                    Else
                        Process.Start("https://www.patreon.com/posts/initial-d-arcade-15177342")
                        End
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                lblStart6.Text = "Play Initial D 6 AA"
                lblStart7.Text = "Play Initial D 7 AAX"
                lblLeaderboard.Text = "Time Attack Ranking"
                lblCardMan.Text = "Card Selection"
                lblSetting.Text = "Settings"
                lblExit.Text = "Quit Game"
                lblDebug.Text = "Debug"
                lblVersion.Text = String.Format("Version: {0} Build: {1}", My.Application.Info.Version, buildDate)
                new_version = "New version detected, do you want to update?"
                no_card_selected = "No card selected! Are you sure you want to play without a card?"
                If Not My.Settings.UserName = "" Then lblLogout.Text = String.Format("User: {0} | Logout", My.Settings.UserName) Else lblLogout.Text = "Login"
            Case "Chinese"
                lblStart6.Text = "玩頭文字D6AA"
                lblStart7.Text = "玩頭文字D7AAX"
                lblLeaderboard.Text = "時間挑戰排行榜"
                lblCardMan.Text = "選擇卡"
                lblSetting.Text = "設定"
                lblExit.Text = "離開遊戲"
                lblDebug.Text = "调试"
                lblVersion.Text = String.Format("版本: {0} 創建: {1}", My.Application.Info.Version, buildDate)
                new_version = "發現新版本，你想更新吗？"
                no_card_selected = "没有选择卡！ 你想繼續嗎？"
                If Not My.Settings.UserName = "" Then lblLogout.Text = String.Format("用戶名: {0} | 登出", My.Settings.UserName) Else lblLogout.Text = "登錄"
            Case "French"
                lblStart6.Text = "Jouer Initial D 6 AA"
                lblStart7.Text = "Jouer Initial D 7 AAX"
                lblLeaderboard.Text = "TA Classement"
                lblCardMan.Text = "Choisir Carte"
                lblSetting.Text = "Réglages"
                lblExit.Text = "Quitter"
                lblDebug.Text = "Déboguer"
                lblVersion.Text = String.Format("Version: {0} Build: {1}", My.Application.Info.Version, buildDate)
                new_version = "New version detected, do you want to update?"
                no_card_selected = "No card selected! Are you sure you want to play without a card?"
                If Not My.Settings.UserName = "" Then lblLogout.Text = String.Format("Utilisateur: {0} | Connectez - Out", My.Settings.UserName) Else lblLogout.Text = "S'identifier"
        End Select
    End Sub
End Class
