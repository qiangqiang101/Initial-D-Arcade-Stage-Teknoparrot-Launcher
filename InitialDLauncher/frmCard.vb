Imports System.IO

Public Class frmCard

    Dim id6CardPath As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardPath As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)
    Dim item As Card

    Private Sub frmCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshID6Cards()
        RefreshID7Cards()

        lbl6.Text = String.Format("Selected ID6 Card: {0}", Path.GetFileName(My.Settings.Id6CardName))
        lbl7.Text = String.Format("Selected ID7 Card: {0}", Path.GetFileName(My.Settings.Id7CardName))
    End Sub

    Public Sub RefreshID6Cards()
        Try
            flp6.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id6CardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, 240, 12))
                    .FileName = file
                    .CardVersion = 6
                    If My.Settings.Id6CardName = file Then .BackColor = Color.LightBlue
                End With
                flp6.Controls.Add(item)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub RefreshID7Cards()
        Try
            flp7.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id7CardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, 240, 12))
                    .FileName = file
                    .CardVersion = 7
                    If My.Settings.Id7CardName = file Then .BackColor = Color.LightBlue
                End With
                flp7.Controls.Add(item)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmCard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub
End Class