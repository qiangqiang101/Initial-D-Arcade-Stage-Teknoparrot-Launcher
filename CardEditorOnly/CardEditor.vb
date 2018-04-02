Imports PluginContract
Imports System.Windows.Forms
Imports System.IO
Imports InitialDLauncher

Public Class CardEditor
    Implements iPlugin

    Public ReadOnly Property Author As String Implements iPlugin.Author
        Get
            Author = "I'm Not MentaL"
        End Get
    End Property

    Public ReadOnly Property Name As String Implements iPlugin.Name
        Get
            Name = "Card Editor Only"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements iPlugin.Version
        Get
            Version = "1.0"
        End Get
    End Property

    Dim fe As frmEdit = Nothing

    Public Sub DoSomething() Implements iPlugin.DoSomething
        frmLauncher.hideMe = False
        Dim ofd As New OpenFileDialog()
        Dim result As DialogResult = ofd.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Try
                Try
                    fe = New frmEdit()

                    fe.FileName = ofd.FileName
                    fe.Extension = Path.GetExtension(ofd.FileName).Replace(".", "")
                    Select Case fe.Extension
                        Case "bin"
                            fe.Version = GetCardVersion(GetHex(ofd.FileName, &H50, 2))
                        Case "crd"
                            fe.Version = GetCardVersion(GetHex(ofd.FileName, &H14, 2))
                    End Select
                    fe.Show()
                Catch ex As Exception
                    MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
                End Try
            Catch ex As Exception
                MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Public Sub TimerTick(sender As Object, e As EventArgs) Implements iPlugin.TimerTick
        If Not frmLauncher.cheat Then frmLauncher.cheat = True
        If fe.IsDisposed Then frmLauncher.endMe = True
    End Sub
End Class
