<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lnkCreateAdmin = New System.Windows.Forms.Label()
        Me.lnkCreateStaff = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(116, 59)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(308, 22)
        Me.txtUsername.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(116, 102)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(308, 22)
        Me.txtPassword.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 34)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Username:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 34)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(111, 160)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(312, 26)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Location = New System.Drawing.Point(111, 136)
        Me.chkShowPassword.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(129, 21)
        Me.chkShowPassword.TabIndex = 5
        Me.chkShowPassword.Text = "Show Password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Britannic Bold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(67, 27)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(250, 19)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Grand Hyatt Manila - Staff Portal"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(36, 160)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(69, 26)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lnkCreateAdmin
        '
        Me.lnkCreateAdmin.AutoSize = True
        Me.lnkCreateAdmin.Location = New System.Drawing.Point(255, 188)
        Me.lnkCreateAdmin.Name = "lnkCreateAdmin"
        Me.lnkCreateAdmin.Size = New System.Drawing.Size(168, 17)
        Me.lnkCreateAdmin.TabIndex = 8
        Me.lnkCreateAdmin.Text = "Create an Admin Account"
        '
        'lnkCreateStaff
        '
        Me.lnkCreateStaff.AutoSize = True
        Me.lnkCreateStaff.Location = New System.Drawing.Point(33, 188)
        Me.lnkCreateStaff.Name = "lnkCreateStaff"
        Me.lnkCreateStaff.Size = New System.Drawing.Size(138, 17)
        Me.lnkCreateStaff.TabIndex = 9
        Me.lnkCreateStaff.Text = "Create Staff Account"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(452, 218)
        Me.Controls.Add(Me.lnkCreateStaff)
        Me.Controls.Add(Me.lnkCreateAdmin)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.chkShowPassword)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hotel System Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents lnkCreateAdmin As Label
    Friend WithEvents lnkCreateStaff As Label
End Class
