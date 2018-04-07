Public Class Car
    Private _replaceTo As String
    Public Property ReplaceTo() As String
        Get
            Return _replaceTo
        End Get
        Set(value As String)
            _replaceTo = value
        End Set
    End Property

    Private _carColor As String
    Public Property CarColor() As String
        Get
            Return _carColor
        End Get
        Set(value As String)
            _carColor = value
        End Set
    End Property

    Private _sticker1, _sticker2, _sticker3, _sticker4 As String
    Public Property Sticker1() As String
        Get
            Return _sticker1
        End Get
        Set(value As String)
            _sticker1 = value
        End Set
    End Property
    Public Property Sticker2() As String
        Get
            Return _sticker2
        End Get
        Set(value As String)
            _sticker2 = value
        End Set
    End Property
    Public Property Sticker3() As String
        Get
            Return _sticker3
        End Get
        Set(value As String)
            _sticker3 = value
        End Set
    End Property
    Public Property Sticker4() As String
        Get
            Return _sticker4
        End Get
        Set(value As String)
            _sticker4 = value
        End Set
    End Property

    Private _plateNo As String
    Public Property PlateNo() As String
        Get
            Return _plateNo
        End Get
        Set(value As String)
            _plateNo = value
        End Set
    End Property

    Private _classCode As String
    Public Property ClassCode() As String
        Get
            Return _classCode
        End Get
        Set(value As String)
            _classCode = value
        End Set
    End Property

    Private _hiragana As String
    Public Property Hiragana() As Integer
        Get
            Return _hiragana
        End Get
        Set(value As Integer)
            _hiragana = value
        End Set
    End Property

    Private _placeName As Integer
    Public Property PlaceName() As Integer
        Get
            Return _placeName
        End Get
        Set(value As Integer)
            _placeName = value
        End Set
    End Property

    Private _fullspec As Boolean
    Public Property FullSpec() As Boolean
        Get
            Return _fullspec
        End Get
        Set(value As Boolean)
            _fullspec = value
        End Set
    End Property

    Private _engine As String
    Public Property Engine() As String
        Get
            Return _engine
        End Get
        Set(value As String)
            _engine = value
        End Set
    End Property

    Private _rollbar As String
    Public Property Rollbar() As String
        Get
            Return _rollbar
        End Get
        Set(value As String)
            _rollbar = value
        End Set
    End Property

    Private _transmission As Integer
    Public Property Transmission() As Integer
        Get
            Return _transmission
        End Get
        Set(value As Integer)
            _transmission = value
        End Set
    End Property

    Private _param As String
    Public Property Param() As String
        Get
            Return _param
        End Get
        Set(value As String)
            _param = value
        End Set
    End Property

    Private _edited As Boolean
    Public Property Edited() As Boolean
        Get
            Return _edited
        End Get
        Set(value As Boolean)
            _edited = value
        End Set
    End Property
End Class
