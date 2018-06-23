Imports System.IO
Imports System.Net
Imports System.Threading

Public Class frmLeaderboard

    Dim TopScoresURL As String = "http://id.imnotmental.com/TopScores.php?"
    Dim items As New ListViewItem()

    Dim trackname6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname8 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype8 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather8 As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Dim thread6, thread7, thread8 As Thread

    'Translate
    Dim LakeAkina, Myogi, Usui, Akagi, Akina, Irohazka, Happogahara, Nagao, Tsukuba, TsubakiLine, Nanamagari, Sadamine, Tsuchisaka, AkinaSnow, TsukubaSnow, TsuchisakaSnow, Hakone, MomijiLine As String

    Private Sub btnReport6_Click(sender As Object, e As EventArgs) Handles btnReport6.Click

    End Sub

    Private Sub btnReport7_Click(sender As Object, e As EventArgs) Handles btnReport7.Click

    End Sub

    Private Sub btnReport8_Click(sender As Object, e As EventArgs) Handles btnReport8.Click

    End Sub

    Private Sub lv7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv7.SelectedIndexChanged
        If lv7.SelectedItems.Count >= 1 Then
            btnReport7.Enabled = True
        Else
            btnReport7.Enabled = False
        End If
    End Sub

    Private Sub lv6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv6.SelectedIndexChanged
        If lv6.SelectedItems.Count >= 1 Then
            btnReport6.Enabled = True
        Else
            btnReport6.Enabled = False
        End If
    End Sub

    Private Sub lv8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv8.SelectedIndexChanged
        If lv8.SelectedItems.Count >= 1 Then
            btnReport8.Enabled = True
        Else
            btnReport8.Enabled = False
        End If
    End Sub

    Private Sub cmbCourse8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse8.SelectedIndexChanged
        cmbType8.DataSource = Nothing
        cmbType8.Items.Clear()
        cmbType8.DisplayMember = "Key"
        cmbType8.ValueMember = "Value"
        tracktype8.Clear()

        cmbWeather8.DataSource = Nothing
        cmbWeather8.Items.Clear()
        cmbWeather8.DisplayMember = "Key"
        cmbWeather8.ValueMember = "Value"
        trackweather8.Clear()

        Select Case cmbCourse8.SelectedValue.ToString
            Case "LakeAkina", "Usui"
                tracktype8.Add(Counterclockwise, "Counterclockwise")
                tracktype8.Add(Clockwise, "Clockwise")
                trackweather8.Add(Dry, "Dry")
            Case "Myogi", "Akagi", "Akina", "Nagao", "TsubakiLine", "Nanamagari", "Sadamine", "Hakone", "MomijiLine"
                tracktype8.Add(Uphill, "Uphill")
                tracktype8.Add(Downhill, "Downhill")
                trackweather8.Add(Dry, "Dry")
            Case "Irohazka"
                tracktype8.Add(Downhill, "Downhill")
                tracktype8.Add(Reversed, "Reversed")
                trackweather8.Add(Dry, "Dry")
            Case "Happogahara", "Tsukuba", "Tsuchisaka"
                tracktype8.Add(Inbound, "Inbound")
                tracktype8.Add(Outbound, "Outbound")
                trackweather8.Add(Dry, "Dry")
            Case "AkinaSnow"
                tracktype8.Add(Uphill, "Uphill")
                tracktype8.Add(Downhill, "Downhill")
                trackweather8.Add(Snow, "Snow")
        End Select

        cmbType8.DataSource = New BindingSource(tracktype8, Nothing)
        cmbType8.SelectedIndex = 0
        cmbWeather8.DataSource = New BindingSource(trackweather8, Nothing)
        cmbWeather8.SelectedIndex = 0
    End Sub


    Private Sub cmbCourse7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse7.SelectedIndexChanged
        cmbType7.DataSource = Nothing
        cmbType7.Items.Clear()
        cmbType7.DisplayMember = "Key"
        cmbType7.ValueMember = "Value"
        tracktype7.Clear()

        cmbWeather7.DataSource = Nothing
        cmbWeather7.Items.Clear()
        cmbWeather7.DisplayMember = "Key"
        cmbWeather7.ValueMember = "Value"
        trackweather7.Clear()

        Select Case cmbCourse7.SelectedValue.ToString
            Case "LakeAkina", "Usui"
                tracktype7.Add(Counterclockwise, "Counterclockwise")
                tracktype7.Add(Clockwise, "Clockwise")
                trackweather7.Add(Dry, "Dry")
            Case "Myogi", "Akagi", "Akina", "Nagao", "TsubakiLine", "Nanamagari", "Sadamine"
                tracktype7.Add(Uphill, "Uphill")
                tracktype7.Add(Downhill, "Downhill")
                trackweather7.Add(Dry, "Dry")
            Case "Irohazka"
                tracktype7.Add(Downhill, "Downhill")
                tracktype7.Add(Reversed, "Reversed")
                trackweather7.Add(Dry, "Dry")
            Case "Happogahara", "Tsukuba", "Tsuchisaka"
                tracktype7.Add(Inbound, "Inbound")
                tracktype7.Add(Outbound, "Outbound")
                trackweather7.Add(Dry, "Dry")
            Case "AkinaSnow"
                tracktype7.Add(Uphill, "Uphill")
                tracktype7.Add(Downhill, "Downhill")
                trackweather7.Add(Snow, "Snow")
            Case "TsukubaSnow", "TsuchisakaSnow"
                tracktype7.Add(Inbound, "Inbound")
                tracktype7.Add(Outbound, "Outbound")
                trackweather7.Add(Snow, "Snow")
        End Select

        cmbType7.DataSource = New BindingSource(tracktype7, Nothing)
        cmbType7.SelectedIndex = 0
        cmbWeather7.DataSource = New BindingSource(trackweather7, Nothing)
        cmbWeather7.SelectedIndex = 0
    End Sub

    Private Sub cmbCourse6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse6.SelectedIndexChanged
        cmbType6.DataSource = Nothing
        cmbType6.Items.Clear()
        cmbType6.DisplayMember = "Key"
        cmbType6.ValueMember = "Value"
        tracktype6.Clear()

        cmbWeather6.DataSource = Nothing
        cmbWeather6.Items.Clear()
        cmbWeather6.DisplayMember = "Key"
        cmbWeather6.ValueMember = "Value"
        trackweather6.Clear()

        Select Case cmbCourse6.SelectedValue.ToString
            Case "LakeAkina", "Usui"
                tracktype6.Add(Counterclockwise, "Counterclockwise")
                tracktype6.Add(Clockwise, "Clockwise")
                trackweather6.Add(Dry, "Dry")
                trackweather6.Add(Wet, "Wet")
            Case "Myogi", "Akagi", "Akina", "Nagao", "TsubakiLine", "Sadamine"
                tracktype6.Add(Uphill, "Uphill")
                tracktype6.Add(Downhill, "Downhill")
                trackweather6.Add(Dry, "Dry")
                trackweather6.Add(Wet, "Wet")
            Case "Irohazka"
                tracktype6.Add(Downhill, "Downhill")
                tracktype6.Add(Reversed, "Reversed")
                trackweather6.Add(Dry, "Dry")
                trackweather6.Add(Wet, "Wet")
            Case "Happogahara", "Tsukuba", "Tsuchisaka"
                tracktype6.Add(Inbound, "Inbound")
                tracktype6.Add(Outbound, "Outbound")
                trackweather6.Add(Dry, "Dry")
                trackweather6.Add(Wet, "Wet")
            Case "AkinaSnow"
                tracktype6.Add(Uphill, "Uphill")
                tracktype6.Add(Downhill, "Downhill")
                trackweather6.Add(Snow, "Snow")
            Case "TsukubaSnow", "TsuchisakaSnow"
                tracktype6.Add(Inbound, "Inbound")
                tracktype6.Add(Outbound, "Outbound")
                trackweather6.Add(Snow, "Snow")
        End Select

        cmbType6.DataSource = New BindingSource(tracktype6, Nothing)
        cmbType6.SelectedIndex = 0
        cmbWeather6.DataSource = New BindingSource(trackweather6, Nothing)
        cmbWeather6.SelectedIndex = 0
    End Sub

    Dim Dry, Wet, Snow As String, Uphill, Downhill, Counterclockwise, Clockwise, Inbound, Outbound, Reversed As String

    Private Sub frmLeaderboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub RefreshLeaderboard6(course As String, type As String, weather As String)
        lv6.Items.Clear()
        Dim number As Integer = 1

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(TopScoresURL + "gameversion=6&track=" & course & "&coursetype=" & type & "&weather=" & weather)))
            Dim Source As String = reader.ReadToEnd
            If Not Source = Nothing Then
                Dim Source2 As String = Source.Remove(Source.Length - 1)
                Dim Lines() As String = Source2.Split("#"c)
                For Each s As String In Lines
                    Dim result() As String = s.Split(","c)
                    Dim name As String = result(0)
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    items = lv6.Items.Add(number)
                    With items
                        .SubItems.Add(name)
                        .SubItems.Add(car)
                        .SubItems.Add(ScoreToTime(score))
                        .SubItems.Add(ts)
                        .Tag = id
                    End With
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard7(course As String, type As String, weather As String)
        lv7.Items.Clear()
        Dim number As Integer = 1

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(TopScoresURL + "gameversion=7&track=" & course & "&coursetype=" & type & "&weather=" & weather)))
            Dim Source As String = reader.ReadToEnd
            If Not Source = Nothing Then
                Dim Source2 As String = Source.Remove(Source.Length - 1)
                Dim Lines() As String = Source2.Split("#"c)
                For Each s As String In Lines
                    Dim result() As String = s.Split(","c)
                    Dim name As String = result(0)
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    items = lv7.Items.Add(number)
                    With items
                        .SubItems.Add(name)
                        .SubItems.Add(car)
                        .SubItems.Add(ScoreToTime(score))
                        .SubItems.Add(ts)
                        .Tag = id
                    End With
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard8(course As String, type As String, weather As String)
        lv8.Items.Clear()
        Dim number As Integer = 1

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(TopScoresURL + "gameversion=8&track=" & course & "&coursetype=" & type & "&weather=" & weather)))
            Dim Source As String = reader.ReadToEnd
            If Not Source = Nothing Then
                Dim Source2 As String = Source.Remove(Source.Length - 1)
                Dim Lines() As String = Source2.Split("#"c)
                For Each s As String In Lines
                    Dim result() As String = s.Split(","c)
                    Dim name As String = result(0)
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    items = lv8.Items.Add(number)
                    With items
                        .SubItems.Add(name)
                        .SubItems.Add(car)
                        .SubItems.Add(ScoreToTime(score))
                        .SubItems.Add(ts)
                        .Tag = id
                    End With
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnRefresh6_Click(sender As Object, e As EventArgs) Handles btnRefresh6.Click
        'RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString)

        thread6 = New Thread(Sub() RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString))
        thread6.Start()
    End Sub

    Private Sub btnRefresh7_Click(sender As Object, e As EventArgs) Handles btnRefresh7.Click
        'RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString)

        thread7 = New Thread(Sub() RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString))
        thread7.Start()
    End Sub

    Private Sub btnRefresh8_Click(sender As Object, e As EventArgs) Handles btnRefresh8.Click
        thread8 = New Thread(Sub() RefreshLeaderboard8(cmbCourse8.SelectedValue.ToString, cmbType8.SelectedValue.ToString, cmbWeather8.SelectedValue.ToString))
        thread8.Start()
    End Sub

    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        Translate()

        trackname6.Add(LakeAkina, "LakeAkina")
        trackname6.Add(Myogi, "Myogi")
        trackname6.Add(Usui, "Usui")
        trackname6.Add(Akagi, "Akagi")
        trackname6.Add(Akina, "Akina")
        trackname6.Add(Irohazka, "Irohazka")
        trackname6.Add(Happogahara, "Happogahara")
        trackname6.Add(Nagao, "Nagao")
        trackname6.Add(Tsukuba, "Tsukuba")
        trackname6.Add(TsubakiLine, "TsubakiLine")
        trackname6.Add(Sadamine, "Sadamine")
        trackname6.Add(Tsuchisaka, "Tsuchisaka")
        trackname6.Add(AkinaSnow, "AkinaSnow")
        trackname6.Add(TsukubaSnow, "TsukubaSnow")
        trackname6.Add(TsuchisakaSnow, "TsuchisakaSnow")
        cmbCourse6.DisplayMember = "Key"
        cmbCourse6.ValueMember = "Value"
        cmbCourse6.DataSource = New BindingSource(trackname6, Nothing)

        trackname7.Add(LakeAkina, "LakeAkina")
        trackname7.Add(Myogi, "Myogi")
        trackname7.Add(Usui, "Usui")
        trackname7.Add(Akagi, "Akagi")
        trackname7.Add(Akina, "Akina")
        trackname7.Add(Irohazka, "Irohazka")
        trackname7.Add(Happogahara, "Happogahara")
        trackname7.Add(Nagao, "Nagao")
        trackname7.Add(Tsukuba, "Tsukuba")
        trackname7.Add(TsubakiLine, "TsubakiLine")
        trackname7.Add(Nanamagari, "Nanamagari")
        trackname7.Add(Sadamine, "Sadamine")
        trackname7.Add(Tsuchisaka, "Tsuchisaka")
        trackname7.Add(AkinaSnow, "AkinaSnow")
        trackname7.Add(TsukubaSnow, "TsukubaSnow")
        trackname7.Add(TsuchisakaSnow, "TsuchisakaSnow")
        cmbCourse7.DisplayMember = "Key"
        cmbCourse7.ValueMember = "Value"
        cmbCourse7.DataSource = New BindingSource(trackname7, Nothing)

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

        cmbCourse6.SelectedIndex = 0
        cmbCourse7.SelectedIndex = 0
        cmbCourse8.SelectedIndex = 0

        thread6 = New Thread(Sub() RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString))
        thread6.Start()
        thread7 = New Thread(Sub() RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString))
        thread7.Start()
        thread8 = New Thread(Sub() RefreshLeaderboard8(cmbCourse8.SelectedValue.ToString, cmbType8.SelectedValue.ToString, cmbWeather8.SelectedValue.ToString))
        thread8.Start()

        If frmLauncher.WindowState = FormWindowState.Maximized Then
            NsControlButton3.Enabled = False
        End If

        'RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString)
        'RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString)
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Me.Text = ReadCfgValue("LeaderboardMeText", langFile)
            NsTheme1.Text = Me.Text
            tp6.Text = ReadCfgValue("EditTab6", langFile)
            tp7.Text = ReadCfgValue("EditTab7", langFile)
            tp8.Text = ReadCfgValue("EditTab8", langFile)
            Label3.Text = ReadCfgValue("Course", langFile)
            Label6.Text = Label3.Text
            Label9.Text = Label3.Text
            Label1.Text = ReadCfgValue("Type", langFile)
            Label5.Text = Label1.Text
            Label8.Text = Label1.Text
            Label2.Text = ReadCfgValue("Weather", langFile)
            Label4.Text = Label2.Text
            Label7.Text = Label2.Text
            btnRefresh6.Text = ReadCfgValue("Refresh", langFile)
            btnRefresh7.Text = btnRefresh6.Text
            btnRefresh8.Text = btnRefresh6.Text
            chNo6.Text = ReadCfgValue("RankNo", langFile)
            chNo7.Text = chNo6.Text
            chName6.Text = ReadCfgValue("RankName", langFile)
            chName7.Text = chName6.Text
            chCar6.Text = ReadCfgValue("RankCar", langFile)
            chCar7.Text = chCar6.Text
            chTime6.Text = ReadCfgValue("RankTime", langFile)
            chTime7.Text = chTime6.Text
            chDate6.Text = ReadCfgValue("RankDate", langFile)
            chDate7.Text = chDate6.Text
            chNo8.Text = chNo6.Text
            chName8.Text = chName6.Text
            chCar8.Text = chCar6.Text
            chTime8.Text = chTime6.Text
            chDate8.Text = chDate6.Text
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
            btnReport6.Text = ReadCfgValue("ReportBtn", langFile)
            btnReport7.Text = btnReport6.Text
            btnReport8.Text = btnReport6.Text
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmLeaderboard_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub
End Class