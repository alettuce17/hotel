Imports MySql.Data.MySqlClient

Public Class frmGuestManagement

#Region "Class-level Variables"

    ' --- Virtual Mode & Cache Variables ---
    Private cache As New DataTable()
    Private cacheStartRowIndex As Integer = -1
    Private ReadOnly PageSize As Integer = 100

    ' --- Form State Variables ---
    Private selectedGuestID As Integer = 0
    Private selectedUserID As Integer = 0

#End Region

#Region "Form Load & Initial Setup"

    Private Sub frmGuestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupVirtualGrid()
        RefreshGridData()
        ClearSelection()
    End Sub

    Private Sub SetupVirtualGrid()
        dgvGuests.VirtualMode = True
        dgvGuests.ReadOnly = True
        dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvGuests.RowHeadersVisible = False
        dgvGuests.AllowUserToAddRows = False

        dgvGuests.Columns.Clear()
        dgvGuests.Columns.Add("FirstName", "First Name")
        dgvGuests.Columns.Add("LastName", "Last Name")
        dgvGuests.Columns.Add("Email", "Email")
        dgvGuests.Columns.Add("TierName", "Loyalty Tier")
        dgvGuests.Columns.Add("TotalNights", "Total Nights")

        For Each col As DataGridViewColumn In dgvGuests.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

#End Region

#Region "Virtual Mode Data Handling"

    Private Sub dgvGuests_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvGuests.CellValueNeeded
        If cacheStartRowIndex = -1 OrElse e.RowIndex < cacheStartRowIndex OrElse e.RowIndex >= cacheStartRowIndex + cache.Rows.Count Then
            FetchPage(e.RowIndex)
        End If
        Dim relativeIndex = e.RowIndex - cacheStartRowIndex
        If relativeIndex >= 0 AndAlso relativeIndex < cache.Rows.Count Then
            Dim colName = dgvGuests.Columns(e.ColumnIndex).Name
            e.Value = cache.Rows(relativeIndex)(colName)
        End If
    End Sub

    Private Sub FetchPage(rowIndex As Integer)
        cache.Clear()
        cacheStartRowIndex = (rowIndex \ PageSize) * PageSize

        Dim searchTerm As String = txtSearch.Text.Trim()
        Dim sql As String = "SELECT g.GuestID, u.UserID, u.FirstName, u.LastName, u.Email, u.PhoneNumber, IFNULL(lt.TierName, 'Not Enrolled') AS TierName, g.TotalNights " &
                            "FROM users u JOIN guests g ON u.UserID = g.UserID " &
                            "LEFT JOIN loyaltytiers lt ON g.LoyaltyTierID = lt.TierID "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            sql &= "WHERE u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm OR u.Email LIKE @SearchTerm "
        End If
        sql &= "ORDER BY u.LastName, u.FirstName LIMIT @StartIndex, @PageSize;"

        Using adapter As New MySqlDataAdapter(sql, modDB.strConnection)
            adapter.SelectCommand.Parameters.AddWithValue("@StartIndex", cacheStartRowIndex)
            adapter.SelectCommand.Parameters.AddWithValue("@PageSize", PageSize)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            adapter.Fill(cache)
        End Using
    End Sub

    Private Sub RefreshGridData()
        Dim searchTerm As String = txtSearch.Text.Trim()
        Dim countSql As String = "SELECT COUNT(*) FROM users u JOIN guests g ON u.UserID = g.UserID "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            countSql &= "WHERE u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm OR u.Email LIKE @SearchTerm "
        End If

        Dim totalRecords As Integer = 0
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(countSql, conn)
            conn.Open()
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
        End Using

        cache.Clear()
        cacheStartRowIndex = -1
        dgvGuests.RowCount = totalRecords
        dgvGuests.Refresh()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        RefreshGridData()
    End Sub

#End Region

#Region "Form Logic"

    Private Sub ClearSelection()
        selectedGuestID = 0
        selectedUserID = 0
        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        lblTierName.Text = "N/A"
        lblTotalNights.Text = "0"
        dgvGuests.ClearSelection()
        gbGuestDetails.Enabled = False
        btnChangePassword.Enabled = False ' Disable button
    End Sub

    Private Sub dgvGuests_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGuests.CellClick
        If e.RowIndex < 0 Then Return

        Dim clickedUserID As Integer = 0
        Dim clickedGuestID As Integer = 0
        Dim searchTerm As String = txtSearch.Text.Trim()

        Dim idSql As String = "SELECT u.UserID, g.GuestID FROM users u JOIN guests g ON u.UserID = g.UserID "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            idSql &= "WHERE u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm OR u.Email LIKE @SearchTerm "
        End If
        idSql &= "ORDER BY u.LastName, u.FirstName LIMIT 1 OFFSET @RowIndex;"

        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(idSql, conn)
            conn.Open()
            cmd.Parameters.AddWithValue("@RowIndex", e.RowIndex)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    clickedUserID = CInt(reader("UserID"))
                    clickedGuestID = CInt(reader("GuestID"))
                End If
            End Using
        End Using

        If clickedUserID = 0 Then
            MsgBox("Could not retrieve details for the selected row.", MsgBoxStyle.Critical) : Return
        End If

        selectedUserID = clickedUserID
        selectedGuestID = clickedGuestID

        Dim detailSql As String = "SELECT * FROM users u JOIN guests g ON u.UserID = g.UserID LEFT JOIN loyaltytiers lt ON g.LoyaltyTierID = lt.TierID WHERE u.UserID = @UserID;"
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(detailSql, conn)
            conn.Open()
            cmd.Parameters.AddWithValue("@UserID", selectedUserID)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtFirstName.Text = reader("FirstName").ToString()
                    txtLastName.Text = reader("LastName").ToString()
                    txtEmail.Text = reader("Email").ToString()
                    txtPhone.Text = reader("PhoneNumber").ToString()
                    lblTierName.Text = If(IsDBNull(reader("TierName")), "Not Enrolled", reader("TierName").ToString())
                    lblTotalNights.Text = reader("TotalNights").ToString()
                    gbGuestDetails.Enabled = True
                    btnChangePassword.Enabled = True ' Enable button
                End If
            End Using
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If selectedUserID = 0 Then
            MsgBox("Please select a guest from the list to edit.", MsgBoxStyle.Information) : Return
        End If
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MsgBox("First Name and Last Name cannot be empty.", MsgBoxStyle.Exclamation) : Return
        End If

        Dim sql As String = "UPDATE users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @Phone WHERE UserID = @UserID;"
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            conn.Open()
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text)
            cmd.Parameters.AddWithValue("@UserID", selectedUserID)
            cmd.ExecuteNonQuery()
        End Using

        MsgBox("Guest details saved successfully.", MsgBoxStyle.Information, "Success")
        modDB.Logs("Guest Updated", "Management", $"Guest details for UserID {selectedUserID} were updated.", "users", selectedUserID)
        RefreshGridData()
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        If selectedUserID = 0 Then Return

        ' Confirm the action with the staff member
        If MsgBox($"Are you sure you want to reset the password for {txtFirstName.Text} {txtLastName.Text}?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Return
        End If

        ' Prompt for the new temporary password
        Dim newPassword As String = InputBox("Enter the new temporary password for the guest:", "Reset Password")

        If String.IsNullOrWhiteSpace(newPassword) Then
            MsgBox("Password cannot be empty. The password was not changed.", MsgBoxStyle.Critical)
            Return
        End If

        ' Hash the new password and update the database
        Dim hashedPassword As String = BCrypt.Net.BCrypt.HashPassword(newPassword)
        Dim sql As String = "UPDATE users SET PasswordHash = @PasswordHash WHERE UserID = @UserID;"

        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            Try
                conn.Open()
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword)
                cmd.Parameters.AddWithValue("@UserID", selectedUserID)
                cmd.ExecuteNonQuery()

                ' Provide clear feedback to the staff
                MsgBox($"Password has been reset successfully.{vbCrLf}{vbCrLf}Please provide the following temporary password to the guest:{vbCrLf}{newPassword}", MsgBoxStyle.Information, "Password Reset")
                modDB.Logs("Password Reset", "Management", $"Password was reset for guest UserID {selectedUserID}.", "users", selectedUserID)

            Catch ex As Exception
                MsgBox($"An error occurred while changing the password: {ex.Message}", MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

End Class
