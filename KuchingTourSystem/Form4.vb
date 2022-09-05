Imports System.IO
Public Class Form4

    'RETURN AMOUNT OF PACKAGE A
    Private Function countPackageA() As Integer
        Dim SOBfile As StreamReader
        Dim packs As String

        Dim countA As Integer = 0

        Try
            If (File.Exists("SummaryOfBooking.txt")) Then
                SOBfile = File.OpenText("SummaryOfBooking.txt")
                Do Until SOBfile.EndOfStream
                    packs = SOBfile.ReadLine()

                    If packs = "PACKAGE : A , SARAWAK ALL TIME" Then

                        countA = countA + 1

                    End If
                Loop
                SOBfile.Close()

            Else
                MessageBox.Show("File not found!")
            End If


        Catch ex As Exception
            MessageBox.Show("Error!!")

        End Try
        Return countA
    End Function


    'RETURN AMOUNT OF PACKAGE B
    Private Function countPackageB()
        Dim SOBfile As StreamReader
        Dim packs As String
        Dim stateName As String = "Not relevant"

        Dim countB As Integer = 0

        Try
            If (File.Exists("SummaryOfBooking.txt")) Then
                SOBfile = File.OpenText("SummaryOfBooking.txt")
                Do Until SOBfile.EndOfStream
                    packs = SOBfile.ReadLine()

                    If packs = "PACKAGE : B ,  KUCHING WILD LIFE" Then
                        countB = countB + 1

                    End If
                Loop
                SOBfile.Close()

            Else
                MessageBox.Show("File not found!")
            End If


        Catch ex As Exception
            MessageBox.Show("Error!!")

        End Try
        Return countB
    End Function

    'RETURN AMOUNT OF PACKAGE C
    Private Function countPackageC() As Integer
        Dim SOBfile As StreamReader
        Dim packs As String


        Dim countC As Integer = 0
        Try
            If (File.Exists("SummaryOfBooking.txt")) Then
                SOBfile = File.OpenText("SummaryOfBooking.txt")
                Do Until SOBfile.EndOfStream
                    packs = SOBfile.ReadLine()

                    If packs = "PACKAGE : C ,  KUCHING BEACH LIFE" Then
                        countC = countC + 1

                    End If
                Loop
                SOBfile.Close()

            Else
                MessageBox.Show("File not found!")
            End If


        Catch ex As Exception
            MessageBox.Show("Error!!")

        End Try
        Return countC
    End Function

    Private Sub BtnDisplay_Click(sender As Object, e As EventArgs) Handles BtnDisplay.Click
        lstReport.Items.Add("===============================SUMMARY OF BOOKING=================================================================")
        lstReport.Items.Add("TICKET SOLD: ")
        lstReport.Items.Add("============================================================================================================================================")
        lstReport.Items.Add(" ")
        lstReport.Items.Add("TOTAL PACKAGE A IS: " & countPackageA())
        lstReport.Items.Add("TOTAL PACKAGE B IS: " & countPackageB())
        lstReport.Items.Add("TOTAL PACKAGE C IS: " & countPackageC())


        'MAX CHOSEN
        lstReport.Items.Add(" ")
        lstReport.Items.Add("==========================================================================================================")
        lstReport.Items.Add("THE MOST AND LEAST CHOSEN PACKAGE: ")
        lstReport.Items.Add("==========================================================================================================")
        lstReport.Items.Add(" ")
        If countPackageA() > countPackageB() Then
            If countPackageA() > countPackageC() Then
                lstReport.Items.Add("PACKAGE A IS THE MOST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageA())
            Else
                lstReport.Items.Add("PACKAGE C THE MOST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageC())
            End If
        Else
            If countPackageB() > countPackageC() Then
                lstReport.Items.Add("PACKAGE B THE MOST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageB())
            Else
                lstReport.Items.Add("PACKAGE C THE MOST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageC())
            End If
        End If

        'MIN CHOSEN
        If countPackageA() < countPackageB() Then
            If countPackageA() < countPackageC() Then
                lstReport.Items.Add("PACKAGE A IS THE LEAST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageA())
            Else
                lstReport.Items.Add("PACKAGE C THE LEAST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageC())
            End If
        Else
            If countPackageB() < countPackageC() Then
                lstReport.Items.Add("PACKAGE B THE LEAST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageB())
            Else
                lstReport.Items.Add("PACKAGE C THE LEAST CHOSEN PACKAGE, TOTAL BOOKED PACKAGE IS " & countPackageC())
            End If
        End If

        lstReport.Items.Add(" ")
        lstReport.Items.Add("==========================================================================================================")
        lstReport.Items.Add("TOTAL PACKAGE PRICE AND TOTAL ADD ON ACTIVITIES PRICES FOR EACH PACKAGE FOR ALL CUSTOMERS: ")
        lstReport.Items.Add("==========================================================================================================")

        lstReport.Items.Add(" ")
        ' Total package price and total add on activities price for each package for

        Dim SOBfile As StreamReader

        Dim name As String
        Dim packline As String
        Dim eachPackPrice As Double = 0
        Dim personalInsRead As Double = 0
        Dim addOnz As Double = 0
        Dim kidRead As Double = 0
        Dim adultRead As Double = 0
        Dim seniorsRead As Double = 0


        Try
            If (File.Exists("SummaryOfBooking.txt")) Then
                SOBfile = File.OpenText("SummaryOfBooking.txt")
                Do Until SOBfile.EndOfStream
                    name = SOBfile.ReadLine()
                    packline = SOBfile.ReadLine()
                    eachPackPrice = Val(SOBfile.ReadLine())
                    personalInsRead = Val(SOBfile.ReadLine())
                    addOnz = Val(SOBfile.ReadLine())
                    kidRead = Val(SOBfile.ReadLine())
                    adultRead = Val(SOBfile.ReadLine())
                    seniorsRead = Val(SOBfile.ReadLine())



                    lstReport.Items.Add("CUSTOMER NAME :" & name)
                    lstReport.Items.Add(" ")
                    lstReport.Items.Add("PACKAGE " & packline)
                    lstReport.Items.Add("PACKAGE PRICE: RM" & eachPackPrice)
                    lstReport.Items.Add("PERSONAL INSURANCES CHARGE: RM" & personalInsRead)
                    lstReport.Items.Add("ADD ON ACTIVITY PRICE: RM" & addOnz)

                    lstReport.Items.Add("TOTAL KID : " & kidRead)
                    lstReport.Items.Add("TOTAL ADULT " & adultRead)
                    lstReport.Items.Add("TOTAL SENIOR : " & seniorsRead)

                    lstReport.Items.Add("-----------------------------------------------------------------------------------------------------------")


                Loop
                SOBfile.Close()

            Else
                MessageBox.Show("File not found!")
            End If


        Catch ex As Exception
            MessageBox.Show("Error!!")

        End Try

        'DECLARATION VARIABLE NEEDED
        Dim packPrice As Double
        Dim totalPackPriceA As Double = 0
        Dim totalPackPriceB As Double = 0
        Dim totalPackPriceC As Double = 0

        Dim insuranceLine As Double
        Dim persInsuA As Double = 0
        Dim persInsuB As Double = 0
        Dim persInsuC As Double = 0

        Dim addOnLine As Double
        Dim addOnA As Double = 0
        Dim addOnB As Double = 0
        Dim addOnC As Double = 0
        Dim packs As String

        Dim totalDue As Double

        Try
            If (File.Exists("SummaryOfBooking.txt")) Then
                SOBfile = File.OpenText("SummaryOfBooking.txt")

                Do Until SOBfile.EndOfStream

                    packs = SOBfile.ReadLine()


                    If packs = "PACKAGE : A , SARAWAK ALL TIME" Then
                        packPrice = Val(SOBfile.ReadLine())
                        totalPackPriceA += packPrice

                        insuranceLine = Val(SOBfile.ReadLine())
                        persInsuA += insuranceLine

                        addOnLine = Val(SOBfile.ReadLine())
                        addOnA += addOnLine




                    ElseIf packs = "PACKAGE : B ,  KUCHING WILD LIFE" Then
                        packPrice = Val(SOBfile.ReadLine())
                        totalPackPriceB += packPrice

                        insuranceLine = Val(SOBfile.ReadLine())
                        persInsuB += insuranceLine

                        addOnLine = Val(SOBfile.ReadLine())
                        addOnB += addOnLine


                    ElseIf packs = "PACKAGE : C ,  KUCHING BEACH LIFE" Then
                        packPrice = Val(SOBfile.ReadLine())
                        totalPackPriceC += packPrice

                        insuranceLine = Val(SOBfile.ReadLine())
                        persInsuC += insuranceLine

                        addOnLine = Val(SOBfile.ReadLine())
                        addOnC += addOnLine


                    End If

                    totalDue = totalPackPriceA + totalPackPriceB + totalPackPriceC +
                              persInsuA + persInsuB + persInsuC +
                              addOnA + addOnB + addOnC

                Loop

                SOBfile.Close()
                'OUTPUT
                lstReport.Items.Add(" ")
                lstReport.Items.Add("==========================================================================================================")
                lstReport.Items.Add("TOTAL PACKAGE PRICE AND TOTAL ADD ON ACTIVITIES PRICES FOR ALL PACKAGES: ")
                lstReport.Items.Add("==========================================================================================================")
                lstReport.Items.Add(" ")

                lstReport.Items.Add("TOTAL PRICE FOR PACKAGE A IS RM " & totalPackPriceA)
                lstReport.Items.Add("TOTAL PRICE FOR PACKAGE B IS RM " & totalPackPriceB)
                lstReport.Items.Add("TOTAL PRICE FOR PACKAGE C IS RM " & totalPackPriceC)

                lstReport.Items.Add("-----------------------------------------------------------------------------------------------------------")
                lstReport.Items.Add("TOTAL PRICE FOR ADD ON PACKAGE A IS RM " & addOnA + persInsuA)
                lstReport.Items.Add("TOTAL PRICE FOR ADD ON PACKAGE B IS RM " & addOnB + persInsuB)
                lstReport.Items.Add("TOTAL PRICE FOR ADD ON PACKAGE C IS RM " & addOnC + persInsuB)

                lstReport.Items.Add(" ")
                lstReport.Items.Add("==========================================================================================================")
                lstReport.Items.Add("TOTAL DUE FOR ALL PACKAGE IS: RM" & totalDue)
                lstReport.Items.Add("==========================================================================================================")

                lstPackages.Items.Add("==========================================================================================================")
                lstPackages.Items.Add("INFORMATION ABOUT PACKAGES: ")
                lstPackages.Items.Add("==========================================================================================================")
                lstPackages.Items.Add("TICKET SOLD: ")
                lstPackages.Items.Add("TICKET PACKAGE A (SARAWAK ALL TIME): " & countPackageA())
                lstPackages.Items.Add("TICKET PACKAGE B (KUCHING WILD LIFE): " & countPackageB())
                lstPackages.Items.Add("TICKET PACKAGE C (KUCHING BEACH LIFE): " & countPackageC())


            Else
                MessageBox.Show("File not found!")
            End If


        Catch ex As Exception
            MessageBox.Show("Error!!")

        End Try


        'STORE FREEGIFT ITEMS IN ARRAY 1D
        lstPackages.Items.Add(" ")
        Dim freeGift() As String = {"1) Face Mask", "2) Hand Sanitizer"}

        lstPackages.Items.Add("FREE GIFT AVAILABLE: ")
        lstPackages.Items.Add(freeGift(0))
        lstPackages.Items.Add(freeGift(1))

    End Sub

    'CLOSE FORM4 
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        End
    End Sub

    'RESET LISTBOX IN FORM4
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        lstReport.Items.Clear()
        lstPackages.Items.Clear()
    End Sub

    'HIDE FORM4 THEN SHOW FORM3(CUSTOMER REGISTRATION)
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Form3.Show()
    End Sub

    'HIDE FORM4 THEN SHOW FORM5(MENU)
    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        Me.Hide()
        Form5.Show()
    End Sub

    'SHOW FORM2 WHICH IS PACKAGES FORM
    Private Sub viewPackages_Click_1(sender As Object, e As EventArgs) Handles viewPackages.Click
        Form2.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class