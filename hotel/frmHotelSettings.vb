Imports MySql.Data.MySqlClient

Public Class frmHotelSettings

    Private Sub frmHotelSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    ''' <summary>
    ''' Loads the current settings from the database into the form controls.
    ''' </summary>
    Private Sub LoadSettings()
        Dim sql As String = "SELECT * FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Populate General Tab
                            txtHotelName.Text = reader("HotelName").ToString()
                            txtLegalName.Text = reader("LegalName").ToString()
                            txtAddress1.Text = reader("AddressLine1").ToString()
                            txtCity.Text = reader("City").ToString()
                            txtState.Text = reader("StateProvince").ToString()
                            txtPostal.Text = reader("PostalCode").ToString()
                            txtCountry.Text = reader("Country").ToString()

                            ' Populate Contact & Policy Tab
                            txtPhone.Text = reader("MainPhoneNumber").ToString()
                            txtEmail.Text = reader("MainEmail").ToString()
                            txtWebsite.Text = reader("WebsiteURL").ToString()
                            numTaxRate.Value = CDec(reader("TaxRatePercentage"))

                            ' Handle Time values
                            If Not IsDBNull(reader("CheckInTimeDefault")) Then
                                Dim checkInTime As TimeSpan = CType(reader("CheckInTimeDefault"), TimeSpan)
                                dtpCheckin.Value = DateTime.Today + checkInTime
                            End If
                            If Not IsDBNull(reader("CheckOutTimeDefault")) Then
                                Dim checkOutTime As TimeSpan = CType(reader("CheckOutTimeDefault"), TimeSpan)
                                dtpCheckout.Value = DateTime.Today + checkOutTime
                            End If
                        Else
                            MsgBox("Could not find hotel settings in the database.", MsgBoxStyle.Exclamation, "Not Found")
                            Me.Close()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox($"Error loading settings: {ex.Message}", MsgBoxStyle.Critical)
                Me.Close()
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Validates all user inputs on the form before saving.
    ''' </summary>
    ''' <returns>True if all inputs are valid, otherwise False.</returns>
    Private Function ValidateInputs() As Boolean
        ' --- General Tab Validation ---
        If String.IsNullOrWhiteSpace(txtHotelName.Text) Then
            MsgBox("Hotel Name cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpGeneral
            txtHotelName.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtAddress1.Text) Then
            MsgBox("Address Line 1 cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpGeneral
            txtAddress1.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtCity.Text) Then
            MsgBox("City cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpGeneral
            txtCity.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtCountry.Text) Then
            MsgBox("Country cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpGeneral
            txtCountry.Focus()
            Return False
        End If

        ' --- Contact & Policy Tab Validation ---
        If String.IsNullOrWhiteSpace(txtPhone.Text) Then
            MsgBox("Main Phone cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpContact
            txtPhone.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MsgBox("Main Email cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpContact
            txtEmail.Focus()
            Return False
        ElseIf Not txtEmail.Text.Contains("@") OrElse Not txtEmail.Text.Contains(".") Then
            MsgBox("Please enter a valid email address.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpContact
            txtEmail.Focus()
            Return False
        End If
        If numTaxRate.Value < 0 Or numTaxRate.Value > 100 Then
            MsgBox("Tax Rate must be between 0 and 100.", MsgBoxStyle.Exclamation, "Input Error")
            tcSettings.SelectedTab = tpContact
            numTaxRate.Focus()
            Return False
        End If

        ' All validations passed
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- 1. Validate all inputs before proceeding ---
        If Not ValidateInputs() Then
            Return ' Stop the save process if validation fails
        End If

        ' --- 2. Confirm with the user ---
        If MsgBox("Are you sure you want to save these changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Return
        End If

        ' --- 3. Execute the database update ---
        Dim sql As String = "UPDATE hotelsettings SET " &
                            "HotelName = @HotelName, LegalName = @LegalName, AddressLine1 = @Address1, City = @City, " &
                            "StateProvince = @State, PostalCode = @Postal, Country = @Country, MainPhoneNumber = @Phone, " &
                            "MainEmail = @Email, WebsiteURL = @Website, CheckInTimeDefault = @Checkin, " &
                            "CheckOutTimeDefault = @Checkout, TaxRatePercentage = @Tax, LastUpdatedByStaffID = @StaffID " &
                            "WHERE SettingID = 1;"

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    ' Add all parameters
                    cmd.Parameters.AddWithValue("@HotelName", txtHotelName.Text)
                    cmd.Parameters.AddWithValue("@LegalName", txtLegalName.Text)
                    cmd.Parameters.AddWithValue("@Address1", txtAddress1.Text)
                    cmd.Parameters.AddWithValue("@City", txtCity.Text)
                    cmd.Parameters.AddWithValue("@State", txtState.Text)
                    cmd.Parameters.AddWithValue("@Postal", txtPostal.Text)
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text)
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text)
                    cmd.Parameters.AddWithValue("@Checkin", dtpCheckin.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@Checkout", dtpCheckout.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@Tax", numTaxRate.Value)
                    cmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)

                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Settings saved successfully.", MsgBoxStyle.Information, "Success")
                modDB.Logs("Settings Updated", "Management", "Hotel settings were updated.")
                Me.Close()

            Catch ex As Exception
                MsgBox($"Error saving settings: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
