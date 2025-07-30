Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class frmAddons

#Region "Class-level Variables"
    ' Class to hold addon data
    Private Class Addon
        Public Property AddonID As Integer
        Public Property AddonName As String
        Public Property Price As Decimal
        Public Property Quantity As Integer
        Public ReadOnly Property Subtotal As Decimal
            Get
                Return Price * Quantity
            End Get
        End Property
        Public Overrides Function ToString() As String
            ' This format is used by the available addons ListBox
            Return $"{AddonName} ({Price:C})"
        End Function
    End Class

    ' The ID of the reservation we are editing
    Private ReadOnly _reservationID As Integer

    ' Data sources for the controls
    Private _availableAddons As New BindingList(Of Addon)()
    Private _selectedAddons As New BindingList(Of Addon)()

#End Region

#Region "Constructor and Form Load"
    ''' <summary>
    ''' Creates a new instance of the Addon Management form.
    ''' </summary>
    ''' <param name="reservationID">The ID of the reservation to manage addons for.</param>
    Public Sub New(ByVal reservationID As Integer)
        InitializeComponent()
        _reservationID = reservationID
    End Sub

    Private Sub frmAddons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup the controls
        SetupControls()

        ' Load data from the database
        LoadReservationDetails()
        LoadAvailableAddons()
        LoadExistingAddons()

        ' Calculate the initial total
        UpdateTotal()
    End Sub

    ''' <summary>
    ''' Configures the controls for display.
    ''' </summary>
    Private Sub SetupControls()
        ' Bind the available addons list to the ListBox.
        lstAvailableAddons.DataSource = _availableAddons

        ' Setup DataGridView for selected addons
        dgvSelectedAddons.DataSource = _selectedAddons
        dgvSelectedAddons.AutoGenerateColumns = False
        dgvSelectedAddons.Columns.Clear()
        dgvSelectedAddons.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "AddonName", .HeaderText = "Selected Addon", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .ReadOnly = True})
        dgvSelectedAddons.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Quantity", .HeaderText = "Qty", .Width = 50})
        dgvSelectedAddons.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Subtotal", .HeaderText = "Subtotal", .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "c"}, .ReadOnly = True})
        dgvSelectedAddons.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
#End Region

#Region "Data Loading"
    ''' <summary>
    ''' Loads basic reservation details to display on the form.
    ''' </summary>
    Private Sub LoadReservationDetails()
        Dim sql = "SELECT CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, r.RoomNumber " &
                  "FROM reservations res " &
                  "JOIN guests g ON res.GuestID = g.GuestID " &
                  "JOIN users u ON g.UserID = u.UserID " &
                  "LEFT JOIN rooms r ON res.RoomID = r.RoomID " &
                  "WHERE res.ReservationID = @ResID"

        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ResID", _reservationID)
            conn.Open()
            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    lblGuestInfo.Text = $"Guest: {reader("GuestName")} | Room: {reader("RoomNumber")}"
                End If
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Loads all possible addons from the database, filtered by the search box.
    ''' </summary>
    Private Sub LoadAvailableAddons()
        _availableAddons.Clear()

        Dim sql = "SELECT AddonID, AddonName, Price FROM addons "
        Dim searchTerm As String = txtSearchAddon.Text.Trim()

        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            sql &= "WHERE AddonName LIKE @SearchTerm "
        End If
        sql &= "ORDER BY AddonName"

        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%")
            End If

            conn.Open()
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    _availableAddons.Add(New Addon With {
                        .AddonID = CInt(reader("AddonID")),
                        .AddonName = reader("AddonName").ToString(),
                        .Price = CDec(reader("Price")),
                        .Quantity = 1
                    })
                End While
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Loads addons already assigned to the current reservation.
    ''' </summary>
    Private Sub LoadExistingAddons()
        _selectedAddons.Clear()
        Dim sql = "SELECT ra.AddonID, a.AddonName, a.Price, ra.Quantity " &
                  "FROM reservation_addons ra " &
                  "JOIN addons a ON ra.AddonID = a.AddonID " &
                  "WHERE ra.ReservationID = @ResID"

        Using conn As New MySqlConnection(modDB.strConnection), cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ResID", _reservationID)
            conn.Open()
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    _selectedAddons.Add(New Addon With {
                        .AddonID = CInt(reader("AddonID")),
                        .AddonName = reader("AddonName").ToString(),
                        .Price = CDec(reader("Price")),
                        .Quantity = CInt(reader("Quantity"))
                    })
                End While
            End Using
        End Using
    End Sub
#End Region

#Region "Button and UI Logic"

    ''' <summary>
    ''' Handles the TextChanged event of the search box. Reloads the available addons list.
    ''' </summary>
    Private Sub txtSearchAddon_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAddon.TextChanged
        LoadAvailableAddons()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If lstAvailableAddons.SelectedItem Is Nothing Then Return

        ' --- ERROR HANDLING: Ensure quantity is valid before adding ---
        If numQuantity.Value < 1 Then
            MsgBox("Quantity must be at least 1.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim availableAddon = CType(lstAvailableAddons.SelectedItem, Addon)
        Dim quantityToAdd As Integer = CInt(numQuantity.Value)

        Dim existingSelectedAddon = _selectedAddons.FirstOrDefault(Function(a) a.AddonID = availableAddon.AddonID)

        If existingSelectedAddon IsNot Nothing Then
            existingSelectedAddon.Quantity += quantityToAdd
            ' Refresh the grid to show the updated quantity and subtotal
            dgvSelectedAddons.Refresh()
        Else
            _selectedAddons.Add(New Addon With {
                .AddonID = availableAddon.AddonID,
                .AddonName = availableAddon.AddonName,
                .Price = availableAddon.Price,
                .Quantity = quantityToAdd
            })
        End If

        numQuantity.Value = 1
        UpdateTotal()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvSelectedAddons.SelectedRows.Count = 0 Then Return

        Dim addonToRemove = CType(dgvSelectedAddons.SelectedRows(0).DataBoundItem, Addon)
        _selectedAddons.Remove(addonToRemove)
        UpdateTotal()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- ERROR HANDLING: Final check for invalid quantities before saving ---
        If _selectedAddons.Any(Function(a) a.Quantity < 1) Then
            MsgBox("One or more selected addons has an invalid quantity. Please correct it before saving.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim totalAddonCost As Decimal = _selectedAddons.Sum(Function(a) a.Subtotal)
        If MsgBox($"This will save the changes and add {totalAddonCost:C} to the guest's folio. Proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Return
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction = conn.BeginTransaction()
            Try
                ' 1. Clear existing addons for this reservation
                Dim deleteSql = "DELETE FROM reservation_addons WHERE ReservationID = @ResID"
                Using cmd As New MySqlCommand(deleteSql, conn, transaction)
                    cmd.Parameters.AddWithValue("@ResID", _reservationID)
                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Insert the new list of selected addons
                If _selectedAddons.Any() Then
                    Dim insertSql = "INSERT INTO reservation_addons (ReservationID, AddonID, Quantity) VALUES (@ResID, @AddonID, @Quantity)"
                    For Each addon In _selectedAddons
                        Using cmd As New MySqlCommand(insertSql, conn, transaction)
                            cmd.Parameters.AddWithValue("@ResID", _reservationID)
                            cmd.Parameters.AddWithValue("@AddonID", addon.AddonID)
                            cmd.Parameters.AddWithValue("@Quantity", addon.Quantity)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                End If

                ' 3. Create a new payment record for these addons.
                If totalAddonCost > 0 Then
                    Dim paymentSql = "INSERT INTO payments (ReservationID, PaymentAmount, PaymentMethod, PaymentNotes, ProcessedByStaffID) " &
                                     "VALUES (@ResID, @Amount, 'Room Charge', 'Charges for addons/services', @StaffID)"
                    Using cmd As New MySqlCommand(paymentSql, conn, transaction)
                        cmd.Parameters.AddWithValue("@ResID", _reservationID)
                        cmd.Parameters.AddWithValue("@Amount", totalAddonCost)
                        cmd.Parameters.AddWithValue("@StaffID", modDB.LoggedInUser.StaffID)
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                ' === LOYALTY POINTS LOGIC REMOVED FROM THIS FORM ===
                ' Points will now be awarded only at checkout based on room type.

                ' 4. Commit all changes
                transaction.Commit()
                MsgBox("Addons and charges saved successfully.", MsgBoxStyle.Information)
                modDB.Logs("Addons Updated", "Reservations", $"Addons updated for ResID: {_reservationID}. New charge: {totalAddonCost:C}", "reservations", _reservationID)
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                transaction.Rollback()
                MsgBox($"An error occurred while saving: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' Recalculates and displays the total cost of selected addons.
    ''' </summary>
    Private Sub UpdateTotal()
        Dim total As Decimal = _selectedAddons.Sum(Function(a) a.Subtotal)
        lblTotal.Text = $"Total Charges: {total:C}"
    End Sub

    ''' <summary>
    ''' Handles changes in the selected addons grid, like editing quantity.
    ''' </summary>
    Private Sub dgvSelectedAddons_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelectedAddons.CellValueChanged
        ' Check if the change was in the "Quantity" column
        If e.RowIndex >= 0 AndAlso dgvSelectedAddons.Columns(e.ColumnIndex).DataPropertyName = "Quantity" Then
            ' Force the grid to refresh the calculated "Subtotal" column
            dgvSelectedAddons.Refresh()
            UpdateTotal()
        End If
    End Sub

    ''' <summary>
    ''' --- ERROR HANDLING: Validates the quantity cell before the edit is committed. ---
    ''' </summary>
    Private Sub dgvSelectedAddons_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvSelectedAddons.CellValidating
        ' We only care about validating the "Quantity" column
        If dgvSelectedAddons.Columns(e.ColumnIndex).DataPropertyName <> "Quantity" Then Return

        Dim newQuantity As Integer
        ' Try to convert the new value to an integer.
        If Not Integer.TryParse(e.FormattedValue.ToString(), newQuantity) Then
            MsgBox("Quantity must be a valid number.", MsgBoxStyle.Exclamation)
            e.Cancel = True ' Cancel the edit
            Return
        End If

        ' Check if the number is positive.
        If newQuantity < 1 Then
            MsgBox("Quantity must be at least 1.", MsgBoxStyle.Exclamation)
            e.Cancel = True ' Cancel the edit
        End If
    End Sub
#End Region

End Class
