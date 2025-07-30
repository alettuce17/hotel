<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuestManagement
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvGuests = New System.Windows.Forms.DataGridView()
        Me.gbGuestDetails = New System.Windows.Forms.GroupBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbLoyaltyStatus = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTotalNights = New System.Windows.Forms.Label()
        Me.lblNightsLabel = New System.Windows.Forms.Label()
        Me.lblTierName = New System.Windows.Forms.Label()
        Me.lblTierLabel = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGuestDetails.SuspendLayout()
        Me.gbLoyaltyStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search by Name or Email:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(212, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(518, 26)
        Me.txtSearch.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(740, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(85, 28)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvGuests
        '
        Me.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuests.Location = New System.Drawing.Point(12, 45)
        Me.dgvGuests.Name = "dgvGuests"
        Me.dgvGuests.RowHeadersWidth = 51
        Me.dgvGuests.RowTemplate.Height = 28
        Me.dgvGuests.Size = New System.Drawing.Size(810, 250)
        Me.dgvGuests.TabIndex = 3
        '
        'gbGuestDetails
        '
        Me.gbGuestDetails.Controls.Add(Me.txtPhone)
        Me.gbGuestDetails.Controls.Add(Me.Label5)
        Me.gbGuestDetails.Controls.Add(Me.txtEmail)
        Me.gbGuestDetails.Controls.Add(Me.Label4)
        Me.gbGuestDetails.Controls.Add(Me.txtLastName)
        Me.gbGuestDetails.Controls.Add(Me.Label3)
        Me.gbGuestDetails.Controls.Add(Me.txtFirstName)
        Me.gbGuestDetails.Controls.Add(Me.Label2)
        Me.gbGuestDetails.Location = New System.Drawing.Point(12, 310)
        Me.gbGuestDetails.Name = "gbGuestDetails"
        Me.gbGuestDetails.Size = New System.Drawing.Size(810, 180)
        Me.gbGuestDetails.TabIndex = 4
        Me.gbGuestDetails.TabStop = False
        Me.gbGuestDetails.Text = "Guest Details"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(415, 110)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(380, 26)
        Me.txtPhone.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 40)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Phone Number:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(15, 110)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(380, 26)
        Me.txtEmail.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 40)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Email:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(415, 50)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(380, 26)
        Me.txtLastName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 40)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Last Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(15, 50)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(380, 26)
        Me.txtFirstName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 40)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "First Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbLoyaltyStatus
        '
        Me.gbLoyaltyStatus.Controls.Add(Me.lblTotalNights)
        Me.gbLoyaltyStatus.Controls.Add(Me.lblNightsLabel)
        Me.gbLoyaltyStatus.Controls.Add(Me.lblTierName)
        Me.gbLoyaltyStatus.Controls.Add(Me.lblTierLabel)
        Me.gbLoyaltyStatus.Location = New System.Drawing.Point(12, 500)
        Me.gbLoyaltyStatus.Name = "gbLoyaltyStatus"
        Me.gbLoyaltyStatus.Size = New System.Drawing.Size(810, 78)
        Me.gbLoyaltyStatus.TabIndex = 12
        Me.gbLoyaltyStatus.TabStop = False
        Me.gbLoyaltyStatus.Text = "Loyalty Status"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(710, 584)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 28)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save Changes" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(619, 584)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 28)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTotalNights
        '
        Me.lblTotalNights.AutoSize = True
        Me.lblTotalNights.Location = New System.Drawing.Point(536, 20)
        Me.lblTotalNights.Name = "lblTotalNights"
        Me.lblTotalNights.Size = New System.Drawing.Size(18, 20)
        Me.lblTotalNights.TabIndex = 11
        Me.lblTotalNights.Text = "0"
        '
        'lblNightsLabel
        '
        Me.lblNightsLabel.AutoSize = True
        Me.lblNightsLabel.Location = New System.Drawing.Point(300, 20)
        Me.lblNightsLabel.Name = "lblNightsLabel"
        Me.lblNightsLabel.Size = New System.Drawing.Size(230, 40)
        Me.lblNightsLabel.TabIndex = 9
        Me.lblNightsLabel.Text = "Total Nights (Last 365 Days):" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblTierName
        '
        Me.lblTierName.AutoSize = True
        Me.lblTierName.Location = New System.Drawing.Point(125, 20)
        Me.lblTierName.Name = "lblTierName"
        Me.lblTierName.Size = New System.Drawing.Size(37, 40)
        Me.lblTierName.TabIndex = 7
        Me.lblTierName.Text = "N/A" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblTierLabel
        '
        Me.lblTierLabel.AutoSize = True
        Me.lblTierLabel.Location = New System.Drawing.Point(15, 20)
        Me.lblTierLabel.Name = "lblTierLabel"
        Me.lblTierLabel.Size = New System.Drawing.Size(104, 40)
        Me.lblTierLabel.TabIndex = 5
        Me.lblTierLabel.Text = "Current Tier:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(12, 580)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(165, 28)
        Me.btnChangePassword.TabIndex = 15
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'frmGuestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 620)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbLoyaltyStatus)
        Me.Controls.Add(Me.gbGuestDetails)
        Me.Controls.Add(Me.dgvGuests)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmGuestManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Guest Management"
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGuestDetails.ResumeLayout(False)
        Me.gbGuestDetails.PerformLayout()
        Me.gbLoyaltyStatus.ResumeLayout(False)
        Me.gbLoyaltyStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dgvGuests As DataGridView
    Friend WithEvents gbGuestDetails As GroupBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents gbLoyaltyStatus As GroupBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTotalNights As Label
    Friend WithEvents lblNightsLabel As Label
    Friend WithEvents lblTierName As Label
    Friend WithEvents lblTierLabel As Label
    Friend WithEvents btnChangePassword As Button
End Class
