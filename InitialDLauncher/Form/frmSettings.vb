Imports System.IO
Imports System.Net

Public Class frmSettings

    Dim pattern As String
    Dim gotError As Boolean = False

    'Translate
    Dim no_exe, no_name, name_is_taken, name_is_available, tp_version As String

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            For Each file As String In IO.Directory.GetFiles(String.Format("{0}\Languages", My.Application.Info.DirectoryPath), "*.ini")
                cmbLang.Items.Add(IO.Path.GetFileNameWithoutExtension(file))
            Next

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
            cbVideo.Checked = My.Settings.VideoBackground
            cbPicodaemon.Checked = My.Settings.RunCardReader
            cbFullScreen.Checked = My.Settings.FullScreen
            If My.Settings.ExtraLaunchOptions.Contains(",") Then
                For Each item In My.Settings.ExtraLaunchOptions.Split(",")
                    lvELO.AddItem(item)
                Next
            End If

            Translate()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txt6.Text.Contains(".exe") Then
                NSMessageBox.ShowOk(no_exe, MsgBoxStyle.Critical, "Error")
                txt6.Focus()
            ElseIf txt7.Text.Contains(".exe") Then
                NSMessageBox.ShowOk(no_exe, MsgBoxStyle.Critical, "Error")
                txt7.Focus()
                'ElseIf txtPlayerName.Text = Nothing Then
                '    NSMessageBox.ShowOk(no_name, MsgBoxStyle.Critical, "Error")
                '    txtPlayerName.Focus()
            ElseIf txt8.Text.Contains(".exe") Then
                NSMessageBox.ShowOk(no_exe, MsgBoxStyle.Critical, "Error")
                txt8.Focus()
            ElseIf cmbLang.SelectedItem = Nothing Then
                NSMessageBox.ShowOk("Please select language!", MsgBoxStyle.Critical, "Error")
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
                My.Settings.VideoBackground = cbVideo.Checked
                My.Settings.RunCardReader = cbPicodaemon.Checked
                My.Settings.FullScreen = cbFullScreen.Checked
                If Not lvELO.Items.Count = 0 Then
                    Dim array As String = Nothing
                    For Each item As NSListView.NSListViewItem In lvELO.Items
                        array = array & item.Text & ","
                    Next
                    array = array.Trim().Remove(array.Length - 1)
                    My.Settings.ExtraLaunchOptions = array
                End If
                My.Settings.Save()

                frmLauncher.id6GameDir = Path.Combine(My.Settings.Id6Path, "InidCrd000.crd")
                frmLauncher.id7GameDir = Path.Combine(My.Settings.Id7Path, "InidCrd000.crd")
                frmLauncher.id8GameDir = Path.Combine(My.Settings.Id8Path, "InidCrd000.crd")

                frmLauncher.lblDebug.Visible = cbDebug.Checked
                frmLauncher.Translate()
                If Not gotError Then Me.Close()

                If Not My.Settings.VideoBackground Then
                    frmLauncher.Timer3.Stop()
                    frmLauncher.BackgroundImage = My.Resources.new_bg
                Else
                    frmLauncher.Timer3.Start()
                End If
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
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
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Me.Text = ReadCfgValue("SettingsMeText", langFile)
            NsTheme1.Text = Me.Text
            Label1.Text = ReadCfgValue("Path6", langFile)
            Label2.Text = ReadCfgValue("Path7", langFile)
            Label4.Text = ReadCfgValue("Path8", langFile)
            cbTest.Text = ReadCfgValue("TestMenu", langFile)
            cbDebug.Text = ReadCfgValue("DebugMode", langFile)
            Label21.Text = ReadCfgValue("Language", langFile)
            btnSave.Text = ReadCfgValue("Save", langFile)
            no_exe = ReadCfgValue("NoExe", langFile)
            no_name = ReadCfgValue("NoName", langFile)
            name_is_taken = ReadCfgValue("NameIsTaken", langFile)
            name_is_available = ReadCfgValue("NameIsAvail", langFile)
            Label22.Text = ReadCfgValue("UserName", langFile)
            Label23.Text = ReadCfgValue("Country", langFile)
            cbMP.Text = ReadCfgValue("Multiplayer", langFile)
            Label3.Text = ReadCfgValue("CardPrefer", langFile)
            cbPicodaemon.Text = ReadCfgValue("Picodaemon", langFile)
            cbVideo.Text = ReadCfgValue("Video", langFile)
            cbFullScreen.Text = ReadCfgValue("FullScreen", langFile)
            tp_version = ReadCfgValue("TPVersion", langFile)
            NsGroupBox1.Title = ReadCfgValue("ExtraLaunchOptions", langFile)
            lvELO.Columns(0).Text = ReadCfgValue("ELPrograms", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub


    Dim UpdateUserCountryURL As String = "http://id.imnotmental.com/SetUserCountry.php?"

    Private Sub btnBrowse6_Click(sender As Object, e As EventArgs) Handles btnBrowse6.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "EXE files (*.exe)|*.exe"
        ofd.Title = Label1.Text
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.InitialDirectory = My.Application.Info.DirectoryPath
        If ofd.ShowDialog() = DialogResult.OK Then
            txt6.Text = Path.GetDirectoryName(ofd.FileName)
        End If
    End Sub

    Private Sub btnBrowse7_Click(sender As Object, e As EventArgs) Handles btnBrowse7.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "EXE files (*.exe)|*.exe"
        ofd.Title = Label2.Text
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.InitialDirectory = My.Application.Info.DirectoryPath
        If ofd.ShowDialog() = DialogResult.OK Then
            txt7.Text = Path.GetDirectoryName(ofd.FileName)
        End If
    End Sub

    Private Sub btnBrowse8_Click(sender As Object, e As EventArgs) Handles btnBrowse8.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "EXE files (*.exe)|*.exe"
        ofd.Title = Label4.Text
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.InitialDirectory = My.Application.Info.DirectoryPath
        If ofd.ShowDialog() = DialogResult.OK Then
            txt8.Text = Path.GetDirectoryName(ofd.FileName)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "EXE files (*.exe)|*.exe"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.InitialDirectory = My.Application.Info.DirectoryPath
        If ofd.ShowDialog() = DialogResult.OK Then
            lvELO.AddItem(ofd.FileName)
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If Not lvELO.SelectedItems(0) Is Nothing Then
            lvELO.RemoveItem(lvELO.SelectedItems(0))
        End If
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub cbPicodaemon_CheckedChanged(sender As Object) Handles cbPicodaemon.CheckedChanged
        If cbPicodaemon.Checked = True Then
            Dim result As Integer = NSMessageBox.ShowYesNo(tp_version, Text)
            If result = DialogResult.Yes Then
                cbPicodaemon.Checked = False
            End If
        End If
    End Sub

    Dim UpdateUserCountryURLCN As String = "http://www.emulot.cn/id/SetUserCountry.php?"
    Private Sub UpdateUserCountry()
        Try
            Dim client As WebClientEx = New WebClientEx() With {.Timeout = 10000}
            client.DownloadString(Convert.ToString(UpdateUserCountryURL + "userEmail=" & My.Settings.UserEmail & "&userCountry=" & cmbCountry.SelectedItem.ToString))
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmSettings_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub
End Class