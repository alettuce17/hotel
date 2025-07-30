<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.pnlReportList = New System.Windows.Forms.Panel()
        Me.flpReports = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnOccupancyReport = New System.Windows.Forms.Button()
        Me.btnGuestReport = New System.Windows.Forms.Button()
        Me.btnRevenueForecast = New System.Windows.Forms.Button()
        Me.btnRevenueSummary = New System.Windows.Forms.Button()
        Me.btnGuestDemographics = New System.Windows.Forms.Button()
        Me.btnBookingSource = New System.Windows.Forms.Button()
        Me.btnRoomPerformance = New System.Windows.Forms.Button()
        Me.btnAddonPopularity = New System.Windows.Forms.Button()
        Me.btnStaffPerformance = New System.Windows.Forms.Button()
        Me.btnCancellationReport = New System.Windows.Forms.Button()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.chkIncludeChart = New System.Windows.Forms.CheckBox()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.cmbRoomType = New System.Windows.Forms.ComboBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblReportTitle = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlPaging = New System.Windows.Forms.Panel()
        Me.lblPageInfo = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnSearchReport = New System.Windows.Forms.Button()
        Me.txtSearchReport = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.chartReport = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmbNationality = New System.Windows.Forms.ComboBox()
        Me.cmbBookingSource = New System.Windows.Forms.ComboBox()
        Me.cmbAddon = New System.Windows.Forms.ComboBox()
        Me.cmbStaff = New System.Windows.Forms.ComboBox()
        Me.pnlReportList.SuspendLayout()
        Me.flpReports.SuspendLayout()
        Me.pnlDisplay.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.pnlPaging.SuspendLayout()
        CType(Me.chartReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlReportList
        '
        Me.pnlReportList.Controls.Add(Me.flpReports)
        Me.pnlReportList.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlReportList.Location = New System.Drawing.Point(0, 0)
        Me.pnlReportList.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.pnlReportList.Name = "pnlReportList"
        Me.pnlReportList.Size = New System.Drawing.Size(147, 612)
        Me.pnlReportList.TabIndex = 0
        '
        'flpReports
        '
        Me.flpReports.Controls.Add(Me.btnOccupancyReport)
        Me.flpReports.Controls.Add(Me.btnGuestReport)
        Me.flpReports.Controls.Add(Me.btnRevenueForecast)
        Me.flpReports.Controls.Add(Me.btnRevenueSummary)
        Me.flpReports.Controls.Add(Me.btnGuestDemographics)
        Me.flpReports.Controls.Add(Me.btnBookingSource)
        Me.flpReports.Controls.Add(Me.btnRoomPerformance)
        Me.flpReports.Controls.Add(Me.btnAddonPopularity)
        Me.flpReports.Controls.Add(Me.btnStaffPerformance)
        Me.flpReports.Controls.Add(Me.btnCancellationReport)
        Me.flpReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpReports.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpReports.Location = New System.Drawing.Point(0, 0)
        Me.flpReports.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.flpReports.Name = "flpReports"
        Me.flpReports.Size = New System.Drawing.Size(147, 612)
        Me.flpReports.TabIndex = 0
        '
        'btnOccupancyReport
        '
        Me.btnOccupancyReport.Location = New System.Drawing.Point(2, 1)
        Me.btnOccupancyReport.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnOccupancyReport.Name = "btnOccupancyReport"
        Me.btnOccupancyReport.Size = New System.Drawing.Size(145, 69)
        Me.btnOccupancyReport.TabIndex = 0
        Me.btnOccupancyReport.Text = "Occupancy Report"
        Me.btnOccupancyReport.UseVisualStyleBackColor = True
        '
        'btnGuestReport
        '
        Me.btnGuestReport.Location = New System.Drawing.Point(2, 72)
        Me.btnGuestReport.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnGuestReport.Name = "btnGuestReport"
        Me.btnGuestReport.Size = New System.Drawing.Size(145, 69)
        Me.btnGuestReport.TabIndex = 2
        Me.btnGuestReport.Text = "Guest Report "
        Me.btnGuestReport.UseVisualStyleBackColor = True
        Me.btnGuestReport.Visible = False
        '
        'btnRevenueForecast
        '
        Me.btnRevenueForecast.Location = New System.Drawing.Point(2, 143)
        Me.btnRevenueForecast.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnRevenueForecast.Name = "btnRevenueForecast"
        Me.btnRevenueForecast.Size = New System.Drawing.Size(145, 69)
        Me.btnRevenueForecast.TabIndex = 3
        Me.btnRevenueForecast.Text = "Revenue Forecast"
        Me.btnRevenueForecast.UseVisualStyleBackColor = True
        Me.btnRevenueForecast.Visible = False
        '
        'btnRevenueSummary
        '
        Me.btnRevenueSummary.Location = New System.Drawing.Point(2, 214)
        Me.btnRevenueSummary.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnRevenueSummary.Name = "btnRevenueSummary"
        Me.btnRevenueSummary.Size = New System.Drawing.Size(145, 69)
        Me.btnRevenueSummary.TabIndex = 4
        Me.btnRevenueSummary.Text = "Revenue Summary"
        Me.btnRevenueSummary.UseVisualStyleBackColor = True
        '
        'btnGuestDemographics
        '
        Me.btnGuestDemographics.Location = New System.Drawing.Point(2, 285)
        Me.btnGuestDemographics.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnGuestDemographics.Name = "btnGuestDemographics"
        Me.btnGuestDemographics.Size = New System.Drawing.Size(145, 69)
        Me.btnGuestDemographics.TabIndex = 5
        Me.btnGuestDemographics.Text = "Guest Demographics"
        Me.btnGuestDemographics.UseVisualStyleBackColor = True
        '
        'btnBookingSource
        '
        Me.btnBookingSource.Location = New System.Drawing.Point(2, 356)
        Me.btnBookingSource.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnBookingSource.Name = "btnBookingSource"
        Me.btnBookingSource.Size = New System.Drawing.Size(145, 69)
        Me.btnBookingSource.TabIndex = 6
        Me.btnBookingSource.Text = "Booking Source Summary" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnBookingSource.UseVisualStyleBackColor = True
        '
        'btnRoomPerformance
        '
        Me.btnRoomPerformance.Location = New System.Drawing.Point(2, 427)
        Me.btnRoomPerformance.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnRoomPerformance.Name = "btnRoomPerformance"
        Me.btnRoomPerformance.Size = New System.Drawing.Size(145, 69)
        Me.btnRoomPerformance.TabIndex = 7
        Me.btnRoomPerformance.Text = "Room Type Performance"
        Me.btnRoomPerformance.UseVisualStyleBackColor = True
        '
        'btnAddonPopularity
        '
        Me.btnAddonPopularity.Location = New System.Drawing.Point(2, 498)
        Me.btnAddonPopularity.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnAddonPopularity.Name = "btnAddonPopularity"
        Me.btnAddonPopularity.Size = New System.Drawing.Size(145, 69)
        Me.btnAddonPopularity.TabIndex = 8
        Me.btnAddonPopularity.Text = "Addon Popularity" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAddonPopularity.UseVisualStyleBackColor = True
        '
        'btnStaffPerformance
        '
        Me.btnStaffPerformance.Location = New System.Drawing.Point(151, 1)
        Me.btnStaffPerformance.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnStaffPerformance.Name = "btnStaffPerformance"
        Me.btnStaffPerformance.Size = New System.Drawing.Size(145, 69)
        Me.btnStaffPerformance.TabIndex = 9
        Me.btnStaffPerformance.Text = "Staff Booking Performance" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnStaffPerformance.UseVisualStyleBackColor = True
        '
        'btnCancellationReport
        '
        Me.btnCancellationReport.Location = New System.Drawing.Point(151, 72)
        Me.btnCancellationReport.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnCancellationReport.Name = "btnCancellationReport"
        Me.btnCancellationReport.Size = New System.Drawing.Size(145, 69)
        Me.btnCancellationReport.TabIndex = 10
        Me.btnCancellationReport.Text = "Cancellation Report"
        Me.btnCancellationReport.UseVisualStyleBackColor = True
        '
        'pnlDisplay
        '
        Me.pnlDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDisplay.Controls.Add(Me.chkIncludeChart)
        Me.pnlDisplay.Controls.Add(Me.pnlFilters)
        Me.pnlDisplay.Controls.Add(Me.pnlPaging)
        Me.pnlDisplay.Controls.Add(Me.chartReport)
        Me.pnlDisplay.Controls.Add(Me.dgvReport)
        Me.pnlDisplay.Location = New System.Drawing.Point(147, 0)
        Me.pnlDisplay.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(1104, 679)
        Me.pnlDisplay.TabIndex = 1
        '
        'chkIncludeChart
        '
        Me.chkIncludeChart.AutoSize = True
        Me.chkIncludeChart.Location = New System.Drawing.Point(5, 448)
        Me.chkIncludeChart.Name = "chkIncludeChart"
        Me.chkIncludeChart.Size = New System.Drawing.Size(124, 17)
        Me.chkIncludeChart.TabIndex = 12
        Me.chkIncludeChart.Text = "Include Chart in PDF"
        Me.chkIncludeChart.UseVisualStyleBackColor = True
        '
        'pnlFilters
        '
        Me.pnlFilters.Controls.Add(Me.cmbStaff)
        Me.pnlFilters.Controls.Add(Me.cmbAddon)
        Me.pnlFilters.Controls.Add(Me.cmbBookingSource)
        Me.pnlFilters.Controls.Add(Me.cmbNationality)
        Me.pnlFilters.Controls.Add(Me.cmbRoomType)
        Me.pnlFilters.Controls.Add(Me.dtpEndDate)
        Me.pnlFilters.Controls.Add(Me.dtpStartDate)
        Me.pnlFilters.Controls.Add(Me.lblReportTitle)
        Me.pnlFilters.Controls.Add(Me.lblStartDate)
        Me.pnlFilters.Controls.Add(Me.lblEndDate)
        Me.pnlFilters.Controls.Add(Me.btnGenerate)
        Me.pnlFilters.Controls.Add(Me.btnExport)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1104, 65)
        Me.pnlFilters.TabIndex = 11
        '
        'cmbRoomType
        '
        Me.cmbRoomType.FormattingEnabled = True
        Me.cmbRoomType.Location = New System.Drawing.Point(647, 30)
        Me.cmbRoomType.Name = "cmbRoomType"
        Me.cmbRoomType.Size = New System.Drawing.Size(83, 21)
        Me.cmbRoomType.TabIndex = 8
        Me.cmbRoomType.Visible = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(337, 31)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(205, 20)
        Me.dtpEndDate.TabIndex = 4
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(69, 31)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(205, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'lblReportTitle
        '
        Me.lblReportTitle.AutoSize = True
        Me.lblReportTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReportTitle.Location = New System.Drawing.Point(4, 5)
        Me.lblReportTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Size = New System.Drawing.Size(177, 26)
        Me.lblReportTitle.TabIndex = 0
        Me.lblReportTitle.Text = "Select a Report"
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(4, 31)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(58, 26)
        Me.lblStartDate.TabIndex = 1
        Me.lblStartDate.Text = "Start Date:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(277, 31)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(55, 26)
        Me.lblEndDate.TabIndex = 3
        Me.lblEndDate.Text = "End Date:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(548, 31)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(94, 20)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "Generate Report" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(735, 31)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(80, 20)
        Me.btnExport.TabIndex = 7
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'pnlPaging
        '
        Me.pnlPaging.Controls.Add(Me.lblPageInfo)
        Me.pnlPaging.Controls.Add(Me.btnLast)
        Me.pnlPaging.Controls.Add(Me.btnPrevious)
        Me.pnlPaging.Controls.Add(Me.btnNext)
        Me.pnlPaging.Controls.Add(Me.btnFirst)
        Me.pnlPaging.Controls.Add(Me.btnSearchReport)
        Me.pnlPaging.Controls.Add(Me.txtSearchReport)
        Me.pnlPaging.Controls.Add(Me.lblSearch)
        Me.pnlPaging.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPaging.Location = New System.Drawing.Point(0, 520)
        Me.pnlPaging.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPaging.Name = "pnlPaging"
        Me.pnlPaging.Size = New System.Drawing.Size(1104, 90)
        Me.pnlPaging.TabIndex = 10
        '
        'lblPageInfo
        '
        Me.lblPageInfo.AutoSize = True
        Me.lblPageInfo.Location = New System.Drawing.Point(526, 29)
        Me.lblPageInfo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPageInfo.Name = "lblPageInfo"
        Me.lblPageInfo.Size = New System.Drawing.Size(83, 36)
        Me.lblPageInfo.TabIndex = 9
        Me.lblPageInfo.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(693, 25)
        Me.btnLast.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(57, 25)
        Me.btnLast.TabIndex = 8
        Me.btnLast.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(460, 26)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(57, 25)
        Me.btnPrevious.TabIndex = 7
        Me.btnPrevious.Text = "< "
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(627, 25)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(57, 25)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(395, 26)
        Me.btnFirst.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(57, 25)
        Me.btnFirst.TabIndex = 5
        Me.btnFirst.Text = "<< "
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnSearchReport
        '
        Me.btnSearchReport.Location = New System.Drawing.Point(313, 26)
        Me.btnSearchReport.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearchReport.Name = "btnSearchReport"
        Me.btnSearchReport.Size = New System.Drawing.Size(72, 25)
        Me.btnSearchReport.TabIndex = 4
        Me.btnSearchReport.Text = "Search"
        Me.btnSearchReport.UseVisualStyleBackColor = True
        '
        'txtSearchReport
        '
        Me.txtSearchReport.Location = New System.Drawing.Point(25, 29)
        Me.txtSearchReport.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchReport.Name = "txtSearchReport"
        Me.txtSearchReport.Size = New System.Drawing.Size(285, 24)
        Me.txtSearchReport.TabIndex = 3
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(23, 9)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(136, 36)
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "Search by Room #:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'chartReport
        '
        ChartArea3.Name = "ChartArea1"
        Me.chartReport.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chartReport.Legends.Add(Legend3)
        Me.chartReport.Location = New System.Drawing.Point(2, 69)
        Me.chartReport.Margin = New System.Windows.Forms.Padding(2)
        Me.chartReport.Name = "chartReport"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chartReport.Series.Add(Series3)
        Me.chartReport.Size = New System.Drawing.Size(395, 374)
        Me.chartReport.TabIndex = 9
        Me.chartReport.Text = "Chart1"
        '
        'dgvReport
        '
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(395, 69)
        Me.dgvReport.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.RowHeadersWidth = 51
        Me.dgvReport.RowTemplate.Height = 28
        Me.dgvReport.Size = New System.Drawing.Size(486, 447)
        Me.dgvReport.TabIndex = 8
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'cmbNationality
        '
        Me.cmbNationality.FormattingEnabled = True
        Me.cmbNationality.Location = New System.Drawing.Point(647, 31)
        Me.cmbNationality.Name = "cmbNationality"
        Me.cmbNationality.Size = New System.Drawing.Size(83, 21)
        Me.cmbNationality.TabIndex = 9
        Me.cmbNationality.Visible = False
        '
        'cmbBookingSource
        '
        Me.cmbBookingSource.FormattingEnabled = True
        Me.cmbBookingSource.Location = New System.Drawing.Point(647, 30)
        Me.cmbBookingSource.Name = "cmbBookingSource"
        Me.cmbBookingSource.Size = New System.Drawing.Size(83, 21)
        Me.cmbBookingSource.TabIndex = 10
        Me.cmbBookingSource.Visible = False
        '
        'cmbAddon
        '
        Me.cmbAddon.FormattingEnabled = True
        Me.cmbAddon.Location = New System.Drawing.Point(647, 30)
        Me.cmbAddon.Name = "cmbAddon"
        Me.cmbAddon.Size = New System.Drawing.Size(83, 21)
        Me.cmbAddon.TabIndex = 11
        Me.cmbAddon.Visible = False
        '
        'cmbStaff
        '
        Me.cmbStaff.FormattingEnabled = True
        Me.cmbStaff.Location = New System.Drawing.Point(647, 31)
        Me.cmbStaff.Name = "cmbStaff"
        Me.cmbStaff.Size = New System.Drawing.Size(83, 21)
        Me.cmbStaff.TabIndex = 12
        Me.cmbStaff.Visible = False
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 612)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.pnlReportList)
        Me.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Name = "frmReports"
        Me.Text = "Staff Booking Performance" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.pnlReportList.ResumeLayout(False)
        Me.flpReports.ResumeLayout(False)
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlPaging.ResumeLayout(False)
        Me.pnlPaging.PerformLayout()
        CType(Me.chartReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlReportList As Panel
    Friend WithEvents flpReports As FlowLayoutPanel
    Friend WithEvents pnlDisplay As Panel
    Friend WithEvents btnGenerate As Button
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblReportTitle As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents btnOccupancyReport As Button
    Friend WithEvents btnGuestReport As Button
    Friend WithEvents btnRevenueForecast As Button
    Friend WithEvents btnRevenueSummary As Button
    Friend WithEvents btnGuestDemographics As Button
    Friend WithEvents btnBookingSource As Button
    Friend WithEvents btnRoomPerformance As Button
    Friend WithEvents btnAddonPopularity As Button
    Friend WithEvents btnStaffPerformance As Button
    Friend WithEvents btnCancellationReport As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents chartReport As DataVisualization.Charting.Chart
    Friend WithEvents pnlPaging As Panel
    Friend WithEvents lblPageInfo As Label
    Friend WithEvents btnLast As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnSearchReport As Button
    Friend WithEvents txtSearchReport As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents chkIncludeChart As CheckBox
    Friend WithEvents cmbRoomType As ComboBox
    Friend WithEvents cmbNationality As ComboBox
    Friend WithEvents cmbBookingSource As ComboBox
    Friend WithEvents cmbAddon As ComboBox
    Friend WithEvents cmbStaff As ComboBox
End Class
