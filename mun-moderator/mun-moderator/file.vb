Public MustInherit Class file
    Friend name As String
    Friend sponsors As ArrayList = New ArrayList
End Class
Public Class Amendment
    Inherits file
    Friend unfriendly As Boolean
    Friend Function number() As Byte
        Return sponsors.Count
    End Function
End Class
Public Class Resolution
    Inherits file
    Friend signatories As ArrayList
    Friend Function number() As Byte
        Return (sponsors.Count + signatories.Count)
    End Function
End Class
