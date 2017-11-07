﻿Imports System.IO
Imports System.Net
Imports System.Threading

Public Class frmLauncher

    Dim widthx As Integer = 43
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public WithEvents proc As Process
    Dim debug As Boolean = My.Settings.DebugMode
    Dim threadE, threadU As Thread
    Dim shadow As Dropshadow
    Dim defaultLocation As Point
    Dim curVer As Integer = 7, buildDate As String = "8/11/2017"

    Dim id6AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_card.bin"
    Dim id7AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBYD_card.bin"
    Public id6CardPath As String = My.Settings.Id6CardName
    Public id7CardPath As String = My.Settings.Id7CardName
    Dim id6CardDir As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardDir As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)

    Dim selPath As String = String.Empty
    Dim lastGame As Integer = 0
    Dim mp3File As String = String.Format("{0}\launcher.mp3", My.Application.Info.DirectoryPath)
    Dim audio As AudioFile

    Public cheat As Boolean = False
    Dim pattern As String = Nothing

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

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        'defaultLocation = Me.Location
        'Me.Location = New Point(((Screen.PrimaryScreen.Bounds.Width / 100) - (Me.Width * 2)) - 1000, Me.Location.Y)

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

        If File.Exists(mp3File) Then
            audio = New AudioFile(mp3File)
            audio.Play()
            audio.SetVolume(500)
        End If

        'threadE = New Thread(AddressOf EnterAni)
        'threadE.Start()
    End Sub

    Private Function CheckForUpdate() As Integer
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead("https://raw.githubusercontent.com/qiangqiang101/Initial-D-Arcade-Stage-Teknoparrot-Launcher/master/ver/ver.txt"))
        Return reader.ReadToEnd
    End Function

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        Me.Enabled = False
        Thread.Sleep(2000)
        End
        'threadE = New Thread(AddressOf ExitAni)
        'threadE.Start()
    End Sub

    Private Sub ExitAni()
        Dim x As Integer = Me.Location.X
Restart:
        If Not Me.Location.X = (Screen.PrimaryScreen.Bounds.Width + Me.Width + 1000) Then
            x += 1
            Me.Location = New Point(x, Me.Location.Y)
        Else
            End
        End If
        GoTo Restart
    End Sub

    Private Sub EnterAni()
        Dim x As Integer = Me.Location.X
Restart:
        If Not Me.Location.X = defaultLocation.X Then
            x += 1
            Me.Location = New Point(x, Me.Location.Y)
        Else
            Exit Sub
        End If
        GoTo Restart
    End Sub

    Private Sub lblStart6_Click(sender As Object, e As EventArgs) Handles lblStart6.Click
        Try
            If File.Exists(mp3File) Then audio.Pause()
            My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)

            If Not IsCardFolderEmpty(id6CardDir) AndAlso id6CardPath = Nothing Then
                Dim result As Integer = MessageBox.Show(no_card_selected, "Initial D Launcher", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    selPath = id6CardPath
                    lastGame = 6
                    Me.WindowState = FormWindowState.Minimized

                    If File.Exists(id6CardPath) Then If Not File.Exists(id6AppData) Then File.Move(id6CardPath, id6AppData)
                    RunParrotLoader(String.Format("{0}\picodaemon.exe", My.Settings.Id6Path), False)
                    Shell(My.Application.Info.DirectoryPath & "\dumbjvscmd.exe 8")
                    If My.Settings.TestMode Then
                        RunParrotLoader(String.Format("{0}\id6_dump_.exe", My.Settings.Id6Path), True, True)
                    Else
                        RunParrotLoader(String.Format("{0}\id6_dump_.exe", My.Settings.Id6Path), True)
                    End If
                    Shell("taskkill /F /IM dumbjvscmd.exe", AppWinStyle.Hide)
                End If
            Else
                selPath = id6CardPath
                lastGame = 6
                Me.WindowState = FormWindowState.Minimized

                If File.Exists(id6CardPath) Then If Not File.Exists(id6AppData) Then File.Move(id6CardPath, id6AppData)
                RunParrotLoader(String.Format("{0}\picodaemon.exe", My.Settings.Id6Path), False)
                Shell(My.Application.Info.DirectoryPath & "\dumbjvscmd.exe 8")
                If My.Settings.TestMode Then
                    RunParrotLoader(String.Format("{0}\id6_dump_.exe", My.Settings.Id6Path), True, True)
                Else
                    RunParrotLoader(String.Format("{0}\id6_dump_.exe", My.Settings.Id6Path), True)
                End If
                Shell("taskkill /F /IM dumbjvscmd.exe", AppWinStyle.Hide)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub lblStart7_Click(sender As Object, e As EventArgs) Handles lblStart7.Click
        Try
            If File.Exists(mp3File) Then audio.Pause()
            My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)

            If Not IsCardFolderEmpty(id7CardDir) AndAlso id7CardPath = Nothing Then
                Dim result As Integer = MessageBox.Show(no_card_selected, "Initial D Launcher", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    selPath = id7CardPath
                    lastGame = 7
                    Me.WindowState = FormWindowState.Minimized

                    If File.Exists(id7CardPath) Then If Not File.Exists(id7AppData) Then File.Move(id7CardPath, id7AppData)
                    RunParrotLoader(String.Format("{0}\picodaemon.exe", My.Settings.Id7Path), False)
                    Shell(My.Application.Info.DirectoryPath & "\dumbjvscmd.exe 8")
                    If My.Settings.TestMode Then
                        RunParrotLoader(String.Format("{0}\InitialD7_GLW_RE_SBYD_dumped_.exe", My.Settings.Id7Path), True, True)
                    Else
                        RunParrotLoader(String.Format("{0}\InitialD7_GLW_RE_SBYD_dumped_.exe", My.Settings.Id7Path), True)
                    End If
                    Shell("taskkill /F /IM dumbjvscmd.exe", AppWinStyle.Hide)
                End If
            Else
                selPath = id7CardPath
                lastGame = 7
                Me.WindowState = FormWindowState.Minimized

                If File.Exists(id7CardPath) Then If Not File.Exists(id7AppData) Then File.Move(id7CardPath, id7AppData)
                RunParrotLoader(String.Format("{0}\picodaemon.exe", My.Settings.Id7Path), False)
                Shell(My.Application.Info.DirectoryPath & "\dumbjvscmd.exe 8")
                If My.Settings.TestMode Then
                    RunParrotLoader(String.Format("{0}\InitialD7_GLW_RE_SBYD_dumped_.exe", My.Settings.Id7Path), True, True)
                Else
                    RunParrotLoader(String.Format("{0}\InitialD7_GLW_RE_SBYD_dumped_.exe", My.Settings.Id7Path), True)
                End If
                Shell("taskkill /F /IM dumbjvscmd.exe", AppWinStyle.Hide)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
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
            If File.Exists(mp3File) Then audio.Stop()
        End If
    End Sub

    Private Sub lblDebug_Click(sender As Object, e As EventArgs) Handles lblDebug.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        MsgBox(String.Format("ID6 AppData Path: {0}{1}ID7 AppData Path: {2}", id6AppData, vbNewLine, id7AppData))
        MsgBox(String.Format("ID6 Card File Path: {0}{1}ID7 Card File Path: {2}", id6CardPath, vbNewLine, id7CardPath))
        MsgBox(String.Format("ID6 Game Path: {0}{1}ID7 Game Path: {2}", My.Settings.Id6Path, vbNewLine, My.Settings.Id7Path))
        MsgBox(String.Format("ID6 Selected Card: {0}{1}ID7 Selected Card: {2}", My.Settings.Id6CardName, vbNewLine, My.Settings.Id7CardName))
    End Sub

    Private Sub lblCardMan_Click(sender As Object, e As EventArgs) Handles lblCardMan.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        frmCard.Show()
        Me.Enabled = False
    End Sub

    Private Sub Proc_Exited() Handles proc.Exited
        Try
            If selPath = Nothing Then
                Select Case lastGame
                    Case 6
                        selPath = String.Format("{0}\ID6_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                    Case 7
                        selPath = String.Format("{0}\ID7_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                        If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                End Select
            Else
                Select Case lastGame
                    Case 6
                        If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                    Case 7
                        If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                End Select
            End If

            Me.WindowState = FormWindowState.Normal
            If File.Exists(mp3File) Then audio.Resume()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click
        Process.Start("https://www.imnotmental.com")
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
                lblCardMan.Text = "Card Selection"
                lblSetting.Text = "Settings"
                lblExit.Text = "Quit Game"
                lblDebug.Text = "Debug"
                lblVersion.Text = String.Format("Version: {0} Build: {1}", My.Application.Info.Version, buildDate)
                new_version = "New version detected, do you want to update?"
                no_card_selected = "No card selected! Are you sure you want to play without a card?"
            Case "Chinese"
                lblStart6.Text = "玩頭文字D6AA"
                lblStart7.Text = "玩頭文字D7AAX"
                lblCardMan.Text = "選擇卡"
                lblSetting.Text = "設定"
                lblExit.Text = "離開遊戲"
                lblDebug.Text = "调试"
                lblVersion.Text = String.Format("版本: {0} 創建: {1}", My.Application.Info.Version, buildDate)
                new_version = "發現新版本，你想更新吗？"
                no_card_selected = "没有选择卡！ 你想繼續嗎？"
            Case "French"
                lblStart6.Text = "Jouer Initial D 6 AA"
                lblStart7.Text = "Jouer Initial D 7 AAX"
                lblCardMan.Text = "Choisir Carte"
                lblSetting.Text = "Réglages"
                lblExit.Text = "Quitter"
                lblDebug.Text = "Déboguer"
                lblVersion.Text = String.Format("Version: {0} Build: {1}", My.Application.Info.Version, buildDate)
                new_version = "New version detected, do you want to update?"
                no_card_selected = "No card selected! Are you sure you want to play without a card?"
        End Select
    End Sub
End Class
