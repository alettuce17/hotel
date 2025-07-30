Imports MySql.Data.MySqlClient

Public Class frmBedTypes

    ' Rename this to reflect it holds RoomTypeID, but keep original control names
    Private selectedRoomTypeID As Integer = 0 ' Renamed variable for clarity

    Private Sub frmBedTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Room Type & Pricing Management" ' Changed form title
        numPrice.Maximum = 1000000
        LoadRoomTypesIntoDGV() ' Call the new loading method
        ClearSelection() ' Initially clear and disable controls
    End Sub

    ''' <summary>
    ''' Loads all room types from the database into the DataGridView (dgvBedTypes).
    ''' This DGV is now repurposed to show Room Types.
    ''' </summary>
    Private Sub LoadRoomTypesIntoDGV() ' Renamed method
        ' Select from roomtypes table
        Dim sql As String = "SELECT RoomTypeID, TypeName, Price FROM roomtypes ORDER BY TypeName;"
        modDB.LoadToDGV(sql, dgvBedTypes) ' Keep dgvBedTypes control name

        dgvBedTypes.RowHeadersVisible = False
        dgvBedTypes.AllowUserToAddRows = False
        dgvBedTypes.ReadOnly = True
        dgvBedTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        If dgvBedTypes.Columns.Count > 0 Then
            ' Map to the actual column names from the roomtypes table
            dgvBedTypes.Columns("RoomTypeID").Visible = False
            dgvBedTypes.Columns("TypeName").HeaderText = "Room Type Name" ' Keep txtBedTypeName conceptually
            dgvBedTypes.Columns("Price").DefaultCellStyle.Format = "C"
            dgvBedTypes.Columns("TypeName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        dgvBedTypes.ClearSelection()
    End Sub

    ''' <summary>
    ''' Clears the input fields and disables the editing controls.
    ''' </summary>
    Private Sub ClearSelection()
        selectedRoomTypeID = 0 ' Use the new variable
        txtBedTypeName.Clear() ' Keep txtBedTypeName control name
        numPrice.Value = 0
        dgvBedTypes.ClearSelection()

        ' Disable controls until a room type is selected
        txtBedTypeName.Enabled = False
        numPrice.Enabled = False
        btnSave.Enabled = False
    End Sub

    ''' <summary>
    ''' Populates the input fields and enables them when a user clicks a row.
    ''' </summary>
    Private Sub dgvBedTypes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBedTypes.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBedTypes.Rows(e.RowIndex)
            ' Access columns by RoomTypeID, TypeName, Price
            selectedRoomTypeID = CInt(row.Cells("RoomTypeID").Value)
            txtBedTypeName.Text = row.Cells("TypeName").Value.ToString() ' Repurpose txtBedTypeName for TypeName
            numPrice.Value = CDec(row.Cells("Price").Value)

            ' Enable controls for editing
            txtBedTypeName.Enabled = True
            numPrice.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Saves changes to the selected room type and updates associated room base prices.
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If selectedRoomTypeID = 0 Then ' Use the new variable
            MsgBox("Please select a room type from the list to edit.", MsgBoxStyle.Information)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtBedTypeName.Text) Then ' Keep txtBedTypeName control name
            MsgBox("Room Type Name cannot be empty.", MsgBoxStyle.Exclamation, "Input Error")
            txtBedTypeName.Focus()
            Return
        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                ' --- UPDATE the Room Type directly ---
                ' Target roomtypes table, update TypeName and Price based on RoomTypeID
                Dim sqlUpdateRoomType As String = "UPDATE roomtypes SET TypeName = @TypeName, Price = @Price WHERE RoomTypeID = @RoomTypeID;"
                Using cmdUpdateRoomType As New MySqlCommand(sqlUpdateRoomType, conn, transaction)
                    cmdUpdateRoomType.Parameters.AddWithValue("@TypeName", txtBedTypeName.Text.Trim())
                    cmdUpdateRoomType.Parameters.AddWithValue("@Price", numPrice.Value)
                    cmdUpdateRoomType.Parameters.AddWithValue("@RoomTypeID", selectedRoomTypeID)
                    cmdUpdateRoomType.ExecuteNonQuery()
                End Using

                ' --- NEW: Update the BasePricePerNight of associated rooms ---
                ' The 'rooms' table has a 'RoomTypeID' to link to 'roomtypes'
                ' and 'BasePricePerNight' which should reflect the room type's price.
                Dim sqlUpdateRoomsBasePrice As String = "UPDATE rooms SET BasePricePerNight = @NewBasePrice WHERE RoomTypeID = @RoomTypeID;"
                Using cmdUpdateRoomsBasePrice As New MySqlCommand(sqlUpdateRoomsBasePrice, conn, transaction)
                    cmdUpdateRoomsBasePrice.Parameters.AddWithValue("@NewBasePrice", numPrice.Value) ' Use the new price from the room type
                    cmdUpdateRoomsBasePrice.Parameters.AddWithValue("@RoomTypeID", selectedRoomTypeID)
                    cmdUpdateRoomsBasePrice.ExecuteNonQuery()
                End Using

                transaction.Commit() ' Commit both updates

                MsgBox("Room Type and associated room base prices saved successfully.", MsgBoxStyle.Information, "Success") ' Updated message
                modDB.Logs("Room Type and Room Prices Saved", "Management", $"Room Type '{txtBedTypeName.Text}' and associated room prices were updated.") ' Updated message
                LoadRoomTypesIntoDGV() ' Call the new loading method
                ClearSelection()

            Catch ex As Exception
                transaction.Rollback() ' Rollback if any error occurs
                MsgBox($"An error occurred: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

End Class