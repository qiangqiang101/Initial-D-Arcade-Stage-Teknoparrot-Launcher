Imports System.IO

Public Class frmCard

    Dim id6CardPath As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardPath As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)
    Dim item As Card

    Private Sub frmCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshID6Cards()
        RefreshID7Cards()

        Translate()
    End Sub

    Public Sub RefreshID6Cards()
        Try
            flp6.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id6CardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, 240, 12))
                    .lblCar.Text = GetCar(GetHex(file, 256, 2), GetHex(file, 271, 1))
                    .lblLevel.Text = GetLevel(GetHex(file, 164, 1), True) + 1
                    .FileName = file
                    .CardVersion = 6
                    If GetGender(GetHex(file, 197, 6)) = Gender.female Then .BackgroundImage = My.Resources.cardf
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
                    .lblCar.Text = GetCar(GetHex(file, 256, 2), GetHex(file, 271, 1))
                    .lblLevel.Text = GetLevel(GetHex(file, 163, 1))
                    .FileName = file
                    If GetGender(GetHex(file, 197, 6)) = Gender.female Then .BackgroundImage = My.Resources.cardf
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

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Card Management"
                TabPage1.Text = "Initial D 6 AA"
                TabPage2.Text = "Initial D 7 AAX"
                lbl6.Text = String.Format("Selected ID6 Card: {0}", Path.GetFileName(My.Settings.Id6CardName))
                lbl7.Text = String.Format("Selected ID7 Card: {0}", Path.GetFileName(My.Settings.Id7CardName))
            Case "Chinese"
                Me.Text = "卡管理"
                TabPage1.Text = "頭文字D6AA"
                TabPage2.Text = "頭文字D7AAX"
                lbl6.Text = String.Format("已經選擇的ID6卡: {0}", Path.GetFileName(My.Settings.Id6CardName))
                lbl7.Text = String.Format("已經選擇的ID7卡: {0}", Path.GetFileName(My.Settings.Id7CardName))
            Case "French"
                Me.Text = "Gestion Cartes"
                TabPage1.Text = "Initial D 6 AA"
                TabPage2.Text = "Initial D 7 AAX"
                lbl6.Text = String.Format("Choix Carte ID6: {0}", Path.GetFileName(My.Settings.Id6CardName))
                lbl7.Text = String.Format("Choix Carte ID7: {0}", Path.GetFileName(My.Settings.Id7CardName))
        End Select
    End Sub

End Class