Public Class frmTimeAttack

    Dim LakeAkinaDryCC, LakeAkinaDryC, LakeAkinaWetCC, LakeAkinaWetC, MyogiDryUH, MyogiDryDH, MyogiWetUH, MyogiWetDH, UsuiDryCC, UsuiDryC, UsuiWetCC, UsuiWetC,
        AkagiDryUH, AkagiDryDH, AkagiWetUH, AkagiWetDH, AkinaDryUH, AkinaDryDH, AkinaWetUH, AkinaWetDH, IrohazkaDryR, IrohazkaDryDH, IrohazkaWetR, IrohazkaWetDH,
        HappogaharaDryIB, HappogaharaDryOB, HappogaharaWetIB, HappogaharaWetOB, NagaoDryUH, NagaoDryDH, NagaoWetUH, NagaoWetDH, TsukubaDryIB, TsukubaDryOB, TsukubaWetIB, TsukubaWetOB,
        TsubakiLineDryUH, TsubakiLineDryDH, TsubakiLineWetUH, TsubakiLineWetDH, NanamagariDryUH, NanamagariDryDH, NanamagariWetUH, NanamagariWetDH,
        SadamineDryUH, SadamineDryDH, SadamineWetUH, SadamineWetDH, TsuchisakaDryIB, TsuchisakaDryOB, TsuchisakaWetIB, TsuchisakaWetOB, AkinaSnowUH, AkinaSnowDH As String

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
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = LakeAkinaDryCC
                    .Score = GetTimeResult(_filename, 588, True)
                    .BackColor = Color.LightBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaWetCC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = LakeAkinaWetCC
                    .Score = GetTimeResult(_filename, 592, True)
                    .BackColor = Color.LightBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaDryC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = LakeAkinaDryC
                    .Score = GetTimeResult(_filename, 596, True)
                    .BackColor = Color.LightBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not LakeAkinaWetC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .LakeAkina
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = LakeAkinaWetC
                    .Score = GetTimeResult(_filename, 600, True)
                    .BackColor = Color.LightBlue
                End With
                flPanel.Controls.Add(item)
            End If

            'Myogi
            MyogiDryDH = GetTimeResult(_filename, 604)
            MyogiWetDH = GetTimeResult(_filename, 608)
            MyogiDryUH = GetTimeResult(_filename, 612)
            MyogiWetUH = GetTimeResult(_filename, 616)
            If Not MyogiDryDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = MyogiDryDH
                    .Score = GetTimeResult(_filename, 604, True)
                    .BackColor = Color.LightCoral
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiWetDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = MyogiWetDH
                    .Score = GetTimeResult(_filename, 608, True)
                    .BackColor = Color.LightCoral
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiDryUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = MyogiDryUH
                    .Score = GetTimeResult(_filename, 612, True)
                    .BackColor = Color.LightCoral
                End With
                flPanel.Controls.Add(item)
            End If
            If Not MyogiWetUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Myogi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = MyogiWetUH
                    .Score = GetTimeResult(_filename, 616, True)
                    .BackColor = Color.LightCoral
                End With
                flPanel.Controls.Add(item)
            End If

            'Akagi
            AkagiDryDH = GetTimeResult(_filename, 620)
            AkagiWetDH = GetTimeResult(_filename, 624)
            AkagiDryUH = GetTimeResult(_filename, 628)
            AkagiWetUH = GetTimeResult(_filename, 632)
            If Not AkagiDryDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkagiDryDH
                    .Score = GetTimeResult(_filename, 620, True)
                    .BackColor = Color.LightSkyBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiWetDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkagiWetDH
                    .Score = GetTimeResult(_filename, 624, True)
                    .BackColor = Color.LightSkyBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiDryUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkagiDryUH
                    .Score = GetTimeResult(_filename, 628, True)
                    .BackColor = Color.LightSkyBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkagiWetUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akagi
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkagiWetUH
                    .Score = GetTimeResult(_filename, 632, True)
                    .BackColor = Color.LightSkyBlue
                End With
                flPanel.Controls.Add(item)
            End If

            'Akina
            AkinaDryDH = GetTimeResult(_filename, 636)
            AkinaWetDH = GetTimeResult(_filename, 640)
            AkinaDryUH = GetTimeResult(_filename, 644)
            AkinaWetUH = GetTimeResult(_filename, 648)
            If Not AkinaDryDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkinaDryDH
                    .Score = GetTimeResult(_filename, 636, True)
                    .BackColor = Color.LightGreen
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaWetDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkinaWetDH
                    .Score = GetTimeResult(_filename, 640, True)
                    .BackColor = Color.LightGreen
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaDryUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = AkinaDryUH
                    .Score = GetTimeResult(_filename, 644, True)
                    .BackColor = Color.LightGreen
                End With
                flPanel.Controls.Add(item)
            End If
            If Not AkinaWetUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Akina
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = AkinaWetUH
                    .Score = GetTimeResult(_filename, 648, True)
                    .BackColor = Color.LightGreen
                End With
                flPanel.Controls.Add(item)
            End If

            'Irohazaka
            IrohazkaDryDH = GetTimeResult(_filename, 652)
            IrohazkaWetDH = GetTimeResult(_filename, 656)
            IrohazkaDryR = GetTimeResult(_filename, 660)
            IrohazkaWetR = GetTimeResult(_filename, 664)
            If Not IrohazkaDryDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = IrohazkaDryDH
                    .Score = GetTimeResult(_filename, 652, True)
                    .BackColor = Color.LightSalmon
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaWetDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = IrohazkaWetDH
                    .Score = GetTimeResult(_filename, 656, True)
                    .BackColor = Color.LightSalmon
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaDryR = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Reversed
                    .lblWeather.Text = .Dry
                    .lblTime.Text = IrohazkaDryR
                    .Score = GetTimeResult(_filename, 660, True)
                    .BackColor = Color.LightSalmon
                End With
                flPanel.Controls.Add(item)
            End If
            If Not IrohazkaWetR = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Irohazka
                    .lblType.Text = .Reversed
                    .lblWeather.Text = .Wet
                    .lblTime.Text = IrohazkaWetR
                    .Score = GetTimeResult(_filename, 664, True)
                    .BackColor = Color.LightSalmon
                End With
                flPanel.Controls.Add(item)
            End If

            'Tsukuba
            TsukubaDryOB = GetTimeResult(_filename, 668)
            TsukubaWetOB = GetTimeResult(_filename, 672)
            TsukubaDryIB = GetTimeResult(_filename, 676)
            TsukubaWetIB = GetTimeResult(_filename, 680)
            If Not TsukubaDryOB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsukubaDryOB
                    .Score = GetTimeResult(_filename, 668, True)
                    .BackColor = Color.LightGoldenrodYellow
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaWetOB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsukubaWetOB
                    .Score = GetTimeResult(_filename, 672, True)
                    .BackColor = Color.LightGoldenrodYellow
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaDryIB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsukubaDryIB
                    .Score = GetTimeResult(_filename, 676, True)
                    .BackColor = Color.LightGoldenrodYellow
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsukubaWetIB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Tsukuba
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsukubaWetIB
                    .Score = GetTimeResult(_filename, 680, True)
                    .BackColor = Color.LightGoldenrodYellow
                End With
                flPanel.Controls.Add(item)
            End If

            'Happogahara
            HappogaharaDryOB = GetTimeResult(_filename, 684)
            HappogaharaWetOB = GetTimeResult(_filename, 688)
            HappogaharaDryIB = GetTimeResult(_filename, 692)
            HappogaharaWetIB = GetTimeResult(_filename, 696)
            If Not HappogaharaDryOB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = HappogaharaDryOB
                    .Score = GetTimeResult(_filename, 684, True)
                    .BackColor = Color.LightSlateGray
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaWetOB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Outbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = HappogaharaWetOB
                    .Score = GetTimeResult(_filename, 688, True)
                    .BackColor = Color.LightSlateGray
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaDryIB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Dry
                    .lblTime.Text = HappogaharaDryIB
                    .Score = GetTimeResult(_filename, 692, True)
                    .BackColor = Color.LightSlateGray
                End With
                flPanel.Controls.Add(item)
            End If
            If Not HappogaharaWetIB = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Happogahara
                    .lblType.Text = .Inbound
                    .lblWeather.Text = .Wet
                    .lblTime.Text = HappogaharaWetIB
                    .Score = GetTimeResult(_filename, 696, True)
                    .BackColor = Color.LightSlateGray
                End With
                flPanel.Controls.Add(item)
            End If

            'Nagao
            NagaoDryDH = GetTimeResult(_filename, 700)
            NagaoWetDH = GetTimeResult(_filename, 704)
            NagaoDryUH = GetTimeResult(_filename, 708)
            NagaoWetUH = GetTimeResult(_filename, 712)
            If Not NagaoDryDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NagaoDryDH
                    .Score = GetTimeResult(_filename, 700, True)
                    .BackColor = Color.LightYellow
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoWetDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = NagaoWetDH
                    .Score = GetTimeResult(_filename, 704, True)
                    .BackColor = Color.LightYellow
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoDryUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = NagaoDryUH
                    .Score = GetTimeResult(_filename, 708, True)
                    .BackColor = Color.LightYellow
                End With
                flPanel.Controls.Add(item)
            End If
            If Not NagaoWetUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Nagao
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = NagaoWetUH
                    .Score = GetTimeResult(_filename, 712, True)
                    .BackColor = Color.LightYellow
                End With
                flPanel.Controls.Add(item)
            End If

            'Tsubaki Line
            TsubakiLineDryDH = GetTimeResult(_filename, 716)
            TsubakiLineWetDH = GetTimeResult(_filename, 720)
            TsubakiLineDryUH = GetTimeResult(_filename, 724)
            TsubakiLineWetUH = GetTimeResult(_filename, 728)
            If Not TsubakiLineDryDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsubakiLineDryDH
                    .Score = GetTimeResult(_filename, 716, True)
                    .BackColor = Color.LightSeaGreen
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineWetDH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Downhill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsubakiLineWetDH
                    .Score = GetTimeResult(_filename, 720, True)
                    .BackColor = Color.LightSeaGreen
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineDryUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Dry
                    .lblTime.Text = TsubakiLineDryUH
                    .Score = GetTimeResult(_filename, 724, True)
                    .BackColor = Color.LightSeaGreen
                End With
                flPanel.Controls.Add(item)
            End If
            If Not TsubakiLineWetUH = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .TsubakiLine
                    .lblType.Text = .Uphill
                    .lblWeather.Text = .Wet
                    .lblTime.Text = TsubakiLineWetUH
                    .Score = GetTimeResult(_filename, 728, True)
                    .BackColor = Color.LightSeaGreen
                End With
                flPanel.Controls.Add(item)
            End If

            'Usui
            UsuiDryCC = GetTimeResult(_filename, 732)
            UsuiWetCC = GetTimeResult(_filename, 736)
            UsuiDryC = GetTimeResult(_filename, 740)
            UsuiWetC = GetTimeResult(_filename, 744)
            If Not UsuiDryCC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = UsuiDryCC
                    .Score = GetTimeResult(_filename, 732, True)
                    .BackColor = Color.LightSteelBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiWetCC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Counterclockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = UsuiWetCC
                    .Score = GetTimeResult(_filename, 736, True)
                    .BackColor = Color.LightSteelBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiDryC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Dry
                    .lblTime.Text = UsuiDryC
                    .Score = GetTimeResult(_filename, 740, True)
                    .BackColor = Color.LightSteelBlue
                End With
                flPanel.Controls.Add(item)
            End If
            If Not UsuiWetC = NoRecord Then
                item = New TimeAttack()
                With item
                    .Version = _version
                    .FileName = _filename
                    .Translate()
                    .lblCourse.Text = .Usui
                    .lblType.Text = .Clockwise
                    .lblWeather.Text = .Wet
                    .lblTime.Text = UsuiWetC
                    .Score = GetTimeResult(_filename, 744, True)
                    .BackColor = Color.LightSteelBlue
                End With
                flPanel.Controls.Add(item)
            End If
        Else


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