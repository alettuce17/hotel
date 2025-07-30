<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBedTypes
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
        Me.dgvBedTypes = New System.Windows.Forms.DataGridView()
        Me.lblBedTypeName = New System.Windows.Forms.Label()
        Me.txtBedTypeName = New System.Windows.Forms.TextBox()
        Me.numPrice = New System.Windows.Forms.NumericUpDown()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.dgvBedTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBedTypes
        '
        Me.dgvBedTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBedTypes.Location = New System.Drawing.Point(12, 12)
        Me.dgvBedTypes.Name = "dgvBedTypes"
        Me.dgvBedTypes.RowHeadersWidth = 51
        Me.dgvBedTypes.RowTemplate.Height = 28
        Me.dgvBedTypes.Size = New System.Drawing.Size(350, 390)
        Me.dgvBedTypes.TabIndex = 0
        '
        'lblBedTypeName
        '
        Me.lblBedTypeName.AutoSize = True
        Me.lblBedTypeName.Location = New System.Drawing.Point(375, 25)
        Me.lblBedTypeName.Name = "lblBedTypeName"
        Me.lblBedTypeName.Size = New System.Drawing.Size(134, 20)
        Me.lblBedTypeName.TabIndex = 1
        Me.lblBedTypeName.Text = "Bed Type Name:" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtBedTypeName
        '
        Me.txtBedTypeName.Location = New System.Drawing.Point(375, 45)
        Me.txtBedTypeName.Name = "txtBedTypeName"
        Me.txtBedTypeName.Size = New System.Drawing.Size(200, 26)
        Me.txtBedTypeName.TabIndex = 2
        '
        'numPrice
        '
        Me.numPrice.DecimalPlaces = 2
        Me.numPrice.Location = New System.Drawing.Point(375, 105)
        Me.numPrice.Name = "numPrice"
        Me.numPrice.Size = New System.Drawing.Size(200, 26)
        Me.numPrice.TabIndex = 3
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(375, 85)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(53, 20)
        Me.lblPrice.TabIndex = 5
        Me.lblPrice.Text = "Price:" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(480, 150)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 28)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmBedTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 403)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.numPrice)
        Me.Controls.Add(Me.txtBedTypeName)
        Me.Controls.Add(Me.lblBedTypeName)
        Me.Controls.Add(Me.dgvBedTypes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBedTypes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bed Type & Pricing Management"
        CType(Me.dgvBedTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvBedTypes As DataGridView
    Friend WithEvents lblBedTypeName As Label
    Friend WithEvents txtBedTypeName As TextBox
    Friend WithEvents numPrice As NumericUpDown
    Friend WithEvents lblPrice As Label
    Friend WithEvents btnSave As Button
End Class
