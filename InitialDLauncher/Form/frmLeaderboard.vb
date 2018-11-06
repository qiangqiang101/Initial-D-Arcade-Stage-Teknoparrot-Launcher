Imports System.IO
Imports System.Net
Imports System.Threading

Public Class frmLeaderboard

    Dim LastLocation As Point = New Point(0, 0)
    Dim TopScoresURL As String = "http://id.imnotmental.com/TopScores.php?"

    Dim trackname4 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname5 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackname8 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype4 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype5 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim tracktype8 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather4 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather5 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather6 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather7 As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim trackweather8 As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Dim thread4, thread4e, thread5, thread6, thread7, thread8 As Thread

    'Translate
    Dim LakeAkina, Myogi, Usui, Akagi, Akina, Irohazka, Happogahara, Nagao, Tsukuba, TsubakiLine, Nanamagari, Sadamine, Tsuchisaka, AkinaSnow, TsukubaSnow, TsuchisakaSnow, Hakone, MomijiLine As String

    Private Sub NsControlButton3_Click(sender As Object, e As EventArgs) Handles NsControlButton3.Click
        LastLocation = Me.Location
    End Sub

    Private Sub btnReport4_Click(sender As Object, e As EventArgs) Handles btnReport4.Click

    End Sub

    Private Sub btnReport4e_Click(sender As Object, e As EventArgs) Handles btnReport4e.Click

    End Sub

    Private Sub btnReport5_Click(sender As Object, e As EventArgs) Handles btnReport5.Click

    End Sub

    Private Sub btnReport6_Click(sender As Object, e As EventArgs) Handles btnReport6.Click

    End Sub

    Private Sub btnReport7_Click(sender As Object, e As EventArgs) Handles btnReport7.Click

    End Sub

    Private Sub btnReport8_Click(sender As Object, e As EventArgs) Handles btnReport8.Click

    End Sub

    'Private Sub lv7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv7.SelectedIndexChanged
    '    If lv7.SelectedItems.Count >= 1 Then
    '        btnReport7.Enabled = True
    '    Else
    '        btnReport7.Enabled = False
    '    End If
    'End Sub

    'Private Sub lv6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv6.SelectedIndexChanged
    '    If lv6.SelectedItems.Count >= 1 Then
    '        btnReport6.Enabled = True
    '    Else
    '        btnReport6.Enabled = False
    '    End If
    'End Sub

    'Private Sub lv8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv8.SelectedIndexChanged
    '    If lv8.SelectedItems.Count >= 1 Then
    '        btnReport8.Enabled = True
    '    Else
    '        btnReport8.Enabled = False
    '    End If
    'End Sub

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

    Private Sub cmbCourse4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse4.SelectedIndexChanged
        cmbType4.DataSource = Nothing
        cmbType4.Items.Clear()
        cmbType4.DisplayMember = "Key"
        cmbType4.ValueMember = "Value"
        tracktype4.Clear()

        cmbWeather4.DataSource = Nothing
        cmbWeather4.Items.Clear()
        cmbWeather4.DisplayMember = "Key"
        cmbWeather4.ValueMember = "Value"
        trackweather4.Clear()

        Select Case cmbCourse4.SelectedValue.ToString
            Case "LakeAkina"
                tracktype4.Add(Counterclockwise, "Counterclockwise")
                tracktype4.Add(Clockwise, "Clockwise")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
            Case "Myogi", "Akagi", "Akina"
                tracktype4.Add(Uphill, "Uphill")
                tracktype4.Add(Downhill, "Downhill")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
            Case "Irohazka"
                tracktype4.Add(Downhill, "Downhill")
                tracktype4.Add(Reversed, "Reversed")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
            Case "Tsukuba"
                tracktype4.Add(Inbound, "Inbound")
                tracktype4.Add(Outbound, "Outbound")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
        End Select

        cmbType4.DataSource = New BindingSource(tracktype4, Nothing)
        cmbType4.SelectedIndex = 0
        cmbWeather4.DataSource = New BindingSource(trackweather4, Nothing)
        cmbWeather4.SelectedIndex = 0
    End Sub

    Private Sub cmbCourse4e_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse4e.SelectedIndexChanged
        cmbType4e.DataSource = Nothing
        cmbType4e.Items.Clear()
        cmbType4e.DisplayMember = "Key"
        cmbType4e.ValueMember = "Value"
        tracktype4.Clear()

        cmbWeather4e.DataSource = Nothing
        cmbWeather4e.Items.Clear()
        cmbWeather4e.DisplayMember = "Key"
        cmbWeather4e.ValueMember = "Value"
        trackweather4.Clear()

        Select Case cmbCourse4e.SelectedValue.ToString
            Case "LakeAkina"
                tracktype4.Add(Counterclockwise, "Counterclockwise")
                tracktype4.Add(Clockwise, "Clockwise")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
            Case "Myogi", "Akagi", "Akina"
                tracktype4.Add(Uphill, "Uphill")
                tracktype4.Add(Downhill, "Downhill")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
            Case "Irohazka"
                tracktype4.Add(Downhill, "Downhill")
                tracktype4.Add(Reversed, "Reversed")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
            Case "Tsukuba"
                tracktype4.Add(Inbound, "Inbound")
                tracktype4.Add(Outbound, "Outbound")
                trackweather4.Add(Dry, "Dry")
                trackweather4.Add(Wet, "Wet")
        End Select

        cmbType4e.DataSource = New BindingSource(tracktype4, Nothing)
        cmbType4e.SelectedIndex = 0
        cmbWeather4e.DataSource = New BindingSource(trackweather4, Nothing)
        cmbWeather4e.SelectedIndex = 0
    End Sub

    Private Sub cmbCourse5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse5.SelectedIndexChanged
        cmbType5.DataSource = Nothing
        cmbType5.Items.Clear()
        cmbType5.DisplayMember = "Key"
        cmbType5.ValueMember = "Value"
        tracktype5.Clear()

        cmbWeather5.DataSource = Nothing
        cmbWeather5.Items.Clear()
        cmbWeather5.DisplayMember = "Key"
        cmbWeather5.ValueMember = "Value"
        trackweather5.Clear()

        Select Case cmbCourse5.SelectedValue.ToString
            Case "LakeAkina"
                tracktype5.Add(Counterclockwise, "Counterclockwise")
                tracktype5.Add(Clockwise, "Clockwise")
                trackweather5.Add(Dry, "Dry")
                trackweather5.Add(Wet, "Wet")
            Case "Myogi", "Akagi", "Akina", "Nagao"
                tracktype5.Add(Uphill, "Uphill")
                tracktype5.Add(Downhill, "Downhill")
                trackweather5.Add(Dry, "Dry")
                trackweather5.Add(Wet, "Wet")
            Case "Irohazka"
                tracktype5.Add(Downhill, "Downhill")
                tracktype5.Add(Reversed, "Reversed")
                trackweather5.Add(Dry, "Dry")
                trackweather5.Add(Wet, "Wet")
            Case "Happogahara", "Tsukuba"
                tracktype5.Add(Inbound, "Inbound")
                tracktype5.Add(Outbound, "Outbound")
                trackweather5.Add(Dry, "Dry")
                trackweather5.Add(Wet, "Wet")
        End Select

        cmbType5.DataSource = New BindingSource(tracktype5, Nothing)
        cmbType5.SelectedIndex = 0
        cmbWeather5.DataSource = New BindingSource(trackweather5, Nothing)
        cmbWeather5.SelectedIndex = 0
    End Sub

    Dim Dry, Wet, Snow As String, Uphill, Downhill, Counterclockwise, Clockwise, Inbound, Outbound, Reversed As String

    Private Sub frmLeaderboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmLauncher.Enabled = True
    End Sub

    Private Sub RefreshLeaderboard4(course As String, type As String, weather As String)
        lvLB4.Clear()

        Dim number As Integer = 1

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(TopScoresURL + "gameversion=4&track=" & course & "&coursetype=" & type & "&weather=" & weather)))
            Dim Source As String = reader.ReadToEnd
            If Not Source = Nothing Then
                Dim Source2 As String = Source.Remove(Source.Length - 1)
                Dim Lines() As String = Source2.Split("#"c)
                For Each s As String In Lines
                    Dim result() As String = s.Split(","c)
                    Dim name As String = result(0).Replace("]", "] ")
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    Dim tag As Object = id
                    lvLB4.AddItem(If(number >= 11, $"     {number.ToString()}", number.ToString()), If(number = 1, My.Resources.gold, If(number >= 11, Nothing, My.Resources.silver)), tag, name, car, ScoreToTime(score), ts)
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard4e(course As String, type As String, weather As String)
        lvLB4e.Clear()

        Dim number As Integer = 1

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(TopScoresURL + "gameversion=4E&track=" & course & "&coursetype=" & type & "&weather=" & weather)))
            Dim Source As String = reader.ReadToEnd
            If Not Source = Nothing Then
                Dim Source2 As String = Source.Remove(Source.Length - 1)
                Dim Lines() As String = Source2.Split("#"c)
                For Each s As String In Lines
                    Dim result() As String = s.Split(","c)
                    Dim name As String = result(0).Replace("]", "] ")
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    Dim tag As Object = id
                    lvLB4e.AddItem(If(number >= 11, $"     {number.ToString()}", number.ToString()), If(number = 1, My.Resources.gold, If(number >= 11, Nothing, My.Resources.silver)), tag, name, car, ScoreToTime(score), ts)
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard5(course As String, type As String, weather As String)
        lvLB5.Clear()

        Dim number As Integer = 1

        Try
            Dim Client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            Dim reader As StreamReader = New StreamReader(Client.OpenRead(Convert.ToString(TopScoresURL + "gameversion=5&track=" & course & "&coursetype=" & type & "&weather=" & weather)))
            Dim Source As String = reader.ReadToEnd
            If Not Source = Nothing Then
                Dim Source2 As String = Source.Remove(Source.Length - 1)
                Dim Lines() As String = Source2.Split("#"c)
                For Each s As String In Lines
                    Dim result() As String = s.Split(","c)
                    Dim name As String = result(0).Replace("]", "] ")
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    Dim tag As Object = id
                    lvLB5.AddItem(If(number >= 11, $"     {number.ToString()}", number.ToString()), If(number = 1, My.Resources.gold, If(number >= 11, Nothing, My.Resources.silver)), tag, name, car, ScoreToTime(score), ts)
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard6(course As String, type As String, weather As String)
        lvLB6.Clear()

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
                    Dim name As String = result(0).Replace("]", "] ")
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    Dim tag As Object = id
                    lvLB6.AddItem(If(number >= 11, $"     {number.ToString()}", number.ToString()), If(number = 1, My.Resources.gold, If(number >= 11, Nothing, My.Resources.silver)), tag, name, car, ScoreToTime(score), ts)
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard7(course As String, type As String, weather As String)
        lvLB7.Clear()
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
                    Dim name As String = result(0).Replace("]", "] ")
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    Dim tag As Object = id
                    lvLB7.AddItem(If(number >= 11, $"     {number.ToString()}", number.ToString()), If(number = 1, My.Resources.gold, If(number >= 11, Nothing, My.Resources.silver)), tag, name, car, ScoreToTime(score), ts)
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub RefreshLeaderboard8(course As String, type As String, weather As String)
        lvLB8.Clear()
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
                    Dim name As String = result(0).Replace("]", "] ")
                    Dim score As String = result(1)
                    Dim car As String = result(2)
                    Dim id As String = result(3)
                    Dim cpuid As String = result(4)
                    Dim ts As String = result(5)
                    Dim tag As Object = id
                    lvLB8.AddItem(If(number >= 11, $"     {number.ToString()}", number.ToString()), If(number = 1, My.Resources.gold, If(number >= 11, Nothing, My.Resources.silver)), tag, name, car, ScoreToTime(score), ts)
                    number += 1
                Next
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnRefresh4_Click(sender As Object, e As EventArgs) Handles btnRefresh4.Click
        thread4 = New Thread(Sub() RefreshLeaderboard4(cmbCourse4.SelectedValue.ToString, cmbType4.SelectedValue.ToString, cmbWeather4.SelectedValue.ToString))
        thread4.Start()
    End Sub

    Private Sub btnRefresh4e_Click(sender As Object, e As EventArgs) Handles btnRefresh4e.Click
        thread4e = New Thread(Sub() RefreshLeaderboard4e(cmbCourse4e.SelectedValue.ToString, cmbType4e.SelectedValue.ToString, cmbWeather4e.SelectedValue.ToString))
        thread4e.Start()
    End Sub

    Private Sub btnRefresh5_Click(sender As Object, e As EventArgs) Handles btnRefresh5.Click
        thread5 = New Thread(Sub() RefreshLeaderboard5(cmbCourse5.SelectedValue.ToString, cmbType5.SelectedValue.ToString, cmbWeather5.SelectedValue.ToString))
        thread5.Start()
    End Sub

    Private Sub btnRefresh6_Click(sender As Object, e As EventArgs) Handles btnRefresh6.Click
        thread6 = New Thread(Sub() RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString))
        thread6.Start()
    End Sub

    Private Sub btnRefresh7_Click(sender As Object, e As EventArgs) Handles btnRefresh7.Click
        thread7 = New Thread(Sub() RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString))
        thread7.Start()
    End Sub

    Private Sub btnRefresh8_Click(sender As Object, e As EventArgs) Handles btnRefresh8.Click
        thread8 = New Thread(Sub() RefreshLeaderboard8(cmbCourse8.SelectedValue.ToString, cmbType8.SelectedValue.ToString, cmbWeather8.SelectedValue.ToString))
        thread8.Start()
    End Sub

    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            If Not My.Settings.FullScreen Then MaximumSize = My.Computer.Screen.WorkingArea.Size

            Translate()

            trackname4.Add(LakeAkina, "LakeAkina")
            trackname4.Add(Myogi, "Myogi")
            trackname4.Add(Akagi, "Akagi")
            trackname4.Add(Akina, "Akina")
            trackname4.Add(Irohazka, "Irohazka")
            trackname4.Add(Tsukuba, "Tsukuba")
            cmbCourse4.DisplayMember = "Key"
            cmbCourse4.ValueMember = "Value"
            cmbCourse4.DataSource = New BindingSource(trackname4, Nothing)
            cmbCourse4e.DisplayMember = "Key"
            cmbCourse4e.ValueMember = "Value"
            cmbCourse4e.DataSource = New BindingSource(trackname4, Nothing)

            trackname5.Add(LakeAkina, "LakeAkina")
            trackname5.Add(Myogi, "Myogi")
            trackname5.Add(Akagi, "Akagi")
            trackname5.Add(Akina, "Akina")
            trackname5.Add(Irohazka, "Irohazka")
            trackname5.Add(Happogahara, "Happogahara")
            trackname5.Add(Nagao, "Nagao")
            trackname5.Add(Tsukuba, "Tsukuba")
            cmbCourse5.DisplayMember = "Key"
            cmbCourse5.ValueMember = "Value"
            cmbCourse5.DataSource = New BindingSource(trackname5, Nothing)

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

            cmbCourse4.SelectedIndex = 0
            cmbCourse4e.SelectedIndex = 0
            cmbCourse5.SelectedIndex = 0
            cmbCourse6.SelectedIndex = 0
            cmbCourse7.SelectedIndex = 0
            cmbCourse8.SelectedIndex = 0

            thread4 = New Thread(Sub() RefreshLeaderboard4(cmbCourse4.SelectedValue.ToString, cmbType4.SelectedValue.ToString, cmbWeather4.SelectedValue.ToString))
            thread4.Start()
            thread4e = New Thread(Sub() RefreshLeaderboard4e(cmbCourse4e.SelectedValue.ToString, cmbType4e.SelectedValue.ToString, cmbWeather4e.SelectedValue.ToString))
            thread4e.Start()
            thread5 = New Thread(Sub() RefreshLeaderboard5(cmbCourse5.SelectedValue.ToString, cmbType5.SelectedValue.ToString, cmbWeather5.SelectedValue.ToString))
            thread5.Start()
            thread6 = New Thread(Sub() RefreshLeaderboard6(cmbCourse6.SelectedValue.ToString, cmbType6.SelectedValue.ToString, cmbWeather6.SelectedValue.ToString))
            thread6.Start()
            thread7 = New Thread(Sub() RefreshLeaderboard7(cmbCourse7.SelectedValue.ToString, cmbType7.SelectedValue.ToString, cmbWeather7.SelectedValue.ToString))
            thread7.Start()
            thread8 = New Thread(Sub() RefreshLeaderboard8(cmbCourse8.SelectedValue.ToString, cmbType8.SelectedValue.ToString, cmbWeather8.SelectedValue.ToString))
            thread8.Start()

            If frmLauncher.WindowState = FormWindowState.Maximized Then
                NsControlButton3.Enabled = False
            End If
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\IDAS\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            Me.Text = ReadCfgValue("LeaderboardMeText", langFile)
            NsTheme1.Text = Me.Text
            tp4.Text = ReadCfgValue("EditTab4", langFile)
            tp4e.Text = ReadCfgValue("EditTab4e", langFile)
            tp5.Text = ReadCfgValue("EditTab5", langFile)
            tp6.Text = ReadCfgValue("EditTab6", langFile)
            tp7.Text = ReadCfgValue("EditTab7", langFile)
            tp8.Text = ReadCfgValue("EditTab8", langFile)
            Label3.Text = ReadCfgValue("Course", langFile)
            Label6.Text = Label3.Text
            Label9.Text = Label3.Text
            Label12.Text = Label3.Text
            Label15.Text = Label3.Text
            Label18.Text = Label3.Text
            Label1.Text = ReadCfgValue("Type", langFile)
            Label5.Text = Label1.Text
            Label8.Text = Label1.Text
            Label11.Text = Label1.Text
            Label14.Text = Label1.Text
            Label17.Text = Label1.Text
            Label2.Text = ReadCfgValue("Weather", langFile)
            Label4.Text = Label2.Text
            Label7.Text = Label2.Text
            Label10.Text = Label2.Text
            Label13.Text = Label2.Text
            Label16.Text = Label2.Text
            btnRefresh6.Text = ReadCfgValue("Refresh", langFile)
            btnRefresh7.Text = btnRefresh6.Text
            btnRefresh8.Text = btnRefresh6.Text
            btnRefresh4.Text = btnRefresh6.Text
            btnRefresh4e.Text = btnRefresh6.Text
            btnRefresh5.Text = btnRefresh6.Text
            lvLB6.Columns(0).Text = ReadCfgValue("RankNo", langFile)
            lvLB6.Columns(1).Text = ReadCfgValue("RankName", langFile)
            lvLB6.Columns(2).Text = ReadCfgValue("RankCar", langFile)
            lvLB6.Columns(3).Text = ReadCfgValue("RankTime", langFile)
            lvLB6.Columns(4).Text = ReadCfgValue("RankDate", langFile)
            lvLB7.Columns(0).Text = ReadCfgValue("RankNo", langFile)
            lvLB7.Columns(1).Text = ReadCfgValue("RankName", langFile)
            lvLB7.Columns(2).Text = ReadCfgValue("RankCar", langFile)
            lvLB7.Columns(3).Text = ReadCfgValue("RankTime", langFile)
            lvLB7.Columns(4).Text = ReadCfgValue("RankDate", langFile)
            lvLB8.Columns(0).Text = ReadCfgValue("RankNo", langFile)
            lvLB8.Columns(1).Text = ReadCfgValue("RankName", langFile)
            lvLB8.Columns(2).Text = ReadCfgValue("RankCar", langFile)
            lvLB8.Columns(3).Text = ReadCfgValue("RankTime", langFile)
            lvLB8.Columns(4).Text = ReadCfgValue("RankDate", langFile)
            lvLB4.Columns(0).Text = ReadCfgValue("RankNo", langFile)
            lvLB4.Columns(1).Text = ReadCfgValue("RankName", langFile)
            lvLB4.Columns(2).Text = ReadCfgValue("RankCar", langFile)
            lvLB4.Columns(3).Text = ReadCfgValue("RankTime", langFile)
            lvLB4.Columns(4).Text = ReadCfgValue("RankDate", langFile)
            lvLB4e.Columns(0).Text = ReadCfgValue("RankNo", langFile)
            lvLB4e.Columns(1).Text = ReadCfgValue("RankName", langFile)
            lvLB4e.Columns(2).Text = ReadCfgValue("RankCar", langFile)
            lvLB4e.Columns(3).Text = ReadCfgValue("RankTime", langFile)
            lvLB4e.Columns(4).Text = ReadCfgValue("RankDate", langFile)
            lvLB5.Columns(0).Text = ReadCfgValue("RankNo", langFile)
            lvLB5.Columns(1).Text = ReadCfgValue("RankName", langFile)
            lvLB5.Columns(2).Text = ReadCfgValue("RankCar", langFile)
            lvLB5.Columns(3).Text = ReadCfgValue("RankTime", langFile)
            lvLB5.Columns(4).Text = ReadCfgValue("RankDate", langFile)
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

    Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
        MyBase.OnActivated(e)
        Location = LastLocation
    End Sub

    Private Sub frmLeaderboard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus, Me.Deactivate
        LastLocation = Location
    End Sub
End Class