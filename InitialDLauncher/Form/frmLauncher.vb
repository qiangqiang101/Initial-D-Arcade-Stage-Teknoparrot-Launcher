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
    Public shadow As Dropshadow
    Dim curVer As Integer = 38
    Public buildDate As String = "26/05/2018"

    Dim id6AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBUU_card.bin")
    Dim id7AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBYD_card.bin")
    Dim id8AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBZZ_card.bin")
    Public Shared id6GameDir As String = Path.Combine(My.Settings.Id6Path, "InidCrd000.crd")
    Public Shared id7GameDir As String = Path.Combine(My.Settings.Id7Path, "InidCrd000.crd")
    Public Shared id8GameDir As String = Path.Combine(My.Settings.Id8Path, "InidCrd000.crd")
    Public id6CardPath As String = My.Settings.Id6CardName
    Public id7CardPath As String = My.Settings.Id7CardName
    Public id8CardPath As String = My.Settings.Id8CardName
    Dim id6CardDir As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardDir As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)
    Dim id8CardDir As String = String.Format("{0}\ID8_CARD\", My.Application.Info.DirectoryPath)

    Dim selPath As String = String.Empty
    Dim lastGame As Integer = 0
    Public Shared isGameRunning As Boolean = False
    'Public Shared hideMe As Boolean = False
    'Public Shared endMe As Boolean = False

    Dim pattern As String = Nothing

    Public plugins As ICollection(Of iPlugin) = PluginLoader.LoadPlugins("Plugins")

    'Translation
    Dim new_version, no_card_selected As String

    Private gifImage As GifImage = New GifImage(My.Resources.background_video) With {.ReverseAtEnd = False}

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

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim args As String() = Environment.GetCommandLineArgs()
            For Each arg As String In args
                If arg.Contains("-cardeditor") Then
                    CardEditorLoad()
                    Opacity = 0
                    Exit Sub
                End If
            Next
            LauncherNormalLoad()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            Exit Sub
        End Try
    End Sub

    Private Sub CardEditorLoad()
        Try
            Dim ofd As New OpenFileDialog()
            Dim fe As frmEdit = New frmEdit()
            ofd.Filter = "New Card Code CRD file (*.crd)|*.crd|Picodaemon BIN file (*.bin)|*.bin"
            ofd.FilterIndex = 1
            ofd.RestoreDirectory = True
            ofd.InitialDirectory = My.Application.Info.DirectoryPath
            If ofd.ShowDialog() = DialogResult.OK Then
                'Dim newFileName As String = String.Format("{0}\{1}.bak", Path.GetDirectoryName(ofd.FileName), Path.GetFileName(ofd.FileName))
                'File.Copy(ofd.FileName, newFileName, True)
                Select Case Path.GetExtension(ofd.FileName)
                    Case ".bin"
                        If GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 7 Then
                            fe.Version = 7
                            fe.FileName = ofd.FileName
                            fe.Extension = "bin"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 6 Then
                            fe.Version = 6
                            fe.FileName = ofd.FileName
                            fe.Extension = "bin"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 8 Then
                            fe.Version = 8
                            fe.FileName = ofd.FileName
                            fe.Extension = "bin"
                            fe.CardEditOnly = True
                        End If
                    Case ".crd"
                        If GetCardVersion(GetHex(ofd.FileName, &H14, 2)) = 7 Then
                            fe.Version = 7
                            fe.FileName = ofd.FileName
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 6 Then
                            fe.Version = 6
                            fe.FileName = ofd.FileName
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 8 Then
                            fe.Version = 8
                            fe.FileName = ofd.FileName
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        End If
                End Select
                fe.ShowDialog()
                fe.BringToFront()
            Else
                End
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub LauncherNormalLoad()
        Try
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.UserPaint, True)

            If Not My.Settings.VideoBackground Then
                Timer3.Stop()
                Timer4.Stop()
                BackgroundImage = My.Resources.launcher_bg
            Else
                Timer3.Start()
                Timer4.Start()
            End If

            If Not Directory.Exists(id6CardDir) Then Directory.CreateDirectory(id6CardDir)
            If Not Directory.Exists(id7CardDir) Then Directory.CreateDirectory(id7CardDir)
            If Not Directory.Exists(id8CardDir) Then Directory.CreateDirectory(id8CardDir)

            If My.Settings.FullScreen Then
                WindowState = FormWindowState.Maximized
            Else
                WindowState = FormWindowState.Normal
            End If

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
            If Not File.Exists(id8CardPath) Then
                My.Settings.Id8CardName = ""
                My.Settings.Save()
            End If

            If My.Settings.Id6Path = Nothing Then lblStart6.Enabled = False
            If My.Settings.Id7Path = Nothing Then lblStart7.Enabled = False
            If My.Settings.Id8Path = Nothing Then lblStart8.Enabled = False

            Translate()

            For Each item In plugins
                item.DoSomething()
                Dim timer As System.Windows.Forms.Timer = New System.Windows.Forms.Timer With {.Interval = 60, .Enabled = True}
                AddHandler timer.Tick, AddressOf item.TimerTick
            Next

            If lblStart6.Enabled Then
                lblStart6.Focus()
            Else
                If lblStart7.Enabled Then
                    lblStart7.Focus()
                Else
                    If lblStart8.Enabled Then
                        lblStart8.Focus()
                    Else
                        If lblLeaderboard.Enabled Then lblLeaderboard.Focus()
                    End If
                End If
            End If

            Timer1.Start()
            Timer3.Start()
            Timer4.Start()
            'AutoCardMove()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            Exit Sub
        End Try
    End Sub

    Private Function CheckForUpdate() As Integer
        Dim client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

        Dim reader As StreamReader = New StreamReader(client.OpenRead("https://raw.githubusercontent.com/qiangqiang101/Initial-D-Arcade-Stage-Teknoparrot-Launcher/master/ver/ver.txt"))
        Return reader.ReadToEnd
    End Function

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click, lblExit.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        Me.Enabled = False
        Thread.Sleep(2000)
        End
    End Sub

    Private Sub RunGame(CardDir As String, CardPath As String, GameID As Integer, AppData As String, MySettingGameDir As String, Profile As String)
        Try
            Dim rd As Random = New Random
            Dim x As Integer = rd.Next(1, 27)
            My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject("Play" & x), AudioPlayMode.Background)

            If Not IsCardFolderEmpty(CardDir) AndAlso CardPath = Nothing Then
                Dim result As Integer = MessageBox.Show(no_card_selected, "Initial D Launcher", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    selPath = CardPath
                    lastGame = GameID
                    Me.WindowState = FormWindowState.Minimized

                    If File.Exists(CardPath) Then If Not File.Exists(AppData) Then File.Move(CardPath, AppData)
                    If IO.Path.GetExtension(AppData) = ".bin" Then If My.Settings.RunCardReader Then RunParrotLoader(String.Format("{0}\picodaemon.exe", MySettingGameDir), False)
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
                If IO.Path.GetExtension(AppData) = ".bin" Then If My.Settings.RunCardReader Then RunParrotLoader(String.Format("{0}\picodaemon.exe", MySettingGameDir), False)
                If My.Settings.Multiplayer Then
                    RunTeknoParrotOnline(True)
                Else
                    RunParrotLoaderUI(Profile, True, My.Settings.TestMode)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            Exit Sub
        End Try
    End Sub

    Private Sub lblStart6_Click(sender As Object, e As EventArgs) Handles lblStart6.Click, lblStart6.EnterPressed
        If My.Settings.VideoBackground Then
            Timer3.Stop()
            Timer4.Stop()
        End If
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

    Private Sub lblStart7_Click(sender As Object, e As EventArgs) Handles lblStart7.Click, lblStart7.EnterPressed
        If My.Settings.VideoBackground Then
            Timer3.Stop()
            Timer4.Stop()
        End If
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

    Private Sub lblStart8_Click(sender As Object, e As EventArgs) Handles lblStart8.Click, lblStart8.EnterPressed
        If My.Settings.VideoBackground Then
            Timer3.Stop()
            Timer4.Stop()
        End If
        isGameRunning = True
        wait(500)

        Select Case IO.Path.GetExtension(My.Settings.Id8CardName)
            Case ".bin"
                RunGame(id8CardDir, id8CardPath, 8, id8AppData, My.Settings.Id8Path, "--profile=ID8.xml")
            Case ".crd"
                RunGame(id8CardDir, id8CardPath, 8, id8GameDir, My.Settings.Id8Path, "--profile=ID8.xml")
            Case Else
                Select Case My.Settings.PerferCardExt
                    Case "CRD"
                        RunGame(id8CardDir, id8CardPath, 8, id8GameDir, My.Settings.Id8Path, "--profile=ID8.xml")
                    Case "BIN"
                        RunGame(id8CardDir, id8CardPath, 8, id8AppData, My.Settings.Id8Path, "--profile=ID8.xml")
                End Select
        End Select
    End Sub

    Private Sub lblSetting_Click(sender As Object, e As EventArgs) Handles lblSetting.Click, lblSetting.EnterPressed
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

    Private Sub lblDebug_Click(sender As Object, e As EventArgs) Handles lblDebug.Click, lblDebug.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        MsgBox(String.Format("ID6 AppData Path: {0}{1}ID7 AppData Path: {2}{1}ID8 AppData Path: {12}{1}{1}ID6 GameDir Path: {3}{1}ID7 GameDir Path: {4}{1}ID8 GameDir Path: {13}{1}{1}ID6 Card File Path: {5}{1}ID7 Card File Path: {6}{1}ID8 Card File Path: {14}{1}{1}ID6 Game Path: {7}{1}ID7 Game Path: {8}{1}ID8 Game Path: {15}{1}{1}ID6 Selected Card: {9}{1}ID7 Selected Card: {10}{1}ID8 Selected Card: {16}{1}{1}CPU ID: {11}", id6AppData, vbNewLine, id7AppData, id6GameDir, id7GameDir, id6CardPath, id7CardPath, My.Settings.Id6Path, My.Settings.Id7Path, My.Settings.Id6CardName, My.Settings.Id7CardName, getNewCPUID, id8AppData, id8GameDir, id8CardPath, My.Settings.Id8Path, My.Settings.Id8CardName))
    End Sub

    Private Sub lblCardMan_Click(sender As Object, e As EventArgs) Handles lblCardMan.Click, lblCardMan.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        frmCard.Show()
        Me.Enabled = False
    End Sub

    Private Sub lblLeaderboard_Click(sender As Object, e As EventArgs) Handles lblLeaderboard.Click, lblLeaderboard.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        frmLeaderboard.Show()
        Me.Enabled = False
    End Sub

    Private Sub Proc_Exited() Handles proc.Exited
        Try
            If selPath = Nothing Then
                If My.Settings.PerferCardExt = "CRD" Then
                    Select Case lastGame
                        Case 6
                            selPath = String.Format("{0}\ID6_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id6GameDir) Then File.Move(id6GameDir, selPath)
                        Case 7
                            selPath = String.Format("{0}\ID7_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id7GameDir) Then File.Move(id7GameDir, selPath)
                        Case 8
                            selPath = String.Format("{0}\ID8_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id8GameDir) Then File.Move(id8GameDir, selPath)
                    End Select
                ElseIf My.Settings.PerferCardExt = "BIN" Then
                    Select Case lastGame
                        Case 6
                            selPath = String.Format("{0}\ID6_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                        Case 7
                            selPath = String.Format("{0}\ID7_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                        Case 8
                            selPath = String.Format("{0}\ID8_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id8AppData) Then File.Move(id8AppData, selPath)
                    End Select
                End If
            Else
                Select Case lastGame
                    Case 6
                        If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                        If File.Exists(id6GameDir) Then File.Move(id6GameDir, selPath)
                    Case 7
                        If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                        If File.Exists(id7GameDir) Then File.Move(id7GameDir, selPath)
                    Case 8
                        If File.Exists(id8AppData) Then File.Move(id8AppData, selPath)
                        If File.Exists(id8GameDir) Then File.Move(id8GameDir, selPath)
                End Select
            End If

            If My.Settings.FullScreen Then
                WindowState = FormWindowState.Maximized
            Else
                WindowState = FormWindowState.Normal
            End If
            isGameRunning = False
            If My.Settings.VideoBackground Then
                Timer3.Start()
                Timer4.Start()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click, lblVersion.EnterPressed
        Me.Enabled = False
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

    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click, lblLogout.EnterPressed
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

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    Try
    '        If Not cheat Then
    '            If pattern.Substring(pattern.Length - 13) = "imnoobcheater" Then
    '                My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
    '                cheat = True
    '            End If
    '        End If

    '        If Not debug Then
    '            If pattern.Substring(pattern.Length - 7) = "debugon" Then
    '                My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
    '                My.Settings.DebugMode = True
    '                My.Settings.Save()
    '                debug = True
    '                lblDebug.Visible = debug
    '            End If
    '        End If

    '        If debug Then
    '            If pattern.Substring(pattern.Length - 8) = "debugoff" Then
    '                My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
    '                My.Settings.DebugMode = False
    '                My.Settings.Save()
    '                debug = False
    '                lblDebug.Visible = debug
    '            End If
    '        End If

    '        If hideMe Then
    '            Me.Hide()
    '        Else
    '            Me.Show()
    '        End If

    '        If endMe Then Me.Close()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()
            threadU = New Thread(AddressOf CheckUpdate)
            threadU.Start()
            If Today.Month = 4 AndAlso Today.Day = 1 Then
                MessageBox.Show("Your license has expired. Click Yes to buy a license for 1 month for $100 or 1 year for $1,000. Click No to close this application.", "Initial D Launcher", MessageBoxButtons.YesNo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub AutoCardMove()
        If File.Exists(id6AppData) Then If Not File.Exists(Path.Combine(id6CardDir, "SBUU_card.bin")) Then File.Move(id6AppData, id6CardDir)
        If File.Exists(id6GameDir) Then If Not File.Exists(Path.Combine(id6CardDir, "InidCrd000.crd")) Then File.Move(id6GameDir, id6CardDir)
        If File.Exists(id7AppData) Then If Not File.Exists(Path.Combine(id7CardDir, "SBYD_card.bin")) Then File.Move(id7AppData, id7CardDir)
        If File.Exists(id7GameDir) Then If Not File.Exists(Path.Combine(id7CardDir, "InidCrd000.crd")) Then File.Move(id7GameDir, id7CardDir)
        If File.Exists(id8AppData) Then If Not File.Exists(Path.Combine(id8CardDir, "SBZZ_card.bin")) Then File.Move(id8AppData, id8CardDir)
        If File.Exists(id8GameDir) Then If Not File.Exists(Path.Combine(id8CardDir, "InidCrd000.crd")) Then File.Move(id8GameDir, id8CardDir)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick, Timer4.Tick
        If Me.Enabled Then
            BackgroundImage = gifImage.GetNextFrame()
        End If
    End Sub

    Public Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            lblStart6.Text = ReadCfgValue("Start6", langFile)
            lblStart7.Text = ReadCfgValue("Start7", langFile)
            lblStart8.Text = ReadCfgValue("Start8", langFile)
            lblLeaderboard.Text = ReadCfgValue("Leaderboard", langFile)
            lblCardMan.Text = ReadCfgValue("CardSelection", langFile)
            lblSetting.Text = ReadCfgValue("Settings", langFile)
            lblExit.Text = ReadCfgValue("QuitGame", langFile)
            lblDebug.Text = ReadCfgValue("Debug", langFile)
            lblVersion.Text = String.Format(ReadCfgValue("VersionBuild", langFile), My.Application.Info.Version, buildDate)
            new_version = ReadCfgValue("NewVersion", langFile)
            no_card_selected = ReadCfgValue("NoCardSelected", langFile)
            If Not My.Settings.UserName = "" Then lblLogout.Text = String.Format(ReadCfgValue("Logout", langFile), My.Settings.UserName) Else lblLogout.Text = ReadCfgValue("Login", langFile)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub
End Class
