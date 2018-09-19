Imports PluginContract
Imports InitialDLauncher
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class CardEditorInGame
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "In-game Card Editor"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "1.0"
        End Get
    End Property

    Dim isGameRunning As Boolean = False
    Dim gameVersion As Integer = 0
    Dim d8xml, d7xml, d6xml As GameProfile
    Dim d8CardPath, d7CardPath, d6CardPath As String
    Dim label As New Label() With {.Text = $"In-game Card Editor - Press {[Enum].GetName(GetType(Keys), My.Settings.Hotkey)} to Activate", .Location = New Point(12, 70), .BackColor = Color.Transparent, .ForeColor = Color.White, .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Regular)}
    Dim frmEdit As frmEdit
    Dim WithEvents labelS As New Label() With {.Text = "In-game Card Editor", .Location = New Point(9, 69), .Size = New Size(111, 15), .ForeColor = Color.White}
    Dim WithEvents comboBox As NSComboBox

    <DllImport("user32.dll")>
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)
    Shared ReadOnly HWND_TOP As New IntPtr(0)
    Shared ReadOnly HWND_BOTTOM As New IntPtr(1)
    Const SWP_NOSIZE As UInt32 = &H1
    Const SWP_NOMOVE As UInt32 = &H2
    Const TOPMOST_FLAGS As UInt32 = SWP_NOMOVE Or SWP_NOSIZE
    <DllImport("user32.dll")>
    Public Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer,
            uFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Sub DoSomething() Implements iPlugin.DoSomething
        If File.Exists(".\UserProfiles\ID8.xml") Then
            d8xml = New GameProfile(".\UserProfiles\ID8.xml").ReadFromFile
            d8CardPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBZZ_card.bin")
        End If
        If File.Exists(".\UserProfiles\ID7.xml") Then
            d7xml = New GameProfile(".\UserProfiles\ID7.xml").ReadFromFile
            d7CardPath = If(d7xml.ConfigValues(5).FieldValue = 0, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBYD_card.bin"), Path.Combine(Path.GetDirectoryName(d7xml.GamePath), "InidCrd000.crd"))
        End If
        If File.Exists(".\UserProfiles\ID6.xml") Then
            d6xml = New GameProfile(".\UserProfiles\ID6.xml").ReadFromFile
            d6CardPath = If(d6xml.ConfigValues(5).FieldValue = 0, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeknoParrot\SBUU_card.bin"), Path.Combine(Path.GetDirectoryName(d6xml.GamePath), "InidCrd000.crd"))
        End If

        frmLauncher.pluginControls.Add(label)
        frmSettings.pluginControls.Add(labelS)

        comboBox = New NSComboBox()
        For Each i In [Enum].GetValues(GetType(Keys))
            comboBox.Items.Add(i)
        Next

        With comboBox
            .SelectedIndex = My.Settings.Index
            .Location = New Point(126, 64)
            .Size = New Size(155, 24)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End With

        frmSettings.pluginControls.Add(comboBox)
    End Sub

    Private Sub iPlugin_TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        isGameRunning = frmLauncher.isGameRunning
        gameVersion = frmLauncher.lastGame

        Try
            If isGameRunning AndAlso GetAsyncKeyState(My.Settings.Hotkey) Then
                My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
                Select Case gameVersion
                    Case 6
                        LoadCardEditor(d6CardPath, 6, If(d6xml.ConfigValues(5).FieldValue = 0, "bin", "crd"))
                    Case 7
                        LoadCardEditor(d7CardPath, 7, If(d7xml.ConfigValues(5).FieldValue = 0, "bin", "crd"))
                    Case 8
                        LoadCardEditor(d8CardPath, 8, "bin")
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadCardEditor(CardFile As String, cardVersion As Integer, cardExt As String)
        Try
            frmEdit = New frmEdit()
            frmEdit.Version = cardVersion
            frmEdit.FileName = CardFile
            frmEdit.Extension = cardExt
            frmEdit.CardEditOnly = False
            frmEdit.TopLevel = True
            frmEdit.TopMost = True
            frmEdit.Show()

            SetWindowPos(frmEdit.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS)
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
            .Location = New Point(126, 64)
            .Size = New Size(155, 24)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End With
        frmSettings.pluginControls.Add(comboBox)
    End Sub

    Private Sub labelS_Disposed(sender As Object, e As EventArgs) Handles labelS.Disposed
        frmSettings.pluginControls.Remove(labelS)
        labelS = New Label() With {.Text = "In-game Card Editor", .Location = New Point(9, 69), .Size = New Size(111, 15), .ForeColor = Color.White}
        frmSettings.pluginControls.Add(labelS)
    End Sub

    Private Sub comboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboBox.SelectedValueChanged
        My.Settings.Hotkey = [Enum].Parse(GetType(Keys), comboBox.SelectedItem)
        My.Settings.Index = comboBox.SelectedIndex
        My.Settings.Save()
        label.Text = $"In-game Card Editor - Press {[Enum].GetName(GetType(Keys), My.Settings.Hotkey)} to Activate"
    End Sub
End Class
