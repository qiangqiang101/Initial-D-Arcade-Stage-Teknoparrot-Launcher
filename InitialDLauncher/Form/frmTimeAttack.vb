Public Class frmTimeAttack

    Dim LastLocation As Point = New Point(0, 0)
    Dim LakeAkinaDryCC, LakeAkinaDryC, LakeAkinaWetCC, LakeAkinaWetC, MyogiDryUH, MyogiDryDH, MyogiWetUH, MyogiWetDH, UsuiDryCC, UsuiDryC, UsuiWetCC, UsuiWetC,
        AkagiDryUH, AkagiDryDH, AkagiWetUH, AkagiWetDH, AkinaDryUH, AkinaDryDH, AkinaWetUH, AkinaWetDH, IrohazkaDryR, IrohazkaDryDH, IrohazkaWetR, IrohazkaWetDH,
        HappogaharaDryIB, HappogaharaDryOB, HappogaharaWetIB, HappogaharaWetOB, NagaoDryUH, NagaoDryDH, NagaoWetUH, NagaoWetDH, TsukubaDryIB, TsukubaDryOB, TsukubaWetIB, TsukubaWetOB,
        TsubakiLineDryUH, TsubakiLineDryDH, TsubakiLineWetUH, TsubakiLineWetDH, SadamineDryDH, SadamineWetDH, SadamineDryUH, SadamineWetUH, TsukubaSnowOB, TsukubaSnowIB,
        TsuchisakaDryOB, TsuchisakaWetOB, TsuchisakaDryIB, TsuchisakaWetIB, TsuchisakaSnowOB, TsuchisakaSnowIB As String

    Private Sub NsControlButton3_Click(sender As Object, e As EventArgs) Handles NsControlButton3.Click
        LastLocation = Me.Location
    End Sub

    Dim LakeAkinaCC, LakeAkinaC, MyogiDH, MyogiUH, AkagiDH, AkagiUH, AkinaDH, AkinaUH, IrohazkaDH, IrohazkaR, TsukubaIB, TsukubaOB, HappogaharaIB, HappogaharaOB,
        NagaoDH, NagaoUH, TsubakiLineDH, TsubakiLineUH, UsuiCC, UsuiC, SadamineDH, SadamineUH, TsuchisakaIB, TsuchisakaOB, AkinaSnowDH, AkinaSnowUH, NanamagariDH, NanamagariUH,
        _AkinaSnowDH, _AkinaSnowUH, _TsukubaSnowOB, _TsukubaSnowIB, _TsuchisakaSnowOB, _TsuchisakaSnowIB, HakoneDH, HakoneUH, MomijiLineDH, MomijiLineUH As String

    Dim NoRecord As String = "0'00""000"
    Dim item As TimeAttack

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

    Private Sub frmTimeAttack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not My.Settings.FullScreen Then MaximumSize = My.Computer.Screen.WorkingArea.Size

        Translate()
        If _extension = "bin" Then
            If _version = 6 Then
                LakeAkinaDryCC = Helper.GetTimeResult(_filename, 588, False)
                LakeAkinaWetCC = Helper.GetTimeResult(_filename, 592, False)
                LakeAkinaDryC = Helper.GetTimeResult(_filename, 596, False)
                LakeAkinaWetC = Helper.GetTimeResult(_filename, 600, False)
                If Not LakeAkinaDryCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 588, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaDryCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaWetCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 592, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = LakeAkinaWetCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaDryC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 596, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaDryC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaWetC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 600, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = LakeAkinaWetC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MyogiDryDH = Helper.GetTimeResult(_filename, 604, False)
                MyogiWetDH = Helper.GetTimeResult(_filename, 608, False)
                MyogiDryUH = Helper.GetTimeResult(_filename, 612, False)
                MyogiWetUH = Helper.GetTimeResult(_filename, 616, False)
                If Not MyogiDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 604, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 608, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = MyogiWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 612, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 616, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = MyogiWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkagiDryDH = Helper.GetTimeResult(_filename, 620, False)
                AkagiWetDH = Helper.GetTimeResult(_filename, 624, False)
                AkagiDryUH = Helper.GetTimeResult(_filename, 628, False)
                AkagiWetUH = Helper.GetTimeResult(_filename, 632, False)
                If Not AkagiDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 620, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 624, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkagiWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 628, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 632, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkagiWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaDryDH = Helper.GetTimeResult(_filename, 636, False)
                AkinaWetDH = Helper.GetTimeResult(_filename, 640, False)
                AkinaDryUH = Helper.GetTimeResult(_filename, 644, False)
                AkinaWetUH = Helper.GetTimeResult(_filename, 648, False)
                If Not AkinaDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 636, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 640, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkinaWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 644, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 648, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkinaWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                IrohazkaDryDH = Helper.GetTimeResult(_filename, 652, False)
                IrohazkaWetDH = Helper.GetTimeResult(_filename, 656, False)
                IrohazkaDryR = Helper.GetTimeResult(_filename, 660, False)
                IrohazkaWetR = Helper.GetTimeResult(_filename, 664, False)
                If Not IrohazkaDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 652, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 656, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = IrohazkaWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaDryR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 660, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Reversed
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDryR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaWetR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 664, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Reversed
                        .lblWeather.Text = .Wet
                        .lblTime.Text = IrohazkaWetR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaDryOB = Helper.GetTimeResult(_filename, 668, False)
                TsukubaWetOB = Helper.GetTimeResult(_filename, 672, False)
                TsukubaDryIB = Helper.GetTimeResult(_filename, 676, False)
                TsukubaWetIB = Helper.GetTimeResult(_filename, 680, False)
                If Not TsukubaDryOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 668, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaDryOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaWetOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 672, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsukubaWetOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaDryIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 676, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaDryIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaWetIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 680, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsukubaWetIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HappogaharaDryOB = Helper.GetTimeResult(_filename, 684, False)
                HappogaharaWetOB = Helper.GetTimeResult(_filename, 688, False)
                HappogaharaDryIB = Helper.GetTimeResult(_filename, 692, False)
                HappogaharaWetIB = Helper.GetTimeResult(_filename, 696, False)
                If Not HappogaharaDryOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 684, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaDryOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaWetOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 688, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = HappogaharaWetOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaDryIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 692, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaDryIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaWetIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 696, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = HappogaharaWetIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NagaoDryDH = Helper.GetTimeResult(_filename, 700, False)
                NagaoWetDH = Helper.GetTimeResult(_filename, 704, False)
                NagaoDryUH = Helper.GetTimeResult(_filename, 708, False)
                NagaoWetUH = Helper.GetTimeResult(_filename, 712, False)
                If Not NagaoDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 700, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 704, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = NagaoWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 708, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 712, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = NagaoWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsubakiLineDryDH = Helper.GetTimeResult(_filename, 716, False)
                TsubakiLineWetDH = Helper.GetTimeResult(_filename, 720, False)
                TsubakiLineDryUH = Helper.GetTimeResult(_filename, 724, False)
                TsubakiLineWetUH = Helper.GetTimeResult(_filename, 728, False)
                If Not TsubakiLineDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 716, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 720, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsubakiLineWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 724, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 728, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsubakiLineWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                UsuiDryCC = Helper.GetTimeResult(_filename, 732, False)
                UsuiWetCC = Helper.GetTimeResult(_filename, 736, False)
                UsuiDryC = Helper.GetTimeResult(_filename, 740, False)
                UsuiWetC = Helper.GetTimeResult(_filename, 744, False)
                If Not UsuiDryCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 732, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiDryCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiWetCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 736, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = UsuiWetCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiDryC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 740, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiDryC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiWetC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 744, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = UsuiWetC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                SadamineDryDH = Helper.GetTimeResult(_filename, 748, False)
                SadamineWetDH = Helper.GetTimeResult(_filename, 752, False)
                SadamineDryUH = Helper.GetTimeResult(_filename, 756, False)
                SadamineWetUH = Helper.GetTimeResult(_filename, 760, False)
                If Not SadamineDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 748, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 752, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = SadamineWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 756, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 760, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = SadamineWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaDryOB = Helper.GetTimeResult(_filename, 764, False)
                TsuchisakaWetOB = Helper.GetTimeResult(_filename, 768, False)
                TsuchisakaDryIB = Helper.GetTimeResult(_filename, 772, False)
                TsuchisakaWetIB = Helper.GetTimeResult(_filename, 776, False)
                If Not TsuchisakaDryOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 764, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaDryOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaWetOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 768, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsuchisakaWetOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaDryIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 772, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaDryIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaWetIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 776, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsuchisakaWetIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaSnowDH = Helper.GetTimeResult(_filename, 784, False)
                AkinaSnowUH = Helper.GetTimeResult(_filename, 792, False)
                If Not AkinaSnowDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 784, True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = AkinaSnowDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaSnowUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 792, True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = AkinaSnowUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaSnowOB = Helper.GetTimeResult(_filename, 800, False)
                TsukubaSnowIB = Helper.GetTimeResult(_filename, 808, False)
                If Not TsukubaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 800, True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsukubaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 808, True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsukubaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaSnowOB = Helper.GetTimeResult(_filename, 812, False)
                TsuchisakaSnowIB = Helper.GetTimeResult(_filename, 820, False)
                If Not TsuchisakaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 812, True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsuchisakaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 820, True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsuchisakaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
            ElseIf _version = 7 Then
                LakeAkinaCC = Helper.GetTimeResult(_filename, 596, False)
                LakeAkinaC = Helper.GetTimeResult(_filename, 600, False)
                If Not LakeAkinaCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 596, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 600, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MyogiDH = Helper.GetTimeResult(_filename, 604, False)
                MyogiUH = Helper.GetTimeResult(_filename, 608, False)
                If Not MyogiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 604, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 608, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkagiDH = Helper.GetTimeResult(_filename, 612, False)
                AkagiUH = Helper.GetTimeResult(_filename, 616, False)
                If Not AkagiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 612, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 616, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaDH = Helper.GetTimeResult(_filename, 620, False)
                AkinaUH = Helper.GetTimeResult(_filename, 624, False)
                If Not AkinaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 620, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 624, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                IrohazkaDH = Helper.GetTimeResult(_filename, 628, False)
                IrohazkaR = Helper.GetTimeResult(_filename, 632, False)
                If Not IrohazkaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 628, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 632, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaOB = Helper.GetTimeResult(_filename, 636, False)
                TsukubaIB = Helper.GetTimeResult(_filename, 640, False)
                If Not TsukubaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 636, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 640, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HappogaharaOB = Helper.GetTimeResult(_filename, 644, False)
                HappogaharaIB = Helper.GetTimeResult(_filename, 648, False)
                If Not HappogaharaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 644, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 648, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NagaoDH = Helper.GetTimeResult(_filename, 652, False)
                NagaoUH = Helper.GetTimeResult(_filename, 656, False)
                If Not NagaoDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 652, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 656, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsubakiLineDH = Helper.GetTimeResult(_filename, 660, False)
                TsubakiLineUH = Helper.GetTimeResult(_filename, 664, False)
                If Not TsubakiLineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 660, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 664, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                UsuiCC = Helper.GetTimeResult(_filename, 668, False)
                UsuiC = Helper.GetTimeResult(_filename, 672, False)
                If Not UsuiCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 668, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 672, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                SadamineDH = Helper.GetTimeResult(_filename, 676, False)
                SadamineUH = Helper.GetTimeResult(_filename, 680, False)
                If Not SadamineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 676, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 680, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaOB = Helper.GetTimeResult(_filename, 684, False)
                TsuchisakaIB = Helper.GetTimeResult(_filename, 688, False)
                If Not TsuchisakaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 684, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 688, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _AkinaSnowDH = Helper.GetTimeResult(_filename, 692, False)
                _AkinaSnowUH = Helper.GetTimeResult(_filename, 696, False)
                If Not _AkinaSnowDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 692, True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _AkinaSnowUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 696, True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _TsukubaSnowOB = Helper.GetTimeResult(_filename, 700, False)
                _TsukubaSnowIB = Helper.GetTimeResult(_filename, 704, False)
                If Not _TsukubaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 700, True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsukubaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _TsukubaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 704, True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsukubaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _TsuchisakaSnowOB = Helper.GetTimeResult(_filename, 708, False)
                _TsuchisakaSnowIB = Helper.GetTimeResult(_filename, 712, False)
                If Not _TsuchisakaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 700, True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsuchisakaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _TsuchisakaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 704, True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsuchisakaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NanamagariDH = Helper.GetTimeResult(_filename, 716, False)
                NanamagariUH = Helper.GetTimeResult(_filename, 720, False)
                If Not NanamagariDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 716, True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NanamagariUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 720, True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
            ElseIf _version = 8 Then
                LakeAkinaCC = Helper.GetTimeResult(_filename, 596, False)
                LakeAkinaC = Helper.GetTimeResult(_filename, 600, False)
                If Not LakeAkinaCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 596, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 600, True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MyogiDH = Helper.GetTimeResult(_filename, 604, False)
                MyogiUH = Helper.GetTimeResult(_filename, 608, False)
                If Not MyogiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 604, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 608, True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkagiDH = Helper.GetTimeResult(_filename, 612, False)
                AkagiUH = Helper.GetTimeResult(_filename, 616, False)
                If Not AkagiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 612, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 616, True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaDH = Helper.GetTimeResult(_filename, 620, False)
                AkinaUH = Helper.GetTimeResult(_filename, 624, False)
                If Not AkinaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 620, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 624, True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                IrohazkaDH = Helper.GetTimeResult(_filename, 628, False)
                IrohazkaR = Helper.GetTimeResult(_filename, 632, False)
                If Not IrohazkaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 628, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 632, True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaOB = Helper.GetTimeResult(_filename, 636, False)
                TsukubaIB = Helper.GetTimeResult(_filename, 640, False)
                If Not TsukubaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 636, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 640, True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HappogaharaOB = Helper.GetTimeResult(_filename, 644, False)
                HappogaharaIB = Helper.GetTimeResult(_filename, 648, False)
                If Not HappogaharaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 644, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 648, True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NagaoDH = Helper.GetTimeResult(_filename, 652, False)
                NagaoUH = Helper.GetTimeResult(_filename, 656, False)
                If Not NagaoDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 652, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 656, True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsubakiLineDH = Helper.GetTimeResult(_filename, 660, False)
                TsubakiLineUH = Helper.GetTimeResult(_filename, 664, False)
                If Not TsubakiLineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 660, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 664, True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                UsuiCC = Helper.GetTimeResult(_filename, 668, False)
                UsuiC = Helper.GetTimeResult(_filename, 672, False)
                If Not UsuiCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 668, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 672, True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                SadamineDH = Helper.GetTimeResult(_filename, 676, False)
                SadamineUH = Helper.GetTimeResult(_filename, 680, False)
                If Not SadamineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 676, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 680, True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaOB = Helper.GetTimeResult(_filename, 684, False)
                TsuchisakaIB = Helper.GetTimeResult(_filename, 688, False)
                If Not TsuchisakaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 684, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 688, True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _AkinaSnowDH = Helper.GetTimeResult(_filename, 692, False)
                _AkinaSnowUH = Helper.GetTimeResult(_filename, 696, False)
                If Not _AkinaSnowDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 692, True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _AkinaSnowUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 696, True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HakoneDH = Helper.GetTimeResult(_filename, 700, False) '_TsukubaSnowOB
                HakoneUH = Helper.GetTimeResult(_filename, 704, False) '_TsukubaSnowIB
                If Not HakoneDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 700, True), .BackgroundImage = My.Resources.hakone}
                    With item
                        .Translate()
                        .lblCourse.Text = .Hakone
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HakoneDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HakoneUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 704, True), .BackgroundImage = My.Resources.hakone}
                    With item
                        .Translate()
                        .lblCourse.Text = .Hakone
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HakoneUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MomijiLineDH = Helper.GetTimeResult(_filename, 708, False) '_TsuchisakaSnowOB
                MomijiLineUH = Helper.GetTimeResult(_filename, 712, False) '_TsuchisakaSnowIB
                If Not MomijiLineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 700, True), .BackgroundImage = My.Resources.momijiline}
                    With item
                        .Translate()
                        .lblCourse.Text = .MomijiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MomijiLineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MomijiLineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 704, True), .BackgroundImage = My.Resources.momijiline}
                    With item
                        .Translate()
                        .lblCourse.Text = .MomijiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MomijiLineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NanamagariDH = Helper.GetTimeResult(_filename, 716, False)
                NanamagariUH = Helper.GetTimeResult(_filename, 720, False)
                If Not NanamagariDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 716, True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NanamagariUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, 720, True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
            End If
        Else
            If _version = 6 Then
                LakeAkinaDryCC = Helper.GetTimeResult(_filename, Neg60(588), False)
                LakeAkinaWetCC = Helper.GetTimeResult(_filename, Neg60(592), False)
                LakeAkinaDryC = Helper.GetTimeResult(_filename, Neg60(596), False)
                LakeAkinaWetC = Helper.GetTimeResult(_filename, Neg60(600), False)
                If Not LakeAkinaDryCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(588), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaDryCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaWetCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(592), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = LakeAkinaWetCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaDryC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(596), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaDryC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaWetC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(600), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = LakeAkinaWetC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MyogiDryDH = Helper.GetTimeResult(_filename, Neg60(604), False)
                MyogiWetDH = Helper.GetTimeResult(_filename, Neg60(608), False)
                MyogiDryUH = Helper.GetTimeResult(_filename, Neg60(612), False)
                MyogiWetUH = Helper.GetTimeResult(_filename, Neg60(616), False)
                If Not MyogiDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(604), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(608), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = MyogiWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(612), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(616), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = MyogiWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkagiDryDH = Helper.GetTimeResult(_filename, Neg60(620), False)
                AkagiWetDH = Helper.GetTimeResult(_filename, Neg60(624), False)
                AkagiDryUH = Helper.GetTimeResult(_filename, Neg60(628), False)
                AkagiWetUH = Helper.GetTimeResult(_filename, Neg60(632), False)
                If Not AkagiDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(620), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(624), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkagiWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(628), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(632), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkagiWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaDryDH = Helper.GetTimeResult(_filename, Neg60(636), False)
                AkinaWetDH = Helper.GetTimeResult(_filename, Neg60(640), False)
                AkinaDryUH = Helper.GetTimeResult(_filename, Neg60(644), False)
                AkinaWetUH = Helper.GetTimeResult(_filename, Neg60(648), False)
                If Not AkinaDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(636), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(640), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkinaWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(644), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(648), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = AkinaWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                IrohazkaDryDH = Helper.GetTimeResult(_filename, Neg60(652), False)
                IrohazkaWetDH = Helper.GetTimeResult(_filename, Neg60(656), False)
                IrohazkaDryR = Helper.GetTimeResult(_filename, Neg60(660), False)
                IrohazkaWetR = Helper.GetTimeResult(_filename, Neg60(664), False)
                If Not IrohazkaDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(652), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(656), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = IrohazkaWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaDryR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(660), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Reversed
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDryR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaWetR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(664), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Reversed
                        .lblWeather.Text = .Wet
                        .lblTime.Text = IrohazkaWetR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaDryOB = Helper.GetTimeResult(_filename, Neg60(668), False)
                TsukubaWetOB = Helper.GetTimeResult(_filename, Neg60(672), False)
                TsukubaDryIB = Helper.GetTimeResult(_filename, Neg60(676), False)
                TsukubaWetIB = Helper.GetTimeResult(_filename, Neg60(680), False)
                If Not TsukubaDryOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(668), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaDryOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaWetOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(672), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsukubaWetOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaDryIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(676), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaDryIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaWetIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(680), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsukubaWetIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HappogaharaDryOB = Helper.GetTimeResult(_filename, Neg60(684), False)
                HappogaharaWetOB = Helper.GetTimeResult(_filename, Neg60(688), False)
                HappogaharaDryIB = Helper.GetTimeResult(_filename, Neg60(692), False)
                HappogaharaWetIB = Helper.GetTimeResult(_filename, Neg60(696), False)
                If Not HappogaharaDryOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(684), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaDryOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaWetOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(688), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = HappogaharaWetOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaDryIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(692), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaDryIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaWetIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(696), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = HappogaharaWetIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NagaoDryDH = Helper.GetTimeResult(_filename, Neg60(700), False)
                NagaoWetDH = Helper.GetTimeResult(_filename, Neg60(704), False)
                NagaoDryUH = Helper.GetTimeResult(_filename, Neg60(708), False)
                NagaoWetUH = Helper.GetTimeResult(_filename, Neg60(712), False)
                If Not NagaoDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(700), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(704), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = NagaoWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(708), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(712), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = NagaoWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsubakiLineDryDH = Helper.GetTimeResult(_filename, Neg60(716), False)
                TsubakiLineWetDH = Helper.GetTimeResult(_filename, Neg60(720), False)
                TsubakiLineDryUH = Helper.GetTimeResult(_filename, Neg60(724), False)
                TsubakiLineWetUH = Helper.GetTimeResult(_filename, Neg60(728), False)
                If Not TsubakiLineDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(716), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(720), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsubakiLineWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(724), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(728), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsubakiLineWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                UsuiDryCC = Helper.GetTimeResult(_filename, Neg60(732), False)
                UsuiWetCC = Helper.GetTimeResult(_filename, Neg60(736), False)
                UsuiDryC = Helper.GetTimeResult(_filename, Neg60(740), False)
                UsuiWetC = Helper.GetTimeResult(_filename, Neg60(744), False)
                If Not UsuiDryCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(732), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiDryCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiWetCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(736), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = UsuiWetCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiDryC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(740), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiDryC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiWetC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(744), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Wet
                        .lblTime.Text = UsuiWetC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                SadamineDryDH = Helper.GetTimeResult(_filename, Neg60(748), False)
                SadamineWetDH = Helper.GetTimeResult(_filename, Neg60(752), False)
                SadamineDryUH = Helper.GetTimeResult(_filename, Neg60(756), False)
                SadamineWetUH = Helper.GetTimeResult(_filename, Neg60(760), False)
                If Not SadamineDryDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(748), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDryDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineWetDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(752), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = SadamineWetDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineDryUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(756), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDryUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineWetUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(760), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Wet
                        .lblTime.Text = SadamineWetUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaDryOB = Helper.GetTimeResult(_filename, Neg60(764), False)
                TsuchisakaWetOB = Helper.GetTimeResult(_filename, Neg60(768), False)
                TsuchisakaDryIB = Helper.GetTimeResult(_filename, Neg60(772), False)
                TsuchisakaWetIB = Helper.GetTimeResult(_filename, Neg60(776), False)
                If Not TsuchisakaDryOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(764), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaDryOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaWetOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(768), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsuchisakaWetOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaDryIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(772), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaDryIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaWetIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(776), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Wet
                        .lblTime.Text = TsuchisakaWetIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaSnowDH = Helper.GetTimeResult(_filename, Neg60(784), False)
                AkinaSnowUH = Helper.GetTimeResult(_filename, Neg60(792), False)
                If Not AkinaSnowDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(784), True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = AkinaSnowDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaSnowUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(792), True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = AkinaSnowUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaSnowOB = Helper.GetTimeResult(_filename, Neg60(800), False)
                TsukubaSnowIB = Helper.GetTimeResult(_filename, Neg60(808), False)
                If Not TsukubaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(800), True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsukubaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(808), True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsukubaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaSnowOB = Helper.GetTimeResult(_filename, Neg60(812), False)
                TsuchisakaSnowIB = Helper.GetTimeResult(_filename, Neg60(820), False)
                If Not TsuchisakaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(812), True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsuchisakaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(820), True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = TsuchisakaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
            ElseIf _version = 7 Then
                LakeAkinaCC = Helper.GetTimeResult(_filename, Neg60(596), False)
                LakeAkinaC = Helper.GetTimeResult(_filename, Neg60(600), False)
                If Not LakeAkinaCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(596), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(600), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MyogiDH = Helper.GetTimeResult(_filename, Neg60(604), False)
                MyogiUH = Helper.GetTimeResult(_filename, Neg60(608), False)
                If Not MyogiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(604), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(608), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkagiDH = Helper.GetTimeResult(_filename, Neg60(612), False)
                AkagiUH = Helper.GetTimeResult(_filename, Neg60(616), False)
                If Not AkagiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(612), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(616), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaDH = Helper.GetTimeResult(_filename, Neg60(620), False)
                AkinaUH = Helper.GetTimeResult(_filename, Neg60(624), False)
                If Not AkinaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(620), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(624), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                IrohazkaDH = Helper.GetTimeResult(_filename, Neg60(628), False)
                IrohazkaR = Helper.GetTimeResult(_filename, Neg60(632), False)
                If Not IrohazkaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(628), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(632), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaOB = Helper.GetTimeResult(_filename, Neg60(636), False)
                TsukubaIB = Helper.GetTimeResult(_filename, Neg60(640), False)
                If Not TsukubaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(636), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(640), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HappogaharaOB = Helper.GetTimeResult(_filename, Neg60(644), False)
                HappogaharaIB = Helper.GetTimeResult(_filename, Neg60(648), False)
                If Not HappogaharaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(644), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(648), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NagaoDH = Helper.GetTimeResult(_filename, Neg60(652), False)
                NagaoUH = Helper.GetTimeResult(_filename, Neg60(656), False)
                If Not NagaoDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(652), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(656), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsubakiLineDH = Helper.GetTimeResult(_filename, Neg60(660), False)
                TsubakiLineUH = Helper.GetTimeResult(_filename, Neg60(664), False)
                If Not TsubakiLineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(660), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(664), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                UsuiCC = Helper.GetTimeResult(_filename, Neg60(668), False)
                UsuiC = Helper.GetTimeResult(_filename, Neg60(672), False)
                If Not UsuiCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(668), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(672), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                SadamineDH = Helper.GetTimeResult(_filename, Neg60(676), False)
                SadamineUH = Helper.GetTimeResult(_filename, Neg60(680), False)
                If Not SadamineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(676), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(680), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaOB = Helper.GetTimeResult(_filename, Neg60(684), False)
                TsuchisakaIB = Helper.GetTimeResult(_filename, Neg60(688), False)
                If Not TsuchisakaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(684), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(688), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _AkinaSnowDH = Helper.GetTimeResult(_filename, Neg60(692), False)
                _AkinaSnowUH = Helper.GetTimeResult(_filename, Neg60(696), False)
                If Not _AkinaSnowDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(692), True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _AkinaSnowUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(696), True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _TsukubaSnowOB = Helper.GetTimeResult(_filename, Neg60(700), False)
                _TsukubaSnowIB = Helper.GetTimeResult(_filename, Neg60(704), False)
                If Not _TsukubaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(700), True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsukubaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _TsukubaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(704), True), .BackgroundImage = My.Resources.tsukubaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsukubaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsukubaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _TsuchisakaSnowOB = Helper.GetTimeResult(_filename, Neg60(708), False)
                _TsuchisakaSnowIB = Helper.GetTimeResult(_filename, Neg60(712), False)
                If Not _TsuchisakaSnowOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(708), True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsuchisakaSnowOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _TsuchisakaSnowIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(712), True), .BackgroundImage = My.Resources.tsuchisakaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsuchisakaSnow
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _TsuchisakaSnowIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NanamagariDH = Helper.GetTimeResult(_filename, Neg60(716), False)
                NanamagariUH = Helper.GetTimeResult(_filename, Neg60(720), False)
                If Not NanamagariDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(716), True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NanamagariUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(720), True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
            ElseIf _version = 8 Then
                LakeAkinaCC = Helper.GetTimeResult(_filename, Neg60(596), False)
                LakeAkinaC = Helper.GetTimeResult(_filename, Neg60(600), False)
                If Not LakeAkinaCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(596), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not LakeAkinaC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(600), True), .BackgroundImage = My.Resources.lakeAkina}
                    With item
                        .Translate()
                        .lblCourse.Text = .LakeAkina
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = LakeAkinaC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MyogiDH = Helper.GetTimeResult(_filename, Neg60(604), False)
                MyogiUH = Helper.GetTimeResult(_filename, Neg60(608), False)
                If Not MyogiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(604), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MyogiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(608), True), .BackgroundImage = My.Resources.myogi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Myogi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MyogiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkagiDH = Helper.GetTimeResult(_filename, Neg60(612), False)
                AkagiUH = Helper.GetTimeResult(_filename, Neg60(616), False)
                If Not AkagiDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(612), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkagiUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(616), True), .BackgroundImage = My.Resources.akagi}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akagi
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkagiUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                AkinaDH = Helper.GetTimeResult(_filename, Neg60(620), False)
                AkinaUH = Helper.GetTimeResult(_filename, Neg60(624), False)
                If Not AkinaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(620), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not AkinaUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(624), True), .BackgroundImage = My.Resources.akina}
                    With item
                        .Translate()
                        .lblCourse.Text = .Akina
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = AkinaUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                IrohazkaDH = Helper.GetTimeResult(_filename, Neg60(628), False)
                IrohazkaR = Helper.GetTimeResult(_filename, Neg60(632), False)
                If Not IrohazkaDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(628), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not IrohazkaR = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(632), True), .BackgroundImage = My.Resources.irohazaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Irohazka
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = IrohazkaR
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsukubaOB = Helper.GetTimeResult(_filename, Neg60(636), False)
                TsukubaIB = Helper.GetTimeResult(_filename, Neg60(640), False)
                If Not TsukubaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(636), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsukubaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(640), True), .BackgroundImage = My.Resources.tsukuba}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsukuba
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsukubaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HappogaharaOB = Helper.GetTimeResult(_filename, Neg60(644), False)
                HappogaharaIB = Helper.GetTimeResult(_filename, Neg60(648), False)
                If Not HappogaharaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(644), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HappogaharaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(648), True), .BackgroundImage = My.Resources.happogahara}
                    With item
                        .Translate()
                        .lblCourse.Text = .Happogahara
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HappogaharaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NagaoDH = Helper.GetTimeResult(_filename, Neg60(652), False)
                NagaoUH = Helper.GetTimeResult(_filename, Neg60(656), False)
                If Not NagaoDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(652), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NagaoUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(656), True), .BackgroundImage = My.Resources.nagao}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nagao
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NagaoUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsubakiLineDH = Helper.GetTimeResult(_filename, Neg60(660), False)
                TsubakiLineUH = Helper.GetTimeResult(_filename, Neg60(664), False)
                If Not TsubakiLineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(660), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsubakiLineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(664), True), .BackgroundImage = My.Resources.tsubakiLine}
                    With item
                        .Translate()
                        .lblCourse.Text = .TsubakiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsubakiLineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                UsuiCC = Helper.GetTimeResult(_filename, Neg60(668), False)
                UsuiC = Helper.GetTimeResult(_filename, Neg60(672), False)
                If Not UsuiCC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(668), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Counterclockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiCC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not UsuiC = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(672), True), .BackgroundImage = My.Resources.usui}
                    With item
                        .Translate()
                        .lblCourse.Text = .Usui
                        .lblType.Text = .Clockwise
                        .lblWeather.Text = .Dry
                        .lblTime.Text = UsuiC
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                SadamineDH = Helper.GetTimeResult(_filename, Neg60(676), False)
                SadamineUH = Helper.GetTimeResult(_filename, Neg60(680), False)
                If Not SadamineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(676), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not SadamineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(680), True), .BackgroundImage = My.Resources.sadamine}
                    With item
                        .Translate()
                        .lblCourse.Text = .Sadamine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = SadamineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                TsuchisakaOB = Helper.GetTimeResult(_filename, Neg60(684), False)
                TsuchisakaIB = Helper.GetTimeResult(_filename, Neg60(688), False)
                If Not TsuchisakaOB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(684), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Outbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaOB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not TsuchisakaIB = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(688), True), .BackgroundImage = My.Resources.tsuchisaka}
                    With item
                        .Translate()
                        .lblCourse.Text = .Tsuchisaka
                        .lblType.Text = .Inbound
                        .lblWeather.Text = .Dry
                        .lblTime.Text = TsuchisakaIB
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                _AkinaSnowDH = Helper.GetTimeResult(_filename, Neg60(692), False)
                _AkinaSnowUH = Helper.GetTimeResult(_filename, Neg60(696), False)
                If Not _AkinaSnowDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(692), True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not _AkinaSnowUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(696), True), .BackgroundImage = My.Resources.akinaSnow}
                    With item
                        .Translate()
                        .lblCourse.Text = .AkinaSnow
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Snow
                        .lblTime.Text = _AkinaSnowUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                HakoneDH = Helper.GetTimeResult(_filename, Neg60(700), False) '_TsukubaSnowOB
                HakoneUH = Helper.GetTimeResult(_filename, Neg60(704), False) '_TsukubaSnowIB
                If Not HakoneDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(700), True), .BackgroundImage = My.Resources.hakone}
                    With item
                        .Translate()
                        .lblCourse.Text = .Hakone
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HakoneDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not HakoneUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(704), True), .BackgroundImage = My.Resources.hakone}
                    With item
                        .Translate()
                        .lblCourse.Text = .Hakone
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = HakoneUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                MomijiLineDH = Helper.GetTimeResult(_filename, Neg60(708), False) '_TsuchisakaSnowOB
                MomijiLineUH = Helper.GetTimeResult(_filename, Neg60(712), False) '_TsuchisakaSnowIB
                If Not MomijiLineDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(700), True), .BackgroundImage = My.Resources.momijiline}
                    With item
                        .Translate()
                        .lblCourse.Text = .MomijiLine
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MomijiLineDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not MomijiLineUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(704), True), .BackgroundImage = My.Resources.momijiline}
                    With item
                        .Translate()
                        .lblCourse.Text = .MomijiLine
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = MomijiLineUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If

                NanamagariDH = Helper.GetTimeResult(_filename, Neg60(716), False)
                NanamagariUH = Helper.GetTimeResult(_filename, Neg60(720), False)
                If Not NanamagariDH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(716), True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Downhill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariDH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
                If Not NanamagariUH = NoRecord Then
                    item = New TimeAttack With {.Version = _version, .Extension = _extension, .FileName = _filename, .Score = Helper.GetTimeResult(_filename, Neg60(720), True), .BackgroundImage = My.Resources.namagari}
                    With item
                        .Translate()
                        .lblCourse.Text = .Nanamagari
                        .lblType.Text = .Uphill
                        .lblWeather.Text = .Dry
                        .lblTime.Text = NanamagariUH
                        .lblTypeWeather.Text = String.Format("{0} / {1}", .lblType.Text, .lblWeather.Text)
                    End With
                    flPanel.FP.Controls.Add(item)
                End If
            End If
        End If

        If frmLauncher.WindowState = FormWindowState.Maximized Then
            NsControlButton3.Enabled = False
        End If
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            'ReadCfgValue("", langFile)
            Me.Text = ReadCfgValue("TAMeText", langFile)
            NsTheme1.Text = Me.Text
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmTimeAttack_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub

    Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
        MyBase.OnActivated(e)
        Me.Location = LastLocation
    End Sub

    Private Sub frmTimeAttack_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus, Me.Deactivate
        LastLocation = Me.Location
    End Sub
End Class