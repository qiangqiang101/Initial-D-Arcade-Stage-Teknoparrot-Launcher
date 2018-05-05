Imports System.Drawing.Imaging

Public Class GifImage
    Private gifImage As Image
    Private dimension As FrameDimension
    Private frameCount As Integer
    Private currentFrame As Integer = -1
    Private reverse As Boolean
    Private [step] As Integer = 1

    Public Sub New(path As String)
        gifImage = Image.FromFile(path)
        'initialize
        dimension = New FrameDimension(gifImage.FrameDimensionsList(0))
        'gets the GUID
        'total frames in the animation
        frameCount = gifImage.GetFrameCount(dimension)
    End Sub

    Public Sub New(picture As Bitmap)
        gifImage = picture
        'initialize
        dimension = New FrameDimension(gifImage.FrameDimensionsList(0))
        'gets the GUID
        'total frames in the animation
        frameCount = gifImage.GetFrameCount(dimension)
    End Sub

    Public Sub New(picture As Object)
        gifImage = picture
        'initialize
        dimension = New FrameDimension(gifImage.FrameDimensionsList(0))
        'gets the GUID
        'total frames in the animation
        frameCount = gifImage.GetFrameCount(dimension)
    End Sub

    Public Property ReverseAtEnd() As Boolean
        'whether the gif should play backwards when it reaches the end
        Get
            Return reverse
        End Get
        Set
            reverse = Value
        End Set
    End Property

    Public Function GetNextFrame() As Image

        currentFrame += [step]

        'if the animation reaches a boundary...
        If currentFrame >= frameCount OrElse currentFrame < 1 Then
            If reverse Then
                [step] *= -1
                '...reverse the count
                'apply it
                currentFrame += [step]
            Else
                currentFrame = 0
                '...or start over
            End If
        End If
        Return GetFrame(currentFrame)
    End Function

    Public Function GetFrame(index As Integer) As Image
        gifImage.SelectActiveFrame(dimension, index)
        'find the frame
        Return DirectCast(gifImage.Clone(), Image)
        'return a copy of it
    End Function
End Class