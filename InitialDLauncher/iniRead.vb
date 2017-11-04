Option Strict Off
Option Explicit On
Module INIread

    Public Function ReadIniValue(ByRef INIpath As String, ByRef KEY As String, ByRef Variable As String) As String
        Dim NF As Short
        Dim Temp As String
        Dim LcaseTemp As String
        Dim ReadyToRead As Boolean

AssignVariables:
        NF = FreeFile()
        ReadIniValue = ""
        KEY = "[" & LCase(KEY) & "]"
        Variable = LCase(Variable)

EnsureFileExists:
        FileOpen(NF, INIpath, OpenMode.Binary)
        FileClose(NF)
        SetAttr(INIpath, FileAttribute.Archive)

LoadFile:
        FileOpen(NF, INIpath, OpenMode.Input)
        While Not EOF(NF)
            Temp = LineInput(NF)
            LcaseTemp = LCase(Temp)
            If InStr(LcaseTemp, "[") <> 0 Then ReadyToRead = False
            If LcaseTemp = KEY Then ReadyToRead = True
            If InStr(LcaseTemp, "[") = 0 And ReadyToRead = True Then
                If InStr(LcaseTemp, Variable & "=") = 1 Then
                    ReadIniValue = Mid(Temp, 1 + Len(Variable & "="))
                    FileClose(NF) : Exit Function
                End If
            End If
        End While
        FileClose(NF)
    End Function
End Module

Module INIwrite

    Public Sub WriteIniValue(ByRef INIpath As String, ByRef PutKey As String, ByRef PutVariable As String, ByRef PutValue As String)
        Dim Temp As String
        Dim LcaseTemp As String
        Dim ReadKey As String
        Dim ReadVariable As String
        Dim LOKEY As Short
        Dim HIKEY As Short
        Dim KEYLEN As Short
        Dim VAR As Short
        Dim VARENDOFLINE As Short
        Dim NF As Short

AssignVariables:
        NF = FreeFile()
        ReadKey = vbCrLf & "[" & LCase(PutKey) & "]" & Chr(13)
        KEYLEN = Len(ReadKey)
        ReadVariable = Chr(10) & LCase(PutVariable) & "="

EnsureFileExists:
        FileOpen(NF, INIpath, OpenMode.Binary)
        FileClose(NF)
        SetAttr(INIpath, FileAttribute.Archive)

LoadFile:
        FileOpen(NF, INIpath, OpenMode.Input)
        Temp = InputString(NF, LOF(NF))
        Temp = vbCrLf & Temp & "[]"
        FileClose(NF)
        LcaseTemp = LCase(Temp)

LogicMenu:
        LOKEY = InStr(LcaseTemp, ReadKey)
        If LOKEY = 0 Then GoTo AddKey
        HIKEY = InStr(LOKEY + KEYLEN, LcaseTemp, "[")
        VAR = InStr(LOKEY, LcaseTemp, ReadVariable)
        If VAR > HIKEY Or VAR < LOKEY Then GoTo AddVariable
        GoTo RenewVariable

AddKey:
        Temp = Left(Temp, Len(Temp) - 2)
        Temp = Temp & vbCrLf & vbCrLf & "[" & PutKey & "]" & vbCrLf & PutVariable & "=" & PutValue
        GoTo TrimFinalString

AddVariable:
        Temp = Left(Temp, Len(Temp) - 2)
        Temp = Left(Temp, LOKEY + KEYLEN) & PutVariable & "=" & PutValue & vbCrLf & Mid(Temp, LOKEY + KEYLEN + 1)
        GoTo TrimFinalString

RenewVariable:
        Temp = Left(Temp, Len(Temp) - 2)
        VARENDOFLINE = InStr(VAR, Temp, Chr(13))
        Temp = Left(Temp, VAR) & PutVariable & "=" & PutValue & Mid(Temp, VARENDOFLINE)
        GoTo TrimFinalString

TrimFinalString:
        Temp = Mid(Temp, 2)
        Do Until InStr(Temp, vbCrLf & vbCrLf & vbCrLf) = 0
            Temp = Replace(Temp, vbCrLf & vbCrLf & vbCrLf, vbCrLf & vbCrLf)
        Loop

        Do Until Right(Temp, 1) > Chr(13)
            Temp = Left(Temp, Len(Temp) - 1)
        Loop

        Do Until Left(Temp, 1) > Chr(13)
            Temp = Mid(Temp, 2)
        Loop

OutputAmendedINIFile:
        FileOpen(NF, INIpath, OpenMode.Output)
        PrintLine(NF, Temp)
        FileClose(NF)

    End Sub
End Module