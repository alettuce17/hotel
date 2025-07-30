Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data ' Required for DataTable
Imports System.Windows.Forms.DataVisualization.Charting ' Required for Charting
Imports System.Globalization ' Required for culture-specific formatting

' --- Main Report Form Class ---
Public Class frmReports

#Region "Class-level Variables"
    ' Stores the type of the currently selected report (e.g., "Occupancy", "RevenueSummary")
    Private currentReportType As String = ""
    ' This DataTable will hold the *entire* result set for the current report query
    Private fullReportData As New DataTable()

    ' Paging variables for the summary DataGridView
    Private currentPage As Integer = 1
    ' Defines the number of rows to display per page in the DataGridView
    Private ReadOnly ReportGridPageSize As Integer = 50
    ' Calculated total number of pages for the DataGridView
    Private totalPages As Integer = 0

    ' --- Variables to hold hotel settings ---
    Private hotelName As String = "Mema Hotel" ' Default name
    Private hotelCurrencyCulture As CultureInfo = New CultureInfo("en-US") ' Default culture (USD)

#End Region

#Region "Form Load & Report Selection"

    ' Handles the form loading event
    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dock the form to fill its parent container
        Me.Dock = DockStyle.Fill
        ' Set default start date to the first day of the current month
        dtpStartDate.Value = New Date(DateTime.Today.Year, DateTime.Today.Month, 1)
        ' Set default end date to today
        dtpEndDate.Value = DateTime.Today

        ' --- Load dynamic data ---
        LoadHotelSettings()
        PopulateFilterComboBoxes() ' Method to populate all combo boxes

        ' Initialize the report area to a clean state
        ClearReportArea()
    End Sub

    ' --- Function to load settings from the database ---
    Private Sub LoadHotelSettings()
        Dim sql As String = "SELECT HotelName, CurrencyCode FROM hotelsettings WHERE SettingID = 1 LIMIT 1;"
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            hotelName = reader("HotelName").ToString()
                            Dim dbCurrencyCode As String = reader("CurrencyCode").ToString()

                            ' Map common currency codes to culture names
                            Select Case dbCurrencyCode.ToUpper()
                                Case "PHP" : hotelCurrencyCulture = New CultureInfo("en-PH")
                                Case "USD" : hotelCurrencyCulture = New CultureInfo("en-US")
                                Case "EUR" : hotelCurrencyCulture = New CultureInfo("de-DE") ' Example for Euro
                                Case "JPY" : hotelCurrencyCulture = New CultureInfo("ja-JP")
                                Case Else
                                    Try
                                        hotelCurrencyCulture = New CultureInfo(dbCurrencyCode)
                                    Catch
                                        hotelCurrencyCulture = New CultureInfo("en-US")
                                        Console.WriteLine($"Invalid CurrencyCode '{dbCurrencyCode}' in settings. Falling back to USD.")
                                    End Try
                            End Select
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Could not load hotel settings. Using default values." & vbCrLf & ex.Message, "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Console.WriteLine("Could not load hotel settings: " & ex.Message)
            End Try
        End Using
    End Sub

    ' --- Method to populate all filter combo boxes ---
    Private Sub PopulateFilterComboBoxes()
        ' This assumes you have ComboBoxes named: cmbRoomType, cmbStaff, cmbBookingSource, cmbAddon, cmbNationality
        PopulateComboBox(cmbRoomType, "SELECT RoomTypeID, TypeName FROM roomtypes ORDER BY TypeName", "RoomTypeID", "TypeName", "All Room Types")
        PopulateComboBox(cmbStaff, "SELECT s.StaffID, CONCAT(u.FirstName, ' ', u.LastName) AS StaffName FROM staff s JOIN users u ON s.UserID = u.UserID ORDER BY StaffName", "StaffID", "StaffName", "All Staff")
        PopulateComboBox(cmbBookingSource, "SELECT DISTINCT SourceOfBooking FROM reservations WHERE SourceOfBooking IS NOT NULL AND TRIM(SourceOfBooking) <> '' ORDER BY SourceOfBooking", "SourceOfBooking", "SourceOfBooking", "All Sources")
        PopulateComboBox(cmbAddon, "SELECT AddonID, AddonName FROM addons ORDER BY AddonName", "AddonID", "AddonName", "All Add-ons")
        PopulateComboBox(cmbNationality, "SELECT DISTINCT Nationality FROM guests WHERE Nationality IS NOT NULL AND TRIM(Nationality) <> '' ORDER BY Nationality", "Nationality", "Nationality", "All Nationalities")
    End Sub

    ' --- Generic helper to populate a ComboBox ---
    Private Sub PopulateComboBox(ByVal cmb As ComboBox, ByVal sql As String, ByVal valueMember As String, ByVal displayMember As String, ByVal allText As String)
        Dim dt As New DataTable()
        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.Fill(dt)

                Dim allRow As DataRow = dt.NewRow()
                ' Handle both integer and string based value members for the "All" option
                If dt.Columns(valueMember).DataType Is GetType(String) Then
                    allRow(valueMember) = allText
                Else
                    allRow(valueMember) = 0 ' Use 0 for numeric IDs to signify "All"
                End If
                allRow(displayMember) = allText
                dt.Rows.InsertAt(allRow, 0)

                cmb.DataSource = dt
                cmb.DisplayMember = displayMember
                cmb.ValueMember = valueMember
                cmb.SelectedIndex = 0 ' Default to "All"
            Catch ex As Exception
                MessageBox.Show($"Failed to load data for '{displayMember}': {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Resets the UI elements related to report display
    Private Sub ClearReportArea()
        lblReportTitle.Text = "Select a Report"
        chartReport.Series.Clear()
        chartReport.Titles.Clear()
        dgvReport.DataSource = Nothing
        fullReportData.Clear()
        btnGenerate.Enabled = False
        btnExport.Enabled = False
        pnlPaging.Visible = False
        pnlFilters.Visible = False ' Hide the main filter panel
    End Sub

    ' Configures the UI based on the selected report type
    Private Sub SelectReport(reportName As String, reportTitle As String, usesDates As Boolean, ParamArray visibleFilters As ComboBox())
        currentReportType = reportName
        lblReportTitle.Text = reportTitle
        btnGenerate.Enabled = True
        SetDatePickersEnabled(usesDates)

        ' Show the main filter panel and then toggle individual combo boxes
        pnlFilters.Visible = True
        For Each cmb As ComboBox In pnlFilters.Controls.OfType(Of ComboBox)()
            cmb.Visible = visibleFilters.Contains(cmb)
        Next
    End Sub

    ' Event handlers for report selection buttons
    Private Sub btnOccupancyReport_Click(sender As Object, e As EventArgs) Handles btnOccupancyReport.Click
        SelectReport("Occupancy", "Daily Occupancy Report", True, cmbRoomType)
    End Sub
    Private Sub btnRevenueSummary_Click(sender As Object, e As EventArgs) Handles btnRevenueSummary.Click
        SelectReport("RevenueSummary", "Revenue Summary Report", True, cmbRoomType)
    End Sub
    Private Sub btnRevenueForecast_Click(sender As Object, e As EventArgs) Handles btnRevenueForecast.Click
        SelectReport("RevenueForecast", "Revenue Forecast Report", True, cmbRoomType)
    End Sub
    Private Sub btnGuestDemographics_Click(sender As Object, e As EventArgs) Handles btnGuestDemographics.Click
        SelectReport("GuestDemographics", "Guest Demographics Report", False, cmbNationality)
    End Sub
    Private Sub btnBookingSource_Click(sender As Object, e As EventArgs) Handles btnBookingSource.Click
        SelectReport("BookingSource", "Booking Source Details", True, cmbBookingSource)
    End Sub
    Private Sub btnRoomPerformance_Click(sender As Object, e As EventArgs) Handles btnRoomPerformance.Click
        SelectReport("RoomPerformance", "Room Booking Details", True, cmbRoomType)
    End Sub
    Private Sub btnAddonPopularity_Click(sender As Object, e As EventArgs) Handles btnAddonPopularity.Click
        SelectReport("AddonPopularity", "Add-on Booking Details", True, cmbAddon)
    End Sub
    Private Sub btnStaffPerformance_Click(sender As Object, e As EventArgs) Handles btnStaffPerformance.Click
        SelectReport("StaffPerformance", "Staff Booking Details", True, cmbStaff)
    End Sub
    Private Sub btnCancellationReport_Click(sender As Object, e As EventArgs) Handles btnCancellationReport.Click
        SelectReport("Cancellation", "Cancellation Report", True, cmbRoomType)
    End Sub

    Private Sub SetDatePickersEnabled(ByVal isEnabled As Boolean)
        dtpStartDate.Enabled = isEnabled
        dtpEndDate.Enabled = isEnabled
    End Sub
#End Region

#Region "Report Generation & Paging"

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If String.IsNullOrEmpty(currentReportType) Then
            MessageBox.Show("Please select a report to generate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        RunReportQuery()
        currentPage = 1
        DisplayCurrentPage()
        PopulateChart()
        btnExport.Enabled = (fullReportData.Rows.Count > 0)
        pnlPaging.Visible = (fullReportData.Rows.Count > 0)
    End Sub

    Private Sub RunReportQuery()
        Dim sql As String = ""
        Dim useDateRange As Boolean = True
        Dim conditions As New List(Of String)()
        fullReportData = New DataTable()

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    Select Case currentReportType
                        Case "Occupancy"
                            sql = "SELECT d.ReportDate, COUNT(res.ReservationID) AS OccupiedRooms FROM (SELECT DATE(@StartDate + INTERVAL a.a + (10 * b.a) DAY) AS ReportDate FROM (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS a CROSS JOIN (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS b) d LEFT JOIN reservations res ON d.ReportDate >= res.CheckInDate AND d.ReportDate < res.CheckOutDate AND res.ReservationStatus IN ('Checked In', 'Confirmed','Checked Out') "
                            conditions.Add("d.ReportDate <= @EndDate")
                            If cmbRoomType.Visible AndAlso CInt(cmbRoomType.SelectedValue) > 0 Then
                                conditions.Add("res.RoomTypeID = @RoomTypeID")
                                cmd.Parameters.AddWithValue("@RoomTypeID", CInt(cmbRoomType.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " GROUP BY d.ReportDate ORDER BY d.ReportDate;"
                        Case "RevenueSummary"
                            sql = "SELECT COALESCE(p.PaymentMethod, 'Undefined') AS PaymentMethod, SUM(COALESCE(p.PaymentAmount, 0)) AS TotalRevenue FROM payments p JOIN reservations res ON p.ReservationID = res.ReservationID "
                            conditions.Add("res.ReservationStatus = 'Checked Out'")
                            conditions.Add("res.ActualCheckOutDateTime >= @StartDate AND res.ActualCheckOutDateTime < @EndDateExclusive")
                            If cmbRoomType.Visible AndAlso CInt(cmbRoomType.SelectedValue) > 0 Then
                                conditions.Add("res.RoomTypeID = @RoomTypeID")
                                cmd.Parameters.AddWithValue("@RoomTypeID", CInt(cmbRoomType.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " GROUP BY COALESCE(p.PaymentMethod, 'Undefined') ORDER BY TotalRevenue DESC;"
                        Case "RevenueForecast"
                            sql = "SELECT DATE_FORMAT(CheckInDate, '%Y-%m') AS Month, SUM(TotalReservationAmount) AS ForecastedRevenue FROM reservations "
                            conditions.Add("ReservationStatus IN ('Confirmed', 'Pending')")
                            conditions.Add("CheckInDate >= @StartDate AND CheckInDate < @EndDateExclusive")
                            If cmbRoomType.Visible AndAlso CInt(cmbRoomType.SelectedValue) > 0 Then
                                conditions.Add("RoomTypeID = @RoomTypeID")
                                cmd.Parameters.AddWithValue("@RoomTypeID", CInt(cmbRoomType.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " GROUP BY DATE_FORMAT(CheckInDate, '%Y-%m') ORDER BY Month;"
                        Case "GuestDemographics"
                            useDateRange = False
                            sql = "SELECT COALESCE(Nationality, 'Unknown') AS Nationality, COUNT(*) AS NumberOfGuests FROM guests "
                            conditions.Add("Nationality IS NOT NULL AND TRIM(Nationality) <> ''")
                            If cmbNationality.Visible AndAlso cmbNationality.SelectedValue.ToString() <> "All Nationalities" Then
                                conditions.Add("Nationality = @Nationality")
                                cmd.Parameters.AddWithValue("@Nationality", cmbNationality.SelectedValue.ToString())
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " GROUP BY COALESCE(Nationality, 'Unknown') ORDER BY NumberOfGuests DESC;"
                        Case "BookingSource"
                            sql = "SELECT res.ReservationID, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, rt.TypeName AS RoomType, res.CheckInDate, res.CheckOutDate, res.TotalReservationAmount, res.ReservationStatus, COALESCE(res.SourceOfBooking, 'Unknown/Direct') AS SourceOfBooking FROM reservations res JOIN guests g ON res.GuestID = g.GuestID JOIN users u ON g.UserID = u.UserID JOIN roomtypes rt ON res.RoomTypeID = rt.RoomTypeID "
                            conditions.Add("res.CheckInDate < @EndDateExclusive AND res.CheckOutDate > @StartDate")
                            If cmbBookingSource.Visible AndAlso cmbBookingSource.SelectedValue.ToString() <> "All Sources" Then
                                conditions.Add("res.SourceOfBooking = @SourceOfBooking")
                                cmd.Parameters.AddWithValue("@SourceOfBooking", cmbBookingSource.SelectedValue.ToString())
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " ORDER BY res.ReservationID;"
                        Case "RoomPerformance"
                            sql = "SELECT res.ReservationID, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, res.CheckInDate, res.CheckOutDate, res.TotalReservationAmount, res.ReservationStatus FROM reservations res JOIN guests g ON res.GuestID = g.GuestID JOIN users u ON g.UserID = u.UserID "
                            conditions.Add("res.CheckInDate < @EndDateExclusive AND res.CheckOutDate > @StartDate")
                            If cmbRoomType.Visible AndAlso CInt(cmbRoomType.SelectedValue) > 0 Then
                                conditions.Add("res.RoomTypeID = @RoomTypeID")
                                cmd.Parameters.AddWithValue("@RoomTypeID", CInt(cmbRoomType.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " ORDER BY res.ReservationID;"
                        Case "AddonPopularity"
                            sql = "SELECT res.ReservationID, CONCAT(u.FirstName, ' ', u.LastName) AS GuestName, a.AddonName, ra.Quantity, a.Price, (ra.Quantity * a.Price) AS SubTotal FROM reservation_addons ra JOIN reservations res ON ra.ReservationID = res.ReservationID JOIN addons a ON ra.AddonID = a.AddonID JOIN guests g ON res.GuestID = g.GuestID JOIN users u ON g.UserID = u.UserID "
                            conditions.Add("res.CheckInDate < @EndDateExclusive AND res.CheckOutDate > @StartDate")
                            If cmbAddon.Visible AndAlso CInt(cmbAddon.SelectedValue) > 0 Then
                                conditions.Add("a.AddonID = @AddonID")
                                cmd.Parameters.AddWithValue("@AddonID", CInt(cmbAddon.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " ORDER BY res.ReservationID;"
                        Case "StaffPerformance"
                            sql = "SELECT res.ReservationID, CONCAT(gu.FirstName, ' ', gu.LastName) AS GuestName, rt.TypeName AS RoomType, res.CheckInDate, res.CheckOutDate, res.TotalReservationAmount FROM reservations res JOIN staff s ON res.BookedByStaffID = s.StaffID JOIN users su ON s.UserID = su.UserID JOIN guests g ON res.GuestID = g.GuestID JOIN users gu ON g.UserID = gu.UserID JOIN roomtypes rt ON res.RoomTypeID = rt.RoomTypeID "
                            conditions.Add("res.CheckInDate < @EndDateExclusive AND res.CheckOutDate > @StartDate")
                            If cmbStaff.Visible AndAlso CInt(cmbStaff.SelectedValue) > 0 Then
                                conditions.Add("s.StaffID = @StaffID")
                                cmd.Parameters.AddWithValue("@StaffID", CInt(cmbStaff.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " ORDER BY res.ReservationID;"
                        Case "Cancellation"
                            sql = "SELECT DATE(LastModifiedDateTime) AS CancellationDate, COUNT(*) AS NumberOfCancellations FROM reservations "
                            conditions.Add("ReservationStatus = 'Cancelled'")
                            conditions.Add("LastModifiedDateTime >= @StartDate AND LastModifiedDateTime < @EndDateExclusive")
                            If cmbRoomType.Visible AndAlso CInt(cmbRoomType.SelectedValue) > 0 Then
                                conditions.Add("RoomTypeID = @RoomTypeID")
                                cmd.Parameters.AddWithValue("@RoomTypeID", CInt(cmbRoomType.SelectedValue))
                            End If
                            sql &= "WHERE " & String.Join(" AND ", conditions) & " GROUP BY DATE(LastModifiedDateTime) ORDER BY CancellationDate;"
                        Case Else
                            MessageBox.Show("Invalid report type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                    End Select

                    cmd.CommandText = sql
                    If useDateRange Then
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date)
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date) ' For Occupancy report
                        cmd.Parameters.AddWithValue("@EndDateExclusive", dtpEndDate.Value.Date.AddDays(1)) ' For all other reports
                    End If

                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(fullReportData)
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Database error generating report: {ex.Message}{vbCrLf}SQL: {sql}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub PopulateChart()
        chartReport.Series.Clear()
        chartReport.Titles.Clear()
        chartReport.ChartAreas.Clear()
        Dim defaultChartArea As New ChartArea("DefaultChartArea")
        chartReport.ChartAreas.Add(defaultChartArea)
        Dim chartTitle As New Title(lblReportTitle.Text, Docking.Top, New System.Drawing.Font("Arial", 14, FontStyle.Bold), Color.Black)
        chartReport.Titles.Add(chartTitle)

        If fullReportData.Rows.Count = 0 Then
            Dim noDataTitle As New Title("No Data Available for Chart", Docking.Top, New System.Drawing.Font("Arial", 12, FontStyle.Italic), Color.Gray)
            chartReport.Titles.Add(noDataTitle)
            chartReport.Invalidate()
            Return
        End If

        Dim series As New Series("Data")
        Select Case currentReportType
            Case "Occupancy", "Cancellation"
                series.ChartType = SeriesChartType.Line
                series.XValueType = ChartValueType.Date
                For Each row As DataRow In fullReportData.Rows
                    series.Points.AddXY(CDate(row(0)), CInt(row(1)))
                Next
                defaultChartArea.AxisX.LabelStyle.Format = "MM/dd"
                defaultChartArea.AxisY.Minimum = 0
            Case "RevenueSummary", "GuestDemographics", "RevenueForecast"
                series.ChartType = SeriesChartType.Pie
                series.IsValueShownAsLabel = True
                series.LegendText = "#VALX (#PERCENT)"
                For Each row As DataRow In fullReportData.Rows
                    series.Points.AddXY(row(0).ToString(), CDbl(row(1)))
                Next
            Case Else ' For detailed reports, no chart is applicable
                Dim noDataTitle As New Title("Chart not applicable for this report type.", Docking.Top, New System.Drawing.Font("Arial", 12, FontStyle.Italic), Color.Gray)
                chartReport.Titles.Add(noDataTitle)
                chartReport.Invalidate()
                Return
        End Select

        chartReport.Series.Add(series)
        chartReport.Invalidate()
    End Sub

    Private Sub DisplayCurrentPage()
        totalPages = CInt(Math.Ceiling(fullReportData.Rows.Count / ReportGridPageSize))
        If totalPages = 0 Then totalPages = 1
        If currentPage > totalPages Then currentPage = totalPages
        If currentPage < 1 Then currentPage = 1

        Dim pagedTable As DataTable = fullReportData.Clone()
        Dim startIndex = (currentPage - 1) * ReportGridPageSize
        Dim endIndex = Math.Min(startIndex + ReportGridPageSize - 1, fullReportData.Rows.Count - 1)

        For i = startIndex To endIndex
            pagedTable.ImportRow(fullReportData.Rows(i))
        Next

        dgvReport.DataSource = pagedTable
        UpdatePagingControls()
    End Sub

    Private Sub UpdatePagingControls()
        lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
        btnFirst.Enabled = (currentPage > 1)
        btnPrevious.Enabled = (currentPage > 1)
        btnNext.Enabled = (currentPage < totalPages)
        btnLast.Enabled = (currentPage < totalPages)
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        currentPage = 1
        DisplayCurrentPage()
    End Sub
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentPage > 1 Then
            currentPage -= 1
            DisplayCurrentPage()
        End If
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            DisplayCurrentPage()
        End If
    End Sub
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        currentPage = totalPages
        DisplayCurrentPage()
    End Sub
#End Region

#Region "PDF Export Logic"

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If fullReportData.Rows.Count = 0 Then
            MessageBox.Show("There is no data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim doc As New Document(iTextSharp.text.PageSize.A4.Rotate(), 36, 36, 80, 36)
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{currentReportType}Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf")

            Using fs As New FileStream(filePath, FileMode.Create)
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                Dim pageEvent As New ReportPageEventHandler()
                pageEvent.HotelName = hotelName
                pageEvent.ReportTitle = lblReportTitle.Text
                pageEvent.DateRange = If(dtpStartDate.Enabled, $"For period: {dtpStartDate.Value:D} to {dtpEndDate.Value:D}", "For All Time")
                writer.PageEvent = pageEvent
                doc.Open()

                If chkIncludeChart.Checked Then
                    ' Only add chart if it's applicable for the report type
                    Dim chartApplicable As Boolean = {"Occupancy", "Cancellation", "RevenueSummary", "GuestDemographics", "RevenueForecast"}.Contains(currentReportType)
                    If chartApplicable Then
                        Using ms As New MemoryStream()
                            chartReport.SaveImage(ms, ChartImageFormat.Png)
                            Dim chartImage = iTextSharp.text.Image.GetInstance(ms.ToArray())
                            chartImage.ScaleToFit(doc.PageSize.Width - doc.LeftMargin - doc.RightMargin, 250)
                            chartImage.Alignment = Element.ALIGN_CENTER
                            chartImage.SpacingBefore = 20
                            doc.Add(chartImage)
                        End Using
                    End If
                End If

                doc.Add(New Paragraph(" "))
                Dim tableTitleFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)
                Dim tableTitle As New Paragraph("Report Data Table", tableTitleFont)
                tableTitle.Alignment = Element.ALIGN_CENTER
                tableTitle.SpacingAfter = 10
                doc.Add(tableTitle)

                Dim table As New PdfPTable(fullReportData.Columns.Count)
                table.WidthPercentage = 100
                table.HeaderRows = 1
                table.SetWidths(CalculateColumnWidths(fullReportData))

                Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE)
                Dim headerBgColor As New BaseColor(63, 81, 181)

                For Each col As DataColumn In fullReportData.Columns
                    Dim cell As New PdfPCell(New Phrase(col.ColumnName, headerFont)) With {
                        .BackgroundColor = headerBgColor, .Padding = 5,
                        .HorizontalAlignment = Element.ALIGN_CENTER, .VerticalAlignment = Element.ALIGN_MIDDLE
                    }
                    table.AddCell(cell)
                Next

                Dim dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK)
                For Each row As DataRow In fullReportData.Rows
                    For i As Integer = 0 To fullReportData.Columns.Count - 1
                        Dim currentColumnName As String = fullReportData.Columns(i).ColumnName
                        Dim cellText As String
                        If (currentColumnName.Contains("Revenue") OrElse currentColumnName.Contains("Amount") OrElse currentColumnName = "Price" OrElse currentColumnName = "SubTotal") AndAlso IsNumeric(row(i)) Then
                            cellText = Convert.ToDecimal(row(i)).ToString("C", hotelCurrencyCulture)
                        Else
                            cellText = row(i).ToString()
                        End If
                        Dim cell As New PdfPCell(New Phrase(cellText, dataFont)) With {
                            .Padding = 3, .HorizontalAlignment = Element.ALIGN_LEFT, .VerticalAlignment = Element.ALIGN_MIDDLE
                        }
                        table.AddCell(cell)
                    Next
                Next

                ' --- ADD TOTAL ROW LOGIC ---
                Dim addTotalRow As Boolean = False
                Dim totalColumnName As String = ""

                Select Case currentReportType
                    Case "RoomPerformance", "StaffPerformance", "BookingSource"
                        If (cmbRoomType.Visible AndAlso cmbRoomType.SelectedIndex > 0) OrElse
                           (cmbStaff.Visible AndAlso cmbStaff.SelectedIndex > 0) OrElse
                           (cmbBookingSource.Visible AndAlso cmbBookingSource.SelectedIndex > 0) Then
                            addTotalRow = True
                            totalColumnName = "TotalReservationAmount"
                        End If
                    Case "AddonPopularity"
                        If cmbAddon.Visible AndAlso cmbAddon.SelectedIndex > 0 Then
                            addTotalRow = True
                            totalColumnName = "SubTotal"
                        End If
                End Select

                If addTotalRow AndAlso fullReportData.Columns.Contains(totalColumnName) Then
                    Dim totalAmount As Decimal = fullReportData.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)(totalColumnName))
                    Dim totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK)

                    Dim totalLabelCell As New PdfPCell(New Phrase("Total:", totalFont)) With {
                        .Colspan = fullReportData.Columns.Count - 1,
                        .HorizontalAlignment = Element.ALIGN_RIGHT, .Padding = 5, .BackgroundColor = BaseColor.LIGHT_GRAY
                    }
                    table.AddCell(totalLabelCell)

                    Dim totalValueCell As New PdfPCell(New Phrase(totalAmount.ToString("C", hotelCurrencyCulture), totalFont)) With {
                        .HorizontalAlignment = Element.ALIGN_RIGHT, .Padding = 5, .BackgroundColor = BaseColor.LIGHT_GRAY
                    }
                    table.AddCell(totalValueCell)
                End If
                ' --- END TOTAL ROW LOGIC ---

                doc.Add(table)
                doc.Close()

                MessageBox.Show($"Report successfully exported to your desktop:{vbCrLf}{filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                System.Diagnostics.Process.Start(filePath)
            End Using
        Catch ex As IOException
            MessageBox.Show($"Could not export to PDF. File may be open or you lack permissions.{vbCrLf}{ex.Message}", "PDF Export Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred during PDF export:{vbCrLf}{ex.Message}", "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CalculateColumnWidths(dt As DataTable) As Single()
        If dt.Columns.Count = 0 Then Return New Single() {}
        Dim widths(dt.Columns.Count - 1) As Single
        Dim totalWidth As Single = 0
        For i As Integer = 0 To dt.Columns.Count - 1
            Dim maxLength As Integer = dt.Columns(i).ColumnName.Length
            For Each row As DataRow In dt.Rows
                If row(i) IsNot DBNull.Value AndAlso row(i).ToString().Length > maxLength Then
                    maxLength = row(i).ToString().Length
                End If
            Next
            widths(i) = maxLength
            totalWidth += widths(i)
        Next
        If totalWidth = 0 Then
            For i As Integer = 0 To widths.Length - 1 : widths(i) = 1 : Next
            Return widths
        End If
        For i As Integer = 0 To widths.Length - 1
            widths(i) = (widths(i) / totalWidth) * 100.0F
        Next
        Return widths
    End Function

#End Region

End Class

Public Class ReportPageEventHandler
    Inherits PdfPageEventHelper
    Public Property HotelName As String
    Public Property ReportTitle As String
    Public Property DateRange As String
    Private headerFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.WHITE)
    Private subHeaderFont As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.WHITE)
    Private footerFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.GRAY)
    Private blueBackground As New BaseColor(63, 81, 181)

    Public Overrides Sub OnStartPage(writer As PdfWriter, document As Document)
        MyBase.OnStartPage(writer, document)
        Dim headerTable As New PdfPTable(1)
        headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin
        headerTable.DefaultCell.Border = 0
        Dim hotelNameCell As New PdfPCell(New Phrase(HotelName, headerFont)) With {
            .BackgroundColor = blueBackground, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER, .Padding = 6
        }
        headerTable.AddCell(hotelNameCell)
        Dim reportTitleCell As New PdfPCell(New Phrase(ReportTitle, subHeaderFont)) With {
            .BackgroundColor = blueBackground, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER, .PaddingBottom = 4
        }
        headerTable.AddCell(reportTitleCell)
        Dim dateRangeCell As New PdfPCell(New Phrase(DateRange, subHeaderFont)) With {
            .BackgroundColor = blueBackground, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER, .PaddingBottom = 10
        }
        headerTable.AddCell(dateRangeCell)
        headerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent)
    End Sub

    Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
        MyBase.OnEndPage(writer, document)
        Dim footerTable As New PdfPTable(2)
        footerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin
        footerTable.DefaultCell.Border = 0
        Dim generatedCell As New PdfPCell(New Phrase($"Generated on: {DateTime.Now:G}", footerFont)) With {
            .Border = 0, .HorizontalAlignment = Element.ALIGN_LEFT
        }
        footerTable.AddCell(generatedCell)
        Dim pageNumCell As New PdfPCell(New Phrase($"Page {writer.PageNumber}", footerFont)) With {
            .Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT
        }
        footerTable.AddCell(pageNumCell)
        footerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 5, writer.DirectContent)
    End Sub
End Class
