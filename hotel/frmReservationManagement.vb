Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmReservationManagement

#Region "Paging and State Variables"
    ' We need separate paging variables for each tab
    Private currentPageUpcoming As Integer = 1
    Private currentPageInHouse As Integer = 1
    Private currentPageDeparted As Integer = 1
    Private ReadOnly PageSize As Integer = 50 ' Show 50 records per page
    Private totalPagesUpcoming, totalPagesInHouse, totalPagesDeparted As Integer
#End Region

#Region "Form Load and Tab Control Logic"
    Private Sub frmReservationManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataForCurrentTab()
        UpdateActionButtons()
    End Sub

    Private Sub tcReservations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcReservations.SelectedIndexChanged
        ' When the user switches tabs, load the data and adjust button visibility.
        LoadDataForCurrentTab()
        UpdateActionButtons()
    End Sub

    ''' <summary>
    ''' A helper method to determine which tab is active and call the appropriate data loading function.
    ''' </summary>
    Private Sub LoadDataForCurrentTab()
        Select Case tcReservations.SelectedTab.Name
            Case tpUpcoming.Name
                ' For the "Upcoming" tab, we use the new grouped view.
                LoadReservationsPage(dgvUpcoming, txtSearchUpcoming.Text, "'Confirmed', 'Pending'", currentPageUpcoming, totalPagesUpcoming, lblPageInfoUpcoming, btnFirstUpcoming, btnPrevUpcoming, btnNextUpcoming, btnLastUpcoming, groupByGuest:=True)
            Case tpInHouse.Name
                ' "In-House" guests are shown individually.
                LoadReservationsPage(dgvInHouse, txtSearchInHouse.Text, "'Checked In'", currentPageInHouse, totalPagesInHouse, lblPageInfoInHouse, btnFirstInHouse, btnPrevInHouse, btnNextInHouse, btnLastInHouse)
            Case tpDeparted.Name
                ' "Departed" guests are shown individually.
                LoadReservationsPage(dgvDeparted, txtSearchDeparted.Text, "'Checked Out', 'Cancelled', 'No-Show'", currentPageDeparted, totalPagesDeparted, lblPageInfoDeparted, btnFirstDeparted, btnPrevDeparted, btnNextDeparted, btnLastDeparted)
        End Select
    End Sub

    ''' <summary>
    ''' Controls which action buttons are enabled based on the active tab.
    ''' </summary>
    Private Sub UpdateActionButtons()
        btnCheckIn.Enabled = (tcReservations.SelectedTab Is tpUpcoming)
        btnViewEdit.Enabled = (tcReservations.SelectedTab Is tpUpcoming)
        btnCancel.Enabled = (tcReservations.SelectedTab Is tpUpcoming OrElse tcReservations.SelectedTab Is tpInHouse)

        btnCheckout.Enabled = (tcReservations.SelectedTab Is tpInHouse)
        btnAddCharge.Enabled = (tcReservations.SelectedTab Is tpInHouse)
    End Sub
#End Region

#Region "Universal Data Loading and Paging Logic"

    Private Sub LoadReservationsPage(ByVal dgv As DataGridView, ByVal searchTerm As String, ByVal statuses As String, ByRef currentPage As Integer, ByRef totalPages As Integer, ByVal pageInfoLabel As Label, ByVal firstBtn As Button, ByVal prevBtn As Button, ByVal nextBtn As Button, ByVal lastBtn As Button, Optional groupByGuest As Boolean = False)
        Dim countSql As String
        Dim dataSql As String

        ' --- Base SQL and Search Conditions ---
        Dim baseSqlFrom As String = "FROM reservations res " &
                                     "JOIN guests g ON res.GuestID = g.GuestID " &
                                     "JOIN users u ON g.UserID = u.UserID "

        Dim searchCondition As String = ""
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            searchCondition = "AND (u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm OR res.ConfirmationCode LIKE @SearchTerm) "
        End If

        If groupByGuest Then
            ' --- Queries for the GROUPED "Upcoming" (Today's Arrivals) View ---
            Dim whereClause As String = $"WHERE res.ReservationStatus IN ({statuses}) AND DATE(res.CheckInDate) = CURDATE() "
            countSql = "SELECT COUNT(DISTINCT res.GuestID) " & baseSqlFrom & whereClause & searchCondition
            dataSql = "SELECT " &
                      "  g.GuestID, " &
                      "  CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, " &
                      "  COUNT(res.ReservationID) AS NumberOfRooms, " &
                      "  GROUP_CONCAT(DISTINCT rt.TypeName ORDER BY rt.TypeName SEPARATOR ', ') AS RoomTypes, " &
                      "  MIN(res.CheckInDate) as CheckInDate, " &
                      "  GROUP_CONCAT(res.ReservationID) AS ReservationIDs " &
                      baseSqlFrom &
                      "LEFT JOIN rooms r ON res.RoomID = r.RoomID " &
                      "LEFT JOIN roomtypes rt ON IFNULL(r.RoomTypeID, res.RoomTypeID) = rt.RoomTypeID " &
                      whereClause & searchCondition &
                      "GROUP BY g.GuestID, GuestName " &
                      "ORDER BY GuestName LIMIT @PageSize OFFSET @Offset;"
        Else
            ' --- Queries for the "In-House" and "Departed" Views ---
            Dim whereClause As String = $"WHERE res.ReservationStatus IN ({statuses}) "
            countSql = "SELECT COUNT(*) " & baseSqlFrom & whereClause & searchCondition
            dataSql = "SELECT res.ReservationID, res.RoomID, res.GuestID, res.RoomTypeID, res.ConfirmationCode, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, r.RoomNumber, res.CheckInDate, res.CheckOutDate, res.ReservationStatus " &
                      baseSqlFrom &
                      "LEFT JOIN rooms r ON res.RoomID = r.RoomID " &
                      whereClause & searchCondition &
                      "ORDER BY res.CheckInDate DESC, res.ReservationID DESC LIMIT @PageSize OFFSET @Offset;"
        End If

        ' --- Execute queries and update UI ---
        Dim totalRecords As Integer = 0
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(countSql, conn)
            conn.Open()
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
        End Using

        totalPages = If(totalRecords > 0, CInt(Math.Ceiling(totalRecords / PageSize)), 1)
        If currentPage > totalPages Then currentPage = totalPages
        If currentPage < 1 Then currentPage = 1

        Dim offset As Integer = (currentPage - 1) * PageSize
        Using adapter As New MySqlDataAdapter(dataSql, modDB.strConnection)
            adapter.SelectCommand.Parameters.AddWithValue("@PageSize", PageSize)
            adapter.SelectCommand.Parameters.AddWithValue("@Offset", offset)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgv.DataSource = dt
        End Using

        pageInfoLabel.Text = $"Page {currentPage} of {totalPages}"
        firstBtn.Enabled = (currentPage > 1)
        prevBtn.Enabled = (currentPage > 1)
        nextBtn.Enabled = (currentPage < totalPages)
        lastBtn.Enabled = (currentPage < totalPages)
        FormatDgv(dgv)
    End Sub

    Private Sub FormatDgv(ByVal dgv As DataGridView)
        dgv.RowHeadersVisible = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        If dgv.Columns.Count > 0 Then
            If dgv.Parent Is tpUpcoming Then
                dgv.Columns("GuestID").Visible = False
                dgv.Columns("ReservationIDs").Visible = False
                dgv.Columns("GuestName").HeaderText = "Guest Name"
                dgv.Columns("NumberOfRooms").HeaderText = "Rooms"
                dgv.Columns("RoomTypes").HeaderText = "Room Type(s)"
                dgv.Columns("CheckInDate").HeaderText = "Arrival Date"
            Else ' This now applies to In-House and Departed
                dgv.Columns("ReservationID").Visible = False
                dgv.Columns("RoomID").Visible = False
                dgv.Columns("GuestID").Visible = False
                dgv.Columns("RoomTypeID").Visible = False
                dgv.Columns("ConfirmationCode").HeaderText = "Conf. Code"
                dgv.Columns("GuestName").HeaderText = "Guest Name"
                dgv.Columns("RoomNumber").HeaderText = "Assigned Room"
                dgv.Columns("CheckInDate").HeaderText = "Check-in"
                dgv.Columns("CheckOutDate").HeaderText = "Check-out"
                dgv.Columns("ReservationStatus").HeaderText = "Status"
            End If
        End If
    End Sub
#End Region

#Region "Action Button Logic"

    Private Sub btnNewReservation_Click(sender As Object, e As EventArgs) Handles btnNewReservation.Click
        Using frm As New frmNewReservation()
            frm.ShowDialog()
        End Using
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnViewEdit_Click(sender As Object, e As EventArgs) Handles btnViewEdit.Click
        If tcReservations.SelectedTab IsNot tpUpcoming OrElse dgvUpcoming.SelectedRows.Count = 0 Then
            MsgBox("Please select a reservation from the 'Upcoming Arrivals' list to view or edit.", MsgBoxStyle.Information) : Return
        End If
        Dim reservationIDsString As String = dgvUpcoming.SelectedRows(0).Cells("ReservationIDs").Value.ToString()
        Dim firstResID As Integer = CInt(reservationIDsString.Split(","c)(0))

        Using frm As New frmNewReservation(firstResID)
            frm.ShowDialog()
        End Using
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnAddCharge_Click(sender As Object, e As EventArgs) Handles btnAddCharge.Click
        If tcReservations.SelectedTab IsNot tpInHouse OrElse dgvInHouse.SelectedRows.Count = 0 Then
            MsgBox("Please select a guest from the 'In-House Guests' list to add a charge.", MsgBoxStyle.Information) : Return
        End If
        Dim selectedResID As Integer = CInt(dgvInHouse.SelectedRows(0).Cells("ReservationID").Value)

        ' *** FIX: Uncommented the code to open the frmAddons form. ***
        ' Assuming you have a form named frmAddons that takes a reservation ID
        Using frm As New frmAddons(selectedResID)
            frm.ShowDialog()
        End Using
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        If dgvUpcoming.SelectedRows.Count = 0 Then
            MsgBox("Please select a guest from the 'Upcoming Arrivals' list to check in.", MsgBoxStyle.Information)
            Return
        End If

        Dim selectedRow = dgvUpcoming.SelectedRows(0)
        Dim reservationIDsString As String = selectedRow.Cells("ReservationIDs").Value.ToString()
        Dim allReservationIDs = reservationIDsString.Split(","c).Select(Function(id) CInt(id)).ToList()

        If allReservationIDs.Count = 0 Then
            MsgBox("No reservations found for the selected guest to check in.", MsgBoxStyle.Exclamation)
            Return
        End If

        For Each resID As Integer In allReservationIDs
            Using frm As New frmNewReservation(resID, False, True)
                Dim dialogResult = frm.ShowDialog()
                If dialogResult = DialogResult.Cancel Then
                    MsgBox($"Check-in for reservation ID {resID} was cancelled. Continuing to next reservation (if any).", MsgBoxStyle.Information)
                ElseIf dialogResult <> DialogResult.OK Then
                    MsgBox($"Check-in for reservation ID {resID} was not completed. Continuing to next reservation (if any).", MsgBoxStyle.Exclamation)
                End If
            End Using
        Next

        LoadDataForCurrentTab() ' Refresh the grid
    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If dgvInHouse.SelectedRows.Count = 0 Then
            MsgBox("Please select a guest from the 'In-House Guests' list to check out.", MsgBoxStyle.Information)
            Return
        End If

        ' *** FIX: Restored the logic to get all of a guest's in-house reservations. ***
        Dim selectedGuestID As Integer = CInt(dgvInHouse.SelectedRows(0).Cells("GuestID").Value)
        Dim guestName As String = dgvInHouse.SelectedRows(0).Cells("GuestName").Value.ToString()
        Dim allInHouseReservationIDs As New List(Of Integer)

        Dim sql As String = "SELECT ReservationID FROM reservations WHERE GuestID = @GuestID AND ReservationStatus = 'Checked In';"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@GuestID", selectedGuestID)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            allInHouseReservationIDs.Add(CInt(reader("ReservationID")))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MsgBox($"Could not retrieve all reservations for {guestName}.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical)
                Return
            End Try
        End Using

        ' *** FIX: Uncommented the code to open the frmCheckout form. ***
        If allInHouseReservationIDs.Count > 0 Then
            ' Assuming you have a form named frmCheckout that takes a list of reservation IDs
            Using checkoutForm As New frmCheckout(allInHouseReservationIDs)
                checkoutForm.ShowDialog()
            End Using
            LoadDataForCurrentTab()
        Else
            MsgBox("No active 'Checked In' reservations found for the selected guest.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If tcReservations.SelectedTab Is tpUpcoming Then
            If dgvUpcoming.SelectedRows.Count = 0 Then
                MsgBox("Please select a reservation from the 'Upcoming Arrivals' list to cancel.", MsgBoxStyle.Information)
                Return
            End If

            Dim reservationIDsString As String = dgvUpcoming.SelectedRows(0).Cells("ReservationIDs").Value.ToString()
            If MsgBox($"Are you sure you want to cancel all {reservationIDsString.Split(","c).Length} reservations for this guest?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
                Return
            End If

            Dim sql = $"UPDATE reservations SET ReservationStatus = 'Cancelled' WHERE ReservationID IN ({reservationIDsString});"
            Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Reservation(s) cancelled successfully.", MsgBoxStyle.Information, "Success")
            modDB.Logs("Reservation Cancelled", "Reservations", $"Reservations {reservationIDsString} were cancelled.")
            LoadDataForCurrentTab()

        ElseIf tcReservations.SelectedTab Is tpInHouse Then
            If dgvInHouse.SelectedRows.Count = 0 Then
                MsgBox("Please select a guest from the 'In-House' list to perform an error-correction cancellation.", MsgBoxStyle.Information)
                Return
            End If

            Dim selectedRow = dgvInHouse.SelectedRows(0)
            Dim resID As Integer = CInt(selectedRow.Cells("ReservationID").Value)
            Dim roomID As Object = selectedRow.Cells("RoomID").Value ' Can be DBNull
            Dim guestName As String = selectedRow.Cells("GuestName").Value.ToString()

            If MsgBox($"This will CANCEL the in-house stay for {guestName} and reset the room to 'Vacant'. This should only be used to correct a check-in error. Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Return
            End If

            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim transaction As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim resSql = "UPDATE reservations SET ReservationStatus = 'Cancelled', RoomID = NULL, ActualCheckOutDateTime = NOW() WHERE ReservationID = @ResID;"
                    Using cmd As New MySqlCommand(resSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@ResID", resID)
                        cmd.ExecuteNonQuery()
                    End Using

                    If roomID IsNot DBNull.Value Then
                        Dim roomSql = "UPDATE rooms SET CurrentStatus = 'Vacant' WHERE RoomID = @RoomID;"
                        Using cmd As New MySqlCommand(roomSql, conn, transaction)
                            cmd.Parameters.AddWithValue("@RoomID", CInt(roomID))
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    transaction.Commit()
                    MsgBox("In-house stay cancelled successfully. The room has been reset.", MsgBoxStyle.Information, "Success")
                    modDB.Logs("In-House Stay Cancelled", "Reservations", $"In-house stay for {guestName} (ResID: {resID}) was cancelled.", "reservations", resID)
                    LoadDataForCurrentTab()

                Catch ex As Exception
                    transaction.Rollback()
                    MsgBox($"An error occurred during cancellation: {ex.Message}", MsgBoxStyle.Critical)
                End Try
            End Using
        End If
    End Sub
#End Region

#Region "Search and Paging Event Handlers"
    ' --- Upcoming Tab ---
    Private Sub txtSearchUpcoming_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUpcoming.TextChanged
        currentPageUpcoming = 1
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnFirstUpcoming_Click(sender As Object, e As EventArgs) Handles btnFirstUpcoming.Click
        currentPageUpcoming = 1
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnPrevUpcoming_Click(sender As Object, e As EventArgs) Handles btnPrevUpcoming.Click
        If currentPageUpcoming > 1 Then
            currentPageUpcoming -= 1
            LoadDataForCurrentTab()
        End If
    End Sub

    Private Sub btnNextUpcoming_Click(sender As Object, e As EventArgs) Handles btnNextUpcoming.Click
        If currentPageUpcoming < totalPagesUpcoming Then
            currentPageUpcoming += 1
            LoadDataForCurrentTab()
        End If
    End Sub

    Private Sub btnLastUpcoming_Click(sender As Object, e As EventArgs) Handles btnLastUpcoming.Click
        currentPageUpcoming = totalPagesUpcoming
        LoadDataForCurrentTab()
    End Sub

    ' --- In-House Tab ---
    Private Sub txtSearchInHouse_TextChanged(sender As Object, e As EventArgs) Handles txtSearchInHouse.TextChanged
        currentPageInHouse = 1
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnFirstInHouse_Click(sender As Object, e As EventArgs) Handles btnFirstInHouse.Click
        currentPageInHouse = 1
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnPrevInHouse_Click(sender As Object, e As EventArgs) Handles btnPrevInHouse.Click
        If currentPageInHouse > 1 Then
            currentPageInHouse -= 1
            LoadDataForCurrentTab()
        End If
    End Sub

    Private Sub btnNextInHouse_Click(sender As Object, e As EventArgs) Handles btnNextInHouse.Click
        If currentPageInHouse < totalPagesInHouse Then
            currentPageInHouse += 1
            LoadDataForCurrentTab()
        End If
    End Sub

    Private Sub btnLastInHouse_Click(sender As Object, e As EventArgs) Handles btnLastInHouse.Click
        currentPageInHouse = totalPagesInHouse
        LoadDataForCurrentTab()
    End Sub

    ' --- Departed Tab ---
    Private Sub txtSearchDeparted_TextChanged(sender As Object, e As EventArgs) Handles txtSearchDeparted.TextChanged
        currentPageDeparted = 1
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnFirstDeparted_Click(sender As Object, e As EventArgs) Handles btnFirstDeparted.Click
        currentPageDeparted = 1
        LoadDataForCurrentTab()
    End Sub

    Private Sub btnPrevDeparted_Click(sender As Object, e As EventArgs) Handles btnPrevDeparted.Click
        If currentPageDeparted > 1 Then
            currentPageDeparted -= 1
            LoadDataForCurrentTab()
        End If
    End Sub

    Private Sub btnNextDeparted_Click(sender As Object, e As EventArgs) Handles btnNextDeparted.Click
        If currentPageDeparted < totalPagesDeparted Then
            currentPageDeparted += 1
            LoadDataForCurrentTab()
        End If
    End Sub

    Private Sub btnLastDeparted_Click(sender As Object, e As EventArgs) Handles btnLastDeparted.Click
        currentPageDeparted = totalPagesDeparted
        LoadDataForCurrentTab()
    End Sub
#End Region

End Class
