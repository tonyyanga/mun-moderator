Public Class Form3
    Event Save()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent Save()
    End Sub
End Class