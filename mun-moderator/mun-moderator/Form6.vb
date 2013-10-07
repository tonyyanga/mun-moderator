Public Class Form6
    Friend files As ArrayList, fileorder As Byte
    Friend countries As ArrayList, countryorder As Byte
    Dim yes As Byte, no As Byte
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        yes += 1
        check()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "No" Then
            no += 1
            check()
        Else
            Button2.Text = "No"
            fileorder += 1
            If fileorder <= files.Count Then
                Label1.Text = files(fileorder).ToString
                countryorder = 0
                Button1.Visible = True
                Button3.Visible = True
                Label2.Text = countries(countryorder).ToString
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        check()
    End Sub
    Private Sub Calc()
        Button2.Text = "Next"
        Button1.Visible = False
        Button3.Visible = False
        If yes >= 2 / 3 * (yes + no) Then
            Label2.Text = "This file pass!"
        Else
            Label2.Text = "This file fail!"
        End If
    End Sub
    Private Sub check()
        If countryorder >= countries.Count Then
            Calc()
        Else
            countryorder += 1
            Label2.Text = countries(countryorder)
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles Me.Load
        fileorder = 0
        countryorder = 0
        Label1.Text = files(0).ToString
        Label2.Text = countries(0).ToString
    End Sub
End Class