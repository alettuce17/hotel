Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmConfig

#Region "Form Load & Helper Methods"

    Private Sub frmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Database Configuration"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        LoadConfig()
    End Sub

    Private Sub LoadConfig()
        Dim configFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")
        If Not File.Exists(configFile) Then Return
        Try
            Dim config As New Dictionary(Of String, String)
            For Each line In File.ReadLines(configFile)
                If line.Contains("=") And Not String.IsNullOrWhiteSpace(line) Then
                    Dim parts = line.Split(New Char() {"="c}, 2)
                    config(parts(0).Trim()) = parts(1).Trim()
                End If
            Next
            txtServer.Text = If(config.ContainsKey("server"), config("server"), "")
            txtPort.Text = If(config.ContainsKey("port"), config("port"), "3306")
            txtDatabase.Text = If(config.ContainsKey("database"), config("database"), "")
            txtUser.Text = If(config.ContainsKey("user"), config("user"), "")
            txtPassword.Text = If(config.ContainsKey("password"), config("password"), "")
        Catch ex As Exception
            MsgBox($"Error reading configuration file.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical, "File Read Error")
        End Try
    End Sub

    ''' <summary>
    ''' Validates the user input in the textboxes.
    ''' </summary>
    ''' <returns>True if all inputs are valid, otherwise False.</returns>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtServer.Text) Then
            MsgBox("Server address cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtServer.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPort.Text) Then
            MsgBox("Port number cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtPort.Focus()
            Return False
        End If

        ' Use Integer.TryParse for robust numeric validation
        Dim portNumber As Integer
        If Not Integer.TryParse(txtPort.Text, portNumber) Then
            MsgBox("Port must be a valid number.", MsgBoxStyle.Exclamation, "Input Error")
            txtPort.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDatabase.Text) Then
            MsgBox("Database name cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtDatabase.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUser.Text) Then
            MsgBox("User ID cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtUser.Focus()
            Return False
        End If

        ' All checks passed
        Return True
    End Function

    ''' <summary>
    ''' Attempts to connect to the database using the provided connection string.
    ''' </summary>
    ''' <param name="connectionString">The full connection string to test.</param>
    ''' <returns>True if connection is successful, False otherwise.</returns>
    Private Function CanConnect(ByVal connectionString As String) As Boolean
        Using tempConn As New MySqlConnection(connectionString)
            Try
                tempConn.Open()
                Return True ' Connection was successful
            Catch ex As MySqlException
                MsgBox($"Database Connection Failed!{vbCrLf}{vbCrLf}Error: {ex.Message}", MsgBoxStyle.Critical, "Database Error")
                Return False ' Connection failed
            Catch ex As Exception
                MsgBox($"Connection Failed!{vbCrLf}{ex.Message}", MsgBoxStyle.Critical, "Connection Error")
                Return False ' Connection failed
            End Try
        End Using
    End Function

#End Region

#Region "Button Click Events"

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        ' --- 1. Validate Input First ---
        If Not ValidateInputs() Then
            Return ' Stop execution if validation fails
        End If

        ' --- 2. Attempt Connection ---
        Dim testConnectionString As String = $"server={txtServer.Text};port={txtPort.Text};user id={txtUser.Text};password={txtPassword.Text};database={txtDatabase.Text};"
        If CanConnect(testConnectionString) Then
            MsgBox("Connection Successful!", MsgBoxStyle.Information, "Success")
        End If
        ' If it fails, the error message is handled inside CanConnect.
    End Sub

    ''' <summary>
    ''' Handles the click event for the Save button.
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- 1. Validate Input First ---
        If Not ValidateInputs() Then
            Return ' Stop execution if validation fails
        End If

        ' --- 2. Test Connectivity Before Saving ---
        Dim testConnectionString As String = $"server={txtServer.Text};port={txtPort.Text};user id={txtUser.Text};password={txtPassword.Text};database={txtDatabase.Text};"
        If Not CanConnect(testConnectionString) Then
            ' If connection fails, show error (handled in CanConnect) and stop.
            Return
        End If

        ' --- 3. Save to File (Only if connection was successful) ---
        Dim configFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")
        Dim lines As New List(Of String)
        lines.Add($"server={txtServer.Text}")
        lines.Add($"port={txtPort.Text}")
        lines.Add($"database={txtDatabase.Text}")
        lines.Add($"user={txtUser.Text}")
        lines.Add($"password={txtPassword.Text}")

        Try
            File.WriteAllLines(configFile, lines)
            MsgBox("Settings saved successfully.", MsgBoxStyle.Information, "Saved")

            ' Directly open the login form and then hide this configuration form.
            Dim loginForm As New frmLogin()
            loginForm.Show()
            Me.Hide() ' Hide this form instead of closing it

        Catch ex As Exception
            MsgBox($"Could not save the configuration file.{vbCrLf}{ex.Message}", MsgBoxStyle.Critical, "Save Error")
        End Try
    End Sub

    Private Sub lblServer_Click(sender As Object, e As EventArgs) Handles lblServer.Click

    End Sub

#End Region

End Class
