Public Class FieldInformationItem

    Public Enum FieldType
        Text
        Bool
        Input
    End Enum

    Public Property Type() As FieldType
    Public Property CategoryName() As String
    Public Property FieldName() As String
    Public Property FieldValue() As String
    Public Property _FieldType() As String

    Private Sub FieldInformationItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Type
            Case FieldType.Text
                TextField.Visible = True
            Case FieldType.Bool
                BoolField.Visible = True
            Case FieldType.Input
                TextField.Visible = True
                TextField.Tag = Tag
        End Select
    End Sub
End Class
