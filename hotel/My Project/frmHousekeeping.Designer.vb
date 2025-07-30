<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHousekeeping
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
        Me.dgvDirtyRooms = New System.Windows.Forms.DataGridView()
        Me.btnMarkClean = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlPagingUpcoming = New System.Windows.Forms.Panel()
        Me.lblPageInfo = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.btnMarkAllClean = New System.Windows.Forms.Button()
        CType(Me.dgvDirtyRooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPagingUpcoming.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 58)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rooms Requiring Service" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dgvDirtyRooms
        '
        Me.dgvDirtyRooms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDirtyRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDirtyRooms.Location = New System.Drawing.Point(22, 44)
        Me.dgvDirtyRooms.Name = "dgvDirtyRooms"
        Me.dgvDirtyRooms.RowHeadersWidth = 51
        Me.dgvDirtyRooms.RowTemplate.Height = 28
        Me.dgvDirtyRooms.Size = New System.Drawing.Size(1493, 655)
        Me.dgvDirtyRooms.TabIndex = 1
        '
        'btnMarkClean
        '
        Me.btnMarkClean.Location = New System.Drawing.Point(1131, 8)
        Me.btnMarkClean.Name = "btnMarkClean"
        Me.btnMarkClean.Size = New System.Drawing.Size(182, 98)
        Me.btnMarkClean.TabIndex = 2
        Me.btnMarkClean.Text = "Mark Selected as Clean" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMarkClean.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(1353, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(182, 98)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh List"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'pnlPagingUpcoming
        '
        Me.pnlPagingUpcoming.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnMarkAllClean)
        Me.pnlPagingUpcoming.Controls.Add(Me.lblPageInfo)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnMarkClean)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnRefresh)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnLast)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnPrevious)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnNext)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnFirst)
        Me.pnlPagingUpcoming.Controls.Add(Me.btnSearch)
        Me.pnlPagingUpcoming.Controls.Add(Me.txtSearch)
        Me.pnlPagingUpcoming.Controls.Add(Me.lblSearch)
        Me.pnlPagingUpcoming.Location = New System.Drawing.Point(-4, 705)
        Me.pnlPagingUpcoming.Name = "pnlPagingUpcoming"
        Me.pnlPagingUpcoming.Size = New System.Drawing.Size(1535, 109)
        Me.pnlPagingUpcoming.TabIndex = 4
        '
        'lblPageInfo
        '
        Me.lblPageInfo.AutoSize = True
        Me.lblPageInfo.Location = New System.Drawing.Point(789, 45)
        Me.lblPageInfo.Name = "lblPageInfo"
        Me.lblPageInfo.Size = New System.Drawing.Size(145, 58)
        Me.lblPageInfo.TabIndex = 9
        Me.lblPageInfo.Text = "Page 0 of 0" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(1020, 38)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(85, 38)
        Me.btnLast.TabIndex = 8
        Me.btnLast.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(698, 40)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(85, 38)
        Me.btnPrevious.TabIndex = 7
        Me.btnPrevious.Text = "< "
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(929, 38)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(85, 38)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = ">" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(624, 40)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(85, 38)
        Me.btnFirst.TabIndex = 5
        Me.btnFirst.Text = "<< "
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(514, 36)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(108, 38)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(203, 40)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(305, 34)
        Me.txtSearch.TabIndex = 3
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(198, -3)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(233, 58)
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "Search by Room #:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnMarkAllClean
        '
        Me.btnMarkAllClean.Location = New System.Drawing.Point(0, 0)
        Me.btnMarkAllClean.Name = "btnMarkAllClean"
        Me.btnMarkAllClean.Size = New System.Drawing.Size(182, 98)
        Me.btnMarkAllClean.TabIndex = 10
        Me.btnMarkAllClean.Text = "Mark Selected as Clean" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMarkAllClean.UseVisualStyleBackColor = True
        '
        'frmHousekeeping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(15.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1527, 946)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlPagingUpcoming)
        Me.Controls.Add(Me.dgvDirtyRooms)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmHousekeeping"
        Me.Text = "Housekeeping Status"
        CType(Me.dgvDirtyRooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPagingUpcoming.ResumeLayout(False)
        Me.pnlPagingUpcoming.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDirtyRooms As DataGridView
    Friend WithEvents btnMarkClean As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents pnlPagingUpcoming As Panel
    Friend WithEvents lblPageInfo As Label
    Friend WithEvents btnLast As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents btnMarkAllClean As Button
End Class
