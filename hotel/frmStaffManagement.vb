Imports MySql.Data.MySqlClient
Public Class frmStaffManagement

#Region "Class-level Variables"
    Private cache As New DataTable() ' Holds one "page" of data at a time.
    Private cacheStartRowIndex As Integer = -1 ' The absolute index of the first row in our cache.
    Private ReadOnly PageSize As Integer = 100 ' Load 100 records at a time for smooth scrolling.

    Private selectedUserID As Integer = 0
    Private selectedStaffID As Integer = 0
#End Region

#Region "Form Load & Initial Setup"
    Private Sub frmStaffManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        numSalary.Maximum = 1000000
        LoadRoles()
        LoadEmploymentStatuses()
        SetupVirtualGrid()
        RefreshGridData()
        ClearSelection()
    End Sub

    Private Sub SetupVirtualGrid()
        dgvStaff.VirtualMode = True
        dgvStaff.ReadOnly = True
        dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStaff.RowHeadersVisible = False
        dgvStaff.AllowUserToAddRows = False

        dgvStaff.Columns.Clear()
        dgvStaff.Columns.Add("FirstName", "First Name")
        dgvStaff.Columns.Add("LastName", "Last Name")
        dgvStaff.Columns.Add("Email", "Email")
        dgvStaff.Columns.Add("RoleName", "Role")
        dgvStaff.Columns.Add("EmploymentStatus", "Status")
        dgvStaff.Columns.Add("UserID", "UserID")
        dgvStaff.Columns("UserID").Visible = False
        dgvStaff.Columns.Add("StaffID", "StaffID")
        dgvStaff.Columns("StaffID").Visible = False

        For Each col As DataGridViewColumn In dgvStaff.Columns
            If col.Name <> "UserID" AndAlso col.Name <> "StaffID" Then
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Next
    End Sub

    Private Sub LoadRoles()
        cboRole.DataSource = Nothing
        Dim dt As New DataTable()
        dt.Columns.Add("RoleID", GetType(Integer))
        dt.Columns.Add("RoleName", GetType(String))
        Dim sql As String = "SELECT RoleID, RoleName FROM roles ORDER BY RoleName;"
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            conn.Open()
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    dt.Rows.Add(reader("RoleID"), reader("RoleName"))
                End While
            End Using
        End Using
        cboRole.DataSource = dt
        cboRole.DisplayMember = "RoleName"
        cboRole.ValueMember = "RoleID"
    End Sub

    Private Sub LoadEmploymentStatuses()
        cboStatus.Items.Clear()
        cboStatus.Items.Add("Active")
        cboStatus.Items.Add("On Leave")
        cboStatus.Items.Add("Terminated")
    End Sub
#End Region

#Region "Virtual Mode Data Handling"
    Private Sub dgvStaff_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvStaff.CellValueNeeded
        If cacheStartRowIndex = -1 OrElse e.RowIndex < cacheStartRowIndex OrElse e.RowIndex >= cacheStartRowIndex + cache.Rows.Count Then
            FetchPage(e.RowIndex)
        End If

        Dim relativeIndex = e.RowIndex - cacheStartRowIndex
        If relativeIndex >= 0 AndAlso relativeIndex < cache.Rows.Count Then
            Dim colName = dgvStaff.Columns(e.ColumnIndex).Name
            e.Value = cache.Rows(relativeIndex)(colName)
        End If
    End Sub

    Private Sub FetchPage(rowIndex As Integer)
        cache.Clear()
        cacheStartRowIndex = (rowIndex \ PageSize) * PageSize

        Dim searchTerm As String = txtSearch.Text.Trim()
        Dim sql As String = "SELECT u.UserID, s.StaffID, u.FirstName, u.LastName, u.Email, r.RoleName, s.EmploymentStatus " &
                            "FROM users u " &
                            "JOIN staff s ON u.UserID = s.UserID " &
                            "JOIN roles r ON s.RoleID = r.RoleID "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            sql &= "WHERE u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm "
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
        Dim countSql As String = "SELECT COUNT(*) FROM users u JOIN staff s ON u.UserID = s.UserID "
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            countSql &= "WHERE u.FirstName LIKE @SearchTerm OR u.LastName LIKE @SearchTerm "
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
        dgvStaff.RowCount = totalRecords
        dgvStaff.Refresh()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        RefreshGridData()
    End Sub
#End Region

#Region "Form Logic (Add, Edit, Save)"
    Private Sub ClearSelection()
        selectedUserID = 0
        selectedStaffID = 0
        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtPassword.Clear()
        cboRole.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        numSalary.Value = 0
        dgvStaff.ClearSelection()
        gbStaffDetails.Text = "Add New Staff Member"
        txtFirstName.Focus()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ClearSelection()
    End Sub

    Private Sub dgvStaff_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStaff.CellClick
        If e.RowIndex < 0 Then Return

        Dim relativeIndex As Integer = e.RowIndex - cacheStartRowIndex
        If relativeIndex < 0 OrElse relativeIndex >= cache.Rows.Count Then
            MsgBox("Selected row is outside the cached range.", MsgBoxStyle.Exclamation) : Return
        End If

        Dim row As DataRow = cache.Rows(relativeIndex)
        selectedUserID = CInt(row("UserID"))
        selectedStaffID = CInt(row("StaffID"))

        Dim detailSql As String = "SELECT * FROM users u JOIN staff s ON u.UserID = s.UserID WHERE u.UserID = @UserID;"
        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(detailSql, conn)
            conn.Open()
            cmd.Parameters.AddWithValue("@UserID", selectedUserID)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtFirstName.Text = reader("FirstName").ToString()
                    txtLastName.Text = reader("LastName").ToString()
                    txtEmail.Text = reader("Email").ToString()
                    txtPhone.Text = reader("PhoneNumber").ToString()
                    cboRole.SelectedValue = CInt(reader("RoleID"))
                    cboStatus.SelectedItem = reader("EmploymentStatus").ToString()
                    numSalary.Value = CDec(reader("Salary"))
                    txtPassword.Clear()
                    gbStaffDetails.Text = "Edit Staff Member Details"
                End If
            End Using
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse String.IsNullOrWhiteSpace(txtLastName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MsgBox("First Name, Last Name, and Email are required.", MsgBoxStyle.Exclamation, "Input Error") : Return
        End If
        If cboRole.SelectedIndex = -1 OrElse cboStatus.SelectedIndex = -1 Then
            MsgBox("You must select a Role and an Employment Status.", MsgBoxStyle.Exclamation, "Input Error") : Return
        End If
        If selectedUserID = 0 AndAlso String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("A password is required for new staff members.", MsgBoxStyle.Exclamation, "Input Error") : Return
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                Dim userIDToUpdate As Integer = selectedUserID
                If userIDToUpdate > 0 Then ' UPDATE
                    Dim userSql As String = "UPDATE users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @Phone "
                    If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        userSql &= ", PasswordHash = @PasswordHash "
                    End If
                    userSql &= "WHERE UserID = @UserID;"
                    Using cmd As New MySqlCommand(userSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text)
                        If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                            cmd.Parameters.AddWithValue("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                        End If
                        cmd.Parameters.AddWithValue("@UserID", userIDToUpdate)
                        cmd.ExecuteNonQuery()
                    End Using
                Else ' INSERT
                    Dim userSql As String = "INSERT INTO users (FirstName, LastName, Email, Username, PhoneNumber, PasswordHash, IsActive) " &
                                            "VALUES (@FirstName, @LastName, @Email, @Username, @PhoneNumber, @PasswordHash, 1);"
                    Using cmd As New MySqlCommand(userSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                        cmd.Parameters.AddWithValue("@Username", txtEmail.Text)
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text)
                        cmd.Parameters.AddWithValue("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                        cmd.ExecuteNonQuery()
                        userIDToUpdate = CInt(cmd.LastInsertedId)
                    End Using
                End If

                If selectedStaffID > 0 Then ' UPDATE staff
                    Dim staffSql As String = "UPDATE staff SET RoleID = @RoleID, Salary = @Salary, EmploymentStatus = @Status WHERE StaffID = @StaffID;"
                    Using cmd As New MySqlCommand(staffSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@RoleID", cboRole.SelectedValue)
                        cmd.Parameters.AddWithValue("@Salary", numSalary.Value)
                        cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem.ToString())
                        cmd.Parameters.AddWithValue("@StaffID", selectedStaffID)
                        cmd.ExecuteNonQuery()
                    End Using
                Else ' INSERT staff
                    Dim staffSql As String = "INSERT INTO staff (UserID, RoleID, Salary, EmploymentStatus, HireDate) " &
                                            "VALUES (@UserID, @RoleID, @Salary, @Status, CURDATE());"
                    Using cmd As New MySqlCommand(staffSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@UserID", userIDToUpdate)
                        cmd.Parameters.AddWithValue("@RoleID", cboRole.SelectedValue)
                        cmd.Parameters.AddWithValue("@Salary", numSalary.Value)
                        cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem.ToString())
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                transaction.Commit()
                MsgBox("Staff details saved successfully.", MsgBoxStyle.Information, "Success")
                RefreshGridData()
                ClearSelection()
            Catch ex As Exception
                transaction.Rollback()
                MsgBox($"An error occurred while saving: {ex.Message}", MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub


#End Region

End Class
