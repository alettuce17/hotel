Imports MySql.Data.MySqlClient

Public Class frmActivityLog

#Region "Class-level Variables"

    ' --- Virtual Mode & Cache Variables ---
    Private cache As New DataTable()
    Private cacheStartRowIndex As Integer = -1
    Private ReadOnly PageSize As Integer = 100

#End Region

#Region "Form Load & Setup"

    Private Sub frmActivityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        dtpStartDate.Value = DateTime.Today.AddDays(-7)
        dtpEndDate.Value = DateTime.Today
        SetupVirtualGrid()
    End Sub

    ''' <summary>
    ''' Load data after all controls are initialized
    ''' </summary>
    Private Sub frmActivityLog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshGridData()
    End Sub

    Private Sub SetupVirtualGrid()
        dgvLogs.VirtualMode = True
        dgvLogs.ReadOnly = True
        dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLogs.RowHeadersVisible = False
        dgvLogs.AllowUserToAddRows = False

        dgvLogs.Columns.Clear()
        dgvLogs.Columns.Add("LogTimestamp", "Timestamp")
        dgvLogs.Columns.Add("StaffName", "User")
        dgvLogs.Columns.Add("EventType", "Event Type")
        dgvLogs.Columns.Add("ApplicationModule", "Module")
        dgvLogs.Columns.Add("Details", "Details")

        dgvLogs.Columns("LogTimestamp").Width = 150
        dgvLogs.Columns("StaffName").Width = 150
        dgvLogs.Columns("EventType").Width = 120
        dgvLogs.Columns("ApplicationModule").Width = 120
        dgvLogs.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

#End Region

#Region "Virtual Mode Data Handling"

    Private Sub dgvLogs_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvLogs.CellValueNeeded
        If cacheStartRowIndex = -1 OrElse e.RowIndex < cacheStartRowIndex OrElse e.RowIndex >= cacheStartRowIndex + cache.Rows.Count Then
            FetchPage(e.RowIndex)
        End If

        Dim relativeIndex = e.RowIndex - cacheStartRowIndex
        If relativeIndex >= 0 AndAlso relativeIndex < cache.Rows.Count Then
            Dim colName = dgvLogs.Columns(e.ColumnIndex).Name
            e.Value = cache.Rows(relativeIndex)(colName)
        End If
    End Sub
    Private Sub FetchPage(rowIndex As Integer)
        Try
            cache.Clear()
            cacheStartRowIndex = (rowIndex \ PageSize) * PageSize

            Dim searchTerm As String = If(txtSearch Is Nothing, "", txtSearch.Text.Trim())
            Dim sql As String = "SELECT l.LogDateTime AS LogTimestamp, CONCAT(u.FirstName, ' ', u.LastName) AS StaffName, " &
                            "l.EventType, l.ApplicationModule, l.Details " &
                            "FROM logs l " &
                            "LEFT JOIN users u ON l.UserID = u.UserID " &
                            "WHERE l.LogDateTime BETWEEN @StartDate AND @EndDate "

            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                sql &= "AND l.Details LIKE @SearchTerm "
            End If

            sql &= "ORDER BY l.LogDateTime DESC LIMIT @StartIndex, @PageSize;"

            Using adapter As New MySqlDataAdapter(sql, modDB.strConnection)
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1))
                adapter.SelectCommand.Parameters.AddWithValue("@StartIndex", cacheStartRowIndex)
                adapter.SelectCommand.Parameters.AddWithValue("@PageSize", PageSize)

                If Not String.IsNullOrWhiteSpace(searchTerm) Then
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
                End If

                adapter.Fill(cache)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error fetching log page: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RefreshGridData()
        Try
            If dtpStartDate Is Nothing OrElse dtpEndDate Is Nothing OrElse dgvLogs Is Nothing Then Exit Sub

            Dim searchTerm As String = If(txtSearch Is Nothing, "", txtSearch.Text.Trim())
            Dim countSql As String = "SELECT COUNT(*) FROM logs l WHERE l.LogDateTime BETWEEN @StartDate AND @EndDate "
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                countSql &= "AND l.Details LIKE @SearchTerm "
            End If

            Dim totalRecords As Integer = 0
            Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(countSql, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date)
                cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1))
                If Not String.IsNullOrWhiteSpace(searchTerm) Then
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
                End If

                Dim result = cmd.ExecuteScalar()
                If Not IsDBNull(result) Then
                    totalRecords = Convert.ToInt32(result)
                End If
            End Using

            cache.Clear()
            cacheStartRowIndex = -1
            dgvLogs.RowCount = totalRecords
            dgvLogs.Refresh()

        Catch ex As Exception
            MessageBox.Show("Error loading activity logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnApplyFilter_Click(sender As Object, e As EventArgs) Handles btnApplyFilter.Click
        RefreshGridData()
    End Sub

#End Region

End Class
