Public Class Form2

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedItems.Count > 0 Then

            If ListBox2.Items.Contains(ListBox1.SelectedItem) Then Exit Sub

            ListBox2.Items.Add(ListBox1.SelectedItem)

            ListBox1.Items.Remove(ListBox1.SelectedItem)
            RaiseEvent Change()
        End If
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        If ListBox2.SelectedItems.Count > 0 Then

            If ListBox1.Items.Contains(ListBox2.SelectedItem) Then Exit Sub

            ListBox1.Items.Add(ListBox2.SelectedItem)

            ListBox2.Items.Remove(ListBox2.SelectedItem)
            RaiseEvent Change()
        End If
    End Sub
    Friend Event Finish()
    Friend Event Quit()
    Friend Event Change()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent Finish()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RaiseEvent Quit()
    End Sub
   
    Private Sub ListBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListBox1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then RaiseEvent Finish()
    End Sub

    Private Sub ListBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListBox2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then RaiseEvent Finish()
    End Sub

End Class