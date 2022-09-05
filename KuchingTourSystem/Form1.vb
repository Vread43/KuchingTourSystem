Imports System.IO
Public Class Form1
    Private Sub BtnSignIn_Click(sender As Object, e As EventArgs) Handles BtnSignIn.Click

        'TO ENSURE INPUT ARE NOT MISSING
        If (TBname.Text = Nothing Or
           TBstaffID.Text = Nothing Or
           TBphoneNo.Text = Nothing Or
           TBemail.Text = Nothing Or
           TBuserName.Text = Nothing Or
           TBuserPassword.Text = Nothing) Then
            MessageBox.Show("Please Fill Up All The Information")

        ElseIf TBuserPassword.Text.Length > 8 And TBuserPassword.Text.Length < 12 Then
            MessageBox.Show("Password length must around 8 - 12 characters /  digit")

        Else
            Me.RegisterDBBindingSource.AddNew() 'ADD NEW RECORD TO DATABASE TABLE
        End If

    End Sub

    'EXITING THE FORM 1
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        End
    End Sub

    'EXITING THE FORM 1 AND GO TO FORM2
    Private Sub goToViewPackage_Click(sender As Object, e As EventArgs) Handles goToViewPackage.Click
        Me.Hide()
        Form2.Show()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RegisterDB1DataSet.RegisterDB' table. You can move, or remove it, as needed.
        Me.RegisterDBTableAdapter.Fill(Me.RegisterDB1DataSet.RegisterDB)
        BtnSignIn.PerformClick()

    End Sub

    'UPDATE THE DATA IN DATABASE
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Me.Validate()
        RegisterDBBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RegisterDB1DataSet)
        MessageBox.Show("Your Data Successfully Updated")

    End Sub

    'DELETE THE DATA IN DATABASE
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        RegisterDBBindingSource.RemoveCurrent()
        Me.TableAdapterManager.UpdateAll(Me.RegisterDB1DataSet)
        MessageBox.Show("Your Data Successfully Removed")
    End Sub

    'MOVE TO FIRST ROW IN DATABASE
    Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles BtnFirst.Click
        Me.RegisterDBBindingSource.MoveFirst()
    End Sub

    'MOVE TO NEXT ROW IN DATABASE
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Me.RegisterDBBindingSource.MoveNext()
    End Sub

    'MOVE TO PREVIOUS ROW IN DATABASE
    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        Me.RegisterDBBindingSource.MovePrevious()
    End Sub

    'MOVE TO LAST ROW IN DATABASE
    Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles BtnLast.Click
        Me.RegisterDBBindingSource.MoveLast()
    End Sub

    'SAVE ROW IN DATABASE
    Private Sub btnSaveRecord_Click(sender As Object, e As EventArgs) Handles btnSaveRecord.Click
        Me.RegisterDBBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RegisterDB1DataSet)
        MessageBox.Show("Your Data Successfully Saved")
    End Sub

    Private Sub RegisterDBBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.RegisterDBBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RegisterDB1DataSet)

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        TBname.Clear()
        TBemail.Clear()
        TBphoneNo.Clear()
        TBstaffID.Clear()
        TBuserName.Clear()
        TBuserPassword.Clear()

    End Sub
End Class
