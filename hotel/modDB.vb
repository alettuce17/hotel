Imports System.IO
Imports MySql.Data.MySqlClient
' You will need to add the BCrypt.Net-Next NuGet package to your project for this to work
' In Visual Studio: Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution... -> Browse for "BCrypt.Net-Next" and install it.
Imports BCrypt.Net

Module modDB
    ' --- Database Connection ---
    Public conn As MySqlConnection
    Public strConnection As String

    ' --- Current User Information ---
    ' This structure holds details for the logged-in user (staff/admin)
    Public Structure CurrentUser
        Dim UserID As Integer
        Dim StaffID As Integer
        Dim RoleID As Integer
        Dim RoleName As String ' "Admin" or "Staff"
        Dim FullName As String
        Dim Username As String
    End Structure
    Public LoggedInUser As CurrentUser

    ''' <summary>
    ''' Reads the config.txt file and sets the global database connection string.
    ''' This should be the first function called on application startup.
    ''' </summary>
    Public Sub InitializeConnectionString()
        Dim configFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")

        If Not File.Exists(configFile) Then
            MsgBox("Database configuration file (config.txt) not found. Please configure the database connection.", MsgBoxStyle.Critical, "Configuration Error")
            ' Show the configuration form so the user can create the file.
            Dim configForm As New frmConfig()
            configForm.ShowDialog()
            Exit Sub
        End If

        Try
            Dim config As New Dictionary(Of String, String)
            For Each line In File.ReadLines(configFile)
                If line.Contains("=") Then
                    Dim parts = line.Split(New Char() {"="c}, 2)
                    config(parts(0).Trim()) = parts(1).Trim()
                End If
            Next

            strConnection = $"server={config("server")};" &
                            $"port={config("port")};" &
                            $"user id={config("user")};" &
                            $"password={config("password")};" &
                            $"database={config("database")};" &
                            "AllowUserVariables=True;"

        Catch ex As Exception
            MsgBox($"Error reading config file: {ex.Message}", MsgBoxStyle.Critical, "Configuration Error")
        End Try
    End Sub

    ''' <summary>
    ''' Checks if a connection to the database can be established using the global connection string.
    ''' </summary>
    ''' <returns>True if the connection is successful, otherwise False.</returns>
    Public Function IsConnected() As Boolean
        If String.IsNullOrEmpty(strConnection) Then Return False

        Using tempConn As New MySqlConnection(strConnection)
            Try
                tempConn.Open()
                Return tempConn.State = ConnectionState.Open
            Catch ex As MySqlException
                ' Catch specific MySQL exceptions for more detailed error messages
                MsgBox($"Database connection failed.{vbCrLf}{vbCrLf}Error: {ex.Message}{vbCrLf}(Error Code: {ex.Number})", MsgBoxStyle.Critical, "Database Error")
                Return False
            Catch ex As Exception
                MsgBox($"An unexpected error occurred: {ex.Message}", MsgBoxStyle.Critical, "Connection Error")
                Return False
            End Try
        End Using ' The connection is automatically closed here
    End Function

    ' --- Password Management ---
    ''' <summary>
    ''' Verifies a plaintext password against a stored bcrypt hash.
    ''' </summary>
    ''' <param name="password">The plaintext password entered by the user.</param>
    ''' <param name="hashedPassword">The hash retrieved from the database's `PasswordHash` column.</param>
    ''' <returns>True if the password matches the hash.</returns>
    Public Function VerifyPassword(password As String, hashedPassword As String) As Boolean
        Try
            Return BCrypt.Net.BCrypt.Verify(password, hashedPassword)
        Catch ex As Exception
            Logs("Password Verification Error", "Authentication", $"Error verifying hash: {ex.Message}")
            Return False
        End Try
    End Function

    ' --- Data Loading ---
    ''' <summary>
    ''' Executes a query and loads the result into a DataGridView.
    ''' </summary>
    ''' <param name="query">The SQL SELECT query to execute.</param>
    ''' <param name="dgv">The DataGridView to populate.</param>
    ''' <returns>The number of rows loaded.</returns>
    Public Function LoadToDGV(query As String, dgv As DataGridView) As Integer
        Try
            Using adapter As New MySqlDataAdapter(query, strConnection)
                Dim dt As New DataTable
                adapter.Fill(dt)
                dgv.DataSource = dt
                dgv.Refresh()
                Return dgv.Rows.Count
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Database Error")
            Return 0
        End Try
    End Function

    ' --- Auditing / Logging ---
    ''' <summary>
    ''' Records an event into the 'logs' table. Aligns with your hoteldb schema.
    ''' </summary>
    Public Sub Logs(EventType As String, ApplicationModule As String, Optional Details As String = "", Optional AffectedTable As String = Nothing, Optional AffectedRecordID As Integer? = Nothing)
        Dim sql As String = "INSERT INTO `logs` (`UserID`, `EventType`, `ApplicationModule`, `Details`, `AffectedTable`, `AffectedRecordID`, `IPAddress`) " &
                            "VALUES (@UserID, @EventType, @ApplicationModule, @Details, @AffectedTable, @AffectedRecordID, @IPAddress);"

        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UserID", If(LoggedInUser.UserID > 0, CType(LoggedInUser.UserID, Object), DBNull.Value))
                    cmd.Parameters.AddWithValue("@EventType", EventType)
                    cmd.Parameters.AddWithValue("@ApplicationModule", ApplicationModule)
                    cmd.Parameters.AddWithValue("@Details", If(String.IsNullOrEmpty(Details), CType(DBNull.Value, Object), Details))
                    cmd.Parameters.AddWithValue("@AffectedTable", If(String.IsNullOrEmpty(AffectedTable), CType(DBNull.Value, Object), AffectedTable))
                    cmd.Parameters.AddWithValue("@AffectedRecordID", If(AffectedRecordID.HasValue, CType(AffectedRecordID.Value, Object), DBNull.Value))
                    cmd.Parameters.AddWithValue("@IPAddress", "127.0.0.1") ' Placeholder

                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                File.AppendAllText("error_log.txt", $"{DateTime.Now}: Failed to write to database log. Error: {ex.Message}{vbCrLf}")
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Retrieves the hotel name from the settings table.
    ''' </summary>
    ''' <returns>The hotel name as a string, or a default name if not found.</returns>
    Public Function GetHotelName() As String
        Dim hotelName As String = "Hotel System" ' Default name in case of failure
        Dim sql As String = "SELECT HotelName FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"

        ' Ensure the connection string is initialized before trying to connect
        If String.IsNullOrEmpty(strConnection) Then Return hotelName

        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    ' ExecuteScalar is efficient for retrieving a single value
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        hotelName = result.ToString()
                    End If
                End Using
            Catch ex As Exception
                ' Silently fail; the default name will be used.
                ' This prevents a crash if the database is not yet configured on first run.
            End Try
        End Using
        Return hotelName
    End Function
    Public Function GetTaxRate() As Decimal
        Dim taxRate As Decimal = 0
        Dim sql As String = "SELECT TaxRatePercentage FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"
        If String.IsNullOrEmpty(strConnection) Then Return 0
        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        taxRate = CDec(result)
                    End If
                End Using
            Catch ex As Exception
                ' Silently fail, returns 0
            End Try
        End Using
        Return taxRate
    End Function
    Public Function GetWebsiteUrl() As String
        Dim websiteUrl As String = ""
        Dim sql As String = "SELECT WebsiteURL FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"
        If String.IsNullOrEmpty(strConnection) Then Return ""
        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        websiteUrl = result.ToString()
                    End If
                End Using
            Catch ex As Exception
                ' Silently fail, returns an empty string
            End Try
        End Using
        Return websiteUrl
    End Function
    ''' <summary>
    ''' Retrieves the default check-in time from the hotel settings.
    ''' </summary>
    ''' <returns>The check-in time as a string (e.g., "15:00").</returns>
    Public Function GetCheckInTime() As String
        Dim checkInTime As String = "15:00" ' Default value in case of failure
        Dim sql As String = "SELECT CheckInTimeDefault FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"
        If String.IsNullOrEmpty(strConnection) Then Return checkInTime
        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        ' The database stores it as a TimeSpan, so we format it
                        Dim timeSpanResult As TimeSpan = CType(result, TimeSpan)
                        checkInTime = timeSpanResult.ToString("hh\:mm")
                    End If
                End Using
            Catch ex As Exception
                ' Silently fail, returns the default time
            End Try
        End Using
        Return checkInTime
    End Function

    ''' <summary>
    ''' Retrieves the default check-out time from the hotel settings.
    ''' </summary>
    ''' <returns>The check-out time as a string (e.g., "11:00").</returns>
    Public Function GetCheckOutTime() As String
        Dim checkOutTime As String = "11:00" ' Default value in case of failure
        Dim sql As String = "SELECT CheckOutTimeDefault FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"
        If String.IsNullOrEmpty(strConnection) Then Return checkOutTime
        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        ' The database stores it as a TimeSpan, so we format it
                        Dim timeSpanResult As TimeSpan = CType(result, TimeSpan)
                        checkOutTime = timeSpanResult.ToString("hh\:mm")
                    End If
                End Using
            Catch ex As Exception
                ' Silently fail, returns the default time
            End Try
        End Using
        Return checkOutTime
    End Function
    ''' <summary>
    ''' Retrieves all hotel settings from the database.
    ''' </summary>
    ''' <returns>A Dictionary containing all hotel settings.</returns>
    Public Function GetHotelDetails() As Dictionary(Of String, String)
        Dim details As New Dictionary(Of String, String)
        Dim sql As String = "SELECT * FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"
        If String.IsNullOrEmpty(strConnection) Then Return details

        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            For i As Integer = 0 To reader.FieldCount - 1
                                Dim colName As String = reader.GetName(i)
                                Dim colValue As String = If(IsDBNull(reader(i)), "", reader(i).ToString())
                                details(colName) = colValue
                            Next
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' Silently fail, returns an empty dictionary
            End Try
        End Using
        Return details
    End Function
    Public Function GetConnectionDetails() As Dictionary(Of String, String)
        Dim details As New Dictionary(Of String, String)
        Dim configFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")

        If Not File.Exists(configFile) Then
            Return details ' Return empty dictionary if file doesn't exist
        End If

        Try
            For Each line In File.ReadLines(configFile)
                If line.Contains("=") Then
                    Dim parts = line.Split(New Char() {"="c}, 2)
                    details(parts(0).Trim()) = parts(1).Trim()
                End If
            Next
        Catch ex As Exception
            ' Silently fail, returns an empty dictionary
        End Try

        Return details
    End Function
    ' Example of how to implement GetStatutoryDiscountPercentage in modDB (assuming it's not there)
    Public Function GetStatutoryDiscountPercentage() As Decimal
        Dim discount As Decimal = 0
        Dim sql As String = "SELECT StatutoryDiscountPercentage FROM hotelsettings LIMIT 1;"
        Using conn As New MySqlConnection(strConnection), cmd As New MySqlCommand(sql, conn)
            Try
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    discount = CDec(result)
                End If
            Catch ex As Exception
                MsgBox($"Error loading statutory discount: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
        Return discount
    End Function
    Public Function AdminAccountExists() As Boolean
        Dim sql As String = "SELECT COUNT(*) FROM staff WHERE RoleID = 3;"
        Using conn As New MySqlConnection(strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    ' ExecuteScalar is efficient for getting a single value.
                    Dim count As Long = CLng(cmd.ExecuteScalar())
                    ' If the count is greater than 0, an admin exists.
                    Return count > 0
                End Using
            Catch ex As Exception
                ' If an error occurs (e.g., database not configured yet),
                ' we assume no admin exists to allow the setup to proceed.
                Return False
            End Try
        End Using
    End Function
End Module
