Public MustInherit Class country
    Friend countryform As Form2 = New Form2
    Friend ordered As Boolean
    Friend note As String = ""
    Private toclose As Boolean = False
    Sub close()
        countryform.Close()
        Me.Finalize()
    End Sub
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
    Friend Ctimer As timer = New timer
    Friend form As New Form4
    Friend procedure As String
    Friend sponsors As ArrayList = New ArrayList
    Overrides Sub save()
        For Each obj As String In countryform.ListBox2.Items
            selected.Add(obj)
        Next
        RaiseEvent finish()
        countryform.Close()
    End Sub
    Sub GSL_Select_Finish()
        Dim CSL As SL_Apprehend = New SL_Apprehend
        CSL.note = "Select the countries to apprehend into the list."
        CSL.ordered = True
        CSL.Ctimer = Ctimer
        CSL.procedure = procedure
        CSL.form = form
        CSL.sender = Me
        AddHandler CSL.finish, AddressOf CSL.GSL_Select_Apprehend
        CSL.Init()
        CSL.init2()
        Ctimer = New timer
        Display_list(selected, procedure, form)
        Ctimer.list = selected
        Select Case procedure
            Case "General Speakers List"
                Ctimer.speaker = CInt(InputBox("Time for each speaker?"))
                Ctimer.type = 0
                AddHandler Ctimer.nextspeaker, AddressOf GSL_next
                AddHandler Ctimer.finish, AddressOf GSL_Finish
            Case "Moderated Caucus"
                Ctimer.total = CInt(InputBox("Total time?"))
                Ctimer.speaker = CInt(InputBox("Time for each speaker?"))
                Ctimer.type = 1
                AddHandler Ctimer.nextspeaker, AddressOf MC_next
                AddHandler Ctimer.finish, AddressOf MC_Finish
        End Select

       
        Ctimer.init()
    End Sub
    Sub GSL_next()
        Ctimer.finished.Add(Ctimer.todo.Item(0))
        Ctimer.todo.RemoveAt(0)
        Display_Update(Ctimer.finished, Ctimer.todo, procedure, form)
        If Ctimer.todo.Count > 0 Then
            Ctimer.note = Ctimer.todo(0).ToString
            ordered += 1
        Else
            Ctimer.note = "End of the list"
            If MsgBox("The GSL is end. Close debate?", vbOKCancel, Form1.Title) = MsgBoxResult.Ok Then GSL_Finish()
        End If
    End Sub
    Sub GSL_Finish()
        Ctimer.Close()
        Form1.closedebate()
    End Sub
    Sub MC_next()
        Ctimer.finished.Add(Ctimer.todo.Item(0))
        Ctimer.todo.RemoveAt(0)
        Display_Update(Ctimer.finished, Ctimer.todo, procedure, form)
        If Ctimer.todo.Count > 0 Then
            Ctimer.note = Ctimer.todo(0).ToString
            ordered += 1
        Else
            Ctimer.note = "End of the list"
            If CInt(Form5.Label4.Text) < Ctimer.speaker Then MC_Finish()
            If MsgBox("The List is end. End the caucus?", vbOKCancel, Form1.Title) = MsgBoxResult.Ok Then MC_Finish()
        End If
    End Sub
    Sub MC_Finish()
        Ctimer.Close()
    End Sub
    Friend Overloads Sub init2()
        For Each obj As String In Form1.countries
            countryform.ListBox1.Items.Add(obj)
        Next
    End Sub
    Sub WP_Spon_finish()
        Display_list(selected, "Introduce " & InputBox("Name of the working paper?", Form1.Title, "Working Paper "), form)
        Ctimer.note = "Introduce WP"
        Ctimer.type = 2
        Ctimer.total = CInt(InputBox("Total time?", Form1.Title))
        Ctimer.init()
    End Sub
    Sub Am_Spon_finish()
        Dim am As Amendment = New Amendment
        am.sponsors = selected
        am.unfriendly = IIf(MsgBox("Friendly?", vbYesNo, Form1.Title), MsgBoxResult.No, MsgBoxResult.Yes)
        If am.unfriendly Then
            Display_list(selected, "Introduce " & InputBox("Name of the amendment?", Form1.Title, "Amendment "), form)
            Ctimer.note = "Introduce Amendment"
            Ctimer.type = 2
            Ctimer.total = CInt(InputBox("Total time?", Form1.Title))
            Ctimer.init()
        End If
        Form1.amendment.Add(am)
    End Sub
    Sub DR_Spon_finish()
        Dim CDR_Sign As DR_Sign = New DR_Sign
        CDR_Sign.sender = Me
        CDR_Sign.note = "Select signatories"
        CDR_Sign.ordered = False
        AddHandler CDR_Sign.finish, AddressOf CDR_Sign.DR_Sign_finish
    End Sub
    Event finish()
End Class
Class DR_Sign
    Inherits country_select
    Friend sender As country_select
    Sub DR_Sign_finish()
        Dim dr As Resolution = New Resolution
        dr.signatories = selected
        dr.sponsors = sender.selected
        Display_list(selected, "Introduce " & InputBox("Name of the resolution?", Form1.Title, "Draft Resolution "), form)
        Ctimer.note = "Introduce Draft Resolution"
        Ctimer.type = 2
        Ctimer.total = CInt(InputBox("Total time?", Form1.Title))
        Ctimer.init()
        Form1.resolutions.Add(dr)
    End Sub
End Class
Class SL_Apprehend
    Inherits country_select
    Friend sender As country_select
    Sub GSL_Select_Apprehend()
        sender.Ctimer.todo = selected
        Display_Update(sender.Ctimer.finished, sender.Ctimer.todo, procedure, form)
        If sender.Ctimer.todo.Count > 0 Then
            sender.Ctimer.note = sender.Ctimer.todo(0).ToString
            sender.ordered += 1
        Else
            sender.Ctimer.note = "End of the list"
            If MsgBox("The list is end. End?", vbOKCancel, Form1.Title) = MsgBoxResult.Ok Then GSL_Finish()
        End If
        Ctimer.apprehend()
    End Sub
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
        Form1.countries = New ArrayList
        For Each obj As String In countryform.ListBox2.Items
            Form1.countries.Add(obj)
        Next
        Form4.RichTextBox1.Text = ""
        Form1.simplemajority = CStr(Int(IIf(Form1.countries.Count Mod 2 = 0, Form1.countries.Count / 2 + 1, Form1.countries.Count / 2 + 0.5)))
        Form1.absolutemajority = CStr(Int(IIf(Form1.countries.Count Mod 3 = 0, 2 * Form1.countries.Count / 3, 2 * Form1.countries.Count / 3 + 1)))
        Form4.RichTextBox1.Text = "Committee " + Form1.committee + " " + Form1.session + System.Environment.NewLine + Form1.topic + System.Environment.NewLine + System.Environment.NewLine + Form4.RichTextBox1.Text + "Simple Majority " + CStr(Form1.simplemajority) + "  Two-thirds Majority " + CStr(Form1.absolutemajority)
        countryform.Close()
        Form1.Conference_begin()
    End Sub
    Private Sub itemchange()
        Dim box1 As ArrayList = New ArrayList
        Dim box2 As ArrayList = New ArrayList
        For Each obj In countryform.ListBox1.Items
            box1.Add(obj)
        Next
        For Each obj In countryform.ListBox2.Items
            box2.Add(obj)
        Next
        Display.Display_Update(box2, box1, "Roll Call", Form4)
    End Sub
End Class

