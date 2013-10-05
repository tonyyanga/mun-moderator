Public MustInherit Class country
    Friend countryform As Form2 = New Form2
    Friend ordered As Boolean
    Friend note As String = ""
    Private toclose As Boolean = False
    Friend Sub Init()
        If ordered Then countryform.ListBox2.Sorted = False Else countryform.ListBox2.Sorted = True
        countryform.Label1.Text = note
        AddHandler countryform.Finish, AddressOf save
        AddHandler countryform.Quit, AddressOf quit
        AddHandler countryform.FormClosing, AddressOf closing
        countryform.Show()
    End Sub
    Friend Sub init2()
        countryform.ListBox1.Items.AddRange(New Object() {"Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Republic", "Chad", "Chile", "China, People's Republic of", "Colombia", "Comoros", "Congo, Democratic Republic of", "Congo, Republic of", "Costa Rica", "Côte d’Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, Democratic People's Republic", "Korea, Republic of", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macedonia, Former Yugoslav Republic of", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia, Federated States of", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russian Federation", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "St. Vincent and the Grenadines", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States of America", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Viet Nam", "Yemen", "Zambia", "Zimbabwe"})
    End Sub
    Private Sub quit()
        countryform.Close()
        toclose = True
    End Sub
    Private Sub closing()
        If toclose = False Then countryform.Show()
    End Sub
    MustOverride Sub save()
End Class
Public Class country_general
    Inherits country
    
    Overrides Sub save()
        For Each obj As String In countryform.ListBox2.Items
            Form1.countries.Add(obj)
        Next
        countryform.Close()
        Form1.Button3.Enabled = False
        Form1.Button4.Enabled = True
    End Sub
End Class
Public Class country_select
    Inherits country
    Friend selected As ArrayList = New ArrayList
    Overrides Sub save()
        For Each obj As String In countryform.ListBox2.Items
            selected.Add(obj)
        Next
        RaiseEvent finish()
        countryform.Close()
    End Sub
    Event finish()
End Class
Public Class rollcall
    Inherits country
    Friend Overloads Sub init2()
        AddHandler countryform.Change, AddressOf itemchange
        For Each obj As String In Form1.countries
            countryform.ListBox1.Items.Add(obj)
        Next
    End Sub
    Public Overrides Sub save()
        Form1.countries = Nothing
        For Each obj As String In countryform.ListBox2.Items
            Form1.countries.Add(obj)
        Next
    End Sub
    Private Sub itemchange()

        Form4.RichTextBox1.Text = "Committee " + Form1.committee + " " + Form1.session + System.Environment.NewLine + Form1.topic + System.Environment.NewLine + System.Environment.NewLine + "Roll Call"
        Dim i As Integer, length As Integer = 0, length2 As Integer = 0
        For i = 0 To countryform.ListBox2.Items.Count - 1
            Form4.RichTextBox1.Text = Form4.RichTextBox1.Text + System.Environment.NewLine + countryform.ListBox2.Items(i).ToString
        Next
        For i = 0 To countryform.ListBox1.Items.Count - 1
            Form4.RichTextBox1.Text = Form4.RichTextBox1.Text + System.Environment.NewLine + countryform.ListBox1.Items(i).ToString
        Next
        For i = 0 To 3
            length += Form4.RichTextBox1.Lines(i).Length
        Next
        Form4.RichTextBox1.SelectionStart = 0
        Form4.RichTextBox1.SelectionLength = length + 3
        Form4.RichTextBox1.SelectionFont = New System.Drawing.Font(Form4.RichTextBox1.SelectionFont.Name, Form4.RichTextBox1.SelectionFont.Size, FontStyle.Bold)
        Form4.RichTextBox1.SelectionStart = length + 3
        For i = 4 To countryform.ListBox2.Items.Count + 3
            length2 += Form4.RichTextBox1.Lines(i).Length
        Next
        length2 += countryform.ListBox2.Items.Count
        Form4.RichTextBox1.SelectionLength = length2
        Form4.RichTextBox1.SelectionColor = Color.Green
        Form4.RichTextBox1.SelectionStart = length + length2 + 3
        For i = countryform.ListBox2.Items.Count + 3 To Form4.RichTextBox1.Lines.Count - 1
            length += Form4.RichTextBox1.Lines(i).Length
        Next
        Form4.RichTextBox1.SelectionLength = length
        Form4.RichTextBox1.SelectionColor = Color.Red
        Form4.RichTextBox1.SelectionLength = 0


    End Sub
End Class
