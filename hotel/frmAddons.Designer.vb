<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddons
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
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lstAvailableAddons = New System.Windows.Forms.ListBox()
        Me.btnSearchAddons = New System.Windows.Forms.Button()
        Me.txtSearchAddon = New System.Windows.Forms.TextBox()
        Me.lblSearchAddons = New System.Windows.Forms.Label()
        Me.lblGuestInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAddonQuantity = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgvSelectedAddons = New System.Windows.Forms.DataGridView()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSelectedAddons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(442, 434)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(113, 31)
        Me.btnRemove.TabIndex = 22
        Me.btnRemove.Text = "<- Remove" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Export to Sheets" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(313, 434)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(113, 31)
        Me.btnAdd.TabIndex = 20
        Me.btnAdd.Text = "Add ->" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(165, 434)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(120, 26)
        Me.numQuantity.TabIndex = 19
        '
        'lstAvailableAddons
        '
        Me.lstAvailableAddons.FormattingEnabled = True
        Me.lstAvailableAddons.ItemHeight = 20
        Me.lstAvailableAddons.Location = New System.Drawing.Point(13, 79)
        Me.lstAvailableAddons.Name = "lstAvailableAddons"
        Me.lstAvailableAddons.Size = New System.Drawing.Size(408, 344)
        Me.lstAvailableAddons.TabIndex = 16
        '
        'btnSearchAddons
        '
        Me.btnSearchAddons.Location = New System.Drawing.Point(774, 9)
        Me.btnSearchAddons.Name = "btnSearchAddons"
        Me.btnSearchAddons.Size = New System.Drawing.Size(102, 34)
        Me.btnSearchAddons.TabIndex = 15
        Me.btnSearchAddons.Text = "Search"
        Me.btnSearchAddons.UseVisualStyleBackColor = True
        '
        'txtSearchAddon
        '
        Me.txtSearchAddon.Location = New System.Drawing.Point(541, 17)
        Me.txtSearchAddon.Name = "txtSearchAddon"
        Me.txtSearchAddon.Size = New System.Drawing.Size(227, 26)
        Me.txtSearchAddon.TabIndex = 14
        '
        'lblSearchAddons
        '
        Me.lblSearchAddons.AutoSize = True
        Me.lblSearchAddons.Location = New System.Drawing.Point(471, 17)
        Me.lblSearchAddons.Name = "lblSearchAddons"
        Me.lblSearchAddons.Size = New System.Drawing.Size(67, 40)
        Me.lblSearchAddons.TabIndex = 13
        Me.lblSearchAddons.Text = "Search:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblGuestInfo
        '
        Me.lblGuestInfo.AutoSize = True
        Me.lblGuestInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblGuestInfo.Name = "lblGuestInfo"
        Me.lblGuestInfo.Size = New System.Drawing.Size(59, 20)
        Me.lblGuestInfo.TabIndex = 12
        Me.lblGuestInfo.Text = "Guest:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 40)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Available Addons:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblAddonQuantity
        '
        Me.lblAddonQuantity.AutoSize = True
        Me.lblAddonQuantity.Location = New System.Drawing.Point(83, 434)
        Me.lblAddonQuantity.Name = "lblAddonQuantity"
        Me.lblAddonQuantity.Size = New System.Drawing.Size(76, 40)
        Me.lblAddonQuantity.TabIndex = 18
        Me.lblAddonQuantity.Text = "Quantity:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(623, 431)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(113, 31)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(742, 431)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(113, 31)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(438, 49)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(56, 20)
        Me.lblTotal.TabIndex = 26
        Me.lblTotal.Text = "Total: "
        '
        'dgvSelectedAddons
        '
        Me.dgvSelectedAddons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectedAddons.Location = New System.Drawing.Point(442, 79)
        Me.dgvSelectedAddons.Name = "dgvSelectedAddons"
        Me.dgvSelectedAddons.RowHeadersWidth = 51
        Me.dgvSelectedAddons.RowTemplate.Height = 28
        Me.dgvSelectedAddons.Size = New System.Drawing.Size(413, 344)
        Me.dgvSelectedAddons.TabIndex = 27
        '
        'frmAddons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 479)
        Me.Controls.Add(Me.dgvSelectedAddons)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.numQuantity)
        Me.Controls.Add(Me.lstAvailableAddons)
        Me.Controls.Add(Me.btnSearchAddons)
        Me.Controls.Add(Me.txtSearchAddon)
        Me.Controls.Add(Me.lblSearchAddons)
        Me.Controls.Add(Me.lblGuestInfo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAddonQuantity)
        Me.Name = "frmAddons"
        Me.Text = "frmAddons"
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSelectedAddons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents lstAvailableAddons As ListBox
    Friend WithEvents btnSearchAddons As Button
    Friend WithEvents txtSearchAddon As TextBox
    Friend WithEvents lblSearchAddons As Label
    Friend WithEvents lblGuestInfo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAddonQuantity As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvSelectedAddons As DataGridView
End Class
