﻿Imports System.Windows.Forms

Module ReadWritingMemory
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer

    Private Declare Function WriteProcessMemory1 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Integer, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
    Private Declare Function WriteProcessMemory2 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Single
    Private Declare Function WriteProcessMemory3 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Long, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Long

    Private Declare Function ReadProcessMemory1 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Integer, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
    Private Declare Function ReadProcessMemory2 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Single
    Private Declare Function ReadProcessMemory3 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Long, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Long

    Const PROCESS_ALL_ACCESS = &H1F0FF

    Public Function WriteDMAInteger(ByVal Process As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Value As Integer, ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Boolean
        Try
            Dim lvl As Integer = Address
            For i As Integer = 1 To Level
                lvl = ReadInteger(Process, lvl, nsize) + Offsets(i - 1)
            Next
            WriteInteger(Process, lvl, Value, nsize)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ReadDMAInteger(ByVal Process As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Integer
        Try
            Dim lvl As Integer = Address
            For i As Integer = 1 To Level
                lvl = ReadInteger(Process, lvl, nsize) + Offsets(i - 1)
            Next
            Dim vBuffer As Integer
            vBuffer = ReadInteger(Process, lvl, nsize)
            Return vBuffer
        Catch ex As Exception

        End Try
    End Function

    Public Function WriteDMAFloat(ByVal Process As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Value As Single, ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Boolean
        Try
            Dim lvl As Integer = Address
            For i As Integer = 1 To Level
                lvl = ReadFloat(Process, lvl, nsize) + Offsets(i - 1)
            Next
            WriteFloat(Process, lvl, Value, nsize)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ReadDMAFloat(ByVal Process As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Single
        Try
            Dim lvl As Integer = Address
            For i As Integer = 1 To Level
                lvl = ReadFloat(Process, lvl, nsize) + Offsets(i - 1)
            Next
            Dim vBuffer As Single
            vBuffer = ReadFloat(Process, lvl, nsize)
            Return vBuffer
        Catch ex As Exception

        End Try
    End Function

    Public Function WriteDMALong(ByVal Process As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Value As Long, ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Boolean
        Try
            Dim lvl As Integer = Address
            For i As Integer = 1 To Level
                lvl = ReadLong(Process, lvl, nsize) + Offsets(i - 1)
            Next
            WriteLong(Process, lvl, Value, nsize)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ReadDMALong(ByVal Process As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Long
        Try
            Dim lvl As Integer = Address
            For i As Integer = 1 To Level
                lvl = ReadLong(Process, lvl, nsize) + Offsets(i - 1)
            Next
            Dim vBuffer As Long
            vBuffer = ReadLong(Process, lvl, nsize)
            Return vBuffer
        Catch ex As Exception

        End Try
    End Function

    Public Sub WriteNOPs(ByVal ProcessName As String, ByVal Address As Long, ByVal NOPNum As Integer)
        Dim C As Integer
        Dim B As Integer
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Sub
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Sub
        End If

        B = 0
        For C = 1 To NOPNum
            Call WriteProcessMemory1(hProcess, Address + B, &H90, 1, 0&)
            B = B + 1
        Next C
    End Sub

    Public Sub WriteXBytes(ByVal ProcessName As String, ByVal Address As Long, ByVal Value As String)
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Sub
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Sub
        End If

        Dim C As Integer
        Dim B As Integer
        Dim D As Integer
        Dim V As Byte

        B = 0
        D = 1
        For C = 1 To Math.Round((Len(Value) / 2))
            V = Val("&H" & Mid$(Value, D, 2))
            Call WriteProcessMemory1(hProcess, Address + B, V, 1, 0&)
            B = B + 1
            D = D + 2
        Next C

    End Sub

    Public Sub WriteInteger(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Integer, Optional ByVal nsize As Integer = 4)
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            Dim result As String = MessageBox.Show(ProcessName & " is not running!", "Error", MessageBoxButtons.AbortRetryIgnore)
            If result = vbAbort Then
                Exit Sub
            ElseIf result = vbRetry Then
                MsgBox("Retry")
            ElseIf result = vbIgnore Then
                MsgBox("Ignore")
            End If
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Sub
        End If

        Dim hAddress, vBuffer As Integer
        hAddress = Address
        vBuffer = Value
        WriteProcessMemory1(hProcess, hAddress, CInt(vBuffer), nsize, 0)
    End Sub

    Public Sub WriteFloat(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Single, Optional ByVal nsize As Integer = 4)
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Sub
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Sub
        End If

        Dim hAddress As Integer
        Dim vBuffer As Single

        hAddress = Address
        vBuffer = Value
        WriteProcessMemory2(hProcess, hAddress, vBuffer, nsize, 0)
    End Sub

    Public Sub WriteLong(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Long, Optional ByVal nsize As Integer = 4)
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Sub
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Sub
        End If

        Dim hAddress As Integer
        Dim vBuffer As Long

        hAddress = Address
        vBuffer = Value
        WriteProcessMemory3(hProcess, hAddress, vBuffer, nsize, 0)
    End Sub

    Public Function ReadInteger(ByVal ProcessName As String, ByVal Address As Integer, Optional ByVal nsize As Integer = 4) As Integer
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Function
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Function
        End If

        Dim hAddress, vBuffer As Integer
        hAddress = Address
        ReadProcessMemory1(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function ReadFloat(ByVal ProcessName As String, ByVal Address As Integer, Optional ByVal nsize As Integer = 4) As Single
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Function
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Function
        End If

        Dim hAddress As Integer
        Dim vBuffer As Single

        hAddress = Address
        ReadProcessMemory2(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function ReadLong(ByVal ProcessName As String, ByVal Address As Integer, Optional ByVal nsize As Integer = 4) As Long
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            MessageBox.Show(ProcessName & " isn't open!")
            Exit Function
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Exit Function
        End If

        Dim hAddress As Integer
        Dim vBuffer As Long

        hAddress = Address
        ReadProcessMemory3(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

End Module