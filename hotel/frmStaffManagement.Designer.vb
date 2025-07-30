<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffManagement
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
        Me.dgvStaff = New System.Windows.Forms.DataGridView()
        Me.gbStaffDetails = New System.Windows.Forms.GroupBox()
        Me.numSalary = New System.Windows.Forms.NumericUpDown()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.lblSalary = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPageInfo = New System.Windows.Forms.Label()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        CType(Me.dgvStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStaffDetails.SuspendLayout()
        CType(Me.numSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvStaff
        '
        Me.dgvStaff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStaff.Location = New System.Drawing.Point(12, 12)
        Me.dgvStaff.Name = "dgvStaff"
        Me.dgvStaff.RowHeadersWidth = 51
        Me.dgvStaff.RowTemplate.Height = 28
        Me.dgvStaff.Size = New System.Drawing.Size(450, 439)
        Me.dgvStaff.TabIndex = 0
        '
        'gbStaffDetails
        '
        Me.gbStaffDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbStaffDetails.Controls.Add(Me.numSalary)
        Me.gbStaffDetails.Controls.Add(Me.cboStatus)
        Me.gbStaffDetails.Controls.Add(Me.cboRole)
        Me.gbStaffDetails.Controls.Add(Me.lblSalary)
        Me.gbStaffDetails.Controls.Add(Me.Label7)
        Me.gbStaffDetails.Controls.Add(Me.Label6)
        Me.gbStaffDetails.Controls.Add(Me.txtPassword)
        Me.gbStaffDetails.Controls.Add(Me.Label5)
        Me.gbStaffDetails.Controls.Add(Me.txtPhone)
        Me.gbStaffDetails.Controls.Add(Me.Label4)
        Me.gbStaffDetails.Controls.Add(Me.txtEmail)
        Me.gbStaffDetails.Controls.Add(Me.Label3)
        Me.gbStaffDetails.Controls.Add(Me.txtLastName)
        Me.gbStaffDetails.Controls.Add(Me.Label2)
        Me.gbStaffDetails.Controls.Add(Me.txtFirstName)
        Me.gbStaffDetails.Controls.Add(Me.Label1)
        Me.gbStaffDetails.Location = New System.Drawing.Point(475, 12)
        Me.gbStaffDetails.Name = "gbStaffDetails"
        Me.gbStaffDetails.Size = New System.Drawing.Size(360, 480)
        Me.gbStaffDetails.TabIndex = 1
        Me.gbStaffDetails.TabStop = False
        Me.gbStaffDetails.Text = "Staff Details" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'numSalary
        '
        Me.numSalary.DecimalPlaces = 2
        Me.numSalary.Location = New System.Drawing.Point(10, 350)
        Me.numSalary.Name = "numSalary"
        Me.numSalary.Size = New System.Drawing.Size(150, 26)
        Me.numSalary.TabIndex = 21
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(180, 290)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(150, 28)
        Me.cboStatus.TabIndex = 20
        '
        'cboRole
        '
        Me.cboRole.FormattingEnabled = True
        Me.cboRole.Location = New System.Drawing.Point(10, 290)
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Size = New System.Drawing.Size(150, 28)
        Me.cboRole.TabIndex = 19
        '
        'lblSalary
        '
        Me.lblSalary.AutoSize = True
        Me.lblSalary.Location = New System.Drawing.Point(10, 330)
        Me.lblSalary.Name = "lblSalary"
        Me.lblSalary.Size = New System.Drawing.Size(61, 20)
        Me.lblSalary.TabIndex = 17
        Me.lblSalary.Text = "Salary:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(180, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 40)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Employment Status:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 40)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Role:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(10, 230)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(320, 26)
        Me.txtPassword.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(333, 40)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Password (leave blank to keep unchanged):" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(10, 170)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(320, 26)
        Me.txtPhone.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 40)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Phone Number:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(10, 110)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(320, 26)
        Me.txtEmail.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 40)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Email (Username):" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(180, 50)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(150, 26)
        Me.txtLastName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 40)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Last Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(10, 50)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(150, 26)
        Me.txtFirstName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 40)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "First Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnPrevious)
        Me.Panel1.Controls.Add(Me.btnFirst)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnLast)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblPageInfo)
        Me.Panel1.Location = New System.Drawing.Point(12, 469)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 81)
        Me.Panel1.TabIndex = 2
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(101, 47)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(105, 30)
        Me.btnPrevious.TabIndex = 28
        Me.btnPrevious.Text = "< Previous" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(6, 47)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(97, 28)
        Me.btnFirst.TabIndex = 27
        Me.btnFirst.Text = "<< First" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(296, 47)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 28)
        Me.btnNext.TabIndex = 26
        Me.btnNext.Text = "Next >" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(372, 47)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(75, 28)
        Me.btnLast.TabIndex = 25
        Me.btnLast.Text = "Last >>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(212, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 28)
        Me.btnSearch.TabIndex = 24
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(6, 22)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 26)
        Me.txtSearch.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 40)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Search by Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPageInfo
        '
        Me.lblPageInfo.AutoSize = True
        Me.lblPageInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageInfo.Location = New System.Drawing.Point(209, 53)
        Me.lblPageInfo.Name = "lblPageInfo"
        Me.lblPageInfo.Size = New System.Drawing.Size(81, 34)
        Me.lblPageInfo.TabIndex = 29
        Me.lblPageInfo.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(569, 491)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(130, 41)
        Me.btnAddNew.TabIndex = 22
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(705, 491)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(130, 41)
        Me.btnSave.TabIndex = 23
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'MySqlCommand1
        '
        Me.MySqlCommand1.CacheAge = 0
        Me.MySqlCommand1.Connection = Nothing
        Me.MySqlCommand1.EnableCaching = False
        Me.MySqlCommand1.Transaction = Nothing
        '
        'frmStaffManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 553)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbStaffDetails)
        Me.Controls.Add(Me.dgvStaff)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStaffManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Staff Management"
        CType(Me.dgvStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStaffDetails.ResumeLayout(False)
        Me.gbStaffDetails.PerformLayout()
        CType(Me.numSalary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvStaff As DataGridView
    Friend WithEvents gbStaffDetails As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblSalary As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents numSalary As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnAddNew As Button
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents lblPageInfo As Label
End Class
