Public Class ComboboxItem

    Public Property Text() As String
    Public Property Value() As Object

    Public Overrides Function ToString() As String
        Return Text
    End Function

End Class
