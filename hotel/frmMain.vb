Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- 1. Set Dynamic Titles and Status ---
        Me.Text = $"{modDB.GetHotelName()} - Main Menu"
        tsslUser.Text = $"User: {modDB.LoggedInUser.FullName}"
        tsslRole.Text = $"Role: {modDB.LoggedInUser.RoleName}"

        ' --- 2. Set Permissions Based on Role ---
        If modDB.LoggedInUser.RoleName.ToLower() = "staff" Then
            ' Hide admin-only menu items for staff users
            ManagementToolStripMenuItem.Visible = False
            ActivityLogToolStripMenuItem.Visible = False
        End If

        ' --- 3. Load the Dashboard by Default ---
        ShowForm(New frmDashboard())
    End Sub

    ''' <summary>
    ''' A helper method to show a form within the MDI container, ensuring only one instance is open.
    ''' </summary>
    ''' <param name="formToShow">An instance of the form you want to display.</param>
    Private Sub ShowForm(ByVal formToShow As Form)
        ' Check if a form of this type is already open
        For Each frm As Form In Me.MdiChildren
            If frm.GetType() = formToShow.GetType() Then
                frm.Activate() ' If it is, just bring it to the front
                Return
            End If
        Next

        ' If not open, set it as a child of this MDI form and show it
        formToShow.MdiParent = Me
        formToShow.Show()
    End Sub

#Region "Menu Click Events"

    ' --- File Menu ---
    Private Sub logoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles logoutToolStripMenuItem.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            modDB.Logs("Logout", "Authentication", $"User '{modDB.LoggedInUser.Username}' logged out.")
            ' Close all open child forms
            For Each frm As Form In Me.MdiChildren
                frm.Close()
            Next
            ' Show the login form again
            Dim loginForm As New frmLogin()
            loginForm.Show()
            Me.Close() ' Close this main form
        End If
    End Sub

    Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
        If MsgBox("Are you sure you want to exit the application?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' --- Main Feature Menus ---
    Private Sub dashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        ShowForm(New frmDashboard())
    End Sub

    Private Sub walkinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WalkinToolStripMenuItem.Click
        ShowForm(New frmWalkin())
    End Sub

    Private Sub reportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        ' We will create frmReports in a future step
        MsgBox("frmReports will be created in a future step.", MsgBoxStyle.Information)
    End Sub

    ' --- Management Menu (Admin Only) ---
    Private Sub hotelSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HotelSettingsToolStripMenuItem.Click
        ' Open settings as a Dialog to ensure user saves or cancels before continuing.
        Dim frm As New frmHotelSettings()
        frm.ShowDialog()
    End Sub

    ''' <summary>
    ''' This is the new event handler for the "Addons" menu item.
    ''' </summary>
    Private Sub addonsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddonsToolStripMenuItem.Click
        Dim frm As New frmAddonManagement()
        frm.ShowDialog()
    End Sub

    Private Sub ssMain_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ssMain.ItemClicked

    End Sub

    ' Note: The click events for the other management menu items will be added here as we build them.

#End Region

End Class
