Imports System.IO

Public Class frmCard

    'Translate
    Dim select_card, deselect_card As String

    Dim id6CardPath As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardPath As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)
    Dim id8CardPath As String = String.Format("{0}\ID8_CARD\", My.Application.Info.DirectoryPath)
    Dim item As Card

    Private Sub frmCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshID6Cards()
        RefreshID7Cards()
        RefreshID8Cards()

        Translate()
    End Sub

    Public Sub RefreshID6Cards()
        Try
            flp6.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id6CardPath, "*.bin")
                item = New Card()
                With item
                    .lblLevel.Location = New Point(260, 5)
                    .lblName.Text = GetName(GetHex(file, 240, 12))
                    .lblCar.Text = GetCar(GetHex(file, 256, 2), GetHex(file, 271, 1), 6)
                    .lblLevel.Text = GetLevel(GetHex(file, 164, 1), True) + 1
                    .FileName = file
                    .Extension = "bin"
                    .CardVersion = 6
                    If GetGender(GetHex(file, 90, 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card6f
                    Else
                        .BackgroundImage = My.Resources.card6m
                    End If
                    If My.Settings.Id6CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H50, 2)) = 6 Then
                    flp6.Controls.Add(item)
                End If
            Next
            For Each file As String In IO.Directory.GetFiles(id6CardPath, "*.crd")
                item = New Card()
                With item
                    .lblLevel.Location = New Point(260, 5)
                    .lblName.Text = GetName(GetHex(file, Neg60(240), 12))
                    .lblCar.Text = GetCar(GetHex(file, Neg60(256), 2), GetHex(file, Neg60(271), 1), 6)
                    .lblLevel.Text = GetLevel(GetHex(file, Neg60(164), 1), True) + 1
                    .FileName = file
                    .Extension = "crd"
                    .CardVersion = 6
                    If GetGender(GetHex(file, Neg60(90), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card6f
                    Else
                        .BackgroundImage = My.Resources.card6m
                    End If
                    If My.Settings.Id6CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H14, 2)) = 6 Then
                    flp6.Controls.Add(item)
                End If
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
                    .Extension = "bin"
                    If GetGender(GetHex(file, 90, 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card7f
                    Else
                        .BackgroundImage = My.Resources.card7m
                    End If
                    .CardVersion = 7
                    If My.Settings.Id7CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H50, 2)) = 7 Then
                    flp7.Controls.Add(item)
                End If
            Next
            For Each file As String In IO.Directory.GetFiles(id7CardPath, "*.crd")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, Neg60(240), 12))
                    .lblCar.Text = GetCar(GetHex(file, Neg60(256), 2), GetHex(file, Neg60(271), 1))
                    .lblLevel.Text = GetLevel(GetHex(file, Neg60(163), 1))
                    .FileName = file
                    .Extension = "crd"
                    If GetGender(GetHex(file, Neg60(90), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card7f
                    Else
                        .BackgroundImage = My.Resources.card7m
                    End If
                    .CardVersion = 7
                    If My.Settings.Id7CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H14, 2)) = 7 Then
                    flp7.Controls.Add(item)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub RefreshID8Cards()
        Try
            flp8.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id8CardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Location = New Point(85, 14)
                    .lblName.Text = GetName(GetHex(file, 240, 12))
                    .lblCar.Visible = False
                    .lblLevel.Location = New Point(266, 18)
                    .lblLevel.Text = GetLevel(GetHex(file, 163, 1), False, True)
                    .FileName = file
                    .Extension = "bin"
                    .BackgroundImage = My.Resources.card8m
                    .CardVersion = 8
                    If My.Settings.Id8CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H50, 2)) = 8 Then
                    flp8.Controls.Add(item)
                End If
            Next
            For Each file As String In IO.Directory.GetFiles(id8CardPath, "*.crd")
                item = New Card()
                With item
                    .lblName.Location = New Point(85, 14)
                    .lblName.Text = GetName(GetHex(file, Neg60(240), 12))
                    .lblCar.Visible = False
                    .lblLevel.Location = New Point(266, 18)
                    .lblLevel.Text = GetLevel(GetHex(file, Neg60(163), 1), False, True)
                    .FileName = file
                    .Extension = "bin"
                    .BackgroundImage = My.Resources.card8m
                    .CardVersion = 8
                    If My.Settings.Id8CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H14, 2)) = 8 Then
                    flp8.Controls.Add(item)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmCard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub frmCard_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Card Management"
                NsTheme1.Text = Me.Text
                TabPage3.Text = "InitialD 6 AA Cards"
                TabPage4.Text = "InitialD 7 AAX Cards"
                TabPage1.Text = "InitialD 8 ∞ Cards"
                txt6.Text = String.Format("Selected ID6 Card: {0}", Path.GetFileName(My.Settings.Id6CardName))
                txt7.Text = String.Format("Selected ID7 Card: {0}", Path.GetFileName(My.Settings.Id7CardName))
                txt8.Text = String.Format("Selected ID8 Card: {0}", Path.GetFileName(My.Settings.Id8CardName))
                select_card = "Select Card"
                deselect_card = "Deselect Card"
            Case "Chinese"
                Me.Text = "卡管理"
                NsTheme1.Text = Me.Text
                TabPage3.Text = "頭文字D6AA卡"
                TabPage4.Text = "頭文字D7AAX卡"
                TabPage1.Text = "頭文字D8∞卡"
                txt6.Text = String.Format("已經選擇的ID6卡: {0}", Path.GetFileName(My.Settings.Id6CardName))
                txt7.Text = String.Format("已經選擇的ID7卡: {0}", Path.GetFileName(My.Settings.Id7CardName))
                txt8.Text = String.Format("已經選擇的ID8卡: {0}", Path.GetFileName(My.Settings.Id8CardName))
                select_card = "選擇卡"
                deselect_card = "取消選擇"
            Case "French"
                NsTheme1.Text = Me.Text
                Me.Text = "Gestion Cartes"
                TabPage3.Text = "InitialD 6 AA Cards"
                TabPage4.Text = "InitialD 7 AAX Cards"
                TabPage1.Text = "InitialD 8 ∞ Cards"
                txt6.Text = String.Format("Choix Carte ID6: {0}", Path.GetFileName(My.Settings.Id6CardName))
                txt7.Text = String.Format("Choix Carte ID7: {0}", Path.GetFileName(My.Settings.Id7CardName))
                txt8.Text = String.Format("Choix Carte ID8: {0}", Path.GetFileName(My.Settings.Id8CardName))
                select_card = "Activer"
                deselect_card = "Desactiver"
        End Select
    End Sub

End Class