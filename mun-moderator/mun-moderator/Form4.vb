Public Class Form4

    Private Sub Form4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.PageUp)
                With richtextbox1
                    Font = New System.Drawing.Font(Font.Name, Font.Size + 4)
                End With
            Case Chr(Keys.PageDown)
                With richtextbox1
                    Font = New System.Drawing.Font(Font.Name, Font.Size - 4)
                End With
        End Select
    End Sub
    Private Sub Form4_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        size()
    End Sub
    Private Shadows Sub size()
        RichTextBox1.Width = Me.Width - 40
        RichTextBox1.Height = Me.Height - 62
    End Sub

    Private Sub richrichtextbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        RichTextBox1.SelectAll()
        If e.Control Then
            Select Case e.KeyValue
                Case Keys.L
                    RichTextBox1.SelectionFont = New System.Drawing.Font(RichTextBox1.SelectionFont.Name, RichTextBox1.SelectionFont.Size + 4)
                    size()
                Case Keys.S
                    RichTextBox1.SelectionFont = New System.Drawing.Font(RichTextBox1.SelectionFont.Name, RichTextBox1.SelectionFont.Size - 4)
                    size()
            End Select
        End If
        RichTextBox1.SelectionLength = 0
    End Sub
End Class