<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWalkin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCompleteCheckin = New System.Windows.Forms.Button()
        Me.flpNavigation = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlStep1 = New System.Windows.Forms.Panel()
        Me.lblCheckoutDate = New System.Windows.Forms.Label()
        Me.dtpCheckout = New System.Windows.Forms.DateTimePicker()
        Me.lblCheckinDate = New System.Windows.Forms.Label()
        Me.gbRoomTypes = New System.Windows.Forms.GroupBox()
        Me.btnAddRoom = New System.Windows.Forms.Button()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.dgvRoomTypes = New System.Windows.Forms.DataGridView()
        Me.dtpCheckin = New System.Windows.Forms.DateTimePicker()
        Me.lblStep1Title = New System.Windows.Forms.Label()
        Me.gbSelectedRooms = New System.Windows.Forms.GroupBox()
        Me.btnRemoveRoom = New System.Windows.Forms.Button()
        Me.lbSelectedRooms = New System.Windows.Forms.ListBox()
        Me.pnlStep2 = New System.Windows.Forms.Panel()
        Me.gbGuestDetails = New System.Windows.Forms.GroupBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.gbSearchGuest = New System.Windows.Forms.GroupBox()
        Me.lblGuestPoints = New System.Windows.Forms.Label()
        Me.dgvGuestResults = New System.Windows.Forms.DataGridView()
        Me.btnSearchGuest = New System.Windows.Forms.Button()
        Me.txtSearchGuest = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblStep2Title = New System.Windows.Forms.Label()
        Me.pnlStep3 = New System.Windows.Forms.Panel()
        Me.btnSearchAddons = New System.Windows.Forms.Button()
        Me.txtSearchAddons = New System.Windows.Forms.TextBox()
        Me.lblSearchAddons = New System.Windows.Forms.Label()
        Me.lblStep3Title = New System.Windows.Forms.Label()
        Me.clbAddons = New System.Windows.Forms.CheckedListBox()
        Me.pnlStep4 = New System.Windows.Forms.Panel()
        Me.cboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.lblPaymentMethod = New System.Windows.Forms.Label()
        Me.gbLoyalty = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnApplyPoints = New System.Windows.Forms.Button()
        Me.numPointsToUse = New System.Windows.Forms.NumericUpDown()
        Me.lblPointsToUse = New System.Windows.Forms.Label()
        Me.lblAvailablePoints = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.lblStep4Title = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.flpNavigation.SuspendLayout()
        Me.pnlStep1.SuspendLayout()
        Me.gbRoomTypes.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRoomTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSelectedRooms.SuspendLayout()
        Me.pnlStep2.SuspendLayout()
        Me.gbGuestDetails.SuspendLayout()
        Me.gbSearchGuest.SuspendLayout()
        CType(Me.dgvGuestResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep3.SuspendLayout()
        Me.pnlStep4.SuspendLayout()
        Me.gbLoyalty.SuspendLayout()
        CType(Me.numPointsToUse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(953, 5)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(102, 36)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Location = New System.Drawing.Point(629, 5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(102, 36)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(521, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 36)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCompleteCheckin
        '
        Me.btnCompleteCheckin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompleteCheckin.Location = New System.Drawing.Point(737, 3)
        Me.btnCompleteCheckin.Name = "btnCompleteCheckin"
        Me.btnCompleteCheckin.Size = New System.Drawing.Size(210, 38)
        Me.btnCompleteCheckin.TabIndex = 3
        Me.btnCompleteCheckin.Text = "Complete Check-in"
        Me.btnCompleteCheckin.UseVisualStyleBackColor = True
        '
        'flpNavigation
        '
        Me.flpNavigation.Controls.Add(Me.btnNext)
        Me.flpNavigation.Controls.Add(Me.btnCompleteCheckin)
        Me.flpNavigation.Controls.Add(Me.btnBack)
        Me.flpNavigation.Controls.Add(Me.btnCancel)
        Me.flpNavigation.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpNavigation.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpNavigation.Location = New System.Drawing.Point(0, 612)
        Me.flpNavigation.Margin = New System.Windows.Forms.Padding(5)
        Me.flpNavigation.Name = "flpNavigation"
        Me.flpNavigation.Size = New System.Drawing.Size(1058, 52)
        Me.flpNavigation.TabIndex = 4
        '
        'pnlStep1
        '
        Me.pnlStep1.Controls.Add(Me.lblCheckoutDate)
        Me.pnlStep1.Controls.Add(Me.dtpCheckout)
        Me.pnlStep1.Controls.Add(Me.lblCheckinDate)
        Me.pnlStep1.Controls.Add(Me.gbRoomTypes)
        Me.pnlStep1.Controls.Add(Me.dtpCheckin)
        Me.pnlStep1.Controls.Add(Me.lblStep1Title)
        Me.pnlStep1.Controls.Add(Me.gbSelectedRooms)
        Me.pnlStep1.Location = New System.Drawing.Point(14, 14)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(1032, 576)
        Me.pnlStep1.TabIndex = 5
        '
        'lblCheckoutDate
        '
        Me.lblCheckoutDate.AutoSize = True
        Me.lblCheckoutDate.Location = New System.Drawing.Point(528, 492)
        Me.lblCheckoutDate.Name = "lblCheckoutDate"
        Me.lblCheckoutDate.Size = New System.Drawing.Size(125, 20)
        Me.lblCheckoutDate.TabIndex = 9
        Me.lblCheckoutDate.Text = "Check-out Date:"
        '
        'dtpCheckout
        '
        Me.dtpCheckout.Location = New System.Drawing.Point(672, 492)
        Me.dtpCheckout.Name = "dtpCheckout"
        Me.dtpCheckout.Size = New System.Drawing.Size(200, 26)
        Me.dtpCheckout.TabIndex = 10
        '
        'lblCheckinDate
        '
        Me.lblCheckinDate.AutoSize = True
        Me.lblCheckinDate.Location = New System.Drawing.Point(12, 492)
        Me.lblCheckinDate.Name = "lblCheckinDate"
        Me.lblCheckinDate.Size = New System.Drawing.Size(114, 40)
        Me.lblCheckinDate.TabIndex = 5
        Me.lblCheckinDate.Text = "Check-in Date:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbRoomTypes
        '
        Me.gbRoomTypes.Controls.Add(Me.btnAddRoom)
        Me.gbRoomTypes.Controls.Add(Me.numQuantity)
        Me.gbRoomTypes.Controls.Add(Me.lblQuantity)
        Me.gbRoomTypes.Controls.Add(Me.dgvRoomTypes)
        Me.gbRoomTypes.Location = New System.Drawing.Point(12, 48)
        Me.gbRoomTypes.Name = "gbRoomTypes"
        Me.gbRoomTypes.Size = New System.Drawing.Size(492, 420)
        Me.gbRoomTypes.TabIndex = 3
        Me.gbRoomTypes.TabStop = False
        Me.gbRoomTypes.Text = "Available Room Types"
        '
        'btnAddRoom
        '
        Me.btnAddRoom.Location = New System.Drawing.Point(300, 346)
        Me.btnAddRoom.Name = "btnAddRoom"
        Me.btnAddRoom.Size = New System.Drawing.Size(168, 34)
        Me.btnAddRoom.TabIndex = 6
        Me.btnAddRoom.Text = "Add to Booking ->"
        Me.btnAddRoom.UseVisualStyleBackColor = True
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(96, 348)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(72, 26)
        Me.numQuantity.TabIndex = 5
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(12, 348)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(72, 40)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Text = "Quantity:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvRoomTypes
        '
        Me.dgvRoomTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoomTypes.Location = New System.Drawing.Point(7, 30)
        Me.dgvRoomTypes.Name = "dgvRoomTypes"
        Me.dgvRoomTypes.RowHeadersWidth = 62
        Me.dgvRoomTypes.RowTemplate.Height = 28
        Me.dgvRoomTypes.Size = New System.Drawing.Size(478, 300)
        Me.dgvRoomTypes.TabIndex = 0
        '
        'dtpCheckin
        '
        Me.dtpCheckin.Location = New System.Drawing.Point(144, 492)
        Me.dtpCheckin.Name = "dtpCheckin"
        Me.dtpCheckin.Size = New System.Drawing.Size(200, 26)
        Me.dtpCheckin.TabIndex = 8
        '
        'lblStep1Title
        '
        Me.lblStep1Title.AutoSize = True
        Me.lblStep1Title.Location = New System.Drawing.Point(12, 12)
        Me.lblStep1Title.Name = "lblStep1Title"
        Me.lblStep1Title.Size = New System.Drawing.Size(164, 40)
        Me.lblStep1Title.TabIndex = 0
        Me.lblStep1Title.Text = "Step 1: Select Rooms" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbSelectedRooms
        '
        Me.gbSelectedRooms.Controls.Add(Me.btnRemoveRoom)
        Me.gbSelectedRooms.Controls.Add(Me.lbSelectedRooms)
        Me.gbSelectedRooms.Location = New System.Drawing.Point(528, 48)
        Me.gbSelectedRooms.Name = "gbSelectedRooms"
        Me.gbSelectedRooms.Size = New System.Drawing.Size(492, 420)
        Me.gbSelectedRooms.TabIndex = 4
        Me.gbSelectedRooms.TabStop = False
        Me.gbSelectedRooms.Text = "Selected Rooms for Booking"
        '
        'btnRemoveRoom
        '
        Me.btnRemoveRoom.Location = New System.Drawing.Point(7, 378)
        Me.btnRemoveRoom.Name = "btnRemoveRoom"
        Me.btnRemoveRoom.Size = New System.Drawing.Size(168, 34)
        Me.btnRemoveRoom.TabIndex = 7
        Me.btnRemoveRoom.Text = "<- Remove Selected" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnRemoveRoom.UseVisualStyleBackColor = True
        '
        'lbSelectedRooms
        '
        Me.lbSelectedRooms.FormattingEnabled = True
        Me.lbSelectedRooms.ItemHeight = 20
        Me.lbSelectedRooms.Location = New System.Drawing.Point(7, 30)
        Me.lbSelectedRooms.Name = "lbSelectedRooms"
        Me.lbSelectedRooms.Size = New System.Drawing.Size(478, 324)
        Me.lbSelectedRooms.TabIndex = 0
        '
        'pnlStep2
        '
        Me.pnlStep2.Controls.Add(Me.gbGuestDetails)
        Me.pnlStep2.Controls.Add(Me.gbSearchGuest)
        Me.pnlStep2.Controls.Add(Me.lblStep2Title)
        Me.pnlStep2.Location = New System.Drawing.Point(14, 14)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(1238, 691)
        Me.pnlStep2.TabIndex = 6
        Me.pnlStep2.Visible = False
        '
        'gbGuestDetails
        '
        Me.gbGuestDetails.Controls.Add(Me.txtPhone)
        Me.gbGuestDetails.Controls.Add(Me.lblPhone)
        Me.gbGuestDetails.Controls.Add(Me.txtEmail)
        Me.gbGuestDetails.Controls.Add(Me.lblEmail)
        Me.gbGuestDetails.Controls.Add(Me.txtLastName)
        Me.gbGuestDetails.Controls.Add(Me.lblLastName)
        Me.gbGuestDetails.Controls.Add(Me.txtFirstName)
        Me.gbGuestDetails.Controls.Add(Me.lblFirstName)
        Me.gbGuestDetails.Location = New System.Drawing.Point(12, 300)
        Me.gbGuestDetails.Name = "gbGuestDetails"
        Me.gbGuestDetails.Size = New System.Drawing.Size(1008, 216)
        Me.gbGuestDetails.TabIndex = 10
        Me.gbGuestDetails.TabStop = False
        Me.gbGuestDetails.Text = "Guest Details" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(636, 84)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(336, 26)
        Me.txtPhone.TabIndex = 12
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(504, 84)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(119, 40)
        Me.lblPhone.TabIndex = 11
        Me.lblPhone.Text = "Phone Number:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(144, 84)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(336, 26)
        Me.txtEmail.TabIndex = 10
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(12, 84)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(52, 40)
        Me.lblEmail.TabIndex = 9
        Me.lblEmail.Text = "Email:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(636, 36)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(336, 26)
        Me.txtLastName.TabIndex = 8
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(504, 36)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(90, 40)
        Me.lblLastName.TabIndex = 7
        Me.lblLastName.Text = "Last Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(144, 36)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(336, 26)
        Me.txtFirstName.TabIndex = 6
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(12, 36)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(90, 20)
        Me.lblFirstName.TabIndex = 5
        Me.lblFirstName.Text = "First Name:"
        '
        'gbSearchGuest
        '
        Me.gbSearchGuest.Controls.Add(Me.lblGuestPoints)
        Me.gbSearchGuest.Controls.Add(Me.dgvGuestResults)
        Me.gbSearchGuest.Controls.Add(Me.btnSearchGuest)
        Me.gbSearchGuest.Controls.Add(Me.txtSearchGuest)
        Me.gbSearchGuest.Controls.Add(Me.lblSearch)
        Me.gbSearchGuest.Location = New System.Drawing.Point(12, 48)
        Me.gbSearchGuest.Name = "gbSearchGuest"
        Me.gbSearchGuest.Size = New System.Drawing.Size(1008, 240)
        Me.gbSearchGuest.TabIndex = 9
        Me.gbSearchGuest.TabStop = False
        Me.gbSearchGuest.Text = "Search for Returning Guest"
        '
        'lblGuestPoints
        '
        Me.lblGuestPoints.AutoSize = True
        Me.lblGuestPoints.Location = New System.Drawing.Point(12, 204)
        Me.lblGuestPoints.Name = "lblGuestPoints"
        Me.lblGuestPoints.Size = New System.Drawing.Size(137, 40)
        Me.lblGuestPoints.TabIndex = 4
        Me.lblGuestPoints.Text = "Available Points: 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvGuestResults
        '
        Me.dgvGuestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuestResults.Location = New System.Drawing.Point(12, 84)
        Me.dgvGuestResults.Name = "dgvGuestResults"
        Me.dgvGuestResults.RowHeadersWidth = 62
        Me.dgvGuestResults.RowTemplate.Height = 28
        Me.dgvGuestResults.Size = New System.Drawing.Size(984, 108)
        Me.dgvGuestResults.TabIndex = 3
        '
        'btnSearchGuest
        '
        Me.btnSearchGuest.Location = New System.Drawing.Point(708, 34)
        Me.btnSearchGuest.Name = "btnSearchGuest"
        Me.btnSearchGuest.Size = New System.Drawing.Size(120, 34)
        Me.btnSearchGuest.TabIndex = 2
        Me.btnSearchGuest.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSearchGuest.UseVisualStyleBackColor = True
        '
        'txtSearchGuest
        '
        Me.txtSearchGuest.Location = New System.Drawing.Point(216, 36)
        Me.txtSearchGuest.Name = "txtSearchGuest"
        Me.txtSearchGuest.Size = New System.Drawing.Size(480, 26)
        Me.txtSearchGuest.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(12, 36)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(191, 40)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search by Name or Email:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblStep2Title
        '
        Me.lblStep2Title.AutoSize = True
        Me.lblStep2Title.Location = New System.Drawing.Point(12, 12)
        Me.lblStep2Title.Name = "lblStep2Title"
        Me.lblStep2Title.Size = New System.Drawing.Size(236, 20)
        Me.lblStep2Title.TabIndex = 0
        Me.lblStep2Title.Text = "Step 2: Enter Guest Information"
        '
        'pnlStep3
        '
        Me.pnlStep3.Controls.Add(Me.btnSearchAddons)
        Me.pnlStep3.Controls.Add(Me.txtSearchAddons)
        Me.pnlStep3.Controls.Add(Me.lblSearchAddons)
        Me.pnlStep3.Controls.Add(Me.lblStep3Title)
        Me.pnlStep3.Controls.Add(Me.clbAddons)
        Me.pnlStep3.Location = New System.Drawing.Point(14, 14)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(1032, 576)
        Me.pnlStep3.TabIndex = 7
        Me.pnlStep3.Visible = False
        '
        'btnSearchAddons
        '
        Me.btnSearchAddons.Location = New System.Drawing.Point(931, 8)
        Me.btnSearchAddons.Name = "btnSearchAddons"
        Me.btnSearchAddons.Size = New System.Drawing.Size(102, 34)
        Me.btnSearchAddons.TabIndex = 4
        Me.btnSearchAddons.Text = "Search"
        Me.btnSearchAddons.UseVisualStyleBackColor = True
        '
        'txtSearchAddons
        '
        Me.txtSearchAddons.Location = New System.Drawing.Point(698, 16)
        Me.txtSearchAddons.Name = "txtSearchAddons"
        Me.txtSearchAddons.Size = New System.Drawing.Size(227, 26)
        Me.txtSearchAddons.TabIndex = 3
        '
        'lblSearchAddons
        '
        Me.lblSearchAddons.AutoSize = True
        Me.lblSearchAddons.Location = New System.Drawing.Point(628, 16)
        Me.lblSearchAddons.Name = "lblSearchAddons"
        Me.lblSearchAddons.Size = New System.Drawing.Size(64, 40)
        Me.lblSearchAddons.TabIndex = 2
        Me.lblSearchAddons.Text = "Search:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblStep3Title
        '
        Me.lblStep3Title.AutoSize = True
        Me.lblStep3Title.Location = New System.Drawing.Point(12, 12)
        Me.lblStep3Title.Name = "lblStep3Title"
        Me.lblStep3Title.Size = New System.Drawing.Size(241, 40)
        Me.lblStep3Title.TabIndex = 0
        Me.lblStep3Title.Text = "Step 3: Select Addons (Optional)" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'clbAddons
        '
        Me.clbAddons.FormattingEnabled = True
        Me.clbAddons.Location = New System.Drawing.Point(16, 58)
        Me.clbAddons.Name = "clbAddons"
        Me.clbAddons.Size = New System.Drawing.Size(1008, 464)
        Me.clbAddons.TabIndex = 1
        '
        'pnlStep4
        '
        Me.pnlStep4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStep4.Controls.Add(Me.cboPaymentMethod)
        Me.pnlStep4.Controls.Add(Me.lblPaymentMethod)
        Me.pnlStep4.Controls.Add(Me.lblSummary)
        Me.pnlStep4.Controls.Add(Me.lblStep4Title)
        Me.pnlStep4.Controls.Add(Me.gbLoyalty)
        Me.pnlStep4.Location = New System.Drawing.Point(14, 14)
        Me.pnlStep4.Name = "pnlStep4"
        Me.pnlStep4.Size = New System.Drawing.Size(1032, 576)
        Me.pnlStep4.TabIndex = 8
        Me.pnlStep4.Visible = False
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.FormattingEnabled = True
        Me.cboPaymentMethod.Items.AddRange(New Object() {"Cash", "", "", "Credit Card", "", "", "Bank Transfer", "", "", "Online Payment"})
        Me.cboPaymentMethod.Location = New System.Drawing.Point(672, 344)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.Size = New System.Drawing.Size(121, 28)
        Me.cboPaymentMethod.TabIndex = 4
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.AutoSize = True
        Me.lblPaymentMethod.Location = New System.Drawing.Point(528, 344)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(133, 40)
        Me.lblPaymentMethod.TabIndex = 3
        Me.lblPaymentMethod.Text = "Payment Method:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbLoyalty
        '
        Me.gbLoyalty.Controls.Add(Me.lblTotal)
        Me.gbLoyalty.Controls.Add(Me.btnApplyPoints)
        Me.gbLoyalty.Controls.Add(Me.numPointsToUse)
        Me.gbLoyalty.Controls.Add(Me.lblPointsToUse)
        Me.gbLoyalty.Controls.Add(Me.lblAvailablePoints)
        Me.gbLoyalty.Location = New System.Drawing.Point(528, 48)
        Me.gbLoyalty.Name = "gbLoyalty"
        Me.gbLoyalty.Size = New System.Drawing.Size(492, 293)
        Me.gbLoyalty.TabIndex = 2
        Me.gbLoyalty.TabStop = False
        Me.gbLoyalty.Text = "Use Loyalty Points" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(12, 124)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(149, 40)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.Text = "TOTAL: PHP 0.00" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnApplyPoints
        '
        Me.btnApplyPoints.Location = New System.Drawing.Point(288, 82)
        Me.btnApplyPoints.Name = "btnApplyPoints"
        Me.btnApplyPoints.Size = New System.Drawing.Size(180, 34)
        Me.btnApplyPoints.TabIndex = 3
        Me.btnApplyPoints.Text = "Apply Discount" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnApplyPoints.UseVisualStyleBackColor = True
        '
        'numPointsToUse
        '
        Me.numPointsToUse.Location = New System.Drawing.Point(144, 84)
        Me.numPointsToUse.Name = "numPointsToUse"
        Me.numPointsToUse.Size = New System.Drawing.Size(120, 26)
        Me.numPointsToUse.TabIndex = 5
        '
        'lblPointsToUse
        '
        Me.lblPointsToUse.AutoSize = True
        Me.lblPointsToUse.Location = New System.Drawing.Point(12, 84)
        Me.lblPointsToUse.Name = "lblPointsToUse"
        Me.lblPointsToUse.Size = New System.Drawing.Size(108, 40)
        Me.lblPointsToUse.TabIndex = 4
        Me.lblPointsToUse.Text = "Points to Use:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblAvailablePoints
        '
        Me.lblAvailablePoints.AutoSize = True
        Me.lblAvailablePoints.Location = New System.Drawing.Point(12, 36)
        Me.lblAvailablePoints.Name = "lblAvailablePoints"
        Me.lblAvailablePoints.Size = New System.Drawing.Size(218, 40)
        Me.lblAvailablePoints.TabIndex = 3
        Me.lblAvailablePoints.Text = "Available Points: 0 (PHP 0.00)" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Location = New System.Drawing.Point(12, 48)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(76, 20)
        Me.lblSummary.TabIndex = 1
        Me.lblSummary.Text = "Summary"
        '
        'lblStep4Title
        '
        Me.lblStep4Title.AutoSize = True
        Me.lblStep4Title.Location = New System.Drawing.Point(12, 12)
        Me.lblStep4Title.Name = "lblStep4Title"
        Me.lblStep4Title.Size = New System.Drawing.Size(224, 40)
        Me.lblStep4Title.TabIndex = 0
        Me.lblStep4Title.Text = "Step 4: Confirmation & Payment" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'frmWalkin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 664)
        Me.Controls.Add(Me.flpNavigation)
        Me.Controls.Add(Me.pnlStep3)
        Me.Controls.Add(Me.pnlStep2)
        Me.Controls.Add(Me.pnlStep1)
        Me.Controls.Add(Me.pnlStep4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWalkin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Walk-in Guest Wizard"
        Me.flpNavigation.ResumeLayout(False)
        Me.pnlStep1.ResumeLayout(False)
        Me.pnlStep1.PerformLayout()
        Me.gbRoomTypes.ResumeLayout(False)
        Me.gbRoomTypes.PerformLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRoomTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSelectedRooms.ResumeLayout(False)
        Me.pnlStep2.ResumeLayout(False)
        Me.pnlStep2.PerformLayout()
        Me.gbGuestDetails.ResumeLayout(False)
        Me.gbGuestDetails.PerformLayout()
        Me.gbSearchGuest.ResumeLayout(False)
        Me.gbSearchGuest.PerformLayout()
        CType(Me.dgvGuestResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep3.ResumeLayout(False)
        Me.pnlStep3.PerformLayout()
        Me.pnlStep4.ResumeLayout(False)
        Me.pnlStep4.PerformLayout()
        Me.gbLoyalty.ResumeLayout(False)
        Me.gbLoyalty.PerformLayout()
        CType(Me.numPointsToUse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnNext As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCompleteCheckin As Button
    Friend WithEvents flpNavigation As FlowLayoutPanel
    Friend WithEvents pnlStep1 As Panel
    Friend WithEvents pnlStep2 As Panel
    Friend WithEvents pnlStep3 As Panel
    Friend WithEvents pnlStep4 As Panel
    Friend WithEvents gbSelectedRooms As GroupBox
    Friend WithEvents dtpCheckout As DateTimePicker
    Friend WithEvents lblCheckoutDate As Label
    Friend WithEvents dtpCheckin As DateTimePicker
    Friend WithEvents lblCheckinDate As Label
    Friend WithEvents btnRemoveRoom As Button
    Friend WithEvents lbSelectedRooms As ListBox
    Friend WithEvents gbRoomTypes As GroupBox
    Friend WithEvents btnAddRoom As Button
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents lblQuantity As Label
    Friend WithEvents dgvRoomTypes As DataGridView
    Friend WithEvents lblStep1Title As Label
    Friend WithEvents gbGuestDetails As GroupBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblFirstName As Label
    Friend WithEvents gbSearchGuest As GroupBox
    Friend WithEvents lblGuestPoints As Label
    Friend WithEvents dgvGuestResults As DataGridView
    Friend WithEvents btnSearchGuest As Button
    Friend WithEvents txtSearchGuest As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents lblStep2Title As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents clbAddons As CheckedListBox
    Friend WithEvents lblStep3Title As Label
    Friend WithEvents gbLoyalty As GroupBox
    Friend WithEvents lblSummary As Label
    Friend WithEvents lblStep4Title As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnApplyPoints As Button
    Friend WithEvents numPointsToUse As NumericUpDown
    Friend WithEvents lblPointsToUse As Label
    Friend WithEvents lblAvailablePoints As Label
    Friend WithEvents cboPaymentMethod As ComboBox
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents btnSearchAddons As Button
    Friend WithEvents txtSearchAddons As TextBox
    Friend WithEvents lblSearchAddons As Label
End Class
