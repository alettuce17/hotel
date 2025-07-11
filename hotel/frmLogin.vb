Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- 1. Initialize Connection and Form Properties ---
        ' The form assumes the configuration is now present.
        modDB.InitializeConnectionString()

        ' If the connection string is still empty (e.g., user closed config), exit.
        If String.IsNullOrEmpty(modDB.strConnection) Then
            MsgBox("Database is not configured. Application will exit.", MsgBoxStyle.Critical, "Configuration Error")
            Application.Exit()
            Return
        End If

        ' Dynamically set the form's title
        Dim hotelTitle As String = $"{modDB.GetHotelName()} - Staff Portal"
        Me.Text = hotelTitle
        ' If you have a title label on your form, update it too:
        ' lblTitle.Text = hotelTitle

        ' Set Form Properties for a Dialog-like appearance
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ' Set the AcceptButton so pressing Enter clicks the Login button.
        Me.AcceptButton = btnLogin
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(txtUsername.Text) Or String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("Please enter both a username and password.", MsgBoxStyle.Exclamation, "Input Required")
            Return
        End If

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim userFound As Boolean = False

        ' --- Database Query ---
        Dim sql As String = "SELECT u.UserID, u.PasswordHash, u.FirstName, u.LastName, s.StaffID, r.RoleID, r.RoleName " &
                            "FROM users u " &
                            "JOIN staff s ON u.UserID = s.UserID " &
                            "JOIN roles r ON s.RoleID = r.RoleID " &
                            "WHERE u.Username = @Username AND u.IsActive = 1"

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Username", username)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            userFound = True
                            Dim storedHash As String = reader("PasswordHash").ToString()
                            ' --- Password Verification ---
                            If modDB.VerifyPassword(password, storedHash) Then
                                ' --- Success: Populate LoggedInUser ---
                                modDB.LoggedInUser.UserID = CInt(reader("UserID"))
                                modDB.LoggedInUser.StaffID = CInt(reader("StaffID"))
                                modDB.LoggedInUser.RoleID = CInt(reader("RoleID"))
                                modDB.LoggedInUser.RoleName = reader("RoleName").ToString()
                                modDB.LoggedInUser.FullName = $"{reader("FirstName")} {reader("LastName")}"
                                modDB.LoggedInUser.Username = username
                                modDB.Logs("Login Success", "Authentication", $"User '{username}' logged in successfully.")
                                ' Open the main form and hide this one
                                Dim frm As New frmMain()
                                frm.Show()
                                Me.Hide()
                            Else
                                MsgBox("Invalid username or password.", MsgBoxStyle.Critical, "Login Failed")
                                modDB.Logs("Login Failed", "Authentication", $"Failed login attempt for user '{username}' - Incorrect password.")
                            End If
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox($"An error occurred while trying to log in.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical, "Database Error")
                modDB.Logs("Login Error", "Authentication", $"Database error during login for user '{username}': {ex.Message}")
                Return
            End Try
        End Using

        ' --- Handle User Not Found ---
        If Not userFound Then
            MsgBox("Invalid username or password.", MsgBoxStyle.Critical, "Login Failed")
            modDB.Logs("Login Failed", "Authentication", $"Failed login attempt for non-existent or inactive user '{username}'.")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked = True Then
            txtPassword.PasswordChar = vbNullChar
        Else
            txtPassword.PasswordChar = "*"
        End If
    End Sub
    Private Sub txtCommon_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles txtUsername.KeyDown, txtPassword.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.Back Then
            Dim tb As TextBox = CType(sender, TextBox)
            Dim caretPos As Integer = tb.SelectionStart

            If caretPos > 0 Then
                Dim textBefore As String = tb.Text.Substring(0, caretPos)
                Dim textAfter As String = tb.Text.Substring(tb.SelectionStart)

                ' Find the last space before the caret
                Dim lastSpaceIndex As Integer = textBefore.TrimEnd().LastIndexOf(" "c)

                ' If no space found, delete from start
                If lastSpaceIndex = -1 Then lastSpaceIndex = 0

                ' Reconstruct the string with the word removed
                tb.Text = textBefore.Substring(0, lastSpaceIndex).TrimEnd() & textAfter

                ' Set caret position
                tb.SelectionStart = lastSpaceIndex
            End If

            ' Prevent the weird  character from appearing
            e.SuppressKeyPress = True
        End If
    End Sub

End Class
