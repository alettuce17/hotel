<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Me.components = New System.ComponentModel.Container()
        Me.gbRoomStatus = New System.Windows.Forms.GroupBox()
        Me.lblPendingValue = New System.Windows.Forms.Label()
        Me.btnRefresh_Click = New System.Windows.Forms.Button()
        Me.lblCleaningLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCleaningValue = New System.Windows.Forms.Label()
        Me.lblOccupiedValue = New System.Windows.Forms.Label()
        Me.lblOccupiedLabel = New System.Windows.Forms.Label()
        Me.lblAvailableValue = New System.Windows.Forms.Label()
        Me.lblAvialableLabel = New System.Windows.Forms.Label()
        Me.gbDailyMovements = New System.Windows.Forms.GroupBox()
        Me.pnlPagingCheckins = New System.Windows.Forms.Panel()
        Me.lblPageInfoCheckin = New System.Windows.Forms.Label()
        Me.btnLastCheckin = New System.Windows.Forms.Button()
        Me.btnPrevCheckin = New System.Windows.Forms.Button()
        Me.btnNextCheckin = New System.Windows.Forms.Button()
        Me.btnFirstCheckin = New System.Windows.Forms.Button()
        Me.btnSearchCheckins = New System.Windows.Forms.Button()
        Me.txtSearchCheckins = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlPagingCheckouts = New System.Windows.Forms.Panel()
        Me.lblPageInfoCheckout = New System.Windows.Forms.Label()
        Me.btnLastCheckout = New System.Windows.Forms.Button()
        Me.btnPreviousCheckout = New System.Windows.Forms.Button()
        Me.btnNextCheckout = New System.Windows.Forms.Button()
        Me.btnFirstCheckout = New System.Windows.Forms.Button()
        Me.btnSearchCheckouts = New System.Windows.Forms.Button()
        Me.txtSearchCheckouts = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.dgvCheckouts = New System.Windows.Forms.DataGridView()
        Me.lblCheckouts = New System.Windows.Forms.Label()
        Me.dgvCheckins = New System.Windows.Forms.DataGridView()
        Me.lblCheckins = New System.Windows.Forms.Label()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.gbRoomStatus.SuspendLayout()
        Me.gbDailyMovements.SuspendLayout()
        Me.pnlPagingCheckins.SuspendLayout()
        Me.pnlPagingCheckouts.SuspendLayout()
        CType(Me.dgvCheckouts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCheckins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbRoomStatus
        '
        Me.gbRoomStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbRoomStatus.Controls.Add(Me.lblPendingValue)
        Me.gbRoomStatus.Controls.Add(Me.btnRefresh_Click)
        Me.gbRoomStatus.Controls.Add(Me.lblCleaningLabel)
        Me.gbRoomStatus.Controls.Add(Me.Label1)
        Me.gbRoomStatus.Controls.Add(Me.lblCleaningValue)
        Me.gbRoomStatus.Controls.Add(Me.lblOccupiedValue)
        Me.gbRoomStatus.Controls.Add(Me.lblOccupiedLabel)
        Me.gbRoomStatus.Controls.Add(Me.lblAvailableValue)
        Me.gbRoomStatus.Controls.Add(Me.lblAvialableLabel)
        Me.gbRoomStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gbRoomStatus.Location = New System.Drawing.Point(12, 12)
        Me.gbRoomStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.gbRoomStatus.Name = "gbRoomStatus"
        Me.gbRoomStatus.Padding = New System.Windows.Forms.Padding(4)
        Me.gbRoomStatus.Size = New System.Drawing.Size(400, 532)
        Me.gbRoomStatus.TabIndex = 0
        Me.gbRoomStatus.TabStop = False
        Me.gbRoomStatus.Text = "Room Status"
        '
        'lblPendingValue
        '
        Me.lblPendingValue.AutoSize = True
        Me.lblPendingValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingValue.Location = New System.Drawing.Point(199, 115)
        Me.lblPendingValue.Name = "lblPendingValue"
        Me.lblPendingValue.Size = New System.Drawing.Size(24, 25)
        Me.lblPendingValue.TabIndex = 7
        Me.lblPendingValue.Text = "0"
        Me.lblPendingValue.Visible = False
        '
        'btnRefresh_Click
        '
        Me.btnRefresh_Click.Location = New System.Drawing.Point(27, 194)
        Me.btnRefresh_Click.Name = "btnRefresh_Click"
        Me.btnRefresh_Click.Size = New System.Drawing.Size(139, 38)
        Me.btnRefresh_Click.TabIndex = 3
        Me.btnRefresh_Click.Text = "Refresh Data"
        Me.btnRefresh_Click.UseVisualStyleBackColor = True
        '
        'lblCleaningLabel
        '
        Me.lblCleaningLabel.AutoSize = True
        Me.lblCleaningLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCleaningLabel.Location = New System.Drawing.Point(24, 127)
        Me.lblCleaningLabel.Name = "lblCleaningLabel"
        Me.lblCleaningLabel.Size = New System.Drawing.Size(112, 34)
        Me.lblCleaningLabel.TabIndex = 4
        Me.lblCleaningLabel.Text = "Needs Cleaning:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pending Reservations:"
        Me.Label1.Visible = False
        '
        'lblCleaningValue
        '
        Me.lblCleaningValue.AutoSize = True
        Me.lblCleaningValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCleaningValue.Location = New System.Drawing.Point(199, 120)
        Me.lblCleaningValue.Name = "lblCleaningValue"
        Me.lblCleaningValue.Size = New System.Drawing.Size(24, 25)
        Me.lblCleaningValue.TabIndex = 5
        Me.lblCleaningValue.Text = "0"
        '
        'lblOccupiedValue
        '
        Me.lblOccupiedValue.AutoSize = True
        Me.lblOccupiedValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOccupiedValue.Location = New System.Drawing.Point(199, 86)
        Me.lblOccupiedValue.Name = "lblOccupiedValue"
        Me.lblOccupiedValue.Size = New System.Drawing.Size(24, 25)
        Me.lblOccupiedValue.TabIndex = 3
        Me.lblOccupiedValue.Text = "0"
        '
        'lblOccupiedLabel
        '
        Me.lblOccupiedLabel.AutoSize = True
        Me.lblOccupiedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOccupiedLabel.Location = New System.Drawing.Point(24, 93)
        Me.lblOccupiedLabel.Name = "lblOccupiedLabel"
        Me.lblOccupiedLabel.Size = New System.Drawing.Size(120, 34)
        Me.lblOccupiedLabel.TabIndex = 2
        Me.lblOccupiedLabel.Text = "Occupied Rooms:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblAvailableValue
        '
        Me.lblAvailableValue.AutoSize = True
        Me.lblAvailableValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableValue.Location = New System.Drawing.Point(199, 52)
        Me.lblAvailableValue.Name = "lblAvailableValue"
        Me.lblAvailableValue.Size = New System.Drawing.Size(24, 25)
        Me.lblAvailableValue.TabIndex = 1
        Me.lblAvailableValue.Text = "0"
        '
        'lblAvialableLabel
        '
        Me.lblAvialableLabel.AutoSize = True
        Me.lblAvialableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvialableLabel.Location = New System.Drawing.Point(24, 59)
        Me.lblAvialableLabel.Name = "lblAvialableLabel"
        Me.lblAvialableLabel.Size = New System.Drawing.Size(117, 17)
        Me.lblAvialableLabel.TabIndex = 0
        Me.lblAvialableLabel.Text = "Available Rooms:"
        '
        'gbDailyMovements
        '
        Me.gbDailyMovements.Controls.Add(Me.pnlPagingCheckins)
        Me.gbDailyMovements.Controls.Add(Me.pnlPagingCheckouts)
        Me.gbDailyMovements.Controls.Add(Me.dgvCheckouts)
        Me.gbDailyMovements.Controls.Add(Me.lblCheckouts)
        Me.gbDailyMovements.Controls.Add(Me.dgvCheckins)
        Me.gbDailyMovements.Controls.Add(Me.lblCheckins)
        Me.gbDailyMovements.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDailyMovements.Location = New System.Drawing.Point(424, 12)
        Me.gbDailyMovements.Name = "gbDailyMovements"
        Me.gbDailyMovements.Size = New System.Drawing.Size(1446, 1039)
        Me.gbDailyMovements.TabIndex = 1
        Me.gbDailyMovements.TabStop = False
        Me.gbDailyMovements.Text = "Today's Guest Movements"
        '
        'pnlPagingCheckins
        '
        Me.pnlPagingCheckins.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPagingCheckins.Controls.Add(Me.lblPageInfoCheckin)
        Me.pnlPagingCheckins.Controls.Add(Me.btnLastCheckin)
        Me.pnlPagingCheckins.Controls.Add(Me.btnPrevCheckin)
        Me.pnlPagingCheckins.Controls.Add(Me.btnNextCheckin)
        Me.pnlPagingCheckins.Controls.Add(Me.btnFirstCheckin)
        Me.pnlPagingCheckins.Controls.Add(Me.btnSearchCheckins)
        Me.pnlPagingCheckins.Controls.Add(Me.txtSearchCheckins)
        Me.pnlPagingCheckins.Controls.Add(Me.Label3)
        Me.pnlPagingCheckins.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPagingCheckins.Location = New System.Drawing.Point(0, 495)
        Me.pnlPagingCheckins.Name = "pnlPagingCheckins"
        Me.pnlPagingCheckins.Size = New System.Drawing.Size(1446, 95)
        Me.pnlPagingCheckins.TabIndex = 10
        '
        'lblPageInfoCheckin
        '
        Me.lblPageInfoCheckin.AutoSize = True
        Me.lblPageInfoCheckin.Location = New System.Drawing.Point(789, 45)
        Me.lblPageInfoCheckin.Name = "lblPageInfoCheckin"
        Me.lblPageInfoCheckin.Size = New System.Drawing.Size(104, 48)
        Me.lblPageInfoCheckin.TabIndex = 9
        Me.lblPageInfoCheckin.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLastCheckin
        '
        Me.btnLastCheckin.Location = New System.Drawing.Point(1040, 39)
        Me.btnLastCheckin.Name = "btnLastCheckin"
        Me.btnLastCheckin.Size = New System.Drawing.Size(85, 38)
        Me.btnLastCheckin.TabIndex = 8
        Me.btnLastCheckin.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLastCheckin.UseVisualStyleBackColor = True
        '
        'btnPrevCheckin
        '
        Me.btnPrevCheckin.Location = New System.Drawing.Point(690, 40)
        Me.btnPrevCheckin.Name = "btnPrevCheckin"
        Me.btnPrevCheckin.Size = New System.Drawing.Size(85, 38)
        Me.btnPrevCheckin.TabIndex = 7
        Me.btnPrevCheckin.Text = "< "
        Me.btnPrevCheckin.UseVisualStyleBackColor = True
        '
        'btnNextCheckin
        '
        Me.btnNextCheckin.Location = New System.Drawing.Point(940, 39)
        Me.btnNextCheckin.Name = "btnNextCheckin"
        Me.btnNextCheckin.Size = New System.Drawing.Size(85, 38)
        Me.btnNextCheckin.TabIndex = 6
        Me.btnNextCheckin.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNextCheckin.UseVisualStyleBackColor = True
        '
        'btnFirstCheckin
        '
        Me.btnFirstCheckin.Location = New System.Drawing.Point(593, 40)
        Me.btnFirstCheckin.Name = "btnFirstCheckin"
        Me.btnFirstCheckin.Size = New System.Drawing.Size(85, 38)
        Me.btnFirstCheckin.TabIndex = 5
        Me.btnFirstCheckin.Text = "<< "
        Me.btnFirstCheckin.UseVisualStyleBackColor = True
        '
        'btnSearchCheckins
        '
        Me.btnSearchCheckins.Location = New System.Drawing.Point(469, 40)
        Me.btnSearchCheckins.Name = "btnSearchCheckins"
        Me.btnSearchCheckins.Size = New System.Drawing.Size(108, 38)
        Me.btnSearchCheckins.TabIndex = 4
        Me.btnSearchCheckins.Text = "Search"
        Me.btnSearchCheckins.UseVisualStyleBackColor = True
        '
        'txtSearchCheckins
        '
        Me.txtSearchCheckins.Location = New System.Drawing.Point(38, 44)
        Me.txtSearchCheckins.Name = "txtSearchCheckins"
        Me.txtSearchCheckins.Size = New System.Drawing.Size(425, 28)
        Me.txtSearchCheckins.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 48)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Search by Room #:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlPagingCheckouts
        '
        Me.pnlPagingCheckouts.Controls.Add(Me.lblPageInfoCheckout)
        Me.pnlPagingCheckouts.Controls.Add(Me.btnLastCheckout)
        Me.pnlPagingCheckouts.Controls.Add(Me.btnPreviousCheckout)
        Me.pnlPagingCheckouts.Controls.Add(Me.btnNextCheckout)
        Me.pnlPagingCheckouts.Controls.Add(Me.btnFirstCheckout)
        Me.pnlPagingCheckouts.Controls.Add(Me.btnSearchCheckouts)
        Me.pnlPagingCheckouts.Controls.Add(Me.txtSearchCheckouts)
        Me.pnlPagingCheckouts.Controls.Add(Me.lblSearch)
        Me.pnlPagingCheckouts.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPagingCheckouts.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPagingCheckouts.Location = New System.Drawing.Point(3, 941)
        Me.pnlPagingCheckouts.Name = "pnlPagingCheckouts"
        Me.pnlPagingCheckouts.Size = New System.Drawing.Size(1440, 95)
        Me.pnlPagingCheckouts.TabIndex = 5
        '
        'lblPageInfoCheckout
        '
        Me.lblPageInfoCheckout.AutoSize = True
        Me.lblPageInfoCheckout.Location = New System.Drawing.Point(789, 45)
        Me.lblPageInfoCheckout.Name = "lblPageInfoCheckout"
        Me.lblPageInfoCheckout.Size = New System.Drawing.Size(104, 48)
        Me.lblPageInfoCheckout.TabIndex = 9
        Me.lblPageInfoCheckout.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLastCheckout
        '
        Me.btnLastCheckout.Location = New System.Drawing.Point(1040, 39)
        Me.btnLastCheckout.Name = "btnLastCheckout"
        Me.btnLastCheckout.Size = New System.Drawing.Size(85, 38)
        Me.btnLastCheckout.TabIndex = 8
        Me.btnLastCheckout.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLastCheckout.UseVisualStyleBackColor = True
        '
        'btnPreviousCheckout
        '
        Me.btnPreviousCheckout.Location = New System.Drawing.Point(690, 40)
        Me.btnPreviousCheckout.Name = "btnPreviousCheckout"
        Me.btnPreviousCheckout.Size = New System.Drawing.Size(85, 38)
        Me.btnPreviousCheckout.TabIndex = 7
        Me.btnPreviousCheckout.Text = "< "
        Me.btnPreviousCheckout.UseVisualStyleBackColor = True
        '
        'btnNextCheckout
        '
        Me.btnNextCheckout.Location = New System.Drawing.Point(940, 39)
        Me.btnNextCheckout.Name = "btnNextCheckout"
        Me.btnNextCheckout.Size = New System.Drawing.Size(85, 38)
        Me.btnNextCheckout.TabIndex = 6
        Me.btnNextCheckout.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNextCheckout.UseVisualStyleBackColor = True
        '
        'btnFirstCheckout
        '
        Me.btnFirstCheckout.Location = New System.Drawing.Point(593, 40)
        Me.btnFirstCheckout.Name = "btnFirstCheckout"
        Me.btnFirstCheckout.Size = New System.Drawing.Size(85, 38)
        Me.btnFirstCheckout.TabIndex = 5
        Me.btnFirstCheckout.Text = "<< "
        Me.btnFirstCheckout.UseVisualStyleBackColor = True
        '
        'btnSearchCheckouts
        '
        Me.btnSearchCheckouts.Location = New System.Drawing.Point(469, 40)
        Me.btnSearchCheckouts.Name = "btnSearchCheckouts"
        Me.btnSearchCheckouts.Size = New System.Drawing.Size(108, 38)
        Me.btnSearchCheckouts.TabIndex = 4
        Me.btnSearchCheckouts.Text = "Search"
        Me.btnSearchCheckouts.UseVisualStyleBackColor = True
        '
        'txtSearchCheckouts
        '
        Me.txtSearchCheckouts.Location = New System.Drawing.Point(38, 44)
        Me.txtSearchCheckouts.Name = "txtSearchCheckouts"
        Me.txtSearchCheckouts.Size = New System.Drawing.Size(425, 28)
        Me.txtSearchCheckouts.TabIndex = 3
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(33, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(171, 48)
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "Search by Room #:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvCheckouts
        '
        Me.dgvCheckouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckouts.Location = New System.Drawing.Point(6, 686)
        Me.dgvCheckouts.Name = "dgvCheckouts"
        Me.dgvCheckouts.RowHeadersWidth = 62
        Me.dgvCheckouts.RowTemplate.Height = 28
        Me.dgvCheckouts.Size = New System.Drawing.Size(1430, 262)
        Me.dgvCheckouts.TabIndex = 9
        '
        'lblCheckouts
        '
        Me.lblCheckouts.AutoSize = True
        Me.lblCheckouts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckouts.Location = New System.Drawing.Point(3, 649)
        Me.lblCheckouts.Name = "lblCheckouts"
        Me.lblCheckouts.Size = New System.Drawing.Size(145, 34)
        Me.lblCheckouts.TabIndex = 8
        Me.lblCheckouts.Text = "Expected Check-outs:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvCheckins
        '
        Me.dgvCheckins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckins.Location = New System.Drawing.Point(20, 65)
        Me.dgvCheckins.Name = "dgvCheckins"
        Me.dgvCheckins.RowHeadersWidth = 62
        Me.dgvCheckins.RowTemplate.Height = 28
        Me.dgvCheckins.Size = New System.Drawing.Size(1430, 420)
        Me.dgvCheckins.TabIndex = 7
        '
        'lblCheckins
        '
        Me.lblCheckins.AutoSize = True
        Me.lblCheckins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckins.Location = New System.Drawing.Point(20, 40)
        Me.lblCheckins.Name = "lblCheckins"
        Me.lblCheckins.Size = New System.Drawing.Size(136, 34)
        Me.lblCheckins.TabIndex = 6
        Me.lblCheckins.Text = "Expected Check-ins:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'tmrRefresh
        '
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoScrollMinSize = New System.Drawing.Size(1900, 1020)
        Me.ClientSize = New System.Drawing.Size(1878, 1065)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbDailyMovements)
        Me.Controls.Add(Me.gbRoomStatus)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDashboard"
        Me.Text = "Hotel Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbRoomStatus.ResumeLayout(False)
        Me.gbRoomStatus.PerformLayout()
        Me.gbDailyMovements.ResumeLayout(False)
        Me.gbDailyMovements.PerformLayout()
        Me.pnlPagingCheckins.ResumeLayout(False)
        Me.pnlPagingCheckins.PerformLayout()
        Me.pnlPagingCheckouts.ResumeLayout(False)
        Me.pnlPagingCheckouts.PerformLayout()
        CType(Me.dgvCheckouts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCheckins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbRoomStatus As GroupBox
    Friend WithEvents lblCleaningValue As Label
    Friend WithEvents lblCleaningLabel As Label
    Friend WithEvents lblOccupiedValue As Label
    Friend WithEvents lblOccupiedLabel As Label
    Friend WithEvents lblAvailableValue As Label
    Friend WithEvents lblAvialableLabel As Label
    Friend WithEvents gbDailyMovements As GroupBox
    Friend WithEvents dgvCheckouts As DataGridView
    Friend WithEvents lblCheckouts As Label
    Friend WithEvents dgvCheckins As DataGridView
    Friend WithEvents lblCheckins As Label
    Friend WithEvents tmrRefresh As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPendingValue As Label
    Friend WithEvents pnlPagingCheckouts As Panel
    Friend WithEvents lblPageInfoCheckout As Label
    Friend WithEvents btnRefresh_Click As Button
    Friend WithEvents btnLastCheckout As Button
    Friend WithEvents btnPreviousCheckout As Button
    Friend WithEvents btnNextCheckout As Button
    Friend WithEvents btnFirstCheckout As Button
    Friend WithEvents btnSearchCheckouts As Button
    Friend WithEvents txtSearchCheckouts As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents pnlPagingCheckins As Panel
    Friend WithEvents lblPageInfoCheckin As Label
    Friend WithEvents btnLastCheckin As Button
    Friend WithEvents btnPrevCheckin As Button
    Friend WithEvents btnNextCheckin As Button
    Friend WithEvents btnFirstCheckin As Button
    Friend WithEvents btnSearchCheckins As Button
    Friend WithEvents txtSearchCheckins As TextBox
    Friend WithEvents Label3 As Label
End Class
