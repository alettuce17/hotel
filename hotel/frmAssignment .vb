Imports MySql.Data.MySqlClient
Imports System.Linq

Public Class frmAssignment

    ' This internal class holds the state of each reservation being assigned.
    Private Class ReservationAssignment
        Public Property ReservationID As Integer
        Public Property GuestID As Integer
        Public Property GuestName As String
        Public Property RoomTypeID As Integer
        Public Property RoomTypeName As String
        Public Property AssignedRoomID As Integer = 0 ' 0 means unassigned
        Public Property AssignedRoomNumber As String = "Not Assigned"
        Public Property PricePerNight As Decimal
        Public Property CheckInDate As Date
        Public Property CheckOutDate As Date
    End Class

    Private _assignments As New List(Of ReservationAssignment)
    Private _guestTierName As String

    Public Sub New(ByVal reservationIDs As List(Of Integer))
        InitializeComponent()
        LoadReservationDetails(reservationIDs)
    End Sub

    Private Sub frmAssignment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _assignments.Any() Then
            DisplayGuestInfo()
            RefreshGrid()
        Else
            MsgBox("No valid reservation details could be loaded. The form will now close.", MsgBoxStyle.Critical)
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Loads reservation details from the database.
    ''' </summary>
    Private Sub LoadReservationDetails(ByVal reservationIDs As List(Of Integer))
        If Not reservationIDs.Any() Then Return

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim idsString = String.Join(",", reservationIDs)

            Dim sql As String = "SELECT res.ReservationID, res.GuestID, res.RoomTypeID, rt.TypeName, res.TotalReservationAmount, " &
                                "res.CheckInDate, res.CheckOutDate, u.FirstName, u.LastName, IFNULL(lt.TierName, 'N/A') as TierName " &
                                "FROM reservations res " &
                                "JOIN roomtypes rt ON res.RoomTypeID = rt.RoomTypeID " &
                                "JOIN guests g ON res.GuestID = g.GuestID " &
                                "JOIN users u ON g.UserID = u.UserID " &
                                "LEFT JOIN loyaltytiers lt ON g.LoyaltyTierID = lt.TierID " &
                                $"WHERE res.ReservationID IN ({idsString});"

            Using cmd As New MySqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim checkIn = CDate(reader("CheckInDate"))
                        Dim checkOut = CDate(reader("CheckOutDate"))
                        Dim totalAmount = CDec(reader("TotalReservationAmount"))
                        Dim nights = CInt(Math.Max(1, (checkOut - checkIn).TotalDays))

                        _assignments.Add(New ReservationAssignment With {
                            .ReservationID = CInt(reader("ReservationID")),
                            .GuestID = CInt(reader("GuestID")),
                            .GuestName = $"{reader("FirstName")} {reader("LastName")}",
                            .RoomTypeID = CInt(reader("RoomTypeID")),
                            .RoomTypeName = reader("TypeName").ToString(),
                            .CheckInDate = checkIn,
                            .CheckOutDate = checkOut,
                            .PricePerNight = If(nights > 0, totalAmount / nights, totalAmount)
                        })
                    End While
                End Using
            End Using
            If _assignments.Any() Then
                _guestTierName = "N/A"
                Using cmdTier As New MySqlCommand("SELECT IFNULL(lt.TierName, 'N/A') FROM guests g LEFT JOIN loyaltytiers lt ON g.LoyaltyTierID = lt.TierID WHERE g.GuestID = @GuestID", conn)
                    cmdTier.Parameters.AddWithValue("@GuestID", _assignments.First().GuestID)
                    _guestTierName = cmdTier.ExecuteScalar().ToString()
                End Using
            End If
        End Using
    End Sub

    Private Sub DisplayGuestInfo()
        lblGuestName.Text = $"Guest Name: {_assignments.FirstOrDefault()?.GuestName}"
        lblGuestTier.Text = $"Loyalty Tier: {_guestTierName}"
    End Sub

    Private Sub RefreshGrid()
        dgvReservations.DataSource = Nothing
        dgvReservations.DataSource = _assignments.ToList()
        FormatDgv()
    End Sub

    Private Sub FormatDgv()
        dgvReservations.RowHeadersVisible = False
        dgvReservations.ReadOnly = True
        dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReservations.MultiSelect = False
        dgvReservations.AllowUserToAddRows = False

        If dgvReservations.Columns.Count > 0 Then
            For Each col As DataGridViewColumn In dgvReservations.Columns
                col.Visible = False
            Next
            dgvReservations.Columns("RoomTypeName").Visible = True
            dgvReservations.Columns("AssignedRoomNumber").Visible = True
            dgvReservations.Columns("RoomTypeName").HeaderText = "Required Room Type"
            dgvReservations.Columns("AssignedRoomNumber").HeaderText = "Assigned Room"
            dgvReservations.Columns("RoomTypeName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvReservations.Columns("AssignedRoomNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End If
    End Sub

    Private Sub btnAssignRoom_Click(sender As Object, e As EventArgs) Handles btnAssignRoom.Click
        If dgvReservations.SelectedRows.Count = 0 Then
            MsgBox("Please select a reservation line to assign a room.", MsgBoxStyle.Information) : Return
        End If

        Dim selectedAssignment As ReservationAssignment = CType(dgvReservations.SelectedRows(0).DataBoundItem, ReservationAssignment)
        Dim alreadySelectedIDs As List(Of Integer) = _assignments.Where(Function(a) a.AssignedRoomID > 0).Select(Function(a) a.AssignedRoomID).ToList()

        Using roomSelector As New frmRoomSelector(selectedAssignment.RoomTypeID, selectedAssignment.CheckInDate, selectedAssignment.CheckOutDate, alreadySelectedIDs, True)
            If roomSelector.ShowDialog() = DialogResult.OK Then
                selectedAssignment.AssignedRoomID = roomSelector.SelectedRoomID
                selectedAssignment.AssignedRoomNumber = roomSelector.SelectedRoomNumber
                selectedAssignment.PricePerNight = roomSelector.SelectedRoomPrice
                RefreshGrid()
            End If
        End Using
    End Sub

    Private Sub btnRemoveReservation_Click(sender As Object, e As EventArgs) Handles btnRemoveReservation.Click
        If dgvReservations.SelectedRows.Count = 0 Then
            MsgBox("Please select a room reservation to remove from this check-in.", MsgBoxStyle.Information) : Return
        End If
        If _assignments.Count <= 1 Then
            MsgBox("Cannot remove the last room from a check-in. Please cancel the entire reservation from the main screen if needed.", MsgBoxStyle.Exclamation) : Return
        End If

        Dim selectedAssignment As ReservationAssignment = CType(dgvReservations.SelectedRows(0).DataBoundItem, ReservationAssignment)
        _assignments.Remove(selectedAssignment)
        RefreshGrid()
    End Sub

    ''' <summary>
    ''' REVISED: This function now directly handles the database updates for checking in a guest.
    ''' </summary>
    Private Sub btnConfirmCheckin_Click(sender As Object, e As EventArgs) Handles btnConfirmCheckin.Click
        Dim unassigned = _assignments.FirstOrDefault(Function(a) a.AssignedRoomID = 0)
        If unassigned IsNot Nothing Then
            MsgBox($"Please assign a specific room for the '{unassigned.RoomTypeName}' reservation.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("Are you sure you want to finalize check-in for all assigned rooms?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                ' Loop through each assignment and update the database
                For Each assignment In _assignments
                    ' Update the reservation with the assigned room and set status to 'Checked In'
                    Dim resSql = "UPDATE reservations SET RoomID = @RoomID, ActualCheckInDateTime = NOW(), ReservationStatus = 'Checked In' WHERE ReservationID = @ResID;"
                    Using cmd As New MySqlCommand(resSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@RoomID", assignment.AssignedRoomID)
                        cmd.Parameters.AddWithValue("@ResID", assignment.ReservationID)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Update the room's status to 'Occupied'
                    Dim roomSql = "UPDATE rooms SET CurrentStatus = 'Occupied' WHERE RoomID = @RoomID;"
                    Using cmd As New MySqlCommand(roomSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@RoomID", assignment.AssignedRoomID)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit()
                MsgBox("Guest checked in successfully!", MsgBoxStyle.Information, "Success")
                modDB.Logs("Guest Check-in", "Reservations", $"GuestID {_assignments.First().GuestID} checked into {_assignments.Count} rooms.")
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                transaction.Rollback()
                MsgBox($"An error occurred during check-in: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
