Imports MySql.Data.MySqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports BCrypt.Net
Imports System.Linq
Imports System.Collections.Generic

Public Class frmNewReservation

#Region "Class-level Variables & Structures"
    ' Structure to hold information about a selected room
    Private Structure RoomSelection
        Public Property ReservationID As Integer
        Public Property RoomID As Integer
        Public Property RoomNumber As String
        Public Property TypeName As String
        Public Property PricePerNight As Decimal
        Public Property ReservationName As String
        Public Property ApplyStatutoryDiscount As Boolean
    End Structure

    Private selectedRoomsList As New List(Of RoomSelection)

    ' --- Guest & Booking Variables ---
    Private selectedGuestID As Integer = 0
    Private statutoryDiscountPercentage As Decimal = 0
    Private guestDiscountType As String = "None"
    Private guestDiscountIDNumber As String = ""
    Private numberOfNights As Integer = 1
    Private estimatedTotalAmount As Decimal = 0, taxRate As Decimal = 0, taxAmount As Decimal = 0
    Private tempNewGuestPassword As String = ""
    Private currentStep As Integer = 1
    Private isFormLoading As Boolean = True

    ' --- Mode Variables ---
    Private isEditMode As Boolean = False
    Private isCheckInMode As Boolean = False
    Private editingReservationID As Integer = 0
    Private requiredRoomTypeID As Integer = 0
    Private requiredRoomTypeName As String = ""

    ' -- Payment Variable --
    Private paymentAmount As Decimal = 0
#End Region

#Region "Constructors and Form Load"
    Public Sub New()
        InitializeComponent()
        isEditMode = False
        isCheckInMode = False
    End Sub

    Public Sub New(ByVal reservationID As Integer)
        InitializeComponent()
        editingReservationID = reservationID
        isEditMode = True
        isCheckInMode = False
    End Sub

    Public Sub New(ByVal reservationID As Integer, ByVal isCopy As Boolean, ByVal isCheckingIn As Boolean)
        InitializeComponent()
        Me.editingReservationID = reservationID
        Me.isCheckInMode = isCheckingIn
        Me.isEditMode = True
    End Sub


    Private Sub frmNewReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isFormLoading = True
        taxRate = modDB.GetTaxRate()
        statutoryDiscountPercentage = modDB.GetStatutoryDiscountPercentage()

        cboPaymentMethod.Items.AddRange(New String() {"Cash", "Credit Card", "Debit Card", "Bank Transfer"})
        cboPaymentMethod.SelectedIndex = 0

        chkPayInFull.Text = "Pay in Full Now"
        chkPayInFull.Checked = False
        txtPaymentAmount.ReadOnly = True

        cboDiscountType.Items.AddRange(New String() {"None", "Senior Citizen", "PWD"})
        cboDiscountType.SelectedIndex = 0

        pnlStep3.Visible = False ' Addons step is skipped

        If isCheckInMode Then
            Me.Text = "Process Guest Check-In"
            btnCompleteBooking.Text = "Confirm Check-In"
            LoadReservationForCheckIn()
        ElseIf isEditMode Then
            Me.Text = "Edit Booking"
            btnCompleteBooking.Text = "Save Changes"
            LoadReservationForEdit()
            pnlStep1.Enabled = True
            pnlStep2.Enabled = True
            GoToStep(1)
        Else ' Creating a brand new reservation
            Me.Text = "Book a Room"
            btnCompleteBooking.Text = "Confirm Booking & Pay"
            GoToStep(1)
            dtpCheckin.MinDate = DateTime.Today
            dtpCheckin.Value = DateTime.Today
            dtpCheckout.Value = DateTime.Today.AddDays(1)
            LoadRoomTypes()
        End If

        isFormLoading = False
    End Sub
#End Region

#Region "Core Data Saving Logic"
    Private Sub btnCompleteBooking_Click(sender As Object, e As EventArgs) Handles btnCompleteBooking.Click
        If isEditMode Or isCheckInMode Then
            SaveChanges()
        Else
            CreateNewBooking()
        End If
    End Sub

    Private Sub CreateNewBooking()
        If cboPaymentMethod.Text.Equals("Cash", StringComparison.OrdinalIgnoreCase) Then
            Dim cashTendered As Decimal = 0
            If Not Decimal.TryParse(txtCashTendered.Text, cashTendered) OrElse cashTendered < paymentAmount Then
                MsgBox("The cash amount tendered is not sufficient to cover the payment due.", MsgBoxStyle.Exclamation, "Insufficient Payment")
                Return
            End If
        End If
        If selectedRoomsList.Count = 0 Then
            MsgBox("You must select at least one room to create a booking.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim confirmationMessage As String = $"This booking requires a payment of {paymentAmount:C}. Proceed?"
        If MsgBox(confirmationMessage, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return

        Dim guestIDForReservation As Integer = selectedGuestID
        Dim isNewGuest As Boolean = (guestIDForReservation = 0)
        Dim newReservationIDs As New List(Of Integer)

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                If isNewGuest Then
                    guestIDForReservation = CreateNewGuest(conn, transaction)
                End If

                UpdateGuestDiscountInfo(conn, transaction, guestIDForReservation)

                Dim paymentID As Integer? = Nothing
                If paymentAmount > 0 Then
                    Dim firstReservationID As Integer = CreateReservationRecord(conn, transaction, guestIDForReservation, selectedRoomsList.First(), Nothing)
                    newReservationIDs.Add(firstReservationID)
                    paymentID = CreateConsolidatedPaymentRecord(conn, transaction, firstReservationID)
                    For i = 1 To selectedRoomsList.Count - 1
                        Dim roomSelection = selectedRoomsList(i)
                        Dim reservationID As Integer = CreateReservationRecord(conn, transaction, guestIDForReservation, roomSelection, paymentID)
                        newReservationIDs.Add(reservationID)
                    Next
                Else
                    For Each roomSelection In selectedRoomsList
                        Dim reservationID As Integer = CreateReservationRecord(conn, transaction, guestIDForReservation, roomSelection, Nothing)
                        newReservationIDs.Add(reservationID)
                    Next
                End If

                transaction.Commit()
                MsgBox("Booking successful! Payment recorded.", MsgBoxStyle.Information, "Success")

                If isNewGuest AndAlso Not String.IsNullOrEmpty(tempNewGuestPassword) Then
                    Dim displayUsername = Sanitize(txtEmail.Text, $"guest_{guestIDForReservation}@hotel.local").ToString()
                    Dim credentialsMessage As String = $"Please provide the following to the guest:{vbCrLf}{vbCrLf}Username: {displayUsername}{vbCrLf}Temporary Password: {tempNewGuestPassword}"
                    MsgBox(credentialsMessage, MsgBoxStyle.Information, "New Guest Account Created")
                End If

                GenerateIndividualReceipts(newReservationIDs)

                modDB.Logs("New Reservation Confirmed", "Reservations", $"New booking for GuestID {guestIDForReservation}. Payment: {paymentAmount:C}", "reservations", newReservationIDs.First())
                Me.Close()

            Catch ex As Exception
                transaction.Rollback()
                MsgBox($"An error occurred while creating the booking: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    Private Sub SaveChanges()
        If isCheckInMode Then
            ' --- CHECK-IN LOGIC ---
            If selectedRoomsList.Count = 0 Then
                MsgBox("You must assign a room before you can check the guest in.", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim assignedRoom = selectedRoomsList.First()
            Dim guestFullName = $"{txtFirstName.Text} {txtLastName.Text}"

            If MsgBox($"This will check in {guestFullName} to Room {assignedRoom.RoomNumber}. Proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
                Return
            End If

            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim resSql = "UPDATE reservations SET RoomID = @RoomID, ReservationStatus = 'Checked In', ActualCheckInDateTime = NOW() WHERE ReservationID = @ResID;"
                    Using cmd As New MySqlCommand(resSql, conn, trans)
                        cmd.Parameters.AddWithValue("@RoomID", assignedRoom.RoomID)
                        cmd.Parameters.AddWithValue("@ResID", Me.editingReservationID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim roomSql = "UPDATE rooms SET CurrentStatus = 'Occupied' WHERE RoomID = @RoomID;"
                    Using cmd As New MySqlCommand(roomSql, conn, trans)
                        cmd.Parameters.AddWithValue("@RoomID", assignedRoom.RoomID)
                        cmd.ExecuteNonQuery()
                    End Using

                    trans.Commit()
                    MsgBox("Guest checked in successfully!", MsgBoxStyle.Information, "Check-In Complete")

                    ' *** Generate a receipt for the check-in ***
                    If selectedRoomsList.Count > 0 Then
                        GenerateSingleReceiptPdf(selectedRoomsList.First(), Me.editingReservationID)
                    End If

                    modDB.Logs("Guest Checked In", "Reservations", $"GuestID {selectedGuestID} checked into RoomID {assignedRoom.RoomID} (ReservationID: {editingReservationID})")
                    Me.DialogResult = DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    trans.Rollback()
                    MsgBox($"Failed to process check-in due to a database error: {ex.Message}", MsgBoxStyle.Critical)
                End Try
            End Using
        Else
            ' --- STANDARD EDIT LOGIC ---
            If MsgBox("Are you sure you want to save these changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim transaction As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim updateGuestSql = "UPDATE users u JOIN guests g ON u.UserID = g.UserID SET u.FirstName = @FirstName, u.LastName = @LastName, u.Email = @Email, u.PhoneNumber = @Phone WHERE g.GuestID = @GuestID;"
                    Using cmd As New MySqlCommand(updateGuestSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@FirstName", Sanitize(txtFirstName.Text, "Valued"))
                        cmd.Parameters.AddWithValue("@LastName", Sanitize(txtLastName.Text, "Guest"))
                        cmd.Parameters.AddWithValue("@Email", Sanitize(txtEmail.Text))
                        cmd.Parameters.AddWithValue("@Phone", Sanitize(txtPhone.Text, "N/A"))
                        cmd.Parameters.AddWithValue("@GuestID", selectedGuestID)
                        cmd.ExecuteNonQuery()
                    End Using
                    transaction.Commit()
                    MsgBox("Reservation updated successfully!", MsgBoxStyle.Information, "Success")
                    modDB.Logs("Reservation Updated", "Reservations", $"Reservation {editingReservationID} was updated.", "reservations", editingReservationID)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Catch ex As Exception
                    transaction.Rollback()
                    MsgBox($"Failed to save changes: {ex.Message}", MsgBoxStyle.Critical, "Error")
                End Try
            End Using
        End If
    End Sub
#End Region

#Region "Database Helper Subroutines"
    Private Function Sanitize(inputText As String, Optional defaultIfEmpty As String = Nothing) As Object
        If String.IsNullOrWhiteSpace(inputText) Then
            If defaultIfEmpty IsNot Nothing Then
                Return defaultIfEmpty
            Else
                Return DBNull.Value
            End If
        Else
            Return inputText.Trim()
        End If
    End Function

    Private Function CreateNewGuest(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction) As Integer
        Dim newUserID As Integer = 0
        Dim userSql As String = "INSERT INTO users (Username, PasswordHash, Email, PhoneNumber, FirstName, LastName, IsActive) VALUES (@Username, @PasswordHash, @Email, @PhoneNumber, @FirstName, @LastName, 1);"
        Using userCmd As New MySqlCommand(userSql, conn, trans)
            tempNewGuestPassword = Guid.NewGuid().ToString().Substring(0, 8)
            Dim tempUserEmail As String = $"guest_{DateTime.Now:yyyyMMddHHmmss}@hotel.local"
            userCmd.Parameters.AddWithValue("@Username", Sanitize(txtEmail.Text, tempUserEmail))
            userCmd.Parameters.AddWithValue("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(tempNewGuestPassword))
            userCmd.Parameters.AddWithValue("@Email", Sanitize(txtEmail.Text, tempUserEmail))
            userCmd.Parameters.AddWithValue("@PhoneNumber", Sanitize(txtPhone.Text, "N/A"))
            userCmd.Parameters.AddWithValue("@FirstName", Sanitize(txtFirstName.Text, "Valued"))
            userCmd.Parameters.AddWithValue("@LastName", Sanitize(txtLastName.Text, "Guest"))
            userCmd.ExecuteNonQuery()
            newUserID = CInt(userCmd.LastInsertedId)
        End Using
        If newUserID = 0 Then Throw New Exception("Failed to create the user profile.")
        Dim newGuestID As Integer = 0
        Dim guestSql As String = "INSERT INTO guests (UserID) VALUES (@UserID);"
        Using guestCmd As New MySqlCommand(guestSql, conn, trans)
            guestCmd.Parameters.AddWithValue("@UserID", newUserID)
            guestCmd.ExecuteNonQuery()
            newGuestID = CInt(guestCmd.LastInsertedId)
        End Using
        Return newGuestID
    End Function

    Private Sub UpdateGuestDiscountInfo(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction, ByVal guestID As Integer)
        Dim sql As String = "UPDATE guests SET DiscountType = @DiscountType, DiscountIDNumber = @DiscountIDNumber WHERE GuestID = @GuestID;"
        Using cmd As New MySqlCommand(sql, conn, trans)
            cmd.Parameters.AddWithValue("@DiscountType", Sanitize(guestDiscountType))
            cmd.Parameters.AddWithValue("@DiscountIDNumber", Sanitize(guestDiscountIDNumber))
            cmd.Parameters.AddWithValue("@GuestID", guestID)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function CreateConsolidatedPaymentRecord(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction, ByVal firstReservationID As Integer) As Integer
        Dim paymentSql As String = "INSERT INTO payments (ReservationID, PaymentAmount, TaxAmount, PaymentMethod, ProcessedByStaffID) VALUES (@ResID, @Amount, @Tax, @Method, @StaffID);"
        Using payCmd As New MySqlCommand(paymentSql, conn, trans)
            payCmd.Parameters.AddWithValue("@ResID", firstReservationID)
            payCmd.Parameters.AddWithValue("@Amount", paymentAmount)
            payCmd.Parameters.AddWithValue("@Tax", taxAmount)
            payCmd.Parameters.AddWithValue("@Method", cboPaymentMethod.SelectedItem.ToString())
            payCmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
            payCmd.ExecuteNonQuery()
            Return CInt(payCmd.LastInsertedId)
        End Using
    End Function

    Private Function CreateReservationRecord(ByVal conn As MySqlConnection, ByVal trans As MySqlTransaction, ByVal guestID As Integer, ByVal roomSelection As RoomSelection, ByVal paymentID As Integer?) As Integer
        Dim roomSubtotal As Decimal = roomSelection.PricePerNight * numberOfNights
        Dim discountToApply As Decimal = 0
        If roomSelection.ApplyStatutoryDiscount Then
            discountToApply = roomSubtotal * (statutoryDiscountPercentage / 100)
        End If
        Dim roomTotalAfterDiscount = roomSubtotal - discountToApply
        Dim roomTax As Decimal = roomTotalAfterDiscount * (taxRate / 100)
        Dim roomTotalWithTax = roomTotalAfterDiscount + roomTax

        Dim isCheckingInNow As Boolean = (dtpCheckin.Value.Date = DateTime.Today.Date)
        Dim reservationStatus As String
        Dim actualCheckInTime As Object

        If isCheckingInNow Then
            reservationStatus = "Checked In"
            actualCheckInTime = DateTime.Now
        Else
            reservationStatus = "Confirmed"
            actualCheckInTime = DBNull.Value
        End If

        Dim resSql As String = "INSERT INTO reservations (GuestID, RoomID, PaymentID, ReservationName, CheckInDate, CheckOutDate, ActualCheckInDateTime, NumberOfAdults, TotalReservationAmount, DiscountAppliedAmount, ReservationStatus, SourceOfBooking, ConfirmationCode, BookedByStaffID) " &
                             "VALUES (@GuestID, @RoomID, @PaymentID, @ReservationName, @CheckInDate, @CheckOutDate, @ActualCheckIn, @Adults, @Total, @Discount, @Status, 'Walk-In', @ConfCode, @StaffID);"

        Dim newReservationID As Integer = 0
        Using resCmd As New MySqlCommand(resSql, conn, trans)
            resCmd.Parameters.AddWithValue("@GuestID", guestID)
            resCmd.Parameters.AddWithValue("@RoomID", roomSelection.RoomID)
            resCmd.Parameters.AddWithValue("@PaymentID", If(paymentID.HasValue, CType(paymentID.Value, Object), DBNull.Value))
            resCmd.Parameters.AddWithValue("@ReservationName", Sanitize(roomSelection.ReservationName))
            resCmd.Parameters.AddWithValue("@CheckInDate", dtpCheckin.Value)
            resCmd.Parameters.AddWithValue("@CheckOutDate", dtpCheckout.Value)
            resCmd.Parameters.AddWithValue("@ActualCheckIn", actualCheckInTime)
            resCmd.Parameters.AddWithValue("@Adults", 2)
            resCmd.Parameters.AddWithValue("@Total", roomTotalWithTax)
            resCmd.Parameters.AddWithValue("@Discount", discountToApply)
            resCmd.Parameters.AddWithValue("@Status", reservationStatus)
            resCmd.Parameters.AddWithValue("@ConfCode", $"CONF-{Guid.NewGuid().ToString().Substring(0, 12).ToUpper()}")
            resCmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)

            resCmd.ExecuteNonQuery()
            newReservationID = CInt(resCmd.LastInsertedId)
        End Using

        If isCheckingInNow Then
            Dim updateRoomSql As String = "UPDATE rooms SET CurrentStatus = 'Occupied' WHERE RoomID = @RoomID;"
            Using updateRoomCmd As New MySqlCommand(updateRoomSql, conn, trans)
                updateRoomCmd.Parameters.AddWithValue("@RoomID", roomSelection.RoomID)
                updateRoomCmd.ExecuteNonQuery()
            End Using
        End If

        Return newReservationID
    End Function
#End Region

#Region "Calculation and UI Logic"
    Private Sub CalculateEstimatedTotal()
        numberOfNights = CInt((dtpCheckout.Value - dtpCheckin.Value).TotalDays)
        If numberOfNights <= 0 Then numberOfNights = 1

        Dim totalRoomCost As Decimal = 0
        Dim totalDiscount As Decimal = 0
        For Each room In selectedRoomsList
            Dim roomSubtotal = room.PricePerNight * numberOfNights
            totalRoomCost += roomSubtotal
            If room.ApplyStatutoryDiscount Then
                totalDiscount += roomSubtotal * (statutoryDiscountPercentage / 100)
            End If
        Next

        Dim subtotal As Decimal = totalRoomCost
        taxAmount = (subtotal - totalDiscount) * (taxRate / 100)
        estimatedTotalAmount = subtotal - totalDiscount + taxAmount

        If chkPayInFull.Checked Then
            paymentAmount = estimatedTotalAmount
        Else
            paymentAmount = estimatedTotalAmount * 0.5
        End If
        txtPaymentAmount.Text = paymentAmount.ToString("C")

        UpdateSummaryDisplay()
    End Sub

    Private Sub UpdateSummaryDisplay()
        Dim roomCost As Decimal = selectedRoomsList.Sum(Function(r) r.PricePerNight * numberOfNights)
        Dim totalDiscount As Decimal = 0
        For Each room In selectedRoomsList
            If room.ApplyStatutoryDiscount Then
                totalDiscount += (room.PricePerNight * numberOfNights) * (statutoryDiscountPercentage / 100)
            End If
        Next

        lblSummary.Text = $"Room Subtotal (Est.): {roomCost:C}" & vbCrLf &
                          $"Discount(s) Applied: -{totalDiscount:C}" & vbCrLf &
                          $"Tax ({taxRate}%): {taxAmount:C}"
        lblTotal.Text = $"--------------------" & vbCrLf &
                        $"ESTIMATED GRAND TOTAL: {estimatedTotalAmount:C}" & vbCrLf &
                        $"Payment Due Now: {paymentAmount:C}" & vbCrLf &
                        $"Balance Due at Checkout: {(estimatedTotalAmount - paymentAmount):C}"
    End Sub

    Private Sub chkPayInFull_CheckedChanged(sender As Object, e As EventArgs) Handles chkPayInFull.CheckedChanged
        CalculateEstimatedTotal()
    End Sub
#End Region

#Region "Form Navigation and Step Logic"
    Private Sub GoToStep(targetStep As Integer)
        currentStep = targetStep
        pnlStep1.Visible = (targetStep = 1)
        pnlStep2.Visible = (targetStep = 2)
        pnlStep3.Visible = False ' Addons step is skipped
        pnlStep4.Visible = (targetStep = 4)

        btnBack.Visible = (targetStep > 1)
        btnNext.Visible = (targetStep < 4)
        btnCompleteBooking.Visible = (targetStep = 4)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Select Case currentStep
            Case 1
                If selectedRoomsList.Count = 0 Then
                    MsgBox("You must add at least one room to the booking.", MsgBoxStyle.Exclamation)
                    Return
                End If
                GoToStep(2)
            Case 2
                If cboDiscountType.SelectedItem.ToString() <> "None" AndAlso String.IsNullOrWhiteSpace(txtDiscountID.Text) Then
                    MsgBox("Please enter an ID number for the selected discount type, or set the type to 'None'.", MsgBoxStyle.Exclamation)
                    Return
                End If
                CalculateEstimatedTotal()
                GoToStep(4)
        End Select
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentStep > 1 Then
            If currentStep = 4 Then
                GoToStep(2)
            Else
                GoToStep(currentStep - 1)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBox("Are you sure you want to cancel this reservation?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then Me.Close()
    End Sub
#End Region

#Region "Room Naming and Selection Logic"
    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckin.ValueChanged, dtpCheckout.ValueChanged
        If isFormLoading Then Return
        If dtpCheckin.Value.Date < DateTime.Today.Date Then
            MsgBox("Check-in date cannot be in the past.", MsgBoxStyle.Exclamation)
            dtpCheckin.Value = DateTime.Today
            Return
        End If
        If dtpCheckout.Value.Date <= dtpCheckin.Value.Date Then
            dtpCheckout.Value = dtpCheckin.Value.AddDays(1)
        End If
        selectedRoomsList.Clear()
        lbSelectedRooms.Items.Clear()
        LoadRoomTypes()
        CalculateEstimatedTotal()
    End Sub

    Private Sub LoadRoomTypes()
        Dim sql As String
        Dim isTodayBooking As Boolean = (dtpCheckin.Value.Date = DateTime.Today.Date)

        If isTodayBooking Then
            sql = "SELECT rt.RoomTypeID, rt.TypeName, rt.Description, COUNT(r.RoomID) AS AvailableCount, MIN(r.BasePricePerNight) AS Price " &
                  "FROM roomtypes rt " &
                  "JOIN rooms r ON rt.RoomTypeID = r.RoomTypeID " &
                  "WHERE r.CurrentStatus = 'Available' " &
                  "GROUP BY rt.RoomTypeID, rt.TypeName, rt.Description " &
                  "HAVING COUNT(r.RoomID) > 0 " &
                  "ORDER BY rt.TypeName;"
        Else
            sql = "SELECT rt.RoomTypeID, rt.TypeName, rt.Description, COUNT(r.RoomID) AS AvailableCount, MIN(r.BasePricePerNight) AS Price " &
                  "FROM roomtypes rt " &
                  "JOIN rooms r ON rt.RoomTypeID = r.RoomTypeID " &
                  "WHERE r.RoomID NOT IN (SELECT res.RoomID FROM reservations res WHERE res.RoomID IS NOT NULL AND res.ReservationStatus <> 'Cancelled' AND NOT (res.CheckOutDate <= @StartDate OR res.CheckInDate >= @EndDate)) " &
                  "GROUP BY rt.RoomTypeID, rt.TypeName, rt.Description " &
                  "HAVING COUNT(r.RoomID) > 0 " &
                  "ORDER BY rt.TypeName;"
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    If Not isTodayBooking Then
                        cmd.Parameters.AddWithValue("@StartDate", dtpCheckin.Value.Date)
                        cmd.Parameters.AddWithValue("@EndDate", dtpCheckout.Value.Date)
                    End If

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
        Dim typeIdToUse As Integer
        Dim typeNameToUse As String

        If isCheckInMode Then
            If selectedRoomsList.Count > 0 Then
                MsgBox("A room has already been assigned. Please remove it first if you wish to select a different one.", MsgBoxStyle.Information)
                Return
            End If
            typeIdToUse = Me.requiredRoomTypeID
            typeNameToUse = Me.requiredRoomTypeName
        Else
            If dgvRoomTypes.SelectedRows.Count = 0 Then
                MsgBox("Please select a room type from the list on the left first.", MsgBoxStyle.Information) : Return
            End If
            Dim selectedGridRow = dgvRoomTypes.SelectedRows(0)
            typeIdToUse = CInt(selectedGridRow.Cells("RoomTypeID").Value)
            typeNameToUse = selectedGridRow.Cells("TypeName").Value.ToString()
        End If

        Dim alreadySelectedIDs = selectedRoomsList.Select(Function(r) r.RoomID).ToList()
        Dim isTodayBooking As Boolean = (dtpCheckin.Value.Date = DateTime.Today.Date)

        Using roomSelectorForm As New frmRoomSelector(typeIdToUse, dtpCheckin.Value, dtpCheckout.Value, alreadySelectedIDs, isTodayBooking)
            If roomSelectorForm.ShowDialog() = DialogResult.OK Then
                Dim reservationName As String = InputBox("Please enter a name for this room's reservation (e.g., Guest's Name, 'Bridal Suite'):", "Assign Reservation Name", $"{txtFirstName.Text} {txtLastName.Text}")
                If String.IsNullOrWhiteSpace(reservationName) Then reservationName = "Valued Guest"

                Dim applyDiscount As Boolean = False
                If cboDiscountType.SelectedItem.ToString() <> "None" AndAlso Not String.IsNullOrWhiteSpace(txtDiscountID.Text) Then
                    If MsgBox($"Apply {cboDiscountType.SelectedItem} discount to this specific room ('{reservationName}')?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = DialogResult.Yes Then
                        applyDiscount = True
                    End If
                End If

                Dim selection As New RoomSelection With {
                    .RoomID = roomSelectorForm.SelectedRoomID,
                    .RoomNumber = roomSelectorForm.SelectedRoomNumber,
                    .TypeName = typeNameToUse,
                    .PricePerNight = roomSelectorForm.SelectedRoomPrice,
                    .ReservationName = reservationName,
                    .ApplyStatutoryDiscount = applyDiscount
                }
                selectedRoomsList.Add(selection)
                lbSelectedRooms.Items.Add($"'{selection.ReservationName}' - Room {selection.RoomNumber} ({selection.TypeName})")
                CalculateEstimatedTotal()
            End If
        End Using
    End Sub

    Private Sub btnRemoveRoom_Click(sender As Object, e As EventArgs) Handles btnRemoveRoom.Click
        If lbSelectedRooms.SelectedIndex = -1 Then
            MsgBox("Please select a room from the booking list to remove.", MsgBoxStyle.Information) : Return
        End If
        Dim selectedIndex As Integer = lbSelectedRooms.SelectedIndex
        selectedRoomsList.RemoveAt(selectedIndex)
        lbSelectedRooms.Items.RemoveAt(selectedIndex)
        CalculateEstimatedTotal()
    End Sub

    Private Sub lbSelectedRooms_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbSelectedRooms.MouseDoubleClick
        Dim index As Integer = Me.lbSelectedRooms.IndexFromPoint(e.Location)
        If index <> ListBox.NoMatches Then
            Dim currentSelection = selectedRoomsList(index)
            Dim newName = InputBox("Enter the new name for this reservation:", "Edit Reservation Name", currentSelection.ReservationName)
            If Not String.IsNullOrWhiteSpace(newName) Then
                currentSelection.ReservationName = newName
                selectedRoomsList(index) = currentSelection
                lbSelectedRooms.Items(index) = $"' {currentSelection.ReservationName}' - Room {currentSelection.RoomNumber} ({currentSelection.TypeName})"
            End If
        End If
    End Sub

    Private Sub btnSearchGuest_Click(sender As Object, e As EventArgs) Handles btnSearchGuest.Click
        Dim searchTerm As String = txtSearchGuest.Text.Trim()
        If String.IsNullOrWhiteSpace(searchTerm) Then Return

        Dim sql As String = "SELECT g.GuestID, u.FirstName, u.LastName, u.Email, u.PhoneNumber, g.DiscountType, g.DiscountIDNumber " &
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
        If dgvGuestResults.Columns.Count > 0 Then
            dgvGuestResults.Columns("GuestID").Visible = False
        End If
    End Sub

    Private Sub dgvGuestResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGuestResults.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvGuestResults.Rows(e.RowIndex)
            selectedGuestID = CInt(row.Cells("GuestID").Value)
            txtFirstName.Text = row.Cells("FirstName").Value.ToString()
            txtLastName.Text = row.Cells("LastName").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()
            txtPhone.Text = row.Cells("PhoneNumber").Value.ToString()

            guestDiscountType = If(IsDBNull(row.Cells("DiscountType").Value), "None", row.Cells("DiscountType").Value.ToString())
            guestDiscountIDNumber = If(IsDBNull(row.Cells("DiscountIDNumber").Value), "", row.Cells("DiscountIDNumber").Value.ToString())
            cboDiscountType.SelectedItem = guestDiscountType
            txtDiscountID.Text = guestDiscountIDNumber
        End If
    End Sub

    Private Sub LoadReservationForCheckIn()
        LoadReservationForEdit()

        gbBookingDetails.Enabled = False
        gbGuestDetails.Enabled = False
        gbPayment.Enabled = False

        dgvRoomTypes.Visible = False
        lblRoomTypes.Text = $"Required Room Type: {requiredRoomTypeName}"
        btnAddRoom.Text = "Assign Room"

        GoToStep(1)
    End Sub

    Private Sub LoadReservationForEdit()
        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim sql As String = "SELECT res.*, g.*, u.*, r.RoomNumber, r.BasePricePerNight, rt.RoomTypeID, rt.TypeName " &
                              "FROM reservations res " &
                              "JOIN guests g ON res.GuestID = g.GuestID " &
                              "JOIN users u ON g.UserID = u.UserID " &
                              "LEFT JOIN rooms r ON res.RoomID = r.RoomID " &
                              "JOIN roomtypes rt ON IFNULL(r.RoomTypeID, res.RoomTypeID) = rt.RoomTypeID " &
                              "WHERE res.ReservationID = @ResID;"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ResID", editingReservationID)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        selectedGuestID = CInt(reader("GuestID"))
                        txtFirstName.Text = reader("FirstName").ToString()
                        txtLastName.Text = reader("LastName").ToString()
                        txtEmail.Text = reader("Email").ToString()
                        txtPhone.Text = reader("PhoneNumber").ToString()
                        dtpCheckin.Value = CDate(reader("CheckInDate"))
                        dtpCheckout.Value = CDate(reader("CheckOutDate"))

                        Me.requiredRoomTypeID = CInt(reader("RoomTypeID"))
                        Me.requiredRoomTypeName = reader("TypeName").ToString()

                        If Not IsDBNull(reader("RoomID")) Then
                            Dim selection As New RoomSelection With {
                                .RoomID = CInt(reader("RoomID")),
                                .RoomNumber = reader("RoomNumber").ToString(),
                                .TypeName = reader("TypeName").ToString(),
                                .PricePerNight = CDec(reader("BasePricePerNight")),
                                .ReservationName = If(IsDBNull(reader("ReservationName")), "Valued Guest", reader("ReservationName").ToString()),
                                .ApplyStatutoryDiscount = (CDec(reader("DiscountAppliedAmount")) > 0)
                            }
                            selectedRoomsList.Add(selection)
                            lbSelectedRooms.Items.Add($"'{selection.ReservationName}' - Room {selection.RoomNumber} ({selection.TypeName})")
                        End If
                    Else
                        MsgBox("Could not find the specified reservation.", MsgBoxStyle.Critical)
                        Me.Close()
                    End If
                End Using
            End Using
        End Using
        CalculateEstimatedTotal()
    End Sub

    Private Sub cboDiscountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDiscountType.SelectedIndexChanged
        If Not isFormLoading Then
            guestDiscountType = cboDiscountType.SelectedItem.ToString()
        End If
    End Sub

    Private Sub txtDiscountID_TextChanged(sender As Object, e As EventArgs) Handles txtDiscountID.TextChanged
        If Not isFormLoading Then
            guestDiscountIDNumber = txtDiscountID.Text
        End If
    End Sub
#End Region

#Region "PDF Generation"
    Private Sub GenerateIndividualReceipts(ByVal reservationIDs As List(Of Integer))
        For i = 0 To selectedRoomsList.Count - 1
            Dim room = selectedRoomsList(i)
            Dim resID = reservationIDs(i)
            GenerateSingleReceiptPdf(room, resID)
        Next
    End Sub

    Private Sub GenerateSingleReceiptPdf(ByVal room As RoomSelection, ByVal reservationID As Integer)
        Try
            Dim doc As New Document(PageSize.A4.Rotate(), 36, 36, 36, 36)
            Dim fileName As String = $"Receipt_{Sanitize(room.ReservationName, "Guest")}_{room.RoomNumber}.pdf"
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))

            doc.Open()

            Dim titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22)
            Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE)
            Dim boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9)
            Dim normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9)
            Dim footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 8)
            Dim headerBgColor As New BaseColor(63, 81, 181)
            Dim hotelDetails As Dictionary(Of String, String) = modDB.GetHotelDetails()

            Dim mainHeaderTable As New PdfPTable(2)
            mainHeaderTable.WidthPercentage = 100
            mainHeaderTable.SetWidths({70, 30})
            Dim hotelNameCell As New PdfPCell(New Phrase(hotelDetails.Item("HotelName"), titleFont))
            hotelNameCell.Border = 0
            mainHeaderTable.AddCell(hotelNameCell)
            Dim logoCell As New PdfPCell()
            logoCell.Border = 0
            mainHeaderTable.AddCell(logoCell)
            doc.Add(mainHeaderTable)
            doc.Add(New Paragraph(" "))

            Dim detailsTable As New PdfPTable(2)
            detailsTable.WidthPercentage = 100
            detailsTable.SetWidths({50, 50})

            Dim guestDetailsContent As New PdfPTable(1)
            guestDetailsContent.WidthPercentage = 100
            Dim guestHeader As New PdfPCell(New Phrase("Guest Details", headerFont))
            guestHeader.BackgroundColor = headerBgColor
            guestHeader.Padding = 5
            guestDetailsContent.AddCell(guestHeader)
            guestDetailsContent.AddCell(GetDetailCell($"Guest Name: {Sanitize(txtFirstName.Text, "Valued")} {Sanitize(txtLastName.Text, "Guest")}", Element.ALIGN_LEFT))
            guestDetailsContent.AddCell(GetDetailCell($"Room Number: {room.RoomNumber}", Element.ALIGN_LEFT))
            guestDetailsContent.AddCell(GetDetailCell($"Email: {Sanitize(txtEmail.Text)}", Element.ALIGN_LEFT))
            guestDetailsContent.AddCell(GetDetailCell($"Phone: {Sanitize(txtPhone.Text, "N/A")}", Element.ALIGN_LEFT))
            Dim guestCell As New PdfPCell(guestDetailsContent)
            guestCell.Border = 0
            detailsTable.AddCell(guestCell)

            Dim invoiceDetailsTable As New PdfPTable(2)
            invoiceDetailsTable.WidthPercentage = 100
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("RECEIPT #", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("DATE", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetDetailCell(reservationID.ToString(), Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetDetailCell(DateTime.Now.ToString("dd/MM/yyyy"), Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("CASHIER", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(New PdfPCell(New Phrase(modDB.LoggedInUser.FullName, normalFont)) With {.Colspan = 1})
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("ARRIVAL DATE", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("ARRIVAL TIME", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetDetailCell(dtpCheckin.Value.ToString("dd/MM/yyyy"), Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetDetailCell(TimeSpan.Parse(hotelDetails.Item("CheckInTimeDefault")).ToString("hh\:mm"), Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("DEPARTURE DATE", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetBlueHeaderCell("DEPARTURE TIME", Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetDetailCell(dtpCheckout.Value.ToString("dd/MM/yyyy"), Element.ALIGN_LEFT))
            invoiceDetailsTable.AddCell(GetDetailCell(TimeSpan.Parse(hotelDetails.Item("CheckOutTimeDefault")).ToString("hh\:mm"), Element.ALIGN_LEFT))
            Dim invoiceCell As New PdfPCell(invoiceDetailsTable)
            invoiceCell.Border = 0
            detailsTable.AddCell(invoiceCell)
            doc.Add(detailsTable)
            doc.Add(New Paragraph(" "))

            Dim itemsTable As New PdfPTable(4)
            itemsTable.WidthPercentage = 100
            itemsTable.SetWidths({55, 15, 15, 15})
            itemsTable.AddCell(GetBlueHeaderCell("DESCRIPTION", Element.ALIGN_LEFT))
            itemsTable.AddCell(GetBlueHeaderCell("QTY", Element.ALIGN_CENTER))
            itemsTable.AddCell(GetBlueHeaderCell("UNIT PRICE", Element.ALIGN_RIGHT))
            itemsTable.AddCell(GetBlueHeaderCell("AMOUNT", Element.ALIGN_RIGHT))

            Dim roomSubTotalAmount = room.PricePerNight * numberOfNights
            itemsTable.AddCell(GetDetailCell($"{room.TypeName} ('{room.ReservationName}') - {numberOfNights} nights", Element.ALIGN_LEFT))
            itemsTable.AddCell(GetDetailCell("1", Element.ALIGN_CENTER))
            itemsTable.AddCell(GetDetailCell(room.PricePerNight.ToString("N2"), Element.ALIGN_RIGHT))
            itemsTable.AddCell(GetDetailCell(roomSubTotalAmount.ToString("N2"), Element.ALIGN_RIGHT))
            doc.Add(itemsTable)

            Dim totalsTable As New PdfPTable(2)
            totalsTable.WidthPercentage = 100
            totalsTable.SetWidths({85, 15})

            Dim discountForThisRoom As Decimal = 0
            If room.ApplyStatutoryDiscount Then
                discountForThisRoom = roomSubTotalAmount * (statutoryDiscountPercentage / 100)
            End If
            Dim taxForThisRoom As Decimal = (roomSubTotalAmount - discountForThisRoom) * (taxRate / 100)
            Dim totalForThisRoom As Decimal = roomSubTotalAmount - discountForThisRoom + taxForThisRoom

            Dim paymentForThisRoom As Decimal = 0
            If estimatedTotalAmount > 0 Then
                paymentForThisRoom = (totalForThisRoom / estimatedTotalAmount) * paymentAmount
            End If


            totalsTable.AddCell(GetNoBorderCell("Subtotal:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell(roomSubTotalAmount.ToString("N2"), Element.ALIGN_RIGHT, normalFont))
            totalsTable.AddCell(GetNoBorderCell($"Statutory Discount:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell($"-{discountForThisRoom:N2}", Element.ALIGN_RIGHT, normalFont))
            totalsTable.AddCell(GetNoBorderCell($"Tax ({taxRate}%):", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell(taxForThisRoom.ToString("N2"), Element.ALIGN_RIGHT, normalFont))

            Dim totalLabelCell = GetBlueHeaderCell("ROOM TOTAL", Element.ALIGN_RIGHT)
            totalsTable.AddCell(totalLabelCell)
            Dim totalValueCell = GetBlueHeaderCell(totalForThisRoom.ToString("C"), Element.ALIGN_RIGHT)
            totalsTable.AddCell(totalValueCell)

            totalsTable.AddCell(GetNoBorderCell("Payment Applied to this Room:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell(paymentForThisRoom.ToString("C"), Element.ALIGN_RIGHT, normalFont))

            totalsTable.AddCell(GetNoBorderCell("Balance Due for this Room:", Element.ALIGN_RIGHT, boldFont))
            totalsTable.AddCell(GetNoBorderCell((totalForThisRoom - paymentForThisRoom).ToString("C"), Element.ALIGN_RIGHT, normalFont))

            doc.Add(totalsTable)

            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph($"Cashier Signature: ____________________", normalFont))
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph($"Thanks for Choosing - {hotelDetails.Item("HotelName")}", boldFont) With {.Alignment = Element.ALIGN_CENTER})
            Dim fullAddress As String = $"{hotelDetails.Item("AddressLine1")}, {hotelDetails.Item("City")}, {hotelDetails.Item("Country")}"
            doc.Add(New Paragraph(fullAddress, footerFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Add(New Paragraph($"Ph: {hotelDetails.Item("MainPhoneNumber")} | Email: {hotelDetails.Item("MainEmail")}", footerFont) With {.Alignment = Element.ALIGN_CENTER})

            doc.Close()
            System.Diagnostics.Process.Start(filePath)

        Catch ex As Exception
            MsgBox($"Could not generate the receipt PDF for room {room.RoomNumber}.{vbCrLf}{ex.Message}", MsgBoxStyle.Exclamation, "PDF Error")
        End Try
    End Sub

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
    Private Sub cboPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentMethod.SelectedIndexChanged
        Dim isCash As Boolean = (cboPaymentMethod.Text.Equals("Cash", StringComparison.OrdinalIgnoreCase))

        lblCashTendered.Visible = isCash
        txtCashTendered.Visible = isCash
        lblChange.Visible = isCash
        lblChangeDue.Visible = isCash

        If Not isCash Then
            txtCashTendered.Clear()
            lblChangeDue.Text = ""
        End If
    End Sub
    Private Sub txtCashTendered_TextChanged(sender As Object, e As EventArgs) Handles txtCashTendered.TextChanged
        Dim cashTendered As Decimal

        If Decimal.TryParse(txtCashTendered.Text, cashTendered) Then
            If cashTendered >= paymentAmount Then
                Dim change As Decimal = cashTendered - paymentAmount
                lblChangeDue.Text = change.ToString("C")
            Else
                lblChangeDue.Text = ""
            End If
        Else
            lblChangeDue.Text = ""
        End If
    End Sub
#End Region

End Class
