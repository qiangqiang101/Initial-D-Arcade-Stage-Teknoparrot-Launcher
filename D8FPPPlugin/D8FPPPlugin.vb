Imports PluginContract
Imports InitialDLauncher
Imports System.IO
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class D8FPPPlugin
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "Initial D8 Free Play Patch"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "2.0"
        End Get
    End Property

    Dim isGameRunning As Boolean = False
    Dim game_exe As String = Nothing
    Dim patched As Boolean = False
    Dim lastGame As Integer = 0
    Dim d8xml As GameProfile
    Dim WithEvents label As New Label() With {.Text = $"Initial D8 Free Play Patch - Press {[Enum].GetName(GetType(Keys), My.Settings.HotKey)} to Activate", .Location = New Point(12, 50), .BackColor = Color.Transparent, .ForeColor = Color.White, .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Regular)}
    Dim WithEvents labelS As New Label() With {.Text = "FreePlay Patch", .Location = New Point(9, 39), .Size = New Size(111, 15), .ForeColor = Color.White}
    Dim WithEvents comboBox As NSComboBox
    <DllImport("user32.dll")>
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Public Sub DoSomething() Implements iPlugin.DoSomething
        If File.Exists(".\UserProfiles\ID8.xml") Then
            d8xml = New GameProfile(".\UserProfiles\ID8.xml").ReadFromFile
            game_exe = Path.GetFileNameWithoutExtension(d8xml.GamePath)
            frmLauncher.pluginControls.Add(label)
            frmSettings.pluginControls.Add(labelS)

            comboBox = New NSComboBox()
            For Each i In [Enum].GetValues(GetType(Keys))
                comboBox.Items.Add(i)
            Next

            With comboBox
                .SelectedIndex = My.Settings.Index
                .Location = New Point(126, 34)
                .Size = New Size(155, 24)
                .Font = New Font("Segoe UI", 10, FontStyle.Regular)
            End With

            frmSettings.pluginControls.Add(comboBox)
        End If
    End Sub

    Private Sub iPlugin_TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        isGameRunning = frmLauncher.isGameRunning
        lastGame = frmLauncher.lastGame

        Try
            If isGameRunning AndAlso lastGame = 8 AndAlso Not patched Then

                If GetAsyncKeyState(My.Settings.HotKey) Then
                    My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
                    WriteInteger(game_exe, &H13D3782, 0, 1)
                    WriteInteger(game_exe, &H13D37B0, 99)
                    patched = True
                    label.ForeColor = Color.Red
                End If
            End If
            If Not isGameRunning Then
                patched = False
                label.ForeColor = Color.White
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
            .Location = New Point(126, 34)
            .Size = New Size(155, 24)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End With
        frmSettings.pluginControls.Add(comboBox)
    End Sub

    Private Sub labelS_Disposed(sender As Object, e As EventArgs) Handles labelS.Disposed
        frmSettings.pluginControls.Remove(labelS)
        labelS = New Label() With {.Text = "FreePlay Patch", .Location = New Point(9, 39), .Size = New Size(111, 15), .ForeColor = Color.White}
        frmSettings.pluginControls.Add(labelS)
    End Sub

    Private Sub comboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboBox.SelectedValueChanged
        My.Settings.HotKey = [Enum].Parse(GetType(Keys), comboBox.SelectedItem)
        My.Settings.Index = comboBox.SelectedIndex
        My.Settings.Save()
        label.Text = $"Initial D8 Free Play Patch - Press {[Enum].GetName(GetType(Keys), My.Settings.HotKey)} to Activate"
    End Sub
End Class
