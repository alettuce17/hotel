Imports MySql.Data.MySqlClient
Imports BCrypt.Net

Public Class frmCreateAccount

    Private isCreatingAdmin As Boolean

    ' REVISED: The constructor is now simple and requires no parameters.
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmCreateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' REVISED: The form now automatically detects which type of account to create.
        If modDB.AdminAccountExists() Then
            ' If an admin already exists, this form will create a Staff account.
            isCreatingAdmin = False
            Me.Text = "Create New Staff Account"
        Else
            ' If no admin exists, this form will create the initial Admin account.
            isCreatingAdmin = True
            Me.Text = "Create Initial Administrator Account"
        End If


    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MsgBox("All fields are required.", MsgBoxStyle.Exclamation)
            Return
        End If

        If txtPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("Passwords do not match.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' --- REVISED: Automatically determine the Role ID ---
        Dim selectedRoleID As Integer
        If isCreatingAdmin Then
            ' If we are creating an admin, use RoleID 3.
            selectedRoleID = 3 ' As per your requirement for Admin
        Else
            ' Otherwise, create a standard Staff account with RoleID 1.
            selectedRoleID = 1 ' As per your requirement for Staff
        End If

        ' --- Database Insertion ---
        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                ' 1. Create the user record.
                Dim userSql As String = "INSERT INTO users (Username, PasswordHash, Email, FirstName, LastName, IsActive) VALUES (@Username, @PasswordHash, @Email, @FirstName, @LastName, 1);"
                Dim newUserID As Integer = 0
                Using userCmd As New MySqlCommand(userSql, conn, transaction)
                    userCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    userCmd.Parameters.AddWithValue("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                    userCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    userCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                    userCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                    userCmd.ExecuteNonQuery()
                    newUserID = CInt(userCmd.LastInsertedId)
                End Using

                If newUserID = 0 Then Throw New Exception("Failed to create the user profile.")

                ' 2. Create the staff record with the automatically determined RoleID.
                Dim staffSql As String = "INSERT INTO staff (UserID, RoleID, HireDate, Salary, EmploymentStatus) VALUES (@UserID, @RoleID, CURDATE(), 0, 'Active');"
                Using staffCmd As New MySqlCommand(staffSql, conn, transaction)
                    staffCmd.Parameters.AddWithValue("@UserID", newUserID)
                    staffCmd.Parameters.AddWithValue("@RoleID", selectedRoleID)
                    staffCmd.ExecuteNonQuery()
                End Using

                transaction.Commit()
                MsgBox("Account created successfully.", MsgBoxStyle.Information, "Success")
                Me.Close()

            Catch ex As Exception
                transaction.Rollback()
                MsgBox($"Failed to create account: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
