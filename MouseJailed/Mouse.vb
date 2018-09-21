Imports PluginContract
Imports InitialDLauncher
Imports System.IO
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class MouseJailed
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "Mouse Jailed"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "2.0"
        End Get
    End Property

    <DllImport("user32.dll")>
    Public Shared Function SetCursorPos(ByVal x As Integer, ByVal y As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Dim modActivated As Boolean = My.Settings.AutoEnable
    Dim isGameRunning As Boolean = False
    Dim WithEvents labelS As New Label() With {.Text = "Mouse Jailed", .Location = New Point(289, 9), .Size = New Size(111, 15), .ForeColor = Color.White}
    Dim WithEvents checkBox As New NSCheckBox() With {.Text = "Mouse Jailed Enable", .Location = New Point(289, 34), .Size = New Size(266, 24), .ForeColor = Color.White, .Font = New Font("Segoe UI", 10, FontStyle.Regular), .Checked = My.Settings.AutoEnable}
    Dim WithEvents comboBox As NSComboBox

    Public Sub DoSomething() Implements iPlugin.DoSomething
        frmSettings.pluginControls.Add(labelS)
        frmSettings.pluginControls.Add(checkBox)

        comboBox = New NSComboBox()
        For Each i In [Enum].GetValues(GetType(Keys))
            comboBox.Items.Add(i)
        Next

        With comboBox
            .SelectedIndex = My.Settings.Index
            .Location = New Point(406, 4)
            .Size = New Size(155, 24)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End With

        frmSettings.pluginControls.Add(comboBox)
    End Sub

    Private Sub iPlugin_TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        isGameRunning = frmLauncher.isGameRunning

        Try
            If GetAsyncKeyState(My.Settings.HotKey) Then
                modActivated = Not modActivated
            End If

            If isGameRunning AndAlso modActivated Then
                SetCursorPos(Screen.PrimaryScreen.Bounds.Width, 0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub comboBox_Disposed(sender As Object, e As EventArgs) Handles comboBox.Disposed
        frmSettings.pluginControls.Remove(comboBox)
        comboBox = New NSComboBox()
        For Each i In [Enum].GetValues(GetType(Keys))
            comboBox.Items.Add(i)
        Next

        With comboBox
            .SelectedIndex = My.Settings.Index
            .Location = New Point(406, 4)
            .Size = New Size(155, 24)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End With
        frmSettings.pluginControls.Add(comboBox)
    End Sub

    Private Sub labelS_Disposed(sender As Object, e As EventArgs) Handles labelS.Disposed
        frmSettings.pluginControls.Remove(labelS)
        labelS = New Label() With {.Text = "Mouse Jailed", .Location = New Point(289, 9), .Size = New Size(111, 15), .ForeColor = Color.White}
        frmSettings.pluginControls.Add(labelS)
    End Sub

    Private Sub comboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboBox.SelectedValueChanged
        My.Settings.HotKey = [Enum].Parse(GetType(Keys), comboBox.SelectedItem)
        My.Settings.Index = comboBox.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Sub checkBox_Disposed(sender As Object, e As EventArgs) Handles checkBox.Disposed
        frmSettings.pluginControls.Remove(checkBox)
        checkBox = New NSCheckBox() With {.Text = "Mouse Jailed Enable", .Location = New Point(289, 34), .Size = New Size(266, 24), .ForeColor = Color.White, .Font = New Font("Segoe UI", 10, FontStyle.Regular), .Checked = My.Settings.AutoEnable}
        frmSettings.pluginControls.Add(checkBox)
    End Sub

    Private Sub checkBox_CheckedChanged(sender As Object) Handles checkBox.CheckedChanged
        My.Settings.AutoEnable = checkBox.Checked
        My.Settings.Save()
        modActivated = checkBox.Checked
    End Sub
End Class
