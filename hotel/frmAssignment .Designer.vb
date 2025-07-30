<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignment
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
        Me.lblGuestTier = New System.Windows.Forms.Label()
        Me.dgvReservations = New System.Windows.Forms.DataGridView()
        Me.btnRemoveReservation = New System.Windows.Forms.Button()
        Me.btnAssignRoom = New System.Windows.Forms.Button()
        Me.btnConfirmCheckin = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.dgvReservations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGuestName
        '
        Me.lblGuestName.AutoSize = True
        Me.lblGuestName.Location = New System.Drawing.Point(12, 9)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.Size = New System.Drawing.Size(167, 20)
        Me.lblGuestName.TabIndex = 0
        Me.lblGuestName.Text = "Guest Name: [Name]"
        '
        'lblGuestTier
        '
        Me.lblGuestTier.AutoSize = True
        Me.lblGuestTier.Location = New System.Drawing.Point(12, 35)
        Me.lblGuestTier.Name = "lblGuestTier"
        Me.lblGuestTier.Size = New System.Drawing.Size(145, 20)
        Me.lblGuestTier.TabIndex = 1
        Me.lblGuestTier.Text = "Loyalty Tier: [Tier]"
        '
        'dgvReservations
        '
        Me.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReservations.Location = New System.Drawing.Point(16, 58)
        Me.dgvReservations.Name = "dgvReservations"
        Me.dgvReservations.RowHeadersWidth = 51
        Me.dgvReservations.RowTemplate.Height = 28
        Me.dgvReservations.Size = New System.Drawing.Size(860, 450)
        Me.dgvReservations.TabIndex = 2
        '
        'btnRemoveReservation
        '
        Me.btnRemoveReservation.Location = New System.Drawing.Point(150, 525)
        Me.btnRemoveReservation.Name = "btnRemoveReservation"
        Me.btnRemoveReservation.Size = New System.Drawing.Size(160, 28)
        Me.btnRemoveReservation.TabIndex = 3
        Me.btnRemoveReservation.Text = "Remove Selected Room" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnRemoveReservation.UseVisualStyleBackColor = True
        '
        'btnAssignRoom
        '
        Me.btnAssignRoom.Location = New System.Drawing.Point(12, 525)
        Me.btnAssignRoom.Name = "btnAssignRoom"
        Me.btnAssignRoom.Size = New System.Drawing.Size(130, 28)
        Me.btnAssignRoom.TabIndex = 4
        Me.btnAssignRoom.Text = "Assign Room..."
        Me.btnAssignRoom.UseVisualStyleBackColor = True
        '
        'btnConfirmCheckin
        '
        Me.btnConfirmCheckin.Location = New System.Drawing.Point(650, 525)
        Me.btnConfirmCheckin.Name = "btnConfirmCheckin"
        Me.btnConfirmCheckin.Size = New System.Drawing.Size(100, 28)
        Me.btnConfirmCheckin.TabIndex = 5
        Me.btnConfirmCheckin.Text = "Confirm Assignments & Check-In" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnConfirmCheckin.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(762, 525)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(110, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Export to Sheets" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAssignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 553)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirmCheckin)
        Me.Controls.Add(Me.btnAssignRoom)
        Me.Controls.Add(Me.btnRemoveReservation)
        Me.Controls.Add(Me.dgvReservations)
        Me.Controls.Add(Me.lblGuestTier)
        Me.Controls.Add(Me.lblGuestName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssignment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Room Assignment & Check-in"
        CType(Me.dgvReservations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGuestName As Label
    Friend WithEvents lblGuestTier As Label
    Friend WithEvents dgvReservations As DataGridView
    Friend WithEvents btnRemoveReservation As Button
    Friend WithEvents btnAssignRoom As Button
    Friend WithEvents btnConfirmCheckin As Button
    Friend WithEvents btnCancel As Button
End Class
