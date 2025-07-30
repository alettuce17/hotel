<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckout
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
        Me.lblGuestName = New System.Windows.Forms.Label()
        Me.lblLoyaltyInfo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBillSummary = New System.Windows.Forms.TextBox()
        Me.gbFinalCalculation = New System.Windows.Forms.GroupBox()
        Me.A = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.L = New System.Windows.Forms.Label()
        Me.lblPointsApplied = New System.Windows.Forms.Label()
        Me.lblAmountDue = New System.Windows.Forms.Label()
        Me.lblDownPayment = New System.Windows.Forms.Label()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.gbBillSummary = New System.Windows.Forms.Label()
        Me.numPointsToUse = New System.Windows.Forms.NumericUpDown()
        Me.btnApplyPoints = New System.Windows.Forms.Button()
        Me.cboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnProcessPayment = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblCashTendered = New System.Windows.Forms.Label()
        Me.txtCashTendered = New System.Windows.Forms.TextBox()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.lblChangeDue = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gbFinalCalculation.SuspendLayout()
        CType(Me.numPointsToUse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGuestName
        '
        Me.lblGuestName.AutoSize = True
        Me.lblGuestName.Location = New System.Drawing.Point(11, 7)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.Size = New System.Drawing.Size(51, 17)
        Me.lblGuestName.TabIndex = 0
        Me.lblGuestName.Text = "Label1"
        '
        'lblLoyaltyInfo
        '
        Me.lblLoyaltyInfo.AutoSize = True
        Me.lblLoyaltyInfo.Location = New System.Drawing.Point(140, 7)
        Me.lblLoyaltyInfo.Name = "lblLoyaltyInfo"
        Me.lblLoyaltyInfo.Size = New System.Drawing.Size(51, 17)
        Me.lblLoyaltyInfo.TabIndex = 1
        Me.lblLoyaltyInfo.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBillSummary)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 60)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(329, 420)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "gbBillSummary"
        '
        'txtBillSummary
        '
        Me.txtBillSummary.Location = New System.Drawing.Point(5, 20)
        Me.txtBillSummary.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBillSummary.Multiline = True
        Me.txtBillSummary.Name = "txtBillSummary"
        Me.txtBillSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBillSummary.Size = New System.Drawing.Size(319, 396)
        Me.txtBillSummary.TabIndex = 3
        '
        'gbFinalCalculation
        '
        Me.gbFinalCalculation.Controls.Add(Me.A)
        Me.gbFinalCalculation.Controls.Add(Me.Label7)
        Me.gbFinalCalculation.Controls.Add(Me.Label8)
        Me.gbFinalCalculation.Controls.Add(Me.Label9)
        Me.gbFinalCalculation.Controls.Add(Me.Label10)
        Me.gbFinalCalculation.Controls.Add(Me.Label11)
        Me.gbFinalCalculation.Controls.Add(Me.L)
        Me.gbFinalCalculation.Controls.Add(Me.lblPointsApplied)
        Me.gbFinalCalculation.Controls.Add(Me.lblAmountDue)
        Me.gbFinalCalculation.Controls.Add(Me.lblDownPayment)
        Me.gbFinalCalculation.Controls.Add(Me.lblGrandTotal)
        Me.gbFinalCalculation.Controls.Add(Me.lblTax)
        Me.gbFinalCalculation.Controls.Add(Me.lblDiscount)
        Me.gbFinalCalculation.Controls.Add(Me.lblSubtotal)
        Me.gbFinalCalculation.Location = New System.Drawing.Point(351, 60)
        Me.gbFinalCalculation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbFinalCalculation.Name = "gbFinalCalculation"
        Me.gbFinalCalculation.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbFinalCalculation.Size = New System.Drawing.Size(342, 240)
        Me.gbFinalCalculation.TabIndex = 3
        Me.gbFinalCalculation.TabStop = False
        Me.gbFinalCalculation.Text = "Final Calculation"
        '
        'A
        '
        Me.A.AutoSize = True
        Me.A.Location = New System.Drawing.Point(28, 90)
        Me.A.Name = "A"
        Me.A.Size = New System.Drawing.Size(145, 17)
        Me.A.TabIndex = 17
        Me.A.Text = "Down Payment Made:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "AMOUNT DUE: ₱"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Points Redeemed:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 17)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Grand Total:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 17)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Tax:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Loyalty Discount:"""
        '
        'L
        '
        Me.L.AutoSize = True
        Me.L.Location = New System.Drawing.Point(28, 26)
        Me.L.Name = "L"
        Me.L.Size = New System.Drawing.Size(60, 17)
        Me.L.TabIndex = 11
        Me.L.Text = "Subtotal"
        '
        'lblPointsApplied
        '
        Me.lblPointsApplied.AutoSize = True
        Me.lblPointsApplied.Location = New System.Drawing.Point(195, 106)
        Me.lblPointsApplied.Name = "lblPointsApplied"
        Me.lblPointsApplied.Size = New System.Drawing.Size(36, 17)
        Me.lblPointsApplied.TabIndex = 10
        Me.lblPointsApplied.Text = "0.00"
        '
        'lblAmountDue
        '
        Me.lblAmountDue.AutoSize = True
        Me.lblAmountDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountDue.Location = New System.Drawing.Point(195, 122)
        Me.lblAmountDue.Name = "lblAmountDue"
        Me.lblAmountDue.Size = New System.Drawing.Size(44, 20)
        Me.lblAmountDue.TabIndex = 9
        Me.lblAmountDue.Text = "0.00"
        '
        'lblDownPayment
        '
        Me.lblDownPayment.AutoSize = True
        Me.lblDownPayment.Location = New System.Drawing.Point(195, 90)
        Me.lblDownPayment.Name = "lblDownPayment"
        Me.lblDownPayment.Size = New System.Drawing.Size(36, 17)
        Me.lblDownPayment.TabIndex = 8
        Me.lblDownPayment.Text = "0.00"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Location = New System.Drawing.Point(195, 74)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(36, 17)
        Me.lblGrandTotal.TabIndex = 7
        Me.lblGrandTotal.Text = "0.00"
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Location = New System.Drawing.Point(195, 58)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(36, 17)
        Me.lblTax.TabIndex = 6
        Me.lblTax.Text = "0.00"
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.Location = New System.Drawing.Point(195, 42)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(36, 17)
        Me.lblDiscount.TabIndex = 5
        Me.lblDiscount.Text = "0.00"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(195, 26)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(36, 17)
        Me.lblSubtotal.TabIndex = 4
        Me.lblSubtotal.Text = "0.00"
        '
        'gbBillSummary
        '
        Me.gbBillSummary.AutoSize = True
        Me.gbBillSummary.Location = New System.Drawing.Point(12, 42)
        Me.gbBillSummary.Name = "gbBillSummary"
        Me.gbBillSummary.Size = New System.Drawing.Size(108, 17)
        Me.gbBillSummary.TabIndex = 4
        Me.gbBillSummary.Text = "Billing Summary"
        '
        'numPointsToUse
        '
        Me.numPointsToUse.Location = New System.Drawing.Point(356, 312)
        Me.numPointsToUse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPointsToUse.Name = "numPointsToUse"
        Me.numPointsToUse.Size = New System.Drawing.Size(107, 22)
        Me.numPointsToUse.TabIndex = 5
        '
        'btnApplyPoints
        '
        Me.btnApplyPoints.Location = New System.Drawing.Point(471, 310)
        Me.btnApplyPoints.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnApplyPoints.Name = "btnApplyPoints"
        Me.btnApplyPoints.Size = New System.Drawing.Size(128, 24)
        Me.btnApplyPoints.TabIndex = 6
        Me.btnApplyPoints.Text = "Apply Points"
        Me.btnApplyPoints.UseVisualStyleBackColor = True
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.FormattingEnabled = True
        Me.cboPaymentMethod.Items.AddRange(New Object() {"Cash", "Credit Card", "", "", "Debit Card", "Bank Transfer", "Online Payment"})
        Me.cboPaymentMethod.Location = New System.Drawing.Point(356, 355)
        Me.cboPaymentMethod.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.Size = New System.Drawing.Size(113, 24)
        Me.cboPaymentMethod.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(353, 336)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Payment Method:"
        '
        'btnProcessPayment
        '
        Me.btnProcessPayment.Location = New System.Drawing.Point(498, 454)
        Me.btnProcessPayment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnProcessPayment.Name = "btnProcessPayment"
        Me.btnProcessPayment.Size = New System.Drawing.Size(128, 22)
        Me.btnProcessPayment.TabIndex = 9
        Me.btnProcessPayment.Text = "Process Payment"
        Me.btnProcessPayment.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(351, 454)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(128, 22)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblCashTendered
        '
        Me.lblCashTendered.AutoSize = True
        Me.lblCashTendered.Location = New System.Drawing.Point(357, 392)
        Me.lblCashTendered.Name = "lblCashTendered"
        Me.lblCashTendered.Size = New System.Drawing.Size(110, 17)
        Me.lblCashTendered.TabIndex = 18
        Me.lblCashTendered.Text = "Cash Tendered:"
        Me.lblCashTendered.Visible = False
        '
        'txtCashTendered
        '
        Me.txtCashTendered.Location = New System.Drawing.Point(473, 389)
        Me.txtCashTendered.Name = "txtCashTendered"
        Me.txtCashTendered.Size = New System.Drawing.Size(100, 22)
        Me.txtCashTendered.TabIndex = 19
        Me.txtCashTendered.Visible = False
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Location = New System.Drawing.Point(357, 420)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(74, 17)
        Me.lblChange.TabIndex = 20
        Me.lblChange.Text = "Change: ₱"
        '
        'lblChangeDue
        '
        Me.lblChangeDue.AutoSize = True
        Me.lblChangeDue.Location = New System.Drawing.Point(470, 420)
        Me.lblChangeDue.Name = "lblChangeDue"
        Me.lblChangeDue.Size = New System.Drawing.Size(36, 17)
        Me.lblChangeDue.TabIndex = 21
        Me.lblChangeDue.Text = "0.00"
        Me.lblChangeDue.Visible = False
        '
        'frmCheckout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 496)
        Me.Controls.Add(Me.lblChangeDue)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.txtCashTendered)
        Me.Controls.Add(Me.lblCashTendered)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnProcessPayment)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPaymentMethod)
        Me.Controls.Add(Me.btnApplyPoints)
        Me.Controls.Add(Me.numPointsToUse)
        Me.Controls.Add(Me.gbBillSummary)
        Me.Controls.Add(Me.gbFinalCalculation)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblLoyaltyInfo)
        Me.Controls.Add(Me.lblGuestName)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmCheckout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCheckout"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbFinalCalculation.ResumeLayout(False)
        Me.gbFinalCalculation.PerformLayout()
        CType(Me.numPointsToUse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGuestName As Label
    Friend WithEvents lblLoyaltyInfo As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtBillSummary As TextBox
    Friend WithEvents gbFinalCalculation As GroupBox
    Friend WithEvents A As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents L As Label
    Friend WithEvents lblPointsApplied As Label
    Friend WithEvents lblAmountDue As Label
    Friend WithEvents lblDownPayment As Label
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents gbBillSummary As Label
    Friend WithEvents numPointsToUse As NumericUpDown
    Friend WithEvents btnApplyPoints As Button
    Friend WithEvents cboPaymentMethod As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnProcessPayment As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblCashTendered As Label
    Friend WithEvents txtCashTendered As TextBox
    Friend WithEvents lblChange As Label
    Friend WithEvents lblChangeDue As Label
End Class
