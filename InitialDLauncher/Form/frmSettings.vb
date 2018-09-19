Imports System.IO

Public Class frmSettings

    Dim gotError As Boolean = False

    Dim id6XmlFile As String = ".\UserProfiles\ID6.xml"
    Dim id7XmlFile As String = ".\UserProfiles\ID7.xml"
    Dim id8XmlFile As String = ".\UserProfiles\ID8.xml"
    Dim parrotDataFile As String = ".\ParrotData.xml"
    Public Shared pluginControls As New List(Of Control)

    'Translate
    Dim no_exe, no_name, name_is_taken, name_is_available, tp_version, save_haptic, no_haptic, restart_require As String

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each file As String In IO.Directory.GetFiles(String.Format("{0}\Languages", My.Application.Info.DirectoryPath), "*.ini")
                cmbLang.Items.Add(IO.Path.GetFileNameWithoutExtension(file))
            Next

            Translate()

            If File.Exists(id6XmlFile) Then ReadXml(id6XmlFile, txt6, flp6.FP)
            If File.Exists(id7XmlFile) Then ReadXml(id7XmlFile, txt7, flp7.FP)
            If File.Exists(id8XmlFile) Then ReadXml(id8XmlFile, txt8, flp8.FP)
            If File.Exists(parrotDataFile) Then ReadParrotData()

            txtPlayerName.Text = My.Settings.UserName
            cbTest.Checked = My.Settings.TestMode
            cbDebug.Checked = My.Settings.DebugMode
            cbMP.Checked = My.Settings.Multiplayer
            cmbLang.SelectedItem = My.Settings.Language
            cmbCountry.SelectedItem = My.Settings.UserCountry
            cbPicodaemon.Checked = My.Settings.RunCardReader
            cbFullScreen.Checked = My.Settings.FullScreen
            If File.Exists(SBUU_e2prom) Then cmbSeat6.SelectedItem = GetSeatName(GetHex(SBUU_e2prom, &H2B, 1))
            If File.Exists(SBYD_e2prom) Then cmbSeat7.SelectedItem = GetSeatName(GetHex(SBYD_e2prom, &H2B, 1))
            If File.Exists(SBZZ_e2prom) Then cmbSeat8.SelectedItem = GetSeatName(GetHex(SBZZ_e2prom, &H2B, 1))

            If My.Settings.ExtraLaunchOptions.Contains(";") Then
                For Each item In My.Settings.ExtraLaunchOptions.Split(",")
                    lvELO.AddItem(item.Replace(";", ""))
                Next
            End If

            cmbHapticDevice.SelectedIndex = 0

            For Each ctrl In pluginControls
                pPluginSettings.Controls.Add(ctrl)
            Next
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If File.Exists(parrotDataFile) Then WriteParrotData()
            If File.Exists(id6XmlFile) AndAlso Not String.IsNullOrWhiteSpace(txt6.Text) Then WriteXml(id6XmlFile, flp6.FP, txt6, 6)
            If File.Exists(id7XmlFile) AndAlso Not String.IsNullOrWhiteSpace(txt7.Text) Then WriteXml(id7XmlFile, flp7.FP, txt7, 7)
            If File.Exists(id8XmlFile) AndAlso Not String.IsNullOrWhiteSpace(txt8.Text) Then WriteXml(id8XmlFile, flp8.FP, txt8, 8)

            If cmbLang.SelectedItem = Nothing Then
                NSMessageBox.ShowOk("Please select language!", MsgBoxStyle.Critical, "Error")
            Else
                If File.Exists(SBUU_e2prom) Then SetSeatName(cmbSeat6.SelectedItem, SBUU_e2prom)
                If File.Exists(SBYD_e2prom) Then SetSeatName(cmbSeat7.SelectedItem, SBYD_e2prom)
                If File.Exists(SBZZ_e2prom) Then SetSeatName(cmbSeat8.SelectedItem, SBZZ_e2prom)
                If Not txtPlayerName.Text = "" Then If My.Settings.UserCountry <> cmbCountry.SelectedItem.ToString Then UpdateUserCountry()
                My.Settings.UserName = txtPlayerName.Text
                My.Settings.TestMode = cbTest.Checked
                My.Settings.DebugMode = cbDebug.Checked
                My.Settings.Multiplayer = cbMP.Checked
                My.Settings.Language = cmbLang.SelectedItem
                My.Settings.UserCountry = cmbCountry.SelectedItem
                My.Settings.RunCardReader = cbPicodaemon.Checked
                My.Settings.FullScreen = cbFullScreen.Checked
                If lvELO.Items.Count = 0 Then
                    My.Settings.ExtraLaunchOptions = ""
                Else
                    Dim array As String = Nothing
                    For Each item As NSListView.NSListViewItem In lvELO.Items
                        array = array & item.Text & ","
                    Next
                    Dim lastChar As String = array.Substring(array.Length - 1)
                    array = array.Substring(0, array.Length - 1) & ";"c 'Replace(lastChar, ";")
                    My.Settings.ExtraLaunchOptions = array
                End If
                My.Settings.Save()

                frmLauncher.id6GameDir = Path.Combine(My.Settings.Id6Path, "InidCrd000.crd")
                frmLauncher.id7GameDir = Path.Combine(My.Settings.Id7Path, "InidCrd000.crd")
                frmLauncher.id8GameDir = Path.Combine(My.Settings.Id8Path, "InidCrd000.crd")

                frmLauncher.lblDebug.Visible = cbDebug.Checked
                frmLauncher.Translate()
                If Not gotError Then Me.Close()
            End If

            NSMessageBox.ShowOk(restart_require, MessageBoxIcon.Exclamation, Text)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
            Exit Sub
        End Try
    End Sub

    Private Sub frmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
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
            cbPicodaemon.Text = ReadCfgValue("Picodaemon", langFile)
            cbFullScreen.Text = ReadCfgValue("FullScreen", langFile)
            tp_version = ReadCfgValue("TPVersion", langFile)
            NsGroupBox1.Title = ReadCfgValue("ExtraLaunchOptions", langFile)
            lvELO.Columns(0).Text = ReadCfgValue("ELPrograms", langFile)
            tpLauncher.Text = ReadCfgValue("ThisLauncher", langFile)
            tpId6.Text = ReadCfgValue("ID6Settings", langFile)
            tpId7.Text = ReadCfgValue("ID7Settings", langFile)
            tpId8.Text = ReadCfgValue("ID8Settings", langFile)
            tpTPEmu.Text = ReadCfgValue("TPEmulation", langFile)
            Label5.Text = ReadCfgValue("JoystickInterface", langFile)
            NsGroupBox2.Title = ReadCfgValue("Sto0zZone", langFile)
            Label6.Text = ReadCfgValue("Sto0zPercent", langFile)
            cbSto0z.Text = ReadCfgValue("Sto0zEnable", langFile)
            NsGroupBox4.Title = ReadCfgValue("DirectInputWheel", langFile)
            cbFullAxisGas.Text = ReadCfgValue("FullAG", langFile)
            cbFullAxisBrake.Text = ReadCfgValue("FullAB", langFile)
            cbReverseAxisGas.Text = ReadCfgValue("ReverseAG", langFile)
            cbReverseAxisBrake.Text = ReadCfgValue("ReverseAB", langFile)
            NsGroupBox5.Title = ReadCfgValue("ForceFB", langFile)
            cbUseFFB.Text = ReadCfgValue("FFBEnable", langFile)
            cbThrustmaster.Text = ReadCfgValue("Thrustmaster", langFile)
            btnRefreshHaptic.Text = ReadCfgValue("RefreshHaptic", langFile)
            Label9.Text = ReadCfgValue("HapticDevice", langFile)
            save_haptic = ReadCfgValue("SavedHaptic", langFile)
            no_haptic = ReadCfgValue("NoHaptic", langFile)
            Label10.Text = ReadCfgValue("SineBase", langFile)
            Label11.Text = ReadCfgValue("SpringBase", langFile)
            Label12.Text = ReadCfgValue("FrictionBase", langFile)
            Label13.Text = ReadCfgValue("ConstantBase", langFile)
            restart_require = ReadCfgValue("RestartRequire", langFile)
            Label3.Text = ReadCfgValue("SeatNumber", langFile)
            Label7.Text = ReadCfgValue("SeatNumber", langFile)
            Label8.Text = ReadCfgValue("SeatNumber", langFile)
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
            'txt6.Text = Path.GetDirectoryName(ofd.FileName)
            txt6.Text = ofd.FileName
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
            'txt7.Text = Path.GetDirectoryName(ofd.FileName)
            txt7.Text = ofd.FileName
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
            'txt8.Text = Path.GetDirectoryName(ofd.FileName)
            txt8.Text = ofd.FileName
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
        If Not lvELO.SelectedItems.Count = 0 Then
            lvELO.RemoveItem(lvELO.SelectedItems(0))
        End If
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

    Private Sub tbSto0z_Scroll(sender As Object) Handles tbSto0z.Scroll
        lblSto0zPercent.Text = $"{tbSto0z.Value}%"
    End Sub

    Private Sub btnRefreshHaptic_Click(sender As Object, e As EventArgs) Handles btnRefreshHaptic.Click
        Dim xml As ParrotData = New ParrotData(parrotDataFile)
        xml = xml.ReadFromFile()

        cmbHapticDevice.Items.Clear()
        If Not String.IsNullOrWhiteSpace(xml.HapticDevice) Then cmbHapticDevice.Items.Add(CreateJoystickItem(xml.HapticDevice, save_haptic))
        cmbHapticDevice.Items.Add(CreateJoystickItem("", no_haptic))
        Dim joysticks = ForceFeedbackJesus.BasicInformation.GetHapticDevices()
        For Each joystickProfile In joysticks
            cmbHapticDevice.Items.Add(CreateJoystickItem(joystickProfile))
        Next
        cmbHapticDevice.SelectedIndex = 0
    End Sub

    Private Function CreateJoystickItem(joystickName As String, Optional extraSting As String = "") As ComboboxItem
        Dim content As String
        If String.IsNullOrWhiteSpace(joystickName) AndAlso Not extraSting = "" Then
            content = extraSting
        ElseIf String.IsNullOrWhiteSpace(extraSting) AndAlso Not joystickName = "" Then
            content = joystickName
        Else
            content = $"{joystickName} - {extraSting}"
        End If
        Return New ComboboxItem() With {.Text = content, .Value = joystickName}
    End Function

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

    Private Sub ReadXml(xmlFile As String, gamePathTB As NSTextBox, gameFLP As FlowLayoutPanel)
        Try
            Dim xml As GameProfile = New GameProfile(xmlFile).ReadFromFile
            Dim item As FieldInformationItem

            gamePathTB.Text = xml.GamePath
            For Each cv As FieldInformation In xml.ConfigValues
                item = New FieldInformationItem()
                gameFLP.Controls.Add(item)
                With item
                    .CategoryName = cv.CategoryName
                    .FieldName = cv.FieldName
                    .FieldValue = cv.FieldValue
                    ._FieldType = cv.FieldType
                    Select Case ._FieldType
                        Case "Text"
                            .Type = FieldInformationItem.FieldType.Text
                            .TextField.Text = .FieldValue
                            .TextField.ReadOnly = False
                        Case "Bool"
                            .Type = FieldInformationItem.FieldType.Bool
                            .BoolField.Checked = Convert.ToBoolean(CInt(.FieldValue))
                    End Select
                    .LabelText.Text = $"{ .CategoryName} - { .FieldName}"
                End With
            Next
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub WriteXml(fileName As String, flp As FlowLayoutPanel, gamePathTB As NSTextBox, gameVersion As Integer)
        Dim xml As GameProfile = New GameProfile(fileName).ReadFromFile

        Dim tempFI As New List(Of FieldInformation)
        For Each s As FieldInformationItem In flp.Controls
            Dim fi As New FieldInformation
            With fi
                .CategoryName = s.CategoryName
                .FieldName = s.FieldName
                .FieldType = s._FieldType
                If s._FieldType = "Text" Then
                    .FieldValue = s.TextField.Text
                Else
                    .FieldValue = If(s.BoolField.Checked, 1, 0)
                End If
            End With
            tempFI.Add(fi)
        Next

        Dim gp As New GameProfile(fileName, xml.GameName, gamePathTB.Text, xml.TestMenuParameter, xml.TestMenuIsExecutable, xml.ExtraParameters, xml.TestMenuParameter, xml.IconName, tempFI, xml.JoystickButtons, xml.EmulationProfile, xml.GameProfileRevision, xml.HasSeparateTestMode, xml.Is64Bit)
        gp.Save()

        Select Case gameVersion
            Case 6
                My.Settings.Id6Path = Path.GetDirectoryName(xml.GamePath)
                My.Settings.PerferCardExt6 = If(xml.ConfigValues(5).FieldValue = 0, "BIN", "CRD")
            Case 7
                My.Settings.Id7Path = Path.GetDirectoryName(xml.GamePath)
                My.Settings.PerferCardExt7 = If(xml.ConfigValues(5).FieldValue = 0, "BIN", "CRD")
            Case 8
                My.Settings.Id8Path = Path.GetDirectoryName(xml.GamePath)
                My.Settings.PerferCardExt8 = "BIN"
        End Select
        My.Settings.Save()
    End Sub

    Private Sub ReadParrotData()
        Try
            Dim xml As ParrotData = New ParrotData(parrotDataFile).ReadFromFile

            cmbJoyInterface.SelectedIndex = If(xml.XInputMode, 1, 0)
            cbSto0z.Checked = xml.UseSto0ZDrivingHack
            tbSto0z.Value = xml.StoozPercent
            cbFullAxisGas.Checked = xml.FullAxisGas
            cbFullAxisBrake.Checked = xml.FullAxisBrake
            cbReverseAxisGas.Checked = xml.ReverseAxisGas
            cbReverseAxisBrake.Checked = xml.ReverseAxisBrake
            cbUseFFB.Checked = xml.UseHaptic
            cbThrustmaster.Checked = xml.HapticThrustmasterFix
            txtSine.Text = xml.SineBase
            txtFriction.Text = xml.FrictionBase
            txtSpring.Text = xml.SpringBase
            txtConstant.Text = xml.ConstantBase
            Dim haptic As String = xml.HapticDevice
            If Not String.IsNullOrWhiteSpace(xml.HapticDevice) Then cmbHapticDevice.Items.Add(CreateJoystickItem(xml.HapticDevice, save_haptic))
            cmbHapticDevice.Items.Add(CreateJoystickItem("", no_haptic))
            Dim joysticks = ForceFeedbackJesus.BasicInformation.GetHapticDevices()
            For Each joystickProfile In joysticks
                cmbHapticDevice.Items.Add(CreateJoystickItem(joystickProfile))
            Next
            cmbHapticDevice.SelectedItem = 0

        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConstant.KeyPress, txtFriction.KeyPress, txtSine.KeyPress, txtSpring.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Control Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Back Then
                Return
            End If
            e.Handled = True
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub WriteParrotData()
        Dim xml As ParrotData = New ParrotData(parrotDataFile).ReadFromFile

        Dim pd As New ParrotData()
        With pd
            .XMLFileName = parrotDataFile
            .UseMouse = xml.UseMouse
            .XInputMode = If(cmbJoyInterface.SelectedIndex = 1, True, False)
            .UseSto0ZDrivingHack = cbSto0z.Checked
            .StoozPercent = tbSto0z.Value
            .GunSensitivityPlayer1 = xml.GunSensitivityPlayer1
            .GunSensitivityPlayer2 = xml.GunSensitivityPlayer2
            .FullAxisGas = cbFullAxisGas.Checked
            .FullAxisBrake = cbFullAxisBrake.Checked
            .ReverseAxisGas = cbReverseAxisGas.Checked
            .ReverseAxisBrake = cbReverseAxisBrake.Checked
            .UseHaptic = cbUseFFB.Checked
            .HapticThrustmasterFix = cbThrustmaster.Checked
            .SineBase = txtSine.Text
            .FrictionBase = txtFriction.Text
            .SpringBase = txtSpring.Text
            .ConstantBase = txtConstant.Text
            Dim hd As ComboboxItem = cmbHapticDevice.SelectedItem
            .HapticDevice = hd.Value.ToString
        End With
        pd.Save()
    End Sub
End Class