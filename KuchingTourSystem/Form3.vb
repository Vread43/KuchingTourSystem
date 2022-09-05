Imports System.IO 'TO ENSURE TXT FILE CAN BE READ
Public Class Form3

    Dim SelectedPackages As String = " "
    Dim packPrice As Double = 0
    Dim addOn As Double = 0
    Dim AddOnPerInsurancePrice As Double = 0
    Dim fullNameCust As String = " "

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        'CUSTOMER INFORMATIONS DECLARATIONS
        Dim phoneNumCust As String
        Dim emailCust As String
        Dim dateOfBook As String

        'ADD ON
        Dim perTravInsurance As Double = 50
        Dim FreeGift As String


        'PRICE ACCORDING AGE CATEGORY 
        Dim kidPrice As Double
        Dim adultPrice As Double
        Dim seniorPrice As Double

        'ASSIGN VALUE FROM TEXTBOX TO VARIABLE
        fullNameCust = TBcustName.Text
        phoneNumCust = TBcustPhoneNum.Text()
        emailCust = TBcustEmail.Text()
        dateOfBook = TBcustDate.Text()

        'VALIDATE ALL INPUT
        If (TBcustName.Text = Nothing) Then
            MessageBox.Show("Please Fill Up Your Name")
        ElseIf TBcustPhoneNum.Text = Nothing Then
            MessageBox.Show("Please Fill Up Your Contact Number")
        ElseIf TBcustEmail.Text = Nothing Then
            MessageBox.Show("Please Fill Up Your Email Address")
        ElseIf TBcustDate.Text = Nothing Then
            MessageBox.Show("Please Fill Up Booking Date")
        ElseIf adultNumeric.Value = 0 And kidNumeric.Value = 0 And seniorNumeric.Value = 0 Then
            MessageBox.Show("Please Enter The Total Amount Person")
        Else
            MessageBox.Show("Information Have Been Sucessfully Registered, Click Button Save To Save Receipt")

            If (radBtnA.Checked) Then

                kidPrice = kidNumeric.Value * 1000
                adultPrice = adultNumeric.Value * 1560
                seniorPrice = seniorNumeric.Value * 1300

                packPrice = kidPrice + adultPrice + seniorPrice

                If (CBbikeTour.Checked) Then
                    addOn = 30
                    addOnType = "HALF - DAY HERITAGE BIKE TOUR IN KUCHING"

                ElseIf (CBdinner.Checked) Then
                    addOn = 35
                    addOnType = "DINNER POTLUCK"

                ElseIf (CBMuseum.Checked) Then
                    addOn = 40
                    addOnType = "VISIT SARAWAK MUSEUM"

                ElseIf (CBnational.Checked) Then
                    addOn = 30
                    addOnType = "NATIONAL PARK TOUR"

                End If


            ElseIf (radBtnB.Checked) Then
                kidPrice = kidNumeric.Value * 950
                adultPrice = adultNumeric.Value * 1400
                seniorPrice = seniorNumeric.Value * 1240

                packPrice = kidPrice + adultPrice + seniorPrice

                If (CBkayak.Checked) Then
                    addOn = 35
                    addOnType = "FUN FILLED-KAYAKING"
                ElseIf (CBbirdFeed.Checked) Then
                    addOn = 15
                    addOnType = "BIRD FEEDING"

                ElseIf (CBphotos.Checked) Then
                    addOn = 20
                    addOnType = "PHOTOS WITH ANIMALS"

                ElseIf (CBQuiz.Checked) Then
                    addOn = 15
                    addOnType = "ANIMAL QUIZ"
                End If

            ElseIf (radBtnC.Checked) Then
                kidPrice = kidNumeric.Value * 1200
                adultPrice = adultNumeric.Value * 1700
                seniorPrice = seniorNumeric.Value * 1450
                packPrice = kidPrice + adultPrice + seniorPrice
                If (cbStack.Checked) Then
                    addOn = 100
                    addOnType = "SEA STACK TOUR"

                ElseIf (CBlearnDiving.Checked) Then
                    addOn = 70
                    addOnType = "LEARN HOW TO DIVING"

                ElseIf (CBlearnSurfing.Checked) Then
                    addOn = 65
                    addOnType = "LEARN HOW TO SURFING"

                ElseIf (CBbbq.Checked) Then
                    addOn = 110
                    addOnType = "BBQ SESSION"
                End If

            End If

            If (CBpersonalInsurance.Checked) Then
                AddOnPerInsurance = "PERSONAL INSURANCE"
                AddOnPerInsurancePrice = 50
            Else
                AddOnPerInsurance = "NONE"
                AddOnPerInsurancePrice = 0
            End If

            totalPrice = kidPrice + adultPrice + seniorPrice + addOn + AddOnPerInsurancePrice

            FreeGift = CBoxFreeGift.SelectedItem

            lstReceipt.Items.Add(" ")
            lstReceipt.Items.Add(vbNewLine & "========================================== ")
            lstReceipt.Items.Add("---------------------------RECEIPT--------------------------- ")
            lstReceipt.Items.Add("==========================================  ")
            lstReceipt.Items.Add("FULL NAME: " & TBcustName.Text & vbNewLine)
            lstReceipt.Items.Add("PHONE NUMBER: " & TBcustPhoneNum.Text & vbNewLine)
            lstReceipt.Items.Add("EMAIL ADDRESS: " & TBcustEmail.Text & vbNewLine)
            lstReceipt.Items.Add("DATE OF BOOKING: " & TBcustDate.Text)
            lstReceipt.Items.Add(" ")
            lstReceipt.Items.Add("NUMBER OF KIDS: " & kidNumeric.Value)
            lstReceipt.Items.Add("NUMBER OF ADULTS: " & adultNumeric.Value)
            lstReceipt.Items.Add("NUMBER OF SENIORS: " & seniorNumeric.Value)


            lstReceipt.Items.Add(" ")
            If radBtnA.Checked Then
                lstReceipt.Items.Add("PACKAGE : A , SARAWAK ALL TIME")

                SelectedPackages = "PACKAGE : A , SARAWAK ALL TIME"

            ElseIf radBtnB.Checked Then
                lstReceipt.Items.Add("PACKAGE : B ,  KUCHING WILD LIFE")

                SelectedPackages = "PACKAGE : B ,  KUCHING WILD LIFE"

            ElseIf radBtnC.Checked Then
                lstReceipt.Items.Add("PACKAGE : C ,  KUCHING BEACH LIFE")

                SelectedPackages = "PACKAGE : C ,  KUCHING BEACH LIFE"

            ElseIf Not (radBtnC.Checked And radBtnB.Checked And radBtnA.Checked) Then
                MessageBox.Show("Please Choose A Package")
            End If


            lstReceipt.Items.Add("PERSONAL INSURANCE(ADD ON): " & AddOnPerInsurance)
            lstReceipt.Items.Add("OTHERS ADD ON: " & addOnType)
            lstReceipt.Items.Add("FREE GIFT: " & FreeGift)
            lstReceipt.Items.Add("**TOTAL PRICE IS RM" & totalPrice)
            lstReceipt.Items.Add("==========================================  ")
        End If

    End Sub


    Dim AddOnPerInsurance As String = " "
    Dim totalPrice As Double = 0.0
    Dim addOnType As String = " "

    'SAVE FILE IN Receipt.txt and SummaryOfBooking.txt
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Dim saveFile As StreamWriter

        saveFile = File.AppendText("Receipt.txt")
        saveFile.WriteLine(vbNewLine & "===================================================  " & vbNewLine &
                            "---------------------------RECEIPT--------------------------- " & vbNewLine &
                            "===================================================   " & vbNewLine &
                            "FULL NAME: " & fullNameCust & vbNewLine &
                            "SELECTED PACKAGES : " & SelectedPackages & vbNewLine &
                            "NUMBER OF KIDS : " & kidNumeric.Value & vbNewLine &
                            "NUMBER OF ADULTS : " & adultNumeric.Value & vbNewLine &
                            "NUMBER OF SENIORS : " & seniorNumeric.Value & vbNewLine &
                            "PERSONAL INSURANCE(ADD ON) : " & AddOnPerInsurance & vbNewLine &
                            "OTHER ADD ON : " & addOnType & vbNewLine &
                           "**TOTAL PRICE IS RM" & totalPrice)

        saveFile.Close()
        Dim saveFile2 As StreamWriter
        saveFile2 = File.AppendText("SummaryOfBooking.txt")
        saveFile2.WriteLine(fullNameCust & vbNewLine &
                              SelectedPackages & vbNewLine &
                              packPrice & " PACKAGE PRICE IN RM" & vbNewLine &
                              AddOnPerInsurancePrice & " //PERSONAL INSURANCE CHARGE IN RM" & vbNewLine &
                              addOn & " //ADD ON ACTIVITIES PRICE IN RM" & vbNewLine &
                              kidNumeric.Value & " //NUMBER OF KIDS : " & vbNewLine &
                              adultNumeric.Value & " //NUMBER OF ADULTS" & vbNewLine &
                              seniorNumeric.Value & " //NUMBER OF SENIORS")


        saveFile2.Close()

        MessageBox.Show("Receipt has been saved as Receipt.txt and SummaryOfBooking.txt")

    End Sub

    'EXIT FORM3 
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        End
    End Sub

    'SHOW ALL PACKAGES IN FORM2
    Private Sub lblBackToPackage_Click(sender As Object, e As EventArgs) Handles lblBackToPackage.Click
        Form2.Show()
        Me.Hide()

    End Sub

    'HIDE FORM3 AND  MOVE TO FORM4
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Me.Hide()
        Form4.Show()
    End Sub


    'RESETTING RADIO BUTTON
    Private Sub radBtnA_CheckedChanged(sender As Object, e As EventArgs) Handles radBtnA.CheckedChanged
        CBpersonalInsurance.Enabled = True

        CBbikeTour.Enabled = True
        CBdinner.Enabled = True
        CBMuseum.Enabled = True
        CBnational.Enabled = True


        CBkayak.Enabled = False
        CBbirdFeed.Enabled = False
        CBphotos.Enabled = False
        CBQuiz.Enabled = False

        cbStack.Enabled = False
        CBlearnDiving.Enabled = False
        CBbbq.Enabled = False
        CBlearnSurfing.Enabled = False

    End Sub

    'RESETTING RADIO BUTTON
    Private Sub radBtnB_CheckedChanged(sender As Object, e As EventArgs) Handles radBtnB.CheckedChanged
        CBpersonalInsurance.Enabled = True

        CBbikeTour.Enabled = False
        CBdinner.Enabled = False
        CBMuseum.Enabled = False
        CBnational.Enabled = False

        CBkayak.Enabled = True
        CBbirdFeed.Enabled = True
        CBphotos.Enabled = True
        CBQuiz.Enabled = True

        cbStack.Enabled = False
        CBlearnDiving.Enabled = False
        CBbbq.Enabled = False
        CBlearnSurfing.Enabled = False
    End Sub

    'RESETTING RADIO BUTTON
    Private Sub radBtnC_CheckedChanged(sender As Object, e As EventArgs) Handles radBtnC.CheckedChanged
        CBpersonalInsurance.Enabled = True

        CBbikeTour.Enabled = False
        CBdinner.Enabled = False
        CBMuseum.Enabled = False
        CBnational.Enabled = False

        CBkayak.Enabled = False
        CBbirdFeed.Enabled = False
        CBphotos.Enabled = False
        CBQuiz.Enabled = False

        cbStack.Enabled = True
        CBlearnDiving.Enabled = True
        CBbbq.Enabled = True
        CBlearnSurfing.Enabled = True
    End Sub

    'RESETTING INPUT BOX AND ETC
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        TBcustName.Clear()
        TBcustPhoneNum.Clear()
        TBcustEmail.Clear()
        TBcustDate.Clear()
        CBpersonalInsurance.Checked = False
        radBtnA.Checked = 0
        radBtnB.Checked = 0
        radBtnC.Checked = 0

        kidNumeric.Value = 0
        adultNumeric.Value = 0
        seniorNumeric.Value = 0

        CBpersonalInsurance.Enabled = True
        CBoxFreeGift.SelectedIndex = 0

        'ENABLE
        CBbikeTour.Enabled = True
        CBdinner.Enabled = True
        CBMuseum.Enabled = True
        CBnational.Enabled = True

        CBkayak.Enabled = True
        CBbirdFeed.Enabled = True
        CBphotos.Enabled = True
        CBQuiz.Enabled = True

        cbStack.Enabled = True
        CBbbq.Enabled = True
        CBlearnSurfing.Enabled = True

        'CHECK 
        CBbikeTour.Checked = False
        CBdinner.Checked = False
        CBMuseum.Checked = False
        CBnational.Checked = False

        CBkayak.Checked = False
        CBbirdFeed.Checked = False
        CBphotos.Checked = False
        CBQuiz.Checked = False

        cbStack.Checked = False
        CBlearnDiving.Checked = False
        CBbbq.Checked = False
        CBlearnSurfing.Checked = False
    End Sub

    Private Sub help_Click(sender As Object, e As EventArgs) Handles help.Click
        MessageBox.Show("DUE TO LIMITATION OF TRIP DURATION, ONLY ONE ADD TYPE ON PER ORDER CAN BE CHOOSEN, THANK YOU")
    End Sub


End Class