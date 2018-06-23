Public Class TimeAttack

    Dim trackname As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather As Dictionary(Of String, String) = New Dictionary(Of String, String)

    'Translate
    Public LakeAkina, Myogi, Usui, Akagi, Akina, Irohazka, Happogahara, Nagao, Tsukuba, TsubakiLine, Nanamagari, Sadamine, Tsuchisaka, AkinaSnow, TsukubaSnow, TsuchisakaSnow, Hakone, MomijiLine As String
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
            If frmLauncher.WindowState = FormWindowState.Maximized Then
                cs.TopLevel = False
                frmLauncher.Controls.Add(frmLogin)
            End If
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
            cs.Focus()
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
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
        trackname.Add(Hakone, "Hakone")
        trackname.Add(MomijiLine, "MomijiLine")
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

        Select Case lblCourse.Text.Length
            Case 0 To 10
                lblCourse.Font = New Font("Segoe UI", 18.0, FontStyle.Bold)
            Case 11
                lblCourse.Font = New Font("Segoe UI", 17.0, FontStyle.Bold)
            Case 12
                lblCourse.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
            Case 13 To 999999
                lblCourse.Font = New Font("Segoe UI", 14.0, FontStyle.Bold)
        End Select

    End Sub

    Public Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
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
            TsukubaSnow = ReadCfgValue("SnowTsukuba", langFile)
            TsuchisakaSnow = ReadCfgValue("SnowTsuchisaka", langFile)
            Hakone = ReadCfgValue("Hakone", langFile)
            MomijiLine = ReadCfgValue("MomijiLine", langFile)
            Uphill = ReadCfgValue("Uphill", langFile)
            Downhill = ReadCfgValue("Downhill", langFile)
            Counterclockwise = ReadCfgValue("Counterclockwise", langFile)
            Clockwise = ReadCfgValue("Clockwise", langFile)
            Inbound = ReadCfgValue("Inbound", langFile)
            Outbound = ReadCfgValue("Outbound", langFile)
            Reversed = ReadCfgValue("Reversed", langFile)
            Dry = ReadCfgValue("Dry", langFile)
            Wet = ReadCfgValue("Wet", langFile)
            Snow = ReadCfgValue("_Snow", langFile)
            btnTimeAttack.Text = ReadCfgValue("SubmitBtn", langFile)
            id6 = ReadCfgValue("EditTab6", langFile)
            id7 = ReadCfgValue("EditTab7", langFile)
            id8 = ReadCfgValue("EditTab8", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub lblCourse_TextChanged(sender As Object, e As EventArgs) Handles lblCourse.TextChanged
        Select Case lblCourse.Text.Length
            Case 0 To 10
                lblCourse.Font = New Font("Segoe UI", 18.0, FontStyle.Bold)
            Case 11
                lblCourse.Font = New Font("Segoe UI", 17.0, FontStyle.Bold)
            Case 12
                lblCourse.Font = New Font("Segoe UI", 16.0, FontStyle.Bold)
            Case 13 To 999999
                lblCourse.Font = New Font("Segoe UI", 14.0, FontStyle.Bold)
        End Select
    End Sub
End Class
