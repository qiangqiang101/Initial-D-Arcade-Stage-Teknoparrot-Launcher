Public Class MyFlowLayoutPanel

    Private Sub FP_ControlAdded(sender As Object, e As ControlEventArgs) Handles FP.ControlAdded
        VS.Maximum = FP.VerticalScroll.Maximum
        VS.Minimum = FP.VerticalScroll.Minimum
        VS.LargeChange = FP.VerticalScroll.LargeChange
        VS.SmallChange = FP.VerticalScroll.SmallChange
    End Sub

    Private Sub FP_Scroll(sender As Object, e As ScrollEventArgs) Handles FP.Scroll
        On Error Resume Next
        VS.Value = FP.VerticalScroll.Value
    End Sub

    Private Sub FP_SizeChanged(sender As Object, e As EventArgs) Handles FP.SizeChanged
        VS.Maximum = FP.VerticalScroll.Maximum
        VS.Minimum = FP.VerticalScroll.Minimum
        VS.LargeChange = FP.VerticalScroll.LargeChange
        VS.SmallChange = FP.VerticalScroll.SmallChange
    End Sub

    Private Sub VS_Scroll(sender As Object) Handles VS.Scroll
        On Error Resume Next
        FP.VerticalScroll.Value = VS.Value
    End Sub
End Class
