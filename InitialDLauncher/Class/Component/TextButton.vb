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
End Class
