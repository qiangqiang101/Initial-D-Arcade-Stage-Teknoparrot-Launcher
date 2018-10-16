Public Class Avatar
    Inherits PictureBox

    Private _face, _hair, _eyes, _mouth, _shades, _acc, _coat, _frame, i As Image
    Public Property Face() As Image
        Get
            Return _face
        End Get
        Set(value As Image)
            _face = value
        End Set
    End Property
    Public Property Hair() As Image
        Get
            Return _hair
        End Get
        Set(value As Image)
            _hair = value
        End Set
    End Property
    Public Property Eyes() As Image
        Get
            Return _eyes
        End Get
        Set(value As Image)
            _eyes = value
        End Set
    End Property
    Public Property Mouth() As Image
        Get
            Return _mouth
        End Get
        Set(value As Image)
            _mouth = value
        End Set
    End Property
    Public Property Shades() As Image
        Get
            Return _shades
        End Get
        Set(value As Image)
            _shades = value
        End Set
    End Property
    Public Property Accessory() As Image
        Get
            Return _acc
        End Get
        Set(value As Image)
            _acc = value
        End Set
    End Property
    Public Property Coat() As Image
        Get
            Return _coat
        End Get
        Set(value As Image)
            _coat = value
        End Set
    End Property
    Public Property Frame() As Image
        Get
            Return _frame
        End Get
        Set(value As Image)
            _frame = value
        End Set
    End Property

    Public Sub ChangeAccessoryImage(image As Bitmap)
        If _acc IsNot Nothing Then _acc.Dispose()
        _acc = Nothing
        _acc = image
    End Sub

    Public Sub ChangeHairImage(image As Bitmap)
        If _hair IsNot Nothing Then _hair.Dispose()
        _hair = Nothing
        _hair = image
    End Sub

    Public Sub ChangeEyesImage(image As Bitmap)
        If _eyes IsNot Nothing Then _eyes.Dispose()
        _eyes = Nothing
        _eyes = image
    End Sub

    Public Sub ChangeMouthImage(image As Bitmap)
        If _mouth IsNot Nothing Then _mouth.Dispose()
        _mouth = Nothing
        _mouth = image
    End Sub

    Public Sub ChangeFaceImage(image As Bitmap)
        If _face IsNot Nothing Then _face.Dispose()
        _face = Nothing
        _face = image
    End Sub

    Public Sub ChangeShadesImage(image As Bitmap)
        If _shades IsNot Nothing Then _shades.Dispose()
        _shades = Nothing
        _shades = image
    End Sub

    Public Sub ChangeCoatImage(image As Bitmap)
        If _coat IsNot Nothing Then _coat.Dispose()
        _coat = Nothing
        _coat = image
    End Sub

    Public Sub ChangeFrameImage(image As Bitmap)
        If _frame IsNot Nothing Then _frame.Dispose()
        _frame = Nothing
        _frame = image
    End Sub

    Public Sub RefreshImage()
        Try
            If Not i Is Nothing Then i.Dispose()
            i = New Bitmap(240, 240)
            Dim g As Graphics = Graphics.FromImage(i)
            If Not _frame Is Nothing Then g.DrawImage(_frame, 0, 0)
            If Not _face Is Nothing Then g.DrawImage(_face, 0, 0)
            If Not _mouth Is Nothing Then g.DrawImage(_mouth, 0, 0)
            If Not _eyes Is Nothing Then g.DrawImage(_eyes, 0, 0)
            If Not _shades Is Nothing Then g.DrawImage(_shades, 0, 0)
            If Not _coat Is Nothing Then g.DrawImage(_coat, 0, 0)
            If Not _acc Is Nothing Then g.DrawImage(_acc, 0, 0)
            If Not _hair Is Nothing Then g.DrawImage(_hair, 0, 0)
            g.Dispose()
            BackgroundImage = i
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Function ScaleImage(ByVal OldImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer) As System.Drawing.Image
        Dim NewHeight As Integer = TargetHeight
        Dim NewWidth As Integer = NewHeight / OldImage.Height * OldImage.Width
        If NewWidth > TargetWidth Then
            NewWidth = TargetWidth
            NewHeight = NewWidth / OldImage.Width * OldImage.Height
        End If
        Return New Bitmap(OldImage, NewWidth, NewHeight)
    End Function
End Class
