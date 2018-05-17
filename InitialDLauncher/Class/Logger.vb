Public NotInheritable Class Logger

    Private Sub New()

    End Sub

    Public Shared Sub Log(message As Object)
        IO.File.AppendAllText(".\InitialDLauncher.log", DateTime.Now & ":" & message & Environment.NewLine)
    End Sub

    Public Shared Sub Write(message As Object)
        IO.File.AppendAllText(".\BennysOriginalMotorworks-" & Now.Month & "-" & Now.Day & "-" & Now.Year & ".txt", message & Environment.NewLine)
    End Sub
End Class