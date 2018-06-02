Imports System.IO
Imports InitialDLauncher.frmLauncher

Public Class CardEmpty

    'Translation
    Dim not_valid_card As String

    Private _cardVersion As Integer
    Public Property CardVersion() As Integer
        Get
            Return _cardVersion
        End Get
        Set(value As Integer)
            _cardVersion = value
        End Set
    End Property

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Filter = "CRD files (*.crd)|*.crd|BIN files (*.bin)|*.bin"
            ofd.FilterIndex = 1
            ofd.RestoreDirectory = True
            ofd.InitialDirectory = My.Application.Info.DirectoryPath
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim fileName As String = ofd.FileName
                Dim fileNameOnly As String = Path.GetFileName(fileName)
                Dim extension As String = Path.GetExtension(fileName).Replace(".", "").ToLower
                Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                Select Case extension
                    Case "crd"
                        If GetCardVersion(GetHex(fileName, &H14, 2)) = _cardVersion Then
                            File.Move(fileName, destination)
                            frmCard.Translate()
                            frmCard.RefreshID6Cards()
                            frmCard.RefreshID7Cards()
                            frmCard.RefreshID8Cards()
                        Else
                            MsgBox(String.Format(not_valid_card, _cardVersion), MsgBoxStyle.Critical, "Error")
                        End If
                    Case "bin"
                        If GetCardVersion(GetHex(fileName, &H50, 2)) = _cardVersion Then
                            File.Move(fileName, destination)
                            frmCard.Translate()
                            frmCard.RefreshID6Cards()
                            frmCard.RefreshID7Cards()
                            frmCard.RefreshID8Cards()
                        Else
                            MsgBox(String.Format(not_valid_card, _cardVersion), MsgBoxStyle.Critical, "Error")
                        End If
                End Select
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        Try
            Dim AppData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot")

            For Each file As String In IO.Directory.GetFiles(AppData, "*.bin")
                Dim fileName As String = file
                Dim fileNameOnly As String = Path.GetFileName(file)
                Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                If GetCardVersion(GetHex(fileName, &H50, 2)) = _cardVersion Then
                    IO.File.Move(fileName, destination)
                End If
            Next

            Select Case _cardVersion
                Case 6
                    If Directory.Exists(My.Settings.Id6Path) Then
                        For Each file As String In IO.Directory.GetFiles(My.Settings.Id6Path, "*.crd")
                            Dim fileName As String = file
                            Dim fileNameOnly As String = Path.GetFileName(file)
                            Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                            Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                            If GetCardVersion(GetHex(fileName, &H14, 2)) = 6 Then
                                IO.File.Move(fileName, destination)
                            End If
                        Next
                    End If
                Case 7
                    If Directory.Exists(My.Settings.Id7Path) Then
                        For Each file As String In IO.Directory.GetFiles(My.Settings.Id7Path, "*.crd")
                            Dim fileName As String = file
                            Dim fileNameOnly As String = Path.GetFileName(file)
                            Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                            Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                            If GetCardVersion(GetHex(fileName, &H14, 2)) = 7 Then
                                IO.File.Move(fileName, destination)
                            End If
                        Next
                    End If
                Case 8
                    If Directory.Exists(My.Settings.Id8Path) Then
                        For Each file As String In IO.Directory.GetFiles(My.Settings.Id8Path, "*.crd")
                            Dim fileName As String = file
                            Dim fileNameOnly As String = Path.GetFileName(file)
                            Dim extension As String = Path.GetExtension(file).Replace(".", "").ToLower
                            Dim destination As String = Path.Combine(My.Application.Info.DirectoryPath, "ID" & CardVersion & "_CARD\" & fileNameOnly)
                            If GetCardVersion(GetHex(fileName, &H14, 2)) = 8 Then
                                IO.File.Move(fileName, destination)
                            End If
                        Next
                    End If
            End Select

            frmCard.Translate()
            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()
            frmCard.RefreshID8Cards()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            lblNoCard.Text = ReadCfgValue("NoCardFound", langFile)
            btnBrowse.Text = ReadCfgValue("Browse", langFile)
            btnScan.Text = ReadCfgValue("Scan", langFile)
            not_valid_card = ReadCfgValue("NotValidCard", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub
End Class
