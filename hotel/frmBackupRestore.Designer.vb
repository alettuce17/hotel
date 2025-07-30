<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupRestore
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
        Me.gbBackup = New System.Windows.Forms.GroupBox()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtBackupPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.gbBackup.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbBackup
        '
        Me.gbBackup.Controls.Add(Me.btnBackup)
        Me.gbBackup.Controls.Add(Me.btnBrowse)
        Me.gbBackup.Controls.Add(Me.txtBackupPath)
        Me.gbBackup.Controls.Add(Me.Label1)
        Me.gbBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbBackup.Location = New System.Drawing.Point(0, 0)
        Me.gbBackup.Name = "gbBackup"
        Me.gbBackup.Size = New System.Drawing.Size(532, 144)
        Me.gbBackup.TabIndex = 0
        Me.gbBackup.TabStop = False
        Me.gbBackup.Text = "Backup Database" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(145, 87)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(217, 45)
        Me.btnBackup.TabIndex = 3
        Me.btnBackup.Text = "Start Backup"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(445, 34)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 29)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtBackupPath
        '
        Me.txtBackupPath.Location = New System.Drawing.Point(145, 34)
        Me.txtBackupPath.Name = "txtBackupPath"
        Me.txtBackupPath.Size = New System.Drawing.Size(287, 26)
        Me.txtBackupPath.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Save Location:"
        '
        'frmBackupRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 144)
        Me.Controls.Add(Me.gbBackup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackupRestore"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Backup & Restore"
        Me.gbBackup.ResumeLayout(False)
        Me.gbBackup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbBackup As GroupBox
    Friend WithEvents btnBackup As Button
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtBackupPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
