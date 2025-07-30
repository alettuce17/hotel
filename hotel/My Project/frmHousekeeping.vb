Imports MySql.Data.MySqlClient

Public Class frmHousekeeping

#Region "Paging and State Variables"
    Private currentPage As Integer = 1
    Private ReadOnly PageSize As Integer = 50 ' Show 50 rooms per page
    Private totalPages As Integer = 0
#End Region

#Region "Form Load and Data Loading"

    Private Sub frmHousekeeping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        LoadDirtyRoomsPage()
    End Sub

    ''' <summary>
    ''' The main method to load a specific "page" of dirty rooms.
    ''' </summary>
    Private Sub LoadDirtyRoomsPage()
        Dim searchTerm As String = txtSearch.Text.Trim()

        ' --- Step 1: Get the total number of records ---
        Dim countSql As String = "SELECT COUNT(*) FROM rooms WHERE CurrentStatus = 'Dirty' "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            countSql &= "AND RoomNumber LIKE @SearchTerm "
        End If

        Dim totalRecords As Integer = 0
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(countSql, conn)
            conn.Open()
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
        End Using

        ' --- Step 2: Calculate total pages ---
        totalPages = CInt(Math.Ceiling(totalRecords / PageSize))
        If totalPages = 0 Then totalPages = 1
        If currentPage > totalPages Then currentPage = totalPages

        ' --- Step 3: Fetch the data for the current page ---
        Dim offset As Integer = (currentPage - 1) * PageSize
        Dim dataSql As String = "SELECT r.RoomID, r.RoomNumber, rt.TypeName, r.LastCleanedDate " &
                                "FROM rooms r " &
                                "JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID " &
                                "WHERE r.CurrentStatus = 'Dirty' "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            dataSql &= "AND r.RoomNumber LIKE @SearchTerm "
        End If
        dataSql &= "ORDER BY r.FloorNumber, r.RoomNumber LIMIT @PageSize OFFSET @Offset;"

        Using adapter As New MySqlDataAdapter(dataSql, modDB.strConnection)
            adapter.SelectCommand.Parameters.AddWithValue("@PageSize", PageSize)
            adapter.SelectCommand.Parameters.AddWithValue("@Offset", offset)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvDirtyRooms.DataSource = dt
        End Using

        ' --- Step 4: Update UI ---
        lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
        btnFirst.Enabled = (currentPage > 1)
        btnPrevious.Enabled = (currentPage > 1)
        btnNext.Enabled = (currentPage < totalPages)
        btnLast.Enabled = (currentPage < totalPages)

        ' *** FIX: Pass the correct DataGridView to the formatting function ***
        FormatDgv(dgvDirtyRooms)
    End Sub

    Private Sub FormatDgv(ByVal dgv As DataGridView)
        dgv.RowHeadersVisible = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If dgv.Columns.Count > 0 Then
            dgv.Columns("RoomID").Visible = False
            dgv.Columns("RoomNumber").HeaderText = "Room No."
            dgv.Columns("TypeName").HeaderText = "Room Type"
            dgv.Columns("LastCleanedDate").HeaderText = "Last Cleaned"
            dgv.Columns("TypeName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

#End Region

#Region "Button Click Handlers"

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        currentPage = 1
        LoadDirtyRoomsPage()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        currentPage = 1
        LoadDirtyRoomsPage()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadDirtyRoomsPage()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadDirtyRoomsPage()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        currentPage = totalPages
        LoadDirtyRoomsPage()
    End Sub

    Private Sub btnMarkClean_Click(sender As Object, e As EventArgs) Handles btnMarkClean.Click
        If dgvDirtyRooms.SelectedRows.Count = 0 Then
            MsgBox("Please select a room from the list to mark as clean.", MsgBoxStyle.Information)
            Return
        End If

        Dim selectedRow = dgvDirtyRooms.SelectedRows(0)
        Dim roomID As Integer = CInt(selectedRow.Cells("RoomID").Value)
        Dim roomNumber As String = selectedRow.Cells("RoomNumber").Value.ToString()

        If MsgBox($"Are you sure you want to mark Room {roomNumber} as clean and available?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Return
        End If

        Dim sql As String = "UPDATE rooms SET CurrentStatus = 'Available', LastCleanedDate = NOW(), LastCleanedByStaffID = @StaffID WHERE RoomID = @RoomID;"
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            Try
                conn.Open()
                cmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
                cmd.Parameters.AddWithValue("@RoomID", roomID)
                cmd.ExecuteNonQuery()

                MsgBox($"Room {roomNumber} has been marked as available.", MsgBoxStyle.Information, "Success")
                modDB.Logs("Room Cleaned", "Housekeeping", $"Room {roomNumber} status set to Available.", "rooms", roomID)
                LoadDirtyRoomsPage()

            Catch ex As Exception
                MsgBox($"An error occurred while updating the room status.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical, "Database Error")
            End Try
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        currentPage = 1
        LoadDirtyRoomsPage()
    End Sub

    Private Sub btnMarkAllClean_Click(sender As Object, e As EventArgs) Handles btnMarkAllClean.Click
        If dgvDirtyRooms.Rows.Count = 0 Then
            MsgBox("There are no dirty rooms to mark as cleaned.", MsgBoxStyle.Information)
            Return
        End If

        If MsgBox("Are you sure you want to mark ALL rooms on this page as clean and available?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Action") = MsgBoxResult.No Then
            Return
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Dim trans = conn.BeginTransaction()

                For Each row As DataGridViewRow In dgvDirtyRooms.Rows
                    Dim roomID As Integer = CInt(row.Cells("RoomID").Value)
                    Dim roomNumber As String = row.Cells("RoomNumber").Value.ToString()

                    Dim sql As String = "UPDATE rooms SET CurrentStatus = 'Available', LastCleanedDate = NOW(), LastCleanedByStaffID = @StaffID WHERE RoomID = @RoomID;"
                    Using cmd As New MySqlCommand(sql, conn, trans)
                        cmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
                        cmd.Parameters.AddWithValue("@RoomID", roomID)
                        cmd.ExecuteNonQuery()
                    End Using

                    modDB.Logs("Room Cleaned", "Housekeeping", $"Room {roomNumber} status set to Available.", "rooms", roomID)
                Next

                trans.Commit()
                MsgBox("All rooms on this page have been marked as available.", MsgBoxStyle.Information, "Success")
                LoadDirtyRoomsPage()

            Catch ex As Exception
                MsgBox("An error occurred while marking all rooms as cleaned." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub


#End Region

End Class
