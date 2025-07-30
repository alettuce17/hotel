Imports MySql.Data.MySqlClient

Public Class frmLoyaltyTiers

    Private selectedTierID As Integer = 0

    Private Sub frmLoyaltyTiers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set max values for NumericUpDown controls
        numMinNights.Maximum = 1000
        numDiscount.Maximum = 100

        LoadTiers()
        ClearSelection()
    End Sub

    ''' <summary>
    ''' Loads all loyalty tiers from the database into the DataGridView.
    ''' </summary>
    Private Sub LoadTiers()
        ' *** UPDATED SQL to use new column names ***
        Dim sql As String = "SELECT TierID, TierName, MinNightsRequired, DiscountPercentage, TierBenefits FROM loyaltytiers ORDER BY MinNightsRequired;"
        modDB.LoadToDGV(sql, dgvTiers)

        dgvTiers.RowHeadersVisible = False
        dgvTiers.AllowUserToAddRows = False
        dgvTiers.ReadOnly = True
        dgvTiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        If dgvTiers.Columns.Count > 0 Then
            dgvTiers.Columns("TierID").Visible = False
            dgvTiers.Columns("TierName").HeaderText = "Tier Name"
            dgvTiers.Columns("MinNightsRequired").HeaderText = "Min Nights"
            dgvTiers.Columns("DiscountPercentage").HeaderText = "Discount %"
            dgvTiers.Columns("TierBenefits").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        dgvTiers.ClearSelection()
    End Sub

    ''' <summary>
    ''' Clears the input fields and resets the form to "Add New" mode.
    ''' </summary>
    Private Sub ClearSelection()
        selectedTierID = 0
        txtTierName.Clear()
        txtBenefits.Clear()
        numMinNights.Value = 0
        numDiscount.Value = 0
        btnDelete.Enabled = False
        dgvTiers.ClearSelection()
        txtTierName.Focus()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ClearSelection()
    End Sub

    ''' <summary>
    ''' Populates the input fields when a user clicks a row in the grid.
    ''' </summary>
    Private Sub dgvTiers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTiers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvTiers.Rows(e.RowIndex)
            selectedTierID = CInt(row.Cells("TierID").Value)
            txtTierName.Text = row.Cells("TierName").Value.ToString()
            txtBenefits.Text = row.Cells("TierBenefits").Value.ToString()
            numMinNights.Value = CInt(row.Cells("MinNightsRequired").Value)
            numDiscount.Value = CDec(row.Cells("DiscountPercentage").Value)
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(txtTierName.Text) Then
            MsgBox("Tier Name cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtTierName.Focus()
            Return
        End If

        Dim sql As String
        Dim isUpdate As Boolean = (selectedTierID > 0)

        If isUpdate Then
            ' *** UPDATED SQL for UPDATE statement ***
            sql = "UPDATE loyaltytiers SET TierName = @TierName, MinNightsRequired = @MinNights, DiscountPercentage = @Discount, TierBenefits = @Benefits WHERE TierID = @TierID;"
        Else
            ' *** UPDATED SQL for INSERT statement ***
            sql = "INSERT INTO loyaltytiers (TierName, MinNightsRequired, DiscountPercentage, TierBenefits) VALUES (@TierName, @MinNights, @Discount, @Benefits);"
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TierName", txtTierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@MinNights", numMinNights.Value)
                    cmd.Parameters.AddWithValue("@Discount", numDiscount.Value)
                    cmd.Parameters.AddWithValue("@Benefits", txtBenefits.Text.Trim())

                    If isUpdate Then
                        cmd.Parameters.AddWithValue("@TierID", selectedTierID)
                    End If
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Loyalty Tier saved successfully.", MsgBoxStyle.Information, "Success")
                If isUpdate Then
                    modDB.Logs("Loyalty Tier Updated", "Management", $"Tier '{txtTierName.Text}' was updated.", "loyaltytiers", selectedTierID)
                Else
                    modDB.Logs("Loyalty Tier Created", "Management", $"New tier '{txtTierName.Text}' was created.", "loyaltytiers")
                End If

                LoadTiers()
                ClearSelection()

            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    MsgBox("A loyalty tier with this name already exists.", MsgBoxStyle.Critical, "Duplicate Error")
                Else
                    MsgBox($"A database error occurred: {ex.Message}", MsgBoxStyle.Critical, "Database Error")
                End If
            Catch ex As Exception
                MsgBox($"An unexpected error occurred: {ex.Message}", MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedTierID = 0 Then Return

        If MsgBox($"Are you sure you want to delete the '{txtTierName.Text}' tier? This could affect existing guests in this tier.", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
            Return
        End If

        Dim sql As String = "DELETE FROM loyaltytiers WHERE TierID = @TierID;"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TierID", selectedTierID)
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Loyalty Tier deleted successfully.", MsgBoxStyle.Information, "Success")
                modDB.Logs("Loyalty Tier Deleted", "Management", $"Tier '{txtTierName.Text}' was deleted.", "loyaltytiers", selectedTierID)

                LoadTiers()
                ClearSelection()

            Catch ex As Exception
                MsgBox($"Error deleting tier: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

End Class
