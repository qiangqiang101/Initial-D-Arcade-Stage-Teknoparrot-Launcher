Public Class frmTimeAttack

    Dim LakeAkinaDryCC, LakeAkinaDryC, LakeAkinaWetCC, LakeAkinaWetC, MyogiDryUH, MyogiDryDH, MyogiWetUH, MyogiWetDH, UsuiDryCC, UsuiDryC, UsuiWetCC, UsuiWetC,
        AkagiDryUH, AkagiDryDH, AkagiWetUH, AkagiWetDH, AkinaDryUH, AkinaDryDH, AkinaWetUH, AkinaWetDH, IrohazkaDryR, IrohazkaDryDH, IrohazkaWetR, IrohazkaWetDH,
        HappogaharaDryIB, HappogaharaDryOB, HappogaharaWetIB, HappogaharaWetOB, NagaoDryUH, NagaoDryDH, NagaoWetUH, NagaoWetDH, TsukubaDryIB, TsukubaDryOB, TsukubaWetIB, TsukubaWetOB,
        TsubakiLineDryUH, TsubakiLineDryDH, TsubakiLineWetUH, TsubakiLineWetDH As String
    Dim LakeAkinaCC, LakeAkinaC, MyogiDH, MyogiUH, AkagiDH, AkagiUH, AkinaDH, AkinaUH, IrohazkaDH, IrohazkaR, TsukubaIB, TsukubaOB, HappogaharaIB, HappogaharaOB,
        NagaoDH, NagaoUH, TsubakiLineDH, TsubakiLineUH, UsuiCC, UsuiC, SadamineDH, SadamineUH, TsuchisakaIB, TsuchisakaOB, AkinaSnowDH, AkinaSnowUH, NanamagariDH, NanamagariUH As String

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

    Private Sub frmTimeAttack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()

        If _version = 6 Then
            'Lake Akina
            LakeAkinaDryCC = GetTimeResult(_filename, 588)
            LakeAkinaWetCC = GetTimeResult(_filename, 592)
            LakeAkinaDryC = GetTimeResult(_filename, 596)
            LakeAkinaWetC = GetTimeResult(_filename, 600)
            If Not LakeAkinaDryCC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 588, True), .BackColor = Color.LightBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = LakeAkinaDryCC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaWetCC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 592, True), .BackColor = Color.LightBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = LakeAkinaWetCC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaDryC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 596, True), .BackColor = Color.LightBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = LakeAkinaDryC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaWetC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 600, True), .BackColor = Color.LightBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = LakeAkinaWetC
                End With
                flPanel.Controls.Add(item)
            End If

            'Myogi
            MyogiDryDH = GetTimeResult(_filename, 604)
            MyogiWetDH = GetTimeResult(_filename, 608)
            MyogiDryUH = GetTimeResult(_filename, 612)
            MyogiWetUH = GetTimeResult(_filename, 616)
            If Not MyogiDryDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 604, True), .BackColor = Color.LightCoral}
                With item
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = MyogiDryDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiWetDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 608, True), .BackColor = Color.LightCoral}
                With item
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = MyogiWetDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiDryUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 612, True), .BackColor = Color.LightCoral}
                With item
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = MyogiDryUH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiWetUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 616, True), .BackColor = Color.LightCoral}
                With item
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = MyogiWetUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Akagi
            AkagiDryDH = GetTimeResult(_filename, 620)
            AkagiWetDH = GetTimeResult(_filename, 624)
            AkagiDryUH = GetTimeResult(_filename, 628)
            AkagiWetUH = GetTimeResult(_filename, 632)
            If Not AkagiDryDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 620, True), .BackColor = Color.LightSkyBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkagiDryDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiWetDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 624, True), .BackColor = Color.LightSkyBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkagiWetDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiDryUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 628, True), .BackColor = Color.LightSkyBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkagiDryUH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiWetUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 632, True), .BackColor = Color.LightSkyBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkagiWetUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Akina
            AkinaDryDH = GetTimeResult(_filename, 636)
            AkinaWetDH = GetTimeResult(_filename, 640)
            AkinaDryUH = GetTimeResult(_filename, 644)
            AkinaWetUH = GetTimeResult(_filename, 648)
            If Not AkinaDryDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 636, True), .BackColor = Color.LightGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkinaDryDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaWetDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 640, True), .BackColor = Color.LightGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkinaWetDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaDryUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 644, True), .BackColor = Color.LightGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkinaDryUH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaWetUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 648, True), .BackColor = Color.LightGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkinaWetUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Irohazaka
            IrohazkaDryDH = GetTimeResult(_filename, 652)
            IrohazkaWetDH = GetTimeResult(_filename, 656)
            IrohazkaDryR = GetTimeResult(_filename, 660)
            IrohazkaWetR = GetTimeResult(_filename, 664)
            If Not IrohazkaDryDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 652, True), .BackColor = Color.LightSalmon}
                With item
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = IrohazkaDryDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaWetDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 656, True), .BackColor = Color.LightSalmon}
                With item
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = IrohazkaWetDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaDryR = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 660, True), .BackColor = Color.LightSalmon}
                With item
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Reversed
                    .lblWeather.Text = .Dry
                    .lblTime.Text = IrohazkaDryR
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaWetR = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 664, True), .BackColor = Color.LightSalmon}
                With item
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Reversed
                    .lblWeather.Text = .Wet
                    .lblTime.Text = IrohazkaWetR
                End With
                flPanel.Controls.Add(item)
            End If

            'Tsukuba
            TsukubaDryOB = GetTimeResult(_filename, 668)
            TsukubaWetOB = GetTimeResult(_filename, 672)
            TsukubaDryIB = GetTimeResult(_filename, 676)
            TsukubaWetIB = GetTimeResult(_filename, 680)
            If Not TsukubaDryOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 668, True), .BackColor = Color.LightGoldenrodYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsukubaDryOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaWetOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 672, True), .BackColor = Color.LightGoldenrodYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsukubaWetOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaDryIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 676, True), .BackColor = Color.LightGoldenrodYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsukubaDryIB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaWetIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 680, True), .BackColor = Color.LightGoldenrodYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsukubaWetIB
                End With
                flPanel.Controls.Add(item)
            End If

            'Happogahara
            HappogaharaDryOB = GetTimeResult(_filename, 684)
            HappogaharaWetOB = GetTimeResult(_filename, 688)
            HappogaharaDryIB = GetTimeResult(_filename, 692)
            HappogaharaWetIB = GetTimeResult(_filename, 696)
            If Not HappogaharaDryOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 684, True), .BackColor = Color.LightSlateGray}
                With item
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = HappogaharaDryOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaWetOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 688, True), .BackColor = Color.LightSlateGray}
                With item
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = HappogaharaWetOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaDryIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 692, True), .BackColor = Color.LightSlateGray}
                With item
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = HappogaharaDryIB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaWetIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 696, True), .BackColor = Color.LightSlateGray}
                With item
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = HappogaharaWetIB
                End With
                flPanel.Controls.Add(item)
            End If

            'Nagao
            NagaoDryDH = GetTimeResult(_filename, 700)
            NagaoWetDH = GetTimeResult(_filename, 704)
            NagaoDryUH = GetTimeResult(_filename, 708)
            NagaoWetUH = GetTimeResult(_filename, 712)
            If Not NagaoDryDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 700, True), .BackColor = Color.LightYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NagaoDryDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoWetDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 704, True), .BackColor = Color.LightYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = NagaoWetDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoDryUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 708, True), .BackColor = Color.LightYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NagaoDryUH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoWetUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 712, True), .BackColor = Color.LightYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = NagaoWetUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Tsubaki Line
            TsubakiLineDryDH = GetTimeResult(_filename, 716)
            TsubakiLineWetDH = GetTimeResult(_filename, 720)
            TsubakiLineDryUH = GetTimeResult(_filename, 724)
            TsubakiLineWetUH = GetTimeResult(_filename, 728)
            If Not TsubakiLineDryDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 716, True), .BackColor = Color.LightSeaGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsubakiLineDryDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineWetDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 720, True), .BackColor = Color.LightSeaGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsubakiLineWetDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineDryUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 724, True), .BackColor = Color.LightSeaGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsubakiLineDryUH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineWetUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 728, True), .BackColor = Color.LightSeaGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsubakiLineWetUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Usui
            UsuiDryCC = GetTimeResult(_filename, 732)
            UsuiWetCC = GetTimeResult(_filename, 736)
            UsuiDryC = GetTimeResult(_filename, 740)
            UsuiWetC = GetTimeResult(_filename, 744)
            If Not UsuiDryCC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 732, True), .BackColor = Color.LightSteelBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = UsuiDryCC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiWetCC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 736, True), .BackColor = Color.LightSteelBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = UsuiWetCC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiDryC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 740, True), .BackColor = Color.LightSteelBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = UsuiDryC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiWetC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 744, True), .BackColor = Color.LightSteelBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = UsuiWetC
                End With
                flPanel.Controls.Add(item)
            End If
        Else
            'Lake Akina
            LakeAkinaCC = GetTimeResult(_filename, 596)
            LakeAkinaC = GetTimeResult(_filename, 600)
            If Not LakeAkinaCC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 596, True), .BackColor = Color.LightBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = LakeAkinaCC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 600, True), .BackColor = Color.LightBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = LakeAkinaC
                End With
                flPanel.Controls.Add(item)
            End If

            'Myogi
            MyogiDH = GetTimeResult(_filename, 604)
            MyogiUH = GetTimeResult(_filename, 608)
            If Not MyogiDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 604, True), .BackColor = Color.LightCoral}
                With item
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = MyogiDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 608, True), .BackColor = Color.LightCoral}
                With item
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = MyogiUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Akagi
            AkagiDH = GetTimeResult(_filename, 612)
            AkagiUH = GetTimeResult(_filename, 616)
            If Not AkagiDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 612, True), .BackColor = Color.LightSkyBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkagiDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 616, True), .BackColor = Color.LightSkyBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkagiUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Akina
            AkinaDH = GetTimeResult(_filename, 620)
            AkinaUH = GetTimeResult(_filename, 624)
            If Not AkinaDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 620, True), .BackColor = Color.LightGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkinaDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 624, True), .BackColor = Color.LightGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkinaUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Irohazka
            IrohazkaDH = GetTimeResult(_filename, 628)
            IrohazkaR = GetTimeResult(_filename, 632)
            If Not IrohazkaDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 628, True), .BackColor = Color.LightSalmon}
                With item
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = IrohazkaDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaR = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 632, True), .BackColor = Color.LightSalmon}
                With item
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = IrohazkaR
                End With
                flPanel.Controls.Add(item)
            End If

            'Tsukuba
            TsukubaOB = GetTimeResult(_filename, 636)
            TsukubaIB = GetTimeResult(_filename, 640)
            If Not TsukubaOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 636, True), .BackColor = Color.LightGoldenrodYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsukubaOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 640, True), .BackColor = Color.LightGoldenrodYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsukubaIB
                End With
                flPanel.Controls.Add(item)
            End If

            'Happogahara
            HappogaharaOB = GetTimeResult(_filename, 644)
            HappogaharaIB = GetTimeResult(_filename, 648)
            If Not HappogaharaOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 644, True), .BackColor = Color.LightSlateGray}
                With item
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = HappogaharaOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 648, True), .BackColor = Color.LightSlateGray}
                With item
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = HappogaharaIB
                End With
                flPanel.Controls.Add(item)
            End If

            'Nagao
            NagaoDH = GetTimeResult(_filename, 652)
            NagaoUH = GetTimeResult(_filename, 656)
            If Not NagaoDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 652, True), .BackColor = Color.LightYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NagaoDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 656, True), .BackColor = Color.LightYellow}
                With item
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NagaoUH
                End With
                flPanel.Controls.Add(item)
            End If

            'TsubakiLine
            TsubakiLineDH = GetTimeResult(_filename, 660)
            TsubakiLineUH = GetTimeResult(_filename, 664)
            If Not TsubakiLineDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 660, True), .BackColor = Color.LightSeaGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsubakiLineDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 664, True), .BackColor = Color.LightSeaGreen}
                With item
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsubakiLineUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Usui
            UsuiCC = GetTimeResult(_filename, 668)
            UsuiC = GetTimeResult(_filename, 672)
            If Not UsuiCC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 668, True), .BackColor = Color.LightSteelBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = UsuiCC
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiC = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 672, True), .BackColor = Color.LightSteelBlue}
                With item
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = UsuiC
                End With
                flPanel.Controls.Add(item)
            End If

            'Sadamine
            SadamineDH = GetTimeResult(_filename, 676)
            SadamineUH = GetTimeResult(_filename, 680)
            If Not SadamineDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 676, True), .BackColor = Color.LightCyan}
                With item
                    .Translate()
                    .lblCourse.Text = .Sadamine
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = SadamineDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not SadamineUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 680, True), .BackColor = Color.LightCyan}
                With item
                    .Translate()
                    .lblCourse.Text = .Sadamine
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = SadamineUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Tsuchisaka
            TsuchisakaOB = GetTimeResult(_filename, 684)
            TsuchisakaIB = GetTimeResult(_filename, 688)
            If Not TsuchisakaOB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 684, True), .BackColor = Color.LightPink}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsuchisaka
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsuchisakaOB
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsuchisakaIB = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 688, True), .BackColor = Color.LightPink}
                With item
                    .Translate()
                    .lblCourse.Text = .Tsuchisaka
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsuchisakaIB
                End With
                flPanel.Controls.Add(item)
            End If

            'AkinaSnow
            AkinaSnowDH = GetTimeResult(_filename, 692)
            AkinaSnowUH = GetTimeResult(_filename, 696)
            If Not AkinaSnowDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 692, True), .BackColor = Color.White}
                With item
                    .Translate()
                    .lblCourse.Text = .AkinaSnow
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Snow
                    .lblTime.Text = AkinaSnowDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaSnowUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 696, True), .BackColor = Color.White}
                With item
                    .Translate()
                    .lblCourse.Text = .AkinaSnow
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Snow
                    .lblTime.Text = AkinaSnowUH
                End With
                flPanel.Controls.Add(item)
            End If

            'Nanamagari
            NanamagariDH = GetTimeResult(_filename, 716)
            NanamagariUH = GetTimeResult(_filename, 720)
            If Not NanamagariDH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 716, True), .BackColor = Color.Silver}
                With item
                    .Translate()
                    .lblCourse.Text = .Nanamagari
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NanamagariDH
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NanamagariUH = NoRecord Then
                item = New TimeAttack() With {.Version = _version, .FileName = _filename, .Score = GetTimeResult(_filename, 720, True), .BackColor = Color.Silver}
                With item
                    .Translate()
                    .lblCourse.Text = .Nanamagari
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NanamagariUH
                End With
                flPanel.Controls.Add(item)
            End If
        End If
    End Sub

    Private Sub Translate()
        Select Case My.Settings.Language
            Case "English"
                Me.Text = "Time Attack Result"
            Case "Chinese"
                Me.Text = "時間挑戰成就"
            Case "French"
                Me.Text = "Résultat Time Attack"
        End Select
    End Sub
End Class