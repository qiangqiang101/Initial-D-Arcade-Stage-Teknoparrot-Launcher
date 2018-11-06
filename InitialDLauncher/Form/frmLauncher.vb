Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Windows
Imports PluginContract

Public Class frmLauncher

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public WithEvents proc As Process
    Dim debug As Boolean = My.Settings.DebugMode
    Dim threadU As Thread
    Public Shared RunGameThread As Thread
    Public shadow As Dropshadow
    Dim curVer As Integer = 48
    Public buildDate As String = "06/11/2018"

    Dim id4AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBML_card.bin")
    Dim id4eAppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBNK_card.bin")
    Dim id5AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBQZ_card.bin")
    Dim id6AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBUU_card.bin")
    Dim id7AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBYD_card.bin")
    Dim id8AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBZZ_card.bin")
    Dim AppDataDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot")

    Public Shared id4GameDir As String = Path.Combine(My.Settings.Id4Path, "InidCrd000.crd")
    Public Shared id4eGameDir As String = Path.Combine(My.Settings.Id4ePath, "InidCrd000.crd")
    Public Shared id5GameDir As String = Path.Combine(My.Settings.Id5Path, "InidCrd000.crd")
    Public Shared id6GameDir As String = Path.Combine(My.Settings.Id6Path, "InidCrd000.crd")
    Public Shared id7GameDir As String = Path.Combine(My.Settings.Id7Path, "InidCrd000.crd")
    Public Shared id8GameDir As String = Path.Combine(My.Settings.Id8Path, "InidCrd000.crd")
    Public id4CardPath As String = My.Settings.Id4CardName
    Public id4eCardPath As String = My.Settings.Id4eCardName
    Public id5CardPath As String = My.Settings.Id5CardName
    Public id6CardPath As String = My.Settings.Id6CardName
    Public id7CardPath As String = My.Settings.Id7CardName
    Public id8CardPath As String = My.Settings.Id8CardName
    Dim id4CardDir As String = String.Format("{0}\ID4_CARD\", My.Application.Info.DirectoryPath)
    Dim id4eCardDir As String = String.Format("{0}\ID4E_CARD\", My.Application.Info.DirectoryPath)
    Dim id5CardDir As String = String.Format("{0}\ID5_CARD\", My.Application.Info.DirectoryPath)
    Dim id6CardDir As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardDir As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)
    Dim id8CardDir As String = String.Format("{0}\ID8_CARD\", My.Application.Info.DirectoryPath)
    Public Shared parrotData As ParrotData = New ParrotData(".\ParrotData.xml").ReadFromFile

    Public Shared selPath As String = Nothing
    Public Shared lastGame As Integer = 0
    Public Shared isGameRunning As Boolean = False
    Public Shared pluginControls As New List(Of Control)
    Public plugins As ICollection(Of iPlugin) = PluginLoader.LoadPlugins("Plugins\IDAS")

    'Translation
    Dim new_version, no_card_selected, not_available_edit As String

    Private Sub frmLauncher_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmLauncher_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmLauncher_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
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
            Dim file As String = Command$()
            If Not file = "" Then
                file = Replace(file, Chr(34), "")
                CardEditorLoad(file)
                Opacity = 0
                Exit Sub
            End If
            LauncherNormalLoad()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
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
                            'ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 4 Then
                            '    fe.Version = 4
                            '    fe.FileName = ofd.FileName
                            '    fe.Extension = "bin"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = &H4E Then
                            '    fe.Version = &H4E
                            '    fe.FileName = ofd.FileName
                            '    fe.Extension = "bin"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 5 Then
                            '    fe.Version = 5
                            '    fe.FileName = ofd.FileName
                            '    fe.Extension = "bin"
                            '    fe.CardEditOnly = True
                        Else
                            NSMessageBox.ShowOk(not_available_edit, MsgBoxStyle.Critical, "Error")
                        End If
                    Case ".crd"
                        If GetCardVersion(GetHex(ofd.FileName, &H14, 2)) = 7 Then
                            fe.Version = 7
                            fe.FileName = ofd.FileName
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(ofd.FileName, &H14, 2)) = 6 Then
                            fe.Version = 6
                            fe.FileName = ofd.FileName
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(ofd.FileName, &H14, 2)) = 8 Then
                            fe.Version = 8
                            fe.FileName = ofd.FileName
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 4 Then
                            '    fe.Version = 4
                            '    fe.FileName = ofd.FileName
                            '    fe.Extension = "crd"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = &H4E Then
                            '    fe.Version = &H4E
                            '    fe.FileName = ofd.FileName
                            '    fe.Extension = "crd"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(ofd.FileName, &H50, 2)) = 5 Then
                            '    fe.Version = 5
                            '    fe.FileName = ofd.FileName
                            '    fe.Extension = "crd"
                            '    fe.CardEditOnly = True
                        Else
                            NSMessageBox.ShowOk(not_available_edit, MsgBoxStyle.Critical, "Error")
                        End If
                End Select
                fe.ShowDialog()
                fe.BringToFront()
            Else
                End
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            End
        End Try
    End Sub

    Private Sub CardEditorLoad(CardFile As String)
        Try
            Dim fe As frmEdit = New frmEdit()
            If Not CardFile = Nothing Then
                Select Case Path.GetExtension(CardFile)
                    Case ".bin"
                        If GetCardVersion(GetHex(CardFile, &H50, 2)) = 7 Then
                            fe.Version = 7
                            fe.FileName = CardFile
                            fe.Extension = "bin"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = 6 Then
                            fe.Version = 6
                            fe.FileName = CardFile
                            fe.Extension = "bin"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = 8 Then
                            fe.Version = 8
                            fe.FileName = CardFile
                            fe.Extension = "bin"
                            fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = 4 Then
                            '    fe.Version = 4
                            '    fe.FileName = CardFile
                            '    fe.Extension = "bin"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = &H4E Then
                            '    fe.Version = &H4E
                            '    fe.FileName = CardFile
                            '    fe.Extension = "bin"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = 5 Then
                            '    fe.Version = 5
                            '    fe.FileName = CardFile
                            '    fe.Extension = "bin"
                            '    fe.CardEditOnly = True
                        Else
                            NSMessageBox.ShowOk(not_available_edit, MsgBoxStyle.Critical, "Error")
                        End If
                    Case ".crd"
                        If GetCardVersion(GetHex(CardFile, &H14, 2)) = 7 Then
                            fe.Version = 7
                            fe.FileName = CardFile
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(CardFile, &H14, 2)) = 6 Then
                            fe.Version = 6
                            fe.FileName = CardFile
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                        ElseIf GetCardVersion(GetHex(CardFile, &H14, 2)) = 8 Then
                            fe.Version = 8
                            fe.FileName = CardFile
                            fe.Extension = "crd"
                            fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = 4 Then
                            '    fe.Version = 4
                            '    fe.FileName = CardFile
                            '    fe.Extension = "crd"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = &H4E Then
                            '    fe.Version = &H4E
                            '    fe.FileName = CardFile
                            '    fe.Extension = "crd"
                            '    fe.CardEditOnly = True
                            'ElseIf GetCardVersion(GetHex(CardFile, &H50, 2)) = 5 Then
                            '    fe.Version = 5
                            '    fe.FileName = CardFile
                            '    fe.Extension = "crd"
                            '    fe.CardEditOnly = True
                        Else
                            NSMessageBox.ShowOk(not_available_edit, MsgBoxStyle.Critical, "Error")
                        End If
                End Select
                fe.ShowDialog()
                fe.BringToFront()
            Else
                End
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            End
        End Try
    End Sub

    Private Sub LauncherNormalLoad()
        Try
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.UserPaint, True)

            If Not Directory.Exists(id4CardDir) Then Directory.CreateDirectory(id4CardDir)
            If Not Directory.Exists(id4eCardDir) Then Directory.CreateDirectory(id4eCardDir)
            If Not Directory.Exists(id5CardDir) Then Directory.CreateDirectory(id5CardDir)
            If Not Directory.Exists(id6CardDir) Then Directory.CreateDirectory(id6CardDir)
            If Not Directory.Exists(id7CardDir) Then Directory.CreateDirectory(id7CardDir)
            If Not Directory.Exists(id8CardDir) Then Directory.CreateDirectory(id8CardDir)
            If Not Directory.Exists(AppDataDir) Then Directory.CreateDirectory(AppDataDir)

            If My.Settings.FullScreen Then
                WindowState = FormWindowState.Maximized
            Else
                WindowState = FormWindowState.Normal
            End If

            shadow = New Dropshadow(Me) With {.ShadowBlur = 30, .ShadowSpread = 1, .ShadowColor = Color.Black}
            shadow.RefreshShadow()

            lblDebug.Visible = debug
            CheckForIllegalCrossThreadCalls = False
            'GetGamePath()

            If Not File.Exists(id4CardPath) Then
                My.Settings.Id4CardName = ""
                My.Settings.Save()
            End If
            If Not File.Exists(id4eCardPath) Then
                My.Settings.Id4eCardName = ""
                My.Settings.Save()
            End If
            If Not File.Exists(id5CardPath) Then
                My.Settings.Id5CardName = ""
                My.Settings.Save()
            End If
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

            If My.Settings.Id4Path = Nothing Then btnStart4.Enabled = False
            If My.Settings.Id4ePath = Nothing Then btnStart4e.Enabled = False
            If My.Settings.Id5Path = Nothing Then btnStart5.Enabled = False
            If My.Settings.Id6Path = Nothing Then btnStart6.Enabled = False
            If My.Settings.Id7Path = Nothing Then btnStart7.Enabled = False
            If My.Settings.Id8Path = Nothing Then btnStart8.Enabled = False

            Translate()

            For Each item In plugins
                item.DoSomething()
                Dim timer As System.Windows.Forms.Timer = New System.Windows.Forms.Timer With {.Interval = 60, .Enabled = True}
                AddHandler timer.Tick, AddressOf item.TimerTick
            Next

            lblStart.Focus()
            Timer1.Start()

            For Each ctrl In pluginControls
                Me.Controls.Add(ctrl)
            Next
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
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
        wait(2000)
        End
    End Sub

    Private Sub RunGame(CardDir As String, CardPath As String, GameID As Integer, AppData As String, MySettingGameDir As String, Profile As String)
        Try
            Dim rd As Random = New Random
            Dim x As Integer = rd.Next(1, 27)
            My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject("Play" & x), AudioPlayMode.Background)

            If Not IsCardFolderEmpty(CardDir) AndAlso CardPath = Nothing Then
                Dim result As DialogResult = NSMessageBox.ShowYesNo(no_card_selected, MessageBoxIcon.Exclamation, Text)
                If result = DialogResult.No Then
                    isGameRunning = False
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    isGameRunning = True
                    If My.Settings.ExtraLaunchOptions.Contains(",") Then
                        For Each item In My.Settings.ExtraLaunchOptions.Split(",")
                            Dim psi = New ProcessStartInfo With {.FileName = "CMD", .Arguments = String.Format("/C start """" ""{0}""", item.Replace(";", "")), .WorkingDirectory = Path.GetDirectoryName(item.Replace(";", "")), .UseShellExecute = True, .CreateNoWindow = False, .WindowStyle = ProcessWindowStyle.Normal}
                            Process.Start(psi)
                        Next
                    End If

                    selPath = CardPath
                    lastGame = GameID
                    Me.WindowState = FormWindowState.Minimized

                    If File.Exists(CardPath) Then If Not File.Exists(AppData) Then File.Move(CardPath, AppData)
                    If IO.Path.GetExtension(AppData) = ".bin" Then If My.Settings.RunCardReader Then RunParrotLoader(String.Format("{0}\picodaemon.exe", MySettingGameDir), False)
                    If My.Settings.Multiplayer Then
                        RunGameThread = New Thread(Sub() RunTeknoParrotOnline(True))
                        RunGameThread.Start()
                    Else
                        RunGameThread = New Thread(Sub() RunParrotLoaderUI(Profile, True, My.Settings.TestMode))
                        RunGameThread.Start()
                    End If
                End If
            Else
                isGameRunning = True
                If My.Settings.ExtraLaunchOptions.Contains(";") Then
                    For Each item In My.Settings.ExtraLaunchOptions.Split(",")
                        Dim psi = New ProcessStartInfo With {.FileName = "CMD", .Arguments = String.Format("/C start """" ""{0}""", item.Replace(";", "")), .WorkingDirectory = Path.GetDirectoryName(item.Replace(";", "")), .UseShellExecute = True, .CreateNoWindow = False, .WindowStyle = ProcessWindowStyle.Normal}
                        Process.Start(psi)
                    Next
                End If

                selPath = CardPath
                lastGame = GameID
                Me.WindowState = FormWindowState.Minimized

                If File.Exists(CardPath) Then If Not File.Exists(AppData) Then File.Move(CardPath, AppData)
                If IO.Path.GetExtension(AppData) = ".bin" Then If My.Settings.RunCardReader Then RunParrotLoader(String.Format("{0}\picodaemon.exe", MySettingGameDir), False)
                If My.Settings.Multiplayer Then
                    RunGameThread = New Thread(Sub() RunTeknoParrotOnline(True))
                    RunGameThread.Start()
                Else
                    RunGameThread = New Thread(Sub() RunParrotLoaderUI(Profile, True, My.Settings.TestMode))
                    RunGameThread.Start()
                End If
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            isGameRunning = False
            Exit Sub
        End Try
    End Sub

    Private Sub QuickScan(CardVersion As Integer)
        Try
            Dim AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot")

            For Each file As String In IO.Directory.GetFiles(AppData, "*.bin")
                Dim fileName As String = file
                Dim fileNameOnly As String = Path.GetFileName(file)
                Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                If GetCardVersion(GetHex(fileName, &H50, 2)) = CardVersion Then
                    If IO.File.Exists(destination) Then
                        IO.File.Delete(destination)
                        IO.File.Move(fileName, destination)
                    Else
                        IO.File.Move(fileName, destination)
                    End If
                End If
            Next

            Select Case CardVersion
                Case 6
                    If Directory.Exists(My.Settings.Id6Path) Then
                        For Each file As String In IO.Directory.GetFiles(My.Settings.Id6Path, "*.crd")
                            Dim fileName As String = file
                            Dim fileNameOnly As String = Path.GetFileName(file)
                            Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                            Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                            If GetCardVersion(GetHex(fileName, &H14, 2)) = 6 Then
                                If IO.File.Exists(destination) Then
                                    IO.File.Delete(destination)
                                    IO.File.Move(fileName, destination)
                                Else
                                    IO.File.Move(fileName, destination)
                                End If
                            End If
                        Next
                    End If
                Case 7
                    If Directory.Exists(My.Settings.Id7Path) Then
                        For Each file As String In IO.Directory.GetFiles(My.Settings.Id7Path, "*.crd")
                            Dim fileName As String = file
                            Dim fileNameOnly As String = Path.GetFileName(file)
                            Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                            Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                            If GetCardVersion(GetHex(fileName, &H14, 2)) = 7 Then
                                If IO.File.Exists(destination) Then
                                    IO.File.Delete(destination)
                                    IO.File.Move(fileName, destination)
                                Else
                                    IO.File.Move(fileName, destination)
                                End If
                            End If
                        Next
                    End If
                Case 8
                    If Directory.Exists(My.Settings.Id8Path) Then
                        For Each file As String In IO.Directory.GetFiles(My.Settings.Id8Path, "*.crd")
                            Dim fileName As String = file
                            Dim fileNameOnly As String = Path.GetFileName(file)
                            Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                            Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                            If GetCardVersion(GetHex(fileName, &H14, 2)) = 8 Then
                                If IO.File.Exists(destination) Then
                                    IO.File.Delete(destination)
                                    IO.File.Move(fileName, destination)
                                Else
                                    IO.File.Move(fileName, destination)
                                End If
                            End If
                        Next
                    End If
            End Select
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnStart6_Click(sender As Object, e As EventArgs) Handles btnStart6.Click, btnStart6.EnterPressed
        wait(500)

        QuickScan(6)
        Select Case IO.Path.GetExtension(My.Settings.Id6CardName)
            Case ".bin"
                RunGame(id6CardDir, id6CardPath, 6, id6AppData, My.Settings.Id6Path, "--profile=ID6.xml")
            Case ".crd"
                RunGame(id6CardDir, id6CardPath, 6, id6GameDir, My.Settings.Id6Path, "--profile=ID6.xml")
            Case Else
                Select Case My.Settings.PerferCardExt6
                    Case "CRD"
                        RunGame(id6CardDir, id6CardPath, 6, id6GameDir, My.Settings.Id6Path, "--profile=ID6.xml")
                    Case "BIN"
                        RunGame(id6CardDir, id6CardPath, 6, id6AppData, My.Settings.Id6Path, "--profile=ID6.xml")
                End Select
        End Select
    End Sub

    Private Sub btnStart7_Click(sender As Object, e As EventArgs) Handles btnStart7.Click, btnStart7.EnterPressed
        wait(500)

        QuickScan(7)
        Select Case IO.Path.GetExtension(My.Settings.Id7CardName)
            Case ".bin"
                RunGame(id7CardDir, id7CardPath, 7, id7AppData, My.Settings.Id7Path, "--profile=ID7.xml")
            Case ".crd"
                RunGame(id7CardDir, id7CardPath, 7, id7GameDir, My.Settings.Id7Path, "--profile=ID7.xml")
            Case Else
                Select Case My.Settings.PerferCardExt7
                    Case "CRD"
                        RunGame(id7CardDir, id7CardPath, 7, id7GameDir, My.Settings.Id7Path, "--profile=ID7.xml")
                    Case "BIN"
                        RunGame(id7CardDir, id7CardPath, 7, id7AppData, My.Settings.Id7Path, "--profile=ID7.xml")
                End Select
        End Select
    End Sub

    Private Sub btnStart8_Click(sender As Object, e As EventArgs) Handles btnStart8.Click, btnStart8.EnterPressed
        wait(500)

        QuickScan(8)
        Select Case IO.Path.GetExtension(My.Settings.Id8CardName)
            Case ".bin"
                RunGame(id8CardDir, id8CardPath, 8, id8AppData, My.Settings.Id8Path, "--profile=ID8.xml")
            Case ".crd"
                RunGame(id8CardDir, id8CardPath, 8, id8GameDir, My.Settings.Id8Path, "--profile=ID8.xml")
            Case Else
                Select Case My.Settings.PerferCardExt8
                    Case "CRD"
                        RunGame(id8CardDir, id8CardPath, 8, id8GameDir, My.Settings.Id8Path, "--profile=ID8.xml")
                    Case "BIN"
                        RunGame(id8CardDir, id8CardPath, 8, id8AppData, My.Settings.Id8Path, "--profile=ID8.xml")
                End Select
        End Select
    End Sub

    Private Sub lblSetting_Click(sender As Object, e As EventArgs) Handles lblSetting.Click, lblSetting.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        If Me.WindowState = FormWindowState.Maximized Then
            frmSettings.TopLevel = False
            Me.Controls.Add(frmSettings)
            frmSettings.Show()
            frmSettings.Focus()
        Else
            frmSettings.Show()
            Me.Enabled = False
        End If
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
        Dim n As String = vbNewLine
        NSMessageBox.ShowOk($"APPDATA PATH{n} ID4: {id4AppData}{n} ID4 EXP: {id4eAppData}{n} ID5: {id5AppData}{n} ID6: {id6AppData}{n} ID7: {id7AppData}{n} ID8: {id8AppData}{n}{n}" &
                            $"GAME DIRECTORY{n} ID4: {id4GameDir}{n} ID4 EXP: {id4eGameDir}{n} ID5: {id5GameDir}{n} ID6: {id6GameDir}{n} ID7: {id7GameDir}{n} ID8: {id8GameDir}", Text)
        NSMessageBox.ShowOk($"CARD FILE PATH{n} ID4: {id4CardPath}{n} ID4 EXP: {id4eCardPath}{n} ID5: {id5CardPath}{n} ID6: {id6CardPath}{n} ID7: {id7CardPath}{n} ID8: {id8CardPath}{n}{n}" &
                            $"GAME PATH{n} ID4: {My.Settings.Id4Path}{n} ID4 EXP: {My.Settings.Id4ePath}{n} ID5: {My.Settings.Id5Path}{n} ID6: {My.Settings.Id6Path}{n} ID7: {My.Settings.Id7Path}{n} ID8: {My.Settings.Id8Path}", Text)
        NSMessageBox.ShowOk($"SELECTED CARD{n} ID4: {My.Settings.Id4CardName}{n} ID4 EXP: {My.Settings.Id4eCardName}{n} ID5: {My.Settings.Id5CardName}{n} ID6: {My.Settings.Id6CardName}{n} ID7: {My.Settings.Id7CardName}{n} ID8: {My.Settings.Id8CardName}{n}{n}" &
                            $"CPU ID: {getNewCPUID()}", Text)
    End Sub

    Private Sub lblCardMan_Click(sender As Object, e As EventArgs) Handles lblCardMan.Click, lblCardMan.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        If Me.WindowState = FormWindowState.Maximized Then
            frmCard.TopLevel = False
            Me.Controls.Add(frmCard)
            frmCard.Show()
            frmCard.Focus()
        Else
            frmCard.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub lblLeaderboard_Click(sender As Object, e As EventArgs) Handles lblLeaderboard.Click, lblLeaderboard.EnterPressed
        My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
        If Me.WindowState = FormWindowState.Maximized Then
            frmLeaderboard.TopLevel = False
            Me.Controls.Add(frmLeaderboard)
            frmLeaderboard.Show()
            frmLeaderboard.Focus()
        Else
            frmLeaderboard.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub RunParrotLoader(ByVal arg As String, wait As Boolean, Optional test As Boolean = False)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = My.Application.Info.DirectoryPath & "\ParrotLoader.exe"
        startInfo.WindowStyle = ProcessWindowStyle.Minimized
        If test Then
            startInfo.Arguments = String.Format("""{0}"" {1}", arg, "-t")
        Else
            startInfo.Arguments = """" & arg & """"
        End If
        proc = Process.Start(startInfo)
        If wait Then
            proc.EnableRaisingEvents = True
            proc.WaitForExit()
            MovingBackCards()
        Else
            proc.EnableRaisingEvents = False
        End If
    End Sub

    Private Sub RunParrotLoaderUI(ByVal arg As String, wait As Boolean, Optional test As Boolean = False)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = My.Application.Info.DirectoryPath & "\TeknoParrotUi.exe"
        startInfo.WindowStyle = ProcessWindowStyle.Minimized
        If test Then
            startInfo.Arguments = String.Format("""{0}"" {1}", arg, "--test")
        Else
            startInfo.Arguments = """" & arg & """"
        End If
        proc = Process.Start(startInfo)
        If wait Then
            proc.EnableRaisingEvents = True
            proc.WaitForExit()
            MovingBackCards()
        Else
            proc.EnableRaisingEvents = False
        End If
    End Sub

    Private Sub RunTeknoParrotOnline(wait As Boolean)
        Process.Start("steam://rungameid/0")
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = My.Application.Info.DirectoryPath & "\TeknoParrotOnline.exe"
        startInfo.WindowStyle = ProcessWindowStyle.Normal
        proc = Process.Start(startInfo)
        If wait Then
            proc.EnableRaisingEvents = True
            proc.WaitForExit()
            MovingBackCards()
        Else
            proc.EnableRaisingEvents = False
        End If
    End Sub

    Private Sub Proc_Exited() Handles proc.Exited
        isGameRunning = False
        Me.Enabled = True
    End Sub

    Private Sub MovingBackCards()
        If My.Settings.FullScreen Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If

        Try
            If selPath = Nothing Then
                Select Case lastGame
                    Case 6
                        If My.Settings.PerferCardExt6 = "CRD" Then
                            selPath = String.Format("{0}\ID6_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id6GameDir) Then File.Move(id6GameDir, selPath)
                        ElseIf My.Settings.PerferCardExt6 = "BIN" Then
                            selPath = String.Format("{0}\ID6_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id6AppData) Then File.Move(id6AppData, selPath)
                        End If
                    Case 7
                        If My.Settings.PerferCardExt7 = "CRD" Then
                            selPath = String.Format("{0}\ID7_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id7GameDir) Then File.Move(id7GameDir, selPath)
                        ElseIf My.Settings.PerferCardExt7 = "BIN" Then
                            selPath = String.Format("{0}\ID7_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id7AppData) Then File.Move(id7AppData, selPath)
                        End If
                    Case 8
                        If My.Settings.PerferCardExt8 = "CRD" Then
                            selPath = String.Format("{0}\ID8_CARD\{1}.crd", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id8GameDir) Then File.Move(id8GameDir, selPath)
                        ElseIf My.Settings.PerferCardExt8 = "BIN" Then
                            selPath = String.Format("{0}\ID8_CARD\{1}.bin", My.Application.Info.DirectoryPath, Guid.NewGuid.ToString())
                            If File.Exists(id8AppData) Then File.Move(id8AppData, selPath)
                        End If
                End Select
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
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click, lblVersion.EnterPressed
        If Me.WindowState = FormWindowState.Maximized Then
            frmAbout.TopLevel = False
            Me.Controls.Add(frmAbout)
            frmAbout.Show()
            frmAbout.Focus()
        Else
            frmAbout.Show()
            Me.Enabled = False
        End If
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

        If Me.WindowState = FormWindowState.Maximized Then
            frmLogin.TopLevel = False
            Me.Controls.Add(frmLogin)
            frmLogin.Show()
            frmLogin.Focus()
        Else
            frmLogin.Show()
            Me.Enabled = False
        End If
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()
            threadU = New Thread(AddressOf CheckUpdate)
            threadU.IsBackground = True
            threadU.Start()
            If Today.Month = 4 AndAlso Today.Day = 1 Then
                NSMessageBox.ShowYesNo("Your license has expired. Click Yes to buy a license for 1 month for $100 or 1 year for $1,000. Click No to close this application.", MessageBoxIcon.Warning, Text)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
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
            If curVer < CheckForUpdate() Then
                Dim result As DialogResult = NSMessageBox.ShowYesNo(new_version, MessageBoxIcon.Exclamation, Text)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    If IsURLValid("https://www.imnotmental.com/tool/initial-d-arcade-stage-launcher-teknoparrot/") Then
                        Process.Start("https://www.imnotmental.com/tool/initial-d-arcade-stage-launcher-teknoparrot/")
                        End
                    Else
                        Process.Start("https://www.patreon.com/posts/initiald-arcade-16661248")
                        End
                    End If
                End If
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Enabled = False
        wait(2000)
        End
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub lblStart_Click(sender As Object, e As EventArgs) Handles lblStart.Click, lblStart.EnterPressed, btnExit2.Click, btnExit2.EnterPressed
        If sender Is lblStart Then My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background) : If Not tcPlay.Visible Then wait(2000)
        tcPlay.Visible = Not tcPlay.Visible
        If tcPlay.Visible Then
            If btnStart4.Enabled Then
                btnStart4.Focus()
            Else
                If btnStart4e.Enabled Then
                    btnStart4e.Focus()
                Else
                    If btnStart5.Enabled Then
                        btnStart5.Focus()
                    Else
                        If btnStart6.Enabled Then
                            btnStart6.Focus()
                        Else
                            If btnStart7.Enabled Then
                                btnStart7.Focus()
                            Else
                                If btnStart8.Enabled Then
                                    btnStart8.Focus()
                                Else
                                    btnExit2.Focus()
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            lblStart.Focus()
        End If
    End Sub

    Private Sub btnStart4_Click(sender As Object, e As EventArgs) Handles btnStart4.Click, btnStart4.EnterPressed
        wait(500)

        QuickScan(4)
        Select Case IO.Path.GetExtension(My.Settings.Id4CardName)
            Case ".bin"
                RunGame(id4CardDir, id4CardPath, 4, id4AppData, My.Settings.Id4Path, "--profile=ID4Jap.xml")
            Case ".crd"
                RunGame(id4CardDir, id4CardPath, 4, id4GameDir, My.Settings.Id4Path, "--profile=ID4Jap.xml")
            Case Else
                Select Case My.Settings.PerferCardExt4
                    Case "CRD"
                        RunGame(id4CardDir, id4CardPath, 4, id4GameDir, My.Settings.Id4Path, "--profile=ID4Jap.xml")
                    Case "BIN"
                        RunGame(id4CardDir, id4CardPath, 6, id4AppData, My.Settings.Id4Path, "--profile=ID4Jap.xml")
                End Select
        End Select
    End Sub

    Private Sub btnStart4e_Click(sender As Object, e As EventArgs) Handles btnStart4e.Click, btnStart4e.EnterPressed
        wait(500)

        QuickScan(&H4E)
        Select Case IO.Path.GetExtension(My.Settings.Id4eCardName)
            Case ".bin"
                RunGame(id4eCardDir, id4eCardPath, &H4E, id4eAppData, My.Settings.Id4ePath, "--profile=ID4Exp.xml")
            Case ".crd"
                RunGame(id4eCardDir, id4eCardPath, &H4E, id4eGameDir, My.Settings.Id4ePath, "--profile=ID4Exp.xml")
            Case Else
                Select Case My.Settings.PerferCardExt4e
                    Case "CRD"
                        RunGame(id4eCardDir, id4eCardPath, &H4E, id4eGameDir, My.Settings.Id4ePath, "--profile=ID4Exp.xml")
                    Case "BIN"
                        RunGame(id4eCardDir, id4eCardPath, &H4E, id4eAppData, My.Settings.Id4ePath, "--profile=ID4Exp.xml")
                End Select
        End Select
    End Sub

    Private Sub btnStart5_Click(sender As Object, e As EventArgs) Handles btnStart5.Click, btnStart5.EnterPressed
        wait(500)

        QuickScan(5)
        Select Case IO.Path.GetExtension(My.Settings.Id5CardName)
            Case ".bin"
                RunGame(id5CardDir, id5CardPath, 5, id5AppData, My.Settings.Id5Path, "--profile=ID5.xml")
            Case ".crd"
                RunGame(id5CardDir, id5CardPath, 5, id5GameDir, My.Settings.Id5Path, "--profile=ID5.xml")
            Case Else
                Select Case My.Settings.PerferCardExt5
                    Case "CRD"
                        RunGame(id5CardDir, id5CardPath, 5, id5GameDir, My.Settings.Id5Path, "--profile=ID5.xml")
                    Case "BIN"
                        RunGame(id5CardDir, id5CardPath, 5, id5AppData, My.Settings.Id5Path, "--profile=ID5.xml")
                End Select
        End Select
    End Sub

    Public Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Text = ReadCfgValue("LauncherTitle", langFile)
            lblStart.Text = ReadCfgValue("StartGame", langFile)
            btnStart4.Text = ReadCfgValue("Start4jp", langFile)
            btnStart4e.Text = ReadCfgValue("Start4exp", langFile)
            btnStart5.Text = ReadCfgValue("Start5", langFile)
            btnStart6.Text = ReadCfgValue("Start6", langFile)
            btnStart7.Text = ReadCfgValue("Start7", langFile)
            btnStart8.Text = ReadCfgValue("Start8", langFile)
            lblLeaderboard.Text = ReadCfgValue("Leaderboard", langFile)
            lblCardMan.Text = ReadCfgValue("CardSelection", langFile)
            lblSetting.Text = ReadCfgValue("Settings", langFile)
            lblExit.Text = ReadCfgValue("QuitGame", langFile)
            lblDebug.Text = ReadCfgValue("Debug", langFile)
            lblVersion.Text = String.Format(ReadCfgValue("VersionBuild", langFile), FileVersionInfo.GetVersionInfo(Forms.Application.ExecutablePath).FileVersion, buildDate)
            new_version = ReadCfgValue("NewVersion", langFile)
            no_card_selected = ReadCfgValue("NoCardSelected", langFile)
            If Not My.Settings.UserName = "" Then lblLogout.Text = String.Format(ReadCfgValue("Logout", langFile), My.Settings.UserName) Else lblLogout.Text = ReadCfgValue("Login", langFile)
            not_available_edit = ReadCfgValue("NotAvailEdit", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub
End Class
