Imports System.IO
Imports Thumbs.InitialD6

Public Class frmEdit

    'Avatar Offsets
    Dim C4 As String = "00"
    Dim C5 As String = "00"
    Dim C6 As String = "00"
    Dim C7 As String = "00"
    Dim C8 As String = "00"
    Dim C9 As String = "00"
    Dim CA As String = "00"
    Dim CB As String = "00"
    Dim CC As String = "00"
    Dim CD As String = "00"
    Dim CE As String = "00"

    'Translation
    Dim tool_tip, mouth_t, eyes_t, face_skin_t, accessories_t, shades_t, hair_t, shirt_t, male, female, coming_soon, must_select_avatar As String

    'Database
    Dim sex As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim category As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim mouth_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim eyes_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim hair_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim skin_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim shirt_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim accessories_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim shades_f As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim mouth_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim eyes_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim hair_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim skin_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim shirt_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim accessories_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)
    Dim shades_m As Dictionary(Of String, Bitmap) = New Dictionary(Of String, Bitmap)

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

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Try
            Select Case cmbAvatarCat.SelectedValue.ToString
                Case "SKIN"
                    lblc4c5.Text = cmbAvatar.SelectedValue.Tag
                    pbSkin.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    Dim C5A = C5.Substring(0, 1)
                    SV = SV.Replace("X", C5A)
                    C4 = FV
                    C5 = SV
                Case "SHIRT"
                    lblc5c6.Text = cmbAvatar.SelectedValue.Tag
                    pbShirt.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '0X
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    '00
                    Dim C5B = C5.Substring(C5.Length - 1)
                    FV = FV.Replace("X", C5B)
                    C5 = FV
                    C6 = SV
                Case "EYES"
                    lblc7c8.Text = cmbAvatar.SelectedValue.Tag
                    pbEyes.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    Dim C8A = C8.Substring(0, 1)
                    SV = SV.Replace("X", C8A)
                    C7 = FV
                    C8 = SV
                Case "MOUTH"
                    lblc8c9.Text = cmbAvatar.SelectedValue.Tag
                    pbMouth.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '0X
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    '00
                    Dim C8B = C8.Substring(C8.Length - 1)
                    FV = FV.Replace("X", C8B)
                    C8 = FV
                    C9 = SV
                Case "ACCESSORIES"
                    lblcacb.Text = cmbAvatar.SelectedValue.Tag
                    pbAccessories.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    Dim CBA = CB.Substring(0, 1)
                    SV = SV.Replace("X", CBA)
                    CA = FV
                    CB = SV
                Case "SHADES"
                    lblcbcc.Text = cmbAvatar.SelectedValue.Tag
                    pbShades.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '0X
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    '00
                    Dim CBB = CB.Substring(CB.Length - 1)
                    FV = FV.Replace("X", CBB)
                    CB = FV
                    CC = SV
                Case "HAIR"
                    lblcdce.Text = cmbAvatar.SelectedValue.Tag
                    pbHair.BackgroundImage = cmbAvatar.SelectedValue
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    SV = SV.Replace("X", "0")
                    CD = FV
                    CE = SV
            End Select

            lblAvatarOffset.Text = C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

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

            If cbSaveAvatar.Checked Then
                SetHex(_filename, CLng("&HC4"), HexStringToBinary(C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE))
                Select Case True
                    Case lblc4c5.Text = "0000", lblc5c6.Text = "0000", lblc7c8.Text = "0000", lblc8c9.Text = "0000", lblcacb.Text = "0000", lblcbcc.Text = "0000", lblcdce.Text = "0000"
                        MsgBox(must_select_avatar, MsgBoxStyle.Critical, "Error")
                        Exit Sub
                End Select
            End If

            If GroupBox1.Enabled Then
                If Not cmbCar1.SelectedItem.ToString = "" AndAlso cbCar1.Checked Then SetHex(_filename, CLng("&H100"), HexStringToBinary(SetCar(cmbCar1.SelectedItem.ToString)))
                If Not cmbCar2.SelectedItem.ToString = "" AndAlso cbCar2.Checked Then SetHex(_filename, CLng("&H160"), HexStringToBinary(SetCar(cmbCar2.SelectedItem.ToString)))
                If Not cmbCar3.SelectedItem.ToString = "" AndAlso cbCar3.Checked Then SetHex(_filename, CLng("&H1C0"), HexStringToBinary(SetCar(cmbCar3.SelectedItem.ToString)))

                If cmbGender.SelectedIndex = 1 Then
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
                    Case 7
                        SetHex(_filename, CLng("&HA3"), SetValue(txtLevel.Text))
                        'SetHex(_filename, CLng("&HAA"), SetValue4(txtSPride.Text))
                        'SetHex(_filename, CLng("&HAC"), SetValue4(txtTPride.Text))
                End Select
            End If

            SetHex(_filename, CLng("&H759"), HexStringToBinary("6564697465647573696E67696461736C61756E63686572")) 'editedusingidaslauncher

            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()

        'Add Gender
        sex.Add(male, "MALE")
        sex.Add(female, "FEMALE")
        cmbGender.DisplayMember = "Key"
        cmbGender.ValueMember = "Value"
        cmbGender.DataSource = New BindingSource(sex, Nothing)
        If GetGender(GetHex(_filename, 90, 1)) = Gender.female Then
            cmbGender.SelectedIndex = 1
        Else
            cmbGender.SelectedIndex = 0
        End If

        GroupBox1.Enabled = frmLauncher.cheat

        ttCar1.SetToolTip(cbCar1, tool_tip)
        ttCar2.SetToolTip(cbCar2, tool_tip)
        ttCar3.SetToolTip(cbCar3, tool_tip)

        If _version = 6 Then
            DictionaryAdd()
            GroupBox4.Enabled = True
        End If

        lblAvatarOffset.Visible = My.Settings.DebugMode
        lblc4c5.Visible = My.Settings.DebugMode
        lblc5c6.Visible = My.Settings.DebugMode
        lblc7c8.Visible = My.Settings.DebugMode
        lblc8c9.Visible = My.Settings.DebugMode
        lblcacb.Visible = My.Settings.DebugMode
        lblcbcc.Visible = My.Settings.DebugMode
        lblcdce.Visible = My.Settings.DebugMode

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
                btnSave.Text = "Save"
                tool_tip = "Change car might lose ability to tune your car!"
                GroupBox1.Text = "Cheat"
                GroupBox2.Text = "Initial D 6 AA"
                GroupBox3.Text = "Initial D 7 AAX"
                GroupBox4.Text = "Avatar"
                Label10.Text = "Category"
                Label12.Text = "Selection"
                mouth_t = "Mouth"
                eyes_t = "Eyes"
                face_skin_t = "Face and Skin"
                accessories_t = "Accessories"
                shades_t = "Specs"
                hair_t = "Hair"
                shirt_t = "Shirt"
                gbMouth.Text = mouth_t
                gbEyes.Text = eyes_t
                gbSkin.Text = face_skin_t
                gbAccessories.Text = accessories_t
                gbShades.Text = shades_t
                gbHair.Text = hair_t
                gbShirt.Text = shirt_t
                male = "Male"
                female = "Female"
                btnSet.Text = "Apply"
                GroupBox5.Text = "Basic"
                cbSaveAvatar.Text = "Save" & vbNewLine & "Avatar"
                coming_soon = "Coming Soon"
                must_select_avatar = "Avatar cannot be blank."
            Case "Chinese"
                Me.Text = "改卡: " & Path.GetFileName(_filename)
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
                btnSave.Text = "保存"
                tool_tip = "更換車可能會失去改車功能！"
                GroupBox1.Text = "作弊"
                GroupBox2.Text = "頭文字D6AA"
                GroupBox3.Text = "頭文字D7AAX"
                GroupBox4.Text = "頭像"
                Label10.Text = "類型"
                Label12.Text = "選項"
                mouth_t = "嘴巴"
                eyes_t = "眼睛"
                face_skin_t = "臉與膚色"
                accessories_t = "配飾"
                shades_t = "眼鏡"
                hair_t = "頭髮"
                shirt_t = "上衣"
                gbMouth.Text = mouth_t
                gbEyes.Text = eyes_t
                gbSkin.Text = face_skin_t
                gbAccessories.Text = accessories_t
                gbShades.Text = shades_t
                gbHair.Text = hair_t
                gbShirt.Text = shirt_t
                male = "帥哥"
                female = "美女"
                btnSet.Text = "應用"
                GroupBox5.Text = "一般"
                cbSaveAvatar.Text = "保存" & vbNewLine & "頭像"
                coming_soon = "即將登場"
                must_select_avatar = "頭像不能為空。"
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
                btnSave.Text = "Sauv"
                tool_tip = "Change car might lose ability to tune your car!"
                GroupBox1.Text = "Tricher"
                GroupBox2.Text = "Initial D 6 AA"
                GroupBox3.Text = "Initial D 7 AAX"
                GroupBox4.Text = "Avatar"
                Label10.Text = "Catégorie"
                Label12.Text = "Sélection"
                mouth_t = "Bouche"
                eyes_t = "Les yeux"
                face_skin_t = "Visage et couleur de la peau"
                accessories_t = "Accessoire"
                shades_t = "Des lunettes"
                hair_t = "Cheveux"
                shirt_t = "Chemise"
                gbMouth.Text = mouth_t
                gbEyes.Text = eyes_t
                gbSkin.Text = face_skin_t
                gbAccessories.Text = accessories_t
                gbShades.Text = shades_t
                gbHair.Text = hair_t
                gbShirt.Text = shirt_t
                male = "Mâle"
                female = "Femelle"
                btnSet.Text = "Appliquer"
                GroupBox5.Text = "De base"
                cbSaveAvatar.Text = "Enregistrer" & vbNewLine & "Avatar"
                coming_soon = "Arrive bientôt"
                must_select_avatar = "Avatar ne peut pas être vide."
        End Select
    End Sub

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChapLevel.KeyPress, txtLevel.KeyPress, txtPridePoint.KeyPress, txtSPride.KeyPress, txtTPride.KeyPress
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

    Private Sub cmbAvatarCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAvatarCat.SelectedIndexChanged
        Try
            cmbAvatar.DataSource = Nothing
            cmbAvatar.Items.Clear()
            cmbAvatar.DisplayMember = "Key"
            cmbAvatar.ValueMember = "Value"

            If cmbGender.SelectedIndex = 1 Then
                Select Case cmbAvatarCat.SelectedValue.ToString
                    Case "MOUTH"
                        cmbAvatar.DataSource = New BindingSource(mouth_f, Nothing)
                    Case "EYES"
                        cmbAvatar.DataSource = New BindingSource(eyes_f, Nothing)
                    Case "SKIN"
                        cmbAvatar.DataSource = New BindingSource(skin_f, Nothing)
                    Case "ACCESSORIES"
                        cmbAvatar.DataSource = New BindingSource(accessories_f, Nothing)
                    Case "SHIRT"
                        cmbAvatar.DataSource = New BindingSource(shirt_f, Nothing)
                    Case "SHADES"
                        cmbAvatar.DataSource = New BindingSource(shades_f, Nothing)
                    Case "HAIR"
                        cmbAvatar.DataSource = New BindingSource(hair_f, Nothing)
                End Select
            Else
                Select Case cmbAvatarCat.SelectedValue.ToString
                    Case "MOUTH"
                        cmbAvatar.DataSource = New BindingSource(mouth_m, Nothing)
                    Case "EYES"
                        cmbAvatar.DataSource = New BindingSource(eyes_m, Nothing)
                    Case "SKIN"
                        cmbAvatar.DataSource = New BindingSource(skin_m, Nothing)
                    Case "ACCESSORIES"
                        cmbAvatar.DataSource = New BindingSource(accessories_m, Nothing)
                    Case "SHIRT"
                        cmbAvatar.DataSource = New BindingSource(shirt_m, Nothing)
                    Case "SHADES"
                        cmbAvatar.DataSource = New BindingSource(shades_m, Nothing)
                    Case "HAIR"
                        cmbAvatar.DataSource = New BindingSource(hair_m, Nothing)
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbAvatar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAvatar.SelectedIndexChanged
        Try
            If cmbAvatar.SelectedItem IsNot Nothing Then
                pbPreview.BackgroundImage = cmbAvatar.SelectedValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DictionaryAdd()
        'Female
        'Add Mouth
        Dim fmo As New Female.Mouth
        mouth_f.Add("01", fmo.MO_0X0C)
        mouth_f.Add("02", fmo.MO_0X0D)
        mouth_f.Add("03", fmo.MO_1X0C)
        mouth_f.Add("04", fmo.MO_1X0D)
        mouth_f.Add("05", fmo.MO_2X0C)
        mouth_f.Add("06", fmo.MO_2X0D)
        mouth_f.Add("07", fmo.MO_3X0C)
        mouth_f.Add("08", fmo.MO_3X0D)
        mouth_f.Add("09", fmo.MO_4X0C)
        mouth_f.Add("10", fmo.MO_4X0D)
        mouth_f.Add("11", fmo.MO_5X0C)
        mouth_f.Add("12", fmo.MO_5X0D)
        mouth_f.Add("13", fmo.MO_6X0C)
        mouth_f.Add("14", fmo.MO_6X0D)
        mouth_f.Add("15", fmo.MO_7X0B)
        mouth_f.Add("16", fmo.MO_7X0C)
        mouth_f.Add("17", fmo.MO_7X0D)
        mouth_f.Add("18", fmo.MO_8X0B)
        mouth_f.Add("19", fmo.MO_8X0C)
        mouth_f.Add("20", fmo.MO_8X0D)
        mouth_f.Add("21", fmo.MO_9X0B)
        mouth_f.Add("22", fmo.MO_9X0C)
        mouth_f.Add("23", fmo.MO_AX0B)
        mouth_f.Add("24", fmo.MO_AX0C)
        mouth_f.Add("25", fmo.MO_BX0B)
        mouth_f.Add("26", fmo.MO_BX0C)
        mouth_f.Add("27", fmo.MO_CX0B)
        mouth_f.Add("28", fmo.MO_CX0C)
        mouth_f.Add("29", fmo.MO_DX0B)
        mouth_f.Add("30", fmo.MO_DX0C)
        mouth_f.Add("31", fmo.MO_EX0B)
        mouth_f.Add("32", fmo.MO_EX0C)
        mouth_f.Add("33", fmo.MO_FX0B)
        mouth_f.Add("34", fmo.MO_FX0C)

        'Add Shirt
        Dim fsh As New Female.Shirt
        shirt_f.Add("1", fsh.SH_0X02)
        shirt_f.Add("2", fsh.SH_0X03)
        shirt_f.Add("3", fsh.SH_0X04)
        shirt_f.Add("4", fsh.SH_0X05)
        shirt_f.Add("5", fsh.SH_0X06)
        shirt_f.Add("6", fsh.SH_0X07)
        shirt_f.Add("7", fsh.SH_0X08)
        shirt_f.Add("8", fsh.SH_1X02)
        shirt_f.Add("9", fsh.SH_1X03)
        shirt_f.Add("10", fsh.SH_1X04)
        shirt_f.Add("11", fsh.SH_1X05)
        shirt_f.Add("12", fsh.SH_1X06)
        shirt_f.Add("13", fsh.SH_1X07)
        shirt_f.Add("14", fsh.SH_1X08)
        shirt_f.Add("15", fsh.SH_2X02)
        shirt_f.Add("16", fsh.SH_2X03)
        shirt_f.Add("17", fsh.SH_2X04)
        shirt_f.Add("18", fsh.SH_2X05)
        shirt_f.Add("19", fsh.SH_2X06)
        shirt_f.Add("20", fsh.SH_2X07)
        shirt_f.Add("21", fsh.SH_2X08)
        shirt_f.Add("22", fsh.SH_3X02)
        shirt_f.Add("23", fsh.SH_3X03)
        shirt_f.Add("24", fsh.SH_3X04)
        shirt_f.Add("25", fsh.SH_3X05)
        shirt_f.Add("26", fsh.SH_3X06)
        shirt_f.Add("27", fsh.SH_3X07)
        shirt_f.Add("28", fsh.SH_3X08)
        shirt_f.Add("29", fsh.SH_4X02)
        shirt_f.Add("30", fsh.SH_4X03)
        shirt_f.Add("31", fsh.SH_4X04)
        shirt_f.Add("32", fsh.SH_4X05)
        shirt_f.Add("33", fsh.SH_4X06)
        shirt_f.Add("34", fsh.SH_4X07)
        shirt_f.Add("35", fsh.SH_4X08)
        shirt_f.Add("36", fsh.SH_5X02)
        shirt_f.Add("37", fsh.SH_5X03)
        shirt_f.Add("38", fsh.SH_5X04)
        shirt_f.Add("39", fsh.SH_5X05)
        shirt_f.Add("40", fsh.SH_5X06)
        shirt_f.Add("41", fsh.SH_5X07)
        shirt_f.Add("42", fsh.SH_5X08)
        shirt_f.Add("43", fsh.SH_6X01)
        shirt_f.Add("44", fsh.SH_6X02)
        shirt_f.Add("45", fsh.SH_6X03)
        shirt_f.Add("46", fsh.SH_6X04)
        shirt_f.Add("47", fsh.SH_6X05)
        shirt_f.Add("48", fsh.SH_6X06)
        shirt_f.Add("49", fsh.SH_6X07)
        shirt_f.Add("50", fsh.SH_6X08)
        shirt_f.Add("51", fsh.SH_7X01)
        shirt_f.Add("52", fsh.SH_7X02)
        shirt_f.Add("53", fsh.SH_7X03)
        shirt_f.Add("54", fsh.SH_7X04)
        shirt_f.Add("55", fsh.SH_7X05)
        shirt_f.Add("56", fsh.SH_7X06)
        shirt_f.Add("57", fsh.SH_7X07)
        shirt_f.Add("58", fsh.SH_7X08)
        shirt_f.Add("59", fsh.SH_8X01)
        shirt_f.Add("60", fsh.SH_8X02)
        shirt_f.Add("61", fsh.SH_8X03)
        shirt_f.Add("62", fsh.SH_8X04)
        shirt_f.Add("63", fsh.SH_8X05)
        shirt_f.Add("64", fsh.SH_8X06)
        shirt_f.Add("65", fsh.SH_8X07)
        shirt_f.Add("66", fsh.SH_8X08)
        shirt_f.Add("67", fsh.SH_9X01)
        shirt_f.Add("68", fsh.SH_9X02)
        shirt_f.Add("69", fsh.SH_9X03)
        shirt_f.Add("70", fsh.SH_9X04)
        shirt_f.Add("71", fsh.SH_9X05)
        shirt_f.Add("72", fsh.SH_9X06)
        shirt_f.Add("73", fsh.SH_9X07)
        shirt_f.Add("74", fsh.SH_9X08)
        shirt_f.Add("75", fsh.SH_AX01)
        shirt_f.Add("76", fsh.SH_AX02)
        shirt_f.Add("77", fsh.SH_AX03)
        shirt_f.Add("78", fsh.SH_AX04)
        shirt_f.Add("79", fsh.SH_AX05)
        shirt_f.Add("80", fsh.SH_AX06)
        shirt_f.Add("81", fsh.SH_AX07)
        shirt_f.Add("82", fsh.SH_AX08)
        shirt_f.Add("83", fsh.SH_BX01)
        shirt_f.Add("84", fsh.SH_BX02)
        shirt_f.Add("85", fsh.SH_BX03)
        shirt_f.Add("86", fsh.SH_BX04)
        shirt_f.Add("87", fsh.SH_BX05)
        shirt_f.Add("88", fsh.SH_BX06)
        shirt_f.Add("89", fsh.SH_BX07)
        shirt_f.Add("90", fsh.SH_BX08)
        shirt_f.Add("91", fsh.SH_CX01)
        shirt_f.Add("92", fsh.SH_CX02)
        shirt_f.Add("93", fsh.SH_CX03)
        shirt_f.Add("94", fsh.SH_CX04)
        shirt_f.Add("95", fsh.SH_CX05)
        shirt_f.Add("96", fsh.SH_CX06)
        shirt_f.Add("97", fsh.SH_CX07)
        shirt_f.Add("98", fsh.SH_CX08)
        shirt_f.Add("99", fsh.SH_DX01)
        shirt_f.Add("100", fsh.SH_DX02)
        shirt_f.Add("101", fsh.SH_DX03)
        shirt_f.Add("102", fsh.SH_DX04)
        shirt_f.Add("103", fsh.SH_DX05)
        shirt_f.Add("104", fsh.SH_DX06)
        shirt_f.Add("105", fsh.SH_DX07)
        shirt_f.Add("106", fsh.SH_DX08)
        shirt_f.Add("107", fsh.SH_EX01)
        shirt_f.Add("108", fsh.SH_EX02)
        shirt_f.Add("109", fsh.SH_EX03)
        shirt_f.Add("110", fsh.SH_EX04)
        shirt_f.Add("111", fsh.SH_EX05)
        shirt_f.Add("112", fsh.SH_EX06)
        shirt_f.Add("113", fsh.SH_EX07)
        shirt_f.Add("114", fsh.SH_EX08)
        shirt_f.Add("115", fsh.SH_FX01)
        shirt_f.Add("116", fsh.SH_FX02)
        shirt_f.Add("117", fsh.SH_FX03)
        shirt_f.Add("118", fsh.SH_FX04)
        shirt_f.Add("119", fsh.SH_FX05)
        shirt_f.Add("120", fsh.SH_FX06)
        shirt_f.Add("121", fsh.SH_FX07)
        shirt_f.Add("122", fsh.SH_FX08)

        'Add Eyes
        Dim fey As New Female.Eyes
        eyes_f.Add("01", fey.EY_90X0)
        eyes_f.Add("02", fey.EY_91X0)
        eyes_f.Add("03", fey.EY_92X0)
        eyes_f.Add("04", fey.EY_93X0)
        eyes_f.Add("05", fey.EY_94X0)
        eyes_f.Add("06", fey.EY_95X0)
        eyes_f.Add("07", fey.EY_96X0)
        eyes_f.Add("08", fey.EY_97X0)
        eyes_f.Add("09", fey.EY_98X0)
        eyes_f.Add("10", fey.EY_99X0)
        eyes_f.Add("11", fey.EY_9AX0)
        eyes_f.Add("12", fey.EY_9BX0)
        eyes_f.Add("13", fey.EY_9CX0)
        eyes_f.Add("14", fey.EY_9DX0)
        eyes_f.Add("15", fey.EY_9EX0)
        eyes_f.Add("16", fey.EY_9FX0)
        eyes_f.Add("17", fey.EY_A0X0)
        eyes_f.Add("18", fey.EY_A1X0)
        eyes_f.Add("19", fey.EY_A2X0)
        eyes_f.Add("20", fey.EY_A3X0)
        eyes_f.Add("21", fey.EY_A4X0)
        eyes_f.Add("22", fey.EY_A5X0)
        eyes_f.Add("23", fey.EY_A6X0)
        eyes_f.Add("24", fey.EY_A7X0)
        eyes_f.Add("25", fey.EY_A8X0)
        eyes_f.Add("26", fey.EY_A9X0)
        eyes_f.Add("27", fey.EY_AAX0)
        eyes_f.Add("28", fey.EY_ABX0)
        eyes_f.Add("29", fey.EY_ACX0)
        eyes_f.Add("30", fey.EY_ADX0)
        eyes_f.Add("31", fey.EY_AEX0)
        eyes_f.Add("32", fey.EY_AFX0)
        eyes_f.Add("33", fey.EY_B0X0)
        eyes_f.Add("34", fey.EY_B1X0)
        eyes_f.Add("35", fey.EY_B2X0)
        eyes_f.Add("36", fey.EY_B3X0)
        eyes_f.Add("37", fey.EY_B4X0)
        eyes_f.Add("38", fey.EY_B5X0)
        eyes_f.Add("39", fey.EY_B6X0)

        'Add Skin
        Dim fsk As New Female.Skin
        skin_f.Add("01", fsk.SK_01X0)
        skin_f.Add("02", fsk.SK_02X0)
        skin_f.Add("03", fsk.SK_03X0)
        skin_f.Add("04", fsk.SK_04X0)
        skin_f.Add("05", fsk.SK_05X0)
        skin_f.Add("06", fsk.SK_06X0)
        skin_f.Add("07", fsk.SK_07X0)
        skin_f.Add("08", fsk.SK_08X0)
        skin_f.Add("09", fsk.SK_09X0)
        skin_f.Add("10", fsk.SK_0AX0)
        skin_f.Add("11", fsk.SK_0BX0)
        skin_f.Add("12", fsk.SK_0CX0)
        skin_f.Add("13", fsk.SK_0DX0)
        skin_f.Add("14", fsk.SK_0EX0)
        skin_f.Add("15", fsk.SK_0FX0)
        skin_f.Add("16", fsk.SK_10X0)
        skin_f.Add("17", fsk.SK_11X0)
        skin_f.Add("18", fsk.SK_12X0)
        skin_f.Add("19", fsk.SK_13X0)
        skin_f.Add("20", fsk.SK_14X0)
        skin_f.Add("21", fsk.SK_15X0)

        'Add Accesories
        Dim fac As New Female.Accessories
        accessories_f.Add("01", fac.AC_00X1)
        accessories_f.Add("02", fac.AC_D9X0)
        accessories_f.Add("03", fac.AC_DAX0)
        accessories_f.Add("04", fac.AC_DBX0)
        accessories_f.Add("05", fac.AC_DCX0)
        accessories_f.Add("06", fac.AC_DDX0)
        accessories_f.Add("07", fac.AC_DEX0)
        accessories_f.Add("08", fac.AC_DFX0)
        accessories_f.Add("09", fac.AC_E0X0)
        accessories_f.Add("10", fac.AC_E1X0)
        accessories_f.Add("11", fac.AC_E2X0)
        accessories_f.Add("12", fac.AC_E3X0)
        accessories_f.Add("13", fac.AC_E4X0)
        accessories_f.Add("14", fac.AC_E5X0)
        accessories_f.Add("15", fac.AC_E6X0)
        accessories_f.Add("16", fac.AC_E7X0)
        accessories_f.Add("17", fac.AC_E8X0)
        accessories_f.Add("18", fac.AC_E9X0)
        accessories_f.Add("19", fac.AC_EAX0)
        accessories_f.Add("20", fac.AC_EBX0)
        accessories_f.Add("21", fac.AC_ECX0)
        accessories_f.Add("22", fac.AC_EDX0)
        accessories_f.Add("23", fac.AC_EEX0)
        accessories_f.Add("24", fac.AC_EFX0)
        accessories_f.Add("25", fac.AC_F0X0)
        accessories_f.Add("26", fac.AC_F1X0)
        accessories_f.Add("27", fac.AC_F2X0)
        accessories_f.Add("28", fac.AC_F3X0)
        accessories_f.Add("29", fac.AC_F4X0)
        accessories_f.Add("30", fac.AC_F5X0)
        accessories_f.Add("31", fac.AC_F6X0)
        accessories_f.Add("32", fac.AC_F7X0)
        accessories_f.Add("33", fac.AC_F8X0)
        accessories_f.Add("34", fac.AC_F9X0)
        accessories_f.Add("35", fac.AC_FAX0)
        accessories_f.Add("36", fac.AC_FBX0)
        accessories_f.Add("37", fac.AC_FCX0)
        accessories_f.Add("38", fac.AC_FDX0)
        accessories_f.Add("39", fac.AC_FEX0)
        accessories_f.Add("40", fac.AC_FFX0)

        'Add Shades
        Dim fsp As New Female.Shades
        shades_f.Add("01", fsp.SP_1X10)
        shades_f.Add("02", fsp.SP_2X10)
        shades_f.Add("03", fsp.SP_3X10)
        shades_f.Add("04", fsp.SP_4X10)
        shades_f.Add("05", fsp.SP_5X10)
        shades_f.Add("06", fsp.SP_6X10)
        shades_f.Add("07", fsp.SP_7X10)
        shades_f.Add("08", fsp.SP_8X10)
        shades_f.Add("09", fsp.SP_9X10)
        shades_f.Add("10", fsp.SP_AX10)
        shades_f.Add("11", fsp.SP_BX10)
        shades_f.Add("12", fsp.SP_CX10)
        shades_f.Add("13", fsp.SP_DX10)
        shades_f.Add("14", fsp.SP_EX10)

        'Add Hair
        Dim fha As New Female.Hair
        hair_f.Add("01", fha.HA_0FX0)
        hair_f.Add("02", fha.HA_10X1)
        hair_f.Add("03", fha.HA_11X1)
        hair_f.Add("04", fha.HA_12X1)
        hair_f.Add("05", fha.HA_13X1)
        hair_f.Add("06", fha.HA_14X1)
        hair_f.Add("07", fha.HA_15X1)
        hair_f.Add("08", fha.HA_16X1)
        hair_f.Add("09", fha.HA_17X1)
        hair_f.Add("10", fha.HA_18X1)
        hair_f.Add("11", fha.HA_19X1)
        hair_f.Add("12", fha.HA_1AX1)
        hair_f.Add("13", fha.HA_1BX1)
        hair_f.Add("14", fha.HA_1CX1)
        hair_f.Add("15", fha.HA_1DX1)
        hair_f.Add("16", fha.HA_1EX1)
        hair_f.Add("17", fha.HA_1FX1)
        hair_f.Add("18", fha.HA_20X1)
        hair_f.Add("19", fha.HA_21X1)
        hair_f.Add("20", fha.HA_22X1)
        hair_f.Add("21", fha.HA_23X1)
        hair_f.Add("22", fha.HA_24X1)
        hair_f.Add("23", fha.HA_25X1)
        hair_f.Add("24", fha.HA_26X1)
        hair_f.Add("25", fha.HA_27X1)
        hair_f.Add("26", fha.HA_28X1)
        hair_f.Add("27", fha.HA_29X1)
        hair_f.Add("28", fha.HA_2AX1)
        hair_f.Add("29", fha.HA_2BX1)
        hair_f.Add("30", fha.HA_2CX1)
        hair_f.Add("31", fha.HA_2DX1)
        hair_f.Add("32", fha.HA_2EX1)
        hair_f.Add("33", fha.HA_2FX1)
        hair_f.Add("34", fha.HA_30X1)
        hair_f.Add("35", fha.HA_31X1)
        hair_f.Add("36", fha.HA_32X1)
        hair_f.Add("37", fha.HA_33X1)
        hair_f.Add("38", fha.HA_34X1)
        hair_f.Add("39", fha.HA_35X1)
        hair_f.Add("40", fha.HA_36X1)
        hair_f.Add("41", fha.HA_37X1)
        hair_f.Add("42", fha.HA_38X1)
        hair_f.Add("43", fha.HA_39X1)
        hair_f.Add("44", fha.HA_3AX1)
        hair_f.Add("45", fha.HA_3BX1)
        hair_f.Add("46", fha.HA_3CX1)
        hair_f.Add("47", fha.HA_3DX1)
        hair_f.Add("48", fha.HA_3EX1)
        hair_f.Add("49", fha.HA_3FX1)
        hair_f.Add("50", fha.HA_40X1)
        hair_f.Add("51", fha.HA_41X1)
        hair_f.Add("52", fha.HA_42X1)
        hair_f.Add("53", fha.HA_43X1)
        hair_f.Add("54", fha.HA_44X1)
        hair_f.Add("55", fha.HA_45X1)
        hair_f.Add("56", fha.HA_46X1)
        hair_f.Add("57", fha.HA_47X1)
        hair_f.Add("58", fha.HA_48X1)
        hair_f.Add("59", fha.HA_49X1)
        hair_f.Add("60", fha.HA_4AX1)
        hair_f.Add("61", fha.HA_4BX1)
        hair_f.Add("62", fha.HA_4CX1)
        hair_f.Add("63", fha.HA_4DX1)
        hair_f.Add("64", fha.HA_4EX1)
        hair_f.Add("65", fha.HA_4FX1)
        hair_f.Add("66", fha.HA_50X1)
        hair_f.Add("67", fha.HA_51X1)
        hair_f.Add("68", fha.HA_52X1)
        hair_f.Add("69", fha.HA_53X1)
        hair_f.Add("70", fha.HA_54X1)
        hair_f.Add("71", fha.HA_55X1)
        hair_f.Add("72", fha.HA_56X1)
        hair_f.Add("73", fha.HA_57X1)
        hair_f.Add("74", fha.HA_58X1)
        hair_f.Add("75", fha.HA_59X1)
        hair_f.Add("76", fha.HA_5AX1)
        hair_f.Add("77", fha.HA_5BX1)
        hair_f.Add("78", fha.HA_5CX1)
        hair_f.Add("79", fha.HA_5DX1)
        hair_f.Add("80", fha.HA_5EX1)
        hair_f.Add("81", fha.HA_5FX1)
        hair_f.Add("82", fha.HA_60X1)
        hair_f.Add("83", fha.HA_61X1)
        hair_f.Add("84", fha.HA_62X1)
        hair_f.Add("85", fha.HA_63X1)
        hair_f.Add("86", fha.HA_64X1)
        hair_f.Add("87", fha.HA_65X1)
        hair_f.Add("88", fha.HA_66X1)
        hair_f.Add("89", fha.HA_67X1)
        hair_f.Add("90", fha.HA_68X1)
        hair_f.Add("91", fha.HA_69X1)
        hair_f.Add("92", fha.HA_6AX1)
        hair_f.Add("93", fha.HA_6BX1)
        hair_f.Add("94", fha.HA_6CX1)
        hair_f.Add("95", fha.HA_6DX1)
        hair_f.Add("96", fha.HA_6EX1)
        hair_f.Add("97", fha.HA_6FX1)
        hair_f.Add("98", fha.HA_70X1)
        hair_f.Add("99", fha.HA_71X1)
        hair_f.Add("100", fha.HA_72X1)
        hair_f.Add("101", fha.HA_73X1)
        hair_f.Add("102", fha.HA_74X1)
        hair_f.Add("103", fha.HA_75X1)
        hair_f.Add("104", fha.HA_76X1)
        hair_f.Add("105", fha.HA_77X1)
        hair_f.Add("106", fha.HA_78X1)
        hair_f.Add("107", fha.HA_79X1)
        hair_f.Add("108", fha.HA_7AX1)
        hair_f.Add("109", fha.HA_7BX1)
        hair_f.Add("110", fha.HA_7CX1)
        hair_f.Add("111", fha.HA_7DX1)
        hair_f.Add("112", fha.HA_7EX1)
        hair_f.Add("113", fha.HA_7FX1)
        hair_f.Add("114", fha.HA_80X1)
        hair_f.Add("115", fha.HA_81X1)
        hair_f.Add("116", fha.HA_82X1)
        hair_f.Add("117", fha.HA_83X1)
        hair_f.Add("118", fha.HA_84X1)

        'Male
        'Add Mouth
        Dim mmo As New Male.Mouth
        mouth_m.Add("01", mmo.MO_0X0C)
        mouth_m.Add("02", mmo.MO_0X0D)
        mouth_m.Add("03", mmo.MO_0X0E)
        mouth_m.Add("04", mmo.MO_1X0C)
        mouth_m.Add("05", mmo.MO_1X0D)
        mouth_m.Add("06", mmo.MO_1X0E)
        mouth_m.Add("07", mmo.MO_2X0C)
        mouth_m.Add("08", mmo.MO_2X0D)
        mouth_m.Add("09", mmo.MO_3X0C)
        mouth_m.Add("10", mmo.MO_3X0D)
        mouth_m.Add("11", mmo.MO_4X0B)
        mouth_m.Add("12", mmo.MO_4X0C)
        mouth_m.Add("13", mmo.MO_4X0D)
        mouth_m.Add("14", mmo.MO_5X0B)
        mouth_m.Add("15", mmo.MO_5X0C)
        mouth_m.Add("16", mmo.MO_5X0D)
        mouth_m.Add("17", mmo.MO_6X0B)
        mouth_m.Add("18", mmo.MO_6X0C)
        mouth_m.Add("19", mmo.MO_6X0D)
        mouth_m.Add("20", mmo.MO_7X0B)
        mouth_m.Add("21", mmo.MO_7X0C)
        mouth_m.Add("22", mmo.MO_7X0D)
        mouth_m.Add("23", mmo.MO_8X0B)
        mouth_m.Add("24", mmo.MO_8X0C)
        mouth_m.Add("25", mmo.MO_8X0D)
        mouth_m.Add("26", mmo.MO_9X0B)
        mouth_m.Add("27", mmo.MO_9X0C)
        mouth_m.Add("28", mmo.MO_9X0D)
        mouth_m.Add("29", mmo.MO_AX0B)
        mouth_m.Add("30", mmo.MO_AX0C)
        mouth_m.Add("31", mmo.MO_AX0D)
        mouth_m.Add("32", mmo.MO_BX0B)
        mouth_m.Add("33", mmo.MO_BX0C)
        mouth_m.Add("34", mmo.MO_BX0D)
        mouth_m.Add("35", mmo.MO_CX0B)
        mouth_m.Add("36", mmo.MO_CX0C)
        mouth_m.Add("37", mmo.MO_CX0D)
        mouth_m.Add("38", mmo.MO_DX0B)
        mouth_m.Add("39", mmo.MO_DX0C)
        mouth_m.Add("40", mmo.MO_DX0D)
        mouth_m.Add("41", mmo.MO_EX0B)
        mouth_m.Add("42", mmo.MO_EX0C)
        mouth_m.Add("43", mmo.MO_EX0D)
        mouth_m.Add("44", mmo.MO_FX0B)
        mouth_m.Add("45", mmo.MO_FX0C)
        mouth_m.Add("46", mmo.MO_FX0D)

        'Add Shirt
        Dim msh As New Male.Shirt
        'shirt_m.Add("01", msh.SH_0X00)
        shirt_m.Add("02", msh.SH_0X02)
        shirt_m.Add("03", msh.SH_0X03)
        shirt_m.Add("04", msh.SH_0X04)
        shirt_m.Add("05", msh.SH_0X05)
        shirt_m.Add("06", msh.SH_0X06)
        shirt_m.Add("07", msh.SH_0X07)
        shirt_m.Add("08", msh.SH_0X08)
        shirt_m.Add("09", msh.SH_1X02)
        shirt_m.Add("10", msh.SH_1X03)
        shirt_m.Add("11", msh.SH_1X04)
        shirt_m.Add("12", msh.SH_1X05)
        shirt_m.Add("13", msh.SH_1X06)
        shirt_m.Add("14", msh.SH_1X07)
        shirt_m.Add("15", msh.SH_1X08)
        shirt_m.Add("16", msh.SH_2X02)
        shirt_m.Add("17", msh.SH_2X03)
        shirt_m.Add("18", msh.SH_2X04)
        shirt_m.Add("19", msh.SH_2X05)
        shirt_m.Add("20", msh.SH_2X06)
        shirt_m.Add("21", msh.SH_2X07)
        shirt_m.Add("22", msh.SH_2X08)
        shirt_m.Add("23", msh.SH_3X02)
        shirt_m.Add("24", msh.SH_3X03)
        shirt_m.Add("25", msh.SH_3X04)
        shirt_m.Add("26", msh.SH_3X05)
        shirt_m.Add("27", msh.SH_3X06)
        shirt_m.Add("28", msh.SH_3X07)
        shirt_m.Add("29", msh.SH_3X08)
        shirt_m.Add("30", msh.SH_4X02)
        shirt_m.Add("31", msh.SH_4X03)
        shirt_m.Add("32", msh.SH_4X04)
        shirt_m.Add("33", msh.SH_4X05)
        shirt_m.Add("34", msh.SH_4X06)
        shirt_m.Add("35", msh.SH_4X07)
        shirt_m.Add("36", msh.SH_4X08)
        shirt_m.Add("37", msh.SH_5X02)
        shirt_m.Add("38", msh.SH_5X03)
        shirt_m.Add("39", msh.SH_5X04)
        shirt_m.Add("40", msh.SH_5X05)
        shirt_m.Add("41", msh.SH_5X06)
        shirt_m.Add("42", msh.SH_5X07)
        shirt_m.Add("43", msh.SH_5X08)
        shirt_m.Add("44", msh.SH_6X02)
        shirt_m.Add("45", msh.SH_6X03)
        shirt_m.Add("46", msh.SH_6X04)
        shirt_m.Add("47", msh.SH_6X05)
        shirt_m.Add("48", msh.SH_6X06)
        shirt_m.Add("49", msh.SH_6X07)
        shirt_m.Add("50", msh.SH_6X08)
        shirt_m.Add("51", msh.SH_7X02)
        shirt_m.Add("52", msh.SH_7X03)
        shirt_m.Add("53", msh.SH_7X04)
        shirt_m.Add("54", msh.SH_7X05)
        shirt_m.Add("55", msh.SH_7X06)
        shirt_m.Add("56", msh.SH_7X07)
        shirt_m.Add("57", msh.SH_7X08)
        shirt_m.Add("58", msh.SH_8X02)
        shirt_m.Add("59", msh.SH_8X03)
        shirt_m.Add("60", msh.SH_8X04)
        shirt_m.Add("61", msh.SH_8X05)
        shirt_m.Add("62", msh.SH_8X06)
        shirt_m.Add("63", msh.SH_8X07)
        shirt_m.Add("64", msh.SH_8X08)
        shirt_m.Add("65", msh.SH_9X01)
        shirt_m.Add("66", msh.SH_9X02)
        shirt_m.Add("67", msh.SH_9X03)
        shirt_m.Add("68", msh.SH_9X04)
        shirt_m.Add("69", msh.SH_9X05)
        shirt_m.Add("70", msh.SH_9X06)
        shirt_m.Add("71", msh.SH_9X07)
        shirt_m.Add("72", msh.SH_9X08)
        shirt_m.Add("73", msh.SH_AX01)
        shirt_m.Add("74", msh.SH_AX02)
        shirt_m.Add("75", msh.SH_AX03)
        shirt_m.Add("76", msh.SH_AX04)
        shirt_m.Add("77", msh.SH_AX05)
        shirt_m.Add("78", msh.SH_AX06)
        shirt_m.Add("79", msh.SH_AX07)
        shirt_m.Add("80", msh.SH_AX08)
        shirt_m.Add("81", msh.SH_BX01)
        shirt_m.Add("82", msh.SH_BX02)
        shirt_m.Add("83", msh.SH_BX03)
        shirt_m.Add("84", msh.SH_BX04)
        shirt_m.Add("85", msh.SH_BX05)
        shirt_m.Add("86", msh.SH_BX06)
        shirt_m.Add("87", msh.SH_BX07)
        shirt_m.Add("88", msh.SH_BX08)
        shirt_m.Add("89", msh.SH_CX01)
        shirt_m.Add("90", msh.SH_CX02)
        shirt_m.Add("91", msh.SH_CX03)
        shirt_m.Add("92", msh.SH_CX04)
        shirt_m.Add("93", msh.SH_CX05)
        shirt_m.Add("94", msh.SH_CX06)
        shirt_m.Add("95", msh.SH_CX07)
        shirt_m.Add("96", msh.SH_CX08)
        shirt_m.Add("97", msh.SH_DX01)
        shirt_m.Add("98", msh.SH_DX02)
        shirt_m.Add("99", msh.SH_DX03)
        shirt_m.Add("100", msh.SH_DX04)
        shirt_m.Add("101", msh.SH_DX05)
        shirt_m.Add("102", msh.SH_DX06)
        shirt_m.Add("103", msh.SH_DX07)
        shirt_m.Add("104", msh.SH_DX08)
        shirt_m.Add("105", msh.SH_EX01)
        shirt_m.Add("106", msh.SH_EX02)
        shirt_m.Add("107", msh.SH_EX03)
        shirt_m.Add("108", msh.SH_EX04)
        shirt_m.Add("109", msh.SH_EX05)
        shirt_m.Add("110", msh.SH_EX06)
        shirt_m.Add("111", msh.SH_EX07)
        shirt_m.Add("112", msh.SH_FX01)
        shirt_m.Add("113", msh.SH_FX02)
        shirt_m.Add("114", msh.SH_FX03)
        shirt_m.Add("115", msh.SH_FX04)
        shirt_m.Add("116", msh.SH_FX05)
        shirt_m.Add("117", msh.SH_FX06)
        shirt_m.Add("118", msh.SH_FX07)

        'Add Eyes
        Dim mey As New Male.Eyes
        eyes_m.Add("01", mey.EY_8EX0)
        eyes_m.Add("02", mey.EY_8FX0)
        eyes_m.Add("03", mey.EY_90X0)
        eyes_m.Add("04", mey.EY_91X0)
        eyes_m.Add("05", mey.EY_92X0)
        eyes_m.Add("06", mey.EY_93X0)
        eyes_m.Add("07", mey.EY_94X0)
        eyes_m.Add("08", mey.EY_95X0)
        eyes_m.Add("09", mey.EY_96X0)
        eyes_m.Add("10", mey.EY_97X0)
        eyes_m.Add("11", mey.EY_98X0)
        eyes_m.Add("12", mey.EY_99X0)
        eyes_m.Add("13", mey.EY_9AX0)
        eyes_m.Add("14", mey.EY_9BX0)
        eyes_m.Add("15", mey.EY_9CX0)
        eyes_m.Add("16", mey.EY_9DX0)
        eyes_m.Add("17", mey.EY_9EX0)
        eyes_m.Add("18", mey.EY_9FX0)
        eyes_m.Add("19", mey.EY_A0X0)
        eyes_m.Add("20", mey.EY_A1X0)
        eyes_m.Add("21", mey.EY_A2X0)
        eyes_m.Add("22", mey.EY_A3X0)
        eyes_m.Add("23", mey.EY_A4X0)
        eyes_m.Add("24", mey.EY_A5X0)
        eyes_m.Add("25", mey.EY_A6X0)
        eyes_m.Add("26", mey.EY_A7X0)
        eyes_m.Add("27", mey.EY_A8X0)
        eyes_m.Add("28", mey.EY_A9X0)
        eyes_m.Add("29", mey.EY_AAX0)
        eyes_m.Add("30", mey.EY_ABX0)
        eyes_m.Add("31", mey.EY_ACX0)
        eyes_m.Add("32", mey.EY_ADX0)
        eyes_m.Add("33", mey.EY_AEX0)
        eyes_m.Add("34", mey.EY_AFX0)
        eyes_m.Add("35", mey.EY_B0X0)
        eyes_m.Add("36", mey.EY_B1X0)
        eyes_m.Add("37", mey.EY_B2X0)
        eyes_m.Add("38", mey.EY_B3X0)

        'Add Skin
        Dim msk As New Male.Skin
        skin_m.Add("01", msk.SK_01X0)
        skin_m.Add("02", msk.SK_02X0)
        skin_m.Add("03", msk.SK_03X0)
        skin_m.Add("04", msk.SK_04X0)
        skin_m.Add("05", msk.SK_05X0)
        skin_m.Add("06", msk.SK_06X0)
        skin_m.Add("07", msk.SK_07X0)
        skin_m.Add("08", msk.SK_08X0)
        skin_m.Add("09", msk.SK_09X0)
        skin_m.Add("10", msk.SK_0AX0)
        skin_m.Add("11", msk.SK_0BX0)
        skin_m.Add("12", msk.SK_0CX0)
        skin_m.Add("13", msk.SK_0DX0)
        skin_m.Add("14", msk.SK_0EX0)
        skin_m.Add("15", msk.SK_0FX0)
        skin_m.Add("16", msk.SK_10X0)
        skin_m.Add("17", msk.SK_11X0)
        skin_m.Add("18", msk.SK_12X0)
        skin_m.Add("19", msk.SK_13X0)
        skin_m.Add("20", msk.SK_14X0)
        skin_m.Add("21", msk.SK_15X0)
        skin_m.Add("22", msk.SK_16X0)
        skin_m.Add("23", msk.SK_17X0)
        skin_m.Add("24", msk.SK_18X0)

        'Add Accessories
        Dim mac As New Male.Accessories
        accessories_m.Add("01", mac.AC_00X1)
        accessories_m.Add("02", mac.AC_01X1)
        accessories_m.Add("03", mac.AC_02X1)
        accessories_m.Add("04", mac.AC_03X1)
        accessories_m.Add("05", mac.AC_04X1)
        accessories_m.Add("06", mac.AC_05X1)
        accessories_m.Add("07", mac.AC_06X1)
        accessories_m.Add("08", mac.AC_07X1)
        accessories_m.Add("09", mac.AC_08X1)
        accessories_m.Add("10", mac.AC_E2X0)
        accessories_m.Add("11", mac.AC_E3X0)
        accessories_m.Add("12", mac.AC_E4X0)
        accessories_m.Add("13", mac.AC_E5X0)
        accessories_m.Add("14", mac.AC_E6X0)
        accessories_m.Add("15", mac.AC_E7X0)
        accessories_m.Add("16", mac.AC_E8X0)
        accessories_m.Add("17", mac.AC_E9X0)
        accessories_m.Add("18", mac.AC_EAX0)
        accessories_m.Add("19", mac.AC_EBX0)
        accessories_m.Add("20", mac.AC_ECX0)
        accessories_m.Add("21", mac.AC_EDX0)
        accessories_m.Add("22", mac.AC_EEX0)
        accessories_m.Add("23", mac.AC_EFX0)
        accessories_m.Add("24", mac.AC_F0X0)
        accessories_m.Add("25", mac.AC_F1X0)
        accessories_m.Add("26", mac.AC_F2X0)
        accessories_m.Add("27", mac.AC_F3X0)
        accessories_m.Add("28", mac.AC_F4X0)
        accessories_m.Add("29", mac.AC_F5X0)
        accessories_m.Add("30", mac.AC_F6X0)
        accessories_m.Add("31", mac.AC_F7X0)
        accessories_m.Add("32", mac.AC_F8X0)
        accessories_m.Add("33", mac.AC_F9X0)
        accessories_m.Add("34", mac.AC_FAX0)
        accessories_m.Add("35", mac.AC_FBX0)
        accessories_m.Add("36", mac.AC_FCX0)
        accessories_m.Add("37", mac.AC_FDX0)
        accessories_m.Add("38", mac.AC_FEX0)
        accessories_m.Add("39", mac.AC_FFX0)

        'Add Shades
        Dim msp As New Male.Shades
        shades_m.Add("01", msp.SP_0X11)
        shades_m.Add("02", msp.SP_1X11)
        shades_m.Add("03", msp.SP_2X11)
        shades_m.Add("04", msp.SP_3X11)
        shades_m.Add("05", msp.SP_4X11)
        shades_m.Add("06", msp.SP_5X11)
        shades_m.Add("07", msp.SP_6X11)
        shades_m.Add("08", msp.SP_9X10)
        shades_m.Add("09", msp.SP_AX10)
        shades_m.Add("10", msp.SP_BX10)
        shades_m.Add("11", msp.SP_CX10)
        shades_m.Add("12", msp.SP_DX10)
        shades_m.Add("13", msp.SP_EX10)
        shades_m.Add("14", msp.SP_FX10)

        'Add Hair
        Dim mha As New Male.Hair
        hair_m.Add("01", mha.HA_17X1)
        hair_m.Add("02", mha.HA_18X1)
        hair_m.Add("03", mha.HA_19X1)
        hair_m.Add("04", mha.HA_1AX1)
        hair_m.Add("05", mha.HA_1BX1)
        hair_m.Add("06", mha.HA_1CX1)
        hair_m.Add("07", mha.HA_1DX1)
        hair_m.Add("08", mha.HA_1EX1)
        hair_m.Add("09", mha.HA_1FX1)
        hair_m.Add("10", mha.HA_20X1)
        hair_m.Add("11", mha.HA_21X1)
        hair_m.Add("12", mha.HA_22X1)
        hair_m.Add("13", mha.HA_23X1)
        hair_m.Add("14", mha.HA_24X1)
        hair_m.Add("15", mha.HA_25X1)
        hair_m.Add("16", mha.HA_26X1)
        hair_m.Add("17", mha.HA_27X1)
        hair_m.Add("18", mha.HA_28X1)
        hair_m.Add("19", mha.HA_29X1)
        hair_m.Add("20", mha.HA_2AX1)
        hair_m.Add("21", mha.HA_2BX1)
        hair_m.Add("22", mha.HA_2CX1)
        hair_m.Add("23", mha.HA_2DX1)
        hair_m.Add("24", mha.HA_2EX1)
        hair_m.Add("25", mha.HA_2FX1)
        hair_m.Add("26", mha.HA_30X1)
        hair_m.Add("27", mha.HA_31X1)
        hair_m.Add("28", mha.HA_32X1)
        hair_m.Add("29", mha.HA_33X1)
        hair_m.Add("30", mha.HA_34X1)
        hair_m.Add("31", mha.HA_35X1)
        hair_m.Add("32", mha.HA_36X1)
        hair_m.Add("33", mha.HA_37X1)
        hair_m.Add("34", mha.HA_38X1)
        hair_m.Add("35", mha.HA_39X1)
        hair_m.Add("36", mha.HA_3AX1)
        hair_m.Add("37", mha.HA_3BX1)
        hair_m.Add("38", mha.HA_3CX1)
        hair_m.Add("39", mha.HA_3DX1)
        hair_m.Add("40", mha.HA_3EX1)
        hair_m.Add("41", mha.HA_3FX1)
        hair_m.Add("42", mha.HA_40X1)
        hair_m.Add("43", mha.HA_41X1)
        hair_m.Add("44", mha.HA_42X1)
        hair_m.Add("45", mha.HA_43X1)
        hair_m.Add("46", mha.HA_44X1)
        hair_m.Add("47", mha.HA_45X1)
        hair_m.Add("48", mha.HA_46X1)
        hair_m.Add("49", mha.HA_47X1)
        hair_m.Add("50", mha.HA_48X1)
        hair_m.Add("51", mha.HA_49X1)
        hair_m.Add("52", mha.HA_4AX1)
        hair_m.Add("53", mha.HA_4BX1)
        hair_m.Add("54", mha.HA_4CX1)
        hair_m.Add("55", mha.HA_4DX1)
        hair_m.Add("56", mha.HA_4EX1)
        hair_m.Add("57", mha.HA_4FX1)
        hair_m.Add("58", mha.HA_50X1)
        hair_m.Add("59", mha.HA_51X1)
        hair_m.Add("60", mha.HA_52X1)
        hair_m.Add("61", mha.HA_53X1)
        hair_m.Add("62", mha.HA_54X1)
        hair_m.Add("63", mha.HA_55X1)
        hair_m.Add("64", mha.HA_56X1)
        hair_m.Add("65", mha.HA_57X1)
        hair_m.Add("66", mha.HA_58X1)
        hair_m.Add("67", mha.HA_59X1)
        hair_m.Add("68", mha.HA_5AX1)
        hair_m.Add("69", mha.HA_5BX1)
        hair_m.Add("70", mha.HA_5CX1)
        hair_m.Add("71", mha.HA_5DX1)
        hair_m.Add("72", mha.HA_5EX1)
        hair_m.Add("73", mha.HA_5FX1)
        hair_m.Add("74", mha.HA_60X1)
        hair_m.Add("75", mha.HA_61X1)
        hair_m.Add("76", mha.HA_62X1)
        hair_m.Add("77", mha.HA_63X1)
        hair_m.Add("78", mha.HA_64X1)
        hair_m.Add("79", mha.HA_65X1)
        hair_m.Add("80", mha.HA_66X1)
        hair_m.Add("81", mha.HA_67X1)
        hair_m.Add("82", mha.HA_68X1)
        hair_m.Add("83", mha.HA_69X1)
        hair_m.Add("84", mha.HA_6AX1)
        hair_m.Add("85", mha.HA_6BX1)
        hair_m.Add("86", mha.HA_6CX1)
        hair_m.Add("87", mha.HA_6DX1)
        hair_m.Add("88", mha.HA_6EX1)
        hair_m.Add("89", mha.HA_6FX1)
        hair_m.Add("90", mha.HA_70X1)
        hair_m.Add("91", mha.HA_71X1)
        hair_m.Add("92", mha.HA_72X1)
        hair_m.Add("93", mha.HA_73X1)
        hair_m.Add("94", mha.HA_74X1)
        hair_m.Add("95", mha.HA_75X1)
        hair_m.Add("96", mha.HA_76X1)
        hair_m.Add("97", mha.HA_77X1)
        hair_m.Add("98", mha.HA_78X1)
        hair_m.Add("99", mha.HA_79X1)
        hair_m.Add("100", mha.HA_7AX1)
        hair_m.Add("101", mha.HA_7BX1)
        hair_m.Add("102", mha.HA_7CX1)
        hair_m.Add("103", mha.HA_7DX1)
        hair_m.Add("104", mha.HA_7EX1)
        hair_m.Add("105", mha.HA_7FX1)
        hair_m.Add("106", mha.HA_80X1)
        hair_m.Add("107", mha.HA_81X1)
        hair_m.Add("108", mha.HA_82X1)
        hair_m.Add("109", mha.HA_83X1)
        hair_m.Add("110", mha.HA_84X1)
        hair_m.Add("111", mha.HA_85X1)
        hair_m.Add("112", mha.HA_86X1)

        'Add Category
        category.Add(face_skin_t, "SKIN")
        category.Add(hair_t, "HAIR")
        category.Add(eyes_t, "EYES")
        category.Add(shades_t, "SHADES")
        category.Add(mouth_t, "MOUTH")
        category.Add(shirt_t, "SHIRT")
        category.Add(accessories_t, "ACCESSORIES")
        cmbAvatarCat.DisplayMember = "Key"
        cmbAvatarCat.ValueMember = "Value"
        cmbAvatarCat.DataSource = New BindingSource(category, Nothing)
        cmbAvatarCat.SelectedIndex = 0
    End Sub

End Class