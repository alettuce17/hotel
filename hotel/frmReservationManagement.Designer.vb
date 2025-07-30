<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservationManagement
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
        Me.tcReservations = New System.Windows.Forms.TabControl()
        Me.tpUpcoming = New System.Windows.Forms.TabPage()
        Me.pnlPagingUpcoming = New System.Windows.Forms.Panel()
        Me.lblPageInfoUpcoming = New System.Windows.Forms.Label()
        Me.btnLastUpcoming = New System.Windows.Forms.Button()
        Me.btnPrevUpcoming = New System.Windows.Forms.Button()
        Me.btnNextUpcoming = New System.Windows.Forms.Button()
        Me.btnFirstUpcoming = New System.Windows.Forms.Button()
        Me.btnSearchUpcoming = New System.Windows.Forms.Button()
        Me.txtSearchUpcoming = New System.Windows.Forms.TextBox()
        Me.lblSearchUpcoming = New System.Windows.Forms.Label()
        Me.dgvUpcoming = New System.Windows.Forms.DataGridView()
        Me.tpInHouse = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPageInfoInHouse = New System.Windows.Forms.Label()
        Me.btnLastInHouse = New System.Windows.Forms.Button()
        Me.btnPrevInHouse = New System.Windows.Forms.Button()
        Me.btnNextInHouse = New System.Windows.Forms.Button()
        Me.btnFirstInHouse = New System.Windows.Forms.Button()
        Me.btnSearchInHouse = New System.Windows.Forms.Button()
        Me.txtSearchInHouse = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvInHouse = New System.Windows.Forms.DataGridView()
        Me.tpDeparted = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPageInfoDeparted = New System.Windows.Forms.Label()
        Me.btnLastDeparted = New System.Windows.Forms.Button()
        Me.btnPrevDeparted = New System.Windows.Forms.Button()
        Me.btnNextDeparted = New System.Windows.Forms.Button()
        Me.btnFirstDeparted = New System.Windows.Forms.Button()
        Me.btnSearchDeparted = New System.Windows.Forms.Button()
        Me.txtSearchDeparted = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvDeparted = New System.Windows.Forms.DataGridView()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnViewEdit = New System.Windows.Forms.Button()
        Me.btnNewReservation = New System.Windows.Forms.Button()
        Me.btnAddCharge = New System.Windows.Forms.Button()
        Me.btnCheckout = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCheckIn = New System.Windows.Forms.Button()
        Me.tcReservations.SuspendLayout()
        Me.tpUpcoming.SuspendLayout()
        Me.pnlPagingUpcoming.SuspendLayout()
        CType(Me.dgvUpcoming, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInHouse.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvInHouse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDeparted.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvDeparted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcReservations
        '
        Me.tcReservations.Controls.Add(Me.tpUpcoming)
        Me.tcReservations.Controls.Add(Me.tpInHouse)
        Me.tcReservations.Controls.Add(Me.tpDeparted)
        Me.tcReservations.Location = New System.Drawing.Point(12, 12)
        Me.tcReservations.Name = "tcReservations"
        Me.tcReservations.SelectedIndex = 0
        Me.tcReservations.Size = New System.Drawing.Size(810, 650)
        Me.tcReservations.TabIndex = 0
        '
        'tpUpcoming
        '
        Me.tpUpcoming.Controls.Add(Me.pnlPagingUpcoming)
        Me.tpUpcoming.Controls.Add(Me.dgvUpcoming)
        Me.tpUpcoming.Location = New System.Drawing.Point(4, 29)
        Me.tpUpcoming.Name = "tpUpcoming"
        Me.tpUpcoming.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUpcoming.Size = New System.Drawing.Size(802, 617)
        Me.tpUpcoming.TabIndex = 0
        Me.tpUpcoming.Text = "Upcoming Arrivals" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tpUpcoming.UseVisualStyleBackColor = True
        '
        'pnlPagingUpcoming
        '
        Me.pnlPagingUpcoming.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPagingUpcoming.Controls.Add(Me.lblPageInfoUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnLastUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnPrevUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnNextUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnFirstUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnSearchUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.txtSearchUpcoming)
        Me.pnlPagingUpcoming.Controls.Add(Me.lblSearchUpcoming)
        Me.pnlPagingUpcoming.Location = New System.Drawing.Point(6, 543)
        Me.pnlPagingUpcoming.Name = "pnlPagingUpcoming"
        Me.pnlPagingUpcoming.Size = New System.Drawing.Size(790, 78)
        Me.pnlPagingUpcoming.TabIndex = 1
        '
        'lblPageInfoUpcoming
        '
        Me.lblPageInfoUpcoming.AutoSize = True
        Me.lblPageInfoUpcoming.Location = New System.Drawing.Point(369, 41)
        Me.lblPageInfoUpcoming.Name = "lblPageInfoUpcoming"
        Me.lblPageInfoUpcoming.Size = New System.Drawing.Size(94, 40)
        Me.lblPageInfoUpcoming.TabIndex = 9
        Me.lblPageInfoUpcoming.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLastUpcoming
        '
        Me.btnLastUpcoming.Location = New System.Drawing.Point(550, 35)
        Me.btnLastUpcoming.Name = "btnLastUpcoming"
        Me.btnLastUpcoming.Size = New System.Drawing.Size(75, 28)
        Me.btnLastUpcoming.TabIndex = 8
        Me.btnLastUpcoming.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLastUpcoming.UseVisualStyleBackColor = True
        '
        'btnPrevUpcoming
        '
        Me.btnPrevUpcoming.Location = New System.Drawing.Point(278, 36)
        Me.btnPrevUpcoming.Name = "btnPrevUpcoming"
        Me.btnPrevUpcoming.Size = New System.Drawing.Size(85, 28)
        Me.btnPrevUpcoming.TabIndex = 7
        Me.btnPrevUpcoming.Text = "< "
        Me.btnPrevUpcoming.UseVisualStyleBackColor = True
        '
        'btnNextUpcoming
        '
        Me.btnNextUpcoming.Location = New System.Drawing.Point(469, 35)
        Me.btnNextUpcoming.Name = "btnNextUpcoming"
        Me.btnNextUpcoming.Size = New System.Drawing.Size(75, 28)
        Me.btnNextUpcoming.TabIndex = 6
        Me.btnNextUpcoming.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNextUpcoming.UseVisualStyleBackColor = True
        '
        'btnFirstUpcoming
        '
        Me.btnFirstUpcoming.Location = New System.Drawing.Point(197, 36)
        Me.btnFirstUpcoming.Name = "btnFirstUpcoming"
        Me.btnFirstUpcoming.Size = New System.Drawing.Size(75, 28)
        Me.btnFirstUpcoming.TabIndex = 5
        Me.btnFirstUpcoming.Text = "<< "
        Me.btnFirstUpcoming.UseVisualStyleBackColor = True
        '
        'btnSearchUpcoming
        '
        Me.btnSearchUpcoming.Location = New System.Drawing.Point(655, 3)
        Me.btnSearchUpcoming.Name = "btnSearchUpcoming"
        Me.btnSearchUpcoming.Size = New System.Drawing.Size(132, 28)
        Me.btnSearchUpcoming.TabIndex = 4
        Me.btnSearchUpcoming.Text = "Search"
        Me.btnSearchUpcoming.UseVisualStyleBackColor = True
        '
        'txtSearchUpcoming
        '
        Me.txtSearchUpcoming.Location = New System.Drawing.Point(224, 3)
        Me.txtSearchUpcoming.Name = "txtSearchUpcoming"
        Me.txtSearchUpcoming.Size = New System.Drawing.Size(425, 26)
        Me.txtSearchUpcoming.TabIndex = 3
        '
        'lblSearchUpcoming
        '
        Me.lblSearchUpcoming.AutoSize = True
        Me.lblSearchUpcoming.Location = New System.Drawing.Point(10, 5)
        Me.lblSearchUpcoming.Name = "lblSearchUpcoming"
        Me.lblSearchUpcoming.Size = New System.Drawing.Size(208, 40)
        Me.lblSearchUpcoming.TabIndex = 2
        Me.lblSearchUpcoming.Text = "Search by Guest or Room:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvUpcoming
        '
        Me.dgvUpcoming.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUpcoming.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUpcoming.Location = New System.Drawing.Point(6, 6)
        Me.dgvUpcoming.Name = "dgvUpcoming"
        Me.dgvUpcoming.RowHeadersWidth = 51
        Me.dgvUpcoming.RowTemplate.Height = 28
        Me.dgvUpcoming.Size = New System.Drawing.Size(790, 520)
        Me.dgvUpcoming.TabIndex = 0
        '
        'tpInHouse
        '
        Me.tpInHouse.Controls.Add(Me.Panel1)
        Me.tpInHouse.Controls.Add(Me.dgvInHouse)
        Me.tpInHouse.Location = New System.Drawing.Point(4, 29)
        Me.tpInHouse.Name = "tpInHouse"
        Me.tpInHouse.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInHouse.Size = New System.Drawing.Size(802, 617)
        Me.tpInHouse.TabIndex = 1
        Me.tpInHouse.Text = "In-House Guests" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tpInHouse.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblPageInfoInHouse)
        Me.Panel1.Controls.Add(Me.btnLastInHouse)
        Me.Panel1.Controls.Add(Me.btnPrevInHouse)
        Me.Panel1.Controls.Add(Me.btnNextInHouse)
        Me.Panel1.Controls.Add(Me.btnFirstInHouse)
        Me.Panel1.Controls.Add(Me.btnSearchInHouse)
        Me.Panel1.Controls.Add(Me.txtSearchInHouse)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(6, 538)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 78)
        Me.Panel1.TabIndex = 3
        '
        'lblPageInfoInHouse
        '
        Me.lblPageInfoInHouse.AutoSize = True
        Me.lblPageInfoInHouse.Location = New System.Drawing.Point(369, 41)
        Me.lblPageInfoInHouse.Name = "lblPageInfoInHouse"
        Me.lblPageInfoInHouse.Size = New System.Drawing.Size(94, 40)
        Me.lblPageInfoInHouse.TabIndex = 9
        Me.lblPageInfoInHouse.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLastInHouse
        '
        Me.btnLastInHouse.Location = New System.Drawing.Point(550, 35)
        Me.btnLastInHouse.Name = "btnLastInHouse"
        Me.btnLastInHouse.Size = New System.Drawing.Size(75, 28)
        Me.btnLastInHouse.TabIndex = 8
        Me.btnLastInHouse.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLastInHouse.UseVisualStyleBackColor = True
        '
        'btnPrevInHouse
        '
        Me.btnPrevInHouse.Location = New System.Drawing.Point(278, 36)
        Me.btnPrevInHouse.Name = "btnPrevInHouse"
        Me.btnPrevInHouse.Size = New System.Drawing.Size(85, 28)
        Me.btnPrevInHouse.TabIndex = 7
        Me.btnPrevInHouse.Text = "< "
        Me.btnPrevInHouse.UseVisualStyleBackColor = True
        '
        'btnNextInHouse
        '
        Me.btnNextInHouse.Location = New System.Drawing.Point(469, 35)
        Me.btnNextInHouse.Name = "btnNextInHouse"
        Me.btnNextInHouse.Size = New System.Drawing.Size(75, 28)
        Me.btnNextInHouse.TabIndex = 6
        Me.btnNextInHouse.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNextInHouse.UseVisualStyleBackColor = True
        '
        'btnFirstInHouse
        '
        Me.btnFirstInHouse.Location = New System.Drawing.Point(197, 36)
        Me.btnFirstInHouse.Name = "btnFirstInHouse"
        Me.btnFirstInHouse.Size = New System.Drawing.Size(75, 28)
        Me.btnFirstInHouse.TabIndex = 5
        Me.btnFirstInHouse.Text = "<< "
        Me.btnFirstInHouse.UseVisualStyleBackColor = True
        '
        'btnSearchInHouse
        '
        Me.btnSearchInHouse.Location = New System.Drawing.Point(655, 3)
        Me.btnSearchInHouse.Name = "btnSearchInHouse"
        Me.btnSearchInHouse.Size = New System.Drawing.Size(132, 28)
        Me.btnSearchInHouse.TabIndex = 4
        Me.btnSearchInHouse.Text = "Search"
        Me.btnSearchInHouse.UseVisualStyleBackColor = True
        '
        'txtSearchInHouse
        '
        Me.txtSearchInHouse.Location = New System.Drawing.Point(224, 3)
        Me.txtSearchInHouse.Name = "txtSearchInHouse"
        Me.txtSearchInHouse.Size = New System.Drawing.Size(425, 26)
        Me.txtSearchInHouse.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 40)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Search by Guest or Room:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvInHouse
        '
        Me.dgvInHouse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInHouse.Location = New System.Drawing.Point(6, 1)
        Me.dgvInHouse.Name = "dgvInHouse"
        Me.dgvInHouse.RowHeadersWidth = 51
        Me.dgvInHouse.RowTemplate.Height = 28
        Me.dgvInHouse.Size = New System.Drawing.Size(790, 520)
        Me.dgvInHouse.TabIndex = 2
        '
        'tpDeparted
        '
        Me.tpDeparted.Controls.Add(Me.Panel2)
        Me.tpDeparted.Controls.Add(Me.dgvDeparted)
        Me.tpDeparted.Location = New System.Drawing.Point(4, 29)
        Me.tpDeparted.Name = "tpDeparted"
        Me.tpDeparted.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDeparted.Size = New System.Drawing.Size(802, 617)
        Me.tpDeparted.TabIndex = 2
        Me.tpDeparted.Text = "Departures / History" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tpDeparted.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblPageInfoDeparted)
        Me.Panel2.Controls.Add(Me.btnLastDeparted)
        Me.Panel2.Controls.Add(Me.btnPrevDeparted)
        Me.Panel2.Controls.Add(Me.btnNextDeparted)
        Me.Panel2.Controls.Add(Me.btnFirstDeparted)
        Me.Panel2.Controls.Add(Me.btnSearchDeparted)
        Me.Panel2.Controls.Add(Me.txtSearchDeparted)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(6, 538)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(790, 78)
        Me.Panel2.TabIndex = 3
        '
        'lblPageInfoDeparted
        '
        Me.lblPageInfoDeparted.AutoSize = True
        Me.lblPageInfoDeparted.Location = New System.Drawing.Point(369, 41)
        Me.lblPageInfoDeparted.Name = "lblPageInfoDeparted"
        Me.lblPageInfoDeparted.Size = New System.Drawing.Size(94, 40)
        Me.lblPageInfoDeparted.TabIndex = 9
        Me.lblPageInfoDeparted.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLastDeparted
        '
        Me.btnLastDeparted.Location = New System.Drawing.Point(550, 35)
        Me.btnLastDeparted.Name = "btnLastDeparted"
        Me.btnLastDeparted.Size = New System.Drawing.Size(75, 28)
        Me.btnLastDeparted.TabIndex = 8
        Me.btnLastDeparted.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLastDeparted.UseVisualStyleBackColor = True
        '
        'btnPrevDeparted
        '
        Me.btnPrevDeparted.Location = New System.Drawing.Point(278, 36)
        Me.btnPrevDeparted.Name = "btnPrevDeparted"
        Me.btnPrevDeparted.Size = New System.Drawing.Size(85, 28)
        Me.btnPrevDeparted.TabIndex = 7
        Me.btnPrevDeparted.Text = "< "
        Me.btnPrevDeparted.UseVisualStyleBackColor = True
        '
        'btnNextDeparted
        '
        Me.btnNextDeparted.Location = New System.Drawing.Point(469, 35)
        Me.btnNextDeparted.Name = "btnNextDeparted"
        Me.btnNextDeparted.Size = New System.Drawing.Size(75, 28)
        Me.btnNextDeparted.TabIndex = 6
        Me.btnNextDeparted.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNextDeparted.UseVisualStyleBackColor = True
        '
        'btnFirstDeparted
        '
        Me.btnFirstDeparted.Location = New System.Drawing.Point(197, 36)
        Me.btnFirstDeparted.Name = "btnFirstDeparted"
        Me.btnFirstDeparted.Size = New System.Drawing.Size(75, 28)
        Me.btnFirstDeparted.TabIndex = 5
        Me.btnFirstDeparted.Text = "<< "
        Me.btnFirstDeparted.UseVisualStyleBackColor = True
        '
        'btnSearchDeparted
        '
        Me.btnSearchDeparted.Location = New System.Drawing.Point(655, 3)
        Me.btnSearchDeparted.Name = "btnSearchDeparted"
        Me.btnSearchDeparted.Size = New System.Drawing.Size(132, 28)
        Me.btnSearchDeparted.TabIndex = 4
        Me.btnSearchDeparted.Text = "Search"
        Me.btnSearchDeparted.UseVisualStyleBackColor = True
        '
        'txtSearchDeparted
        '
        Me.txtSearchDeparted.Location = New System.Drawing.Point(224, 3)
        Me.txtSearchDeparted.Name = "txtSearchDeparted"
        Me.txtSearchDeparted.Size = New System.Drawing.Size(425, 26)
        Me.txtSearchDeparted.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 40)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Search by Guest or Room:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvDeparted
        '
        Me.dgvDeparted.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDeparted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeparted.Location = New System.Drawing.Point(6, 1)
        Me.dgvDeparted.Name = "dgvDeparted"
        Me.dgvDeparted.RowHeadersWidth = 51
        Me.dgvDeparted.RowTemplate.Height = 28
        Me.dgvDeparted.Size = New System.Drawing.Size(790, 520)
        Me.dgvDeparted.TabIndex = 2
        '
        'pnlActions
        '
        Me.pnlActions.Controls.Add(Me.btnViewEdit)
        Me.pnlActions.Controls.Add(Me.btnNewReservation)
        Me.pnlActions.Controls.Add(Me.btnAddCharge)
        Me.pnlActions.Controls.Add(Me.btnCheckout)
        Me.pnlActions.Controls.Add(Me.btnCancel)
        Me.pnlActions.Controls.Add(Me.btnCheckIn)
        Me.pnlActions.Location = New System.Drawing.Point(835, 41)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(150, 521)
        Me.pnlActions.TabIndex = 1
        '
        'btnViewEdit
        '
        Me.btnViewEdit.Location = New System.Drawing.Point(3, 273)
        Me.btnViewEdit.Name = "btnViewEdit"
        Me.btnViewEdit.Size = New System.Drawing.Size(144, 80)
        Me.btnViewEdit.TabIndex = 4
        Me.btnViewEdit.Text = "View / Edit Reservation"
        Me.btnViewEdit.UseVisualStyleBackColor = True
        '
        'btnNewReservation
        '
        Me.btnNewReservation.Location = New System.Drawing.Point(0, 187)
        Me.btnNewReservation.Name = "btnNewReservation"
        Me.btnNewReservation.Size = New System.Drawing.Size(144, 80)
        Me.btnNewReservation.TabIndex = 3
        Me.btnNewReservation.Text = "New Reservation"
        Me.btnNewReservation.UseVisualStyleBackColor = True
        '
        'btnAddCharge
        '
        Me.btnAddCharge.Location = New System.Drawing.Point(3, 101)
        Me.btnAddCharge.Name = "btnAddCharge"
        Me.btnAddCharge.Size = New System.Drawing.Size(144, 80)
        Me.btnAddCharge.TabIndex = 2
        Me.btnAddCharge.Text = "Add Charge/Service" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAddCharge.UseVisualStyleBackColor = True
        '
        'btnCheckout
        '
        Me.btnCheckout.Location = New System.Drawing.Point(3, 60)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(147, 35)
        Me.btnCheckout.TabIndex = 1
        Me.btnCheckout.Text = "Checkout Guest" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCheckout.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(0, 359)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(147, 35)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel Reservation" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCheckIn
        '
        Me.btnCheckIn.Location = New System.Drawing.Point(3, 19)
        Me.btnCheckIn.Name = "btnCheckIn"
        Me.btnCheckIn.Size = New System.Drawing.Size(147, 35)
        Me.btnCheckIn.TabIndex = 0
        Me.btnCheckIn.Text = "Check In Guest"
        Me.btnCheckIn.UseVisualStyleBackColor = True
        '
        'frmReservationManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 697)
        Me.Controls.Add(Me.pnlActions)
        Me.Controls.Add(Me.tcReservations)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmReservationManagement"
        Me.Text = "Reservation Management"
        Me.tcReservations.ResumeLayout(False)
        Me.tpUpcoming.ResumeLayout(False)
        Me.pnlPagingUpcoming.ResumeLayout(False)
        Me.pnlPagingUpcoming.PerformLayout()
        CType(Me.dgvUpcoming, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInHouse.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvInHouse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDeparted.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvDeparted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcReservations As TabControl
    Friend WithEvents tpUpcoming As TabPage
    Friend WithEvents tpInHouse As TabPage
    Friend WithEvents tpDeparted As TabPage
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnAddCharge As Button
    Friend WithEvents btnCheckout As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCheckIn As Button
    Friend WithEvents dgvUpcoming As DataGridView
    Friend WithEvents pnlPagingUpcoming As Panel
    Friend WithEvents lblPageInfoUpcoming As Label
    Friend WithEvents btnLastUpcoming As Button
    Friend WithEvents btnPrevUpcoming As Button
    Friend WithEvents btnNextUpcoming As Button
    Friend WithEvents btnFirstUpcoming As Button
    Friend WithEvents btnSearchUpcoming As Button
    Friend WithEvents txtSearchUpcoming As TextBox
    Friend WithEvents lblSearchUpcoming As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPageInfoInHouse As Label
    Friend WithEvents btnLastInHouse As Button
    Friend WithEvents btnPrevInHouse As Button
    Friend WithEvents btnNextInHouse As Button
    Friend WithEvents btnFirstInHouse As Button
    Friend WithEvents btnSearchInHouse As Button
    Friend WithEvents txtSearchInHouse As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvInHouse As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblPageInfoDeparted As Label
    Friend WithEvents btnLastDeparted As Button
    Friend WithEvents btnPrevDeparted As Button
    Friend WithEvents btnNextDeparted As Button
    Friend WithEvents btnFirstDeparted As Button
    Friend WithEvents btnSearchDeparted As Button
    Friend WithEvents txtSearchDeparted As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvDeparted As DataGridView
    Friend WithEvents btnNewReservation As Button
    Friend WithEvents btnViewEdit As Button
End Class
