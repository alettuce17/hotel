<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoyaltyTiers
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
        Me.dgvTiers = New System.Windows.Forms.DataGridView()
        Me.lblTierName = New System.Windows.Forms.Label()
        Me.txtTierName = New System.Windows.Forms.TextBox()
        Me.numMinPoints = New System.Windows.Forms.NumericUpDown()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtBenefits = New System.Windows.Forms.TextBox()
        Me.lblMinPoints = New System.Windows.Forms.Label()
        Me.lblMaxPoints = New System.Windows.Forms.Label()
        Me.numMaxPoints = New System.Windows.Forms.NumericUpDown()
        Me.lblBenefits = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        CType(Me.dgvTiers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMaxPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTiers
        '
        Me.dgvTiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTiers.Location = New System.Drawing.Point(14, 14)
        Me.dgvTiers.Name = "dgvTiers"
        Me.dgvTiers.RowHeadersWidth = 62
        Me.dgvTiers.RowTemplate.Height = 28
        Me.dgvTiers.Size = New System.Drawing.Size(792, 240)
        Me.dgvTiers.TabIndex = 0
        '
        'lblTierName
        '
        Me.lblTierName.AutoSize = True
        Me.lblTierName.Location = New System.Drawing.Point(30, 276)
        Me.lblTierName.Name = "lblTierName"
        Me.lblTierName.Size = New System.Drawing.Size(102, 48)
        Me.lblTierName.TabIndex = 1
        Me.lblTierName.Text = "Tier Name:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtTierName
        '
        Me.txtTierName.Location = New System.Drawing.Point(14, 300)
        Me.txtTierName.Name = "txtTierName"
        Me.txtTierName.Size = New System.Drawing.Size(384, 31)
        Me.txtTierName.TabIndex = 2
        '
        'numMinPoints
        '
        Me.numMinPoints.Location = New System.Drawing.Point(420, 300)
        Me.numMinPoints.Name = "numMinPoints"
        Me.numMinPoints.Size = New System.Drawing.Size(180, 26)
        Me.numMinPoints.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(694, 504)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(114, 34)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtBenefits
        '
        Me.txtBenefits.Location = New System.Drawing.Point(14, 372)
        Me.txtBenefits.Multiline = True
        Me.txtBenefits.Name = "txtBenefits"
        Me.txtBenefits.Size = New System.Drawing.Size(792, 90)
        Me.txtBenefits.TabIndex = 6
        '
        'lblMinPoints
        '
        Me.lblMinPoints.AutoSize = True
        Me.lblMinPoints.Location = New System.Drawing.Point(420, 276)
        Me.lblMinPoints.Name = "lblMinPoints"
        Me.lblMinPoints.Size = New System.Drawing.Size(193, 40)
        Me.lblMinPoints.TabIndex = 5
        Me.lblMinPoints.Text = "Minimum Points Required:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblMaxPoints
        '
        Me.lblMaxPoints.AutoSize = True
        Me.lblMaxPoints.Location = New System.Drawing.Point(624, 276)
        Me.lblMaxPoints.Name = "lblMaxPoints"
        Me.lblMaxPoints.Size = New System.Drawing.Size(307, 48)
        Me.lblMaxPoints.TabIndex = 7
        Me.lblMaxPoints.Text = "Maximum Points (0 for highest tier):" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'numMaxPoints
        '
        Me.numMaxPoints.Location = New System.Drawing.Point(624, 300)
        Me.numMaxPoints.Name = "numMaxPoints"
        Me.numMaxPoints.Size = New System.Drawing.Size(180, 26)
        Me.numMaxPoints.TabIndex = 8
        '
        'lblBenefits
        '
        Me.lblBenefits.AutoSize = True
        Me.lblBenefits.Location = New System.Drawing.Point(14, 348)
        Me.lblBenefits.Name = "lblBenefits"
        Me.lblBenefits.Size = New System.Drawing.Size(235, 48)
        Me.lblBenefits.TabIndex = 9
        Me.lblBenefits.Text = "Tier Benefits (Description):" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(572, 504)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 34)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(14, 504)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(114, 34)
        Me.btnAddNew.TabIndex = 11
        Me.btnAddNew.Text = "Add New" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'frmLoyaltyTiers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 544)
        Me.Controls.Add(Me.txtBenefits)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblBenefits)
        Me.Controls.Add(Me.numMaxPoints)
        Me.Controls.Add(Me.lblMaxPoints)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.numMinPoints)
        Me.Controls.Add(Me.txtTierName)
        Me.Controls.Add(Me.lblTierName)
        Me.Controls.Add(Me.dgvTiers)
        Me.Controls.Add(Me.lblMinPoints)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoyaltyTiers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Loyalty Tier Management"
        CType(Me.dgvTiers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMaxPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvTiers As DataGridView
    Friend WithEvents lblTierName As Label
    Friend WithEvents txtTierName As TextBox
    Friend WithEvents numMinPoints As NumericUpDown
    Friend WithEvents btnDelete As Button
    Friend WithEvents txtBenefits As TextBox
    Friend WithEvents lblMinPoints As Label
    Friend WithEvents lblMaxPoints As Label
    Friend WithEvents numMaxPoints As NumericUpDown
    Friend WithEvents lblBenefits As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
End Class
