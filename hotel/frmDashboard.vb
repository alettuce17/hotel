Imports MySql.Data.MySqlClient

Public Class frmDashboard

#Region "Paging and State Variables"
    ' Paging variables for the Check-ins grid
    Private currentPageCheckin As Integer = 1
    Private totalPagesCheckin As Integer = 0

    ' Paging variables for the Check-outs grid
    Private currentPageCheckout As Integer = 1
    Private totalPagesCheckout As Integer = 0

    Private ReadOnly PageSize As Integer = 20 ' Show 20 records per page
#End Region

#Region "Form Load and Data Loading"

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        RefreshData()
    End Sub

    ''' <summary>
    ''' This is the main method that fetches all data from the database and updates the UI.
    ''' </summary>
    Public Sub RefreshData()
        LoadRoomStatusCounts()
        LoadCheckinsPage()
        LoadCheckoutsPage()
    End Sub

    ''' <summary>
    ''' Gets the counts of rooms by their current status and updates the labels.
    ''' </summary>
    Private Sub LoadRoomStatusCounts()
        lblAvailableValue.Text = "0"
        lblOccupiedValue.Text = "0"
        lblPendingValue.Text = "0"
        lblCleaningValue.Text = "0"

        Dim sql As String = "SELECT CurrentStatus, COUNT(*) as RoomCount FROM rooms GROUP BY CurrentStatus;"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim status As String = reader("CurrentStatus").ToString().ToLower()
                            Dim count As String = reader("RoomCount").ToString()
                            Select Case status
                                Case "available"
                                    lblAvailableValue.Text = count
                                Case "occupied"
                                    lblOccupiedValue.Text = count
                                Case "pending"
                                    lblPendingValue.Text = count
                                Case "dirty", "under maintenance"
                                    Dim currentCleaningCount As Integer = 0
                                    Integer.TryParse(lblCleaningValue.Text, currentCleaningCount)
                                    lblCleaningValue.Text = (currentCleaningCount + CInt(count)).ToString()
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine($"Error loading room counts: {ex.Message}")
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Loads a paged list of guests expected to check in today.
    ''' </summary>
    Private Sub LoadCheckinsPage()
        Dim searchTerm As String = txtSearchCheckins.Text.Trim()
        Dim statuses As String = "'Confirmed', 'Pending'"
        LoadPagedData(dgvCheckins, searchTerm, statuses, currentPageCheckin, totalPagesCheckin, lblPageInfoCheckin, btnFirstCheckin, btnPrevCheckin, btnNextCheckin, btnLastCheckin, True)
    End Sub

    ''' <summary>
    ''' Loads a paged list of guests expected to check out today.
    ''' </summary>
    Private Sub LoadCheckoutsPage()
        Dim searchTerm As String = txtSearchCheckouts.Text.Trim()
        Dim statuses As String = "'Checked In'"
        LoadPagedData(dgvCheckouts, searchTerm, statuses, currentPageCheckout, totalPagesCheckout, lblPageInfoCheckout, btnFirstCheckout, btnPreviousCheckout, btnNextCheckout, btnLastCheckout, False)
    End Sub
    ''' <summary>
    ''' A universal function to load paged data into any of the dashboard's grids.
    ''' </summary>
    Private Sub LoadPagedData(ByVal dgv As DataGridView, ByVal searchTerm As String, ByVal statuses As String, ByRef currentPage As Integer, ByRef totalPages As Integer, ByVal pageInfoLabel As Label, ByVal firstBtn As Button, ByVal prevBtn As Button, ByVal nextBtn As Button, ByVal lastBtn As Button, ByVal isCheckin As Boolean)

        Dim todayDate As Date = DateTime.Today
        Dim countSql As String
        Dim dataSql As String

        ' --- Base SQL and Search Conditions (reusable parts) ---
        Dim baseSqlFrom As String = "FROM reservations res " &
                                  "JOIN guests g ON res.GuestID = g.GuestID " &
                                  "JOIN users u ON g.UserID = u.UserID "

        Dim searchCondition As String = ""
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            searchCondition = "AND (u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm) "
        End If


        If isCheckin Then
            ' --- Queries for the GROUPED Check-in (Today's Arrivals) View ---
            ' *** FIX: Added 'AND DATE(res.CheckInDate) = CURDATE()' to show only today's arrivals ***
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
            ' --- Queries for the standard Check-out View ---
            Dim whereClause As String = $"WHERE res.ReservationStatus IN ({statuses}) AND DATE(res.CheckOutDate) = @TodayDate "

            countSql = "SELECT COUNT(*) " & baseSqlFrom & whereClause & searchCondition

            dataSql = "SELECT res.ReservationID, r.RoomNumber, rt.TypeName AS RoomType, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, res.EstimatedArrivalTime, res.CheckOutDate " &
                  baseSqlFrom &
                  "LEFT JOIN rooms r ON res.RoomID = r.RoomID " &
                  "LEFT JOIN roomtypes rt ON res.RoomTypeID = rt.RoomTypeID " &
                  whereClause & searchCondition &
                  "ORDER BY res.EstimatedArrivalTime, u.LastName, u.FirstName LIMIT @PageSize OFFSET @Offset;"
        End If

        ' --- Execute queries and populate the grid ---
        Dim totalRecords As Integer = 0
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(countSql, conn)
            conn.Open()
            ' Only add the TodayDate parameter if the query needs it
            If Not isCheckin Then
                cmd.Parameters.AddWithValue("@TodayDate", todayDate)
            End If
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                totalRecords = Convert.ToInt32(result)
            End If
        End Using

        If totalRecords > 0 Then
            totalPages = CInt(Math.Ceiling(totalRecords / PageSize))
        Else
            totalPages = 1
        End If

        If currentPage > totalPages Then currentPage = totalPages
        If currentPage < 1 Then currentPage = 1

        Dim offset As Integer = (currentPage - 1) * PageSize

        Using adapter As New MySqlDataAdapter(dataSql, modDB.strConnection)
            If Not isCheckin Then
                adapter.SelectCommand.Parameters.AddWithValue("@TodayDate", todayDate)
            End If
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
        FormatDgv(dgv, isCheckin)
    End Sub

    Private Sub FormatDgv(ByVal dgv As DataGridView, ByVal isCheckin As Boolean)
        dgv.RowHeadersVisible = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        If dgv.Columns.Count > 0 Then
            If isCheckin Then
                ' --- Format for the GROUPED Check-in view ---
                If dgv.Columns.Contains("GuestID") Then dgv.Columns("GuestID").Visible = False
                If dgv.Columns.Contains("ReservationIDs") Then dgv.Columns("ReservationIDs").Visible = False
                If dgv.Columns.Contains("CheckInDate") Then dgv.Columns("CheckInDate").Visible = False

                If dgv.Columns.Contains("GuestName") Then
                    dgv.Columns("GuestName").HeaderText = "Guest Name"
                    dgv.Columns("GuestName").DisplayIndex = 0
                    dgv.Columns("GuestName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
                If dgv.Columns.Contains("NumberOfRooms") Then
                    dgv.Columns("NumberOfRooms").HeaderText = "Rooms"
                    dgv.Columns("NumberOfRooms").DisplayIndex = 1
                End If
                If dgv.Columns.Contains("RoomTypes") Then
                    dgv.Columns("RoomTypes").HeaderText = "Room Type(s)"
                    dgv.Columns("RoomTypes").DisplayIndex = 2
                    dgv.Columns("RoomTypes").Width = 250
                End If
            Else
                ' --- Formatting for the standard Check-out view ---
                If dgv.Columns.Contains("ReservationID") Then dgv.Columns("ReservationID").Visible = False
                If dgv.Columns.Contains("RoomType") Then dgv.Columns("RoomType").HeaderText = "Room Type"
                If dgv.Columns.Contains("RoomNumber") Then dgv.Columns("RoomNumber").HeaderText = "Room"
                If dgv.Columns.Contains("GuestName") Then dgv.Columns("GuestName").HeaderText = "Guest Name"
                If dgv.Columns.Contains("CheckOutDate") Then dgv.Columns("CheckOutDate").HeaderText = "Checkout Date"
                If dgv.Columns.Contains("EstimatedArrivalTime") Then dgv.Columns("EstimatedArrivalTime").Visible = False
                If dgv.Columns.Contains("GuestName") Then dgv.Columns("GuestName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End If
    End Sub

#End Region

#Region "Button Click Handlers"


    ' --- Check-in Paging ---
    Private Sub btnSearchCheckins_Click(sender As Object, e As EventArgs) Handles btnSearchCheckins.Click
        currentPageCheckin = 1
        LoadCheckinsPage()
    End Sub
    Private Sub btnFirstCheckin_Click(sender As Object, e As EventArgs) Handles btnFirstCheckin.Click
        currentPageCheckin = 1
        LoadCheckinsPage()
    End Sub
    Private Sub btnPrevCheckin_Click(sender As Object, e As EventArgs) Handles btnPrevCheckin.Click
        If currentPageCheckin > 1 Then currentPageCheckin -= 1
        LoadCheckinsPage()
    End Sub
    Private Sub btnNextCheckin_Click(sender As Object, e As EventArgs) Handles btnNextCheckin.Click
        If currentPageCheckin < totalPagesCheckin Then currentPageCheckin += 1
        LoadCheckinsPage()
    End Sub
    Private Sub btnLastCheckin_Click(sender As Object, e As EventArgs) Handles btnLastCheckin.Click
        currentPageCheckin = totalPagesCheckin
        LoadCheckinsPage()
    End Sub

    ' --- Check-out Paging ---
    Private Sub btnSearchCheckouts_Click(sender As Object, e As EventArgs) Handles btnSearchCheckouts.Click
        currentPageCheckout = 1
        LoadCheckoutsPage()
    End Sub
    Private Sub btnFirstCheckout_Click(sender As Object, e As EventArgs) Handles btnFirstCheckout.Click
        currentPageCheckout = 1
        LoadCheckoutsPage()
    End Sub
    Private Sub btnPrevCheckout_Click(sender As Object, e As EventArgs) Handles btnPreviousCheckout.Click
        If currentPageCheckout > 1 Then currentPageCheckout -= 1
        LoadCheckoutsPage()
    End Sub
    Private Sub btnNextCheckout_Click(sender As Object, e As EventArgs) Handles btnNextCheckout.Click
        If currentPageCheckout < totalPagesCheckout Then currentPageCheckout += 1
        LoadCheckoutsPage()
    End Sub
    Private Sub btnLastCheckout_Click(sender As Object, e As EventArgs) Handles btnLastCheckout.Click
        currentPageCheckout = totalPagesCheckout
        LoadCheckoutsPage()
    End Sub

    ''' <summary>
    ''' This event fires every time the timer's interval elapses (e.g., every 5 minutes).
    ''' </summary>
    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        RefreshData()
    End Sub

    Private Sub btnRefresh_Click_Click(sender As Object, e As EventArgs) Handles btnRefresh_Click.Click
        txtSearchCheckins.Clear()
        txtSearchCheckouts.Clear()
        RefreshData()
    End Sub

    Private Sub lblCheckouts_Click(sender As Object, e As EventArgs) Handles lblCheckouts.Click

    End Sub




#End Region

End Class
