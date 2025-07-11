<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHotelSettings
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
        Me.tcSettings = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.txtPostal = New System.Windows.Forms.TextBox()
        Me.lblPostal = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.txtLegalName = New System.Windows.Forms.TextBox()
        Me.lblLegalName = New System.Windows.Forms.Label()
        Me.txtHotelName = New System.Windows.Forms.TextBox()
        Me.lblHotelName = New System.Windows.Forms.Label()
        Me.tpContact = New System.Windows.Forms.TabPage()
        Me.dtpCheckout = New System.Windows.Forms.DateTimePicker()
        Me.numTaxRate = New System.Windows.Forms.NumericUpDown()
        Me.dtpCheckin = New System.Windows.Forms.DateTimePicker()
        Me.lblCheckout = New System.Windows.Forms.Label()
        Me.lblCheckin = New System.Windows.Forms.Label()
        Me.NumericUpDown = New System.Windows.Forms.Label()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.txtWebsite = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tcSettings.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tpContact.SuspendLayout()
        CType(Me.numTaxRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcSettings
        '
        Me.tcSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcSettings.Controls.Add(Me.tpGeneral)
        Me.tcSettings.Controls.Add(Me.tpContact)
        Me.tcSettings.Location = New System.Drawing.Point(14, 14)
        Me.tcSettings.Name = "tcSettings"
        Me.tcSettings.SelectedIndex = 0
        Me.tcSettings.Size = New System.Drawing.Size(732, 480)
        Me.tcSettings.TabIndex = 0
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.txtCountry)
        Me.tpGeneral.Controls.Add(Me.lblCountry)
        Me.tpGeneral.Controls.Add(Me.txtPostal)
        Me.tpGeneral.Controls.Add(Me.lblPostal)
        Me.tpGeneral.Controls.Add(Me.txtState)
        Me.tpGeneral.Controls.Add(Me.lblState)
        Me.tpGeneral.Controls.Add(Me.txtCity)
        Me.tpGeneral.Controls.Add(Me.lblCity)
        Me.tpGeneral.Controls.Add(Me.txtAddress1)
        Me.tpGeneral.Controls.Add(Me.lblAddress1)
        Me.tpGeneral.Controls.Add(Me.txtLegalName)
        Me.tpGeneral.Controls.Add(Me.lblLegalName)
        Me.tpGeneral.Controls.Add(Me.txtHotelName)
        Me.tpGeneral.Controls.Add(Me.lblHotelName)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 29)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(845, 525)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(378, 336)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(389, 26)
        Me.txtCountry.TabIndex = 13
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(378, 312)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(68, 40)
        Me.lblCountry.TabIndex = 12
        Me.lblCountry.Text = "Country:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtPostal
        '
        Me.txtPostal.Location = New System.Drawing.Point(18, 336)
        Me.txtPostal.Name = "txtPostal"
        Me.txtPostal.Size = New System.Drawing.Size(324, 26)
        Me.txtPostal.TabIndex = 11
        '
        'lblPostal
        '
        Me.lblPostal.AutoSize = True
        Me.lblPostal.Location = New System.Drawing.Point(18, 312)
        Me.lblPostal.Name = "lblPostal"
        Me.lblPostal.Size = New System.Drawing.Size(99, 40)
        Me.lblPostal.TabIndex = 10
        Me.lblPostal.Text = "Postal Code:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(378, 264)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(324, 26)
        Me.txtState.TabIndex = 9
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(378, 240)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(116, 40)
        Me.lblState.TabIndex = 8
        Me.lblState.Text = "State/Province:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(18, 264)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(324, 26)
        Me.txtCity.TabIndex = 7
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(18, 240)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(39, 40)
        Me.lblCity.TabIndex = 6
        Me.lblCity.Text = "City:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(18, 192)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(684, 26)
        Me.txtAddress1.TabIndex = 5
        '
        'lblAddress1
        '
        Me.lblAddress1.AutoSize = True
        Me.lblAddress1.Location = New System.Drawing.Point(18, 168)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(119, 40)
        Me.lblAddress1.TabIndex = 4
        Me.lblAddress1.Text = "Address Line 1:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLegalName
        '
        Me.txtLegalName.Location = New System.Drawing.Point(18, 120)
        Me.txtLegalName.Name = "txtLegalName"
        Me.txtLegalName.Size = New System.Drawing.Size(684, 26)
        Me.txtLegalName.TabIndex = 3
        '
        'lblLegalName
        '
        Me.lblLegalName.AutoSize = True
        Me.lblLegalName.Location = New System.Drawing.Point(18, 96)
        Me.lblLegalName.Name = "lblLegalName"
        Me.lblLegalName.Size = New System.Drawing.Size(98, 40)
        Me.lblLegalName.TabIndex = 2
        Me.lblLegalName.Text = "Legal Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtHotelName
        '
        Me.txtHotelName.Location = New System.Drawing.Point(18, 48)
        Me.txtHotelName.Name = "txtHotelName"
        Me.txtHotelName.Size = New System.Drawing.Size(684, 26)
        Me.txtHotelName.TabIndex = 1
        '
        'lblHotelName
        '
        Me.lblHotelName.AutoSize = True
        Me.lblHotelName.Location = New System.Drawing.Point(18, 24)
        Me.lblHotelName.Name = "lblHotelName"
        Me.lblHotelName.Size = New System.Drawing.Size(97, 40)
        Me.lblHotelName.TabIndex = 0
        Me.lblHotelName.Text = "Hotel Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'tpContact
        '
        Me.tpContact.Controls.Add(Me.dtpCheckout)
        Me.tpContact.Controls.Add(Me.numTaxRate)
        Me.tpContact.Controls.Add(Me.dtpCheckin)
        Me.tpContact.Controls.Add(Me.lblCheckout)
        Me.tpContact.Controls.Add(Me.lblCheckin)
        Me.tpContact.Controls.Add(Me.NumericUpDown)
        Me.tpContact.Controls.Add(Me.lblWebsite)
        Me.tpContact.Controls.Add(Me.txtWebsite)
        Me.tpContact.Controls.Add(Me.lblEmail)
        Me.tpContact.Controls.Add(Me.txtEmail)
        Me.tpContact.Controls.Add(Me.lblPhone)
        Me.tpContact.Controls.Add(Me.txtPhone)
        Me.tpContact.Location = New System.Drawing.Point(4, 29)
        Me.tpContact.Name = "tpContact"
        Me.tpContact.Padding = New System.Windows.Forms.Padding(3)
        Me.tpContact.Size = New System.Drawing.Size(724, 447)
        Me.tpContact.TabIndex = 1
        Me.tpContact.Text = "Contact & Policy"
        Me.tpContact.UseVisualStyleBackColor = True
        '
        'dtpCheckout
        '
        Me.dtpCheckout.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCheckout.Location = New System.Drawing.Point(378, 216)
        Me.dtpCheckout.Name = "dtpCheckout"
        Me.dtpCheckout.ShowUpDown = True
        Me.dtpCheckout.Size = New System.Drawing.Size(180, 26)
        Me.dtpCheckout.TabIndex = 15
        '
        'numTaxRate
        '
        Me.numTaxRate.DecimalPlaces = 2
        Me.numTaxRate.Location = New System.Drawing.Point(18, 312)
        Me.numTaxRate.Name = "numTaxRate"
        Me.numTaxRate.Size = New System.Drawing.Size(120, 26)
        Me.numTaxRate.TabIndex = 14
        '
        'dtpCheckin
        '
        Me.dtpCheckin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCheckin.Location = New System.Drawing.Point(18, 216)
        Me.dtpCheckin.Name = "dtpCheckin"
        Me.dtpCheckin.ShowUpDown = True
        Me.dtpCheckin.Size = New System.Drawing.Size(180, 26)
        Me.dtpCheckin.TabIndex = 12
        '
        'lblCheckout
        '
        Me.lblCheckout.AutoSize = True
        Me.lblCheckout.Location = New System.Drawing.Point(378, 192)
        Me.lblCheckout.Name = "lblCheckout"
        Me.lblCheckout.Size = New System.Drawing.Size(142, 40)
        Me.lblCheckout.TabIndex = 11
        Me.lblCheckout.Text = "Default Check-out:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCheckin
        '
        Me.lblCheckin.AutoSize = True
        Me.lblCheckin.Location = New System.Drawing.Point(18, 192)
        Me.lblCheckin.Name = "lblCheckin"
        Me.lblCheckin.Size = New System.Drawing.Size(131, 40)
        Me.lblCheckin.TabIndex = 9
        Me.lblCheckin.Text = "Default Check-in:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'NumericUpDown
        '
        Me.NumericUpDown.AutoSize = True
        Me.NumericUpDown.Location = New System.Drawing.Point(18, 288)
        Me.NumericUpDown.Name = "NumericUpDown"
        Me.NumericUpDown.Size = New System.Drawing.Size(77, 20)
        Me.NumericUpDown.TabIndex = 7
        Me.NumericUpDown.Text = "Tax Rate:" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblWebsite
        '
        Me.lblWebsite.AutoSize = True
        Me.lblWebsite.Location = New System.Drawing.Point(18, 77)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(108, 40)
        Me.lblWebsite.TabIndex = 5
        Me.lblWebsite.Text = "Website URL:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtWebsite
        '
        Me.txtWebsite.Location = New System.Drawing.Point(18, 120)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(684, 26)
        Me.txtWebsite.TabIndex = 4
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(378, 5)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(90, 40)
        Me.lblEmail.TabIndex = 3
        Me.lblEmail.Text = "Main Email:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(378, 48)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(324, 26)
        Me.txtEmail.TabIndex = 2
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(18, 0)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(97, 40)
        Me.lblPhone.TabIndex = 1
        Me.lblPhone.Text = "Main Phone:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(18, 48)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(324, 26)
        Me.txtPhone.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(628, 500)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 34)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save Settings" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(505, 500)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 34)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Export to Sheets" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmHotelSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 544)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tcSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHotelSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hotel Settings"
        Me.tcSettings.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpGeneral.PerformLayout()
        Me.tpContact.ResumeLayout(False)
        Me.tpContact.PerformLayout()
        CType(Me.numTaxRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcSettings As TabControl
    Friend WithEvents tpContact As TabPage
    Friend WithEvents btnSave As Button
    Friend WithEvents dtpCheckout As DateTimePicker
    Friend WithEvents numTaxRate As NumericUpDown
    Friend WithEvents dtpCheckin As DateTimePicker
    Friend WithEvents lblCheckout As Label
    Friend WithEvents lblCheckin As Label
    Friend WithEvents NumericUpDown As Label
    Friend WithEvents lblWebsite As Label
    Friend WithEvents txtWebsite As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents tpGeneral As TabPage
    Friend WithEvents txtCountry As TextBox
    Friend WithEvents lblCountry As Label
    Friend WithEvents txtPostal As TextBox
    Friend WithEvents lblPostal As Label
    Friend WithEvents txtState As TextBox
    Friend WithEvents lblState As Label
    Friend WithEvents txtCity As TextBox
    Friend WithEvents lblCity As Label
    Friend WithEvents txtAddress1 As TextBox
    Friend WithEvents lblAddress1 As Label
    Friend WithEvents txtLegalName As TextBox
    Friend WithEvents lblLegalName As Label
    Friend WithEvents txtHotelName As TextBox
    Friend WithEvents lblHotelName As Label
    Friend WithEvents btnCancel As Button
End Class
