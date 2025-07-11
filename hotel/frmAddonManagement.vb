Imports MySql.Data.MySqlClient

Public Class frmAddonManagement

    Private selectedAddonID As Integer = 0

    Private Sub frmAddonManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAddons()
        ClearSelection()
    End Sub

    ''' <summary>
    ''' Loads all addons from the database into the DataGridView.
    ''' </summary>
    Private Sub LoadAddons()
        ' *** UPDATED: Added Price to the SELECT statement ***
        Dim sql As String = "SELECT AddonID, AddonName, Description, Price FROM addons ORDER BY AddonName;"
        modDB.LoadToDGV(sql, dgvAddons)

        ' --- UI Customization for the DataGridView ---
        dgvAddons.RowHeadersVisible = False
        dgvAddons.AllowUserToAddRows = False
        dgvAddons.ReadOnly = True
        dgvAddons.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAddons.MultiSelect = False

        If dgvAddons.Columns.Count > 0 Then
            dgvAddons.Columns("AddonID").Visible = False
            dgvAddons.Columns("AddonName").HeaderText = "Addon Name"
            dgvAddons.Columns("Description").Width = 300
            ' *** UPDATED: Format the new Price column ***
            dgvAddons.Columns("Price").DefaultCellStyle.Format = "c" ' Format as currency
            dgvAddons.Columns("Price").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        dgvAddons.ClearSelection()
    End Sub

    ''' <summary>
    ''' Clears the textboxes and resets the form to "Add New" mode.
    ''' </summary>
    Private Sub ClearSelection()
        selectedAddonID = 0
        txtAddonName.Clear()
        txtDescription.Clear()
        numPrice.Value = 0 ' *** UPDATED: Reset the price control ***
        btnDelete.Enabled = False
        dgvAddons.ClearSelection()
        txtAddonName.Focus()
    End Sub

    ''' <summary>
    ''' Handles the click of the Add New button to clear the selection.
    ''' </summary>
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ClearSelection()
    End Sub

    Private Sub dgvAddons_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAddons.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvAddons.Rows(e.RowIndex)
            selectedAddonID = CInt(row.Cells("AddonID").Value)
            txtAddonName.Text = row.Cells("AddonName").Value.ToString()
            txtDescription.Text = row.Cells("Description").Value.ToString()
            numPrice.Value = CDec(row.Cells("Price").Value) ' *** UPDATED: Populate the price control ***
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(txtAddonName.Text) Then
            MsgBox("Addon Name cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtAddonName.Focus()
            Return
        End If

        ' *** UPDATED: Add validation for the price ***
        If numPrice.Value <= 0 Then
            MsgBox("Price must be greater than zero.", MsgBoxStyle.Exclamation, "Input Error")
            numPrice.Focus()
            Return
        End If

        Dim sql As String
        Dim isUpdate As Boolean = (selectedAddonID > 0)

        If isUpdate Then
            ' *** UPDATED: Add Price to the UPDATE statement ***
            sql = "UPDATE addons SET AddonName = @AddonName, Description = @Description, Price = @Price WHERE AddonID = @AddonID;"
        Else
            ' *** UPDATED: Add Price to the INSERT statement ***
            sql = "INSERT INTO addons (AddonName, Description, Price) VALUES (@AddonName, @Description, @Price);"
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AddonName", txtAddonName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@Price", numPrice.Value) ' *** UPDATED: Add price parameter ***
                    If isUpdate Then
                        cmd.Parameters.AddWithValue("@AddonID", selectedAddonID)
                    End If
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Addon saved successfully.", MsgBoxStyle.Information, "Success")
                ' Log the appropriate event
                If isUpdate Then
                    modDB.Logs("Addon Updated", "Management", $"Addon '{txtAddonName.Text}' was updated.", "addons", selectedAddonID)
                Else
                    modDB.Logs("Addon Created", "Management", $"New addon '{txtAddonName.Text}' was created.", "addons")
                End If

                LoadAddons()
                ClearSelection()

            Catch ex As MySqlException
                If ex.Number = 1062 Then ' Duplicate entry error
                    MsgBox("An addon with this name already exists. Please choose a different name.", MsgBoxStyle.Critical, "Duplicate Error")
                Else
                    MsgBox($"A database error occurred: {ex.Message}", MsgBoxStyle.Critical, "Database Error")
                End If
            Catch ex As Exception
                MsgBox($"An unexpected error occurred: {ex.Message}", MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedAddonID = 0 Then
            Return
        End If

        If MsgBox($"Are you sure you want to delete the addon '{txtAddonName.Text}'?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
            Return
        End If

        Dim sql As String = "DELETE FROM addons WHERE AddonID = @AddonID;"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AddonID", selectedAddonID)
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Addon deleted successfully.", MsgBoxStyle.Information, "Success")
                modDB.Logs("Addon Deleted", "Management", $"Addon '{txtAddonName.Text}' was deleted.", "addons", selectedAddonID)

                LoadAddons()
                ClearSelection()

            Catch ex As Exception
                MsgBox($"Error deleting addon: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

End Class
