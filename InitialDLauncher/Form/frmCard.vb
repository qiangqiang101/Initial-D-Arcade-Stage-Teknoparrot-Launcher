﻿Imports System.IO

Public Class frmCard

    'Translate
    Dim select_card, deselect_card As String

    Dim id4CardPath As String = String.Format("{0}\ID4_CARD\", My.Application.Info.DirectoryPath)
    Dim id4eCardPath As String = String.Format("{0}\ID4E_CARD\", My.Application.Info.DirectoryPath)
    Dim id5CardPath As String = String.Format("{0}\ID5_CARD\", My.Application.Info.DirectoryPath)
    Dim id6CardPath As String = String.Format("{0}\ID6_CARD\", My.Application.Info.DirectoryPath)
    Dim id7CardPath As String = String.Format("{0}\ID7_CARD\", My.Application.Info.DirectoryPath)
    Dim id8CardPath As String = String.Format("{0}\ID8_CARD\", My.Application.Info.DirectoryPath)
    Dim LastLocation As Point = New Point(0, 0)
    Dim item As Card, itemBlank As CardEmpty

    Private Sub frmCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not My.Settings.FullScreen Then MaximumSize = My.Computer.Screen.WorkingArea.Size

        RefreshID4Cards()
        RefreshID4eCards()
        RefreshID5Cards()
        RefreshID6Cards()
        RefreshID7Cards()
        RefreshID8Cards()

        Translate()

        If frmLauncher.WindowState = FormWindowState.Maximized Then
            NsControlButton3.Enabled = False
        End If
    End Sub

#Region "Refresh Cards"
    Public Sub RefreshID6Cards()
        Try
            flp6.FP.Controls.Clear()
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
                    flp6.FP.Controls.Add(item)
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
                    flp6.FP.Controls.Add(item)
                End If
            Next
            If flp6.FP.Controls.Count = 0 Then
                itemBlank = New CardEmpty() With {.CardVersion = 6}
                With itemBlank
                    .Translate()
                End With
                flp6.FP.Controls.Add(itemBlank)
                itemBlank.Size = New Size(itemBlank.Parent.Size.Width - 6, itemBlank.Parent.Size.Height - 6)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshID7Cards()
        Try
            flp7.FP.Controls.Clear()
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
                    flp7.FP.Controls.Add(item)
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
                    flp7.FP.Controls.Add(item)
                End If
            Next
            If flp7.FP.Controls.Count = 0 Then
                itemBlank = New CardEmpty() With {.CardVersion = 7}
                With itemBlank
                    .Translate()
                End With
                flp7.FP.Controls.Add(itemBlank)
                itemBlank.Size = New Size(itemBlank.Parent.Size.Width - 6, itemBlank.Parent.Size.Height - 6)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshID8Cards()
        Try
            flp8.FP.Controls.Clear()
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
                    flp8.FP.Controls.Add(item)
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
                    flp8.FP.Controls.Add(item)
                End If
            Next
            If flp8.FP.Controls.Count = 0 Then
                itemBlank = New CardEmpty() With {.CardVersion = 8}
                With itemBlank
                    .Translate()
                End With
                flp8.FP.Controls.Add(itemBlank)
                itemBlank.Size = New Size(itemBlank.Parent.Size.Width - 6, itemBlank.Parent.Size.Height - 6)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshID4Cards()
        Try
            flp4.FP.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id4CardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, Cid4(240), 12))
                    .lblCar.Text = GetCar(GetHex(file, Cid4(256), 2), GetHex(file, Cid4(271), 1))
                    .lblLevel.Text = GetLevel(GetHex(file, Cid4(163), 1), True)
                    .FileName = file
                    .Extension = "bin"
                    If GetGender(GetHex(file, Cid4(90), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card4japf
                    Else
                        .BackgroundImage = My.Resources.card4japm
                    End If
                    .CardVersion = 4
                    If My.Settings.Id4CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H50, 2)) = 4 Then
                    flp4.FP.Controls.Add(item)
                End If
            Next
            For Each file As String In IO.Directory.GetFiles(id4CardPath, "*.crd")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, Neg60(Cid4(240)), 12))
                    .lblCar.Text = GetCar(GetHex(file, Neg60(Cid4(256)), 2), GetHex(file, Neg60(Cid4(271)), 1))
                    .lblLevel.Text = GetLevel(GetHex(file, Neg60(Cid4(163)), 1), True)
                    .FileName = file
                    .Extension = "crd"
                    If GetGender(GetHex(file, Neg60(Cid4(90)), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card4japf
                    Else
                        .BackgroundImage = My.Resources.card4japm
                    End If
                    .CardVersion = 4
                    If My.Settings.Id4CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H14, 2)) = 4 Then
                    flp4.FP.Controls.Add(item)
                End If
            Next
            If flp4.FP.Controls.Count = 0 Then
                itemBlank = New CardEmpty() With {.CardVersion = 4}
                With itemBlank
                    .Translate()
                End With
                flp4.FP.Controls.Add(itemBlank)
                itemBlank.Size = New Size(itemBlank.Parent.Size.Width - 6, itemBlank.Parent.Size.Height - 6)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshID4eCards()
        Try
            flp4e.FP.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id4eCardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Location = New Point(72, 26)
                    .lblName.Text = GetName(GetHex(file, Cid4(240), 12))
                    .lblLevel.Visible = False
                    .lblCar.Visible = False
                    '.lblCar.Text = GetCar(GetHex(file, 256, 2), GetHex(file, 271, 1))
                    '.lblLevel.Text = GetLevel(GetHex(file, 163, 1))
                    .FileName = file
                    .Extension = "bin"
                    If GetGender(GetHex(file, Cid4(90), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card4f
                    Else
                        .BackgroundImage = My.Resources.card4m
                    End If
                    .CardVersion = &H4E
                    If My.Settings.Id4eCardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H50, 2)) = &H4E Then
                    flp4e.FP.Controls.Add(item)
                End If
            Next
            For Each file As String In IO.Directory.GetFiles(id4eCardPath, "*.crd")
                item = New Card()
                With item
                    .lblName.Location = New Point(72, 26)
                    .lblName.Text = GetName(GetHex(file, Neg60(Cid4(240)), 12))
                    '.lblCar.Text = GetCar(GetHex(file, Neg60(256), 2), GetHex(file, Neg60(271), 1))
                    '.lblLevel.Text = GetLevel(GetHex(file, Neg60(163), 1))
                    .lblCar.Visible = False
                    .lblLevel.Visible = False
                    .FileName = file
                    .Extension = "crd"
                    If GetGender(GetHex(file, Neg60(Cid4(90)), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card4f
                    Else
                        .BackgroundImage = My.Resources.card4m
                    End If
                    .CardVersion = &H4E
                    If My.Settings.Id4eCardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H14, 2)) = &H4E Then
                    flp4e.FP.Controls.Add(item)
                End If
            Next
            If flp4e.FP.Controls.Count = 0 Then
                itemBlank = New CardEmpty() With {.CardVersion = &H4E}
                With itemBlank
                    .Translate()
                End With
                flp4e.FP.Controls.Add(itemBlank)
                itemBlank.Size = New Size(itemBlank.Parent.Size.Width - 6, itemBlank.Parent.Size.Height - 6)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshID5Cards()
        Try
            flp5.FP.Controls.Clear()
            For Each file As String In IO.Directory.GetFiles(id5CardPath, "*.bin")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, 240, 12))
                    .lblCar.Text = GetCar(GetHex(file, 256, 2), GetHex(file, 271, 1))
                    .lblLevel.Location = New Point(260, 5)
                    .lblLevel.Text = GetLevel(GetHex(file, 163, 1))
                    .FileName = file
                    .Extension = "bin"
                    If GetGender(GetHex(file, 90, 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card5f
                    Else
                        .BackgroundImage = My.Resources.card5m
                    End If
                    .CardVersion = 5
                    If My.Settings.Id5CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H50, 2)) = 5 Then
                    flp5.FP.Controls.Add(item)
                End If
            Next
            For Each file As String In IO.Directory.GetFiles(id5CardPath, "*.crd")
                item = New Card()
                With item
                    .lblName.Text = GetName(GetHex(file, Neg60(240), 12))
                    .lblCar.Text = GetCar(GetHex(file, Neg60(256), 2), GetHex(file, Neg60(271), 1))
                    .lblLevel.Location = New Point(260, 5)
                    .lblLevel.Text = GetLevel(GetHex(file, Neg60(163), 1))
                    .FileName = file
                    .Extension = "crd"
                    If GetGender(GetHex(file, Neg60(90), 1)) = Gender.female Then
                        .BackgroundImage = My.Resources.card5f
                    Else
                        .BackgroundImage = My.Resources.card5m
                    End If
                    .CardVersion = 5
                    If My.Settings.Id5CardName = file Then
                        .BackColor = Color.LightBlue
                        .btnSelect.Text = deselect_card
                        .Selected = True
                    Else
                        .btnSelect.Text = select_card
                        .Selected = False
                    End If
                End With
                If GetCardVersion(GetHex(file, &H14, 2)) = 5 Then
                    flp5.FP.Controls.Add(item)
                End If
            Next
            If flp5.FP.Controls.Count = 0 Then
                itemBlank = New CardEmpty() With {.CardVersion = 5}
                With itemBlank
                    .Translate()
                End With
                flp5.FP.Controls.Add(itemBlank)
                itemBlank.Size = New Size(itemBlank.Parent.Size.Width - 6, itemBlank.Parent.Size.Height - 6)
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub
#End Region

    Private Sub frmCard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub frmCard_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub

    Private Sub NsControlButton3_Click(sender As Object, e As EventArgs) Handles NsControlButton3.Click
        LastLocation = Me.Location
    End Sub

    Public Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Me.Text = ReadCfgValue("CardMeText", langFile)
            NsTheme1.Text = Me.Text
            TabPage3.Text = ReadCfgValue("CardTab6", langFile)
            TabPage4.Text = ReadCfgValue("CardTab7", langFile)
            TabPage1.Text = ReadCfgValue("CardTab8", langFile)
            TabPage2.Text = ReadCfgValue("CardTab4Jap", langFile)
            TabPage5.Text = ReadCfgValue("CardTab4Exp", langFile)
            TabPage6.Text = ReadCfgValue("CardTab5", langFile)
            txt6.Text = String.Format(ReadCfgValue("Text6", langFile), Path.GetFileName(My.Settings.Id6CardName))
            txt7.Text = String.Format(ReadCfgValue("Text7", langFile), Path.GetFileName(My.Settings.Id7CardName))
            txt8.Text = String.Format(ReadCfgValue("Text8", langFile), Path.GetFileName(My.Settings.Id8CardName))
            txt4.Text = String.Format(ReadCfgValue("Text4", langFile), Path.GetFileName(My.Settings.Id4CardName))
            txt4e.Text = String.Format(ReadCfgValue("Text4e", langFile), Path.GetFileName(My.Settings.Id4eCardName))
            txt5.Text = String.Format(ReadCfgValue("Text5", langFile), Path.GetFileName(My.Settings.Id5CardName))
            select_card = ReadCfgValue("Select", langFile)
            deselect_card = ReadCfgValue("Deselect", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
        MyBase.OnActivated(e)
        Location = LastLocation
    End Sub

    Private Sub frmCard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus, Me.Deactivate
        LastLocation = Location
    End Sub
End Class