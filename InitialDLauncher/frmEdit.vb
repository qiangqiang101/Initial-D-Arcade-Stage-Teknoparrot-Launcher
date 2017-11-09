Imports System.IO

Public Class frmEdit

    'Translation
    Dim tool_tip, mouth_t, eyes_t, face_skin_t, accessories_t, shades_t, hair_t, shirt_t, male, female As String

    'Database
    Dim sex As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim category As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim mouth_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim eyes_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim hair_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim skin_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim shirt_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim accessories_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim shades_f As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim mouth_m As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim eyes_m As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim hair_m As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim skin_m As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim shirt_m As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim accessories_m As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim shades_m As Dictionary(Of String, String) = New Dictionary(Of String, String)

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

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Select Case cmbAvatarCat.SelectedValue.ToString
            Case "SKIN"
                SetAvatar(_filename, AvatarType.Skin, cmbAvatar.SelectedValue.ToString)
            Case "HAIR"
                SetAvatar(_filename, AvatarType.Hair, cmbAvatar.SelectedValue.ToString)
            Case "EYES"
                SetAvatar(_filename, AvatarType.Eyes, cmbAvatar.SelectedValue.ToString)
            Case "MOUTH"
                SetAvatar(_filename, AvatarType.Mouth, cmbAvatar.SelectedValue.ToString)
            Case "SHADES"
                SetAvatar(_filename, AvatarType.Shades, cmbAvatar.SelectedValue.ToString)
            Case "ACCESSORIES"
                SetAvatar(_filename, AvatarType.Accessories, cmbAvatar.SelectedValue.ToString)
            Case "SHIRT"
                SetAvatar(_filename, AvatarType.Shirt, cmbAvatar.SelectedValue.ToString)
        End Select

        RefreshAvatar()
    End Sub

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

        DictionaryAdd()
        RefreshAvatar()
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
                GroupBox2.Text = "Initial D 6 AA"
                GroupBox3.Text = "Initial D 7 AAX"
                GroupBox4.Text = "Avatar"
                Label10.Text = "Category"
                Label12.Text = "Selection"
                mouth_t = "Mouth"
                eyes_t = "Eyes"
                face_skin_t = "Face && Skin"
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
                btnSet.Text = "Save Selection"
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
                btnSave.Text = "保存"
                tool_tip = "更換車可能會失去改車功能！"
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
                btnSet.Text = "保存選擇"
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
                btnSet.Text = "Enregistrer la sélection"
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
                pbPreview.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\{2}\{3}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, cmbAvatarCat.SelectedValue.ToString, cmbAvatar.SelectedValue.ToString))
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RefreshAvatar()
        Try
            pbSkin.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\SKIN\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Skin)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
        Try
            pbAccessories.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\ACCESSORIES\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Accessories)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
        Try
            pbEyes.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\EYES\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Eyes)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
        Try
            pbHair.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\HAIR\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Hair)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
        Try
            pbMouth.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\MOUTH\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Mouth)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
        Try
            pbShades.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\SHADES\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Shades)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
        Try
            pbShirt.BackgroundImage = SafeImageFromFile(String.Format("{0}\LAUNCHER\{1}\SHIRT\{2}.png", My.Application.Info.DirectoryPath, cmbGender.SelectedValue.ToString, GetAvatar(_filename, AvatarType.Shirt)))
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DictionaryAdd()
        'Add Mouth
        mouth_f.Add("01", "0X0C")
        mouth_f.Add("02", "0X0D")
        mouth_f.Add("03", "1X0C")
        mouth_f.Add("04", "1X0D")
        mouth_f.Add("05", "2X0C")
        mouth_f.Add("06", "2X0D")
        mouth_f.Add("07", "3X0C")
        mouth_f.Add("08", "3X0D")
        mouth_f.Add("09", "4X0C")
        mouth_f.Add("10", "4X0D")
        mouth_f.Add("11", "5X0C")
        mouth_f.Add("12", "5X0D")
        mouth_f.Add("13", "6X0C")
        mouth_f.Add("14", "6X0D")
        mouth_f.Add("15", "7X0B")
        mouth_f.Add("16", "7X0C")
        mouth_f.Add("17", "7X0D")
        mouth_f.Add("18", "8X0B")
        mouth_f.Add("19", "8X0C")
        mouth_f.Add("20", "8X0D")
        mouth_f.Add("21", "9X0B")
        mouth_f.Add("22", "9X0C")
        mouth_f.Add("23", "AX0B")
        mouth_f.Add("24", "AX0C")
        mouth_f.Add("25", "BX0B")
        mouth_f.Add("26", "BX0C")
        mouth_f.Add("27", "CX0B")
        mouth_f.Add("28", "CX0C")
        mouth_f.Add("29", "DX0B")
        mouth_f.Add("30", "DX0C")
        mouth_f.Add("31", "EX0B")
        mouth_f.Add("32", "EX0C")
        mouth_f.Add("33", "FX0B")
        mouth_f.Add("34", "FX0C")

        'Add Eyes
        eyes_f.Add("01", "90X0")
        eyes_f.Add("02", "91X0")
        eyes_f.Add("03", "92X0")
        eyes_f.Add("04", "93X0")
        eyes_f.Add("05", "94X0")
        eyes_f.Add("06", "95X0")
        eyes_f.Add("07", "96X0")
        eyes_f.Add("08", "97X0")
        eyes_f.Add("09", "98X0")
        eyes_f.Add("10", "99X0")
        eyes_f.Add("11", "9AX0")
        eyes_f.Add("12", "9BX0")
        eyes_f.Add("13", "9CX0")
        eyes_f.Add("14", "9DX0")
        eyes_f.Add("15", "9EX0")
        eyes_f.Add("16", "9FX0")
        eyes_f.Add("17", "A0X0")
        eyes_f.Add("18", "A1X0")
        eyes_f.Add("19", "A2X0")
        eyes_f.Add("20", "A3X0")
        eyes_f.Add("21", "A4X0")
        eyes_f.Add("22", "A5X0")
        eyes_f.Add("23", "A6X0")
        eyes_f.Add("24", "A7X0")
        eyes_f.Add("25", "A8X0")
        eyes_f.Add("26", "A9X0")
        eyes_f.Add("27", "AAX0")
        eyes_f.Add("28", "ABX0")
        eyes_f.Add("29", "ACX0")
        eyes_f.Add("30", "ADX0")
        eyes_f.Add("31", "AEX0")
        eyes_f.Add("32", "AFX0")
        eyes_f.Add("33", "B0X0")
        eyes_f.Add("34", "B1X0")
        eyes_f.Add("35", "B2X0")
        eyes_f.Add("36", "B3X0")
        eyes_f.Add("37", "B4X0")
        eyes_f.Add("38", "B5X0")
        eyes_f.Add("39", "B6X0")

        'Add Skin
        skin_f.Add("01", "01X0")
        skin_f.Add("02", "02X0")
        skin_f.Add("03", "03X0")
        skin_f.Add("04", "04X0")
        skin_f.Add("05", "05X0")
        skin_f.Add("06", "06X0")
        skin_f.Add("07", "07X0")
        skin_f.Add("08", "08X0")
        skin_f.Add("09", "09X0")
        skin_f.Add("10", "0AX0")
        skin_f.Add("11", "0BX0")
        skin_f.Add("12", "0CX0")
        skin_f.Add("13", "0DX0")
        skin_f.Add("14", "0EX0")
        skin_f.Add("15", "0FX0")
        skin_f.Add("16", "10X0")
        skin_f.Add("17", "11X0")
        skin_f.Add("18", "12X0")
        skin_f.Add("19", "13X0")
        skin_f.Add("20", "14X0")
        skin_f.Add("21", "15X0")

        'Add Accesories
        accessories_f.Add("01", "00X1")
        accessories_f.Add("02", "D9X0")
        accessories_f.Add("03", "DAX0")
        accessories_f.Add("04", "DBX0")
        accessories_f.Add("05", "DCX0")
        accessories_f.Add("06", "DDX0")
        accessories_f.Add("07", "DEX0")
        accessories_f.Add("08", "DFX0")
        accessories_f.Add("09", "E0X0")
        accessories_f.Add("10", "E1X0")
        accessories_f.Add("11", "E2X0")
        accessories_f.Add("12", "E3X0")
        accessories_f.Add("13", "E4X0")
        accessories_f.Add("14", "E5X0")
        accessories_f.Add("15", "E6X0")
        accessories_f.Add("16", "E7X0")
        accessories_f.Add("17", "E8X0")
        accessories_f.Add("18", "E9X0")
        accessories_f.Add("19", "EAX0")
        accessories_f.Add("20", "EBX0")
        accessories_f.Add("21", "ECX0")
        accessories_f.Add("22", "EDX0")
        accessories_f.Add("23", "EEX0")
        accessories_f.Add("24", "EFX0")
        accessories_f.Add("25", "F0X0")
        accessories_f.Add("26", "F1X0")
        accessories_f.Add("27", "F2X0")
        accessories_f.Add("28", "F3X0")
        accessories_f.Add("29", "F4X0")
        accessories_f.Add("30", "F5X0")
        accessories_f.Add("31", "F6X0")
        accessories_f.Add("32", "F7X0")
        accessories_f.Add("33", "F8X0")
        accessories_f.Add("34", "F9X0")
        accessories_f.Add("35", "FAX0")
        accessories_f.Add("36", "FBX0")
        accessories_f.Add("37", "FCX0")
        accessories_f.Add("38", "FDX0")
        accessories_f.Add("39", "FEX0")
        accessories_f.Add("40", "FFX0")

        'Add Shades
        shades_f.Add("01", "0101")
        shades_f.Add("02", "0201")
        shades_f.Add("03", "0301")
        shades_f.Add("04", "0401")
        shades_f.Add("05", "0501")
        shades_f.Add("06", "0601")
        shades_f.Add("07", "0701")
        shades_f.Add("08", "0801")
        shades_f.Add("09", "0901")
        shades_f.Add("10", "0A01")
        shades_f.Add("11", "0B01")
        shades_f.Add("12", "0C01")
        shades_f.Add("13", "0D01")
        shades_f.Add("14", "0E01")

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