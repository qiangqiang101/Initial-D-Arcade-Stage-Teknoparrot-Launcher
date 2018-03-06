Imports System.ComponentModel
Imports System.ComponentModel.Design

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
<Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", GetType(IDesigner))>
<DesignerAttribute(GetType(TransparentControlDesigner))>
Public Class TransparentControl

    Inherits Control

#Region " Field "

    Private m_transparent As Boolean
    Private m_transparentColor As Color
    Private m_opacity As Double
    Private m_minSize As Size
    Private m_backcolor As Color

#End Region

#Region " Constructor "

    Public Sub New()

        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        UpdateStyles()
        m_minSize = New Size(50, 20)
        m_transparent = False
        m_transparentColor = Color.DodgerBlue
        m_opacity = 1.0R
        m_backcolor = Color.Transparent


    End Sub

#End Region

#Region " Property "

    <System.ComponentModel.Browsable(False)>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    <System.ComponentModel.DefaultValue(GetType(Color), "Transparent")>
    <System.ComponentModel.Description("Set background color.")>
    <System.ComponentModel.Category("Control Style")>
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return m_backcolor
        End Get
        Set(ByVal value As System.Drawing.Color)
            m_backcolor = value
            Refresh()
        End Set
    End Property

    <System.ComponentModel.Browsable(True)>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    <System.ComponentModel.DefaultValue(1.0R)>
    <System.ComponentModel.TypeConverter(GetType(OpacityConverter))>
    <System.ComponentModel.Description("Set the opacity percentage of the control.")>
    <System.ComponentModel.Category("Control Style")>
    Public Overridable Property Opacity() As Double
        Get
            Return m_opacity
        End Get
        Set(ByVal value As Double)
            If value = m_opacity Then
                Return
            End If
            m_opacity = value
            UpdateStyles()
            Refresh()
        End Set
    End Property

    <System.ComponentModel.Browsable(True)>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    <System.ComponentModel.DefaultValue(GetType(Boolean), "False")>
    <System.ComponentModel.Description("Enable control trnasparency.")>
    <System.ComponentModel.Category("Control Style")>
    Public Overridable Property Transparent() As Boolean
        Get
            Return m_transparent
        End Get
        Set(ByVal value As Boolean)
            If value = m_transparent Then
                Return
            End If
            m_transparent = value
            Refresh()
        End Set
    End Property

    <System.ComponentModel.Browsable(True)>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    <System.ComponentModel.DefaultValue(GetType(Color), "DodgerBlue")>
    <System.ComponentModel.Description("Set the fill color of the control.")>
    <System.ComponentModel.Category("Control Style")>
    Public Overridable Property TransparentColor() As Color
        Get
            Return m_transparentColor
        End Get
        Set(ByVal value As Color)
            m_transparentColor = value
            Refresh()
        End Set
    End Property

    Protected Overloads Overrides ReadOnly Property DefaultSize() As Size
        Get
            Return New Size(200, 100)
        End Get
    End Property

    Public Overloads Overrides Property MinimumSize() As System.Drawing.Size
        Get
            Return m_minSize
        End Get
        Set(ByVal value As System.Drawing.Size)
            If (value <> (m_minSize)) Then
                m_minSize = value
                Refresh()
            End If
        End Set
    End Property

#End Region

#Region " Event "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        DrawBackground(e.Graphics, Me)
        DrawBorder(e.Graphics, Me)

    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub

#End Region

#Region " Method "

    Public Overridable Sub DrawBorder(ByVal g As Graphics, ByVal control As TransparentControl)
        Using p As New Pen(GetDarkColor(Me.TransparentColor, 40), 1)
            Dim rect As New Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1)
            rect.Inflate(-1, -1)
            g.DrawRectangle(p, rect)
            p.Dispose()
        End Using

    End Sub

    Public Overridable Sub DrawBackground(ByVal g As Graphics, ByVal control As TransparentControl)

        If Transparent Then

            Using sb As New SolidBrush(control.BackColor)
                g.FillRectangle(sb, control.ClientRectangle)
                sb.Dispose()

                Using sbt As New SolidBrush(Color.FromArgb(control.Opacity * 255, control.TransparentColor))
                    g.FillRectangle(sbt, control.ClientRectangle)
                    sbt.Dispose()
                End Using
            End Using

        Else

            Using sb As New SolidBrush(control.TransparentColor)
                g.FillRectangle(sb, control.ClientRectangle)
                sb.Dispose()
            End Using
        End If

    End Sub

    Private Function GetLightColor(ByVal colorIn As Color, ByVal percent As Single) As Color
        If percent < 0 OrElse percent > 100 Then
            Throw New ArgumentOutOfRangeException("percent must be between 0 and 100")
        End If
        Dim a As Int32 = colorIn.A * Me.Opacity
        Dim r As Int32 = colorIn.R + CInt(((255 - colorIn.R) / 100) * percent)
        Dim g As Int32 = colorIn.G + CInt(((255 - colorIn.G) / 100) * percent)
        Dim b As Int32 = colorIn.B + CInt(((255 - colorIn.B) / 100) * percent)
        Return Color.FromArgb(a, r, g, b)
    End Function

    Private Function GetDarkColor(ByVal colorIn As Color, ByVal percent As Single) As Color
        If percent < 0 OrElse percent > 100 Then
            Throw New ArgumentOutOfRangeException("percent must be between 0 and 100")
        End If
        Dim a As Int32 = colorIn.A * Me.Opacity
        Dim r As Int32 = colorIn.R - CInt((colorIn.R / 100) * percent)
        Dim g As Int32 = colorIn.G - CInt((colorIn.G / 100) * percent)
        Dim b As Int32 = colorIn.B - CInt((colorIn.B / 100) * percent)
        Return Color.FromArgb(a, r, g, b)
    End Function

#End Region

End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class TransparentControlDesigner

    Inherits System.Windows.Forms.Design.ParentControlDesigner

#Region " Field "

    Private lists As DesignerActionListCollection

#End Region

#Region " Property "

    Public Overrides ReadOnly Property ActionLists() As System.ComponentModel.Design.DesignerActionListCollection
        Get
            If lists Is Nothing Then
                lists = New DesignerActionListCollection()
                lists.Add(New TransparentControlActionList(Me.Component))

            End If

            Return lists
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultControlLocation() As System.Drawing.Point
        Get
            Return New Point(20, 20)
        End Get
    End Property

    Protected Overrides ReadOnly Property EnableDragRect() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property AllowGenericDragBox() As Boolean
        Get
            Return True
        End Get
    End Property

#End Region

End Class

Public Class TransparentControlActionList

    Inherits DesignerActionList

#Region " Field "
    Private designerActionUISvc As System.ComponentModel.Design.DesignerActionUIService = Nothing
    Private tc As TransparentControl
#End Region

#Region " Constructor "
    Public Sub New(ByVal component As IComponent)
        MyBase.New(component)
        tc = component
        designerActionUISvc = CType(GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
    End Sub
#End Region

#Region " Property "

    <System.ComponentModel.DefaultValue(1.0R)>
    <System.ComponentModel.TypeConverter(GetType(OpacityConverter))>
    Public Overridable Property Opacity() As Double
        Get
            Return tc.Opacity
        End Get
        Set(ByVal value As Double)
            GetPropertyByName("Opacity").SetValue(tc, value)
        End Set
    End Property

    <System.ComponentModel.DefaultValue(GetType(Boolean), "False")>
    Public Overridable Property Transparent() As Boolean
        Get
            Return tc.Transparent
        End Get
        Set(ByVal value As Boolean)
            GetPropertyByName("Transparent").SetValue(tc, value)
        End Set
    End Property

    <System.ComponentModel.DefaultValue(GetType(Color), "OliveDrab")>
    Public Overridable Property TransparentColor() As Color
        Get
            Return tc.TransparentColor
        End Get
        Set(ByVal value As Color)
            GetPropertyByName("TransparentColor").SetValue(tc, value)
        End Set
    End Property

#End Region

#Region " Function "
    Private Function GetPropertyByName(ByVal propName As String) As PropertyDescriptor

        Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(tc)(propName)
        If prop Is Nothing Then
            Throw New ArgumentException("Matching property not valid!", propName)
        Else
            Return prop
        End If
    End Function

    Public Overrides Function GetSortedActionItems() As System.ComponentModel.Design.DesignerActionItemCollection

        Dim items As New DesignerActionItemCollection()

        items.Add(New DesignerActionPropertyItem("Opacity", "Opacity", "Set the opacity percentage of the control"))
        items.Add(New DesignerActionPropertyItem("TransparentColor", "TransparentColor", "Set the fill color of the control"))
        items.Add(New DesignerActionPropertyItem("Transparent", "Transparent ", "Enable trnasparency of the control"))

        Return items

    End Function
#End Region

End Class