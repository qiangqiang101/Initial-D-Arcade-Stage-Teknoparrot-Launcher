Imports PluginContract
Imports InitialDLauncher
Imports System.IO

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
            Version = "1.1a"
        End Get
    End Property

    Dim mp3File As String = String.Format("{0}\Plugins\launcher.mp3", My.Application.Info.DirectoryPath)
    Dim audio As AudioFile
    Dim isGameRunning As Boolean = False
    Dim status As Integer = -1

    Public Sub DoSomething() Implements iPlugin.DoSomething
        If File.Exists(mp3File) Then
            audio = New AudioFile(mp3File)
            audio.Play()
            audio.SetVolume(500)
            status = 0
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
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
