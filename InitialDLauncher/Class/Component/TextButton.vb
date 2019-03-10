Imports System.Drawing.Drawing2D

Public Class TextButton
    Inherits Label

    Private _normal As Color
    Public Property NormalColor() As Color
        Get
            Return _normal
        End Get
        Set(value As Color)
            _normal = value
        End Set
    End Property

    Private _mouseHover As Color
    Public Property MouseHoverColor() As Color
        Get
            Return _mouseHover
        End Get
        Set(value As Color)
            _mouseHover = value
        End Set
    End Property

    Private _disabledColor As Color
    Public Property DisabledColor() As Color
        Get
            Return _disabledColor
        End Get
        Set(value As Color)
            _disabledColor = value
        End Set
    End Property

    Private _mouseDown As Color
    Public Property MousePressedColor() As Color
        Get
            Return _mouseDown
        End Get
        Set(value As Color)
            _mouseDown = value
        End Set
    End Property

    Private _addEffect As Boolean
    Public Property AddEffect() As Boolean
        Get
            Return _addEffect
        End Get
        Set(value As Boolean)
            _addEffect = value
        End Set
    End Property

    Private _effectBefore, _effectAfter As String
    Public Property EffectBefore() As String
        Get
            Return _effectBefore
        End Get
        Set(value As String)
            _effectBefore = value
        End Set
    End Property
    Public Property EffectAfter() As String
        Get
            Return _effectAfter
        End Get
        Set(value As String)
            _effectAfter = value
        End Set
    End Property

    Private _widthX As Integer
    Public Property EffectWidth() As Integer
        Get
            Return _widthX
        End Get
        Set(value As Integer)
            _widthX = value
        End Set
    End Property

    Public ReadOnly Property Selected() As Boolean
        Get
            Return Focus()
        End Get
    End Property

    Public Event EnterPressed(sender As Object, e As EventArgs)

    Public Property P() As Control
        Get
            Return Parent
        End Get
        Set(value As Control)
            Parent = value
        End Set
    End Property

    Private _borderSize As Single = 1.0F
    Private _borderColor As Color = Color.White
    Private _drawPen As New Pen(New SolidBrush(_borderColor), _borderSize)
    Private _forColorBrush As New SolidBrush(ForeColor)
    Public Property BorderSize() As Single
        Get
            Return _borderSize
        End Get
        Set(value As Single)
            _borderSize = value
            If value = 0 Then
                _drawPen.Color = Color.Transparent
            Else
                _drawPen.Color = _borderColor
                _drawPen.Width = value
            End If
            MyBase.OnTextChanged(EventArgs.Empty)
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            If Not _borderSize = 0 Then
                _drawPen.Color = value
            End If

            Invalidate()
        End Set
    End Property

    Public Sub New()
        P = Parent
        NormalColor = Color.Gray
        MouseHoverColor = Color.White
        DisabledColor = Color.DarkGray
        MousePressedColor = Color.Gold
        AddEffect = False
        EffectWidth = 43
        EffectBefore = Nothing
        EffectAfter = " <<"
        Font = New Font("Segoe UI", 20)
        Size = New Size(488, 38)
        SetStyle(ControlStyles.Selectable, True)
        'AddKeyDownEvent(Me)
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        ForeColor = MousePressedColor
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        ForeColor = MouseHoverColor
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        If Not DesignMode Then
            ForeColor = MouseHoverColor
            If AddEffect Then
                Size = New Size(Size.Width + _widthX, Size.Height)
                Text = EffectBefore & Text & EffectAfter
            End If
            My.Computer.Audio.Play(My.Resources._select, AudioPlayMode.Background)
        End If
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        If Not DesignMode Then
            ForeColor = NormalColor
            If AddEffect Then
                If Not IsNothing(EffectBefore) Then Text = Text.Replace(EffectBefore, "")
                If Not IsNothing(EffectAfter) Then Text = Text.Replace(EffectAfter, "")
                Size = New Size(Size.Width - _widthX, Size.Height)
            End If
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ForeColor = MousePressedColor
            RaiseEvent EnterPressed(Me, e)
        End If
    End Sub

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ForeColor = MouseHoverColor
        End If
    End Sub

    Public Sub AddKeyDownEvent(ByVal obj As Control)
        Dim ctl As Control = obj.GetNextControl(obj, True)
        Do Until ctl Is Nothing
            AddHandler ctl.KeyDown, AddressOf AllControls_KeyDown
            ctl = obj.GetNextControl(ctl, True)
        Loop
    End Sub

    Public Sub AllControls_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            SendKeys.SendWait("+{TAB}")
        End If

        If e.KeyCode = Keys.Down Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Protected Overrides Sub OnForeColorChanged(e As EventArgs)
        _forColorBrush.Color = ForeColor
        MyBase.OnForeColorChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnTextAlignChanged(e As EventArgs)
        MyBase.OnTextAlignChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
    End Sub

    Private drawSize As SizeF
    Private point As PointF
    Private drawPath As New GraphicsPath
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If Text.Length = 0 Then Exit Sub

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality

        drawSize = e.Graphics.MeasureString(Text, Font, New PointF(), StringFormat.GenericTypographic)

        If AutoSize Then
            point.X = Padding.Left
            point.Y = Padding.Top
        Else
            If TextAlign = ContentAlignment.TopLeft OrElse TextAlign = ContentAlignment.MiddleLeft OrElse TextAlign = ContentAlignment.BottomLeft Then
                point.X = Padding.Left
            ElseIf TextAlign = ContentAlignment.TopCenter OrElse TextAlign = ContentAlignment.MiddleCenter OrElse TextAlign = ContentAlignment.BottomCenter Then
                point.X = (Width - drawSize.Width) / 2
            Else
                point.X = Width - (Padding.Right + drawSize.Width)
            End If

            If TextAlign = ContentAlignment.TopLeft OrElse TextAlign = ContentAlignment.TopCenter OrElse TextAlign = ContentAlignment.TopRight Then
                point.Y = Padding.Top
            ElseIf TextAlign = ContentAlignment.MiddleLeft OrElse TextAlign = ContentAlignment.MiddleCenter OrElse TextAlign = ContentAlignment.MiddleRight Then
                point.Y = (Height - drawSize.Height) / 2
            Else
                point.Y = Height - (Padding.Bottom + drawSize.Height)
            End If
        End If

        Dim fontSize As Single = e.Graphics.DpiY * Font.SizeInPoints / 72
        drawPath.Reset()
        drawPath.AddString(Text, Font.FontFamily, CInt(Font.Style), fontSize, point, StringFormat.GenericTypographic)

        e.Graphics.DrawPath(_drawPen, drawPath)
        e.Graphics.FillPath(_forColorBrush, drawPath)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If _forColorBrush IsNot Nothing Then _forColorBrush.Dispose()
            If drawPath IsNot Nothing Then drawPath.Dispose()
            If _drawPen IsNot Nothing Then _drawPen.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
