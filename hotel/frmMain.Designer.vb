<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.logoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DashboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperationsStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WalkinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HousekeepingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReservationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HotelSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoyaltyTiersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivityLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsslUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslRole = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BedTypePricingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMain.SuspendLayout()
        Me.ssMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.DashboardToolStripMenuItem, Me.OperationsStripMenuItem, Me.ManagementToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ActivityLogToolStripMenuItem})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(1898, 28)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.logoutToolStripMenuItem, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'logoutToolStripMenuItem
        '
        Me.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem"
        Me.logoutToolStripMenuItem.Size = New System.Drawing.Size(139, 26)
        Me.logoutToolStripMenuItem.Text = "Logout"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(139, 26)
        Me.exitToolStripMenuItem.Text = "Exit"
        '
        'DashboardToolStripMenuItem
        '
        Me.DashboardToolStripMenuItem.Name = "DashboardToolStripMenuItem"
        Me.DashboardToolStripMenuItem.Size = New System.Drawing.Size(100, 24)
        Me.DashboardToolStripMenuItem.Text = "Dashboard "
        '
        'OperationsStripMenuItem
        '
        Me.OperationsStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WalkinToolStripMenuItem, Me.HousekeepingToolStripMenuItem, Me.ReservationsToolStripMenuItem})
        Me.OperationsStripMenuItem.Name = "OperationsStripMenuItem"
        Me.OperationsStripMenuItem.Size = New System.Drawing.Size(96, 24)
        Me.OperationsStripMenuItem.Text = "Operations"
        '
        'WalkinToolStripMenuItem
        '
        Me.WalkinToolStripMenuItem.Name = "WalkinToolStripMenuItem"
        Me.WalkinToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.WalkinToolStripMenuItem.Text = "Walk-in"
        '
        'HousekeepingToolStripMenuItem
        '
        Me.HousekeepingToolStripMenuItem.Name = "HousekeepingToolStripMenuItem"
        Me.HousekeepingToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.HousekeepingToolStripMenuItem.Text = "Housekeeping"
        '
        'ReservationsToolStripMenuItem
        '
        Me.ReservationsToolStripMenuItem.Name = "ReservationsToolStripMenuItem"
        Me.ReservationsToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.ReservationsToolStripMenuItem.Text = "Reservations"
        '
        'ManagementToolStripMenuItem
        '
        Me.ManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HotelSettingsToolStripMenuItem, Me.AddonsToolStripMenuItem, Me.LoyaltyTiersToolStripMenuItem, Me.GuestsToolStripMenuItem, Me.StaffToolStripMenuItem, Me.BackupToolStripMenuItem, Me.BedTypePricingToolStripMenuItem})
        Me.ManagementToolStripMenuItem.Name = "ManagementToolStripMenuItem"
        Me.ManagementToolStripMenuItem.Size = New System.Drawing.Size(115, 24)
        Me.ManagementToolStripMenuItem.Text = "Management "
        '
        'HotelSettingsToolStripMenuItem
        '
        Me.HotelSettingsToolStripMenuItem.Name = "HotelSettingsToolStripMenuItem"
        Me.HotelSettingsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.HotelSettingsToolStripMenuItem.Text = "Hotel Settings"
        '
        'AddonsToolStripMenuItem
        '
        Me.AddonsToolStripMenuItem.Name = "AddonsToolStripMenuItem"
        Me.AddonsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.AddonsToolStripMenuItem.Text = "Addons"
        '
        'LoyaltyTiersToolStripMenuItem
        '
        Me.LoyaltyTiersToolStripMenuItem.Name = "LoyaltyTiersToolStripMenuItem"
        Me.LoyaltyTiersToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.LoyaltyTiersToolStripMenuItem.Text = "Loyalty Tiers "
        '
        'GuestsToolStripMenuItem
        '
        Me.GuestsToolStripMenuItem.Name = "GuestsToolStripMenuItem"
        Me.GuestsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.GuestsToolStripMenuItem.Text = "Guests "
        '
        'StaffToolStripMenuItem
        '
        Me.StaffToolStripMenuItem.Name = "StaffToolStripMenuItem"
        Me.StaffToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.StaffToolStripMenuItem.Text = "Staff"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ActivityLogToolStripMenuItem
        '
        Me.ActivityLogToolStripMenuItem.Name = "ActivityLogToolStripMenuItem"
        Me.ActivityLogToolStripMenuItem.Size = New System.Drawing.Size(101, 24)
        Me.ActivityLogToolStripMenuItem.Text = "Activity Log"
        '
        'ssMain
        '
        Me.ssMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.tsslUser, Me.tsslRole})
        Me.ssMain.Location = New System.Drawing.Point(0, 1114)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(1898, 30)
        Me.ssMain.TabIndex = 2
        Me.ssMain.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(38, 28)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'tsslUser
        '
        Me.tsslUser.Name = "tsslUser"
        Me.tsslUser.Size = New System.Drawing.Size(153, 24)
        Me.tsslUser.Text = "ToolStripStatusLabel1"
        '
        'tsslRole
        '
        Me.tsslRole.Name = "tsslRole"
        Me.tsslRole.Size = New System.Drawing.Size(153, 24)
        Me.tsslRole.Text = "ToolStripStatusLabel2"
        '
        'BedTypePricingToolStripMenuItem
        '
        Me.BedTypePricingToolStripMenuItem.Name = "BedTypePricingToolStripMenuItem"
        Me.BedTypePricingToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.BedTypePricingToolStripMenuItem.Text = "Bed Type Pricing"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1898, 1144)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.msMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hotel Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents msMain As MenuStrip
    Friend WithEvents ssMain As StatusStrip
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents tsslUser As ToolStripStatusLabel
    Friend WithEvents tsslRole As ToolStripStatusLabel
    Friend WithEvents fileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents logoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents exitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DashboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OperationsStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HotelSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddonsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoyaltyTiersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuestsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActivityLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WalkinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HousekeepingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReservationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BedTypePricingToolStripMenuItem As ToolStripMenuItem
End Class
