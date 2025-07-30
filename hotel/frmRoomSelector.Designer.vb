<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoomSelector
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
        Me.flpRooms = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLegendDirty = New System.Windows.Forms.Label()
        Me.lblLegendOccupied = New System.Windows.Forms.Label()
        Me.lblLegendAvailable = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpRooms
        '
        Me.flpRooms.AutoScroll = True
        Me.flpRooms.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpRooms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpRooms.Location = New System.Drawing.Point(0, 0)
        Me.flpRooms.Name = "flpRooms"
        Me.flpRooms.Size = New System.Drawing.Size(782, 553)
        Me.flpRooms.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblLegendDirty)
        Me.Panel1.Controls.Add(Me.lblLegendOccupied)
        Me.Panel1.Controls.Add(Me.lblLegendAvailable)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 453)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(782, 100)
        Me.Panel1.TabIndex = 1
        '
        'lblLegendDirty
        '
        Me.lblLegendDirty.AutoSize = True
        Me.lblLegendDirty.Location = New System.Drawing.Point(617, 40)
        Me.lblLegendDirty.Name = "lblLegendDirty"
        Me.lblLegendDirty.Size = New System.Drawing.Size(144, 20)
        Me.lblLegendDirty.TabIndex = 2
        Me.lblLegendDirty.Text = "■ Needs Cleaning"
        '
        'lblLegendOccupied
        '
        Me.lblLegendOccupied.AutoSize = True
        Me.lblLegendOccupied.Location = New System.Drawing.Point(345, 40)
        Me.lblLegendOccupied.Name = "lblLegendOccupied"
        Me.lblLegendOccupied.Size = New System.Drawing.Size(97, 20)
        Me.lblLegendOccupied.TabIndex = 1
        Me.lblLegendOccupied.Text = "■ Occupied"
        '
        'lblLegendAvailable
        '
        Me.lblLegendAvailable.AutoSize = True
        Me.lblLegendAvailable.Location = New System.Drawing.Point(36, 37)
        Me.lblLegendAvailable.Name = "lblLegendAvailable"
        Me.lblLegendAvailable.Size = New System.Drawing.Size(93, 20)
        Me.lblLegendAvailable.TabIndex = 0
        Me.lblLegendAvailable.Text = "■ Available"
        '
        'frmRoomSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 553)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.flpRooms)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRoomSelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select a Room"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpRooms As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblLegendDirty As Label
    Friend WithEvents lblLegendOccupied As Label
    Friend WithEvents lblLegendAvailable As Label
End Class
