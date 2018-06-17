Public Class AudioFile
    '***********************************************************************************************************
    '        Class:  PlayFile
    '   Written By:  Blake Pell (bpell@indiana.edu)
    ' Initial Date:  03/31/2007
    ' Last Updated:  02/04/2009
    '***********************************************************************************************************

    ' Windows API Declarations
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hwndCallback As Int32) As Int32

    ''' <summary>
    ''' Constructor:  Location is the filename of the media to play.  Wave files and Mp3 files are the supported formats.
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal location As String)
        Me.Filename = location
    End Sub

    ''' <summary>
    ''' Plays the file that is specified as the filename.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Play()

        If _filename = "" Or Filename.Length <= 4 Then Exit Sub

        Select Case Right(Filename, 3).ToLower
            Case "mp3"
                mciSendString("open """ & _filename & """ type mpegvideo alias audiofile", Nothing, 0, IntPtr.Zero)

                Dim playCommand As String = "play audiofile repeat from 0"

                If _wait = True Then playCommand += " wait"

                mciSendString(playCommand, Nothing, 0, IntPtr.Zero)
            Case "wav"
                mciSendString("open """ & _filename & """ type waveaudio alias audiofile", Nothing, 0, IntPtr.Zero)
                mciSendString("play audiofile repeat from 0", Nothing, 0, IntPtr.Zero)
            Case "mid", "idi"
                mciSendString("stop midi", "", 0, 0)
                mciSendString("close midi", "", 0, 0)
                mciSendString("open sequencer!" & _filename & " alias midi", "", 0, 0)
                mciSendString("play midi repeat", "", 0, 0)
            Case "wmv", "mp4", "avi"
                mciSendString("open """ & _filename & """ type mpegvideo alias audiofile parent " & _handle & " style child", Nothing, 0, IntPtr.Zero)
                mciSendString("play audiofile repeat", Nothing, 0, IntPtr.Zero)
            Case Else
                Throw New Exception("File type not supported.")
                Call Close()
        End Select

        IsPaused = False

    End Sub

    ''' <summary>
    ''' Pause the current play back.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Pause()
        mciSendString("pause audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = True
    End Sub

    ''' <summary>
    ''' Resume the current play back if it is currently paused.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub [Resume]()
        mciSendString("resume audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = False
    End Sub

    ''' <summary>
    ''' Stop the current file if it's playing.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub [Stop]()
        mciSendString("stop audiofile", Nothing, 0, IntPtr.Zero)
    End Sub

    ''' <summary>
    ''' Close the file.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        mciSendString("close audiofile", Nothing, 0, IntPtr.Zero)
    End Sub

    Public Sub SetVolume(volume As Integer)
        Dim command = "setaudio audiofile volume to " + volume.ToString()
        mciSendString(command, Nothing, 0, IntPtr.Zero)
    End Sub

    Private _wait As Boolean = False
    ''' <summary>
    ''' Halt the program until the .wav file is done playing.  Be careful, this will lock the entire program up until the
    ''' file is done playing.  It behaves as if the Windows Sleep API is called while the file is playing (and maybe it is, I don't
    ''' actually know, I'm just theorizing).  :P
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Wait() As Boolean
        Get
            Return _wait
        End Get
        Set(ByVal value As Boolean)
            _wait = value
        End Set
    End Property

    ''' <summary>
    ''' Sets the audio file's time format via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Milleseconds() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("set audiofile time format milliseconds", Nothing, 0, IntPtr.Zero)
            mciSendString("status audiofile length", buf, 255, IntPtr.Zero)

            buf = Replace(buf, Chr(0), "") ' Get rid of the nulls, they muck things up

            If buf = "" Then
                Return 0
            Else
                Return CInt(buf)
            End If
        End Get
    End Property

    ''' <summary>
    ''' Gets the status of the current playback file via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Status() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile mode", buf, 255, IntPtr.Zero)
            buf = Replace(buf, Chr(0), "")  ' Get rid of the nulls, they muck things up
            Return buf
        End Get
    End Property

    ''' <summary>
    ''' Gets the file size of the current audio file.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FileSize() As Integer
        Get
            Try
                Return My.Computer.FileSystem.GetFileInfo(_filename).Length
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    ''' <summary>
    ''' Gets the channels of the file via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Channels() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            If IsNumeric(buf) = True Then
                Return CInt(buf)
            Else
                Return -1
            End If
        End Get
    End Property

    ''' <summary>
    ''' Used for debugging purposes.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Debug() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            Return Str(buf)
        End Get
    End Property

    Private _isPaused As Boolean = False
    ''' <summary>
    ''' Whether or not the current playback is paused.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsPaused() As Boolean
        Get
            Return _isPaused
        End Get
        Set(ByVal value As Boolean)
            _isPaused = value
        End Set
    End Property

    Private _filename As String
    ''' <summary>
    ''' The current filename of the file that is to be played back.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Filename() As String
        Get
            Return _filename
        End Get
        Set(ByVal value As String)

            If My.Computer.FileSystem.FileExists(value) = False Then
                Throw New System.IO.FileNotFoundException
                Exit Property
            End If

            _filename = value
        End Set
    End Property

    Private _handle As Int32
    Public Property Handle() As Int32
        Get
            Return _handle
        End Get
        Set(value As Int32)
            _handle = value
        End Set
    End Property

    Public Sub SizeVideoWindow(maxSize As Size, ignoreAspectRatio As Boolean)

        Dim ActualMovieSize As Size = getDefaultSize()
        Dim AspectRatio As Single = ActualMovieSize.Width / ActualMovieSize.Height

        Dim iLeft As Integer = 0
        Dim iTop As Integer = 0

        Dim newWidth As Integer = maxSize.Width
        Dim newHeight As Integer = newWidth \ AspectRatio

        If newHeight > maxSize.Height Then

            newHeight = maxSize.Height
            newWidth = newHeight * AspectRatio
            iLeft = (maxSize.Width - newWidth) \ 2

        Else

            iTop = (maxSize.Height - newHeight) \ 2

        End If

        If ignoreAspectRatio Then
            mciSendString("put audiofile window at 0 0 " & maxSize.Width & " " & maxSize.Height, 0, 0, 0)
        Else
            mciSendString("put audiofile window at " & iLeft & " " & iTop & " " & newWidth & " " & newHeight, 0, 0, 0)
        End If


    End Sub

    Public Function getDefaultSize() As Size
        'Returns the default width, height the movie
        Dim c_Data As String = Space(128)
        mciSendString("where audiofile source", c_Data, 128, 0)
        Dim parts() As String = Split(c_Data, " ")

        Return New Size(CInt(parts(2)), CInt(parts(3)))
    End Function
End Class
