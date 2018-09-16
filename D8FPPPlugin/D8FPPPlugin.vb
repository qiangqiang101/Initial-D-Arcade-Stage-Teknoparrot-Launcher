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
            Version = "1.0"
        End Get
    End Property

    Dim isGameRunning As Boolean = False
    Dim game_exe As String = Nothing
    Dim patched As Boolean = False
    Dim lastGame As Integer = 0
    Dim d8xml As GameProfile
    Dim label As New Label() With {.Text = "Initial D8 Free Play Disabler - Press F4 to Activate", .Location = New Point(10, 50), .BackColor = Color.Transparent, .ForeColor = Color.White, .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Regular)}

    <DllImport("user32.dll")>
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    'Private Declare Function IsWindowVisible Lib "user32" Alias "IsWindowVisible" (ByVal hwnd As IntPtr) As Boolean

    '<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    'Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    'End Function

    Public Sub DoSomething() Implements iPlugin.DoSomething
        If File.Exists(".\UserProfiles\ID8.xml") Then
            d8xml = New GameProfile(".\UserProfiles\ID8.xml").ReadFromFile
            game_exe = Path.GetFileNameWithoutExtension(d8xml.GamePath)
            frmLauncher.pluginControls.Add(label)
        End If
    End Sub

    Private Sub iPlugin_TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        isGameRunning = frmLauncher.isGameRunning
        lastGame = frmLauncher.lastGame

        'Dim id8 As Process() = Process.GetProcessesByName(game_exe)

        Try
            If isGameRunning AndAlso lastGame = 8 AndAlso Not patched Then
                If GetAsyncKeyState(Keys.F4) Then
                    My.Computer.Audio.Play(My.Resources.play, AudioPlayMode.Background)
                    WriteInteger(game_exe, &H13D3782, 0, 1)
                    WriteInteger(game_exe, &H13D37B0, 99)
                    patched = True
                    label.ForeColor = Color.Red
                End If

                'If Not patched AndAlso id8.Length <> 0 Then
                '    If IsWindowVisible(FindWindow(Nothing, id8(0).MainWindowTitle)) Then
                '        Threading.Thread.Sleep(3000)
                '        WriteInteger(game_exe, &H13D3782, 0, 1)
                '        WriteInteger(game_exe, &H13D37B0, 99)
                '        patched = True
                '    End If
                'End If
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
End Class
