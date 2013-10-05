Public Class Form1
    Public committee As String
    Public topic As String
    Public session As String
    Public countries As ArrayList = New ArrayList
    Public amendment As ArrayList = New ArrayList
    Public resolutions As ArrayList = New ArrayList
    Public Const Title As String = "Model UN moderator"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
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

        Form4.RichTextBox1.Text = "Committee " + committee + " " + session + System.Environment.NewLine + topic + System.Environment.NewLine + System.Environment.NewLine + "Roll Call"
        Dim i As Integer, length As Integer = 0
        For i = 0 To countries.Count - 1
            Form4.RichTextBox1.Text = Form4.RichTextBox1.Text + System.Environment.NewLine + countries.Item(i).ToString
        Next
        For i = 0 To 3
            length += Form4.RichTextBox1.Lines(i).Length
        Next
        Form4.RichTextBox1.SelectionStart = 0
        Form4.RichTextBox1.SelectionLength = length + 3
        Form4.RichTextBox1.SelectionFont = New System.Drawing.Font(Form4.RichTextBox1.SelectionFont.Name, Form4.RichTextBox1.SelectionFont.Size + 3, FontStyle.Bold)
        Form4.RichTextBox1.SelectionStart = length + 3
        For i = 4 To Form4.RichTextBox1.Lines.Count - 1
            length += Form4.RichTextBox1.Lines(i).Length
        Next
        Form4.RichTextBox1.SelectionLength = length
        Form4.RichTextBox1.SelectionColor = Color.Red
        Form4.RichTextBox1.SelectionLength = 0
        Dim Crollcall As rollcall = New rollcall
        Crollcall.note = "Double click to confirm the presence of a country."
        Crollcall.ordered = False
        Crollcall.init2()
        Crollcall.Init()
    End Sub
End Class
