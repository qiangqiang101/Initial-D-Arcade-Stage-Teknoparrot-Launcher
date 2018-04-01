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
            Version = "1.0a"
        End Get
    End Property

    Dim mp3File As String = String.Format("{0}\Plugins\launcher.mp3", My.Application.Info.DirectoryPath)
    Dim audio = frmLauncher.audio

    Public Sub DoSomething() Implements iPlugin.DoSomething
        If File.Exists(mp3File) Then
            frmLauncher.mp3File = mp3File
            audio = New AudioFile(mp3File)
            audio.Play()
            audio.SetVolume(500)
        End If
    End Sub
End Class
