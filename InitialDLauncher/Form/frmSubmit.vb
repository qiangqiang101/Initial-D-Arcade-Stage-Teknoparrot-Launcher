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
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
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
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmSubmit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
    End Sub

    Public Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Me.Text = ReadCfgValue("SubmitMeText", langFile)
            NsTheme1.Text = Me.Text
            Label5.Text = ReadCfgValue("UserName", langFile)
            Label7.Text = ReadCfgValue("GameVersion", langFile)
            Label3.Text = ReadCfgValue("Course", langFile)
            Label1.Text = ReadCfgValue("Type", langFile)
            Label2.Text = ReadCfgValue("Weather", langFile)
            Label4.Text = ReadCfgValue("RankTime", langFile)
            Label6.Text = ReadCfgValue("CarSelect", langFile)
            btnSubmit.Text = ReadCfgValue("SubmitBtn", langFile)
            no_name = ReadCfgValue("BlankName", langFile)
            no_car = ReadCfgValue("NoCarSelected", langFile)
            u_r_banned = ReadCfgValue("URBanned", langFile)
            record_exist = ReadCfgValue("RecordExist", langFile)
            Label8.Text = ReadCfgValue("Server", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmSubmit_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub
End Class