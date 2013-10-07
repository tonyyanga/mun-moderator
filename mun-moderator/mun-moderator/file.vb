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
Public Class Voting
    Inherits country
    Friend Overrides Sub init2()
        For Each obj As Amendment In Form1.amendment
            countryform.ListBox1.Items.Add(obj.name)
        Next
        For Each obj As Resolution In Form1.resolutions
            countryform.ListBox1.Items.Add(obj.name)
        Next
    End Sub
    Public Overrides Sub save()
        Dim Form As Form6 = New Form6
        Form.files = New ArrayList(countryform.ListBox2.Items)
        Form.countries = Form1.countries
        Form.Show()
    End Sub
End Class
