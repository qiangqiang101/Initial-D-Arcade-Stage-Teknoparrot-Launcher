Public Class TimeAttack

    Dim trackname As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather As Dictionary(Of String, String) = New Dictionary(Of String, String)

    'Translate
    Public LakeAkina, Myogi, Usui, Akagi, Akina, Irohazka, Happogahara, Nagao, Tsukuba, TsubakiLine, Nanamagari, Sadamine, Tsuchisaka, AkinaSnow, TsukubaSnow, TsuchisakaSnow As String
    Dim id6, id7, id8 As String

    Private _version As Integer
    Public Property Version() As Integer
        Get
            Return _version
        End Get
        Set(value As Integer)
            _version = value
        End Set
    End Property

    Private _score As String
    Public Property Score() As String
        Get
            Return _score
        End Get
        Set(value As String)
            _score = value
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

    Private Sub btnTimeAttack_Click(sender As Object, e As EventArgs) Handles btnTimeAttack.Click
        Try
            Dim cs As frmSubmit = New frmSubmit()
            cs.Version = _version
            cs.Score = _score
            cs.lblName.Text = My.Settings.UserName
            If _version = 6 Then cs.lblVersion.Text = id6 Else If _version = 7 Then cs.lblVersion.Text = id7 Else If _version = 8 Then cs.lblVersion.Text = id8
            cs.lblCourse.Text = lblCourse.Text
            cs.Track = trackname.Item(lblCourse.Text)
            cs.lblTime.Text = lblTime.Text
            cs.lblType.Text = lblType.Text
            cs.CourseType = tracktype.Item(lblType.Text)
            cs.lblWeather.Text = lblWeather.Text
            cs.lblServer.Text = My.Settings.Server
            cs.Weather = trackweather.Item(lblWeather.Text)
            Dim car1, car2, car3 As String
            If _extension = "bin" Then
                If _version = 6 Then
                    car1 = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1), 6)
                    car2 = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1), 6)
                    car3 = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1), 6)
                Else
                    car1 = GetCar(GetHex(_filename, 256, 2), GetHex(_filename, 271, 1))
                    car2 = GetCar(GetHex(_filename, 352, 2), GetHex(_filename, 367, 1))
                    car3 = GetCar(GetHex(_filename, 448, 2), GetHex(_filename, 463, 1))
                End If
            Else
                If _version = 6 Then
                    car1 = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1), 6)
                    car2 = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1), 6)
                    car3 = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1), 6)
                Else
                    car1 = GetCar(GetHex(_filename, Neg60(256), 2), GetHex(_filename, Neg60(271), 1))
                    car2 = GetCar(GetHex(_filename, Neg60(352), 2), GetHex(_filename, Neg60(367), 1))
                    car3 = GetCar(GetHex(_filename, Neg60(448), 2), GetHex(_filename, Neg60(463), 1))
                End If
            End If

            If Not car1 = Nothing Then cs.cmbCar.Items.Add(car1)
            If Not car2 = Nothing Then cs.cmbCar.Items.Add(car2)
            If Not car3 = Nothing Then cs.cmbCar.Items.Add(car3)
            cs.cmbCar.SelectedIndex = 0
            cs.Show()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Dry, Wet, Snow As String, Uphill, Downhill, Counterclockwise, Clockwise, Inbound, Outbound, Reversed As String

    Private Sub TimeAttack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()

        trackname.Add(LakeAkina, "LakeAkina")
        trackname.Add(Myogi, "Myogi")
        trackname.Add(Usui, "Usui")
        trackname.Add(Akagi, "Akagi")
        trackname.Add(Akina, "Akina")
        trackname.Add(Irohazka, "Irohazka")
        trackname.Add(Happogahara, "Happogahara")
        trackname.Add(Nagao, "Nagao")
        trackname.Add(Tsukuba, "Tsukuba")
        trackname.Add(TsubakiLine, "TsubakiLine")
        trackname.Add(Nanamagari, "Nanamagari")
        trackname.Add(Sadamine, "Sadamine")
        trackname.Add(Tsuchisaka, "Tsuchisaka")
        trackname.Add(AkinaSnow, "AkinaSnow")
        trackname.Add(TsukubaSnow, "TsukubaSnow")
        trackname.Add(TsuchisakaSnow, "TsuchisakaSnow")
        tracktype.Add(Uphill, "Uphill")
        tracktype.Add(Downhill, "Downhill")
        tracktype.Add(Counterclockwise, "Counterclockwise")
        tracktype.Add(Clockwise, "Clockwise")
        tracktype.Add(Inbound, "Inbound")
        tracktype.Add(Outbound, "Outbound")
        tracktype.Add(Reversed, "Reversed")
        trackweather.Add(Dry, "Dry")
        trackweather.Add(Wet, "Wet")
        trackweather.Add(Snow, "Snow")
    End Sub

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                LakeAkina = "Lake Akina"
                Myogi = "Myogi"
                Usui = "Usui"
                Akagi = "Akagi"
                Akina = "Akina"
                Irohazka = "Irohazka"
                Happogahara = "Happogahara"
                Nagao = "Nagao"
                Tsukuba = "Tsukuba"
                TsubakiLine = "Tsubaki Line"
                Nanamagari = "Nanamagari"
                Sadamine = "Sadamine"
                Tsuchisaka = "Tsuchisaka"
                AkinaSnow = "Akina Snow"
                TsukubaSnow = "Tsukuba Snow"
                TsuchisakaSnow = "Tsuchisaka Snow"
                Uphill = "Uphill"
                Downhill = "Downhill"
                Counterclockwise = "Counterclockwise"
                Clockwise = "Clockwise"
                Inbound = "Inbound"
                Outbound = "Outbound"
                Reversed = "Reversed"
                Dry = "Dry"
                Wet = "Wet"
                Snow = "Snow"
                btnTimeAttack.Text = "Submit"
                id6 = "InitialD 6 AA"
                id7 = "InitialD 7 AAX"
                id8 = "InitialD 8 ∞"
            Case "Chinese"
                LakeAkina = "秋明湖"
                Myogi = "妙義"
                Usui = "碓冰"
                Akagi = "赤城"
                Akina = "秋明"
                Irohazka = "伊呂波"
                Happogahara = "八方原"
                Nagao = "長尾"
                Tsukuba = "筑波"
                TsubakiLine = "椿线"
                Nanamagari = "七曲"
                Sadamine = "定峰"
                Tsuchisaka = "土坂"
                AkinaSnow = "秋明(雪)"
                TsukubaSnow = "筑波(雪)"
                TsuchisakaSnow = "土坂(雪)"
                Uphill = "上坡"
                Downhill = "下坡"
                Counterclockwise = "左週"
                Clockwise = "右週"
                Inbound = "復路"
                Outbound = "往路"
                Reversed = "逆走"
                Dry = "晴"
                Wet = "雨"
                Snow = "雪"
                btnTimeAttack.Text = "提交"
                id6 = "頭文字D6AA"
                id7 = "頭文字D7AAX"
                id8 = "頭文字D8∞"
            Case "French"
                LakeAkina = "Lake Akina"
                Myogi = "Myogi"
                Usui = "Usui"
                Akagi = "Akagi"
                Akina = "Akina"
                Irohazka = "Irohazka"
                Happogahara = "Happogahara"
                Nagao = "Nagao"
                Tsukuba = "Tsukuba"
                TsubakiLine = "Tsubaki Line"
                Nanamagari = "Nanamagari"
                Sadamine = "Sadamine"
                Tsuchisaka = "Tsuchisaka"
                AkinaSnow = "Akina Snow"
                TsukubaSnow = "Tsukuba Snow"
                TsuchisakaSnow = "Tsuchisaka Snow"
                Uphill = "Montée"
                Downhill = "Une descente"
                Counterclockwise = "Dans le sens antihoraire"
                Clockwise = "Sens horaire"
                Inbound = "Entrant"
                Outbound = "Sortant"
                Reversed = "Renversé"
                Dry = "Sec"
                Wet = "Humide"
                Snow = "Neige"
                btnTimeAttack.Text = "Soumettre"
                id6 = "InitialD 6 AA"
                id7 = "InitialD 7 AAX"
                id8 = "InitialD 8 ∞"
        End Select
    End Sub

End Class
