Imports PluginContract
Imports InitialDLauncher

Public Class CheatsAlwaysEnable
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "Cheats Always Enable"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "1.0"
        End Get
    End Property

    Public Sub DoSomething() Implements iPlugin.DoSomething
        frmLauncher.cheat = True
    End Sub
End Class
