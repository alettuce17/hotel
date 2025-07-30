<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateAccount
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
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(139, 9)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(235, 22)
        Me.txtFirstName.TabIndex = 1
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(139, 37)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(235, 22)
        Me.txtLastName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Last Name:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(139, 65)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(235, 22)
        Me.txtEmail.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Email:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(139, 93)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(235, 22)
        Me.txtUsername.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Username:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(139, 121)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(235, 22)
        Me.txtPassword.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Password:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Confirm Password:"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(139, 149)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(235, 22)
        Me.txtConfirmPassword.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(113, 186)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(239, 186)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(135, 23)
        Me.btnCreate.TabIndex = 13
        Me.btnCreate.Text = "Create Account"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'frmCreateAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 219)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCreateAdmin"
        Me.Text = "frmCreateAdmin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCreate As Button
End Class
