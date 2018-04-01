Imports System.Windows.Forms

Public Interface iPlugin
    ReadOnly Property Name() As String
    ReadOnly Property Author() As String
    ReadOnly Property Version() As String
    Sub DoSomething()
    Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
End Interface