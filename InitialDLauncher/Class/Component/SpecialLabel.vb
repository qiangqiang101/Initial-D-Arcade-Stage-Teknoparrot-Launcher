Public Class SpecialLabel
    Inherits Label

    Public Property P() As Control
        Get
            Return Parent
        End Get
        Set(value As Control)
            Parent = value
        End Set
    End Property

    Public Sub New()
        P = Parent
    End Sub

    Protected Overrides Sub OnLocationChanged(e As EventArgs)
        MyBase.OnLocationChanged(e)
        Location = New Point(0, 0)
    End Sub
End Class
