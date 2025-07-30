<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Me.lblServer = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(11, 7)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(54, 34)
        Me.lblServer.TabIndex = 0
        Me.lblServer.Text = "Server:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(11, 36)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(38, 34)
        Me.lblPort.TabIndex = 1
        Me.lblPort.Text = "Port:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(11, 62)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(73, 34)
        Me.lblDatabase.TabIndex = 2
        Me.lblDatabase.Text = "Database:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(11, 89)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(59, 34)
        Me.lblUser.TabIndex = 3
        Me.lblUser.Text = "User ID:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(11, 120)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(73, 34)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(115, 154)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(122, 27)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Test Connection" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(277, 154)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 27)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(115, 7)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(285, 22)
        Me.txtServer.TabIndex = 7
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(115, 36)
        Me.txtPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(285, 22)
        Me.txtPort.TabIndex = 8
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(115, 90)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(285, 22)
        Me.txtUser.TabIndex = 10
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(115, 62)
        Me.txtDatabase.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(285, 22)
        Me.txtDatabase.TabIndex = 9
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(115, 120)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(285, 22)
        Me.txtPassword.TabIndex = 11
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 208)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.lblServer)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblServer As Label
    Friend WithEvents lblPort As Label
    Friend WithEvents lblDatabase As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents btnTest As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtServer As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents txtPassword As TextBox
End Class
