<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivityLog
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnApplyFilter = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dgvLogs = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnApplyFilter)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpEndDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpStartDate)
        Me.Panel1.Controls.Add(Me.lblStartDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1878, 123)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 36)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Activity Logs"
        '
        'btnApplyFilter
        '
        Me.btnApplyFilter.Location = New System.Drawing.Point(1047, 72)
        Me.btnApplyFilter.Name = "btnApplyFilter"
        Me.btnApplyFilter.Size = New System.Drawing.Size(75, 32)
        Me.btnApplyFilter.TabIndex = 7
        Me.btnApplyFilter.Text = "Apply Filter" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnApplyFilter.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(783, 75)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(258, 26)
        Me.txtSearch.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(652, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 40)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Search Details:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(430, 75)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 26)
        Me.dtpEndDate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(330, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 40)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "End Date:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(100, 75)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 26)
        Me.dtpStartDate.TabIndex = 2
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(3, 75)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(91, 20)
        Me.lblStartDate.TabIndex = 1
        Me.lblStartDate.Text = "Start Date:"
        '
        'dgvLogs
        '
        Me.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLogs.Location = New System.Drawing.Point(0, 123)
        Me.dgvLogs.Name = "dgvLogs"
        Me.dgvLogs.RowHeadersWidth = 51
        Me.dgvLogs.RowTemplate.Height = 28
        Me.dgvLogs.Size = New System.Drawing.Size(1878, 942)
        Me.dgvLogs.TabIndex = 1
        '
        'frmActivityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1878, 1065)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvLogs)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmActivityLog"
        Me.Text = "System Activity Log"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnApplyFilter As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvLogs As DataGridView
End Class
