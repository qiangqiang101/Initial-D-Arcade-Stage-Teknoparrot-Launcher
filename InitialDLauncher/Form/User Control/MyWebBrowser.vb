Public Class MyWebBrowser

    Public Property HTMLString As String
    Public Property VerticalScrollBar() As Boolean
        Get
            Return VS.Visible
        End Get
        Set(value As Boolean)
            VS.Visible = value
        End Set
    End Property
    Public Property HorizontalScrollBar() As Boolean
        Get
            Return HS.Visible
        End Get
        Set(value As Boolean)
            HS.Visible = value
        End Set
    End Property

    Private Sub WB_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WB.DocumentCompleted
        VS.Maximum = WB.Document.Body.ScrollRectangle.Height
        HS.Maximum = WB.Document.Body.ScrollRectangle.Width
    End Sub

    Private Sub VS_Scroll(sender As Object) Handles VS.Scroll
        On Error Resume Next
        WB.Document.Window.ScrollTo(HS.Value, VS.Value)
    End Sub

    Private Sub Mybase_MouseWheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 15))

        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value
    End Sub

    Private Sub HS_Scroll(sender As Object) Handles HS.Scroll
        On Error Resume Next
        WB.Document.Window.ScrollTo(HS.Value, VS.Value)
    End Sub
End Class
