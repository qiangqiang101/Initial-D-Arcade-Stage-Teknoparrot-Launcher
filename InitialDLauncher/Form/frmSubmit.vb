Imports System.Net

Public Class frmSubmit

    Dim PrivateKey As String = "_7sY*>]uKT5>se}N"
    Dim AddScoreURL As String = "http://id.imnotmental.com/AddScore.php?"
    Dim AddScoreURLCN As String = "http://www.emulot.cn/id/AddScore.php?"
    Dim cpuid As String = Nothing

    'Translate
    Dim no_name, no_car, u_r_banned, record_exist As String

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

    Private _weather As String
    Public Property Weather() As String
        Get
            Return _weather
        End Get
        Set(value As String)
            _weather = value
        End Set
    End Property

    Private _track As String
    Public Property Track() As String
        Get
            Return _track
        End Get
        Set(value As String)
            _track = value
        End Set
    End Property

    Private _coursetype As String
    Public Property CourseType() As String
        Get
            Return _coursetype
        End Get
        Set(value As String)
            _coursetype = value
        End Set
    End Property

    Private Sub AddScore(name As String, score As String, car As String, weather As String, track As String, coursetype As String, gameversion As Integer)
        Try
            While cpuid = Nothing
                cpuid = getNewCPUID()
            End While
            Dim numScore As String = score.Replace("'", "").Replace("""", "")
            Dim hash As String = Md5Sum((name & score & car & weather & track & coursetype & gameversion) & PrivateKey)
            Dim client As WebClientEx = New WebClientEx() With {.Timeout = 10000}

            If My.Settings.Server = "World" Then
                client.DownloadString(Convert.ToString(AddScoreURL + "name=" & name & "&score=" & numScore & "&car=" & car & "&weather=" & weather & "&track=" & track & "&coursetype=" & coursetype & "&gameversion=" & gameversion & "&diupc=" & cpuid & "&hash=") & hash)
            Else
                client.DownloadString(Convert.ToString(AddScoreURLCN + "name=" & name & "&score=" & numScore & "&car=" & car & "&weather=" & weather & "&track=" & track & "&coursetype=" & coursetype & "&gameversion=" & gameversion & "&diupc=" & cpuid & "&hash=") & hash)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If lblName.Text = Nothing Then
                MsgBox(no_name, MsgBoxStyle.Critical, "Error")
            ElseIf cmbCar.SelectedItem = Nothing Then
                MsgBox(no_car, MsgBoxStyle.Critical, "Error")
            ElseIf IsMeBanned() Then
                MsgBox(u_r_banned, MsgBoxStyle.Critical, "Error")
            ElseIf DoesRecordExists(_score, _track, _coursetype, _weather, _version) Then
                MsgBox(record_exist, MsgBoxStyle.Critical, "Error")
            Else
                AddScore(String.Format("[{0}]{1}", GetCountryCode(), lblName.Text), _score, cmbCar.SelectedItem.ToString, _weather, _track, _coursetype, _version)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmSubmit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
    End Sub

    Public Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Confirm Submit"
                NsTheme1.Text = Me.Text
                Label5.Text = "User Name"
                Label7.Text = "Game Version"
                Label3.Text = "Course"
                Label1.Text = "Type"
                Label2.Text = "Weather"
                Label4.Text = "Time"
                Label6.Text = "Car"
                btnSubmit.Text = "Submit"
                no_name = "Could not proceed with Blank Name."
                no_car = "Please select a car."
                u_r_banned = "You are not allow to Upload Time Attack results."
                record_exist = "Record already exist on server, please submit another."
                Label8.Text = "Server"
            Case "Chinese"
                Me.Text = "確認提交"
                NsTheme1.Text = Me.Text
                Label5.Text = "用戶名"
                Label7.Text = "遊戲"
                Label3.Text = "地圖"
                Label1.Text = "類別"
                Label2.Text = "天氣"
                Label4.Text = "時間"
                Label6.Text = "車型"
                btnSubmit.Text = "提交"
                no_name = "用戶名為空。"
                no_car = "請選擇一台車。"
                u_r_banned = "您不允許上傳時間挑戰結果。"
                record_exist = "記錄已經存在於服務器上，請提交另一個。"
                Label8.Text = "服務器"
            Case "French"
                Me.Text = "Confirmer Envoyer"
                NsTheme1.Text = Me.Text
                Label5.Text = "Nom d'utilisateur"
                Label7.Text = "Jeu"
                Label3.Text = "Piste"
                Label1.Text = "Type"
                Label2.Text = "Météo"
                Label4.Text = "Temps"
                Label6.Text = "Voiture"
                btnSubmit.Text = "Soumettre"
                no_name = "Impossible de continuer avec le nom vide."
                no_car = "S'il vous plaît sélectionner une voiture."
                u_r_banned = "Vous n'êtes pas autorisé à télécharger les résultats Time Attack."
                record_exist = "L'enregistrement existe déjà sur le serveur, veuillez en soumettre un autre."
                Label8.Text = "Server"
        End Select
    End Sub

    Private Sub frmSubmit_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub
End Class