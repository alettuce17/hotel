Imports MySql.Data.MySqlClient

Public Class frmRoomSelector

    ' Public properties to receive data from the reservation form
    Public SelectedRoomID As Integer = 0
    Public SelectedRoomNumber As String = ""
    Public SelectedRoomPrice As Decimal = 0

    Private _roomTypeID As Integer
    Private _checkInDate As Date
    Private _checkOutDate As Date
    Private _alreadySelectedRoomIDs As List(Of Integer)
    Private _isTodayBooking As Boolean

    ' *** UPDATED: Custom constructor now accepts a flag for same-day bookings ***
    Public Sub New(ByVal roomTypeID As Integer, ByVal checkIn As Date, ByVal checkOut As Date, ByVal alreadySelectedIDs As List(Of Integer), ByVal isToday As Boolean)
        InitializeComponent()
        _roomTypeID = roomTypeID
        _checkInDate = checkIn
        _checkOutDate = checkOut
        _alreadySelectedRoomIDs = alreadySelectedIDs
        _isTodayBooking = isToday
    End Sub

    Private Sub frmRoomSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRooms()
    End Sub

    ''' <summary>
    ''' Fetches all rooms of the specified type and displays them as colored buttons.
    ''' </summary>
    Private Sub LoadRooms()
        flpRooms.Controls.Clear()

        ' *** NEW: The SQL query is now built conditionally based on the booking date ***
        Dim sql As String
        If _isTodayBooking Then
            sql = "SELECT r.RoomID, r.RoomNumber, r.BasePricePerNight, r.CurrentStatus, 0 AS ConflictingBookings " &
        "FROM rooms r " &
        "WHERE r.RoomTypeID = @RoomTypeID " &
        "ORDER BY " &
        "  CASE WHEN r.CurrentStatus = 'available' THEN 0 ELSE 1 END, r.RoomNumber;"

        Else
            ' For future bookings, check for reservation conflicts.
            sql = "SELECT r.RoomID, r.RoomNumber, r.BasePricePerNight, r.CurrentStatus, " &
              "(SELECT COUNT(*) FROM reservations res WHERE res.RoomID = r.RoomID AND NOT (res.CheckOutDate <= @StartDate OR res.CheckInDate >= @EndDate)) AS ConflictingBookings " &
              "FROM rooms r " &
              "WHERE r.RoomTypeID = @RoomTypeID " &
              "ORDER BY " &
              "  CASE " &
              "    WHEN r.CurrentStatus = 'available' AND " &
              "         (SELECT COUNT(*) FROM reservations res WHERE res.RoomID = r.RoomID AND NOT (res.CheckOutDate <= @StartDate OR res.CheckInDate >= @EndDate)) = 0 THEN 0 " &
              "    ELSE 1 " &
              "  END, r.RoomNumber;"

        End If

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RoomTypeID", _roomTypeID)
                    If Not _isTodayBooking Then
                        cmd.Parameters.AddWithValue("@StartDate", _checkInDate)
                        cmd.Parameters.AddWithValue("@EndDate", _checkOutDate)
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim roomID As Integer = CInt(reader("RoomID"))
                            Dim roomNumber As String = reader("RoomNumber").ToString()
                            Dim price As Decimal = CDec(reader("BasePricePerNight"))
                            Dim status As String = reader("CurrentStatus").ToString()
                            Dim conflicts As Integer = CInt(reader("ConflictingBookings"))

                            Dim roomButton As New Button()
                            roomButton.Text = roomNumber
                            roomButton.Size = New Size(100, 80)
                            roomButton.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                            roomButton.Tag = New Dictionary(Of String, Object) From {
                                {"RoomID", roomID},
                                {"RoomNumber", roomNumber},
                                {"Price", price}
                            }

                            ' Set the button color and enabled status based on availability
                            If _alreadySelectedRoomIDs.Contains(roomID) Then
                                roomButton.BackColor = Color.LightBlue ' Already in cart
                                roomButton.Enabled = False
                            ElseIf conflicts > 0 Then
                                roomButton.BackColor = Color.Red ' Occupied due to future booking
                                roomButton.Enabled = False
                            ElseIf status.ToLower() <> "available" Then
                                ' For same-day bookings, this is the primary check.
                                ' For future bookings, this is a secondary check.
                                roomButton.BackColor = If(status.ToLower() = "dirty", Color.Orange, Color.Gray) ' Dirty or Maintenance
                                roomButton.Enabled = False
                            Else
                                roomButton.BackColor = Color.LightGreen ' Available
                                AddHandler roomButton.Click, AddressOf RoomButton_Click
                            End If

                            flpRooms.Controls.Add(roomButton)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MsgBox($"Error loading rooms: {ex.Message}", MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Handles the click event for any of the available room buttons.
    ''' </summary>
    Private Sub RoomButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton = CType(sender, Button)
        Dim roomData = CType(clickedButton.Tag, Dictionary(Of String, Object))

        SelectedRoomID = CInt(roomData("RoomID"))
        SelectedRoomNumber = roomData("RoomNumber").ToString()
        SelectedRoomPrice = CDec(roomData("Price"))

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
