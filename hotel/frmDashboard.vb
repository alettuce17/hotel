Imports MySql.Data.MySqlClient

Public Class frmDashboard

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form to fill the MDI container
        Me.Dock = DockStyle.Fill
        ' Load all data for the first time
        RefreshData()
    End Sub

    ''' <summary>
    ''' This is the main method that fetches all data from the database and updates the UI.
    ''' </summary>
    Private Sub RefreshData()
        LoadRoomStatusCounts()
        LoadTodaysCheckins()
        LoadTodaysCheckouts()
    End Sub

    ''' <summary>
    ''' Gets the counts of rooms by their current status and updates the labels.
    ''' </summary>
    Private Sub LoadRoomStatusCounts()
        ' Set default values to 0
        lblAvailableValue.Text = "0"
        lblOccupiedValue.Text = "0"
        lblPendingValue.Text = "0" ' Initialize the new label
        lblCleaningValue.Text = "0"

        ' This query counts rooms for each status type
        Dim sql As String = "SELECT CurrentStatus, COUNT(*) as RoomCount FROM rooms GROUP BY CurrentStatus;"

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim status As String = reader("CurrentStatus").ToString().ToLower()
                            Dim count As String = reader("RoomCount").ToString()

                            ' Update the correct label based on the status from the database
                            Select Case status
                                Case "available"
                                    lblAvailableValue.Text = count
                                Case "occupied"
                                    lblOccupiedValue.Text = count
                                Case "pending" ' *** NEW CASE ADDED HERE ***
                                    lblPendingValue.Text = count
                                Case "dirty", "under maintenance" ' You can group statuses here
                                    ' Add the counts for "Dirty" and "Under Maintenance" together
                                    Dim currentCleaningCount As Integer = 0
                                    Integer.TryParse(lblCleaningValue.Text, currentCleaningCount)
                                    lblCleaningValue.Text = (currentCleaningCount + CInt(count)).ToString()
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                ' Silently fail, the labels will just show 0
                Console.WriteLine($"Error loading room counts: {ex.Message}")
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Loads a list of guests expected to check in today.
    ''' </summary>
    Private Sub LoadTodaysCheckins()
        ' This query gets reservation and guest details for today's check-ins
        Dim sql As String = "SELECT r.RoomNumber, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, res.EstimatedArrivalTime " &
                            "FROM reservations res " &
                            "JOIN guests g ON res.GuestID = g.GuestID " &
                            "JOIN users u ON g.UserID = u.UserID " &
                            "JOIN rooms r ON res.RoomID = r.RoomID " &
                            "WHERE res.CheckInDate = CURDATE() AND res.ReservationStatus IN ('Confirmed', 'Pending');"

        modDB.LoadToDGV(sql, dgvCheckins)
        ' Optional: Customize column headers for better readability
        If dgvCheckins.Columns.Count > 0 Then
            dgvCheckins.Columns(0).HeaderText = "Room"
            dgvCheckins.Columns(1).HeaderText = "Guest Name"
            dgvCheckins.Columns(2).HeaderText = "ETA"
        End If
    End Sub

    ''' <summary>
    ''' Loads a list of guests expected to check out today.
    ''' </summary>
    Private Sub LoadTodaysCheckouts()
        ' This query gets reservation and guest details for today's check-outs
        Dim sql As String = "SELECT r.RoomNumber, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, res.CheckOutDate " &
                            "FROM reservations res " &
                            "JOIN guests g ON res.GuestID = g.GuestID " &
                            "JOIN users u ON g.UserID = u.UserID " &
                            "JOIN rooms r ON res.RoomID = r.RoomID " &
                            "WHERE res.CheckOutDate = CURDATE() AND res.ReservationStatus = 'Checked In';"

        modDB.LoadToDGV(sql, dgvCheckouts)
        ' Optional: Customize column headers
        If dgvCheckouts.Columns.Count > 0 Then
            dgvCheckouts.Columns(0).HeaderText = "Room"
            dgvCheckouts.Columns(1).HeaderText = "Guest Name"
            dgvCheckouts.Columns(2).HeaderText = "Checkout Date"
        End If
    End Sub

    ''' <summary>
    ''' This event fires every time the timer's interval elapses (e.g., every 5 minutes).
    ''' </summary>
    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        RefreshData()
    End Sub

    Private Sub lblCleaningLabel_Click(sender As Object, e As EventArgs) Handles lblCleaningLabel.Click

    End Sub
End Class
