Imports System.Drawing

Public Class IDAvatar

    Private _bitmap As Bitmap
    Public Property Bitmap() As Bitmap
        Get
            Return _bitmap
        End Get
        Set(value As Bitmap)
            _bitmap = value
        End Set
    End Property

    Private _normalHex As String
    Public Property NormalHex() As String
        Get
            Return _normalHex
        End Get
        Set(value As String)
            _normalHex = value
        End Set
    End Property

    Public Property Tag() As String
        Get
            Return _normalHex
        End Get
        Set(value As String)
            _normalHex = value
        End Set
    End Property

    Public ReadOnly Property ReversedHex() As String
        Get
            Dim result As String = _normalHex
            If Not _normalHex.Length = 2 Then
                Dim bcd As String = _normalHex.Substring(1, 3)
                Dim a As String = _normalHex.Substring(0, 1)
                result = bcd & a
            End If
            Return result
        End Get
    End Property

    Public Sub New(img As Image)
        Bitmap = img
    End Sub
End Class
