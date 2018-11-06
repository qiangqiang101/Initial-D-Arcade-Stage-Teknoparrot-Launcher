Imports System.IO

Public Class Card

    'Translation
    Dim file_already_exist, rules, select_card, deselect_card, error_5108_fixed, opt_edit, opt_fix5108, opt_rename, opt_ta, not_available_edit, not_available_ta As String

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
                Case 4
                    If btnSelect.Text = select_card Then
                        My.Settings.Id4CardName = _filename
                        My.Settings.Save()
                        frmLauncher.id4CardPath = _filename
                        frmCard.Translate()
                        frmCard.RefreshID4Cards()
                    Else
                        My.Settings.Id4CardName = ""
                        My.Settings.Save()
                        frmLauncher.id4CardPath = ""
                        frmCard.Translate()
                        frmCard.RefreshID4Cards()
                    End If
                Case &H4E
                    If btnSelect.Text = select_card Then
                        My.Settings.Id4eCardName = _filename
                        My.Settings.Save()
                        frmLauncher.id4eCardPath = _filename
                        frmCard.Translate()
                        frmCard.RefreshID4eCards()
                    Else
                        My.Settings.Id4eCardName = ""
                        My.Settings.Save()
                        frmLauncher.id4eCardPath = ""
                        frmCard.Translate()
                        frmCard.RefreshID4eCards()
                    End If
                Case 5
                    If btnSelect.Text = select_card Then
                        My.Settings.Id5CardName = _filename
                        My.Settings.Save()
                        frmLauncher.id5CardPath = _filename
                        frmCard.Translate()
                        frmCard.RefreshID5Cards()
                    Else
                        My.Settings.Id5CardName = ""
                        My.Settings.Save()
                        frmLauncher.id5CardPath = ""
                        frmCard.Translate()
                        frmCard.RefreshID5Cards()
                    End If
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
                Case 8
                    If btnSelect.Text = select_card Then
                        My.Settings.Id8CardName = _filename
                        My.Settings.Save()
                        frmLauncher.id8CardPath = _filename
                        frmCard.Translate()
                        frmCard.RefreshID8Cards()
                    Else
                        My.Settings.Id8CardName = ""
                        My.Settings.Save()
                        frmLauncher.id8CardPath = ""
                        frmCard.Translate()
                        frmCard.RefreshID8Cards()
                    End If
            End Select
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
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
                    Dim result As Integer = NSMessageBox.ShowYesNo(rules, Text)
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
                NSMessageBox.ShowOk(error_5108_fixed, MsgBoxStyle.Information, "5108")
            Case "RENAME"
                rt = RenameType.RenameFile
                GroupBox1.Show()
                txtName.Text = Path.GetFileName(_filename)
            Case "TIME"
                Try
                    If Not My.Settings.LoggedIn Then
                        frmLogin.Show()
                        frmCard.Close()
                        frmLauncher.Enabled = False
                    Else
                        Select Case _cardVersion
                            Case 4, &H4E, 5
                                NSMessageBox.ShowOk(not_available_ta, MsgBoxStyle.Critical, "Error")
                            Case Else
                                Dim ta As frmTimeAttack = New frmTimeAttack()
                                ta.Version = _cardVersion
                                ta.FileName = _filename
                                ta.Extension = _extension
                                ta.Show()
                        End Select
                    End If
                Catch ex As Exception
                    NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
                    Logger.Log(ex.Message & ex.StackTrace)
                End Try
        End Select
    End Sub

    Dim rt As RenameType

    Private Sub btnRenameOK_Click(sender As Object, e As EventArgs) Handles btnRenameOK.Click
        Dim fpath As String = Path.GetDirectoryName(_filename)
        If Not File.Exists(String.Format("{0}\{1}", fpath, txtName.Text)) Then
            My.Computer.FileSystem.RenameFile(_filename, txtName.Text)
            frmCard.RefreshID4Cards()
            frmCard.RefreshID4eCards()
            frmCard.RefreshID5Cards()
            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()
            frmCard.RefreshID8Cards()
        Else
            NSMessageBox.ShowOk(String.Format(file_already_exist, fpath, txtName.Text), MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnRenameCancel_Click(sender As Object, e As EventArgs) Handles btnRenameCancel.Click
        GroupBox1.Hide()
        txtName.Text = ""
    End Sub

    Private Sub EditCard()
        Try
            Select Case _cardVersion
                Case 4, &H4E, 5
                    NSMessageBox.ShowOk(not_available_edit, MsgBoxStyle.Critical, "Error")
                Case Else
                    Dim fe As frmEdit = New frmEdit()
                    If frmLauncher.WindowState = FormWindowState.Maximized Then
                        fe.TopLevel = False
                        frmLauncher.Controls.Add(fe)
                    End If
                    fe.Version = _cardVersion
                    fe.FileName = _filename
                    fe.Extension = _extension
                    fe.Show()
                    fe.Focus()
            End Select
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Text = ReadCfgValue("LauncherTitle", langFile)
            error_5108_fixed = ReadCfgValue("E5108Fixed", langFile)
            opt_fix5108 = ReadCfgValue("OptFix5108", langFile)
            opt_edit = ReadCfgValue("OptEdit", langFile)
            opt_rename = ReadCfgValue("OptRename", langFile)
            Label1.Text = ReadCfgValue("Options", langFile)
            btnGo.Text = ReadCfgValue("GoBtn", langFile)
            btnRenameOK.Text = ReadCfgValue("OKBtn", langFile)
            btnRenameCancel.Text = ReadCfgValue("CancelBtn", langFile)
            select_card = ReadCfgValue("Select", langFile)
            deselect_card = ReadCfgValue("Deselect", langFile)
            If _selected Then btnSelect.Text = deselect_card Else btnSelect.Text = select_card
            opt_ta = ReadCfgValue("OptTA", langFile)
            GroupBox1.Title = ReadCfgValue("OptRename", langFile)
            file_already_exist = ReadCfgValue("FileAlreadyExist", langFile)
            rules = ReadCfgValue("Rules", langFile)
            not_available_edit = ReadCfgValue("NotAvailEdit", langFile)
            not_available_ta = ReadCfgValue("NotAvailTA", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
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
