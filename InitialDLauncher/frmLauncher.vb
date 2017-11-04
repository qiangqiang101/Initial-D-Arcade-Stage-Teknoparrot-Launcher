﻿Imports System.IO
Imports System.Net
Imports System.Threading

Public Class frmLauncher

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public WithEvents proc As Process
    Dim debug As Boolean = My.Settings.DebugMode
    Dim threadE As Thread
    Dim shadow As Dropshadow
    Dim defaultLocation As Point
    Dim curVer As Integer = 2, buildDate As String = "5/11/2017"

    Dim id6AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBUU_card.bin"
    Dim id7AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TeknoParrot\SBYD_card.bin"
    Public id6CardPath As String = My.Settings.Id6CardName
    Public id7CardPath As String = My.Settings.Id7CardName
    Dim id6CardDir As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardDir As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)

    Dim selPath As String = String.Empty
    Dim lastGame As Integer = 0

    Private Sub frmLauncher_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, pbLogo.MouseDown
        drag = True
        mousex = System.Windows.Forms.Cursor.Position.X - Me.Left
        mousey = System.Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmLauncher_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, pbLogo.MouseMove
        If drag Then
            Me.Top = System.Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = System.Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmLauncher_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, pbLogo.MouseUp
        drag = False
    End Sub

    Private Sub lblStart6_MouseEnter(sender As Object, e As EventArgs) Handles lblStart6.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblStart6.ForeColor = Color.Gold
        lblStart6.Text = lblStart6.Text & " <<"
    End Sub

    Private Sub lblStart6_MouseLeave(sender As Object, e As EventArgs) Handles lblStart6.MouseLeave
        Me.Cursor = Cursors.Default
        lblStart6.ForeColor = Color.White
        lblStart6.Text = lblStart6.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblStart7_MouseEnter(sender As Object, e As EventArgs) Handles lblStart7.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblStart7.ForeColor = Color.Gold
        lblStart7.Text = lblStart7.Text & " <<"
    End Sub

    Private Sub lblStart7_MouseLeave(sender As Object, e As EventArgs) Handles lblStart7.MouseLeave
        Me.Cursor = Cursors.Default
        lblStart7.ForeColor = Color.White
        lblStart7.Text = lblStart7.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblSetting_MouseEnter(sender As Object, e As EventArgs) Handles lblSetting.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblSetting.ForeColor = Color.Gold
        lblSetting.Text = lblSetting.Text & " <<"
    End Sub

    Private Sub lblSetting_MouseLeave(sender As Object, e As EventArgs) Handles lblSetting.MouseLeave
        Me.Cursor = Cursors.Default
        lblSetting.ForeColor = Color.White
        lblSetting.Text = lblSetting.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblExit.ForeColor = Color.Gold
        lblExit.Text = lblExit.Text & " <<"
    End Sub

    Private Sub lblExit_MouseLeave(sender As Object, e As EventArgs) Handles lblExit.MouseLeave
        Me.Cursor = Cursors.Default
        lblExit.ForeColor = Color.White
        lblExit.Text = lblExit.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblDebug_MouseEnter(sender As Object, e As EventArgs) Handles lblDebug.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblDebug.ForeColor = Color.Gold
        lblDebug.Text = lblDebug.Text & " <<"
    End Sub

    Private Sub lblDebug_MouseLeave(sender As Object, e As EventArgs) Handles lblDebug.MouseLeave
        Me.Cursor = Cursors.Default
        lblDebug.ForeColor = Color.White
        lblDebug.Text = lblDebug.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub lblCardMan_MouseEnter(sender As Object, e As EventArgs) Handles lblCardMan.MouseEnter
        My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        Me.Cursor = Cursors.Hand
        lblCardMan.ForeColor = Color.Gold
        lblCardMan.Text = lblCardMan.Text & " <<"
    End Sub

    Private Sub lblCardMan_MouseLeave(sender As Object, e As EventArgs) Handles lblCardMan.MouseLeave
        Me.Cursor = Cursors.Default
        lblCardMan.ForeColor = Color.White
        lblCardMan.Text = lblCardMan.Text.Replace(" <<", String.Empty)
    End Sub

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        defaultLocation = Me.Location
        Me.Location = New Point(((Screen.PrimaryScreen.Bounds.Width / 100) - (Me.Width * 2)) - 1000, Me.Location.Y)

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

        lblVersion.Text = String.Format("Version: {0} Build: {1}", My.Application.Info.Version, buildDate)

        threadE = New Thread(AddressOf EnterAni)
        threadE.Start()
    End Sub

    Private Function CheckForUpdate() As Integer
        Dim address As String = "https://raw.githubusercontent.com/qiangqiang101/Initial-D-Arcade-Stage-Teknoparrot-Launcher/master/ver/ver.txt"
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead("https://raw.githubusercontent.com/qiangqiang101/Initial-D-Arcade-Stage-Teknoparrot-Launcher/master/ver/ver.txt"))
        Return reader.ReadToEnd
    End Function

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        Me.Enabled = False
        Thread.Sleep(1000)
        threadE = New Thread(AddressOf ExitAni)
        threadE.Start()
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
            My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)

            If Not IsCardFolderEmpty(id6CardDir) AndAlso id6CardPath = Nothing Then
                Dim result As Integer = MessageBox.Show("No card selected! Are you sure you want to play without a card?", "Initial D Launcher", MessageBoxButtons.YesNo)
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
            My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)

            If Not IsCardFolderEmpty(id7CardDir) AndAlso id7CardPath = Nothing Then
                Dim result As Integer = MessageBox.Show("No card selected! Are you sure you want to play without a card?", "Initial D Launcher", MessageBoxButtons.YesNo)
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()
            If curVer <> CheckForUpdate() Then
                Dim result As Integer = MessageBox.Show("New version detected, do you want to update?", "Initial D Launcher", MessageBoxButtons.YesNo)
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
End Class
