Imports MySql.Data.MySqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmCheckout

#Region "Class-level Variables"
    ' REVISED: The form now works with a list of ReservationIDs
    Private ReadOnly reservationIdsToCheckout As List(Of Integer)
    Private reservationsToCheckout As New List(Of ReservationDetail)()
    Private addonsForStay As New List(Of AddonDetail)()
    Private downPaymentsMade As Decimal = 0

    ' Calculation variables
    Private roomTotal As Decimal = 0
    Private addonTotal As Decimal = 0
    Private subTotal As Decimal = 0
    Private finalTotal As Decimal = 0
    Private remainingBalance As Decimal = 0
    Private loyaltyDiscountAmount As Decimal = 0
    Private taxAmount As Decimal = 0
    Private pointsValueUsed As Decimal = 0

    ' Guest-specific variables
    Private guestId As Integer
    Private guestName As String = ""
    Private loyaltyTier As String = "N/A"
    Private loyaltyDiscountPercent As Decimal = 0
    Private availablePoints As Integer = 0

    Private Structure ReservationDetail
        Property ReservationID As Integer
        Property GuestID As Integer
        Property RoomID As Integer
        Property RoomNumber As String
        Property TypeName As String
        Property CheckInDate As Date
        Property CheckOutDate As Date
        Property PricePerNight As Decimal
        Property NumberOfNights As Integer
        ReadOnly Property TotalRoomCost As Decimal
            Get
                Return PricePerNight * NumberOfNights
            End Get
        End Property
    End Structure

    Private Structure AddonDetail
        Property Name As String
        Property Quantity As Integer
        Property Price As Decimal
        ReadOnly Property TotalCost As Decimal
            Get
                Return Price * Quantity
            End Get
        End Property
    End Structure
#End Region

    ''' <summary>
    ''' REVISED: The constructor now accepts a List of ReservationIDs
    ''' </summary>
    Public Sub New(ByVal reservationIDs As List(Of Integer))
        InitializeComponent()
        reservationIdsToCheckout = reservationIDs
    End Sub

    Private Sub frmCheckout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not LoadCheckoutDetails() Then
                MsgBox("Could not load checkout details for the selected reservation(s).", MsgBoxStyle.Critical, "Load Error")
                Me.Close()
                Return
            End If

            If cboPaymentMethod.Items.Count > 0 Then
                cboPaymentMethod.SelectedIndex = 0
            Else
                MsgBox("Payment methods have not been loaded into the checkout form. Please add them in the form designer.", MsgBoxStyle.Critical, "Configuration Warning")
            End If

            CalculateFinalBill()
            DisplayBill()

        Catch ex As Exception
            MsgBox($"A critical error occurred while loading the checkout form: {ex.Message}{vbCrLf}{vbCrLf}The form will now close.", MsgBoxStyle.Critical, "Fatal Error")
            Me.Close()
        End Try
    End Sub

    ''' <summary>
    ''' REVISED: This function now loads details for all reservations in the passed-in list.
    ''' </summary>
    Private Function LoadCheckoutDetails() As Boolean
        If reservationIdsToCheckout Is Nothing OrElse reservationIdsToCheckout.Count = 0 Then Return False

        Dim resIDsString = String.Join(",", reservationIdsToCheckout)

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim sql As String = "SELECT g.GuestID, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, lt.TierName, lt.DiscountPercentage, g.TotalLoyaltyPoints, " &
                                 "res.ReservationID, r.RoomID, r.RoomNumber, rt.TypeName, res.CheckInDate, res.CheckOutDate, r.BasePricePerNight " &
                                 "FROM reservations res " &
                                 "JOIN guests g ON res.GuestID = g.GuestID " &
                                 "JOIN users u ON g.UserID = u.UserID " &
                                 "JOIN rooms r ON res.RoomID = r.RoomID " &
                                 "JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID " &
                                 "LEFT JOIN loyaltytiers lt ON g.LoyaltyTierID = lt.TierID " &
                                 $"WHERE res.ReservationID IN ({resIDsString}) AND res.ReservationStatus = 'Checked In';"

            Using cmd As New MySqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        If guestId = 0 Then ' Load one-time guest details from the first record
                            guestId = CInt(reader("GuestID"))
                            guestName = reader("GuestName").ToString()
                            loyaltyTier = If(IsDBNull(reader("TierName")), "N/A", reader("TierName").ToString())
                            loyaltyDiscountPercent = If(IsDBNull(reader("DiscountPercentage")), 0, CDec(reader("DiscountPercentage")))
                            availablePoints = If(IsDBNull(reader("TotalLoyaltyPoints")), 0, CInt(reader("TotalLoyaltyPoints")))
                        End If

                        Dim nights = CInt((CDate(reader("CheckOutDate")) - CDate(reader("CheckInDate"))).TotalDays)
                        If nights <= 0 Then nights = 1

                        reservationsToCheckout.Add(New ReservationDetail With {
                            .ReservationID = CInt(reader("ReservationID")),
                            .GuestID = CInt(reader("GuestID")),
                            .RoomID = CInt(reader("RoomID")),
                            .RoomNumber = reader("RoomNumber").ToString(),
                            .TypeName = reader("TypeName").ToString(),
                            .CheckInDate = CDate(reader("CheckInDate")),
                            .CheckOutDate = CDate(reader("CheckOutDate")),
                            .PricePerNight = CDec(reader("BasePricePerNight")),
                            .NumberOfNights = nights
                        })
                    End While
                End Using
            End Using

            If reservationsToCheckout.Count = 0 Then Return False

            ' Get addons for all selected reservations
            Dim addonSql = $"SELECT a.AddonName, ra.Quantity, a.Price FROM reservation_addons ra JOIN addons a ON ra.AddonID = a.AddonID WHERE ra.ReservationID IN ({resIDsString});"
            Using cmd As New MySqlCommand(addonSql, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        addonsForStay.Add(New AddonDetail With {
                            .Name = reader("AddonName").ToString(),
                            .Quantity = CInt(reader("Quantity")),
                            .Price = CDec(reader("Price"))
                        })
                    End While
                End Using
            End Using

            ' --- MODIFICATION START ---
            ' Get ONLY actual down payments, excluding 'Room Charge' entries
            ' This assumes 'Room Charge' is exclusively used for addons and not for actual cash/card down payments.
            Dim paymentSql = $"SELECT SUM(PaymentAmount) FROM payments WHERE ReservationID IN ({resIDsString}) AND PaymentMethod <> 'Room Charge';" '<--- Filtered by PaymentMethod
            Using cmd As New MySqlCommand(paymentSql, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    downPaymentsMade = CDec(result)
                End If
            End Using
            ' --- MODIFICATION END ---
        End Using
        Return True
    End Function

    Private Sub CalculateFinalBill()
        roomTotal = reservationsToCheckout.Sum(Function(r) r.TotalRoomCost)
        addonTotal = addonsForStay.Sum(Function(a) a.TotalCost)
        subTotal = roomTotal + addonTotal
        loyaltyDiscountAmount = subTotal * (loyaltyDiscountPercent / 100)
        Dim taxRate = modDB.GetTaxRate() / 100
        taxAmount = (subTotal - loyaltyDiscountAmount) * taxRate
        pointsValueUsed = (CInt(numPointsToUse.Value) / 200) * 40

        finalTotal = subTotal - loyaltyDiscountAmount + taxAmount
        remainingBalance = finalTotal - downPaymentsMade - pointsValueUsed
    End Sub

    Private Sub DisplayBill()
        lblGuestName.Text = guestName
        lblLoyaltyInfo.Text = $"{loyaltyTier} ({loyaltyDiscountPercent}%) - {availablePoints} Points Available"
        numPointsToUse.Maximum = availablePoints

        Dim billSummary As New System.Text.StringBuilder()
        billSummary.AppendLine("--- Room Charges ---")
        For Each res In reservationsToCheckout
            billSummary.AppendLine($"{res.RoomNumber} ({res.TypeName}) - {res.NumberOfNights} nights: {res.TotalRoomCost:C}")
        Next
        billSummary.AppendLine()
        billSummary.AppendLine("--- Addons & Services ---")
        For Each addon In addonsForStay
            billSummary.AppendLine($"{addon.Name} (x{addon.Quantity}): {addon.TotalCost:C}")
        Next
        txtBillSummary.Text = billSummary.ToString()

        lblSubtotal.Text = subTotal.ToString("C")
        lblDiscount.Text = loyaltyDiscountAmount.ToString("C")
        lblTax.Text = taxAmount.ToString("C")
        lblGrandTotal.Text = finalTotal.ToString("C")
        lblDownPayment.Text = downPaymentsMade.ToString("C")
        lblPointsApplied.Text = pointsValueUsed.ToString("C")
        lblAmountDue.Text = remainingBalance.ToString("C")
    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click
        If remainingBalance > 0 AndAlso String.IsNullOrWhiteSpace(cboPaymentMethod.Text) Then
            MsgBox("Please select a payment method.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox($"Confirm checkout for {guestName} ({reservationsToCheckout.Count} rooms)?{vbCrLf}Amount to be charged: {remainingBalance:C}", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return
        ' NEW: Add validation specifically for cash payments
        If cboPaymentMethod.Text.Equals("Cash", StringComparison.OrdinalIgnoreCase) Then
            Dim cashTendered As Decimal = 0
            Decimal.TryParse(txtCashTendered.Text, cashTendered) ' Try to parse the value

            If cashTendered < remainingBalance Then
                MsgBox("The cash amount tendered is not sufficient to cover the balance due.", MsgBoxStyle.Exclamation, "Insufficient Payment")
                Return ' Stop the process
            End If
        End If
        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim trans As MySqlTransaction = conn.BeginTransaction()
            Try
                If remainingBalance > 0 Then
                    ' --- MODIFICATION START ---
                    ' The final payment should use the selected method, which will NOT be 'Room Charge'
                    Dim paymentSql As String = "INSERT INTO payments (ReservationID, PaymentAmount, PaymentMethod, PaymentStatus, ProcessedByStaffID) VALUES (@ResID, @Amount, @Method, 'Success', @StaffID);"
                    Using cmd As New MySqlCommand(paymentSql, conn, trans)
                        cmd.Parameters.AddWithValue("@ResID", reservationsToCheckout(0).ReservationID) ' Log against first reservation
                        cmd.Parameters.AddWithValue("@Amount", remainingBalance)
                        cmd.Parameters.AddWithValue("@Method", cboPaymentMethod.Text) ' Use the selected payment method
                        cmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
                        cmd.ExecuteNonQuery()
                    End Using
                    ' --- MODIFICATION END ---
                End If

                Dim resIDs = String.Join(",", reservationsToCheckout.Select(Function(r) r.ReservationID))
                Dim resSql = $"UPDATE reservations SET ReservationStatus = 'Checked Out', ActualCheckOutDateTime = NOW(), IsLoyaltyApplied = TRUE WHERE ReservationID IN ({resIDs});"
                Using cmd As New MySqlCommand(resSql, conn, trans)
                    cmd.ExecuteNonQuery()
                End Using

                Dim roomIDs = reservationsToCheckout.Select(Function(r) r.RoomID).Distinct().ToList()
                Dim roomSql = $"UPDATE rooms SET CurrentStatus = 'Dirty' WHERE RoomID IN ({String.Join(",", roomIDs)});"
                Using cmd As New MySqlCommand(roomSql, conn, trans)
                    cmd.ExecuteNonQuery()
                End Using

                Dim totalNightsStayed = reservationsToCheckout.Sum(Function(r) r.NumberOfNights)
                Dim guestSql = "UPDATE guests SET TotalNights = TotalNights + @Nights, LastStayDate = CURDATE() WHERE GuestID = @GuestID;"
                Using cmd As New MySqlCommand(guestSql, conn, trans)
                    cmd.Parameters.AddWithValue("@Nights", totalNightsStayed)
                    cmd.Parameters.AddWithValue("@GuestID", guestId)
                    cmd.ExecuteNonQuery()
                End Using

                HandleLoyaltyPoints(conn, trans)
                CheckAndUpgradeTier(conn, trans)

                trans.Commit()
                MsgBox("Checkout successful!", MsgBoxStyle.Information)
                GenerateSimpleReceiptPdf()
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                MsgBox($"Checkout failed: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' REVISED: Generates a simple receipt summarizing the checked-out rooms.
    ''' </summary>
    Private Sub GenerateSimpleReceiptPdf()
        Try
            Dim doc As New Document(New Rectangle(227, 350), 10, 10, 10, 10) ' Made slightly taller for multiple rooms
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"SimpleReceipt_{guestName.Replace(" ", "")}_{DateTime.Now:yyyyMMddHHmmss}.pdf")
            PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            doc.Open()

            Dim boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)
            Dim normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 8)
            Dim hotelDetails As Dictionary(Of String, String) = modDB.GetHotelDetails()

            doc.Add(New Paragraph(hotelDetails("HotelName"), boldFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Add(New Paragraph("OFFICIAL RECEIPT", normalFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph($"Date: {DateTime.Now:dd MMM yyyy hh:mm tt}", normalFont))
            doc.Add(New Paragraph($"Guest: {guestName}", normalFont))
            doc.Add(New Paragraph("Rooms Checked Out:", normalFont))
            For Each res In reservationsToCheckout
                doc.Add(New Paragraph($" - Room {res.RoomNumber}", normalFont))
            Next
            doc.Add(New Paragraph("---------------------------------", normalFont))
            doc.Add(New Paragraph(" "))

            Dim totalPaid As Decimal = remainingBalance
            If totalPaid < 0 Then totalPaid = 0

            Dim totalsTable As New PdfPTable(2)
            totalsTable.WidthPercentage = 100
            totalsTable.SetWidths({50, 50})
            totalsTable.AddCell(GetNoBorderCell("Total Paid:", Element.ALIGN_LEFT, boldFont))
            totalsTable.AddCell(GetNoBorderCell(totalPaid.ToString("C"), Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell("Method:", Element.ALIGN_LEFT, normalFont))
            totalsTable.AddCell(GetNoBorderCell(cboPaymentMethod.Text, Element.ALIGN_RIGHT, normalFont))
            doc.Add(totalsTable)

            ' NEW: Add cash tendered and change details if the payment method was cash
            If cboPaymentMethod.Text.Equals("Cash", StringComparison.OrdinalIgnoreCase) AndAlso Not String.IsNullOrWhiteSpace(txtCashTendered.Text) Then
                Dim cashDetailsTable As New PdfPTable(2)
                cashDetailsTable.WidthPercentage = 100
                cashDetailsTable.SetWidths({50, 50})
                cashDetailsTable.SpacingBefore = 5 ' Add a little space

                ' Try to parse the tendered amount to format it as currency
                Dim cashTenderedValue As Decimal
                If Decimal.TryParse(txtCashTendered.Text, cashTenderedValue) Then
                    cashDetailsTable.AddCell(GetNoBorderCell("Cash Tendered:", Element.ALIGN_LEFT, normalFont))
                    cashDetailsTable.AddCell(GetNoBorderCell(cashTenderedValue.ToString("C"), Element.ALIGN_RIGHT, normalFont))
                    cashDetailsTable.AddCell(GetNoBorderCell("Change:", Element.ALIGN_LEFT, normalFont))
                    cashDetailsTable.AddCell(GetNoBorderCell(lblChangeDue.Text, Element.ALIGN_RIGHT, normalFont)) ' Re-use the text from the change label
                    doc.Add(cashDetailsTable)
                End If
            End If
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph("---------------------------------", normalFont))
            doc.Add(New Paragraph("Thank you!", boldFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Close()

            MsgBox($"Simple receipt saved to your desktop.", MsgBoxStyle.Information, "Receipt Generated")
            System.Diagnostics.Process.Start(filePath)
        Catch ex As Exception
            MsgBox($"Could not generate the simple receipt PDF.{vbCrLf}{ex.Message}", MsgBoxStyle.Exclamation, "PDF Error")
        End Try
    End Sub

#Region "Loyalty and Tier Logic"
    Private Sub HandleLoyaltyPoints(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction)
        Dim pointsUsed As Integer = CInt(numPointsToUse.Value)
        If pointsUsed > 0 Then
            Dim deductSql = "UPDATE guests SET TotalLoyaltyPoints = TotalLoyaltyPoints - @PointsUsed WHERE GuestID = @GuestID;"
            Using cmd As New MySqlCommand(deductSql, conn, trans)
                cmd.Parameters.AddWithValue("@PointsUsed", pointsUsed)
                cmd.Parameters.AddWithValue("@GuestID", guestId)
                cmd.ExecuteNonQuery()
            End Using
            Dim logDeductSql = "INSERT INTO loyaltytransactions (GuestID, PointsChange, TransactionType, Description, AssociatedReservationID) VALUES (@GuestID, @Points, 'Redemption', 'Used points for discount on checkout', @ResID);"
            Using cmd As New MySqlCommand(logDeductSql, conn, trans)
                cmd.Parameters.AddWithValue("@GuestID", guestId)
                cmd.Parameters.AddWithValue("@Points", -pointsUsed)
                cmd.Parameters.AddWithValue("@ResID", reservationIdsToCheckout(0))
                cmd.ExecuteNonQuery()
            End Using
        End If

        Dim pointsToAdd As Integer = 0
        For Each res In reservationsToCheckout
            Dim roomTypeID As Integer = 0
            Dim getTypeSql = "SELECT RoomTypeID FROM rooms WHERE RoomID = @RoomID;"
            Using cmd As New MySqlCommand(getTypeSql, conn, trans)
                cmd.Parameters.AddWithValue("@RoomID", res.RoomID)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    roomTypeID = CInt(result)
                End If
            End Using
            pointsToAdd += (roomTypeID * 100)
        Next

        If pointsToAdd > 0 Then
            Dim addSql = "UPDATE guests SET TotalLoyaltyPoints = TotalLoyaltyPoints + @PointsToAdd WHERE GuestID = @GuestID;"
            Using cmd As New MySqlCommand(addSql, conn, trans)
                cmd.Parameters.AddWithValue("@PointsToAdd", pointsToAdd)
                cmd.Parameters.AddWithValue("@GuestID", guestId)
                cmd.ExecuteNonQuery()
            End Using
            Dim logAddSql = "INSERT INTO loyaltytransactions (GuestID, PointsChange, TransactionType, Description, AssociatedReservationID) VALUES (@GuestID, @Points, 'Earned', 'Points earned from stay', @ResID);"
            Using cmd As New MySqlCommand(logAddSql, conn, trans)
                cmd.Parameters.AddWithValue("@GuestID", guestId)
                cmd.Parameters.AddWithValue("@Points", pointsToAdd)
                cmd.Parameters.AddWithValue("@ResID", reservationIdsToCheckout(0))
                cmd.ExecuteNonQuery()
            End Using
        End If
    End Sub

    Private Sub CheckAndUpgradeTier(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction)
        Dim totalNights As Integer = 0
        Dim currentTierID As Integer = 0
        Dim getSql As String = "SELECT TotalNights, LoyaltyTierID FROM guests WHERE GuestID = @GuestID;"
        Using getCmd As New MySqlCommand(getSql, conn, trans)
            getCmd.Parameters.AddWithValue("@GuestID", guestId)
            Using reader = getCmd.ExecuteReader()
                If reader.Read() Then
                    totalNights = CInt(reader("TotalNights"))
                    If Not IsDBNull(reader("LoyaltyTierID")) Then
                        currentTierID = CInt(reader("LoyaltyTierID"))
                    End If
                End If
            End Using
        End Using

        Dim newTierID As Integer = currentTierID
        Dim getNewTierSql As String = "SELECT TierID FROM loyaltytiers WHERE MinNightsRequired <= @TotalNights ORDER BY MinNightsRequired DESC LIMIT 1;"
        Using tierCmd As New MySqlCommand(getNewTierSql, conn, trans)
            tierCmd.Parameters.AddWithValue("@TotalNights", totalNights)
            Dim result = tierCmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                newTierID = CInt(result)
            End If
        End Using

        If newTierID > currentTierID Then
            Dim updateSql As String = "UPDATE guests SET LoyaltyTierID = @NewTierID WHERE GuestID = @GuestID;"
            Using updateCmd As New MySqlCommand(updateSql, conn, trans)
                updateCmd.Parameters.AddWithValue("@NewTierID", newTierID)
                updateCmd.Parameters.AddWithValue("@GuestID", guestId)
                updateCmd.ExecuteNonQuery()
            End Using
        End If
    End Sub
#End Region

#Region "PDF Helper Functions"
    Private Function GetBlueHeaderCell(text As String, alignment As Integer) As PdfPCell
        Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE)
        Dim cell As New PdfPCell(New Phrase(text, headerFont))
        cell.BackgroundColor = New BaseColor(63, 81, 181)
        cell.HorizontalAlignment = alignment
        cell.Padding = 5
        Return cell
    End Function

    Private Function GetDetailCell(text As String, alignment As Integer) As PdfPCell
        Dim normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9)
        Dim cell As New PdfPCell(New Phrase(text, normalFont))
        cell.HorizontalAlignment = alignment
        cell.Padding = 5
        Return cell
    End Function

    Private Function GetNoBorderCell(text As String, alignment As Integer, font As Font) As PdfPCell
        Dim cell As New PdfPCell(New Phrase(text, font))
        cell.Border = 0
        cell.HorizontalAlignment = alignment
        cell.Padding = 5
        Return cell
    End Function
#End Region
    Private Sub cboPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentMethod.SelectedIndexChanged
        ' Check if the selected payment method is "Cash" (case-insensitive)
        Dim isCash As Boolean = (cboPaymentMethod.Text.Equals("Cash", StringComparison.OrdinalIgnoreCase))

        ' Show or hide the cash-related controls
        lblCashTendered.Visible = isCash
        txtCashTendered.Visible = isCash
        lblChangeDue.Visible = isCash
        lblChangeDue.Visible = isCash

        ' Clear the cash fields if another payment method is chosen
        If Not isCash Then
            txtCashTendered.Clear()
            lblChangeDue.Text = ""
        End If
    End Sub
    Private Sub txtCashTendered_TextChanged(sender As Object, e As EventArgs) Handles txtCashTendered.TextChanged
        Dim cashTendered As Decimal

        ' Try to convert the input text to a number
        If Decimal.TryParse(txtCashTendered.Text, cashTendered) Then
            ' Ensure the amount tendered is enough to cover the bill
            If cashTendered >= remainingBalance Then
                Dim change As Decimal = cashTendered - remainingBalance
                lblChangeDue.Text = change.ToString("C")
            Else
                ' If not enough cash is entered, show an empty or warning text
                lblChangeDue.Text = ""
            End If
        Else
            ' If the input is not a valid number, clear the change label
            lblChangeDue.Text = ""
        End If
    End Sub
End Class