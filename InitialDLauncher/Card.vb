Imports System.IO

Public Class Card

    'Translation
    Dim file_already_exist, rules, select_card, deselect_card As String

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

    Private Sub btnTimeAttack_Click(sender As Object, e As EventArgs) Handles btnTimeAttack.Click
        Try
            Dim ta As frmTimeAttack = New frmTimeAttack()
            ta.Version = _cardVersion
            ta.FileName = _filename
            ta.Show()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        rt = RenameType.RenameFile
        GroupBox1.Show()
        txtName.Text = Path.GetFileName(_filename)
    End Sub

    Enum RenameType
        RenameFile
        RenameName
    End Enum

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
        txtName.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
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
    End Sub

    Private Sub EditCard()
        Try
            Dim fe As frmEdit = New frmEdit()
            fe.Version = _cardVersion
            fe.FileName = _filename
            fe.txtName.Text = lblName.Text
            fe.txtGamePoint.Text = GetMilelage(GetHex(_filename, 192, 1), GetHex(_filename, 193, 1), GetHex(_filename, 194, 1), GetHex(_filename, 195, 1))
            If _cardVersion = 6 Then
                fe.txtLevel.Text = GetLevel(GetHex(_filename, 164, 1), True)
                fe.txtChapLevel.Text = GetChapterLevel(GetHex(_filename, 548, 1))
                fe.txtPridePoint.Text = GetPridePoint(GetHex(_filename, 173, 1), GetHex(_filename, 174, 1))
                fe.txtMileage.Text = GetMilelage(GetHex(_filename, 1096, 1), GetHex(_filename, 1097, 1), GetHex(_filename, 1098, 1), GetHex(_filename, 1099, 1))
                fe.GroupBox3.Enabled = False
            Else
                fe.txtLevel.Text = GetLevel(GetHex(_filename, 163, 1), True)
                fe.GroupBox2.Enabled = False
                fe.txtSPride.Text = GetPridePoint(GetHex(_filename, 170, 1), GetHex(_filename, 171, 1))
                fe.txtTPride.Text = GetPridePoint(GetHex(_filename, 172, 1), GetHex(_filename, 173, 1))
                fe.txtMileage.Text = GetMilelage(GetHex(_filename, 896, 1), GetHex(_filename, 897, 1), GetHex(_filename, 898, 1), GetHex(_filename, 899, 1))
            End If
            fe.cmbCar1.SelectedItem = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1))
            fe.cmbCar2.SelectedItem = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1))
            fe.cmbCar3.SelectedItem = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1))
            fe.Show()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                btnEdit.Text = "Edit Card"
                btnRename.Text = "Rename Card"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "Cancel"
                select_card = "Select Card"
                deselect_card = "Deselect Card"
                If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
                btnTimeAttack.Text = "Time Attack"
                GroupBox1.Text = "Rename Card"
                file_already_exist = "{0}\{1} already exist."
                rules = "Please backup your card file before making changes, I will accept no responsibility for game progress lost or data corrupt. Click Yes if you agreed and continue, click No to cancel."
            Case "Chinese"
                btnEdit.Text = "改卡"
                btnRename.Text = "文件重命名"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "取消"
                select_card = "選擇卡"
                deselect_card = "取消選擇"
                If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
                btnTimeAttack.Text = "時間挑戰"
                GroupBox1.Text = "重命名"
                file_already_exist = "{0}\{1} 已存在。"
                rules = "請在修改任何東西之前先備份你的記憶卡，我將不會負責任何帶給你的損失。如果你同意點擊是，如果你不同意點擊否。"
            Case "French"
                btnEdit.Text = "Edit Cartes"
                btnRename.Text = "Renomer"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "Retour"
                select_card = "Activer"
                deselect_card = "Desactiver"
                If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
                btnTimeAttack.Text = "Time Attack"
                GroupBox1.Text = "Changer Nom"
                file_already_exist = "{0}\{1} already exist."
                rules = "S'il vous plaît sauvegarder votre fichier de carte avant d'apporter des modifications, je n'accepterai aucune responsabilité pour la progression du jeu perdu ou des données corrompues. Cliquez sur Oui si vous avez accepté et continuez, cliquez sur Non pour annuler."
        End Select
    End Sub

    Private Sub Card_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
    End Sub
End Class
