Public Class timer
    Private timeform As Form5 = New Form5
    Friend type As Byte '0=GSL, 1=MC,2=UMC
    Friend speaker As Integer = 0, total As Integer = 0
    Friend note As String
    Friend list As ArrayList = New ArrayList, finished As ArrayList = New ArrayList, todo As ArrayList = New ArrayList
    Friend order As Integer
    Event nextspeaker()
    Event finish()
    Sub init()
        With timeform
            If type = 1 Then
                .Label3.Visible = True
                .Label4.Visible = True
                .Width = 563
                .Label1.Text = speaker
                .Label4.Text = total
                note = list(0).ToString
            Else
                .Label3.Visible = False
                .Label4.Visible = False
                .Width = 300
                If type = 0 Then
                    .Label2.Text = "Speaker"
                    .Label1.Text = speaker
                    note = list(0).ToString
                Else
                    .Label2.Text = "Total"
                    .Label1.Text = total
                    .Button1.Text = "Finish"
                    .Timer1.Enabled = True
                    .Label5.Text = note
                    AddHandler finish, AddressOf Me.Close
                End If
            End If
            AddHandler .Timer1.Tick, AddressOf Timer
            AddHandler .Button1.Click, AddressOf button

            order = 0
            todo = list
            finished = New ArrayList
            .Label5.Text = note
            .Show()
        End With
    End Sub
    Sub Timer()
        With timeform
            .Label1.Text = CInt(.Label1.Text) - 1
            If .Label4.Visible Then
                .Label4.Text = CInt(.Label4.Text) - 1
                If CStr(.Label4.Text) <= 0 Then
                    RaiseEvent finish()
                    .Timer1.Enabled = False
                    Exit Sub
                End If
            End If
            If CStr(.Label1.Text) <= 0 Then
                .Timer1.Enabled = False
                If type = 2 Then
                    RaiseEvent finish()
                Else
                    .Button1.Text = "Begin"
                    RaiseEvent nextspeaker()
                    .Label5.Text = note
                    .Label1.Text = speaker
                End If
            End If
        End With
    End Sub
    Sub button()
        With timeform
            If .Button1.Text = "Begin" Then
                .Timer1.Enabled = True
                .Button1.Text = "Finish"
            ElseIf .Button1.Text = "Finish" Then
                .Button1.Text = "Begin"
                .Timer1.Enabled = False
                Select Case type
                    Case 0
                        RaiseEvent nextspeaker()
                        .Label5.Text = note
                        .Label1.Text = speaker
                    Case 1
                        RaiseEvent nextspeaker()
                        .Label5.Text = note
                        .Label1.Text = speaker
                    Case 2
                        RaiseEvent finish()
                End Select
            End If
        End With
    End Sub
    Sub apprehend()
        With timeform
            .Button1.Text = "Begin"
            RaiseEvent nextspeaker()
            .Label5.Text = note
            .Label1.Text = speaker
        End With

    End Sub

    Sub Close()
        timeform.Close()
    End Sub
End Class
