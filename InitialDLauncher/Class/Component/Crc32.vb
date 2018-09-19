Imports Crc

Public Class Crc32
    Inherits Crc32Base

    Public Sub New()
        MyBase.New(&H4C11DB7, &HFFFFFFFFL, &HFFFFFFFFL, True, True)
    End Sub
End Class
