Imports MySql.Data.MySqlClient
Imports System.IO

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
        ' The Dashboard is still an MDI child, as it's typically a central part of the main menu.
        ShowMdiChildForm(New frmDashboard())
    End Sub

    ''' <summary>
    ''' A helper method to show a form within the MDI container, ensuring only one instance is open.
    ''' This method is now specifically for MDI child forms.
    ''' </summary>
    ''' <param name="formToShow">An instance of the form you want to display.</param>
    Private Sub ShowMdiChildForm(ByVal formToShow As Form)
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
        ShowMdiChildForm(New frmDashboard()) ' Still an MDI child
    End Sub

    Private Sub walkinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WalkinToolStripMenuItem.Click
        ' frmNewReservation should open as a separate, independent window (modal)
        Dim frm As New frmNewReservation()
        frm.ShowDialog() ' Use ShowDialog() for modal, independent window
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

    Private Sub loyaltyTiersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoyaltyTiersToolStripMenuItem.Click
        Dim frm As New frmLoyaltyTiers()
        frm.ShowDialog()
    End Sub
    Private Sub staffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem.Click
        Dim frm As New frmStaffManagement()
        frm.ShowDialog()
    End Sub
    Private Sub guestsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuestsToolStripMenuItem.Click
        Dim frm As New frmGuestManagement()
        frm.ShowDialog()
    End Sub

    Private Sub housekeepingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HousekeepingToolStripMenuItem.Click
        ShowMdiChildForm(New frmHousekeeping()) ' Still an MDI child
    End Sub

    Private Sub ReservationsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReservationsToolStripMenuItem.Click
        ' CHANGE: Open frmReservationManagement as a separate, independent window (modal)
        Dim frm As New frmReservationManagement()
        frm.ShowDialog() ' Use ShowDialog() here
        ' If you want it non-modal (user can interact with frmMain), use frm.Show() instead.
        ' However, ShowDialog() is generally preferred for management forms to prevent
        ' concurrent modifications that might cause data inconsistencies.
    End Sub

    Private Sub reportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        ShowMdiChildForm(New frmReports()) ' Still an MDI child
    End Sub
    Private Sub activityLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivityLogToolStripMenuItem.Click
        ShowMdiChildForm(New frmActivityLog()) ' Still an MDI child
    End Sub
#End Region
    Private Sub backupRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Dim frm As New frmBackupRestore()
        frm.ShowDialog()
    End Sub
    Private Sub bedTypePricingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BedTypePricingToolStripMenuItem.Click
        Dim frm As New frmBedTypes()
        frm.ShowDialog()
    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Optional: show message for debugging
        ' MsgBox("Closing now...")

        ' Ensure all child forms are closed
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next

        ' Optionally force exit
        Application.Exit()
    End Sub

End Class

