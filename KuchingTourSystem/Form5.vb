Public Class Form5

    Private Sub form1sh_Click_1(sender As Object, e As EventArgs) Handles form1sh.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub form2sh_Click(sender As Object, e As EventArgs) Handles form2sh.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub form3sh_Click_1(sender As Object, e As EventArgs) Handles form3sh.Click
        Form3.Show()

        Me.Hide()

    End Sub

    Private Sub form4sh_Click_1(sender As Object, e As EventArgs) Handles form4sh.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub lblHelp_Click(sender As Object, e As EventArgs) Handles lblHelp.Click
        MessageBox.Show("Please Click One Of The Button On The Menu Page, Suggestion, Start With Staff Registration Form")
    End Sub


End Class