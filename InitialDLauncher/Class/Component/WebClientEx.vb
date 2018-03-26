Imports System.Net

Public Class WebClientEx
    Inherits WebClient
    Public Property Timeout() As Integer
        Get
            Return m_Timeout
        End Get
        Set
            m_Timeout = Value
        End Set
    End Property
    Private m_Timeout As Integer

    Protected Overrides Function GetWebRequest(address As Uri) As WebRequest
        Dim request As WebRequest = MyBase.GetWebRequest(address)
        If request IsNot Nothing Then
            request.Timeout = Timeout
        End If
        Return request
    End Function

    Public Sub New()
        ' the standard HTTP Request Timeout default
        Timeout = 100000
    End Sub
End Class