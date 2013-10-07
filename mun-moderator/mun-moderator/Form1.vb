Public Class Form1
    Public committee As String
    Public topic As String
    Public session As String
    Public countries As ArrayList = New ArrayList
    Public amendment As ArrayList = New ArrayList
    Public resolutions As ArrayList = New ArrayList
    Public simplemajority As Byte, absolutemajority As Byte
    Public Const Title As String = "Model UN moderator"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
    End Sub
    Friend Sub Conference_begin()
        Button4.Enabled = False
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        committee = InputBox("Committee Name", Title)
        Button1.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        session = InputBox("Session Information", Title, "Session ")
        topic = InputBox("Topic of the Session", Title)
        Button2.Enabled = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Ccountrylist As country_general = New country_general
        Ccountrylist.note = "Choose the countries who will present."
        Ccountrylist.ordered = False
        Ccountrylist.Init()
        Ccountrylist.init2()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim Caddfile As addfile = New addfile
        Caddfile.Init()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form4.Show()
        Display.Display_list(countries, "Roll Call", Form4)
        Dim Crollcall As rollcall = New rollcall
        Crollcall.note = "Double click to confirm the presence of a country."
        Crollcall.ordered = False
        Crollcall.init2()
        Crollcall.Init()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim CSL As country_select = New country_select
        CSL.note = "Select the countries to add into the GSL."
        CSL.procedure = "General Speakers List"
        CSL.ordered = True
        AddHandler CSL.finish, AddressOf CSL.GSL_Select_Finish
        CSL.Init()
        CSL.init2()
    End Sub
    Sub closedebate()
        
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim CSL As country_select = New country_select
        CSL.note = "Select the countries to add into the list."
        CSL.procedure = "Moderated Caucus"
        CSL.ordered = True
        AddHandler CSL.finish, AddressOf CSL.GSL_Select_Finish
        CSL.Init()
        CSL.init2()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Ctimer As timer = New timer
        Ctimer.type = 2
        Ctimer.total = CInt(InputBox("Total time?", Title))
        Ctimer.note = "Unmoderated Caucus"
        Ctimer.init()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim CSpon As country_select = New country_select
        CSpon.note = "Select the sponsors."
        CSpon.ordered = True
        CSpon.Init()
        CSpon.init2()
        AddHandler CSpon.finish, AddressOf CSpon.WP_Spon_finish
    End Sub
    
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim CSpon As country_select = New country_select
        CSpon.note = "Select the sponsors."
        CSpon.ordered = True
        CSpon.Init()
        CSpon.init2()
        AddHandler CSpon.finish, AddressOf CSpon.Am_Spon_finish
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim CSpon As country_select = New country_select
        CSpon.note = "Select the sponsors."
        CSpon.ordered = True
        CSpon.Init()
        CSpon.init2()
        AddHandler CSpon.finish, AddressOf CSpon.DR_Spon_finish
    End Sub
End Class

Module Display
    Sub Display_list(countrylist As ArrayList, note As String, form As Form4)
        form.Show()
        form.RichTextBox1.Text = ""
        form.RichTextBox1.Text = "Committee " + Form1.committee + " " + Form1.session + System.Environment.NewLine + Form1.topic + System.Environment.NewLine + System.Environment.NewLine + note
        Dim i As Integer, length As Integer = 0
        For i = 0 To countrylist.Count - 1
            form.RichTextBox1.Text = form.RichTextBox1.Text + System.Environment.NewLine + countrylist.Item(i).ToString
        Next
        For i = 0 To 3
            length += form.RichTextBox1.Lines(i).Length
        Next
        form.RichTextBox1.SelectionStart = 0
        form.RichTextBox1.SelectionLength = length + 3
        form.RichTextBox1.SelectionFont = New System.Drawing.Font(form.RichTextBox1.SelectionFont.Name, 15, FontStyle.Bold)
        form.RichTextBox1.SelectionStart = length + 3
        For i = 4 To form.RichTextBox1.Lines.Count - 1
            length += form.RichTextBox1.Lines(i).Length
        Next
        form.RichTextBox1.SelectionLength = length
        form.RichTextBox1.SelectionFont = New System.Drawing.Font(form.RichTextBox1.SelectionFont.Name, 15, FontStyle.Regular)
        form.RichTextBox1.SelectionColor = Color.Red
        form.RichTextBox1.SelectionLength = 0
    End Sub
    Sub Display_Update(Finish As ArrayList, Notfinish As ArrayList, note As String, form As Form4)
        With form.RichTextBox1
            Dim i As Integer, length As Integer = 0, length2 As Integer = 0
            Dim size1 As Integer
            Try
                For i = 0 To 3
                    length += .Lines(i).Length
                Next
                .SelectionStart = 0
                .SelectionLength = length + 3
                size1 = .SelectionFont.Size
                length = 0
            Catch ex As Exception
                size1 = 15
            End Try
            .Text = ""
            .Text = "Committee " + Form1.committee + " " + Form1.session + System.Environment.NewLine + Form1.topic + System.Environment.NewLine + System.Environment.NewLine + note
            For i = 0 To Finish.Count - 1
                .Text = .Text + System.Environment.NewLine + Finish(i).ToString
            Next
            For i = 0 To Notfinish.Count - 1
                .Text = .Text + System.Environment.NewLine + Notfinish(i).ToString
            Next
            For i = 0 To 3
                length += .Lines(i).Length
            Next
            .SelectionStart = 0
            .SelectionLength = length + 3
            .SelectionFont = New System.Drawing.Font(.SelectionFont.Name, size1, FontStyle.Bold)
            .SelectionStart = length + 3
            For i = 4 To Finish.Count + 3
                length2 += .Lines(i).Length
            Next
            length2 += Finish.Count
            .SelectionLength = length2
            .SelectionColor = Color.Green
            .SelectionFont = New System.Drawing.Font(.SelectionFont.Name, size1, FontStyle.Regular)
            .SelectionStart = length + length2 + 3 + 1
            For i = Finish.Count + 4 To .Lines.Count - 1
                length += .Lines(i).Length
            Next
            .SelectionLength = length + Notfinish.Count
            .SelectionColor = Color.Red
            .SelectionFont = New System.Drawing.Font(.SelectionFont.Name, size1, FontStyle.Regular)
            .SelectionLength = 0
        End With
    End Sub
End Module
