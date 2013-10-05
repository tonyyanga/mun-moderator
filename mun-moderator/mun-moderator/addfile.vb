Public Class addfile
    Private country_sel As country_select
    Private form As Form3 = New Form3
    Private am As Amendment, dr As Resolution
    Friend Sub Init()
        AddHandler form.Save, AddressOf Save
        form.Show()
    End Sub
    Private Sub Save()
        If form.RadioButton3.Checked Then
            dr = New Resolution
            dr.name = form.TextBox1.Text
            country_sel = New country_select
            country_sel.ordered = True
            country_sel.note = "Ordered! Choose the sponsors of " + dr.name
            AddHandler country_sel.finish, AddressOf DRSponsorsFinish
            country_sel.Init()
            country_sel.init2()
        Else
            am = New Amendment
            am.name = form.TextBox1.Text
            country_sel = New country_select
            country_sel.ordered = False
            country_sel.note = "Choose the sponsors of " + am.name
            AddHandler country_sel.finish, AddressOf AmendmentFinish
            If form.RadioButton1.Checked Then
                am.unfriendly = False
                country_sel.Init()
                country_sel.init2()
            Else
                am.unfriendly = True
                country_sel.Init()
                country_sel.init2()
            End If
        End If
        Form3.Close()
    End Sub
    Private Sub AmendmentFinish()
        am.sponsors = country_sel.selected
        Form1.amendment.Add(am)
        am = Nothing
    End Sub
    Private Sub DRSponsorsFinish()
        dr.sponsors = country_sel.selected
        country_sel = New country_select
        country_sel.ordered = False
        country_sel.note = "Choose the signatories of " + dr.name
        AddHandler country_sel.finish, AddressOf DRSignatoriesFinish
        country_sel.Init()
        country_sel.init2()
    End Sub
    Private Sub DRSignatoriesFinish()
        dr.signatories = country_sel.selected
        Form1.resolutions.Add(dr)
        dr = Nothing
    End Sub
End Class
