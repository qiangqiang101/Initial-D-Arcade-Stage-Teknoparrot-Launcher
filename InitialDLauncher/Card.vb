Imports System.IO

Public Class Card

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
                    frmCard.lbl6.Text = String.Format("Selected ID6 Card: {0}", Path.GetFileName(_filename))
                    frmCard.RefreshID6Cards()
                Case 7
                    My.Settings.Id7CardName = _filename
                    My.Settings.Save()
                    frmLauncher.id7CardPath = _filename
                    frmCard.lbl7.Text = String.Format("Selected ID7 Card: {0}", Path.GetFileName(_filename))
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
                    frmCard.lbl6.Text = String.Format("Selected ID6 Card: {0}", "")
                    frmCard.RefreshID6Cards()
                Case 7
                    My.Settings.Id7CardName = ""
                    My.Settings.Save()
                    frmLauncher.id7CardPath = ""
                    frmCard.lbl7.Text = String.Format("Selected ID7 Card: {0}", "")
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
        If rt = RenameType.RenameName Then
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
            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()
        Else
            Dim fpath As String = Path.GetDirectoryName(_filename)
            If Not File.Exists(String.Format("{0}\{1}", fpath, txtName.Text)) Then
                My.Computer.FileSystem.RenameFile(_filename, txtName.Text)
                frmCard.RefreshID6Cards()
                frmCard.RefreshID7Cards()
            Else
                MsgBox(String.Format("{0}\{1} already exist.", fpath, txtName.Text), MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub btnRenameCancel_Click(sender As Object, e As EventArgs) Handles btnRenameCancel.Click
        GroupBox1.Hide()
        txtName.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        rt = RenameType.RenameName
        GroupBox1.Show()
        txtName.Text = lblName.Text
    End Sub
End Class
