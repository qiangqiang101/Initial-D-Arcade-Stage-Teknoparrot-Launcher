Imports System.IO

Public Class Card

    'Translation
    Dim file_already_exist, rules, select_card, deselect_card, error_5108_fixed, opt_edit, opt_fix5108, opt_rename, opt_ta As String

    'Database
    Dim opt As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private _filename As String
    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Private _cardVersion As Integer
    Public Property CardVersion() As Integer
        Get
            Return _cardVersion
        End Get
        Set(value As Integer)
            _cardVersion = value
        End Set
    End Property

    Private _extension As String
    Public Property Extension() As String
        Get
            Return _extension
        End Get
        Set(value As String)
            _extension = value
        End Set
    End Property

    Private _selected As Boolean
    Public Property Selected() As Boolean
        Get
            Return _selected
        End Get
        Set(value As Boolean)
            _selected = value
        End Set
    End Property

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            Select Case _cardVersion
                Case 6
                    If btnSelect.Text = select_card Then
                        My.Settings.Id6CardName = _filename
                        My.Settings.Save()
                        frmLauncher.id6CardPath = _filename
                        frmCard.Translate()
                        frmCard.RefreshID6Cards()
                    Else
                        My.Settings.Id6CardName = ""
                        My.Settings.Save()
                        frmLauncher.id6CardPath = ""
                        frmCard.Translate()
                        frmCard.RefreshID6Cards()
                    End If
                Case 7
                    If btnSelect.Text = select_card Then
                        My.Settings.Id7CardName = _filename
                        My.Settings.Save()
                        frmLauncher.id7CardPath = _filename
                        frmCard.Translate()
                        frmCard.RefreshID7Cards()
                    Else
                        My.Settings.Id7CardName = ""
                        My.Settings.Save()
                        frmLauncher.id7CardPath = ""
                        frmCard.Translate()
                        frmCard.RefreshID7Cards()
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Enum RenameType
        RenameFile
        RenameName
    End Enum

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Select Case cmbOptions.SelectedValue.ToString
            Case "EDIT"
                If Not My.Settings.Warned Then
                    Dim result As Integer = MessageBox.Show(rules, "Initial D Launcher", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        My.Settings.Warned = True
                        My.Settings.Save()
                        EditCard()
                    End If
                Else
                    EditCard()
                End If
            Case "5108"
                SetHex(_filename, &HC, HexStringToBinary("00"))
                SetHex(_filename, &HD, HexStringToBinary("00"))
                SetHex(_filename, &HE, HexStringToBinary("00"))
                MsgBox(error_5108_fixed, MsgBoxStyle.Information, "5108")
            Case "RENAME"
                rt = RenameType.RenameFile
                GroupBox1.Show()
                txtName.Text = Path.GetFileName(_filename)
            Case "TIME"
                Try
                    If Not My.Settings.LoggedIn Then
                        frmLogin.Show()
                        frmCard.Close()
                        frmLauncher.WindowState = FormWindowState.Minimized
                        frmLauncher.Enabled = False
                    Else
                        Dim ta As frmTimeAttack = New frmTimeAttack()
                        ta.Version = _cardVersion
                        ta.FileName = _filename
                        ta.Extension = _extension
                        ta.Show()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
                End Try
        End Select
    End Sub

    Dim rt As RenameType

    Private Sub btnRenameOK_Click(sender As Object, e As EventArgs) Handles btnRenameOK.Click
        Dim fpath As String = Path.GetDirectoryName(_filename)
        If Not File.Exists(String.Format("{0}\{1}", fpath, txtName.Text)) Then
            My.Computer.FileSystem.RenameFile(_filename, txtName.Text)
            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()
        Else
            MsgBox(String.Format(file_already_exist, fpath, txtName.Text), MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnRenameCancel_Click(sender As Object, e As EventArgs) Handles btnRenameCancel.Click
        GroupBox1.Hide()
        txtName.Text = ""
    End Sub

    Private Sub EditCard()
        Try
            Dim fe As frmEdit = New frmEdit()
            fe.Version = _cardVersion
            fe.FileName = _filename
            'fe.txtName.Text = lblName.Text
            fe.Extension = _extension
            'If _extension = "bin" Then
            '    fe.txtGamePoint.Text = GetMilelage(GetHex(_filename, 192, 1), GetHex(_filename, 193, 1), GetHex(_filename, 194, 1), GetHex(_filename, 195, 1))
            '    If _cardVersion = 6 Then
            '        fe.txtLevel.Text = GetLevel(GetHex(_filename, 164, 1), True)
            '        fe.txtChapLevel.Text = GetChapterLevel(GetHex(_filename, 548, 1))
            '        fe.txtPridePoint.Text = GetPridePoint(GetHex(_filename, 173, 1), GetHex(_filename, 174, 1))
            '        fe.txtMileage.Text = GetMilelage(GetHex(_filename, 1096, 1), GetHex(_filename, 1097, 1), GetHex(_filename, 1098, 1), GetHex(_filename, 1099, 1))
            '        fe.GroupBox3.Enabled = False
            '        fe.cmbCar1.Text = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 6)
            '        fe.cmbCar2.Text = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 6)
            '        fe.cmbCar3.Text = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 6)
            '    Else
            '        fe.txtLevel.Text = GetLevel(GetHex(_filename, 163, 1), True)
            '        fe.GroupBox2.Enabled = False
            '        fe.txtSPride.Text = GetPridePoint(GetHex(_filename, 170, 1), GetHex(_filename, 171, 1))
            '        fe.txtTPride.Text = GetPridePoint(GetHex(_filename, 172, 1), GetHex(_filename, 173, 1))
            '        fe.txtMileage.Text = GetMilelage(GetHex(_filename, 896, 1), GetHex(_filename, 897, 1), GetHex(_filename, 898, 1), GetHex(_filename, 899, 1))
            '        fe.cmbCar1.Text = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1))
            '        fe.cmbCar2.Text = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1))
            '        fe.cmbCar3.Text = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1))
            '    End If

            'Else
            '    fe.txtGamePoint.Text = GetMilelage(GetHex(_filename, Neg60(192), 1), GetHex(_filename, Neg60(193), 1), GetHex(_filename, Neg60(194), 1), GetHex(_filename, Neg60(195), 1))
            '    If _cardVersion = 6 Then
            '        fe.txtLevel.Text = GetLevel(GetHex(_filename, Neg60(164), 1), True)
            '        fe.txtChapLevel.Text = GetChapterLevel(GetHex(_filename, Neg60(548), 1))
            '        fe.txtPridePoint.Text = GetPridePoint(GetHex(_filename, Neg60(173), 1), GetHex(_filename, Neg60(174), 1))
            '        fe.txtMileage.Text = GetMilelage(GetHex(_filename, Neg60(1096), 1), GetHex(_filename, Neg60(1097), 1), GetHex(_filename, Neg60(1098), 1), GetHex(_filename, Neg60(1099), 1))
            '        fe.GroupBox3.Enabled = False
            '        fe.cmbCar1.Text = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 6)
            '        fe.cmbCar2.Text = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 6)
            '        fe.cmbCar3.Text = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 6)
            '    Else
            '        fe.txtLevel.Text = GetLevel(GetHex(_filename, Neg60(163), 1), True)
            '        fe.GroupBox2.Enabled = False
            '        fe.txtSPride.Text = GetPridePoint(GetHex(_filename, Neg60(170), 1), GetHex(_filename, Neg60(171), 1))
            '        fe.txtTPride.Text = GetPridePoint(GetHex(_filename, Neg60(172), 1), GetHex(_filename, Neg60(173), 1))
            '        fe.txtMileage.Text = GetMilelage(GetHex(_filename, Neg60(896), 1), GetHex(_filename, Neg60(897), 1), GetHex(_filename, Neg60(898), 1), GetHex(_filename, Neg60(899), 1))
            '        fe.cmbCar1.Text = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1))
            '        fe.cmbCar2.Text = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1))
            '        fe.cmbCar3.Text = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1))
            '    End If

            'End If
            fe.Show()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                error_5108_fixed = "Error fixed."
                opt_fix5108 = "Fix Error 5108"
                opt_edit = "Edit Card"
                opt_rename = "Rename Card"
                Label1.Text = "Options"
                btnGo.Text = "GO"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "Cancel"
                select_card = "Select Card"
                deselect_card = "Deselect Card"
                If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
                opt_ta = "Time Attack"
                GroupBox1.Title = "Rename Card"
                file_already_exist = "{0}\{1} already exist."
                rules = "Please backup your card file before making changes, I will accept no responsibility for game progress lost or data corrupt. Click Yes if you agreed and continue, click No to cancel."
            Case "Chinese"
                error_5108_fixed = "修復完成。"
                opt_fix5108 = "修復錯誤5108"
                opt_edit = "改卡"
                opt_rename = "文件重命名"
                Label1.Text = "選項"
                btnGo.Text = "前往"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "取消"
                select_card = "選擇卡"
                deselect_card = "取消選擇"
                If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
                opt_ta = "時間挑戰"
                GroupBox1.Title = "重命名"
                file_already_exist = "{0}\{1} 已存在。"
                rules = "請在修改任何東西之前先備份你的記憶卡，我將不會負責任何帶給你的損失。如果你同意點擊是，如果你不同意點擊否。"
            Case "French"
                error_5108_fixed = "Erreur corrigée."
                opt_fix5108 = "Correction d'erreur 5108"
                opt_edit = "Edit Cartes"
                opt_rename = "Renomer"
                Label1.Text = "Options"
                btnGo.Text = "GO"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "Retour"
                select_card = "Activer"
                deselect_card = "Desactiver"
                If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
                opt_ta = "Time Attack"
                GroupBox1.Title = "Changer Nom"
                file_already_exist = "{0}\{1} already exist."
                rules = "S'il vous plaît sauvegarder votre fichier de carte avant d'apporter des modifications, je n'accepterai aucune responsabilité pour la progression du jeu perdu ou des données corrompues. Cliquez sur Oui si vous avez accepté et continuez, cliquez sur Non pour annuler."
        End Select
    End Sub

    Private Sub Card_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()

        'Add Options
        opt.Add(opt_edit, "EDIT")
        If _extension = "crd" Then opt.Add(opt_fix5108, "5108")
        opt.Add(opt_rename, "RENAME")
        opt.Add(opt_ta, "TIME")
        cmbOptions.DisplayMember = "Key"
        cmbOptions.ValueMember = "Value"
        cmbOptions.DataSource = New BindingSource(opt, Nothing)
        cmbOptions.SelectedIndex = 0
    End Sub
End Class
