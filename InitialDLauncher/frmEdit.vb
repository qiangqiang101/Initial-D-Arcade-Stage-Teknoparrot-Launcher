Imports System.IO

Public Class frmEdit

    'Translation
    Dim tool_tip As String

    Private _version As Integer
    Public Property Version() As Integer
        Get
            Return _version
        End Get
        Set(value As Integer)
            _version = value
        End Set
    End Property

    Private _filename As String
    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim newFileName As String = String.Format("{0}\{1}.bak", Path.GetDirectoryName(_filename), Path.GetFileName(_filename))
            File.Copy(_filename, newFileName, True)

            If _version = 6 Then
                If Integer.Parse(txtLevel.Text) > 98 Then txtLevel.Text = "98"
                If Integer.Parse(txtChapLevel.Text) > 99 Then txtChapLevel.Text = "99"
            Else
                If Integer.Parse(txtLevel.Text) > 30 Then txtLevel.Text = "30"
            End If

            If cbAvatar.Checked Then
                If Integer.Parse(txtAcc.Text) > 255 Then txtAcc.Text = "255"
                If Integer.Parse(txtCoat.Text) > 255 Then txtCoat.Text = "255"
                If Integer.Parse(txtEyebrown.Text) > 255 Then txtEyebrown.Text = "255"
                If Integer.Parse(txtEyes.Text) > 255 Then txtEyes.Text = "255"
                If Integer.Parse(txtEyes2.Text) > 255 Then txtEyes2.Text = "255"
                If Integer.Parse(txtHair.Text) > 255 Then txtHair.Text = "255"
                If Integer.Parse(txtTorso.Text) > 255 Then txtTorso.Text = "255"
                If Integer.Parse(txtMouth.Text) > 255 Then txtMouth.Text = "255"
            End If

            If txtName.TextLength <= 5 Then
                Dim amount As Integer = 6 - txtName.TextLength
                Dim newName As Char = Nothing
                Select Case amount
                    Case 1
                        newName = Chr(0)
                    Case 2
                        newName = Chr(0) & Chr(0)
                    Case 3
                        newName = Chr(0) & Chr(0) & Chr(0)
                    Case 4
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 5
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    Case 6
                        newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                End Select
                SetHex(_filename, CLng("&HF0"), SetName(txtName.Text & newName))
            Else
                SetHex(_filename, CLng("&HF0"), SetName(txtName.Text))
            End If

            If GroupBox1.Enabled Then
                If Not cmbCar1.SelectedItem = "" AndAlso cbCar1.Checked Then SetHex(_filename, CLng("&H100"), HexStringToBinary(SetCar(cmbCar1.SelectedItem)))
                If Not cmbCar2.SelectedItem = "" AndAlso cbCar2.Checked Then SetHex(_filename, CLng("&H160"), HexStringToBinary(SetCar(cmbCar2.SelectedItem)))
                If Not cmbCar3.SelectedItem = "" AndAlso cbCar3.Checked Then SetHex(_filename, CLng("&H1C0"), HexStringToBinary(SetCar(cmbCar3.SelectedItem)))

                If cmbGender.SelectedItem = "Female" Then
                    SetHex(_filename, CLng("&H5A"), HexStringToBinary("01"))
                Else
                    SetHex(_filename, CLng("&H5A"), HexStringToBinary("00"))
                End If

                Select Case _version
                    Case 6
                        If cbLegend.Checked Then SetHex(_filename, CLng("&H222"), HexStringToBinary("218F"))
                        SetHex(_filename, CLng("&H224"), SetValue(txtChapLevel.Text))
                        SetHex(_filename, CLng("&HA4"), SetValue(txtLevel.Text))
                        'SetHex(_filename, CLng("&HAD"), SetValue(txtPridePoint.Text))

                        If cbAvatar.Checked Then
                            SetHex(_filename, CLng("&HC4"), SetValue(txtEyebrown.Text))
                            SetHex(_filename, CLng("&HC5"), SetValue(txtTorso.Text))
                            SetHex(_filename, CLng("&HC6"), SetValue(txtCoat.Text))
                            SetHex(_filename, CLng("&HC7"), SetValue(txtEyes.Text))
                            SetHex(_filename, CLng("&HC8"), SetValue(txtEyes2.Text))
                            SetHex(_filename, CLng("&HC9"), SetValue(txtMouth.Text))
                            SetHex(_filename, CLng("&HCA"), SetValue(txtHair.Text))
                            SetHex(_filename, CLng("&HCB"), SetValue(txtAcc.Text))
                        End If
                    Case 7
                        SetHex(_filename, CLng("&HA3"), SetValue(txtLevel.Text))
                        'SetHex(_filename, CLng("&HAA"), SetValue4(txtSPride.Text))
                        'SetHex(_filename, CLng("&HAC"), SetValue4(txtTPride.Text))
                End Select
            End If

            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
        GroupBox1.Enabled = frmLauncher.cheat

        ttCar1.SetToolTip(cbCar1, tool_tip)
        ttCar2.SetToolTip(cbCar2, tool_tip)
        ttCar3.SetToolTip(cbCar3, tool_tip)
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Edit Card: " & Path.GetFileName(_filename)
                Label1.Text = "Name"
                Label2.Text = "Gender"
                Label6.Text = "Level"
                Label7.Text = "Pride Point"
                Label8.Text = "Chapter Level"
                Label3.Text = "Car 1"
                Label4.Text = "Car 2"
                Label5.Text = "Car 3"
                cbCar1.Text = "Confirm"
                cbCar2.Text = cbCar1.Text
                cbCar3.Text = cbCar1.Text
                cbLegend.Text = "Unlock Legend Chapter"
                btnSave.Text = frmSettings.btnSave.Text
                tool_tip = "Change car might lose ability to tune your car!"
                GroupBox2.Text = "Initial D 6 AA"
                GroupBox3.Text = "Initial D 7 AAX"
                cbAvatar.Text = "Change Avatar (Experimental)"
                GroupBox4.Text = "Avatar"
                Label10.Text = "Eyebrowns"
                Label12.Text = "Torso"
                Label13.Text = "Coat"
                Label14.Text = "Eyes"
                Label17.Text = "Eyes 2"
                Label18.Text = "Mouth"
                Label15.Text = "Hair"
                Label16.Text = "Accessory"
            Case "Chinese"
                Me.Text = "Edit Card: " & Path.GetFileName(_filename)
                Label1.Text = "名字"
                Label2.Text = "性別"
                Label6.Text = "等級"
                Label7.Text = "自豪感點"
                Label8.Text = "章節等級"
                Label3.Text = "車1"
                Label4.Text = "車2"
                Label5.Text = "車3"
                cbCar1.Text = "確認更改"
                cbCar2.Text = cbCar1.Text
                cbCar3.Text = cbCar1.Text
                cbLegend.Text = "解鎖傳說章節"
                btnSave.Text = frmSettings.btnSave.Text
                tool_tip = "更換車可能會失去改車功能！"
                GroupBox2.Text = "頭文字D6AA"
                GroupBox3.Text = "頭文字D7AAX"
                cbAvatar.Text = "更換頭像 (試驗)"
                GroupBox4.Text = "頭像"
                Label10.Text = "眉毛"
                Label12.Text = "上衣"
                Label13.Text = "外套"
                Label14.Text = "眼睛"
                Label17.Text = "眼睛2"
                Label18.Text = "嘴巴"
                Label15.Text = "髮型"
                Label16.Text = "配件"
            Case "French"
                Me.Text = "Edit Card: " & Path.GetFileName(_filename)
                Label1.Text = "Nom"
                Label2.Text = "Genre"
                Label6.Text = "Niveau"
                Label7.Text = "Pride Point"
                Label8.Text = "Niveau du chapitre"
                Label3.Text = "Car 1"
                Label4.Text = "Car 2"
                Label5.Text = "Car 3"
                cbCar1.Text = "Confirmer"
                cbCar2.Text = cbCar1.Text
                cbCar3.Text = cbCar1.Text
                cbLegend.Text = "Unlock Legend Chapter"
                btnSave.Text = frmSettings.btnSave.Text
                tool_tip = "Change car might lose ability to tune your car!"
                GroupBox2.Text = "Initial D 6 AA"
                GroupBox3.Text = "Initial D 7 AAX"
                cbAvatar.Text = "Changer Avatar (Expérimental)"
                GroupBox4.Text = "Avatar"
                Label10.Text = "Les sourcils"
                Label12.Text = "Torse"
                Label13.Text = "Manteau"
                Label14.Text = "Les yeux"
                Label17.Text = "Les yeux 2"
                Label18.Text = "Bouche"
                Label15.Text = "Cheveux"
                Label16.Text = "Accessoire"
        End Select
    End Sub

    Private Sub cbAvatar_CheckedChanged(sender As Object, e As EventArgs) Handles cbAvatar.CheckedChanged
        GroupBox4.Enabled = cbAvatar.Checked
    End Sub

    'Private Sub txtLevel_TextChanged(sender As Object, e As EventArgs) Handles txtLevel.TextChanged, txtChapLevel.TextChanged
    '    If _version = 6 Then
    '        If Integer.Parse(txtLevel.Text) > 98 Then txtLevel.Text = "98"
    '        If Integer.Parse(txtChapLevel.Text) > 99 Then txtChapLevel.Text = "99"
    '    Else
    '        If Integer.Parse(txtLevel.Text) > 30 Then txtLevel.Text = "30"
    '    End If
    'End Sub

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAcc.KeyPress, txtChapLevel.KeyPress, txtCoat.KeyPress, txtEyebrown.KeyPress, txtEyes.KeyPress, txtEyes2.KeyPress, txtHair.KeyPress, txtLevel.KeyPress, txtMouth.KeyPress, txtPridePoint.KeyPress, txtSPride.KeyPress, txtTorso.KeyPress, txtTPride.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Control Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Back Then
                Return
            End If
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Private Sub txtEyebrown_TextChanged(sender As Object, e As EventArgs) Handles txtEyebrown.TextChanged, txtAcc.TextChanged, txtCoat.TextChanged, txtEyes.TextChanged, txtEyes2.TextChanged, txtHair.TextChanged, txtMouth.TextChanged, txtTorso.TextChanged
    '    If Integer.Parse(txtAcc.Text) > 255 Then txtAcc.Text = "255"
    '    If Integer.Parse(txtCoat.Text) > 255 Then txtCoat.Text = "255"
    '    If Integer.Parse(txtEyebrown.Text) > 255 Then txtEyebrown.Text = "255"
    '    If Integer.Parse(txtEyes.Text) > 255 Then txtEyes.Text = "255"
    '    If Integer.Parse(txtEyes2.Text) > 255 Then txtEyes2.Text = "255"
    '    If Integer.Parse(txtHair.Text) > 255 Then txtHair.Text = "255"
    '    If Integer.Parse(txtTorso.Text) > 255 Then txtTorso.Text = "255"
    '    If Integer.Parse(txtMouth.Text) > 255 Then txtMouth.Text = "255"
    'End Sub
End Class