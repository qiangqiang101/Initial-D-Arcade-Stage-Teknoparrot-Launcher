Imports PluginContract
Imports InitialDLauncher
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Drawing

Public Class Mouse
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "Hyde the Mouse"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "1.0"
        End Get
    End Property

    Public Sub DoSomething() Implements iPlugin.DoSomething

    End Sub

    Dim isGameRunning As Boolean = False

    Public Sub TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        isGameRunning = frmLauncher.isGameRunning

        Try
            If isGameRunning Then
                ShowCursor(False)
            Else
                ShowCursor(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    <DllImport("user32")>
    Private Shared Function ClipCursor(ByVal lpRect As RECT) As Int32
    End Function
    <DllImport("user32")>
    Private Shared Function ShowCursor(ByVal bShow As Int32) As Int32
    End Function
    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32
    End Structure
    Private MouseTrap As RECT

    Public Sub RestoreCursor(ByRef ThisForm As System.Windows.Forms.Form)
        With MouseTrap
            .Top = 0
            .Left = 0
            .Right = Screen.PrimaryScreen.Bounds.Width
            .Bottom = Screen.PrimaryScreen.Bounds.Height
        End With

        ClipCursor(MouseTrap)
    End Sub
End Class
