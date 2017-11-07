Imports System.IO

Public Class Card

    'Translation
    Dim file_already_exist As String

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

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            Select Case _cardVersion
                Case 6
                    My.Settings.Id6CardName = _filename
                    My.Settings.Save()
                    frmLauncher.id6CardPath = _filename
                    frmCard.Translate()
                    frmCard.RefreshID6Cards()
                Case 7
                    My.Settings.Id7CardName = _filename
                    My.Settings.Save()
                    frmLauncher.id7CardPath = _filename
                    frmCard.Translate()
                    frmCard.RefreshID7Cards()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnUnselect_Click(sender As Object, e As EventArgs) Handles btnUnselect.Click
        Try
            Select Case _cardVersion
                Case 6
                    My.Settings.Id6CardName = ""
                    My.Settings.Save()
                    frmLauncher.id6CardPath = ""
                    frmCard.Translate()
                    frmCard.RefreshID6Cards()
                Case 7
                    My.Settings.Id7CardName = ""
                    My.Settings.Save()
                    frmLauncher.id7CardPath = ""
                    frmCard.Translate()
                    frmCard.RefreshID7Cards()
            End Select
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
        'If rt = RenameType.RenameName Then
        '    If txtName.TextLength <= 5 Then
        '        Dim amount As Integer = 6 - txtName.TextLength
        '        Dim newName As Char = Nothing
        '        Select Case amount
        '            Case 1
        '                newName = Chr(0)
        '            Case 2
        '                newName = Chr(0) & Chr(0)
        '            Case 3
        '                newName = Chr(0) & Chr(0) & Chr(0)
        '            Case 4
        '                newName = Chr(0) & Chr(0) & Chr(0) & Chr(0)
        '            Case 5
        '                newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
        '            Case 6
        '                newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
        '        End Select
        '        SetHex(_filename, CLng("&HF0"), SetName(txtName.Text & newName))
        '    Else
        '        SetHex(_filename, CLng("&HF0"), SetName(txtName.Text))
        '    End If
        '    frmCard.RefreshID6Cards()
        '    frmCard.RefreshID7Cards()
        'Else

        'End If

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
        'rt = RenameType.RenameName
        'GroupBox1.Show()
        'txtName.Text = lblName.Text
        Dim fe As frmEdit = New frmEdit()
        fe.Version = _cardVersion
        fe.FileName = _filename
        fe.txtName.Text = lblName.Text
        If _cardVersion = 6 Then
            If GetGender6(GetHex(_filename, 196, 4)) = Gender.female Then
                fe.cmbGender.SelectedItem = "Female"
            Else
                fe.cmbGender.SelectedItem = "Male"
            End If
            fe.txtLevel.Text = GetLevel(GetHex(_filename, 164, 1), True)
            fe.txtChapLevel.Text = GetChapterLevel(GetHex(_filename, 548, 1))
        Else
            If GetGender7(GetHex(_filename, 197, 6)) = Gender.female Then
                fe.cmbGender.SelectedItem = "Female"
            Else
                fe.cmbGender.SelectedItem = "Male"
            End If
            fe.txtLevel.Text = GetLevel(GetHex(_filename, 163, 1), True)
            fe.txtChapLevel.Enabled = False
            fe.cbLegend.Enabled = False
        End If
        fe.cmbCar1.SelectedItem = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1))
        fe.cmbCar2.SelectedItem = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1))
        fe.cmbCar3.SelectedItem = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1))
        fe.Show()
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                btnEdit.Text = "Edit Card"
                btnRename.Text = "Rename Card"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "Cancel"
                btnSelect.Text = "Select Card"
                btnUnselect.Text = "Deselect Card"
                GroupBox1.Text = "Rename Card"
                file_already_exist = "{0}\{1} already exist."
            Case "Chinese"
                btnEdit.Text = "改卡"
                btnRename.Text = "文件重命名"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "取消"
                btnSelect.Text = "選擇卡"
                btnUnselect.Text = "取消選擇"
                GroupBox1.Text = "重命名"
                file_already_exist = "{0}\{1} 已存在。"
            Case "French"
                btnEdit.Text = "Edit Cartes"
                btnRename.Text = "Renomer"
                btnRenameOK.Text = "OK"
                btnRenameCancel.Text = "Retour"
                btnSelect.Text = "Activer"
                btnUnselect.Text = "Desactiver"
                GroupBox1.Text = "Changer Nom"
                file_already_exist = "{0}\{1} already exist."
        End Select
    End Sub

    Private Sub Card_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
    End Sub
End Class
