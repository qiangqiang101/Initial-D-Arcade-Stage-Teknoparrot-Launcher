Imports System.IO
Imports System.Net

Public Class frmLeaderboard

    Dim TopScoresURL As String = "http://id.imnotmental.com/TopScores.php?"
    Dim items As New ListViewItem()

    Dim trackname6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather As Dictionary(Of String, String) = New Dictionary(Of String, String)

    'Translate
    Dim LakeAkina, Myogi, Usui, Akagi, Akina, Irohazka, Happogahara, Nagao, Tsukuba, TsubakiLine, Nanamagari, Sadamine, Tsuchisaka, AkinaSnow As String
    Dim Dry, Wet, Snow As String, Uphill, Downhill, Counterclockwise, Clockwise, Inbound, Outbound, Reversed As String

    Private Sub frmLeaderboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub RefreshLeaderboard6(course As String, type As String, weather As String)
        lv6.Items.Clear()
        Dim number As Integer = 0

        Try
            Dim Client As WebClient = New WebClient()
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
                    items = lv6.Items.Add(number + 1)
                    With items
                        .SubItems.Add(name)
                        .SubItems.Add(car)
                        .SubItems.Add(ScoreToTime(score))
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RefreshLeaderboard7(course As String, type As String, weather As String)
        lv7.Items.Clear()
        Dim number As Integer = 0

        Try
            Dim Client As WebClient = New WebClient()
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
                    items = lv7.Items.Add(number + 1)
                    With items
                        .SubItems.Add(name)
                        .SubItems.Add(car)
                        .SubItems.Add(ScoreToTime(score))
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnRefresh6_Click(sender As Object, e As EventArgs) Handles btnRefresh6.Click
        RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString)
    End Sub

    Private Sub btnRefresh7_Click(sender As Object, e As EventArgs) Handles btnRefresh7.Click
        RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString)
    End Sub

    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        cmbCourse7.DisplayMember = "Key"
        cmbCourse7.ValueMember = "Value"
        cmbCourse7.DataSource = New BindingSource(trackname7, Nothing)

        tracktype.Add(Uphill, "Uphill")
        tracktype.Add(Downhill, "Downhill")
        tracktype.Add(Counterclockwise, "Counterclockwise")
        tracktype.Add(Clockwise, "Clockwise")
        tracktype.Add(Inbound, "Inbound")
        tracktype.Add(Outbound, "Outbound")
        tracktype.Add(Reversed, "Reversed")
        cmbType6.DisplayMember = "Key"
        cmbType6.ValueMember = "Value"
        cmbType6.DataSource = New BindingSource(tracktype, Nothing)
        cmbType7.DisplayMember = "Key"
        cmbType7.ValueMember = "Value"
        cmbType7.DataSource = New BindingSource(tracktype, Nothing)

        trackweather.Add(Dry, "Dry")
        trackweather.Add(Wet, "Wet")
        trackweather.Add(Snow, "Snow")
        cmbWeather6.DisplayMember = "Key"
        cmbWeather6.ValueMember = "Value"
        cmbWeather6.DataSource = New BindingSource(trackweather, Nothing)
        cmbWeather7.DisplayMember = "Key"
        cmbWeather7.ValueMember = "Value"
        cmbWeather7.DataSource = New BindingSource(trackweather, Nothing)

        cmbCourse6.SelectedIndex = 0
        cmbCourse7.SelectedIndex = 0
        cmbType6.SelectedIndex = 0
        cmbType7.SelectedIndex = 0
        cmbWeather6.SelectedIndex = 0
        cmbWeather7.SelectedIndex = 0

        RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString)
        RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString)
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Time Attack Ranking"
                tp6.Text = "Initial D 6 AA"
                tp7.Text = "Initial D 7 AAX"
                Label3.Text = "Course"
                Label6.Text = Label3.Text
                Label1.Text = "Type"
                Label5.Text = Label1.Text
                Label2.Text = "Weather"
                Label4.Text = Label2.Text
                btnRefresh6.Text = "Refresh"
                btnRefresh7.Text = btnRefresh6.Text
                chNo6.Text = "No."
                chNo7.Text = chNo6.Text
                chName6.Text = "Name"
                chName7.Text = chName6.Text
                chCar6.Text = "Car"
                chCar7.Text = chCar6.Text
                chTime6.Text = "Time"
                chTime7.Text = chTime6.Text
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
            Case "Chinese"
                Me.Text = "時間攻擊排行榜"
                tp6.Text = "頭文字D6AA"
                tp7.Text = "頭文字D7AAX"
                Label3.Text = "地圖"
                Label6.Text = Label3.Text
                Label1.Text = "類別"
                Label5.Text = Label1.Text
                Label2.Text = "天氣"
                Label4.Text = Label2.Text
                btnRefresh6.Text = "刷新"
                btnRefresh7.Text = btnRefresh6.Text
                chNo6.Text = "名次"
                chNo7.Text = chNo6.Text
                chName6.Text = "名字"
                chName7.Text = chName6.Text
                chCar6.Text = "車型"
                chCar7.Text = chCar6.Text
                chTime6.Text = "時間"
                chTime7.Text = chTime6.Text
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
            Case "French"
                Me.Text = "Classement des attaques de temps"
                tp6.Text = "Initial D 6 AA"
                tp7.Text = "Initial D 7 AAX"
                Label3.Text = "Piste"
                Label6.Text = Label3.Text
                Label1.Text = "Type"
                Label5.Text = Label1.Text
                Label2.Text = "Météo"
                Label4.Text = Label2.Text
                btnRefresh6.Text = "Rafraîchir"
                btnRefresh7.Text = btnRefresh6.Text
                chNo6.Text = "No."
                chNo7.Text = chNo6.Text
                chName6.Text = "Nom"
                chName7.Text = chName6.Text
                chCar6.Text = "Voiture"
                chCar7.Text = chCar6.Text
                chTime6.Text = "Temps"
                chTime7.Text = chTime6.Text
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
        End Select
    End Sub
End Class