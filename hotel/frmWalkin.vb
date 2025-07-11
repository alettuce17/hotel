Imports MySql.Data.MySqlClient
Imports System.IO
' Add the imports for the PDF library. Make sure you have installed the iTextSharp NuGet package.
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmWalkin

#Region "Class-level Variables & Structures"
    ' A simple class to hold addon details for the checklistbox
    Private Class AddonItem
        Public Property Name As String
        Public Property Price As Decimal
        Public Overrides Function ToString() As String
            Return $"{Name} - {Price:C}"
        End Function
    End Class

    Private Structure RoomSelection
        Dim RoomTypeID As Integer, TypeName As String, PricePerNight As Decimal
    End Structure
    Private selectedRoomsList As New List(Of RoomSelection)
    Private selectedGuestID As Integer = 0, numberOfNights As Integer = 1, availablePoints As Integer = 0
    Private pointsToUse As Integer = 0, addonsTotalPrice As Decimal = 0, isNewGuest As Boolean = False
    Private finalTotalAmount As Decimal = 0
    Private taxRate As Decimal = 0 ' To hold the hotel's tax rate
    Private taxAmount As Decimal = 0 ' To hold the calculated tax amount
    Private tempNewGuestPassword As String = "" ' To hold the temporary password for the PDF

    Private currentStep As Integer = 1
#End Region

#Region "Form Load & Navigation"
    Private Sub frmWalkin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "New Reservation"
        GoToStep(1)
        dtpCheckin.MinDate = DateTime.Today
        dtpCheckin.Value = DateTime.Today
        dtpCheckout.Value = DateTime.Today.AddDays(1)
        taxRate = modDB.GetTaxRate()
        LoadRoomTypes()
        cboPaymentMethod.SelectedIndex = 0
    End Sub

    Private Sub GoToStep(targetStep As Integer)
        currentStep = targetStep
        pnlStep1.Visible = (targetStep = 1)
        pnlStep2.Visible = (targetStep = 2)
        pnlStep3.Visible = (targetStep = 3)
        pnlStep4.Visible = (targetStep = 4)
        btnBack.Visible = (targetStep > 1)
        btnNext.Visible = (targetStep < 4)
        btnCompleteCheckin.Visible = (targetStep = 4)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Select Case currentStep
            Case 1
                If lbSelectedRooms.Items.Count = 0 Then
                    MsgBox("You must add at least one room to the booking.", MsgBoxStyle.Exclamation) : Return
                End If
                GoToStep(2)
            Case 2
                If selectedGuestID = 0 AndAlso String.IsNullOrWhiteSpace(txtFirstName.Text) Then
                    MsgBox("Please either search for a returning guest or enter details for a new guest.", MsgBoxStyle.Exclamation) : Return
                End If
                LoadAddons() ' Load all addons when first entering the step
                GoToStep(3)
            Case 3
                CalculateTotals()
                GoToStep(4)
        End Select
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentStep > 1 Then GoToStep(currentStep - 1)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBox("Are you sure you want to cancel this reservation?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then Me.Close()
    End Sub
#End Region

#Region "Step 1: Room Selection"

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckin.ValueChanged, dtpCheckout.ValueChanged
        If dtpCheckin.Value.Date < DateTime.Today.Date Then
            MsgBox("Check-in date cannot be in the past.", MsgBoxStyle.Critical)
            dtpCheckin.Value = DateTime.Today
            Return
        End If
        If dtpCheckout.Value.Date <= dtpCheckin.Value.Date Then
            dtpCheckout.Value = dtpCheckin.Value.AddDays(1)
        End If
        selectedRoomsList.Clear()
        lbSelectedRooms.Items.Clear()
        LoadRoomTypes()
    End Sub

    Private Sub LoadRoomTypes()
        Dim sql As String = "SELECT rt.RoomTypeID, rt.TypeName, rt.Description, COUNT(r.RoomID) AS AvailableCount, MIN(r.BasePricePerNight) AS Price " &
                            "FROM roomtypes rt " &
                            "JOIN rooms r ON rt.RoomTypeID = r.RoomTypeID " &
                            "WHERE r.RoomID NOT IN (" &
                            "  SELECT DISTINCT RoomID FROM reservations WHERE NOT (CheckOutDate <= @StartDate OR CheckInDate >= @EndDate)" &
                            ") AND r.CurrentStatus <> 'Under Maintenance' " &
                            "GROUP BY rt.RoomTypeID, rt.TypeName, rt.Description " &
                            "HAVING COUNT(r.RoomID) > 0 " &
                            "ORDER BY rt.TypeName;"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@StartDate", dtpCheckin.Value.Date)
                    cmd.Parameters.AddWithValue("@EndDate", dtpCheckout.Value.Date)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvRoomTypes.DataSource = dt
                End Using
            Catch ex As Exception
                MsgBox($"Could not load room types.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
        dgvRoomTypes.ReadOnly = True
        dgvRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRoomTypes.MultiSelect = False
        If dgvRoomTypes.Columns.Count > 0 Then
            dgvRoomTypes.Columns("RoomTypeID").Visible = False
            dgvRoomTypes.Columns("TypeName").HeaderText = "Room Type"
            dgvRoomTypes.Columns("AvailableCount").HeaderText = "Available"
            dgvRoomTypes.Columns("Price").DefaultCellStyle.Format = "c"
        End If
    End Sub

    Private Sub btnAddRoom_Click(sender As Object, e As EventArgs) Handles btnAddRoom.Click
        If dgvRoomTypes.SelectedRows.Count = 0 Then
            MsgBox("Please select a room type from the list on the left.", MsgBoxStyle.Information) : Return
        End If
        Dim selectedRow = dgvRoomTypes.SelectedRows(0)
        Dim selectedTypeID As Integer = CInt(selectedRow.Cells("RoomTypeID").Value)
        Dim totalAvailable As Integer = CInt(selectedRow.Cells("AvailableCount").Value)
        Dim quantityToAdd As Integer = CInt(numQuantity.Value)
        Dim alreadyInCartCount As Integer = 0
        For Each room In selectedRoomsList
            If room.RoomTypeID = selectedTypeID Then
                alreadyInCartCount += 1
            End If
        Next
        Dim trulyAvailable As Integer = totalAvailable - alreadyInCartCount
        If quantityToAdd > trulyAvailable Then
            MsgBox($"You cannot add {quantityToAdd} rooms of this type." & vbCrLf &
                   $"There are only {trulyAvailable} left for this booking.", MsgBoxStyle.Exclamation)
            Return
        End If
        For i As Integer = 1 To quantityToAdd
            Dim selection As New RoomSelection With {
                .RoomTypeID = selectedTypeID,
                .TypeName = selectedRow.Cells("TypeName").Value.ToString(),
                .PricePerNight = CDec(selectedRow.Cells("Price").Value)
            }
            selectedRoomsList.Add(selection)
            lbSelectedRooms.Items.Add($"{selection.TypeName} - {selection.PricePerNight:C}")
        Next
    End Sub

    Private Sub btnRemoveRoom_Click(sender As Object, e As EventArgs) Handles btnRemoveRoom.Click
        If lbSelectedRooms.SelectedIndex = -1 Then
            MsgBox("Please select a room from the booking list to remove.", MsgBoxStyle.Information) : Return
        End If
        Dim selectedIndex As Integer = lbSelectedRooms.SelectedIndex
        selectedRoomsList.RemoveAt(selectedIndex)
        lbSelectedRooms.Items.RemoveAt(selectedIndex)
    End Sub
#End Region

#Region "Step 2: Guest Information"
    Private Sub btnSearchGuest_Click(sender As Object, e As EventArgs) Handles btnSearchGuest.Click
        Dim searchTerm As String = txtSearchGuest.Text.Trim()
        If String.IsNullOrWhiteSpace(searchTerm) Then
            MsgBox("Please enter a name or email to search.", MsgBoxStyle.Information) : Return
        End If
        Dim sql As String = "SELECT g.GuestID, u.FirstName, u.LastName, u.Email, u.PhoneNumber, g.TotalLoyaltyPoints " &
                            "FROM guests g JOIN users u ON g.UserID = u.UserID " &
                            "WHERE u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm OR u.Email LIKE @SearchTerm;"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvGuestResults.DataSource = dt
                End Using
                If dgvGuestResults.Rows.Count = 0 Then
                    MsgBox("No guests found matching your search.", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox($"An error occurred while searching for guests.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
        dgvGuestResults.ReadOnly = True
        dgvGuestResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If dgvGuestResults.Columns.Count > 0 Then dgvGuestResults.Columns("GuestID").Visible = False
    End Sub

    Private Sub dgvGuestResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGuestResults.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvGuestResults.Rows(e.RowIndex)
            selectedGuestID = CInt(row.Cells("GuestID").Value)
            txtFirstName.Text = row.Cells("FirstName").Value.ToString()
            txtLastName.Text = row.Cells("LastName").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()
            txtPhone.Text = row.Cells("PhoneNumber").Value.ToString()
            availablePoints = CInt(row.Cells("TotalLoyaltyPoints").Value)
            lblGuestPoints.Text = $"Available Points: {availablePoints}"
            gbGuestDetails.Text = "Guest Details (Existing Guest)"
        End If
    End Sub
#End Region

#Region "Step 3: Addons"
    ''' <summary>
    ''' Loads addons, optionally filtering by a search term.
    ''' </summary>
    Private Sub LoadAddons(Optional searchTerm As String = "")
        clbAddons.Items.Clear()
        Dim sql As String = "SELECT AddonName, Price FROM addons "
        ' If a search term is provided, add a WHERE clause to the query
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            sql &= "WHERE AddonName LIKE @SearchTerm "
        End If
        sql &= "ORDER BY AddonName;"

        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            Try
                ' Add the parameter only if it's needed
                If Not String.IsNullOrWhiteSpace(searchTerm) Then
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
                End If

                conn.Open()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim item As New AddonItem With {
                            .Name = reader("AddonName").ToString(),
                            .Price = CDec(reader("Price"))
                        }
                        clbAddons.Items.Add(item, False)
                    End While
                End Using
            Catch ex As Exception
                MsgBox($"Could not load addons.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Handles the click of the new search button for addons.
    ''' </summary>
    Private Sub btnSearchAddons_Click(sender As Object, e As EventArgs) Handles btnSearchAddons.Click
        LoadAddons(txtSearchAddons.Text)
    End Sub
#End Region

#Region "Step 4: Confirmation & Finalization"
    Private Sub CalculateTotals()
        numberOfNights = CInt((dtpCheckout.Value - dtpCheckin.Value).TotalDays)
        If numberOfNights <= 0 Then numberOfNights = 1
        Dim roomCost As Decimal = 0
        For Each room In selectedRoomsList
            roomCost += (room.PricePerNight * numberOfNights)
        Next
        addonsTotalPrice = 0
        For Each item As AddonItem In clbAddons.CheckedItems
            addonsTotalPrice += item.Price
        Next
        Dim subtotal As Decimal = roomCost + addonsTotalPrice
        taxAmount = subtotal * (taxRate / 100)
        lblSummary.Text = $"Total Rooms: {lbSelectedRooms.Items.Count}" & vbCrLf &
                          $"Dates: {dtpCheckin.Value:d} to {dtpCheckout.Value:d} ({numberOfNights} nights)" & vbCrLf &
                          $"Room Subtotal: {roomCost:C}" & vbCrLf &
                          $"Addons: {addonsTotalPrice:C}" & vbCrLf &
                          $"--------------------" & vbCrLf &
                          $"Subtotal: {subtotal:C}" & vbCrLf &
                          $"Tax ({taxRate}%): {taxAmount:C}"
        Dim phpValue As Decimal = (availablePoints / 200) * 40
        lblAvailablePoints.Text = $"Available Points: {availablePoints} (worth {phpValue:C})"
        numPointsToUse.Maximum = availablePoints
        numPointsToUse.Value = 0
        pointsToUse = 0
        UpdateFinalTotal()
    End Sub

    Private Sub btnApplyPoints_Click(sender As Object, e As EventArgs) Handles btnApplyPoints.Click
        pointsToUse = CInt(numPointsToUse.Value)
        UpdateFinalTotal()
    End Sub

    Private Sub UpdateFinalTotal()
        Dim roomCost As Decimal = 0
        For Each room In selectedRoomsList
            roomCost += (room.PricePerNight * numberOfNights)
        Next
        addonsTotalPrice = 0
        For Each item As AddonItem In clbAddons.CheckedItems
            addonsTotalPrice += item.Price
        Next
        Dim subtotal As Decimal = roomCost + addonsTotalPrice
        taxAmount = subtotal * (taxRate / 100)
        Dim discount As Decimal = (pointsToUse / 200) * 40
        finalTotalAmount = subtotal + taxAmount - discount
        lblTotal.Text = $"Subtotal: {subtotal:C}" & vbCrLf &
                        $"Tax ({taxRate}%): {taxAmount:C}" & vbCrLf &
                        $"Loyalty Discount: -{discount:C}" & vbCrLf &
                        $"--------------------" & vbCrLf &
                        $"FINAL TOTAL: {finalTotalAmount:C}"
    End Sub

    Private Sub btnCompleteCheckin_Click(sender As Object, e As EventArgs) Handles btnCompleteCheckin.Click
        If MsgBox("Are you ready to finalize this booking?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return
        Dim guestIDForReservation As Integer = selectedGuestID
        isNewGuest = (guestIDForReservation = 0)
        Dim newReservationIDs As New List(Of Integer)
        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                If isNewGuest Then
                    guestIDForReservation = CreateNewGuest(conn, transaction)
                    If guestIDForReservation = 0 Then Throw New Exception("Failed to create new guest profile.")
                End If
                For Each roomSelection In selectedRoomsList
                    Dim isTodayCheckin As Boolean = (dtpCheckin.Value.Date = DateTime.Today)
                    Dim reservationStatus As String = If(isTodayCheckin, "Checked In", "Confirmed")
                    Dim actualCheckinTime As Object = If(isTodayCheckin, CType(DateTime.Now, Object), DBNull.Value)
                    Dim roomIDToBook As Integer = FindAvailableRoomID(roomSelection.RoomTypeID, conn, transaction)
                    If roomIDToBook = 0 Then Throw New Exception($"No available rooms of type '{roomSelection.TypeName}' left.")
                    If isTodayCheckin Then
                        UpdateRoomStatus(conn, transaction, roomIDToBook, "Occupied")
                    End If
                    Dim reservationID As Integer = CreateReservationAndPayment(conn, transaction, guestIDForReservation, roomIDToBook, roomSelection.PricePerNight, reservationStatus, actualCheckinTime)
                    newReservationIDs.Add(reservationID)
                Next
                DeductLoyaltyPoints(conn, transaction, guestIDForReservation, newReservationIDs)
                transaction.Commit()
                MsgBox("Booking successful! All records have been saved.", MsgBoxStyle.Information, "Success")
                GenerateReceiptPdf(newReservationIDs)
                modDB.Logs("New Reservation", "Reservations", $"New booking created for {newReservationIDs.Count} rooms.", "reservations", newReservationIDs(0))
                Me.Close()
            Catch ex As Exception
                transaction.Rollback()
                MsgBox($"An error occurred. The booking was not completed.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical, "Transaction Error")
            End Try
        End Using
    End Sub

    Private Function CreateNewGuest(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction) As Integer
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse String.IsNullOrWhiteSpace(txtLastName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) Then
            Throw New Exception("First Name, Last Name, and Email are required for new guests.")
        End If
        Dim newUserID As Integer = 0
        Dim userSql As String = "INSERT INTO users (Username, PasswordHash, Email, PhoneNumber, FirstName, LastName, IsActive) VALUES (@Username, @PasswordHash, @Email, @PhoneNumber, @FirstName, @LastName, 1);"
        Using userCmd As New MySqlCommand(userSql, conn, trans)
            tempNewGuestPassword = Guid.NewGuid().ToString().Substring(0, 8)
            userCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim())
            userCmd.Parameters.AddWithValue("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(tempNewGuestPassword))
            userCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
            userCmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text.Trim())
            userCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
            userCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
            userCmd.ExecuteNonQuery()
            newUserID = CInt(userCmd.LastInsertedId)
        End Using
        If newUserID = 0 Then Throw New Exception("Failed to create the user profile.")
        Dim newGuestID As Integer = 0
        Dim guestSql As String = "INSERT INTO guests (UserID, LoyaltyMemberSince, TotalLoyaltyPoints) VALUES (@UserID, CURDATE(), 200);"
        Using guestCmd As New MySqlCommand(guestSql, conn, trans)
            guestCmd.Parameters.AddWithValue("@UserID", newUserID)
            guestCmd.ExecuteNonQuery()
            newGuestID = CInt(guestCmd.LastInsertedId)
        End Using
        Dim logSql = "INSERT INTO loyaltytransactions (GuestID, PointsChange, TransactionType, Description) VALUES (@GuestID, 200, 'Bonus', 'New Member Sign-up Bonus');"
        Using logCmd As New MySqlCommand(logSql, conn, trans)
            logCmd.Parameters.AddWithValue("@GuestID", newGuestID)
            logCmd.ExecuteNonQuery()
        End Using
        Return newGuestID
    End Function

    Private Function FindAvailableRoomID(ByVal roomTypeID As Integer, ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction) As Integer
        Dim roomID As Integer = 0
        Dim sql As String = "SELECT RoomID FROM rooms WHERE RoomTypeID = @RoomTypeID AND RoomID NOT IN (SELECT RoomID FROM reservations WHERE NOT (CheckOutDate <= @StartDate OR CheckInDate >= @EndDate)) LIMIT 1 FOR UPDATE;"
        Using cmd As New MySqlCommand(sql, conn, trans)
            cmd.Parameters.AddWithValue("@RoomTypeID", roomTypeID)
            cmd.Parameters.AddWithValue("@StartDate", dtpCheckin.Value.Date)
            cmd.Parameters.AddWithValue("@EndDate", dtpCheckout.Value.Date)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                roomID = CInt(result)
            End If
        End Using
        Return roomID
    End Function

    Private Sub UpdateRoomStatus(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction, ByVal roomID As Integer, ByVal newStatus As String)
        Dim updateSql = "UPDATE rooms SET CurrentStatus = @Status WHERE RoomID = @RoomID;"
        Using updateCmd As New MySqlCommand(updateSql, conn, trans)
            updateCmd.Parameters.AddWithValue("@Status", newStatus)
            updateCmd.Parameters.AddWithValue("@RoomID", roomID)
            updateCmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function CreateReservationAndPayment(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction, ByVal guestID As Integer, ByVal roomID As Integer, ByVal price As Decimal, ByVal resStatus As String, ByVal checkinTime As Object) As Integer
        Dim subtotalPerRoom As Decimal = (price * numberOfNights) + (addonsTotalPrice / selectedRoomsList.Count)
        Dim taxPerRoom As Decimal = taxAmount / selectedRoomsList.Count
        Dim resSql As String = "INSERT INTO reservations (GuestID, RoomID, CheckInDate, CheckOutDate, ActualCheckInDateTime, NumberOfAdults, TotalReservationAmount, ReservationStatus, SourceOfBooking, ConfirmationCode, BookedByStaffID) " &
                               "VALUES (@GuestID, @RoomID, @CheckInDate, @CheckOutDate, @ActualCheckin, @Adults, @Total, @Status, 'New Reservation', @ConfCode, @StaffID);"
        Dim newReservationID As Integer = 0
        Using resCmd As New MySqlCommand(resSql, conn, trans)
            resCmd.Parameters.AddWithValue("@GuestID", guestID)
            resCmd.Parameters.AddWithValue("@RoomID", roomID)
            resCmd.Parameters.AddWithValue("@CheckInDate", dtpCheckin.Value)
            resCmd.Parameters.AddWithValue("@CheckOutDate", dtpCheckout.Value)
            resCmd.Parameters.AddWithValue("@ActualCheckin", checkinTime)
            resCmd.Parameters.AddWithValue("@Adults", 2)
            resCmd.Parameters.AddWithValue("@Total", subtotalPerRoom)
            resCmd.Parameters.AddWithValue("@Status", resStatus)
            resCmd.Parameters.AddWithValue("@ConfCode", $"CONF-{Guid.NewGuid().ToString().Substring(0, 12).ToUpper()}")
            resCmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
            resCmd.ExecuteNonQuery()
            newReservationID = CInt(resCmd.LastInsertedId)
        End Using
        Dim paymentSql As String = "INSERT INTO payments (ReservationID, PaymentAmount, TaxAmount, PaymentMethod, ProcessedByStaffID) VALUES (@ResID, @Amount, @Tax, @Method, @StaffID);"
        Using payCmd As New MySqlCommand(paymentSql, conn, trans)
            payCmd.Parameters.AddWithValue("@ResID", newReservationID)
            payCmd.Parameters.AddWithValue("@Amount", finalTotalAmount / selectedRoomsList.Count)
            payCmd.Parameters.AddWithValue("@Tax", taxPerRoom)
            payCmd.Parameters.AddWithValue("@Method", cboPaymentMethod.SelectedItem.ToString())
            payCmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
            payCmd.ExecuteNonQuery()
        End Using
        Return newReservationID
    End Function

    Private Sub DeductLoyaltyPoints(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction, ByVal guestID As Integer, ByVal reservationIDs As List(Of Integer))
        If pointsToUse > 0 Then
            Dim updateGuestSql As String = "UPDATE guests SET TotalLoyaltyPoints = TotalLoyaltyPoints - @PointsUsed WHERE GuestID = @GuestID;"
            Using cmd As New MySqlCommand(updateGuestSql, conn, trans)
                cmd.Parameters.AddWithValue("@PointsUsed", pointsToUse)
                cmd.Parameters.AddWithValue("@GuestID", guestID)
                cmd.ExecuteNonQuery()
            End Using
            Dim logSql = "INSERT INTO loyaltytransactions (GuestID, PointsChange, TransactionType, Description, AssociatedReservationID) VALUES (@GuestID, @Points, 'Redemption', 'Used points for discount on booking', @ResID);"
            Using logCmd As New MySqlCommand(logSql, conn, trans)
                logCmd.Parameters.AddWithValue("@GuestID", guestID)
                logCmd.Parameters.AddWithValue("@Points", -pointsToUse)
                logCmd.Parameters.AddWithValue("@ResID", reservationIDs(0))
                logCmd.ExecuteNonQuery()
            End Using
        End If
    End Sub

    Private Sub GenerateReceiptPdf(ByVal reservationIDs As List(Of Integer))
        Try
            Dim doc As New Document(PageSize.A4, 36, 36, 36, 36)
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Receipt_{txtLastName.Text}_{DateTime.Now:yyyyMMdd}.pdf")
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            doc.Open()
            Dim titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22)
            Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE)
            Dim boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9)
            Dim normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9)
            Dim headerBgColor As New BaseColor(63, 81, 181)
            Dim headerTable As New PdfPTable(2)
            headerTable.WidthPercentage = 100
            headerTable.SetWidths({70, 30})
            Dim hotelNameCell As New PdfPCell(New Phrase(modDB.GetHotelName(), titleFont))
            hotelNameCell.Border = 0
            headerTable.AddCell(hotelNameCell)
            Dim logoCell As New PdfPCell()
            logoCell.Border = 0
            headerTable.AddCell(logoCell)
            doc.Add(headerTable)
            doc.Add(New Paragraph(" "))
            Dim detailsTable As New PdfPTable(4)
            detailsTable.WidthPercentage = 100
            detailsTable.SetWidths({25, 25, 25, 25})
            detailsTable.AddCell(GetHeaderCell("INVOICE #"))
            detailsTable.AddCell(GetHeaderCell("DATE"))
            detailsTable.AddCell(GetHeaderCell("GUEST NAME"))
            detailsTable.AddCell(GetHeaderCell("CASHIER"))
            detailsTable.AddCell(New Phrase(reservationIDs(0).ToString(), normalFont))
            detailsTable.AddCell(New Phrase(DateTime.Now.ToString("dd MMM yyyy"), normalFont))
            detailsTable.AddCell(New Phrase($"{txtFirstName.Text} {txtLastName.Text}", normalFont))
            detailsTable.AddCell(New Phrase(modDB.LoggedInUser.FullName, normalFont))
            detailsTable.AddCell(GetHeaderCell("ARRIVAL"))
            detailsTable.AddCell(GetHeaderCell("DEPARTURE"))
            detailsTable.AddCell(New PdfPCell(New Phrase("")) With {.Colspan = 2, .BackgroundColor = headerBgColor})
            detailsTable.AddCell(New Phrase($"{dtpCheckin.Value:dd MMM yyyy} at {modDB.GetCheckInTime()}", normalFont))
            detailsTable.AddCell(New Phrase($"{dtpCheckout.Value:dd MMM yyyy} at {modDB.GetCheckOutTime()}", normalFont))
            detailsTable.AddCell(New PdfPCell(New Phrase("")) With {.Colspan = 2})
            doc.Add(detailsTable)
            doc.Add(New Paragraph(" "))
            Dim itemsTable As New PdfPTable(4)
            itemsTable.WidthPercentage = 100
            itemsTable.SetWidths({50, 20, 10, 20})
            itemsTable.AddCell(GetHeaderCell("DESCRIPTION"))
            itemsTable.AddCell(GetHeaderCell("UNIT PRICE"))
            itemsTable.AddCell(GetHeaderCell("NIGHTS"))
            itemsTable.AddCell(GetHeaderCell("AMOUNT"))
            Dim roomCost As Decimal = 0
            For Each room In selectedRoomsList
                itemsTable.AddCell(New Phrase(room.TypeName, normalFont))
                itemsTable.AddCell(New Phrase(room.PricePerNight.ToString("C"), normalFont))
                itemsTable.AddCell(New Phrase(numberOfNights.ToString(), normalFont))
                itemsTable.AddCell(New Phrase((room.PricePerNight * numberOfNights).ToString("C"), normalFont))
                roomCost += (room.PricePerNight * numberOfNights)
            Next
            doc.Add(itemsTable)
            Dim totalsTable As New PdfPTable(2)
            totalsTable.WidthPercentage = 100
            totalsTable.SetWidths({80, 20})
            totalsTable.AddCell(GetNoBorderCell("Subtotal:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell((roomCost + addonsTotalPrice).ToString("C"), Element.ALIGN_RIGHT, normalFont))
            totalsTable.AddCell(GetNoBorderCell($"Tax ({taxRate}%):", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell(taxAmount.ToString("C"), Element.ALIGN_RIGHT, normalFont))
            totalsTable.AddCell(GetNoBorderCell("Loyalty Discount:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell($"-{(pointsToUse / 200) * 40:C}", Element.ALIGN_RIGHT, normalFont))
            totalsTable.AddCell(GetNoBorderCell("TOTAL:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell(finalTotalAmount.ToString("C"), Element.ALIGN_RIGHT, boldFont))
            doc.Add(totalsTable)
            doc.Add(New Paragraph(" "))
            Dim pointsForThisStay As Integer = 100 * numberOfNights * selectedRoomsList.Count
            Dim pointsTransactionText As String
            Dim newTotalPoints As Integer = availablePoints - pointsToUse
            If dtpCheckin.Value.Date = DateTime.Today.Date Then
                pointsTransactionText = $"Points Earned This Stay: +{pointsForThisStay} pts"
                newTotalPoints += pointsForThisStay
            Else
                pointsTransactionText = $"Points to be Earned: {pointsForThisStay} pts (pending check-in)"
            End If
            If isNewGuest Then
                newTotalPoints += 200
            End If
            Dim loyaltyTable As New PdfPTable(1)
            loyaltyTable.WidthPercentage = 100
            Dim loyaltyHeader As New PdfPCell(New Phrase("Loyalty Points Summary", headerFont))
            loyaltyHeader.BackgroundColor = headerBgColor
            loyaltyTable.AddCell(loyaltyHeader)
            Dim pointsText As String = $"Previous Balance: {availablePoints} pts" &
                                       $"{vbCrLf}Points Redeemed: -{pointsToUse} pts" &
                                       $"{vbCrLf}{pointsTransactionText}"
            If isNewGuest Then
                pointsText &= $"{vbCrLf}New Member Bonus: +200 pts"
            End If
            pointsText &= $"{vbCrLf}--------------------------------" &
                        $"{vbCrLf}New Balance: {newTotalPoints} pts"
            loyaltyTable.AddCell(New Phrase(pointsText, normalFont))
            doc.Add(loyaltyTable)
            doc.Add(New Paragraph(" "))
            If isNewGuest Then
                Dim credentialsTable As New PdfPTable(1)
                credentialsTable.WidthPercentage = 100
                Dim credsHeader As New PdfPCell(New Phrase("Your Online Account Details", headerFont))
                credsHeader.BackgroundColor = headerBgColor
                credentialsTable.AddCell(credsHeader)
                Dim credsText As String = $"Welcome! Use the details below to log in to our website and change your password." &
                                          $"{vbCrLf}Username: {txtEmail.Text.Trim()}" &
                                          $"{vbCrLf}Temporary Password: {tempNewGuestPassword}"
                credentialsTable.AddCell(New Phrase(credsText, normalFont))
                doc.Add(credentialsTable)
            End If
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph("Thank you for choosing " & modDB.GetHotelName(), normalFont) With {.Alignment = Element.ALIGN_CENTER})
            Dim websiteUrl = modDB.GetWebsiteUrl()
            If Not String.IsNullOrEmpty(websiteUrl) Then
                doc.Add(New Paragraph(websiteUrl, normalFont) With {.Alignment = Element.ALIGN_CENTER})
            End If
            doc.Close()
            MsgBox($"Receipt saved to your desktop:{vbCrLf}{filePath}", MsgBoxStyle.Information, "Receipt Generated")
            System.Diagnostics.Process.Start(filePath)
        Catch ex As Exception
            MsgBox($"Could not generate the receipt PDF.{vbCrLf}{ex.Message}", MsgBoxStyle.Exclamation, "PDF Error")
        End Try
    End Sub

    Private Function GetHeaderCell(text As String) As PdfPCell
        Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE)
        Dim cell As New PdfPCell(New Phrase(text, headerFont))
        cell.BackgroundColor = New BaseColor(63, 81, 181) ' Blue
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

End Class
