﻿Imports System.Drawing.Drawing2D
Imports System.IO
Imports Thumbs
Imports Thumbs2

Public Class frmEdit

    'Avatar Offsets
    Dim C4 As String = "00"
    Dim C5 As String = "00"
    Dim C6 As String = "00"
    Dim C7 As String = "00"
    Dim C8 As String = "00"
    Dim C9 As String = "00"
    Dim CA As String = "00"
    Dim CB As String = "00"
    Dim CC As String = "00"
    Dim CD As String = "00"
    Dim CE As String = "00"
    Dim _221 As String = "00"

    'Course Proficiency
    Dim LakeAkinaP, MyogiP, UsuiP, AkagiP, AkinaP, IrohazkaP, HappogaharaP, NagaoP, TsukubaP, TsubakiLineP, NanamagariP, SadamineP, TsuchisakaP, AkinaSnowP, HakoneP, MomijiLineP As Integer

    'Translation
    Dim tool_tip, mouth_t, eyes_t, face_skin_t, accessories_t, shades_t, hair_t, shirt_t, frame_t, male, female, coming_soon, must_select_avatar, a7_none, a7_hot, a7_wind, a7_light, a7_sprit, a7_overlord, a7_fly, import_complete, c8_paper, c8_orange, c8_tea As String
    Dim LakeAkina, Myogi, Usui, Akagi, Akina, Irohazka, Happogahara, Nagao, Tsukuba, TsubakiLine, Nanamagari, Sadamine, Tsuchisaka, AkinaSnow, Hakone, MomijiLine As String

    'Database
    Dim sex As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim aura As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim cup As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim category As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Dim mouth_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim eyes_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim hair_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim skin_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim shirt_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim accessories_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim shades_f As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim mouth_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim eyes_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim hair_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim skin_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim shirt_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim accessories_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)
    Dim shades_m As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)

    Dim myCar1, myCar2, myCar3 As New CarCtrl()

    Private Sub txtProficiency_TextChanged(sender As Object, e As EventArgs) Handles txtProficiency.TextChanged
        pbEffect.BackgroundImage = My.Resources.prof
        Timer1.Stop()

        Select Case cmbCourse8.SelectedValue.ToString
            Case "LakeAkina"
                LakeAkinaP = txtProficiency.Text
            Case "Usui"
                UsuiP = txtProficiency.Text
            Case "Myogi"
                MyogiP = txtProficiency.Text
            Case "Akagi"
                AkagiP = txtProficiency.Text
            Case "Akina"
                AkinaP = txtProficiency.Text
            Case "Nagao"
                NagaoP = txtProficiency.Text
            Case "TsubakiLine"
                TsubakiLineP = txtProficiency.Text
            Case "Nanamagari"
                NanamagariP = txtProficiency.Text
            Case "Sadamine"
                SadamineP = txtProficiency.Text
            Case "Hakone"
                HakoneP = txtProficiency.Text
            Case "MomijiLine"
                MomijiLineP = txtProficiency.Text
            Case "Irohazka"
                IrohazkaP = txtProficiency.Text
            Case "Happogahara"
                HappogaharaP = txtProficiency.Text
            Case "Tsukuba"
                TsukubaP = txtProficiency.Text
            Case "Tsuchisaka"
                TsuchisakaP = txtProficiency.Text
            Case "AkinaSnow"
                AkinaSnowP = txtProficiency.Text
        End Select
    End Sub


    Private Sub cmbCourse8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse8.SelectedIndexChanged
        pbEffect.BackgroundImage = My.Resources.prof
        Timer1.Stop()

        Select Case cmbCourse8.SelectedValue.ToString
            Case "LakeAkina"
                txtProficiency.Text = LakeAkinaP
            Case "Usui"
                txtProficiency.Text = UsuiP
            Case "Myogi"
                txtProficiency.Text = MyogiP
            Case "Akagi"
                txtProficiency.Text = AkagiP
            Case "Akina"
                txtProficiency.Text = AkinaP
            Case "Nagao"
                txtProficiency.Text = NagaoP
            Case "TsubakiLine"
                txtProficiency.Text = TsubakiLineP
            Case "Nanamagari"
                txtProficiency.Text = NanamagariP
            Case "Sadamine"
                txtProficiency.Text = SadamineP
            Case "Hakone"
                txtProficiency.Text = HakoneP
            Case "MomijiLine"
                txtProficiency.Text = MomijiLineP
            Case "Irohazka"
                txtProficiency.Text = IrohazkaP
            Case "Happogahara"
                txtProficiency.Text = HappogaharaP
            Case "Tsukuba"
                txtProficiency.Text = TsukubaP
            Case "Tsuchisaka"
                txtProficiency.Text = TsuchisakaP
            Case "AkinaSnow"
                txtProficiency.Text = AkinaSnowP
        End Select
    End Sub

    Dim frame As Dictionary(Of String, IDAvatar) = New Dictionary(Of String, IDAvatar)

    'Car Modifier
    Public car1 As New Car(), car2 As New Car(), car3 As New Car()

    Private gifImage As GifImage = New GifImage(My.Resources.E00) With {.ReverseAtEnd = False}

    Private finishLoading As Boolean = False

    Dim trackname8 As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pbEffect.BackgroundImage = gifImage.GetNextFrame()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        pbEffect2.BackgroundImage = gifImage.GetNextFrame()
    End Sub

    Private Sub cmbTachometer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTachometer.SelectedIndexChanged
        If finishLoading Then
            pbEffect.BackgroundImage = My.Resources.ResourceManager.GetObject("T" & cmbTachometer.SelectedIndex)
            Timer1.Stop()
        End If
    End Sub

    Private Sub cmbCup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCup.SelectedIndexChanged
        If finishLoading AndAlso Not cmbCup.SelectedIndex = 0 Then
            pbEffect.BackgroundImage = My.Resources.ResourceManager.GetObject("C" & cmbCup.SelectedIndex)
            Timer1.Stop()
        End If
    End Sub

    Private Sub cmbAura8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAura8.SelectedIndexChanged
        If finishLoading AndAlso Not cmbAura8.SelectedIndex = 0 Then
            gifImage = New GifImage(My.Resources.ResourceManager.GetObject("A" & cmbAura8.SelectedIndex))
            Timer1.Start()
        End If
    End Sub

    Private Sub cmbAura7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAura7.SelectedIndexChanged
        If finishLoading AndAlso Not cmbAura7.SelectedIndex = 0 Then
            gifImage = New GifImage(My.Resources.ResourceManager.GetObject("A" & cmbAura7.SelectedIndex))
            Timer2.Start()
        End If
    End Sub

    Private Sub cmbTitleEffect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTitleEffect.SelectedIndexChanged
        If finishLoading Then
            gifImage = New GifImage(My.Resources.ResourceManager.GetObject("E" & cmbTitleEffect.SelectedIndex.ToString("X2")))
            Timer1.Start()
        End If
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGender.SelectedIndexChanged
        mouth_f.Clear()
        mouth_m.Clear()
        skin_f.Clear()
        skin_m.Clear()
        shirt_f.Clear()
        shirt_m.Clear()
        eyes_f.Clear()
        eyes_m.Clear()
        accessories_f.Clear()
        accessories_m.Clear()
        shades_f.Clear()
        shades_m.Clear()
        hair_f.Clear()
        hair_m.Clear()
        frame.Clear()
        category.Clear()

        Select Case _version
            Case 4, &H4E, 5, 6
                DictionaryAdd6()
            Case 7
                DictionaryAdd7()
            Case 8
                DictionaryAdd8()
        End Select
    End Sub

    Private _version As Integer

    Public Property Version() As Integer
        Get
            Return _version
        End Get
        Set(value As Integer)
            _version = value
        End Set
    End Property

    Private _filename As String
    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Private _extension As String
    Public Property Extension() As String
        Get
            Return _extension
        End Get
        Set(value As String)
            _extension = value
        End Set
    End Property

    Private _cardedit As Boolean
    Public Property CardEditOnly() As Boolean
        Get
            Return _cardedit
        End Get
        Set(value As Boolean)
            _cardedit = value
        End Set
    End Property

    Private Sub GetAvatarFromCard()
        Try
            Dim c4c5 As String = C4 & C5.Replace(C5.Substring(0, 1), "X")
            Dim c5c6 As String = C5.Replace(C5.Substring(C5.Length - 1), "X") & C6
            Dim c7c8 As String = C7 & C8.Replace(C8.Substring(0, 1), "X")
            Dim c8c9 As String = C8.Replace(C8.Substring(C8.Length - 1), "X") & C9
            Dim cacb As String = CA & CB.Replace(CB.Substring(0, 1), "X")
            Dim cbcc As String = CB.Replace(CB.Substring(CB.Length - 1), "X") & CC
            Dim cdce As String = CD & CE.Replace(CE.Substring(0, 1), "X")
            Dim f221 As String = _221

            Select Case _version
                Case 4, &H4E, 5, 6
                    Dim d6fsk As Object = New InitialD6.Female.Skin
                    Dim d6fsh As Object = New InitialD6.Female.Shirt
                    Dim d6fsp As Object = New InitialD6.Female.Shades
                    Dim d6fmo As Object = New InitialD6.Female.Mouth
                    Dim d6fha As Object = New InitialD6.Female.Hair
                    Dim d6fey As Object = New InitialD6.Female.Eyes
                    Dim d6fac As Object = New InitialD6.Female.Accessories
                    Dim d6msk As Object = New InitialD6.Male.Skin
                    Dim d6msh As Object = New InitialD6.Male.Shirt
                    Dim d6msp As Object = New InitialD6.Male.Shades
                    Dim d6mmo As Object = New InitialD6.Male.Mouth
                    Dim d6mha As Object = New InitialD6.Male.Hair
                    Dim d6mey As Object = New InitialD6.Male.Eyes
                    Dim d6mac As Object = New InitialD6.Male.Accessories
                    Dim d6frm As New InitialD7.Share.Frame
                    Dim looplist As New List(Of Object)

                    If cmbGender.SelectedIndex = 1 Then
                        'Female
                        looplist.AddRange({d6fac, d6fey, d6fha, d6fmo, d6fsh, d6fsk, d6fsp})
                    Else
                        'Male
                        looplist.AddRange({d6mac, d6mey, d6mha, d6mmo, d6msh, d6msk, d6msp})
                    End If

                    For Each items In looplist
                        For Each item In items.list
                            Try
                                If item.NormalHex.Contains(c4c5) Then
                                    If d6fsk.list.Contains(item) OrElse d6msk.list.Contains(item) Then
                                        lblc4c5.Text = item.NormalHex
                                        pbSkin.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(c5c6) Then
                                    If d6fsh.list.Contains(item) OrElse d6msh.list.Contains(item) Then
                                        lblc5c6.Text = item.NormalHex
                                        pbShirt.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(c7c8) Then
                                    If d6fey.list.Contains(item) OrElse d6mey.list.Contains(item) Then
                                        lblc7c8.Text = item.NormalHex
                                        pbEyes.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(c8c9) Then
                                    If d6fmo.list.Contains(item) OrElse d6mmo.list.Contains(item) Then
                                        lblc8c9.Text = item.NormalHex
                                        pbMouth.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(cacb) Then
                                    If d6fac.list.contains(item) OrElse d6mac.list.Contains(item) Then
                                        lblcacb.Text = item.NormalHex
                                        pbAccessories.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(cbcc) Then
                                    If d6fsp.list.Contains(item) OrElse d6msp.list.Contains(item) Then
                                        lblcbcc.Text = item.NormalHex
                                        pbShades.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(cdce) Then
                                    If d6fha.list.Contains(item) OrElse d6mha.list.Contains(item) Then
                                        lblcdce.Text = item.NormalHex
                                        pbHair.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                End If
                            Catch ex As Exception
                                NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
                                Logger.Log(ex.Message & ex.StackTrace)
                                Continue For
                            End Try
                        Next
                    Next
                    For Each item In d6frm.list
                        If item.NormalHex.Contains(f221) Then
                            lbl221.Text = item.NormalHex
                            pbFrame.ChangeBackgroundImage(item.Bitmap)
                        End If
                    Next
                Case 7
                    Dim d7fsk As Object = New InitialD7.Female.Skin
                    Dim d7fsh As Object = New InitialD7.Female.Shirt
                    Dim d7fsp As Object = New InitialD7.Female.Shades
                    Dim d7fmo As Object = New InitialD7.Female.Mouth
                    Dim d7fha As Object = New InitialD7.Female.Hair
                    Dim d7fey As Object = New InitialD7.Female.Eyes
                    Dim d7fac As Object = New InitialD7.Female.Accessories
                    Dim d7msk As Object = New InitialD7.Male.Skin
                    Dim d7msh As Object = New InitialD7.Male.Shirt
                    Dim d7msp As Object = New InitialD7.Male.Shades
                    Dim d7mmo As Object = New InitialD7.Male.Mouth
                    Dim d7mha As Object = New InitialD7.Male.Hair
                    Dim d7mey As Object = New InitialD7.Male.Eyes
                    Dim d7mac As Object = New InitialD7.Male.Accessories
                    Dim d7frm As New InitialD7.Share.Frame
                    Dim looplist As New List(Of Object)

                    If cmbGender.SelectedIndex = 1 Then
                        'Female
                        looplist.AddRange({d7fac, d7fey, d7fha, d7fmo, d7fsh, d7fsk, d7fsp})
                    Else
                        'Male
                        looplist.AddRange({d7mac, d7mey, d7mha, d7mmo, d7msh, d7msk, d7msp})
                    End If

                    For Each items In looplist
                        For Each item In items.list
                            Try
                                If item.NormalHex.Contains(c4c5) Then
                                    If d7fsk.list.Contains(item) OrElse d7msk.list.Contains(item) Then
                                        lblc4c5.Text = item.NormalHex
                                        pbSkin.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(c5c6) Then
                                    If d7fsh.list.Contains(item) OrElse d7msh.list.Contains(item) Then
                                        lblc5c6.Text = item.NormalHex
                                        pbShirt.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(c7c8) Then
                                    If d7fey.list.Contains(item) OrElse d7mey.list.Contains(item) Then
                                        lblc7c8.Text = item.NormalHex
                                        pbEyes.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(c8c9) Then
                                    If d7fmo.list.Contains(item) OrElse d7mmo.list.Contains(item) Then
                                        lblc8c9.Text = item.NormalHex
                                        pbMouth.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(cacb) Then
                                    If d7fac.list.contains(item) OrElse d7mac.list.Contains(item) Then
                                        lblcacb.Text = item.NormalHex
                                        pbAccessories.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(cbcc) Then
                                    If d7fsp.list.Contains(item) OrElse d7msp.list.Contains(item) Then
                                        lblcbcc.Text = item.NormalHex
                                        pbShades.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                ElseIf item.NormalHex.Contains(cdce) Then
                                    If d7fha.list.Contains(item) OrElse d7mha.list.Contains(item) Then
                                        lblcdce.Text = item.NormalHex
                                        pbHair.ChangeBackgroundImage(item.Bitmap)
                                    End If
                                End If
                            Catch ex As Exception
                                NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
                                Logger.Log(ex.Message & ex.StackTrace)
                                Continue For
                            End Try
                        Next
                    Next
                    For Each item In d7frm.list
                        If item.NormalHex.Contains(f221) Then
                            lbl221.Text = item.NormalHex
                            pbFrame.ChangeBackgroundImage(item.Bitmap)
                        End If
                    Next
                Case 8
                    Dim d8fsk As Object = New InitialD8.Female.Skin
                    Dim d8fsh As Object = New InitialD8.Female.Shirt
                    Dim d8fsp As Object = New InitialD8.Female.Shades
                    Dim d8fmo As Object = New InitialD8.Female.Mouth
                    Dim d8fha As Object = New InitialD8.Female.Hair
                    Dim d8fey As Object = New InitialD8.Female.Eyes
                    Dim d8fac As Object = New InitialD8.Female.Accessories
                    Dim d8msk As Object = New InitialD8.Male.Skin
                    Dim d8msh As Object = New InitialD8.Male.Shirt
                    Dim d8msp As Object = New InitialD8.Male.Shades
                    Dim d8mmo As Object = New InitialD8.Male.Mouth
                    Dim d8mha As Object = New InitialD8.Male.Hair
                    Dim d8mey As Object = New InitialD8.Male.Eyes
                    Dim d8mac As Object = New InitialD8.Male.Accessories
                    Dim d8frm As New InitialD8.Share.Frame
                    Dim looplist As New List(Of Object)

                    If cmbGender.SelectedIndex = 1 Then
                        'Female
                        looplist.AddRange({d8fac, d8fey, d8fha, d8fmo, d8fsh, d8fsk, d8fsp})
                    Else
                        'Male
                        looplist.AddRange({d8mac, d8mey, d8mha, d8mmo, d8msh, d8msk, d8msp})
                    End If

                    For Each items In looplist
                        For Each item In items.list
                            Try
                                If item.NormalHex.Contains(c4c5) Then
                                    If d8fsk.list.Contains(item) OrElse d8msk.list.Contains(item) Then
                                        lblc4c5.Text = item.NormalHex
                                        pbSkin.ChangeBackgroundImage(item.Bitmap)
                                        lblc4c5_2.Text = item.NormalHex
                                        pbSkin2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Face = item.Bitmap
                                    End If
                                ElseIf item.NormalHex.Contains(c5c6) Then
                                    If d8fsh.list.Contains(item) OrElse d8msh.list.Contains(item) Then
                                        lblc5c6.Text = item.NormalHex
                                        pbShirt.ChangeBackgroundImage(item.Bitmap)
                                        lblc5c6_2.Text = item.NormalHex
                                        pbShirt2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Coat = item.Bitmap
                                    End If
                                ElseIf item.NormalHex.Contains(c7c8) Then
                                    If d8fey.list.Contains(item) OrElse d8mey.list.Contains(item) Then
                                        lblc7c8.Text = item.NormalHex
                                        pbEyes.ChangeBackgroundImage(item.Bitmap)
                                        lblc7c8_2.Text = item.NormalHex
                                        pbEyes2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Eyes = item.Bitmap
                                    End If
                                ElseIf item.NormalHex.Contains(c8c9) Then
                                    If d8fmo.list.Contains(item) OrElse d8mmo.list.Contains(item) Then
                                        lblc8c9.Text = item.NormalHex
                                        pbMouth.ChangeBackgroundImage(item.Bitmap)
                                        lblc8c9_2.Text = item.NormalHex
                                        pbMouth2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Mouth = item.Bitmap
                                    End If
                                ElseIf item.NormalHex.Contains(cacb) Then
                                    If d8fac.list.contains(item) OrElse d8mac.list.Contains(item) Then
                                        lblcacb.Text = item.NormalHex
                                        pbAccessories.ChangeBackgroundImage(item.Bitmap)
                                        lblcacb_2.Text = item.NormalHex
                                        pbAccessories2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Accessory = item.Bitmap
                                    End If
                                ElseIf item.NormalHex.Contains(cbcc) Then
                                    If d8fsp.list.Contains(item) OrElse d8msp.list.Contains(item) Then
                                        lblcbcc.Text = item.NormalHex
                                        pbShades.ChangeBackgroundImage(item.Bitmap)
                                        lblcbcc_2.Text = item.NormalHex
                                        pbShades2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Shades = item.Bitmap
                                    End If
                                ElseIf item.NormalHex.Contains(cdce) Then
                                    If d8fha.list.Contains(item) OrElse d8mha.list.Contains(item) Then
                                        lblcdce.Text = item.NormalHex
                                        pbHair.ChangeBackgroundImage(item.Bitmap)
                                        lblcdce_2.Text = item.NormalHex
                                        pbHair2.ChangeBackgroundImage(item.Bitmap)
                                        Avatar1.Hair = item.Bitmap
                                    End If
                                End If
                            Catch ex As Exception
                                NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
                                Logger.Log(ex.Message & ex.StackTrace)
                                Continue For
                            End Try
                        Next
                    Next
                    For Each item In d8frm.list
                        If item.NormalHex.Contains(f221) Then
                            lbl221.Text = item.NormalHex
                            pbFrame.ChangeBackgroundImage(item.Bitmap)
                            lbl221_2.Text = item.NormalHex
                            pbFrame2.ChangeBackgroundImage(item.Bitmap)
                            Avatar1.Frame = item.Bitmap
                        End If
                    Next

            End Select

            lblAvatarOffset.Text = C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE
            If _version = 8 Then Avatar1.RefreshImage()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Try
            Select Case cmbAvatarCat.SelectedValue.ToString
                Case "SKIN"
                    lblc4c5.Text = cmbAvatar.SelectedValue.Tag
                    pbSkin.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeFaceImage(cmbAvatar.SelectedValue.Bitmap) : lblc4c5_2.Text = cmbAvatar.SelectedValue.Tag : pbSkin2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    Dim C5A = C5.Substring(0, 1)
                    SV = SV.Replace("X", C5A)
                    C4 = FV
                    C5 = SV
                Case "SHIRT"
                    lblc5c6.Text = cmbAvatar.SelectedValue.Tag
                    pbShirt.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeCoatImage(cmbAvatar.SelectedValue.Bitmap) : lblc5c6_2.Text = cmbAvatar.SelectedValue.Tag : pbShirt2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '0X
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    '00
                    Dim C5B = C5.Substring(C5.Length - 1)
                    FV = FV.Replace("X", C5B)
                    C5 = FV
                    C6 = SV
                Case "EYES"
                    lblc7c8.Text = cmbAvatar.SelectedValue.Tag
                    pbEyes.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeEyesImage(cmbAvatar.SelectedValue.Bitmap) : lblc7c8_2.Text = cmbAvatar.SelectedValue.Tag : pbEyes2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    Dim C8A = C8.Substring(0, 1)
                    SV = SV.Replace("X", C8A)
                    C7 = FV
                    C8 = SV
                Case "MOUTH"
                    lblc8c9.Text = cmbAvatar.SelectedValue.Tag
                    pbMouth.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeMouthImage(cmbAvatar.SelectedValue.Bitmap) : lblc8c9_2.Text = cmbAvatar.SelectedValue.Tag : pbMouth2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '0X
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    '00
                    Dim C8B = C8.Substring(C8.Length - 1)
                    FV = FV.Replace("X", C8B)
                    C8 = FV
                    C9 = SV
                Case "ACCESSORIES"
                    lblcacb.Text = cmbAvatar.SelectedValue.Tag
                    pbAccessories.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeAccessoryImage(cmbAvatar.SelectedValue.Bitmap) : lblcacb_2.Text = cmbAvatar.SelectedValue.Tag : pbAccessories2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    Dim CBA = CB.Substring(0, 1)
                    SV = SV.Replace("X", CBA)
                    CA = FV
                    CB = SV
                Case "SHADES"
                    lblcbcc.Text = cmbAvatar.SelectedValue.Tag
                    pbShades.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeShadesImage(cmbAvatar.SelectedValue.Bitmap) : lblcbcc_2.Text = cmbAvatar.SelectedValue.Tag : pbShades2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '0X
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    '00
                    Dim CBB = CB.Substring(CB.Length - 1)
                    FV = FV.Replace("X", CBB)
                    CB = FV
                    CC = SV
                Case "HAIR"
                    lblcdce.Text = cmbAvatar.SelectedValue.Tag
                    pbHair.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeHairImage(cmbAvatar.SelectedValue.Bitmap) : lblcdce_2.Text = cmbAvatar.SelectedValue.Tag : pbHair2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.Tag.Substring(0, 2)                                           '00
                    Dim SV = cmbAvatar.SelectedValue.Tag.Substring(cmbAvatar.SelectedValue.Tag.Length - 2)    'X0
                    SV = SV.Replace("X", "0")
                    CD = FV
                    CE = SV
                Case "FRAME"
                    lbl221.Text = cmbAvatar.SelectedValue.tag
                    pbFrame.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    If _version = 8 Then Avatar1.ChangeFrameImage(cmbAvatar.SelectedValue.Bitmap) : lbl221_2.Text = cmbAvatar.SelectedValue.Tag : pbFrame2.ChangeBackgroundImage(cmbAvatar.SelectedValue.Bitmap)
                    Dim FV = cmbAvatar.SelectedValue.tag
                    _221 = FV
            End Select

            lblAvatarOffset.Text = C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE
            If _version = 8 Then Avatar1.RefreshImage()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim newFileName As String = String.Format("{0}\{1}.bak", Path.GetDirectoryName(_filename), Path.GetFileName(_filename))
            File.Copy(_filename, newFileName, True)

            If _version = 6 Then
                If Integer.Parse(txtLevel.Text) > 98 Then txtLevel.Text = "98"
                If Integer.Parse(txtChapLevel.Text) > 99 Then txtChapLevel.Text = "99"
            ElseIf _version = 7 Then
                If Integer.Parse(txtLevel.Text) > 26 Then txtLevel.Text = "26"
                If Integer.Parse(txtLegend.Text) > 450 Then txtLegend.Text = "450"
                If Integer.Parse(txtTAttack.Text) > 450 Then txtTAttack.Text = "450"
                If Integer.Parse(txtNational.Text) > 450 Then txtNational.Text = "450"
                If Integer.Parse(txtTag.Text) > 450 Then txtTag.Text = "450"
                If Integer.Parse(txtStore.Text) > 450 Then txtStore.Text = "450"
                If Integer.Parse(txtKanto.Text) > 450 Then txtKanto.Text = "450"
                If Integer.Parse(txtEvent.Text) > 450 Then txtEvent.Text = "450"
            ElseIf _version = 8 Then
                If Integer.Parse(txtLevel.Text) > 22 Then txtLevel.Text = "22"
            End If

            If _extension = "bin" Then
                Dim charInt As Integer = 0
                For Each c As Char In txtName.Text
                    If c.IsWideEastAsianWidth_SJIS Then
                        charInt += 2
                    Else
                        charInt += 1
                    End If
                Next
                If charInt <= 11 Then
                    Dim amount As Integer = 12 - charInt
                    Dim newName As Char = Nothing
                    Select Case amount
                        Case 1
                            newName = Chr(0)
                        Case 2
                            newName = Chr(0) & Chr(0)
                        Case 3
                            newName = Chr(0) & Chr(0) & Chr(0)
                        Case 4
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 5
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 6
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 7
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 8
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 9
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 10
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 11
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 12
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    End Select
                    SetHex(_filename, CLng("&HF0"), SetName(txtName.Text & newName))
                Else
                    SetHex(_filename, CLng("&HF0"), SetName(txtName.Text))
                End If

                If cmbGender.SelectedIndex = 1 Then
                    SetHex(_filename, CLng("&H5A"), HexStringToBinary("01"))
                Else
                    SetHex(_filename, CLng("&H5A"), HexStringToBinary("00"))
                End If

                If cbSaveAvatar.Checked Then
                    Select Case True
                        Case lblc4c5.Text = "0000", lblc5c6.Text = "0000", lblc7c8.Text = "0000", lblc8c9.Text = "0000", lblcacb.Text = "0000", lblcbcc.Text = "0000", lblcdce.Text = "0000", lbl221.Text = "0000"
                            NSMessageBox.ShowOk(must_select_avatar, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                    End Select
                    SetHex(_filename, CLng("&HC4"), HexStringToBinary(C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE))
                    SetHex(_filename, CLng("&H221"), HexStringToBinary(_221)) 'Frame
                    SetHex(_filename, &H740, HexStringToBinary(lblAvatarOffset.Text))
                End If

                SetHex(_filename, &H58, SetValue(cmbPlace.SelectedIndex))

                SetHex(_filename, CLng("&HC0"), HexStringToBinary(SetMilelage(txtGamePoint.Text)))

                Select Case _version
                    Case 6
                        If cbLegend.Checked Then SetHex(_filename, CLng("&H222"), HexStringToBinary("218F"))
                        SetHex(_filename, CLng("&H224"), SetValue(txtChapLevel.Text))
                        SetHex(_filename, CLng("&HA4"), SetValue(txtLevel.Text))
                        SetHex(_filename, CLng("&HAD"), HexStringToBinary(SetPridePoint(txtPridePoint.Text)))
                        SetHex(_filename, CLng("&H448"), HexStringToBinary(SetMilelage(txtMileage.Text)))
                    Case 7
                        SetHex(_filename, CLng("&HA3"), SetValue(txtLevel.Text))
                        SetHex(_filename, CLng("&HBD"), HexStringToBinary("20")) 'Unlock X level
                        SetHex(_filename, CLng("&HAA"), HexStringToBinary(SetPridePoint(txtSPride.Text)))
                        SetHex(_filename, CLng("&HAC"), HexStringToBinary(SetPridePoint(txtTPride.Text)))
                        SetHex(_filename, CLng("&H380"), HexStringToBinary(SetMilelage(txtMileage.Text)))
                        SetHex(_filename, Plus3C(&H374), SetValue(cmbAura7.SelectedIndex))
                        SetHex(_filename, &H390, HexStringToBinary(SetPridePoint(txtLegend.Text)))
                        SetHex(_filename, &H392, HexStringToBinary(SetPridePoint(txtTAttack.Text)))
                        SetHex(_filename, &H394, HexStringToBinary(SetPridePoint(txtNational.Text)))
                        SetHex(_filename, &H396, HexStringToBinary(SetPridePoint(txtStore.Text)))
                        SetHex(_filename, &H398, HexStringToBinary(SetPridePoint(txtTag.Text)))
                        SetHex(_filename, &H39A, HexStringToBinary(SetPridePoint(txtKanto.Text)))
                        SetHex(_filename, &H39C, HexStringToBinary(SetPridePoint(txtEvent.Text)))
                        If cbGRumble.Checked Then SetHex(_filename, Plus3C(&H33C), HexStringToBinary("01"))
                    Case 8
                        SetHex(_filename, CLng("&HA3"), SetValue(txtLevel.Text))
                        SetHex(_filename, CLng("&H3B0"), HexStringToBinary(SetMilelage(txtMileage.Text)))
                        SetHex(_filename, CLng(&H3B4), SetValue(cmbAura8.SelectedIndex))
                        SetHex(_filename, CLng(&H236), HexStringToBinary(SetPridePoint(txtInfRank.Text)))
                        SetHex(_filename, CLng(&H223), SetValue(cmbTachometer.SelectedIndex))
                        SetHex(_filename, CLng(&H3B5), SetValue(cmbTitleEffect.SelectedIndex))
                        SetHex(_filename, CLng(&H3B6), HexStringToBinary(SetPridePoint(cmbTitle.SelectedIndex + 1)))
                        SetHex(_filename, CLng(&H222), SetValue(cmbCup.SelectedIndex))
                        If cbUnlockExSpec.Checked Then SetHex(_filename, CLng(&H4E8), HexStringToBinary("77777777777777777777777777777777777777777777777777"))
                        If cbRiseUp.Checked Then SetHex(_filename, &H378, HexStringToBinary("01"))
                        If cbStorySuperb.Checked Then SetHex(_filename, &H230, HexStringToBinary("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"))
                        SetHex(_filename, CLng(&H380), HexStringToBinary(SetPridePoint(LakeAkinaP)))
                        SetHex(_filename, CLng(&H382), HexStringToBinary(SetPridePoint(MyogiP)))
                        SetHex(_filename, CLng(&H384), HexStringToBinary(SetPridePoint(AkagiP)))
                        SetHex(_filename, CLng(&H386), HexStringToBinary(SetPridePoint(AkinaP)))
                        SetHex(_filename, CLng(&H388), HexStringToBinary(SetPridePoint(IrohazkaP)))
                        SetHex(_filename, CLng(&H38A), HexStringToBinary(SetPridePoint(TsukubaP)))
                        SetHex(_filename, CLng(&H38C), HexStringToBinary(SetPridePoint(HappogaharaP)))
                        SetHex(_filename, CLng(&H38E), HexStringToBinary(SetPridePoint(NagaoP)))
                        SetHex(_filename, CLng(&H390), HexStringToBinary(SetPridePoint(TsubakiLineP)))
                        SetHex(_filename, CLng(&H392), HexStringToBinary(SetPridePoint(UsuiP)))
                        SetHex(_filename, CLng(&H394), HexStringToBinary(SetPridePoint(SadamineP)))
                        SetHex(_filename, CLng(&H396), HexStringToBinary(SetPridePoint(TsuchisakaP)))
                        SetHex(_filename, CLng(&H398), HexStringToBinary(SetPridePoint(AkinaSnowP)))
                        SetHex(_filename, CLng(&H39A), HexStringToBinary(SetPridePoint(HakoneP)))
                        SetHex(_filename, CLng(&H39C), HexStringToBinary(SetPridePoint(MomijiLineP)))
                        SetHex(_filename, CLng(&H39E), HexStringToBinary(SetPridePoint(NanamagariP)))
                        If cbStoryHack.Checked Then SetHex(_filename, &H3A0, HexStringToBinary("FF7FFF7FFF7F02"))
                        If cbInfinitySide.Checked Then SetHex(_filename, &H24A, HexStringToBinary("BC"))
                End Select

                'Save Car
                If car1.Edited Then
                    If Not car1.ReplaceTo = "" Then SetHex(_filename, &H100, HexStringToBinary(SetCar(car1.ReplaceTo)))
                    SetHex(_filename, Plus3C(&HC6), HexStringToBinary(car1.CarColor))
                    SetHex(_filename, &H11C, HexStringToBinary(SetPlateNumber(car1.PlateNo)))
                    SetHex(_filename, &H119, SetValue(car1.Hiragana))
                    SetHex(_filename, &H118, SetValue(car1.PlaceName))
                    SetHex(_filename, Plus3C(&HD0), HexStringToBinary(car1.Sticker1))
                    SetHex(_filename, Plus3C(&HD1), HexStringToBinary(car1.Sticker2))
                    SetHex(_filename, Plus3C(&HD2), HexStringToBinary(car1.Sticker3))
                    SetHex(_filename, Plus3C(&HD3), HexStringToBinary(car1.Sticker4))
                    SetHex(_filename, Plus3C(&HCA), HexStringToBinary("10"))
                    SetHex(_filename, &H11A, HexStringToBinary(SetPridePoint(car1.ClassCode)))
                    If car1.FullSpec Then
                        Select Case car1.Transmission
                            Case Transmission.AT
                                SetHex(_filename, &H105, HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, &H105, HexStringToBinary("D0"))
                        End Select
                        If car1.SaveEngineRollbar Then
                            SetHex(_filename, Plus3C(&HCC), HexStringToBinary(car1.Param))
                            SetHex(_filename, Plus3C(&HCE), HexStringToBinary(car1.Engine))
                            SetHex(_filename, Plus3C(&HE4), HexStringToBinary(car1.Rollbar))
                        End If
                    End If
                End If
                If car2.Edited Then
                    If Not car2.ReplaceTo = "" Then SetHex(_filename, &H160, HexStringToBinary(SetCar(car2.ReplaceTo)))
                    SetHex(_filename, Plus3C(&H126), HexStringToBinary(car2.CarColor))
                    SetHex(_filename, &H17C, HexStringToBinary(SetPlateNumber(car2.PlateNo)))
                    SetHex(_filename, &H179, SetValue(car2.Hiragana))
                    SetHex(_filename, &H178, SetValue(car2.PlaceName))
                    SetHex(_filename, Plus3C(&H130), HexStringToBinary(car2.Sticker1))
                    SetHex(_filename, Plus3C(&H131), HexStringToBinary(car2.Sticker2))
                    SetHex(_filename, Plus3C(&H132), HexStringToBinary(car2.Sticker3))
                    SetHex(_filename, Plus3C(&H133), HexStringToBinary(car2.Sticker4))
                    SetHex(_filename, Plus3C(&H12A), HexStringToBinary("10"))
                    SetHex(_filename, &H17A, HexStringToBinary(SetPridePoint(car2.ClassCode)))
                    If car2.FullSpec Then
                        Select Case car2.Transmission
                            Case Transmission.AT
                                SetHex(_filename, &H165, HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, &H165, HexStringToBinary("D0"))
                        End Select
                        If car2.SaveEngineRollbar Then
                            SetHex(_filename, Plus3C(&H12C), HexStringToBinary(car2.Param))
                            SetHex(_filename, Plus3C(&H12E), HexStringToBinary(car2.Engine))
                            SetHex(_filename, Plus3C(&H144), HexStringToBinary(car2.Rollbar))
                        End If
                    End If
                End If
                If car3.Edited Then
                    If Not car3.ReplaceTo = "" Then SetHex(_filename, &H1C0, HexStringToBinary(SetCar(car3.ReplaceTo)))
                    SetHex(_filename, Plus3C(&H186), HexStringToBinary(car3.CarColor))
                    SetHex(_filename, &H1DC, HexStringToBinary(SetPlateNumber(car3.PlateNo)))
                    SetHex(_filename, &H1D9, SetValue(car3.Hiragana))
                    SetHex(_filename, &H1D8, SetValue(car3.PlaceName))
                    SetHex(_filename, Plus3C(&H190), HexStringToBinary(car3.Sticker1))
                    SetHex(_filename, Plus3C(&H191), HexStringToBinary(car3.Sticker2))
                    SetHex(_filename, Plus3C(&H192), HexStringToBinary(car3.Sticker3))
                    SetHex(_filename, Plus3C(&H193), HexStringToBinary(car3.Sticker4))
                    SetHex(_filename, Plus3C(&H18A), HexStringToBinary("10"))
                    SetHex(_filename, &H1DA, HexStringToBinary(SetPridePoint(car3.ClassCode)))
                    If car3.FullSpec Then
                        Select Case car3.Transmission
                            Case Transmission.AT
                                SetHex(_filename, &H1C5, HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, &H1C5, HexStringToBinary("D0"))
                        End Select
                        If car3.SaveEngineRollbar Then
                            SetHex(_filename, Plus3C(&H18C), HexStringToBinary(car3.Param))
                            SetHex(_filename, Plus3C(&H18E), HexStringToBinary(car3.Engine))
                            SetHex(_filename, Plus3C(&H1A4), HexStringToBinary(car3.Rollbar))
                        End If
                    End If
                End If

                SetHex(_filename, CLng("&H759"), HexStringToBinary("6564697465647573696E67696461736C61756E63686572")) 'editedusingidaslauncher

                If _cardedit Then
                    End
                Else
                    frmCard.RefreshID6Cards()
                    frmCard.RefreshID7Cards()
                    frmCard.RefreshID8Cards()
                    Me.Close()
                End If
            Else 'crd
                Dim charInt As Integer = 0
                For Each c As Char In txtName.Text
                    If c.IsWideEastAsianWidth_SJIS Then
                        charInt += 2
                    Else
                        charInt += 1
                    End If
                Next
                If charInt <= 11 Then
                    Dim amount As Integer = 12 - charInt
                    Dim newName As Char = Nothing
                    Select Case amount
                        Case 1
                            newName = Chr(0)
                        Case 2
                            newName = Chr(0) & Chr(0)
                        Case 3
                            newName = Chr(0) & Chr(0) & Chr(0)
                        Case 4
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 5
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 6
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 7
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 8
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 9
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 10
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 11
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                        Case 12
                            newName = Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0)
                    End Select
                    SetHex(_filename, Neg3C("&HF0"), SetName(txtName.Text & newName))
                Else
                    SetHex(_filename, Neg3C("&HF0"), SetName(txtName.Text))
                End If

                If cmbGender.SelectedIndex = 1 Then
                    SetHex(_filename, Neg3C(&H5A), HexStringToBinary("01"))
                Else
                    SetHex(_filename, Neg3C(&H5A), HexStringToBinary("00"))
                End If

                If cbSaveAvatar.Checked Then
                    Select Case True
                        Case lblc4c5.Text = "0000", lblc5c6.Text = "0000", lblc7c8.Text = "0000", lblc8c9.Text = "0000", lblcacb.Text = "0000", lblcbcc.Text = "0000", lblcdce.Text = "0000", lbl221.Text = "0000"
                            NSMessageBox.ShowOk(must_select_avatar, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                    End Select
                    SetHex(_filename, Neg3C(&HC4), HexStringToBinary(C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE))
                    SetHex(_filename, Neg3C(&H221), HexStringToBinary(_221)) 'Frame
                End If

                SetHex(_filename, &H1C, SetValue(cmbPlace.SelectedIndex))

                SetHex(_filename, Neg3C(&HC0), HexStringToBinary(SetMilelage(txtGamePoint.Text)))

                Select Case _version
                    Case 6
                        If cbLegend.Checked Then SetHex(_filename, Neg3C(&H222), HexStringToBinary("218F"))
                        SetHex(_filename, Neg3C(&H224), SetValue(txtChapLevel.Text))
                        SetHex(_filename, Neg3C(&HA4), SetValue(txtLevel.Text))
                        SetHex(_filename, Neg3C(&HAD), HexStringToBinary(SetPridePoint(txtPridePoint.Text)))
                        SetHex(_filename, Neg3C(&H448), HexStringToBinary(SetMilelage(txtMileage.Text)))
                    Case 7
                        SetHex(_filename, Neg3C(&HA3), SetValue(txtLevel.Text))
                        SetHex(_filename, Neg3C(&HBD), HexStringToBinary("20")) 'Unlock X level
                        SetHex(_filename, Neg3C(&HAA), HexStringToBinary(SetPridePoint(txtSPride.Text)))
                        SetHex(_filename, Neg3C(&HAC), HexStringToBinary(SetPridePoint(txtTPride.Text)))
                        SetHex(_filename, Neg3C(&H380), HexStringToBinary(SetMilelage(txtMileage.Text)))
                        SetHex(_filename, &H374, SetValue(cmbAura7.SelectedIndex))
                        If cbGRumble.Checked Then SetHex(_filename, &H33C, HexStringToBinary("01"))
                        SetHex(_filename, Neg3C(&H390), HexStringToBinary(SetPridePoint(txtLegend.Text)))
                        SetHex(_filename, Neg3C(&H392), HexStringToBinary(SetPridePoint(txtTAttack.Text)))
                        SetHex(_filename, Neg3C(&H394), HexStringToBinary(SetPridePoint(txtNational.Text)))
                        SetHex(_filename, Neg3C(&H396), HexStringToBinary(SetPridePoint(txtStore.Text)))
                        SetHex(_filename, Neg3C(&H398), HexStringToBinary(SetPridePoint(txtTag.Text)))
                        SetHex(_filename, Neg3C(&H39A), HexStringToBinary(SetPridePoint(txtKanto.Text)))
                        SetHex(_filename, Neg3C(&H39C), HexStringToBinary(SetPridePoint(txtEvent.Text)))
                    Case 8
                        SetHex(_filename, Neg3C(&HA3), SetValue(txtLevel.Text))
                        SetHex(_filename, Neg3C(&H3B0), HexStringToBinary(SetMilelage(txtMileage.Text)))
                        SetHex(_filename, Neg3C(&H3B4), SetValue(cmbAura8.SelectedIndex))
                        SetHex(_filename, Neg3C(&H236), HexStringToBinary(SetPridePoint(txtInfRank.Text)))
                        SetHex(_filename, Neg3C(&H223), SetValue(cmbTachometer.SelectedIndex))
                        SetHex(_filename, Neg3C(&H3B5), SetValue(cmbTitleEffect.SelectedIndex))
                        SetHex(_filename, Neg3C(&H3B6), HexStringToBinary(SetPridePoint(cmbTitle.SelectedIndex + 1)))
                        SetHex(_filename, Neg3C(&H222), SetValue(cmbCup.SelectedIndex))
                        If cbUnlockExSpec.Checked Then SetHex(_filename, Neg3C(&H4E8), HexStringToBinary("77777777777777777777777777777777777777777777777777"))
                        If cbRiseUp.Checked Then SetHex(_filename, Neg3C(&H378), HexStringToBinary("01"))
                        If cbStorySuperb.Checked Then SetHex(_filename, Neg3C(&H230), HexStringToBinary("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"))
                        SetHex(_filename, Neg3C(&H380), HexStringToBinary(SetPridePoint(LakeAkinaP)))
                        SetHex(_filename, Neg3C(&H382), HexStringToBinary(SetPridePoint(MyogiP)))
                        SetHex(_filename, Neg3C(&H384), HexStringToBinary(SetPridePoint(AkagiP)))
                        SetHex(_filename, Neg3C(&H386), HexStringToBinary(SetPridePoint(AkinaP)))
                        SetHex(_filename, Neg3C(&H388), HexStringToBinary(SetPridePoint(IrohazkaP)))
                        SetHex(_filename, Neg3C(&H38A), HexStringToBinary(SetPridePoint(TsukubaP)))
                        SetHex(_filename, Neg3C(&H38C), HexStringToBinary(SetPridePoint(HappogaharaP)))
                        SetHex(_filename, Neg3C(&H38E), HexStringToBinary(SetPridePoint(NagaoP)))
                        SetHex(_filename, Neg3C(&H390), HexStringToBinary(SetPridePoint(TsubakiLineP)))
                        SetHex(_filename, Neg3C(&H392), HexStringToBinary(SetPridePoint(UsuiP)))
                        SetHex(_filename, Neg3C(&H394), HexStringToBinary(SetPridePoint(SadamineP)))
                        SetHex(_filename, Neg3C(&H396), HexStringToBinary(SetPridePoint(TsuchisakaP)))
                        SetHex(_filename, Neg3C(&H398), HexStringToBinary(SetPridePoint(AkinaSnowP)))
                        SetHex(_filename, Neg3C(&H39A), HexStringToBinary(SetPridePoint(HakoneP)))
                        SetHex(_filename, Neg3C(&H39C), HexStringToBinary(SetPridePoint(MomijiLineP)))
                        SetHex(_filename, Neg3C(&H39E), HexStringToBinary(SetPridePoint(NanamagariP)))
                        If cbStoryHack.Checked Then SetHex(_filename, Neg3C(&H3A0), HexStringToBinary("FF7FFF7FFF7F02"))
                        If cbInfinitySide.Checked Then SetHex(_filename, Neg3C(&H24A), HexStringToBinary("BC"))
                End Select

                'Save Car
                If car1.Edited Then
                    If Not car1.ReplaceTo = "" Then SetHex(_filename, Neg3C(&H100), HexStringToBinary(SetCar(car1.ReplaceTo)))
                    SetHex(_filename, &HC6, HexStringToBinary(car1.CarColor))
                    SetHex(_filename, Neg3C(&H11C), HexStringToBinary(SetPlateNumber(car1.PlateNo)))
                    SetHex(_filename, Neg3C(&H119), SetValue(car1.Hiragana))
                    SetHex(_filename, Neg3C(&H118), SetValue(car1.PlaceName))
                    SetHex(_filename, &HD0, HexStringToBinary(car1.Sticker1))
                    SetHex(_filename, &HD1, HexStringToBinary(car1.Sticker2))
                    SetHex(_filename, &HD2, HexStringToBinary(car1.Sticker3))
                    SetHex(_filename, &HD3, HexStringToBinary(car1.Sticker4))
                    SetHex(_filename, &HCA, HexStringToBinary("10"))
                    SetHex(_filename, Neg3C(&H11A), HexStringToBinary(SetPridePoint(car1.ClassCode)))
                    If car1.FullSpec Then
                        Select Case car1.Transmission
                            Case Transmission.AT
                                SetHex(_filename, Neg3C(&H105), HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, Neg3C(&H105), HexStringToBinary("D0"))
                        End Select
                        If car1.SaveEngineRollbar Then
                            SetHex(_filename, &HCC, HexStringToBinary(car1.Param))
                            SetHex(_filename, &HCE, HexStringToBinary(car1.Engine))
                            SetHex(_filename, &HE4, HexStringToBinary(car1.Rollbar))
                        End If
                    End If
                End If
                If car2.Edited Then
                    If Not car2.ReplaceTo = "" Then SetHex(_filename, Neg3C(&H160), HexStringToBinary(SetCar(car2.ReplaceTo)))
                    SetHex(_filename, &H126, HexStringToBinary(car2.CarColor))
                    SetHex(_filename, Neg3C(&H17C), HexStringToBinary(SetPlateNumber(car2.PlateNo)))
                    SetHex(_filename, Neg3C(&H179), SetValue(car2.Hiragana))
                    SetHex(_filename, Neg3C(&H178), SetValue(car2.PlaceName))
                    SetHex(_filename, &H130, HexStringToBinary(car2.Sticker1))
                    SetHex(_filename, &H131, HexStringToBinary(car2.Sticker2))
                    SetHex(_filename, &H132, HexStringToBinary(car2.Sticker3))
                    SetHex(_filename, &H133, HexStringToBinary(car2.Sticker4))
                    SetHex(_filename, &H12A, HexStringToBinary("10"))
                    SetHex(_filename, Neg3C(&H17A), HexStringToBinary(SetPridePoint(car2.ClassCode)))
                    If car2.FullSpec Then
                        Select Case car2.Transmission
                            Case Transmission.AT
                                SetHex(_filename, Neg3C(&H165), HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, Neg3C(&H165), HexStringToBinary("D0"))
                        End Select
                        If car2.SaveEngineRollbar Then
                            SetHex(_filename, &H12C, HexStringToBinary(car2.Param))
                            SetHex(_filename, &H12E, HexStringToBinary(car2.Engine))
                            SetHex(_filename, &H144, HexStringToBinary(car2.Rollbar))
                        End If
                    End If
                End If
                If car3.Edited Then
                    If Not car3.ReplaceTo = "" Then SetHex(_filename, Neg3C(&H1C0), HexStringToBinary(SetCar(car3.ReplaceTo)))
                    SetHex(_filename, &H186, HexStringToBinary(car3.CarColor))
                    SetHex(_filename, Neg3C(&H1DC), HexStringToBinary(SetPlateNumber(car3.PlateNo)))
                    SetHex(_filename, Neg3C(&H1D9), SetValue(car3.Hiragana))
                    SetHex(_filename, Neg3C(&H1D8), SetValue(car3.PlaceName))
                    SetHex(_filename, &H190, HexStringToBinary(car3.Sticker1))
                    SetHex(_filename, &H191, HexStringToBinary(car3.Sticker2))
                    SetHex(_filename, &H192, HexStringToBinary(car3.Sticker3))
                    SetHex(_filename, &H193, HexStringToBinary(car3.Sticker4))
                    SetHex(_filename, &H18A, HexStringToBinary("10"))
                    SetHex(_filename, Neg3C(&H1DA), HexStringToBinary(SetPridePoint(car3.ClassCode)))
                    If car3.FullSpec Then
                        Select Case car3.Transmission
                            Case Transmission.AT
                                SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("50"))
                            Case Transmission.MT
                                SetHex(_filename, Neg3C(&H1C5), HexStringToBinary("D0"))
                        End Select
                        If car3.SaveEngineRollbar Then
                            SetHex(_filename, &H18C, HexStringToBinary(car3.Param))
                            SetHex(_filename, &H18E, HexStringToBinary(car3.Engine))
                            SetHex(_filename, &H1A4, HexStringToBinary(car3.Rollbar))
                        End If
                    End If
                End If

                'SetHex(_filename, Neg3C(&H759), HexStringToBinary("6564697465647573696E67696461736C61756E63686572")) 'editedusingidaslauncher

                If _cardedit Then
                    End
                Else
                    frmCard.RefreshID6Cards()
                    frmCard.RefreshID7Cards()
                    frmCard.RefreshID8Cards()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _cardedit Then
            frmLauncher.Hide()
        End If

        TabPage1.Enabled = False
        TabPage2.Enabled = False
        TabPage3.Enabled = False

        Translate()

        If _version = 8 Then
            Avatar1.Visible = True
            pAvatar2.Visible = True
        Else
            pAvatar.Visible = True
        End If

        'Add Gender
        sex.Add(male, "MALE")
        sex.Add(female, "FEMALE")
        cmbGender.DisplayMember = "Key"
        cmbGender.ValueMember = "Value"
        cmbGender.DataSource = New BindingSource(sex, Nothing)
        If _extension = "bin" Then
            If GetGender(GetHex(_filename, 90, 1)) = Gender.female Then
                cmbGender.SelectedIndex = 1
            Else
                cmbGender.SelectedIndex = 0
            End If
        Else
            If GetGender(GetHex(_filename, Neg60(90), 1)) = Gender.female Then
                cmbGender.SelectedIndex = 1
            Else
                cmbGender.SelectedIndex = 0
            End If
        End If

        Select Case cmbGender.SelectedIndex
            Case 0 'male
                Avatar1.Frame = (New InitialD8.Share.Frame).FM_00.Bitmap
                Avatar1.Face = (New InitialD8.Male.Skin).SK_01X0.Bitmap
                Avatar1.Eyes = (New InitialD8.Male.Eyes).EY_A8X0.Bitmap
                Avatar1.Mouth = (New InitialD8.Male.Mouth).MO_0X0E.Bitmap
                Avatar1.Coat = (New InitialD8.Male.Shirt).SH_0X02.Bitmap
                Avatar1.Hair = (New InitialD8.Male.Hair).HA_41X1.Bitmap
                Avatar1.RefreshImage()
            Case 1 'female
                Avatar1.Frame = (New InitialD8.Share.Frame).FM_00.Bitmap
                Avatar1.Face = (New InitialD8.Female.Skin).SK_01X0.Bitmap
                Avatar1.Eyes = (New InitialD8.Female.Eyes).EY_AEX0.Bitmap
                Avatar1.Mouth = (New InitialD8.Female.Mouth).MO_0X0E.Bitmap
                Avatar1.Coat = (New InitialD8.Female.Shirt).SH_0X02.Bitmap
                Avatar1.Hair = (New InitialD8.Female.Hair).HA_41X1.Bitmap
                Avatar1.RefreshImage()
        End Select

        'If _version = 6 Then
        '    DictionaryAdd6()
        'End If

        If _version = 7 Then
            'DictionaryAdd7()

            'Add Aura
            aura.Add(a7_none, "NONE")
            aura.Add(a7_hot, "HOT")
            aura.Add(a7_wind, "WIND")
            aura.Add(a7_light, "LIGHT")
            aura.Add(a7_sprit, "SPRIT")
            aura.Add(a7_overlord, "OVERLORD")
            aura.Add(a7_fly, "FLY")
            cmbAura7.DisplayMember = "Key"
            cmbAura7.ValueMember = "Value"
            cmbAura7.DataSource = New BindingSource(aura, Nothing)
        End If

        If _version = 8 Then
            'DictionaryAdd8()

            'Add Aura
            aura.Add(a7_none, "NONE")
            aura.Add(a7_hot, "HOT")
            aura.Add(a7_wind, "WIND")
            aura.Add(a7_light, "LIGHT")
            aura.Add(a7_sprit, "SPRIT")
            aura.Add(a7_overlord, "OVERLORD")
            aura.Add(a7_fly, "FLY")
            cmbAura8.DisplayMember = "Key"
            cmbAura8.ValueMember = "Value"
            cmbAura8.DataSource = New BindingSource(aura, Nothing)

            'Add Cup
            cup.Add(a7_none, "NONE")
            cup.Add(c8_paper, "PAPER")
            cup.Add(c8_orange, "ORANGE")
            cup.Add(c8_tea, "TEA")
            cmbCup.DisplayMember = "Key"
            cmbCup.ValueMember = "Value"
            cmbCup.DataSource = New BindingSource(cup, Nothing)

            trackname8.Add(LakeAkina, "LakeAkina")
            trackname8.Add(Myogi, "Myogi")
            trackname8.Add(Usui, "Usui")
            trackname8.Add(Akagi, "Akagi")
            trackname8.Add(Akina, "Akina")
            trackname8.Add(Irohazka, "Irohazka")
            trackname8.Add(Happogahara, "Happogahara")
            trackname8.Add(Nagao, "Nagao")
            trackname8.Add(Tsukuba, "Tsukuba")
            trackname8.Add(TsubakiLine, "TsubakiLine")
            trackname8.Add(Nanamagari, "Nanamagari")
            trackname8.Add(Sadamine, "Sadamine")
            trackname8.Add(Tsuchisaka, "Tsuchisaka")
            trackname8.Add(AkinaSnow, "AkinaSnow")
            trackname8.Add(Hakone, "Hakone")
            trackname8.Add(MomijiLine, "MomijiLine")
            cmbCourse8.DisplayMember = "Key"
            cmbCourse8.ValueMember = "Value"
            cmbCourse8.DataSource = New BindingSource(trackname8, Nothing)
        End If

        lblAvatarOffset.Visible = My.Settings.DebugMode
        lblc4c5.Visible = My.Settings.DebugMode
        lblc5c6.Visible = My.Settings.DebugMode
        lblc7c8.Visible = My.Settings.DebugMode
        lblc8c9.Visible = My.Settings.DebugMode
        lblcacb.Visible = My.Settings.DebugMode
        lblcbcc.Visible = My.Settings.DebugMode
        lblcdce.Visible = My.Settings.DebugMode
        lbl221.Visible = My.Settings.DebugMode
        lblc4c5_2.Visible = My.Settings.DebugMode
        lblc5c6_2.Visible = My.Settings.DebugMode
        lblc7c8_2.Visible = My.Settings.DebugMode
        lblc8c9_2.Visible = My.Settings.DebugMode
        lblcacb_2.Visible = My.Settings.DebugMode
        lblcbcc_2.Visible = My.Settings.DebugMode
        lblcdce_2.Visible = My.Settings.DebugMode
        lbl221_2.Visible = My.Settings.DebugMode

        Try
            If _extension = "bin" Then
                txtName.Text = GetName(GetHex(_filename, 240, 12))
                txtGamePoint.Text = GetMilelage(GetHex(_filename, 192, 1), GetHex(_filename, 193, 1), GetHex(_filename, 194, 1), GetHex(_filename, 195, 1))
                cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, &H58, 1), True)
                C4 = GetHexStringFromBinary(GetHex(_filename, &H740, 1))
                C5 = GetHexStringFromBinary(GetHex(_filename, &H741, 1))
                C6 = GetHexStringFromBinary(GetHex(_filename, &H742, 1))
                C7 = GetHexStringFromBinary(GetHex(_filename, &H743, 1))
                C8 = GetHexStringFromBinary(GetHex(_filename, &H744, 1))
                C9 = GetHexStringFromBinary(GetHex(_filename, &H745, 1))
                CA = GetHexStringFromBinary(GetHex(_filename, &H746, 1))
                CB = GetHexStringFromBinary(GetHex(_filename, &H747, 1))
                CC = GetHexStringFromBinary(GetHex(_filename, &H748, 1))
                CD = GetHexStringFromBinary(GetHex(_filename, &H749, 1))
                CE = GetHexStringFromBinary(GetHex(_filename, &H74A, 1))
                _221 = GetHexStringFromBinary(GetHex(_filename, &H221, 1))
                lblAvatarOffset.Text = C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE
                If lblAvatarOffset.Text = "0000000000000000000000" Then
                    C4 = GetHexStringFromBinary(GetHex(_filename, CLng(&HC4), 1))
                    C5 = GetHexStringFromBinary(GetHex(_filename, CLng(&HC5), 1))
                    C6 = GetHexStringFromBinary(GetHex(_filename, CLng(&HC6), 1))
                    C7 = GetHexStringFromBinary(GetHex(_filename, CLng(&HC7), 1))
                    C8 = GetHexStringFromBinary(GetHex(_filename, CLng(&HC8), 1))
                    C9 = GetHexStringFromBinary(GetHex(_filename, CLng(&HC9), 1))
                    CA = GetHexStringFromBinary(GetHex(_filename, CLng(&HCA), 1))
                    CB = GetHexStringFromBinary(GetHex(_filename, CLng(&HCB), 1))
                    CC = GetHexStringFromBinary(GetHex(_filename, CLng(&HCC), 1))
                    CD = GetHexStringFromBinary(GetHex(_filename, CLng(&HCD), 1))
                    CE = GetHexStringFromBinary(GetHex(_filename, CLng(&HCE), 1))
                    lblAvatarOffset.Text = C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE
                End If
                GetAvatarFromCard()

                If _version = 6 Then
                    txtLevel.Text = GetLevel(GetHex(_filename, 164, 1), True)
                    txtChapLevel.Text = GetChapterLevel(GetHex(_filename, 548, 1))
                    txtPridePoint.Text = GetPridePoint(GetHex(_filename, 173, 1), GetHex(_filename, 174, 1))
                    txtMileage.Text = GetMilelage(GetHex(_filename, 1096, 1), GetHex(_filename, 1097, 1), GetHex(_filename, 1098, 1), GetHex(_filename, 1099, 1))
                    TabPage1.Enabled = True
                    myCar1.CarName = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 6)
                    myCar2.CarName = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 6)
                    myCar3.CarName = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 6)
                ElseIf _version = 7 Then
                    txtLevel.Text = GetLevel(GetHex(_filename, 163, 1), True)
                    TabPage2.Enabled = True
                    txtSPride.Text = GetPridePoint(GetHex(_filename, 170, 1), GetHex(_filename, 171, 1))
                    txtTPride.Text = GetPridePoint(GetHex(_filename, 172, 1), GetHex(_filename, 173, 1))
                    txtMileage.Text = GetMilelage(GetHex(_filename, 896, 1), GetHex(_filename, 897, 1), GetHex(_filename, 898, 1), GetHex(_filename, 899, 1))
                    myCar1.CarName = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 7)
                    myCar2.CarName = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 7)
                    myCar3.CarName = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 7)
                    cmbAura7.SelectedIndex = GetID7Aura(GetHex(_filename, Plus60(884), 1))
                    txtLegend.Text = GetPridePoint(GetHex(_filename, &H390, 1), GetHex(_filename, &H391, 1))
                    txtTAttack.Text = GetPridePoint(GetHex(_filename, &H392, 1), GetHex(_filename, &H393, 1))
                    txtNational.Text = GetPridePoint(GetHex(_filename, &H394, 1), GetHex(_filename, &H395, 1))
                    txtStore.Text = GetPridePoint(GetHex(_filename, &H396, 1), GetHex(_filename, &H397, 1))
                    txtTag.Text = GetPridePoint(GetHex(_filename, &H398, 1), GetHex(_filename, &H399, 1))
                    txtKanto.Text = GetPridePoint(GetHex(_filename, &H39A, 1), GetHex(_filename, &H39B, 1))
                    txtEvent.Text = GetPridePoint(GetHex(_filename, &H39C, 1), GetHex(_filename, &H39D, 1))
                ElseIf _version = 8 Then
                    TabPage3.Enabled = True
                    txtLevel.Text = GetLevel(GetHex(_filename, 163, 1), True, True)
                    txtMileage.Text = GetMilelage(GetHex(_filename, 944, 1), GetHex(_filename, 945, 1), GetHex(_filename, 946, 1), GetHex(_filename, 947, 1))
                    myCar1.CarName = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 8)
                    myCar2.CarName = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 8)
                    myCar3.CarName = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 8)
                    cmbAura8.SelectedIndex = GetID7Aura(GetHex(_filename, &H3B4, 1))
                    txtInfRank.Text = GetPridePoint(GetHex(_filename, &H236, 1), GetHex(_filename, &H237, 1))
                    cmbTachometer.SelectedIndex = GetTachometer(GetHex(_filename, &H223, 1))
                    cmbTitleEffect.SelectedIndex = GetTachometer(GetHex(_filename, &H3B5, 1))
                    cmbTitle.SelectedIndex = GetPridePoint(GetHex(_filename, &H3B6, 1), GetHex(_filename, &H3B7, 1)) - 1
                    cmbCup.SelectedIndex = GetTachometer(GetHex(_filename, &H222, 1))
                    LakeAkinaP = GetPridePoint(GetHex(_filename, CLng(&H380), 1), GetHex(_filename, CLng(&H381), 1))
                    MyogiP = GetPridePoint(GetHex(_filename, CLng(&H382), 1), GetHex(_filename, CLng(&H383), 1))
                    AkagiP = GetPridePoint(GetHex(_filename, CLng(&H384), 1), GetHex(_filename, CLng(&H385), 1))
                    AkinaP = GetPridePoint(GetHex(_filename, CLng(&H386), 1), GetHex(_filename, CLng(&H387), 1))
                    IrohazkaP = GetPridePoint(GetHex(_filename, CLng(&H388), 1), GetHex(_filename, CLng(&H389), 1))
                    TsukubaP = GetPridePoint(GetHex(_filename, CLng(&H38A), 1), GetHex(_filename, CLng(&H38B), 1))
                    HappogaharaP = GetPridePoint(GetHex(_filename, CLng(&H38C), 1), GetHex(_filename, CLng(&H38D), 1))
                    NagaoP = GetPridePoint(GetHex(_filename, CLng(&H38E), 1), GetHex(_filename, CLng(&H38F), 1))
                    TsubakiLineP = GetPridePoint(GetHex(_filename, CLng(&H390), 1), GetHex(_filename, CLng(&H391), 1))
                    UsuiP = GetPridePoint(GetHex(_filename, CLng(&H392), 1), GetHex(_filename, CLng(&H393), 1))
                    SadamineP = GetPridePoint(GetHex(_filename, CLng(&H394), 1), GetHex(_filename, CLng(&H395), 1))
                    TsuchisakaP = GetPridePoint(GetHex(_filename, CLng(&H396), 1), GetHex(_filename, CLng(&H397), 1))
                    AkinaSnowP = GetPridePoint(GetHex(_filename, CLng(&H398), 1), GetHex(_filename, CLng(&H399), 1))
                    HakoneP = GetPridePoint(GetHex(_filename, CLng(&H39A), 1), GetHex(_filename, CLng(&H39B), 1))
                    MomijiLineP = GetPridePoint(GetHex(_filename, CLng(&H39C), 1), GetHex(_filename, CLng(&H39D), 1))
                    NanamagariP = GetPridePoint(GetHex(_filename, CLng(&H39E), 1), GetHex(_filename, CLng(&H39F), 1))
                    cmbCourse8.SelectedIndex = 0
                    txtProficiency.Text = LakeAkinaP
                Else

                End If





                'Read Car
                If Not myCar1.CarName = "" Then
                    myCar1.Car = car1
                    myCar1.CarSlot = 1
                    myCar1.Version = _version
                    myCar1.FileName = _filename
                    myCar1.Extension = _extension
                    myCar1._parentForm = Me
                    myCar1.pbCar.Image = GetCarImage(myCar1.CarName)
                    myCar1.Car.ReplaceTo = Nothing
                    myCar1.Car.CarColor = GetHexStringFromBinary(GetHex(_filename, Plus60(198), 1))
                    myCar1.Car.Sticker1 = GetHexStringFromBinary(GetHex(_filename, Plus60(208), 1))
                    myCar1.Car.Sticker2 = GetHexStringFromBinary(GetHex(_filename, Plus60(209), 1))
                    myCar1.Car.Sticker3 = GetHexStringFromBinary(GetHex(_filename, Plus60(210), 1))
                    myCar1.Car.Sticker4 = GetHexStringFromBinary(GetHex(_filename, Plus60(211), 1))
                    myCar1.Car.PlateNo = GetPlateNumber(GetHex(_filename, 284, 1), GetHex(_filename, 285, 1), GetHex(_filename, 286, 1))
                    myCar1.Car.ClassCode = GetPridePoint(GetHex(_filename, &H11A, 1), GetHex(_filename, &H11B, 1))
                    myCar1.Car.Hiragana = GetLevel(GetHex(_filename, 281, 1), True)
                    myCar1.Car.PlaceName = GetLevel(GetHex(_filename, 280, 1), True)
                    myCar1.Car.Transmission = GetTransmission(GetHex(_filename, 261, 1))
                    myCar1.Car.Param = Nothing
                    myCar1.Car.FullSpec = False
                    myCar1.Car.Engine = ""
                    myCar1.Car.Rollbar = ""
                    myCar1.Car.Edited = False
                    MyFlowLayoutPanel1.FP.Controls.Add(myCar1)
                End If
                If Not myCar2.CarName = "" Then
                    myCar2.Car = car2
                    myCar2.CarSlot = 2
                    myCar2.Version = _version
                    myCar2.FileName = _filename
                    myCar2.Extension = _extension
                    myCar2._parentForm = Me
                    myCar2.pbCar.Image = GetCarImage(myCar2.CarName)
                    myCar2.Car.ReplaceTo = Nothing
                    myCar2.Car.CarColor = GetHexStringFromBinary(GetHex(_filename, Plus60(294), 1))
                    myCar2.Car.Sticker1 = GetHexStringFromBinary(GetHex(_filename, Plus60(304), 1))
                    myCar2.Car.Sticker2 = GetHexStringFromBinary(GetHex(_filename, Plus60(305), 1))
                    myCar2.Car.Sticker3 = GetHexStringFromBinary(GetHex(_filename, Plus60(306), 1))
                    myCar2.Car.Sticker4 = GetHexStringFromBinary(GetHex(_filename, Plus60(307), 1))
                    myCar2.Car.PlateNo = GetPlateNumber(GetHex(_filename, 380, 1), GetHex(_filename, 381, 1), GetHex(_filename, 382, 1))
                    myCar2.Car.ClassCode = GetPridePoint(GetHex(_filename, &H17A, 1), GetHex(_filename, &H17B, 1))
                    myCar2.Car.Hiragana = GetLevel(GetHex(_filename, 377, 1), True)
                    myCar2.Car.PlaceName = GetLevel(GetHex(_filename, 376, 1), True)
                    myCar2.Car.Transmission = GetTransmission(GetHex(_filename, 357, 1))
                    myCar2.Car.Param = Nothing
                    myCar2.Car.FullSpec = False
                    myCar2.Car.Engine = ""
                    myCar2.Car.Rollbar = ""
                    myCar2.Car.Edited = False
                    MyFlowLayoutPanel1.FP.Controls.Add(myCar2)
                End If
                If Not myCar3.CarName = "" Then
                    myCar3.Car = car3
                    myCar3.CarSlot = 3
                    myCar3.Version = _version
                    myCar3.FileName = _filename
                    myCar3.Extension = _extension
                    myCar3._parentForm = Me
                    myCar3.pbCar.Image = GetCarImage(myCar3.CarName)
                    myCar3.Car.ReplaceTo = Nothing
                    myCar3.Car.CarColor = GetHexStringFromBinary(GetHex(_filename, Plus60(390), 1))
                    myCar3.Car.Sticker1 = GetHexStringFromBinary(GetHex(_filename, Plus60(400), 1))
                    myCar3.Car.Sticker2 = GetHexStringFromBinary(GetHex(_filename, Plus60(401), 1))
                    myCar3.Car.Sticker3 = GetHexStringFromBinary(GetHex(_filename, Plus60(402), 1))
                    myCar3.Car.Sticker4 = GetHexStringFromBinary(GetHex(_filename, Plus60(403), 1))
                    myCar3.Car.PlateNo = GetPlateNumber(GetHex(_filename, 476, 1), GetHex(_filename, 477, 1), GetHex(_filename, 478, 1))
                    myCar3.Car.ClassCode = GetPridePoint(GetHex(_filename, &H1DA, 1), GetHex(_filename, &H1DB, 1))
                    myCar3.Car.Hiragana = GetLevel(GetHex(_filename, 473, 1), True)
                    myCar3.Car.PlaceName = GetLevel(GetHex(_filename, 472, 1), True)
                    myCar3.Car.Transmission = GetTransmission(GetHex(_filename, 453, 1))
                    myCar3.Car.Param = Nothing
                    myCar3.Car.FullSpec = False
                    myCar3.Car.Engine = ""
                    myCar3.Car.Rollbar = ""
                    myCar3.Car.Edited = False
                    MyFlowLayoutPanel1.FP.Controls.Add(myCar3)
                End If
            Else
                txtName.Text = GetName(GetHex(_filename, Neg60(240), 12))
                txtGamePoint.Text = GetMilelage(GetHex(_filename, Neg60(192), 1), GetHex(_filename, Neg60(193), 1), GetHex(_filename, Neg60(194), 1), GetHex(_filename, Neg60(195), 1))
                cmbPlace.SelectedIndex = GetLevel(GetHex(_filename, &H1C, 1), True)
                Select Case _version
                    Case 4, &H4E
                        C4 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HC4)), 1))
                        C5 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HC5)), 1))
                        C6 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HC6)), 1))
                        C7 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HC7)), 1))
                        C8 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HC8)), 1))
                        C9 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HC9)), 1))
                        CA = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HCA)), 1))
                        CB = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HCB)), 1))
                        CC = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HCC)), 1))
                        CD = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HCD)), 1))
                        CE = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&HCE)), 1))
                        _221 = GetHexStringFromBinary(GetHex(_filename, Neg3C(Cid4(&H221)), 1))
                    Case Else
                        C4 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HC4), 1))
                        C5 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HC5), 1))
                        C6 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HC6), 1))
                        C7 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HC7), 1))
                        C8 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HC8), 1))
                        C9 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HC9), 1))
                        CA = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HCA), 1))
                        CB = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HCB), 1))
                        CC = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HCC), 1))
                        CD = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HCD), 1))
                        CE = GetHexStringFromBinary(GetHex(_filename, Neg3C(&HCE), 1))
                        _221 = GetHexStringFromBinary(GetHex(_filename, Neg3C(&H221), 1))
                End Select
                lblAvatarOffset.Text = C4 & C5 & C6 & C7 & C8 & C9 & CA & CB & CC & CD & CE
                GetAvatarFromCard()

                If _version = 6 Then
                    txtLevel.Text = GetLevel(GetHex(_filename, Neg60(164), 1), True)
                    txtChapLevel.Text = GetChapterLevel(GetHex(_filename, Neg60(548), 1))
                    txtPridePoint.Text = GetPridePoint(GetHex(_filename, Neg60(173), 1), GetHex(_filename, Neg60(174), 1))
                    txtMileage.Text = GetMilelage(GetHex(_filename, Neg60(1096), 1), GetHex(_filename, Neg60(1097), 1), GetHex(_filename, Neg60(1098), 1), GetHex(_filename, Neg60(1099), 1))
                    TabPage1.Enabled = True
                    myCar1.CarName = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 6)
                    myCar2.CarName = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 6)
                    myCar3.CarName = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 6)
                ElseIf _version = 7 Then
                    txtLevel.Text = GetLevel(GetHex(_filename, Neg60(163), 1), True)
                    TabPage2.Enabled = True
                    txtSPride.Text = GetPridePoint(GetHex(_filename, Neg60(170), 1), GetHex(_filename, Neg60(171), 1))
                    txtTPride.Text = GetPridePoint(GetHex(_filename, Neg60(172), 1), GetHex(_filename, Neg60(173), 1))
                    txtMileage.Text = GetMilelage(GetHex(_filename, Neg60(896), 1), GetHex(_filename, Neg60(897), 1), GetHex(_filename, Neg60(898), 1), GetHex(_filename, Neg60(899), 1))
                    myCar1.CarName = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 7)
                    myCar2.CarName = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 7)
                    myCar3.CarName = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 7)
                    cmbAura7.SelectedIndex = GetID7Aura(GetHex(_filename, 884, 1))
                    txtLegend.Text = GetPridePoint(GetHex(_filename, Neg3C(&H390), 1), GetHex(_filename, Neg3C(&H391), 1))
                    txtTAttack.Text = GetPridePoint(GetHex(_filename, Neg3C(&H392), 1), GetHex(_filename, Neg3C(&H393), 1))
                    txtNational.Text = GetPridePoint(GetHex(_filename, Neg3C(&H394), 1), GetHex(_filename, Neg3C(&H395), 1))
                    txtStore.Text = GetPridePoint(GetHex(_filename, Neg3C(&H396), 1), GetHex(_filename, Neg3C(&H397), 1))
                    txtTag.Text = GetPridePoint(GetHex(_filename, Neg3C(&H398), 1), GetHex(_filename, Neg3C(&H399), 1))
                    txtKanto.Text = GetPridePoint(GetHex(_filename, Neg3C(&H39A), 1), GetHex(_filename, Neg3C(&H39B), 1))
                    txtEvent.Text = GetPridePoint(GetHex(_filename, Neg3C(&H39C), 1), GetHex(_filename, Neg3C(&H39D), 1))
                ElseIf _version = 8 Then
                    TabPage3.Enabled = True
                    txtLevel.Text = GetLevel(GetHex(_filename, Neg60(163), 1), True, True)
                    txtMileage.Text = GetMilelage(GetHex(_filename, Neg60(944), 1), GetHex(_filename, Neg60(945), 1), GetHex(_filename, Neg60(946), 1), GetHex(_filename, Neg60(947), 1))
                    myCar1.CarName = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 8)
                    myCar2.CarName = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 8)
                    myCar3.CarName = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 8)
                    cmbAura8.SelectedIndex = GetID7Aura(GetHex(_filename, Neg60(&H3B4), 1))
                    txtInfRank.Text = GetPridePoint(GetHex(_filename, Neg60(&H236), 1), GetHex(_filename, Neg60(&H237), 1))
                    cmbTachometer.SelectedIndex = GetTachometer(GetHex(_filename, Neg60(&H223), 1))
                    cmbTitleEffect.SelectedIndex = GetTachometer(GetHex(_filename, Neg60(&H3B5), 1))
                    cmbTitle.SelectedIndex = GetPridePoint(GetHex(_filename, Neg60(&H3B6), 1), GetHex(_filename, Neg60(&H3B7), 1)) - 1
                    cmbCup.SelectedIndex = GetTachometer(GetHex(_filename, Neg60(&H222), 1))
                    LakeAkinaP = GetPridePoint(GetHex(_filename, Neg3C(&H380), 1), GetHex(_filename, Neg3C(&H381), 1))
                    MyogiP = GetPridePoint(GetHex(_filename, Neg3C(&H382), 1), GetHex(_filename, Neg3C(&H383), 1))
                    AkagiP = GetPridePoint(GetHex(_filename, Neg3C(&H384), 1), GetHex(_filename, Neg3C(&H385), 1))
                    AkinaP = GetPridePoint(GetHex(_filename, Neg3C(&H386), 1), GetHex(_filename, Neg3C(&H387), 1))
                    IrohazkaP = GetPridePoint(GetHex(_filename, Neg3C(&H388), 1), GetHex(_filename, Neg3C(&H389), 1))
                    TsukubaP = GetPridePoint(GetHex(_filename, Neg3C(&H38A), 1), GetHex(_filename, Neg3C(&H38B), 1))
                    HappogaharaP = GetPridePoint(GetHex(_filename, Neg3C(&H38C), 1), GetHex(_filename, Neg3C(&H38D), 1))
                    NagaoP = GetPridePoint(GetHex(_filename, Neg3C(&H38E), 1), GetHex(_filename, Neg3C(&H38F), 1))
                    TsubakiLineP = GetPridePoint(GetHex(_filename, Neg3C(&H390), 1), GetHex(_filename, Neg3C(&H391), 1))
                    UsuiP = GetPridePoint(GetHex(_filename, Neg3C(&H392), 1), GetHex(_filename, Neg3C(&H393), 1))
                    SadamineP = GetPridePoint(GetHex(_filename, Neg3C(&H394), 1), GetHex(_filename, Neg3C(&H395), 1))
                    TsuchisakaP = GetPridePoint(GetHex(_filename, Neg3C(&H396), 1), GetHex(_filename, Neg3C(&H397), 1))
                    AkinaSnowP = GetPridePoint(GetHex(_filename, Neg3C(&H398), 1), GetHex(_filename, Neg3C(&H399), 1))
                    HakoneP = GetPridePoint(GetHex(_filename, Neg3C(&H39A), 1), GetHex(_filename, Neg3C(&H39B), 1))
                    MomijiLineP = GetPridePoint(GetHex(_filename, Neg3C(&H39C), 1), GetHex(_filename, Neg3C(&H39D), 1))
                    NanamagariP = GetPridePoint(GetHex(_filename, Neg3C(&H39E), 1), GetHex(_filename, Neg3C(&H39F), 1))
                    cmbCourse8.SelectedIndex = 0
                    txtProficiency.Text = LakeAkinaP
                ElseIf _version = 4 Or &HE4 Then
                    txtLevel.Text = GetLevel(GetHex(_filename, Neg60(Cid4(164)), 1), True, True)
                    txtMileage.Text = GetMilelage(GetHex(_filename, Neg60(Cid4(944)), 1), GetHex(_filename, Neg60(Cid4(945)), 1), GetHex(_filename, Neg60(Cid4(946)), 1), GetHex(_filename, Neg60(Cid4(947)), 1))
                    myCar1.CarName = GetCar(GetHex(_filename, Neg60(Cid4(256)), 2), GetHex(_filename, Neg60(Cid4(271)), 1), 8)
                    myCar2.CarName = GetCar(GetHex(_filename, Neg60(Cid4(352)), 2), GetHex(_filename, Neg60(Cid4(367)), 1), 8)
                    myCar3.CarName = GetCar(GetHex(_filename, Neg60(Cid4(448)), 2), GetHex(_filename, Neg60(Cid4(463)), 1), 8)
                End If

                'Read Car
                If Not myCar1.CarName = "" Then
                    myCar1.Car = car1
                    myCar1.CarSlot = 1
                    myCar1.Version = _version
                    myCar1.FileName = _filename
                    myCar1.Extension = _extension
                    myCar1._parentForm = Me
                    myCar1.pbCar.Image = GetCarImage(myCar1.CarName)
                    myCar1.Car.ReplaceTo = Nothing
                    myCar1.Car.CarColor = GetHexStringFromBinary(GetHex(_filename, 198, 1))
                    myCar1.Car.Sticker1 = GetHexStringFromBinary(GetHex(_filename, 208, 1))
                    myCar1.Car.Sticker2 = GetHexStringFromBinary(GetHex(_filename, 209, 1))
                    myCar1.Car.Sticker3 = GetHexStringFromBinary(GetHex(_filename, 210, 1))
                    myCar1.Car.Sticker4 = GetHexStringFromBinary(GetHex(_filename, 211, 1))
                    myCar1.Car.PlateNo = GetPlateNumber(GetHex(_filename, Neg60(284), 1), GetHex(_filename, Neg60(285), 1), GetHex(_filename, Neg60(286), 1))
                    myCar1.Car.ClassCode = GetPridePoint(GetHex(_filename, Neg3C(&H11A), 1), GetHex(_filename, Neg3C(&H11B), 1))
                    myCar1.Car.Hiragana = GetLevel(GetHex(_filename, Neg60(281), 1), True)
                    myCar1.Car.PlaceName = GetLevel(GetHex(_filename, Neg60(280), 1), True)
                    myCar1.Car.Transmission = GetTransmission(GetHex(_filename, Neg60(261), 1))
                    myCar1.Car.Param = Nothing
                    myCar1.Car.FullSpec = False
                    myCar1.Car.Engine = ""
                    myCar1.Car.Rollbar = ""
                    myCar1.Car.Edited = False
                    MyFlowLayoutPanel1.FP.Controls.Add(myCar1)
                End If
                If Not myCar2.CarName = "" Then
                    myCar2.Car = car2
                    myCar2.CarSlot = 2
                    myCar2.Version = _version
                    myCar2.FileName = _filename
                    myCar2.Extension = _extension
                    myCar2._parentForm = Me
                    myCar2.pbCar.Image = GetCarImage(myCar2.CarName)
                    myCar2.Car.ReplaceTo = Nothing
                    myCar2.Car.CarColor = GetHexStringFromBinary(GetHex(_filename, 294, 1))
                    myCar2.Car.Sticker1 = GetHexStringFromBinary(GetHex(_filename, 304, 1))
                    myCar2.Car.Sticker2 = GetHexStringFromBinary(GetHex(_filename, 305, 1))
                    myCar2.Car.Sticker3 = GetHexStringFromBinary(GetHex(_filename, 306, 1))
                    myCar2.Car.Sticker4 = GetHexStringFromBinary(GetHex(_filename, 307, 1))
                    myCar2.Car.PlateNo = GetPlateNumber(GetHex(_filename, Neg60(380), 1), GetHex(_filename, Neg60(381), 1), GetHex(_filename, Neg60(382), 1))
                    myCar2.Car.ClassCode = GetPridePoint(GetHex(_filename, Neg3C(&H17A), 1), GetHex(_filename, Neg3C(&H17B), 1))
                    myCar2.Car.Hiragana = GetLevel(GetHex(_filename, Neg60(377), 1), True)
                    myCar2.Car.PlaceName = GetLevel(GetHex(_filename, Neg60(376), 1), True)
                    myCar2.Car.Transmission = GetTransmission(GetHex(_filename, Neg60(357), 1))
                    myCar2.Car.Param = Nothing
                    myCar2.Car.FullSpec = False
                    myCar2.Car.Engine = ""
                    myCar2.Car.Rollbar = ""
                    myCar2.Car.Edited = False
                    MyFlowLayoutPanel1.FP.Controls.Add(myCar2)
                End If
                If Not myCar3.CarName = "" Then
                    myCar3.Car = car3
                    myCar3.CarSlot = 3
                    myCar3.Version = _version
                    myCar3.FileName = _filename
                    myCar3.Extension = _extension
                    myCar3._parentForm = Me
                    myCar3.pbCar.Image = GetCarImage(myCar3.CarName)
                    myCar3.Car.ReplaceTo = Nothing
                    myCar3.Car.CarColor = GetHexStringFromBinary(GetHex(_filename, 390, 1))
                    myCar3.Car.Sticker1 = GetHexStringFromBinary(GetHex(_filename, 400, 1))
                    myCar3.Car.Sticker2 = GetHexStringFromBinary(GetHex(_filename, 401, 1))
                    myCar3.Car.Sticker3 = GetHexStringFromBinary(GetHex(_filename, 402, 1))
                    myCar3.Car.Sticker4 = GetHexStringFromBinary(GetHex(_filename, 403, 1))
                    myCar3.Car.PlateNo = GetPlateNumber(GetHex(_filename, Neg60(476), 1), GetHex(_filename, Neg60(477), 1), GetHex(_filename, Neg60(478), 1))
                    myCar3.Car.ClassCode = GetPridePoint(GetHex(_filename, Neg3C(&H1DA), 1), GetHex(_filename, Neg3C(&H1DB), 1))
                    myCar3.Car.Hiragana = GetLevel(GetHex(_filename, Neg60(473), 1), True)
                    myCar3.Car.PlaceName = GetLevel(GetHex(_filename, Neg60(472), 1), True)
                    myCar3.Car.Transmission = GetTransmission(GetHex(_filename, Neg60(453), 1))
                    myCar3.Car.Param = Nothing
                    myCar3.Car.FullSpec = False
                    myCar3.Car.Engine = ""
                    myCar3.Car.Rollbar = ""
                    myCar3.Car.Edited = False
                    MyFlowLayoutPanel1.FP.Controls.Add(myCar3)
                End If
            End If

            finishLoading = True
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Me.Text = String.Format(ReadCfgValue("EditMeText", langFile), Path.GetFileName(_filename))
            NsTheme1.Text = Me.Text
            Label1.Text = ReadCfgValue("Name", langFile)
            Label2.Text = ReadCfgValue("Gender", langFile)
            Label6.Text = ReadCfgValue("Level", langFile)
            Label7.Text = ReadCfgValue("PridePoint", langFile)
            Label8.Text = ReadCfgValue("ChapterLevel", langFile)
            Label13.Text = ReadCfgValue("Mileage", langFile)
            Label14.Text = ReadCfgValue("GamePoint", langFile)
            Label9.Text = ReadCfgValue("SinglePride", langFile)
            Label11.Text = ReadCfgValue("TagPride", langFile)
            cbLegend.Text = ReadCfgValue("Legend", langFile)
            btnSave.Text = ReadCfgValue("Save", langFile)
            TabPage1.Text = ReadCfgValue("EditTab6", langFile)
            TabPage2.Text = ReadCfgValue("EditTab7", langFile)
            TabPage3.Text = ReadCfgValue("EditTab8", langFile)
            tpAvatar.Text = ReadCfgValue("Avatar", langFile)
            Label10.Text = ReadCfgValue("Category", langFile)
            Label12.Text = ReadCfgValue("Selection", langFile)
            mouth_t = ReadCfgValue("Mouth", langFile)
            eyes_t = ReadCfgValue("Eyes", langFile)
            face_skin_t = ReadCfgValue("Skin", langFile)
            accessories_t = ReadCfgValue("Misc", langFile)
            shades_t = ReadCfgValue("Specs", langFile)
            hair_t = ReadCfgValue("Hair", langFile)
            shirt_t = ReadCfgValue("Shirt", langFile)
            frame_t = ReadCfgValue("Frame", langFile)
            slblMouth.Text = mouth_t
            slblEyes.Text = eyes_t
            slblSkin.Text = face_skin_t
            slblAccessories.Text = accessories_t
            slblShades.Text = shades_t
            slblHair.Text = hair_t
            slblShirt.Text = shirt_t
            slblFrame.Text = frame_t
            slblMouth2.Text = mouth_t
            slblEyes2.Text = eyes_t
            slblSkin2.Text = face_skin_t
            slblAccessories2.Text = accessories_t
            slblShades2.Text = shades_t
            slblHair2.Text = hair_t
            slblShirt2.Text = shirt_t
            slblFrame2.Text = frame_t
            slblPreview.Text = ReadCfgValue("Preview", langFile)
            male = ReadCfgValue("Male", langFile)
            female = ReadCfgValue("Female", langFile)
            btnSet.Text = ReadCfgValue("Apply", langFile)
            tpBasic.Text = ReadCfgValue("Basic", langFile)
            tpCar.Text = ReadCfgValue("CarEditor", langFile)
            cbSaveAvatar.Text = ReadCfgValue("SaveAvatar", langFile)
            coming_soon = ReadCfgValue("ComingSoon", langFile)
            must_select_avatar = ReadCfgValue("MustSelectAvatar", langFile)
            Label15.Text = ReadCfgValue("Aura", langFile)
            Label24.Text = Label15.Text
            a7_none = ReadCfgValue("None", langFile)
            a7_hot = ReadCfgValue("ScorchingHot", langFile)
            a7_wind = ReadCfgValue("Whirlwind", langFile)
            a7_light = ReadCfgValue("Lightning", langFile)
            a7_sprit = ReadCfgValue("EvilSpirit", langFile)
            a7_overlord = ReadCfgValue("Overlord", langFile)
            a7_fly = ReadCfgValue("Wings", langFile)
            cbGRumble.Text = ReadCfgValue("GRumble", langFile)
            Label16.Text = ReadCfgValue("Region", langFile)
            Label19.Text = ReadCfgValue("StreetLegend", langFile)
            Label17.Text = ReadCfgValue("TimeAttack", langFile)
            Label20.Text = ReadCfgValue("NationalBattle", langFile)
            Label18.Text = ReadCfgValue("InStoreBattle", langFile)
            Label22.Text = ReadCfgValue("TAGBattle", langFile)
            Label21.Text = ReadCfgValue("OperationKanto", langFile)
            Label23.Text = ReadCfgValue("EventBattle", langFile)
            NsGroupBox1.Title = ReadCfgValue("XMarks", langFile)
            import_complete = ReadCfgValue("ImportComplete", langFile)
            Label25.Text = ReadCfgValue("InfRank", langFile)
            Label26.Text = ReadCfgValue("Tachometer", langFile)
            NsGroupBox2.Title = ReadCfgValue("Preview", langFile)
            NsGroupBox3.Title = ReadCfgValue("Preview", langFile)
            Label27.Text = ReadCfgValue("TitleEffect", langFile)
            c8_paper = ReadCfgValue("PaperCup", langFile)
            c8_orange = ReadCfgValue("OrangeJuice", langFile)
            c8_tea = ReadCfgValue("GreenTea", langFile)
            Label28.Text = ReadCfgValue("Cup", langFile)
            cbUnlockExSpec.Text = ReadCfgValue("ExFullAllCar", langFile)
            Label29.Text = ReadCfgValue("TitleName", langFile)
            cbRiseUp.Text = ReadCfgValue("RiseUp", langFile)
            Label37.Text = ReadCfgValue("Course", langFile)
            Label34.Text = ReadCfgValue("Proficiency", langFile)
            NsGroupBox4.Title = ReadCfgValue("CProficiency", langFile)
            cbStorySuperb.Text = ReadCfgValue("StorySuperb", langFile)
            LakeAkina = ReadCfgValue("LakeAkina", langFile)
            Myogi = ReadCfgValue("Myogi", langFile)
            Usui = ReadCfgValue("Usui", langFile)
            Akagi = ReadCfgValue("Akagi", langFile)
            Akina = ReadCfgValue("Akina", langFile)
            Irohazka = ReadCfgValue("Irohazaka", langFile)
            Happogahara = ReadCfgValue("Happogahara", langFile)
            Nagao = ReadCfgValue("Nagao", langFile)
            Tsukuba = ReadCfgValue("Tsukuba", langFile)
            TsubakiLine = ReadCfgValue("TsubakiLine", langFile)
            Nanamagari = ReadCfgValue("Namagari", langFile)
            Sadamine = ReadCfgValue("Sadamine", langFile)
            Tsuchisaka = ReadCfgValue("Tsuchisaka", langFile)
            AkinaSnow = ReadCfgValue("SnowAkina", langFile)
            Hakone = ReadCfgValue("Hakone", langFile)
            MomijiLine = ReadCfgValue("MomijiLine", langFile)
            cbStoryHack.Text = ReadCfgValue("D8StoryHack", langFile)
            cbInfinitySide.Text = ReadCfgValue("InfinitySide", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChapLevel.KeyPress, txtLevel.KeyPress, txtPridePoint.KeyPress, txtSPride.KeyPress, txtTPride.KeyPress, txtEvent.KeyPress, txtKanto.KeyPress, txtLegend.KeyPress, txtNational.KeyPress, txtStore.KeyPress, txtTag.KeyPress, txtTAttack.KeyPress, txtInfRank.KeyPress, txtProficiency.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Control Or
           Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Back Then
                Return
            End If
            e.Handled = True
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub cmbAvatarCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAvatarCat.SelectedIndexChanged
        Try
            cmbAvatar.DataSource = Nothing
            cmbAvatar.Items.Clear()
            cmbAvatar.DisplayMember = "Key"
            cmbAvatar.ValueMember = "Value"

            If cmbGender.SelectedIndex = 1 Then
                Select Case cmbAvatarCat.SelectedValue.ToString
                    Case "MOUTH"
                        cmbAvatar.DataSource = New BindingSource(mouth_f, Nothing)
                    Case "EYES"
                        cmbAvatar.DataSource = New BindingSource(eyes_f, Nothing)
                    Case "SKIN"
                        cmbAvatar.DataSource = New BindingSource(skin_f, Nothing)
                    Case "ACCESSORIES"
                        cmbAvatar.DataSource = New BindingSource(accessories_f, Nothing)
                    Case "SHIRT"
                        cmbAvatar.DataSource = New BindingSource(shirt_f, Nothing)
                    Case "SHADES"
                        cmbAvatar.DataSource = New BindingSource(shades_f, Nothing)
                    Case "HAIR"
                        cmbAvatar.DataSource = New BindingSource(hair_f, Nothing)
                    Case "FRAME"
                        cmbAvatar.DataSource = New BindingSource(frame, Nothing)
                End Select
            Else
                Select Case cmbAvatarCat.SelectedValue.ToString
                    Case "MOUTH"
                        cmbAvatar.DataSource = New BindingSource(mouth_m, Nothing)
                    Case "EYES"
                        cmbAvatar.DataSource = New BindingSource(eyes_m, Nothing)
                    Case "SKIN"
                        cmbAvatar.DataSource = New BindingSource(skin_m, Nothing)
                    Case "ACCESSORIES"
                        cmbAvatar.DataSource = New BindingSource(accessories_m, Nothing)
                    Case "SHIRT"
                        cmbAvatar.DataSource = New BindingSource(shirt_m, Nothing)
                    Case "SHADES"
                        cmbAvatar.DataSource = New BindingSource(shades_m, Nothing)
                    Case "HAIR"
                        cmbAvatar.DataSource = New BindingSource(hair_m, Nothing)
                    Case "FRAME"
                        cmbAvatar.DataSource = New BindingSource(frame, Nothing)
                End Select
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub cmbAvatar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAvatar.SelectedIndexChanged
        Try
            If cmbAvatar.SelectedItem IsNot Nothing Then
                pbPreview.BackgroundImage = cmbAvatar.SelectedValue.Bitmap
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

#Region "Avatar Dictionary"
    Private Sub DictionaryAdd6()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Dim i As Integer = 0

            If cmbGender.SelectedIndex = 1 Then
                'Female
                'Add Mouth
                Dim mouth As New InitialD6.Female.Mouth
                i = 0
                For Each mo In mouth.list
                    If mouth_f.ContainsKey(ReadCfgValue("D6F_MO_" & mo.Tag, langFile, i)) Then
                        mouth_f.Add(ReadCfgValue("D6F_MO_" & mo.Tag & " (Duplicate)", langFile, i), mo)
                    Else
                        mouth_f.Add(ReadCfgValue("D6F_MO_" & mo.Tag, langFile, i), mo)
                    End If
                    i += 1
                Next

                'Add Skin
                Dim skin As New InitialD6.Female.Skin
                i = 0
                For Each sk In skin.list
                    If skin_f.ContainsKey(ReadCfgValue("D6F_SK_" & sk.Tag, langFile, i)) Then
                        skin_f.Add(ReadCfgValue("D6F_SK_" & sk.Tag & " (Duplicate)", langFile, i), sk)
                    Else
                        skin_f.Add(ReadCfgValue("D6F_SK_" & sk.Tag, langFile, i), sk)
                    End If
                    i += 1
                Next

                'Add Shirt
                Dim shirt As New InitialD6.Female.Shirt
                i = 0
                For Each sh In shirt.list
                    If shirt_f.ContainsKey(ReadCfgValue("D6F_SH_" & sh.Tag, langFile, i)) Then
                        shirt_f.Add(ReadCfgValue("D6F_SH_" & sh.Tag & " (Duplicate)", langFile, i), sh)
                    Else
                        shirt_f.Add(ReadCfgValue("D6F_SH_" & sh.Tag, langFile, i), sh)
                    End If
                    i += 1
                Next

                'Add Eyes
                Dim eyes As New InitialD6.Female.Eyes
                i = 0
                For Each ey In eyes.list
                    If eyes_f.ContainsKey(ReadCfgValue("D6F_EY_" & ey.Tag, langFile, i)) Then
                        eyes_f.Add(ReadCfgValue("D6F_EY_" & ey.Tag & " (Duplicate)", langFile, i), ey)
                    Else
                        eyes_f.Add(ReadCfgValue("D6F_EY_" & ey.Tag, langFile, i), ey)
                    End If
                    i += 1
                Next

                'Add Accessories
                Dim accessories As New InitialD6.Female.Accessories
                i = 0
                For Each ac In accessories.list
                    If accessories_f.ContainsKey(ReadCfgValue("D6F_AC_" & ac.Tag, langFile, i)) Then
                        accessories_f.Add(ReadCfgValue("D6F_AC_" & ac.Tag & " (Duplicate)", langFile, i), ac)
                    Else
                        accessories_f.Add(ReadCfgValue("D6F_AC_" & ac.Tag, langFile, i), ac)
                    End If
                    i += 1
                Next

                'Add Shades
                Dim shades As New InitialD6.Female.Shades
                i = 0
                For Each sp In shades.list
                    If shades_f.ContainsKey(ReadCfgValue("D6F_SP_" & sp.Tag, langFile, i)) Then
                        shades_f.Add(ReadCfgValue("D6F_SP_" & sp.Tag & " (Duplicate)", langFile, i), sp)
                    Else
                        shades_f.Add(ReadCfgValue("D6F_SP_" & sp.Tag, langFile, i), sp)
                    End If
                    i += 1
                Next

                'Add Hair
                Dim hair As New InitialD6.Female.Hair
                i = 0
                For Each ha In hair.list
                    If hair_f.ContainsKey(ReadCfgValue("D6F_HA_" & ha.Tag, langFile, i)) Then
                        hair_f.Add(ReadCfgValue("D6F_HA_" & ha.Tag & " (Duplicate)", langFile, i), ha)
                    Else
                        hair_f.Add(ReadCfgValue("D6F_HA_" & ha.Tag, langFile, i), ha)
                    End If
                    i += 1
                Next
            Else
                'Male
                'Add Skin
                Dim skin2 As New InitialD6.Male.Skin
                i = 0
                For Each sk2 In skin2.list
                    If skin_m.ContainsKey(ReadCfgValue("D6M_SK_" & sk2.Tag, langFile, i)) Then
                        skin_m.Add(ReadCfgValue("D6M_SK_" & sk2.Tag & " (Duplicate)", langFile, i), sk2)
                    Else
                        skin_m.Add(ReadCfgValue("D6M_SK_" & sk2.Tag, langFile, i), sk2)
                    End If
                    i += 1
                Next

                'Add Shirt
                Dim shirt2 As New InitialD6.Male.Shirt
                i = 0
                For Each sh2 In shirt2.list
                    If shirt_m.ContainsKey(ReadCfgValue("D6M_SH_" & sh2.Tag, langFile, i)) Then
                        shirt_m.Add(ReadCfgValue("D6M_SH_" & sh2.Tag & " (Duplicate)", langFile, i), sh2)
                    Else
                        shirt_m.Add(ReadCfgValue("D6M_SH_" & sh2.Tag, langFile, i), sh2)
                    End If
                    i += 1
                Next

                'Add Eyes
                Dim eyes2 As New InitialD6.Male.Eyes
                i = 0
                For Each ey2 In eyes2.list
                    If eyes_m.ContainsKey(ReadCfgValue("D6M_EY_" & ey2.Tag, langFile, i)) Then
                        eyes_m.Add(ReadCfgValue("D6M_EY_" & ey2.Tag & " (Duplicate)", langFile, i), ey2)
                    Else
                        eyes_m.Add(ReadCfgValue("D6M_EY_" & ey2.Tag, langFile, i), ey2)
                    End If
                    i += 1
                Next

                'Add Mouth
                Dim mouth2 As New InitialD6.Male.Mouth
                i = 0
                For Each mo2 In mouth2.list
                    If mouth_m.ContainsKey(ReadCfgValue("D6M_MO_" & mo2.Tag, langFile, i)) Then
                        mouth_m.Add(ReadCfgValue("D6M_MO_" & mo2.Tag & " (Duplicate)", langFile, i), mo2)
                    Else
                        mouth_m.Add(ReadCfgValue("D6M_MO_" & mo2.Tag, langFile, i), mo2)
                    End If
                    i += 1
                Next

                'Add Accessories
                Dim accessories2 As New InitialD6.Male.Accessories
                i = 0
                For Each ac2 In accessories2.list
                    If accessories_m.ContainsKey(ReadCfgValue("D6M_AC_" & ac2.Tag, langFile, i)) Then
                        accessories_m.Add(ReadCfgValue("D6M_AC_" & ac2.Tag & " (Duplicate)", langFile, i), ac2)
                    Else
                        accessories_m.Add(ReadCfgValue("D6M_AC_" & ac2.Tag, langFile, i), ac2)
                    End If
                    i += 1
                Next

                'Add shades
                Dim shades2 As New InitialD6.Male.Shades
                i = 0
                For Each sp2 In shades2.list
                    If shades_m.ContainsKey(ReadCfgValue("D6M_SP_" & sp2.Tag, langFile, i)) Then
                        shades_m.Add(ReadCfgValue("D6M_SP_" & sp2.Tag & " (Duplicate)", langFile, i), sp2)
                    Else
                        shades_m.Add(ReadCfgValue("D6M_SP_" & sp2.Tag, langFile, i), sp2)
                    End If
                    i += 1
                Next

                'Add Hair
                Dim hair2 As New InitialD6.Male.Hair
                i = 0
                For Each ha2 In hair2.list
                    If hair_m.ContainsKey(ReadCfgValue("D6M_HA_" & ha2.Tag, langFile, i)) Then
                        hair_m.Add(ReadCfgValue("D6M_HA_" & ha2.Tag & " (Duplicate)", langFile, i), ha2)
                    Else
                        hair_m.Add(ReadCfgValue("D6M_HA_" & ha2.Tag, langFile, i), ha2)
                    End If
                    i += 1
                Next
            End If

            'Add Frame
            Dim fm As New InitialD7.Share.Frame
            i = 0
            For Each f In fm.list
                If frame.ContainsKey(ReadCfgValue("D7_FR_" & f.Tag, langFile, i)) Then
                    frame.Add(ReadCfgValue("D7_FR_" & f.Tag & " (Duplicate)", langFile, i), f)
                Else
                    frame.Add(ReadCfgValue("D7_FR_" & f.Tag, langFile, i), f)
                End If
                i += 1
            Next

            'Add Category
            category.Add(face_skin_t, "SKIN")
            category.Add(hair_t, "HAIR")
            category.Add(eyes_t, "EYES")
            category.Add(shades_t, "SHADES")
            category.Add(mouth_t, "MOUTH")
            category.Add(shirt_t, "SHIRT")
            category.Add(accessories_t, "ACCESSORIES")
            category.Add(frame_t, "FRAME")
            cmbAvatarCat.DisplayMember = "Key"
            cmbAvatarCat.ValueMember = "Value"
            cmbAvatarCat.DataSource = New BindingSource(category, Nothing)
            cmbAvatarCat.SelectedIndex = 0
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub DictionaryAdd7()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Dim i As Integer = 0

            If cmbGender.SelectedIndex = 1 Then
                'Female
                'Add Mouth
                Dim mouth As New InitialD7.Female.Mouth
                i = 0
                For Each mo In mouth.list
                    If mouth_f.ContainsKey(ReadCfgValue("D7F_MO_" & mo.Tag, langFile, i)) Then
                        mouth_f.Add(ReadCfgValue("D7F_MO_" & mo.Tag & " (Duplicate)", langFile, i), mo)
                    Else
                        mouth_f.Add(ReadCfgValue("D7F_MO_" & mo.Tag, langFile, i), mo)
                    End If
                    i += 1
                Next

                'Add Skin
                Dim skin As New InitialD7.Female.Skin
                i = 0
                For Each sk In skin.list
                    If skin_f.ContainsKey(ReadCfgValue("D7F_SK_" & sk.Tag, langFile, i)) Then
                        skin_f.Add(ReadCfgValue("D7F_SK_" & sk.Tag & " (Duplicate)", langFile, i), sk)
                    Else
                        skin_f.Add(ReadCfgValue("D7F_SK_" & sk.Tag, langFile, i), sk)
                    End If
                    i += 1
                Next

                'Add Shirt
                Dim shirt As New InitialD7.Female.Shirt
                i = 0
                For Each sh In shirt.list
                    If shirt_f.ContainsKey(ReadCfgValue("D7F_SH_" & sh.Tag, langFile, i)) Then
                        shirt_f.Add(ReadCfgValue("D7F_SH_" & sh.Tag & " (Duplicate)", langFile, i), sh)
                    Else
                        shirt_f.Add(ReadCfgValue("D7F_SH_" & sh.Tag, langFile, i), sh)
                    End If
                    i += 1
                Next

                'Add Eyes
                Dim eyes As New InitialD7.Female.Eyes
                i = 0
                For Each ey In eyes.list
                    If eyes_f.ContainsKey(ReadCfgValue("D7F_EY_" & ey.Tag, langFile, i)) Then
                        eyes_f.Add(ReadCfgValue("D7F_EY_" & ey.Tag & " (Duplicate)", langFile, i), ey)
                    Else
                        eyes_f.Add(ReadCfgValue("D7F_EY_" & ey.Tag, langFile, i), ey)
                    End If
                    i += 1
                Next

                'Add Accessories
                Dim accessories As New InitialD7.Female.Accessories
                i = 0
                For Each ac In accessories.list
                    If accessories_f.ContainsKey(ReadCfgValue("D7F_AC_" & ac.Tag, langFile, i)) Then
                        accessories_f.Add(ReadCfgValue("D7F_AC_" & ac.Tag & " (Duplicate)", langFile, i), ac)
                    Else
                        accessories_f.Add(ReadCfgValue("D7F_AC_" & ac.Tag, langFile, i), ac)
                    End If
                    i += 1
                Next

                'Add Shades
                Dim shades As New InitialD7.Female.Shades
                i = 0
                For Each sp In shades.list
                    If shades_f.ContainsKey(ReadCfgValue("D7F_SP_" & sp.Tag, langFile, i)) Then
                        shades_f.Add(ReadCfgValue("D7F_SP_" & sp.Tag & " (Duplicate)", langFile, i), sp)
                    Else
                        shades_f.Add(ReadCfgValue("D7F_SP_" & sp.Tag, langFile, i), sp)
                    End If
                    i += 1
                Next

                'Add Hair
                Dim hair As New InitialD7.Female.Hair
                i = 0
                For Each ha In hair.list
                    If hair_f.ContainsKey(ReadCfgValue("D7F_HA_" & ha.Tag, langFile, i)) Then
                        hair_f.Add(ReadCfgValue("D7F_HA_" & ha.Tag & " (Duplicate)", langFile, i), ha)
                    Else
                        hair_f.Add(ReadCfgValue("D7F_HA_" & ha.Tag, langFile, i), ha)
                    End If
                    i += 1
                Next
            Else
                'Male
                'Add Skin
                Dim skin2 As New InitialD7.Male.Skin
                i = 0
                For Each sk2 In skin2.list
                    If skin_m.ContainsKey(ReadCfgValue("D7M_SK_" & sk2.Tag, langFile, i)) Then
                        skin_m.Add(ReadCfgValue("D7M_SK_" & sk2.Tag & " (Duplicate)", langFile, i), sk2)
                    Else
                        skin_m.Add(ReadCfgValue("D7M_SK_" & sk2.Tag, langFile, i), sk2)
                    End If
                    i += 1
                Next

                'Add Shirt
                Dim shirt2 As New InitialD7.Male.Shirt
                i = 0
                For Each sh2 In shirt2.list
                    If shirt_m.ContainsKey(ReadCfgValue("D7M_SH_" & sh2.Tag, langFile, i)) Then
                        shirt_m.Add(ReadCfgValue("D7M_SH_" & sh2.Tag & " (Duplicate)", langFile, i), sh2)
                    Else
                        shirt_m.Add(ReadCfgValue("D7M_SH_" & sh2.Tag, langFile, i), sh2)
                    End If
                    i += 1
                Next

                'Add Eyes
                Dim eyes2 As New InitialD7.Male.Eyes
                i = 0
                For Each ey2 In eyes2.list
                    If eyes_m.ContainsKey(ReadCfgValue("D7M_EY_" & ey2.Tag, langFile, i)) Then
                        eyes_m.Add(ReadCfgValue("D7M_EY_" & ey2.Tag & " (Duplicate)", langFile, i), ey2)
                    Else
                        eyes_m.Add(ReadCfgValue("D7M_EY_" & ey2.Tag, langFile, i), ey2)
                    End If
                    i += 1
                Next

                'Add Mouth
                Dim mouth2 As New InitialD7.Male.Mouth
                i = 0
                For Each mo2 In mouth2.list
                    If mouth_m.ContainsKey(ReadCfgValue("D7M_MO_" & mo2.Tag, langFile, i)) Then
                        mouth_m.Add(ReadCfgValue("D7M_MO_" & mo2.Tag & " (Duplicate)", langFile, i), mo2)
                    Else
                        mouth_m.Add(ReadCfgValue("D7M_MO_" & mo2.Tag, langFile, i), mo2)
                    End If
                    i += 1
                Next

                'Add Accessories
                Dim accessories2 As New InitialD7.Male.Accessories
                i = 0
                For Each ac2 In accessories2.list
                    If accessories_m.ContainsKey(ReadCfgValue("D7M_AC_" & ac2.Tag, langFile, i)) Then
                        accessories_m.Add(ReadCfgValue("D7M_AC_" & ac2.Tag & " (Duplicate)", langFile, i), ac2)
                    Else
                        accessories_m.Add(ReadCfgValue("D7M_AC_" & ac2.Tag, langFile, i), ac2)
                    End If
                    i += 1
                Next

                'Add shades
                Dim shades2 As New InitialD7.Male.Shades
                i = 0
                For Each sp2 In shades2.list
                    If shades_m.ContainsKey(ReadCfgValue("D7M_SP_" & sp2.Tag, langFile, i)) Then
                        shades_m.Add(ReadCfgValue("D7M_SP_" & sp2.Tag & " (Duplicate)", langFile, i), sp2)
                    Else
                        shades_m.Add(ReadCfgValue("D7M_SP_" & sp2.Tag, langFile, i), sp2)
                    End If
                    i += 1
                Next

                'Add Hair
                Dim hair2 As New InitialD7.Male.Hair
                i = 0
                For Each ha2 In hair2.list
                    If hair_m.ContainsKey(ReadCfgValue("D7M_HA_" & ha2.Tag, langFile, i)) Then
                        hair_m.Add(ReadCfgValue("D7M_HA_" & ha2.Tag & " (Duplicate)", langFile, i), ha2)
                    Else
                        hair_m.Add(ReadCfgValue("D7M_HA_" & ha2.Tag, langFile, i), ha2)
                    End If
                    i += 1
                Next
            End If

            'Add Frame
            Dim fm As New InitialD7.Share.Frame
            i = 0
            For Each f In fm.list
                If frame.ContainsKey(ReadCfgValue("D7_FR_" & f.Tag, langFile, i)) Then
                    frame.Add(ReadCfgValue("D7_FR_" & f.Tag & " (Duplicate)", langFile, i), f)
                Else
                    frame.Add(ReadCfgValue("D7_FR_" & f.Tag, langFile, i), f)
                End If
                i += 1
            Next

            'Add Category
            category.Add(face_skin_t, "SKIN")
            category.Add(hair_t, "HAIR")
            category.Add(eyes_t, "EYES")
            category.Add(shades_t, "SHADES")
            category.Add(mouth_t, "MOUTH")
            category.Add(shirt_t, "SHIRT")
            category.Add(accessories_t, "ACCESSORIES")
            category.Add(frame_t, "FRAME")
            cmbAvatarCat.DisplayMember = "Key"
            cmbAvatarCat.ValueMember = "Value"
            cmbAvatarCat.DataSource = New BindingSource(category, Nothing)
            cmbAvatarCat.SelectedIndex = 0
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub DictionaryAdd8()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Dim i As Integer = 0

            If cmbGender.SelectedIndex = 1 Then
                'Female
                'Add Mouth
                Dim mouth As New InitialD8.Female.Mouth
                i = 0
                For Each mo In mouth.list
                    If mouth_f.ContainsKey(ReadCfgValue("D8F_MO_" & mo.Tag, langFile, i)) Then
                        mouth_f.Add(ReadCfgValue("D8F_MO_" & mo.Tag & " (Duplicate)", langFile, i), mo)
                    Else
                        mouth_f.Add(ReadCfgValue("D8F_MO_" & mo.Tag, langFile, i), mo)
                    End If
                    i += 1
                Next

                'Add Skin
                Dim skin As New InitialD8.Female.Skin
                i = 0
                For Each sk In skin.list
                    If skin_f.ContainsKey(ReadCfgValue("D8F_SK_" & sk.Tag, langFile, i)) Then
                        skin_f.Add(ReadCfgValue("D8F_SK_" & sk.Tag & " (Duplicate)", langFile, i), sk)
                    Else
                        skin_f.Add(ReadCfgValue("D8F_SK_" & sk.Tag, langFile, i), sk)
                    End If
                    i += 1
                Next

                'Add Shirt
                Dim shirt As New InitialD8.Female.Shirt
                i = 0
                For Each sh In shirt.list
                    If shirt_f.ContainsKey(ReadCfgValue("D8F_SH_" & sh.Tag, langFile, i)) Then
                        shirt_f.Add(ReadCfgValue("D8F_SH_" & sh.Tag & " (Duplicate)", langFile, i), sh)
                    Else
                        shirt_f.Add(ReadCfgValue("D8F_SH_" & sh.Tag, langFile, i), sh)
                    End If
                    i += 1
                Next

                'Add Eyes
                Dim eyes As New InitialD8.Female.Eyes
                i = 0
                For Each ey In eyes.list
                    If eyes_f.ContainsKey(ReadCfgValue("D8F_EY_" & ey.Tag, langFile, i)) Then
                        eyes_f.Add(ReadCfgValue("D8F_EY_" & ey.Tag & " (Duplicate)", langFile, i), ey)
                    Else
                        eyes_f.Add(ReadCfgValue("D8F_EY_" & ey.Tag, langFile, i), ey)
                    End If
                    i += 1
                Next

                'Add Accessories
                Dim accessories As New InitialD8.Female.Accessories
                i = 0
                For Each ac In accessories.list
                    If accessories_f.ContainsKey(ReadCfgValue("D8F_AC_" & ac.Tag, langFile, i)) Then
                        accessories_f.Add(ReadCfgValue("D8F_AC_" & ac.Tag & " (Duplicate)", langFile, i), ac)
                    Else
                        accessories_f.Add(ReadCfgValue("D8F_AC_" & ac.Tag, langFile, i), ac)
                    End If
                    i += 1
                Next

                'Add Shades
                Dim shades As New InitialD8.Female.Shades
                i = 0
                For Each sp In shades.list
                    If shades_f.ContainsKey(ReadCfgValue("D8F_SP_" & sp.Tag, langFile, i)) Then
                        shades_f.Add(ReadCfgValue("D8F_SP_" & sp.Tag & " (Duplicate)", langFile, i), sp)
                    Else
                        shades_f.Add(ReadCfgValue("D8F_SP_" & sp.Tag, langFile, i), sp)
                    End If
                    i += 1
                Next

                'Add Hair
                Dim hair As New InitialD8.Female.Hair
                i = 0
                For Each ha In hair.list
                    If hair_f.ContainsKey(ReadCfgValue("D8F_HA_" & ha.Tag, langFile, i)) Then
                        hair_f.Add(ReadCfgValue("D8F_HA_" & ha.Tag & " (Duplicate)", langFile, i), ha)
                    Else
                        hair_f.Add(ReadCfgValue("D8F_HA_" & ha.Tag, langFile, i), ha)
                    End If
                    i += 1
                Next
            Else
                'Male
                'Add Skin
                Dim skin2 As New InitialD8.Male.Skin
                i = 0
                For Each sk2 In skin2.list
                    If skin_m.ContainsKey(ReadCfgValue("D8M_SK_" & sk2.Tag, langFile, i)) Then
                        skin_m.Add(ReadCfgValue("D8M_SK_" & sk2.Tag & " (Duplicate)", langFile, i), sk2)
                    Else
                        skin_m.Add(ReadCfgValue("D8M_SK_" & sk2.Tag, langFile, i), sk2)
                    End If
                    i += 1
                Next

                'Add Shirt
                Dim shirt2 As New InitialD8.Male.Shirt
                i = 0
                For Each sh2 In shirt2.list
                    If shirt_m.ContainsKey(ReadCfgValue("D8M_SH_" & sh2.Tag, langFile, i)) Then
                        shirt_m.Add(ReadCfgValue("D8M_SH_" & sh2.Tag & " (Duplicate)", langFile, i), sh2)
                    Else
                        shirt_m.Add(ReadCfgValue("D8M_SH_" & sh2.Tag, langFile, i), sh2)
                    End If
                    i += 1
                Next

                'Add Eyes
                Dim eyes2 As New InitialD8.Male.Eyes
                i = 0
                For Each ey2 In eyes2.list
                    If eyes_m.ContainsKey(ReadCfgValue("D8M_EY_" & ey2.Tag, langFile, i)) Then
                        eyes_m.Add(ReadCfgValue("D8M_EY_" & ey2.Tag & " (Duplicate)", langFile, i), ey2)
                    Else
                        eyes_m.Add(ReadCfgValue("D8M_EY_" & ey2.Tag, langFile, i), ey2)
                    End If
                    i += 1
                Next

                'Add Mouth
                Dim mouth2 As New InitialD8.Male.Mouth
                i = 0
                For Each mo2 In mouth2.list
                    If mouth_m.ContainsKey(ReadCfgValue("D8M_MO_" & mo2.Tag, langFile, i)) Then
                        mouth_m.Add(ReadCfgValue("D8M_MO_" & mo2.Tag & " (Duplicate)", langFile, i), mo2)
                    Else
                        mouth_m.Add(ReadCfgValue("D8M_MO_" & mo2.Tag, langFile, i), mo2)
                    End If
                    i += 1
                Next

                'Add Accessories
                Dim accessories2 As New InitialD8.Male.Accessories
                i = 0
                For Each ac2 In accessories2.list
                    If accessories_m.ContainsKey(ReadCfgValue("D8M_AC_" & ac2.Tag, langFile, i)) Then
                        accessories_m.Add(ReadCfgValue("D8M_AC_" & ac2.Tag & " (Duplicate)", langFile, i), ac2)
                    Else
                        accessories_m.Add(ReadCfgValue("D8M_AC_" & ac2.Tag, langFile, i), ac2)
                    End If
                    i += 1
                Next

                'Add shades
                Dim shades2 As New InitialD8.Male.Shades
                i = 0
                For Each sp2 In shades2.list
                    If shades_m.ContainsKey(ReadCfgValue("D8M_SP_" & sp2.Tag, langFile, i)) Then
                        shades_m.Add(ReadCfgValue("D8M_SP_" & sp2.Tag & " (Duplicate)", langFile, i), sp2)
                    Else
                        shades_m.Add(ReadCfgValue("D8M_SP_" & sp2.Tag, langFile, i), sp2)
                    End If
                    i += 1
                Next

                'Add Hair
                Dim hair2 As New InitialD8.Male.Hair
                i = 0
                For Each ha2 In hair2.list
                    If hair_m.ContainsKey(ReadCfgValue("D8M_HA_" & ha2.Tag, langFile, i)) Then
                        hair_m.Add(ReadCfgValue("D8M_HA_" & ha2.Tag & " (Duplicate)", langFile, i), ha2)
                    Else
                        hair_m.Add(ReadCfgValue("D8M_HA_" & ha2.Tag, langFile, i), ha2)
                    End If
                    i += 1
                Next
            End If

            'Add Frame
            Dim fm As New InitialD8.Share.Frame
            i = 0
            For Each f In fm.list
                If frame.ContainsKey(ReadCfgValue("D8_FR_" & f.Tag, langFile, i)) Then
                    frame.Add(ReadCfgValue("D8_FR_" & f.Tag & " (Duplicate)", langFile, i), f)
                Else
                    frame.Add(ReadCfgValue("D8_FR_" & f.Tag, langFile, i), f)
                End If
                i += 1
            Next

            'Add Category
            category.Add(face_skin_t, "SKIN")
            category.Add(hair_t, "HAIR")
            category.Add(eyes_t, "EYES")
            category.Add(shades_t, "SHADES")
            category.Add(mouth_t, "MOUTH")
            category.Add(shirt_t, "SHIRT")
            category.Add(accessories_t, "ACCESSORIES")
            category.Add(frame_t, "FRAME")
            cmbAvatarCat.DisplayMember = "Key"
            cmbAvatarCat.ValueMember = "Value"
            cmbAvatarCat.DataSource = New BindingSource(category, Nothing)
            cmbAvatarCat.SelectedIndex = 0
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub
#End Region

    Private Sub frmEdit_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub

    Private Sub frmEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _cardedit Then
            End
        End If
    End Sub
End Class