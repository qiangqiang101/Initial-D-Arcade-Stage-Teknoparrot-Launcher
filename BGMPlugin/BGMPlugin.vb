Imports PluginContract
Imports InitialDLauncher
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class BGMPlugin
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "BGM Plugin"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "2.0"
        End Get
    End Property

    Dim mp3File As String = ".\Plugins\IDAS\launcher.mp3"
    Dim audio As AudioFile
    Dim isGameRunning As Boolean = False
    Dim status As Integer = -1
    Dim WithEvents nsTrackbar As New NSTrackBar() With {.Maximum = 1000, .Minimum = 0, .Value = My.Settings.Volume, .Location = New Point(126, 4), .Size = New Size(155, 23)}
    Dim WithEvents label As New Label() With {.Text = "BGM", .Location = New Point(9, 9), .Size = New Size(111, 15), .ForeColor = Color.White}

    Public Sub DoSomething() Implements iPlugin.DoSomething
        If File.Exists(mp3File) Then
            audio = New AudioFile(mp3File)
            audio.Play()
            audio.SetVolume(My.Settings.Volume)
            status = 0

            frmSettings.pluginControls.Add(label)
            frmSettings.pluginControls.Add(nsTrackbar)
        End If
    End Sub

    Private Sub iPlugin_TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        isGameRunning = frmLauncher.isGameRunning

        Try
            If File.Exists(mp3File) Then
                If isGameRunning Then
                    audio.Pause()
                    status = 1
                Else
                    If status = 1 Then
                        audio.Resume()
                        status = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub nsTrackbar_Scroll(sender As Object) Handles nsTrackbar.Scroll
        My.Settings.Volume = nsTrackbar.Value
        My.Settings.Save()
        If status = 0 Then audio.SetVolume(My.Settings.Volume)
    End Sub

    Private Sub nsTrackbar_Disposed(sender As Object, e As EventArgs) Handles nsTrackbar.Disposed
        frmSettings.pluginControls.Remove(nsTrackbar)
        nsTrackbar = New NSTrackBar() With {.Maximum = 1000, .Minimum = 0, .Value = My.Settings.Volume, .Location = New Point(126, 4), .Size = New Size(155, 23)}
        frmSettings.pluginControls.Add(nsTrackbar)
    End Sub

    Private Sub label_Disposed(sender As Object, e As EventArgs) Handles label.Disposed
        frmSettings.pluginControls.Remove(label)
        label = New Label() With {.Text = "BGM", .Location = New Point(9, 9), .Size = New Size(111, 15), .ForeColor = Color.White}
        frmSettings.pluginControls.Add(label)
    End Sub
End Class
