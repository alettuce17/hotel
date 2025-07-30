<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewReservation
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
        Me.btnCompleteBooking = New System.Windows.Forms.Button()
        Me.flpNavigation = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlStep1 = New System.Windows.Forms.Panel()
        Me.txtDiscountID = New System.Windows.Forms.TextBox()
        Me.lblDiscountID = New System.Windows.Forms.Label()
        Me.cboDiscountType = New System.Windows.Forms.ComboBox()
        Me.lblDiscountType = New System.Windows.Forms.Label()
        Me.btnApplyDiscount = New System.Windows.Forms.Button()
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
        Me.lblStep2Title = New System.Windows.Forms.Label()
        Me.gbGuestDetails = New System.Windows.Forms.GroupBox()
        Me.txtNumAdults = New System.Windows.Forms.NumericUpDown()
        Me.lblNumAdults = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.gbSearchGuest = New System.Windows.Forms.GroupBox()
        Me.lblGuestTierInfo = New System.Windows.Forms.Label()
        Me.dgvGuestResults = New System.Windows.Forms.DataGridView()
        Me.btnSearchGuest = New System.Windows.Forms.Button()
        Me.txtSearchGuest = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.pnlStep3 = New System.Windows.Forms.Panel()
        Me.btnRemoveSelectedAddon = New System.Windows.Forms.Button()
        Me.dgvSelectedAddons = New System.Windows.Forms.DataGridView()
        Me.btnAddSelectedAddon = New System.Windows.Forms.Button()
        Me.numAddonQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lstAvailableAddons = New System.Windows.Forms.ListBox()
        Me.btnSearchAddons = New System.Windows.Forms.Button()
        Me.txtSearchAddons = New System.Windows.Forms.TextBox()
        Me.lblSearchAddons = New System.Windows.Forms.Label()
        Me.lblStep3Title = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAddonQuantity = New System.Windows.Forms.Label()
        Me.pnlStep4 = New System.Windows.Forms.Panel()
        Me.lblChangeDue = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtCashTendered = New System.Windows.Forms.TextBox()
        Me.lblCashTendered = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox()
        Me.lblDownPayment = New System.Windows.Forms.Label()
        Me.chkPayInFull = New System.Windows.Forms.CheckBox()
        Me.cboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.lblPaymentMethod = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.lblStep4Title = New System.Windows.Forms.Label()
        Me.gbLoyalty = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnApplyPoints = New System.Windows.Forms.Button()
        Me.numPointsToUse = New System.Windows.Forms.NumericUpDown()
        Me.lblPointsToUse = New System.Windows.Forms.Label()
        Me.lblAvailablePoints = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.gbBookingDetails = New System.Windows.Forms.GroupBox()
        Me.lblSelectedRoomsHeader = New System.Windows.Forms.Label()
        Me.gbPayment = New System.Windows.Forms.GroupBox()
        Me.lblRoomTypes = New System.Windows.Forms.Label()
        Me.flpNavigation.SuspendLayout()
        Me.pnlStep1.SuspendLayout()
        Me.gbRoomTypes.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRoomTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSelectedRooms.SuspendLayout()
        Me.pnlStep2.SuspendLayout()
        Me.gbGuestDetails.SuspendLayout()
        CType(Me.txtNumAdults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearchGuest.SuspendLayout()
        CType(Me.dgvGuestResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep3.SuspendLayout()
        CType(Me.dgvSelectedAddons, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAddonQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep4.SuspendLayout()
        Me.gbLoyalty.SuspendLayout()
        CType(Me.numPointsToUse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBookingDetails.SuspendLayout()
        Me.gbPayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(846, 3)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(91, 29)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Location = New System.Drawing.Point(556, 3)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(91, 29)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(459, 3)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 29)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCompleteBooking
        '
        Me.btnCompleteBooking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompleteBooking.Location = New System.Drawing.Point(653, 2)
        Me.btnCompleteBooking.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCompleteBooking.Name = "btnCompleteBooking"
        Me.btnCompleteBooking.Size = New System.Drawing.Size(187, 30)
        Me.btnCompleteBooking.TabIndex = 3
        Me.btnCompleteBooking.Text = "Complete Check-in"
        Me.btnCompleteBooking.UseVisualStyleBackColor = True
        '
        'flpNavigation
        '
        Me.flpNavigation.Controls.Add(Me.btnNext)
        Me.flpNavigation.Controls.Add(Me.btnCompleteBooking)
        Me.flpNavigation.Controls.Add(Me.btnBack)
        Me.flpNavigation.Controls.Add(Me.btnCancel)
        Me.flpNavigation.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flpNavigation.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpNavigation.Location = New System.Drawing.Point(0, 489)
        Me.flpNavigation.Margin = New System.Windows.Forms.Padding(4)
        Me.flpNavigation.Name = "flpNavigation"
        Me.flpNavigation.Size = New System.Drawing.Size(940, 42)
        Me.flpNavigation.TabIndex = 4
        '
        'pnlStep1
        '
        Me.pnlStep1.Controls.Add(Me.lblSelectedRoomsHeader)
        Me.pnlStep1.Controls.Add(Me.gbBookingDetails)
        Me.pnlStep1.Controls.Add(Me.txtDiscountID)
        Me.pnlStep1.Controls.Add(Me.lblDiscountID)
        Me.pnlStep1.Controls.Add(Me.cboDiscountType)
        Me.pnlStep1.Controls.Add(Me.lblDiscountType)
        Me.pnlStep1.Controls.Add(Me.btnApplyDiscount)
        Me.pnlStep1.Controls.Add(Me.gbRoomTypes)
        Me.pnlStep1.Controls.Add(Me.lblStep1Title)
        Me.pnlStep1.Controls.Add(Me.gbSelectedRooms)
        Me.pnlStep1.Location = New System.Drawing.Point(12, 11)
        Me.pnlStep1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(917, 476)
        Me.pnlStep1.TabIndex = 5
        '
        'txtDiscountID
        '
        Me.txtDiscountID.Location = New System.Drawing.Point(461, 450)
        Me.txtDiscountID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDiscountID.Name = "txtDiscountID"
        Me.txtDiscountID.Size = New System.Drawing.Size(293, 22)
        Me.txtDiscountID.TabIndex = 19
        '
        'lblDiscountID
        '
        Me.lblDiscountID.AutoSize = True
        Me.lblDiscountID.Location = New System.Drawing.Point(340, 452)
        Me.lblDiscountID.Name = "lblDiscountID"
        Me.lblDiscountID.Size = New System.Drawing.Size(84, 17)
        Me.lblDiscountID.TabIndex = 18
        Me.lblDiscountID.Text = "Discount ID:" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cboDiscountType
        '
        Me.cboDiscountType.FormattingEnabled = True
        Me.cboDiscountType.Location = New System.Drawing.Point(139, 450)
        Me.cboDiscountType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboDiscountType.Name = "cboDiscountType"
        Me.cboDiscountType.Size = New System.Drawing.Size(192, 24)
        Me.cboDiscountType.TabIndex = 17
        '
        'lblDiscountType
        '
        Me.lblDiscountType.AutoSize = True
        Me.lblDiscountType.Location = New System.Drawing.Point(21, 454)
        Me.lblDiscountType.Name = "lblDiscountType"
        Me.lblDiscountType.Size = New System.Drawing.Size(103, 17)
        Me.lblDiscountType.TabIndex = 16
        Me.lblDiscountType.Text = "Discount Type:" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnApplyDiscount
        '
        Me.btnApplyDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApplyDiscount.Location = New System.Drawing.Point(759, 446)
        Me.btnApplyDiscount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnApplyDiscount.Name = "btnApplyDiscount"
        Me.btnApplyDiscount.Size = New System.Drawing.Size(116, 25)
        Me.btnApplyDiscount.TabIndex = 15
        Me.btnApplyDiscount.Text = "Apply Discount"
        Me.btnApplyDiscount.UseVisualStyleBackColor = True
        '
        'lblCheckoutDate
        '
        Me.lblCheckoutDate.AutoSize = True
        Me.lblCheckoutDate.Location = New System.Drawing.Point(467, 20)
        Me.lblCheckoutDate.Name = "lblCheckoutDate"
        Me.lblCheckoutDate.Size = New System.Drawing.Size(110, 17)
        Me.lblCheckoutDate.TabIndex = 9
        Me.lblCheckoutDate.Text = "Check-out Date:"
        '
        'dtpCheckout
        '
        Me.dtpCheckout.Location = New System.Drawing.Point(583, 20)
        Me.dtpCheckout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpCheckout.Name = "dtpCheckout"
        Me.dtpCheckout.Size = New System.Drawing.Size(178, 22)
        Me.dtpCheckout.TabIndex = 10
        '
        'lblCheckinDate
        '
        Me.lblCheckinDate.AutoSize = True
        Me.lblCheckinDate.Location = New System.Drawing.Point(24, 20)
        Me.lblCheckinDate.Name = "lblCheckinDate"
        Me.lblCheckinDate.Size = New System.Drawing.Size(101, 34)
        Me.lblCheckinDate.TabIndex = 5
        Me.lblCheckinDate.Text = "Check-in Date:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbRoomTypes
        '
        Me.gbRoomTypes.Controls.Add(Me.lblRoomTypes)
        Me.gbRoomTypes.Controls.Add(Me.btnAddRoom)
        Me.gbRoomTypes.Controls.Add(Me.numQuantity)
        Me.gbRoomTypes.Controls.Add(Me.lblQuantity)
        Me.gbRoomTypes.Controls.Add(Me.dgvRoomTypes)
        Me.gbRoomTypes.Location = New System.Drawing.Point(11, 38)
        Me.gbRoomTypes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbRoomTypes.Name = "gbRoomTypes"
        Me.gbRoomTypes.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbRoomTypes.Size = New System.Drawing.Size(437, 336)
        Me.gbRoomTypes.TabIndex = 3
        Me.gbRoomTypes.TabStop = False
        '
        'btnAddRoom
        '
        Me.btnAddRoom.Location = New System.Drawing.Point(267, 277)
        Me.btnAddRoom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddRoom.Name = "btnAddRoom"
        Me.btnAddRoom.Size = New System.Drawing.Size(149, 27)
        Me.btnAddRoom.TabIndex = 6
        Me.btnAddRoom.Text = "Add to Booking ->"
        Me.btnAddRoom.UseVisualStyleBackColor = True
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(85, 278)
        Me.numQuantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(64, 22)
        Me.numQuantity.TabIndex = 5
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(11, 278)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(65, 34)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Text = "Quantity:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvRoomTypes
        '
        Me.dgvRoomTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoomTypes.Location = New System.Drawing.Point(6, 24)
        Me.dgvRoomTypes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvRoomTypes.Name = "dgvRoomTypes"
        Me.dgvRoomTypes.RowHeadersWidth = 62
        Me.dgvRoomTypes.RowTemplate.Height = 28
        Me.dgvRoomTypes.Size = New System.Drawing.Size(425, 240)
        Me.dgvRoomTypes.TabIndex = 0
        '
        'dtpCheckin
        '
        Me.dtpCheckin.Location = New System.Drawing.Point(141, 20)
        Me.dtpCheckin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpCheckin.Name = "dtpCheckin"
        Me.dtpCheckin.Size = New System.Drawing.Size(178, 22)
        Me.dtpCheckin.TabIndex = 8
        '
        'lblStep1Title
        '
        Me.lblStep1Title.AutoSize = True
        Me.lblStep1Title.Location = New System.Drawing.Point(11, 10)
        Me.lblStep1Title.Name = "lblStep1Title"
        Me.lblStep1Title.Size = New System.Drawing.Size(144, 34)
        Me.lblStep1Title.TabIndex = 0
        Me.lblStep1Title.Text = "Step 1: Select Rooms" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbSelectedRooms
        '
        Me.gbSelectedRooms.Controls.Add(Me.btnRemoveRoom)
        Me.gbSelectedRooms.Controls.Add(Me.lbSelectedRooms)
        Me.gbSelectedRooms.Location = New System.Drawing.Point(469, 38)
        Me.gbSelectedRooms.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSelectedRooms.Name = "gbSelectedRooms"
        Me.gbSelectedRooms.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSelectedRooms.Size = New System.Drawing.Size(437, 336)
        Me.gbSelectedRooms.TabIndex = 4
        Me.gbSelectedRooms.TabStop = False
        '
        'btnRemoveRoom
        '
        Me.btnRemoveRoom.Location = New System.Drawing.Point(6, 302)
        Me.btnRemoveRoom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemoveRoom.Name = "btnRemoveRoom"
        Me.btnRemoveRoom.Size = New System.Drawing.Size(149, 27)
        Me.btnRemoveRoom.TabIndex = 7
        Me.btnRemoveRoom.Text = "<- Remove Selected" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnRemoveRoom.UseVisualStyleBackColor = True
        '
        'lbSelectedRooms
        '
        Me.lbSelectedRooms.FormattingEnabled = True
        Me.lbSelectedRooms.ItemHeight = 16
        Me.lbSelectedRooms.Location = New System.Drawing.Point(6, 24)
        Me.lbSelectedRooms.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lbSelectedRooms.Name = "lbSelectedRooms"
        Me.lbSelectedRooms.Size = New System.Drawing.Size(425, 260)
        Me.lbSelectedRooms.TabIndex = 0
        '
        'pnlStep2
        '
        Me.pnlStep2.Controls.Add(Me.lblStep2Title)
        Me.pnlStep2.Controls.Add(Me.gbGuestDetails)
        Me.pnlStep2.Controls.Add(Me.gbSearchGuest)
        Me.pnlStep2.Location = New System.Drawing.Point(12, 11)
        Me.pnlStep2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(917, 461)
        Me.pnlStep2.TabIndex = 6
        Me.pnlStep2.Visible = False
        '
        'lblStep2Title
        '
        Me.lblStep2Title.AutoSize = True
        Me.lblStep2Title.Location = New System.Drawing.Point(11, 10)
        Me.lblStep2Title.Name = "lblStep2Title"
        Me.lblStep2Title.Size = New System.Drawing.Size(207, 17)
        Me.lblStep2Title.TabIndex = 0
        Me.lblStep2Title.Text = "Step 2: Enter Guest Information"
        '
        'gbGuestDetails
        '
        Me.gbGuestDetails.Controls.Add(Me.txtNumAdults)
        Me.gbGuestDetails.Controls.Add(Me.lblNumAdults)
        Me.gbGuestDetails.Controls.Add(Me.txtPhone)
        Me.gbGuestDetails.Controls.Add(Me.lblPhone)
        Me.gbGuestDetails.Controls.Add(Me.txtEmail)
        Me.gbGuestDetails.Controls.Add(Me.lblEmail)
        Me.gbGuestDetails.Controls.Add(Me.txtLastName)
        Me.gbGuestDetails.Controls.Add(Me.lblLastName)
        Me.gbGuestDetails.Controls.Add(Me.txtFirstName)
        Me.gbGuestDetails.Controls.Add(Me.lblFirstName)
        Me.gbGuestDetails.Location = New System.Drawing.Point(11, 240)
        Me.gbGuestDetails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbGuestDetails.Name = "gbGuestDetails"
        Me.gbGuestDetails.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbGuestDetails.Size = New System.Drawing.Size(896, 173)
        Me.gbGuestDetails.TabIndex = 10
        Me.gbGuestDetails.TabStop = False
        Me.gbGuestDetails.Text = "Guest Details" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtNumAdults
        '
        Me.txtNumAdults.Location = New System.Drawing.Point(144, 96)
        Me.txtNumAdults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNumAdults.Name = "txtNumAdults"
        Me.txtNumAdults.Size = New System.Drawing.Size(283, 22)
        Me.txtNumAdults.TabIndex = 14
        '
        'lblNumAdults
        '
        Me.lblNumAdults.AutoSize = True
        Me.lblNumAdults.Location = New System.Drawing.Point(11, 96)
        Me.lblNumAdults.Name = "lblNumAdults"
        Me.lblNumAdults.Size = New System.Drawing.Size(121, 17)
        Me.lblNumAdults.TabIndex = 13
        Me.lblNumAdults.Text = "Number of Adults:"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(565, 67)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(299, 22)
        Me.txtPhone.TabIndex = 12
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(448, 67)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(107, 34)
        Me.lblPhone.TabIndex = 11
        Me.lblPhone.Text = "Phone Number:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(128, 67)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(299, 22)
        Me.txtEmail.TabIndex = 10
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(11, 67)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(46, 34)
        Me.lblEmail.TabIndex = 9
        Me.lblEmail.Text = "Email:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(565, 29)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(299, 22)
        Me.txtLastName.TabIndex = 8
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(448, 29)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(80, 34)
        Me.lblLastName.TabIndex = 7
        Me.lblLastName.Text = "Last Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(128, 29)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(299, 22)
        Me.txtFirstName.TabIndex = 6
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(11, 29)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(80, 17)
        Me.lblFirstName.TabIndex = 5
        Me.lblFirstName.Text = "First Name:"
        '
        'gbSearchGuest
        '
        Me.gbSearchGuest.Controls.Add(Me.lblGuestTierInfo)
        Me.gbSearchGuest.Controls.Add(Me.dgvGuestResults)
        Me.gbSearchGuest.Controls.Add(Me.btnSearchGuest)
        Me.gbSearchGuest.Controls.Add(Me.txtSearchGuest)
        Me.gbSearchGuest.Controls.Add(Me.lblSearch)
        Me.gbSearchGuest.Location = New System.Drawing.Point(11, 38)
        Me.gbSearchGuest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSearchGuest.Name = "gbSearchGuest"
        Me.gbSearchGuest.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSearchGuest.Size = New System.Drawing.Size(896, 192)
        Me.gbSearchGuest.TabIndex = 9
        Me.gbSearchGuest.TabStop = False
        Me.gbSearchGuest.Text = "Search for Returning Guest"
        '
        'lblGuestTierInfo
        '
        Me.lblGuestTierInfo.AutoSize = True
        Me.lblGuestTierInfo.Location = New System.Drawing.Point(11, 163)
        Me.lblGuestTierInfo.Name = "lblGuestTierInfo"
        Me.lblGuestTierInfo.Size = New System.Drawing.Size(128, 17)
        Me.lblGuestTierInfo.TabIndex = 4
        Me.lblGuestTierInfo.Text = "Loyalty Status: N/A"
        Me.lblGuestTierInfo.Visible = False
        '
        'dgvGuestResults
        '
        Me.dgvGuestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuestResults.Location = New System.Drawing.Point(11, 67)
        Me.dgvGuestResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvGuestResults.Name = "dgvGuestResults"
        Me.dgvGuestResults.RowHeadersWidth = 62
        Me.dgvGuestResults.RowTemplate.Height = 28
        Me.dgvGuestResults.Size = New System.Drawing.Size(875, 86)
        Me.dgvGuestResults.TabIndex = 3
        '
        'btnSearchGuest
        '
        Me.btnSearchGuest.Location = New System.Drawing.Point(629, 27)
        Me.btnSearchGuest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearchGuest.Name = "btnSearchGuest"
        Me.btnSearchGuest.Size = New System.Drawing.Size(107, 27)
        Me.btnSearchGuest.TabIndex = 2
        Me.btnSearchGuest.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSearchGuest.UseVisualStyleBackColor = True
        '
        'txtSearchGuest
        '
        Me.txtSearchGuest.Location = New System.Drawing.Point(192, 29)
        Me.txtSearchGuest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSearchGuest.Name = "txtSearchGuest"
        Me.txtSearchGuest.Size = New System.Drawing.Size(427, 22)
        Me.txtSearchGuest.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(11, 29)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(172, 34)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search by Name or Email:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlStep3
        '
        Me.pnlStep3.Controls.Add(Me.btnRemoveSelectedAddon)
        Me.pnlStep3.Controls.Add(Me.dgvSelectedAddons)
        Me.pnlStep3.Controls.Add(Me.btnAddSelectedAddon)
        Me.pnlStep3.Controls.Add(Me.numAddonQuantity)
        Me.pnlStep3.Controls.Add(Me.lstAvailableAddons)
        Me.pnlStep3.Controls.Add(Me.btnSearchAddons)
        Me.pnlStep3.Controls.Add(Me.txtSearchAddons)
        Me.pnlStep3.Controls.Add(Me.lblSearchAddons)
        Me.pnlStep3.Controls.Add(Me.lblStep3Title)
        Me.pnlStep3.Controls.Add(Me.Label1)
        Me.pnlStep3.Controls.Add(Me.lblAddonQuantity)
        Me.pnlStep3.Location = New System.Drawing.Point(12, 11)
        Me.pnlStep3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(917, 461)
        Me.pnlStep3.TabIndex = 7
        Me.pnlStep3.Visible = False
        '
        'btnRemoveSelectedAddon
        '
        Me.btnRemoveSelectedAddon.Location = New System.Drawing.Point(424, 410)
        Me.btnRemoveSelectedAddon.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemoveSelectedAddon.Name = "btnRemoveSelectedAddon"
        Me.btnRemoveSelectedAddon.Size = New System.Drawing.Size(100, 25)
        Me.btnRemoveSelectedAddon.TabIndex = 11
        Me.btnRemoveSelectedAddon.Text = "<- Remove" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Export to Sheets" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnRemoveSelectedAddon.UseVisualStyleBackColor = True
        '
        'dgvSelectedAddons
        '
        Me.dgvSelectedAddons.AllowUserToAddRows = False
        Me.dgvSelectedAddons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectedAddons.Location = New System.Drawing.Point(424, 67)
        Me.dgvSelectedAddons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvSelectedAddons.Name = "dgvSelectedAddons"
        Me.dgvSelectedAddons.ReadOnly = True
        Me.dgvSelectedAddons.RowHeadersWidth = 51
        Me.dgvSelectedAddons.RowTemplate.Height = 28
        Me.dgvSelectedAddons.Size = New System.Drawing.Size(491, 338)
        Me.dgvSelectedAddons.TabIndex = 10
        '
        'btnAddSelectedAddon
        '
        Me.btnAddSelectedAddon.Location = New System.Drawing.Point(277, 410)
        Me.btnAddSelectedAddon.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddSelectedAddon.Name = "btnAddSelectedAddon"
        Me.btnAddSelectedAddon.Size = New System.Drawing.Size(100, 25)
        Me.btnAddSelectedAddon.TabIndex = 9
        Me.btnAddSelectedAddon.Text = "Add ->" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAddSelectedAddon.UseVisualStyleBackColor = True
        '
        'numAddonQuantity
        '
        Me.numAddonQuantity.Location = New System.Drawing.Point(86, 414)
        Me.numAddonQuantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numAddonQuantity.Name = "numAddonQuantity"
        Me.numAddonQuantity.Size = New System.Drawing.Size(107, 22)
        Me.numAddonQuantity.TabIndex = 8
        '
        'lstAvailableAddons
        '
        Me.lstAvailableAddons.FormattingEnabled = True
        Me.lstAvailableAddons.ItemHeight = 16
        Me.lstAvailableAddons.Location = New System.Drawing.Point(12, 66)
        Me.lstAvailableAddons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lstAvailableAddons.Name = "lstAvailableAddons"
        Me.lstAvailableAddons.Size = New System.Drawing.Size(363, 340)
        Me.lstAvailableAddons.TabIndex = 5
        '
        'btnSearchAddons
        '
        Me.btnSearchAddons.Location = New System.Drawing.Point(828, 6)
        Me.btnSearchAddons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearchAddons.Name = "btnSearchAddons"
        Me.btnSearchAddons.Size = New System.Drawing.Size(91, 27)
        Me.btnSearchAddons.TabIndex = 4
        Me.btnSearchAddons.Text = "Search"
        Me.btnSearchAddons.UseVisualStyleBackColor = True
        '
        'txtSearchAddons
        '
        Me.txtSearchAddons.Location = New System.Drawing.Point(620, 13)
        Me.txtSearchAddons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSearchAddons.Name = "txtSearchAddons"
        Me.txtSearchAddons.Size = New System.Drawing.Size(202, 22)
        Me.txtSearchAddons.TabIndex = 3
        '
        'lblSearchAddons
        '
        Me.lblSearchAddons.AutoSize = True
        Me.lblSearchAddons.Location = New System.Drawing.Point(558, 13)
        Me.lblSearchAddons.Name = "lblSearchAddons"
        Me.lblSearchAddons.Size = New System.Drawing.Size(57, 34)
        Me.lblSearchAddons.TabIndex = 2
        Me.lblSearchAddons.Text = "Search:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblStep3Title
        '
        Me.lblStep3Title.AutoSize = True
        Me.lblStep3Title.Location = New System.Drawing.Point(11, 10)
        Me.lblStep3Title.Name = "lblStep3Title"
        Me.lblStep3Title.Size = New System.Drawing.Size(215, 34)
        Me.lblStep3Title.TabIndex = 0
        Me.lblStep3Title.Text = "Step 3: Select Addons (Optional)" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 34)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Available Addons:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblAddonQuantity
        '
        Me.lblAddonQuantity.AutoSize = True
        Me.lblAddonQuantity.Location = New System.Drawing.Point(13, 415)
        Me.lblAddonQuantity.Name = "lblAddonQuantity"
        Me.lblAddonQuantity.Size = New System.Drawing.Size(65, 34)
        Me.lblAddonQuantity.TabIndex = 7
        Me.lblAddonQuantity.Text = "Quantity:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlStep4
        '
        Me.pnlStep4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStep4.Controls.Add(Me.gbPayment)
        Me.pnlStep4.Controls.Add(Me.Label2)
        Me.pnlStep4.Controls.Add(Me.txtPaymentAmount)
        Me.pnlStep4.Controls.Add(Me.lblDownPayment)
        Me.pnlStep4.Controls.Add(Me.chkPayInFull)
        Me.pnlStep4.Controls.Add(Me.cboPaymentMethod)
        Me.pnlStep4.Controls.Add(Me.lblPaymentMethod)
        Me.pnlStep4.Controls.Add(Me.lblSummary)
        Me.pnlStep4.Controls.Add(Me.lblStep4Title)
        Me.pnlStep4.Controls.Add(Me.gbLoyalty)
        Me.pnlStep4.Location = New System.Drawing.Point(12, 11)
        Me.pnlStep4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlStep4.Name = "pnlStep4"
        Me.pnlStep4.Size = New System.Drawing.Size(917, 477)
        Me.pnlStep4.TabIndex = 8
        Me.pnlStep4.Visible = False
        '
        'lblChangeDue
        '
        Me.lblChangeDue.AutoSize = True
        Me.lblChangeDue.Location = New System.Drawing.Point(112, 59)
        Me.lblChangeDue.Name = "lblChangeDue"
        Me.lblChangeDue.Size = New System.Drawing.Size(36, 17)
        Me.lblChangeDue.TabIndex = 25
        Me.lblChangeDue.Text = "0.00"
        Me.lblChangeDue.Visible = False
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Location = New System.Drawing.Point(-1, 59)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(74, 17)
        Me.lblChange.TabIndex = 24
        Me.lblChange.Text = "Change: ₱"
        Me.lblChange.Visible = False
        '
        'txtCashTendered
        '
        Me.txtCashTendered.Location = New System.Drawing.Point(115, 28)
        Me.txtCashTendered.Name = "txtCashTendered"
        Me.txtCashTendered.Size = New System.Drawing.Size(100, 22)
        Me.txtCashTendered.TabIndex = 23
        Me.txtCashTendered.Visible = False
        '
        'lblCashTendered
        '
        Me.lblCashTendered.AutoSize = True
        Me.lblCashTendered.Location = New System.Drawing.Point(-1, 31)
        Me.lblCashTendered.Name = "lblCashTendered"
        Me.lblCashTendered.Size = New System.Drawing.Size(110, 17)
        Me.lblCashTendered.TabIndex = 22
        Me.lblCashTendered.Text = "Cash Tendered:"
        Me.lblCashTendered.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(305, 331)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Down Payment Amount:"
        Me.Label2.Visible = False
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.Location = New System.Drawing.Point(475, 328)
        Me.txtPaymentAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(202, 22)
        Me.txtPaymentAmount.TabIndex = 9
        Me.txtPaymentAmount.Text = "0.00"
        '
        'lblDownPayment
        '
        Me.lblDownPayment.AutoSize = True
        Me.lblDownPayment.Location = New System.Drawing.Point(471, 307)
        Me.lblDownPayment.Name = "lblDownPayment"
        Me.lblDownPayment.Size = New System.Drawing.Size(119, 17)
        Me.lblDownPayment.TabIndex = 8
        Me.lblDownPayment.Text = "Payment Amount:"
        Me.lblDownPayment.Visible = False
        '
        'chkPayInFull
        '
        Me.chkPayInFull.AutoSize = True
        Me.chkPayInFull.Location = New System.Drawing.Point(473, 278)
        Me.chkPayInFull.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkPayInFull.Name = "chkPayInFull"
        Me.chkPayInFull.Size = New System.Drawing.Size(162, 21)
        Me.chkPayInFull.TabIndex = 7
        Me.chkPayInFull.Text = "Make Down Payment"
        Me.chkPayInFull.UseVisualStyleBackColor = True
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.FormattingEnabled = True
        Me.cboPaymentMethod.Items.AddRange(New Object() {"Cash", "Credit Card", "Bank Transfer", "Online Payment", "Other"})
        Me.cboPaymentMethod.Location = New System.Drawing.Point(683, 326)
        Me.cboPaymentMethod.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.Size = New System.Drawing.Size(204, 24)
        Me.cboPaymentMethod.TabIndex = 4
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.AutoSize = True
        Me.lblPaymentMethod.Location = New System.Drawing.Point(683, 304)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(118, 34)
        Me.lblPaymentMethod.TabIndex = 3
        Me.lblPaymentMethod.Text = "Payment Method:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Location = New System.Drawing.Point(11, 38)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(67, 17)
        Me.lblSummary.TabIndex = 1
        Me.lblSummary.Text = "Summary"
        '
        'lblStep4Title
        '
        Me.lblStep4Title.AutoSize = True
        Me.lblStep4Title.Location = New System.Drawing.Point(11, 10)
        Me.lblStep4Title.Name = "lblStep4Title"
        Me.lblStep4Title.Size = New System.Drawing.Size(199, 34)
        Me.lblStep4Title.TabIndex = 0
        Me.lblStep4Title.Text = "Step 3: Confirmation & Payment" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbLoyalty
        '
        Me.gbLoyalty.Controls.Add(Me.lblTotal)
        Me.gbLoyalty.Controls.Add(Me.btnApplyPoints)
        Me.gbLoyalty.Controls.Add(Me.numPointsToUse)
        Me.gbLoyalty.Controls.Add(Me.lblPointsToUse)
        Me.gbLoyalty.Controls.Add(Me.lblAvailablePoints)
        Me.gbLoyalty.Location = New System.Drawing.Point(469, 38)
        Me.gbLoyalty.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLoyalty.Name = "gbLoyalty"
        Me.gbLoyalty.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLoyalty.Size = New System.Drawing.Size(437, 234)
        Me.gbLoyalty.TabIndex = 2
        Me.gbLoyalty.TabStop = False
        Me.gbLoyalty.Text = "Use Loyalty Points" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(11, 99)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(137, 34)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.Text = "TOTAL: PHP 0.00" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnApplyPoints
        '
        Me.btnApplyPoints.Location = New System.Drawing.Point(256, 66)
        Me.btnApplyPoints.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnApplyPoints.Name = "btnApplyPoints"
        Me.btnApplyPoints.Size = New System.Drawing.Size(160, 27)
        Me.btnApplyPoints.TabIndex = 3
        Me.btnApplyPoints.Text = "Apply Discount" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnApplyPoints.UseVisualStyleBackColor = True
        '
        'numPointsToUse
        '
        Me.numPointsToUse.Location = New System.Drawing.Point(128, 67)
        Me.numPointsToUse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPointsToUse.Name = "numPointsToUse"
        Me.numPointsToUse.Size = New System.Drawing.Size(107, 22)
        Me.numPointsToUse.TabIndex = 5
        '
        'lblPointsToUse
        '
        Me.lblPointsToUse.AutoSize = True
        Me.lblPointsToUse.Location = New System.Drawing.Point(11, 67)
        Me.lblPointsToUse.Name = "lblPointsToUse"
        Me.lblPointsToUse.Size = New System.Drawing.Size(96, 34)
        Me.lblPointsToUse.TabIndex = 4
        Me.lblPointsToUse.Text = "Points to Use:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblAvailablePoints
        '
        Me.lblAvailablePoints.AutoSize = True
        Me.lblAvailablePoints.Location = New System.Drawing.Point(11, 29)
        Me.lblAvailablePoints.Name = "lblAvailablePoints"
        Me.lblAvailablePoints.Size = New System.Drawing.Size(198, 34)
        Me.lblAvailablePoints.TabIndex = 3
        Me.lblAvailablePoints.Text = "Available Points: 0 (PHP 0.00)" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbBookingDetails
        '
        Me.gbBookingDetails.Controls.Add(Me.dtpCheckin)
        Me.gbBookingDetails.Controls.Add(Me.lblCheckinDate)
        Me.gbBookingDetails.Controls.Add(Me.dtpCheckout)
        Me.gbBookingDetails.Controls.Add(Me.lblCheckoutDate)
        Me.gbBookingDetails.Location = New System.Drawing.Point(14, 379)
        Me.gbBookingDetails.Name = "gbBookingDetails"
        Me.gbBookingDetails.Size = New System.Drawing.Size(842, 64)
        Me.gbBookingDetails.TabIndex = 20
        Me.gbBookingDetails.TabStop = False
        Me.gbBookingDetails.Text = "Booking Details"
        '
        'lblSelectedRoomsHeader
        '
        Me.lblSelectedRoomsHeader.AutoSize = True
        Me.lblSelectedRoomsHeader.Location = New System.Drawing.Point(466, 30)
        Me.lblSelectedRoomsHeader.Name = "lblSelectedRoomsHeader"
        Me.lblSelectedRoomsHeader.Size = New System.Drawing.Size(217, 17)
        Me.lblSelectedRoomsHeader.TabIndex = 21
        Me.lblSelectedRoomsHeader.Text = "Selected Rooms for this Booking:"
        '
        'gbPayment
        '
        Me.gbPayment.Controls.Add(Me.txtCashTendered)
        Me.gbPayment.Controls.Add(Me.lblChangeDue)
        Me.gbPayment.Controls.Add(Me.lblCashTendered)
        Me.gbPayment.Controls.Add(Me.lblChange)
        Me.gbPayment.Location = New System.Drawing.Point(473, 360)
        Me.gbPayment.Name = "gbPayment"
        Me.gbPayment.Size = New System.Drawing.Size(260, 85)
        Me.gbPayment.TabIndex = 26
        Me.gbPayment.TabStop = False
        Me.gbPayment.Text = "Payment"
        '
        'lblRoomTypes
        '
        Me.lblRoomTypes.AutoSize = True
        Me.lblRoomTypes.Location = New System.Drawing.Point(6, 4)
        Me.lblRoomTypes.Name = "lblRoomTypes"
        Me.lblRoomTypes.Size = New System.Drawing.Size(149, 17)
        Me.lblRoomTypes.TabIndex = 22
        Me.lblRoomTypes.Text = "Available Room Types"
        '
        'frmNewReservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 531)
        Me.Controls.Add(Me.flpNavigation)
        Me.Controls.Add(Me.pnlStep4)
        Me.Controls.Add(Me.pnlStep3)
        Me.Controls.Add(Me.pnlStep2)
        Me.Controls.Add(Me.pnlStep1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewReservation"
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
        CType(Me.txtNumAdults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearchGuest.ResumeLayout(False)
        Me.gbSearchGuest.PerformLayout()
        CType(Me.dgvGuestResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep3.ResumeLayout(False)
        Me.pnlStep3.PerformLayout()
        CType(Me.dgvSelectedAddons, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAddonQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep4.ResumeLayout(False)
        Me.pnlStep4.PerformLayout()
        Me.gbLoyalty.ResumeLayout(False)
        Me.gbLoyalty.PerformLayout()
        CType(Me.numPointsToUse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBookingDetails.ResumeLayout(False)
        Me.gbBookingDetails.PerformLayout()
        Me.gbPayment.ResumeLayout(False)
        Me.gbPayment.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnNext As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCompleteBooking As Button
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
    Friend WithEvents lblGuestTierInfo As Label
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
    Friend WithEvents dgvSelectedAddons As DataGridView
    Friend WithEvents numAddonQuantity As NumericUpDown
    Friend WithEvents lstAvailableAddons As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAddonQuantity As Label
    Friend WithEvents txtNumAdults As NumericUpDown
    Friend WithEvents lblNumAdults As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPaymentAmount As TextBox
    Friend WithEvents lblDownPayment As Label
    Friend WithEvents chkPayInFull As CheckBox
    Friend WithEvents txtDiscountID As TextBox
    Friend WithEvents lblDiscountID As Label
    Friend WithEvents cboDiscountType As ComboBox
    Friend WithEvents lblDiscountType As Label
    Friend WithEvents btnApplyDiscount As Button
    Friend WithEvents btnRemoveSelectedAddon As Button
    Friend WithEvents btnAddSelectedAddon As Button
    Friend WithEvents lblChangeDue As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents txtCashTendered As TextBox
    Friend WithEvents lblCashTendered As Label
    Friend WithEvents lblSelectedRoomsHeader As Label
    Friend WithEvents gbBookingDetails As GroupBox
    Friend WithEvents gbPayment As GroupBox
    Friend WithEvents lblRoomTypes As Label
End Class
