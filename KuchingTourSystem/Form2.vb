Public Class Form2

    'EXIT FORM2
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        End
    End Sub

    'MOVE TO FORM5(MENU) AND HIDE FORM2
    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        Form5.Show()
        Me.Hide()
    End Sub

    'MOVE TO FORM1 AND HIDE FORM2
    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        Form1.Show()
        Me.Hide()
    End Sub

    'MOVE TO FORM3 AND HIDE FORM2
    Private Sub nextPage_Click(sender As Object, e As EventArgs) Handles nextPage.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class