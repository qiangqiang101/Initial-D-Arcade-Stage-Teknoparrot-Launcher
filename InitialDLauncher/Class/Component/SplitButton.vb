Imports System.Windows.Forms.VisualStyles

Public Class SplitButton
    Inherits Button

    Private _state As PushButtonState
    Private Const PushButtonWidth As Integer = 14
    Private Shared BorderSize As Integer = SystemInformation.Border3DSize.Width * 2
    Private skipNextOpen As Boolean = False
    Private dropDownRectangle As New Rectangle
    Private _showSplit As Boolean = True

    Public Sub New()
        Me.AutoSize = True
    End Sub
    Public Property ShowSplit() As Boolean
        Get
            Return Me._showSplit
        End Get
        Set(ByVal value As Boolean)
            If value <> Me._showSplit Then
                Me._showSplit = value
                Me.Invalidate()
                If Me.Parent IsNot Nothing Then
                    Me.Parent.PerformLayout()
                End If
            End If
        End Set
    End Property
    Private Property State() As PushButtonState
        Get
            Return Me._state
        End Get
        Set(ByVal value As PushButtonState)
            If value <> Me._state Then
                Me._state = value
                Me.Invalidate()
            End If
        End Set
    End Property
    Public Overrides Function GetPreferredSize(ByVal proposedSize As System.Drawing.Size) As System.Drawing.Size
        GetPreferredSize = MyBase.GetPreferredSize(proposedSize)
        If Me._showSplit AndAlso Not String.IsNullOrEmpty(Me.Text) AndAlso TextRenderer.MeasureText(Me.Text, Me.Font).Width + PushButtonWidth > GetPreferredSize.Width Then
            GetPreferredSize += New Size(PushButtonWidth + BorderSize * 2, 0)
        End If
    End Function
    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (keyData.Equals(Keys.Down) AndAlso Me._showSplit) Then Return True
        Return MyBase.IsInputKey(keyData)
    End Function
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        If Not Me._showSplit Then
            MyBase.OnGotFocus(e)
        ElseIf Not State = PushButtonState.Pressed AndAlso Not State = PushButtonState.Disabled Then
            State = PushButtonState.Default
        End If
    End Sub
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        If Not Me._showSplit Then
            MyBase.OnLostFocus(e)
        ElseIf State <> PushButtonState.Pressed AndAlso State <> PushButtonState.Disabled Then
            State = PushButtonState.Normal
        End If
    End Sub
    Protected Overrides Sub OnKeyDown(ByVal kevent As System.Windows.Forms.KeyEventArgs)
        If Me._showSplit Then
            If kevent.KeyCode = Keys.Down Then
                ShowContextMenuStrip()
            ElseIf kevent.KeyCode = Keys.Space AndAlso kevent.Modifiers = Keys.None Then
                State = PushButtonState.Pressed
            End If
        End If
        MyBase.OnKeyDown(kevent)
    End Sub
    Protected Overrides Sub OnKeyUp(ByVal kevent As System.Windows.Forms.KeyEventArgs)
        If kevent.KeyCode = Keys.Space Then
            If Control.MouseButtons = MouseButtons.None Then
                State = PushButtonState.Normal
            End If
        End If
        MyBase.OnKeyUp(kevent)
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not Me._showSplit Then
            MyBase.OnMouseDown(e)
        ElseIf dropDownRectangle.Contains(e.Location) Then
            ShowContextMenuStrip()
        Else
            State = PushButtonState.Pressed
        End If
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not Me._showSplit Then
            MyBase.OnMouseUp(e)
        ElseIf ContextMenuStrip Is Nothing OrElse Not ContextMenuStrip.Visible Then
            SetButtonDrawState()
            If Bounds.Contains(Parent.PointToClient(Cursor.Position)) AndAlso Not dropDownRectangle.Contains(e.Location) Then
                OnClick(New EventArgs())
            End If
        End If
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        If Not ShowSplit Then
            MyBase.OnMouseEnter(e)
        ElseIf State <> PushButtonState.Pressed AndAlso State <> PushButtonState.Disabled Then
            State = PushButtonState.Hot
        End If
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        If Not ShowSplit Then
            MyBase.OnMouseLeave(e)
        ElseIf State <> PushButtonState.Pressed AndAlso State <> PushButtonState.Disabled Then
            If Focused Then
                State = PushButtonState.Default
            Else
                State = PushButtonState.Normal
            End If
        End If
    End Sub
    Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pevent)
        If Me._showSplit Then
            Dim g As Graphics = pevent.Graphics
            Dim bounds As Rectangle = Me.ClientRectangle

            'draw the button background as according to the current state.
            If State <> PushButtonState.Pressed AndAlso IsDefault AndAlso Not Application.RenderWithVisualStyles Then
                Dim backgroundBounds As Rectangle = bounds
                backgroundBounds.Inflate(-1, -1)
                ButtonRenderer.DrawButton(g, backgroundBounds, State)
                'button renderer doesnt draw the black frame when themes are off =(
                g.DrawRectangle(SystemPens.WindowFrame, 0, 0, bounds.Width - 1, bounds.Height - 1)
            Else
                ButtonRenderer.DrawButton(g, bounds, State)
            End If

            'calculate the current dropdown rectangle.
            dropDownRectangle = New Rectangle(bounds.Right - PushButtonWidth - 1, BorderSize, PushButtonWidth, bounds.Height - BorderSize * 2)
            Dim internalBorder As Integer = BorderSize
            Dim focusRect As New Rectangle(internalBorder, internalBorder, bounds.Width - dropDownRectangle.Width - internalBorder, bounds.Height - (internalBorder * 2))
            Dim drawSplitLine As Boolean = State = PushButtonState.Hot OrElse State = PushButtonState.Pressed OrElse Not Application.RenderWithVisualStyles
            If RightToLeft = System.Windows.Forms.RightToLeft.Yes Then
                dropDownRectangle.X = bounds.Left + 1
                focusRect.X = dropDownRectangle.Right
                If drawSplitLine Then
                    'draw two lines at the edge of the dropdown button
                    g.DrawLine(SystemPens.ButtonShadow, bounds.Left + PushButtonWidth, BorderSize, bounds.Left + PushButtonWidth, bounds.Bottom - BorderSize)
                    g.DrawLine(SystemPens.ButtonFace, bounds.Left + PushButtonWidth + 1, BorderSize, bounds.Left + PushButtonWidth + 1, bounds.Bottom - BorderSize)
                End If
            ElseIf drawSplitLine Then
                'draw two lines at the edge of the dropdown button
                g.DrawLine(SystemPens.ButtonShadow, bounds.Right - PushButtonWidth, BorderSize, bounds.Right - PushButtonWidth, bounds.Bottom - BorderSize)
                g.DrawLine(SystemPens.ButtonFace, bounds.Right - PushButtonWidth - 1, BorderSize, bounds.Right - PushButtonWidth - 1, bounds.Bottom - BorderSize)
            End If

            'Draw an arrow in the correct location
            Dim middle As New Point(dropDownRectangle.Left + dropDownRectangle.Width / 2, dropDownRectangle.Top + dropDownRectangle.Height / 2)
            'if the width is odd - favor pushing it over one pixel right.
            middle.X += dropDownRectangle.Width Mod 2
            Dim arrow As Point() = New Point() {New Point(middle.X - 2, middle.Y - 1), New Point(middle.X + 3, middle.Y - 1), New Point(middle.X, middle.Y + 2)}
            g.FillPolygon(SystemBrushes.ControlText, arrow)

            'Figure out how to draw the text
            Dim formatFlags As TextFormatFlags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter
            'If we dont' use mnemonic, set formatFlag to NoPrefix as this will show ampersand.
            If Not UseMnemonic Then
                formatFlags = formatFlags Or TextFormatFlags.NoPrefix
            ElseIf Not ShowKeyboardCues Then
                formatFlags = formatFlags Or TextFormatFlags.HidePrefix
            End If
            If Not String.IsNullOrEmpty(Me.Text) Then
                TextRenderer.DrawText(g, Text, Font, focusRect, SystemColors.ControlText, formatFlags)
            End If

            'draw the focus rectangle.
            If State <> PushButtonState.Pressed AndAlso Focused Then
                ControlPaint.DrawFocusRectangle(g, focusRect)
            End If
        End If
    End Sub
    Private Sub ShowContextMenuStrip()
        If skipNextOpen Then
            'we were called because we're closing the context menu strip
            'when clicking the dropdown button.
            skipNextOpen = False
        Else
            State = PushButtonState.Pressed
            If ContextMenuStrip IsNot Nothing Then
                AddHandler ContextMenuStrip.Closing, AddressOf ContextMenuStrip_Closing
                ContextMenuStrip.Show(Me, New Point(0, Height), ToolStripDropDownDirection.BelowRight)
            End If
        End If
    End Sub
    Private Sub ContextMenuStrip_Closing(ByVal sender As Object, ByVal e As ToolStripDropDownClosingEventArgs)
        Dim cms As ContextMenuStrip = CType(sender, ContextMenuStrip)
        If cms IsNot Nothing Then
            RemoveHandler cms.Closing, AddressOf ContextMenuStrip_Closing
        End If
        SetButtonDrawState()
        If e.CloseReason = ToolStripDropDownCloseReason.AppClicked Then
            skipNextOpen = dropDownRectangle.Contains(Me.PointToClient(Cursor.Position))
        End If
    End Sub
    Private Sub SetButtonDrawState()
        If Bounds.Contains(Parent.PointToClient(Cursor.Position)) Then
            State = PushButtonState.Hot
        ElseIf Focused Then
            State = PushButtonState.Default
        Else
            State = PushButtonState.Normal
        End If
    End Sub
End Class
