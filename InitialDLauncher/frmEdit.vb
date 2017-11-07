Imports System.IO

Public Class frmEdit

    'Translation
    Dim tool_tip As String

    Private _version As Integer
    Public Property Version() As Integer
        Get
            Return _version
        End Get
        Set(value As Integer)
            _version = value
        End Set
    End Property

    Private _filename As String
    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim newFileName As String = String.Format("{0}\{1}.bak", Path.GetDirectoryName(_filename), Path.GetFileName(_filename))
            File.Copy(_filename, newFileName, True)

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

            If GroupBox1.Enabled Then
                If Not cmbCar1.SelectedItem = "" AndAlso cbCar1.Checked Then SetHex(_filename, CLng("&H100"), HexStringToBinary(SetCar(cmbCar1.SelectedItem)))
                If Not cmbCar2.SelectedItem = "" AndAlso cbCar2.Checked Then SetHex(_filename, CLng("&H160"), HexStringToBinary(SetCar(cmbCar2.SelectedItem)))
                If Not cmbCar3.SelectedItem = "" AndAlso cbCar3.Checked Then SetHex(_filename, CLng("&H1C0"), HexStringToBinary(SetCar(cmbCar3.SelectedItem)))

                Select Case _version
                    Case 6
                        If cmbGender.SelectedItem = "Female" Then
                            SetHex(_filename, CLng("&HC4"), HexStringToBinary("12F008B6"))
                        Else
                            SetHex(_filename, CLng("&HC4"), HexStringToBinary("18D008B3"))
                        End If
                        If cbLegend.Checked Then SetHex(_filename, CLng("&H"), HexStringToBinary("218F"))
                        SetHex(_filename, CLng("&HE0"), SetValue(txtChapLevel.Text))
                        SetHex(_filename, CLng("&HA4"), SetValue(txtLevel.Text))
                    Case 7
                        If cmbGender.SelectedItem = "Female" Then
                            SetHex(_filename, CLng("&HC5"), HexStringToBinary("0008ABB00C46"))
                        Else
                            SetHex(_filename, CLng("&HC5"), HexStringToBinary("5008B0C00D80"))
                        End If
                        SetHex(_filename, CLng("&HA3"), SetValue(txtLevel.Text))
                End Select
            End If

            frmCard.RefreshID6Cards()
            frmCard.RefreshID7Cards()

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
        GroupBox1.Enabled = frmLauncher.cheat

        ttCar1.SetToolTip(cbCar1, tool_tip)
        ttCar2.SetToolTip(cbCar2, tool_tip)
        ttCar3.SetToolTip(cbCar3, tool_tip)
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Edit Card: " & Path.GetFileName(_filename)
                Label1.Text = "Name"
                Label2.Text = "Gender"
                Label6.Text = "Level"
                Label8.Text = "Chapter Level"
                Label3.Text = "Car 1"
                Label4.Text = "Car 2"
                Label3.Text = "Car 3"
                cbCar1.Text = "Confirm"
                cbCar2.Text = cbCar1.Text
                cbCar3.Text = cbCar1.Text
                cbLegend.Text = "Unlock Legend Chapter"
                btnSave.Text = frmSettings.btnSave.Text
                tool_tip = "Change car might lose ability to tune your car!"
            Case "Chinese"
                Me.Text = "Edit Card: " & Path.GetFileName(_filename)
                Label1.Text = "名字"
                Label2.Text = "性別"
                Label6.Text = "等級"
                Label8.Text = "章節等級"
                Label3.Text = "車1"
                Label4.Text = "車2"
                Label3.Text = "車3"
                cbCar1.Text = "確認更改"
                cbCar2.Text = cbCar1.Text
                cbCar3.Text = cbCar1.Text
                cbLegend.Text = "解鎖傳說章節"
                btnSave.Text = frmSettings.btnSave.Text
                tool_tip = "更換車可能會失去改車功能！"
            Case "French"
                Me.Text = "Edit Card: " & Path.GetFileName(_filename)
                Label1.Text = "Nom"
                Label2.Text = "Genre"
                Label6.Text = "Niveau"
                Label8.Text = "Niveau du chapitre"
                Label3.Text = "Car 1"
                Label4.Text = "Car 2"
                Label3.Text = "Car 3"
                cbCar1.Text = "Confirmer"
                cbCar2.Text = cbCar1.Text
                cbCar3.Text = cbCar1.Text
                cbLegend.Text = "Unlock Legend Chapter"
                btnSave.Text = frmSettings.btnSave.Text
                tool_tip = "Change car might lose ability to tune your car!"
        End Select
    End Sub
End Class