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
        Me.lblCleaningLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCleaningValue = New System.Windows.Forms.Label()
        Me.lblOccupiedValue = New System.Windows.Forms.Label()
        Me.lblOccupiedLabel = New System.Windows.Forms.Label()
        Me.lblAvailableValue = New System.Windows.Forms.Label()
        Me.lblAvialableLabel = New System.Windows.Forms.Label()
        Me.gbDailyMovements = New System.Windows.Forms.GroupBox()
        Me.dgvCheckouts = New System.Windows.Forms.DataGridView()
        Me.lblCheckouts = New System.Windows.Forms.Label()
        Me.dgvCheckins = New System.Windows.Forms.DataGridView()
        Me.lblCheckins = New System.Windows.Forms.Label()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.gbRoomStatus.SuspendLayout()
        Me.gbDailyMovements.SuspendLayout()
        CType(Me.dgvCheckouts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCheckins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbRoomStatus
        '
        Me.gbRoomStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbRoomStatus.Controls.Add(Me.lblPendingValue)
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
        Me.gbRoomStatus.Size = New System.Drawing.Size(400, 805)
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
        '
        'lblCleaningLabel
        '
        Me.lblCleaningLabel.AutoSize = True
        Me.lblCleaningLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCleaningLabel.Location = New System.Drawing.Point(24, 157)
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
        '
        'lblCleaningValue
        '
        Me.lblCleaningValue.AutoSize = True
        Me.lblCleaningValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCleaningValue.Location = New System.Drawing.Point(199, 150)
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
        Me.gbDailyMovements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDailyMovements.Controls.Add(Me.dgvCheckouts)
        Me.gbDailyMovements.Controls.Add(Me.lblCheckouts)
        Me.gbDailyMovements.Controls.Add(Me.dgvCheckins)
        Me.gbDailyMovements.Controls.Add(Me.lblCheckins)
        Me.gbDailyMovements.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDailyMovements.Location = New System.Drawing.Point(424, 12)
        Me.gbDailyMovements.Name = "gbDailyMovements"
        Me.gbDailyMovements.Size = New System.Drawing.Size(1446, 805)
        Me.gbDailyMovements.TabIndex = 1
        Me.gbDailyMovements.TabStop = False
        Me.gbDailyMovements.Text = "Today's Guest Movements"
        '
        'dgvCheckouts
        '
        Me.dgvCheckouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckouts.Location = New System.Drawing.Point(20, 525)
        Me.dgvCheckouts.Name = "dgvCheckouts"
        Me.dgvCheckouts.RowHeadersWidth = 62
        Me.dgvCheckouts.RowTemplate.Height = 28
        Me.dgvCheckouts.Size = New System.Drawing.Size(1430, 420)
        Me.dgvCheckouts.TabIndex = 9
        '
        'lblCheckouts
        '
        Me.lblCheckouts.AutoSize = True
        Me.lblCheckouts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckouts.Location = New System.Drawing.Point(20, 500)
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
        Me.ClientSize = New System.Drawing.Size(1878, 1044)
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
End Class
