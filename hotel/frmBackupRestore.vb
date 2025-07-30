Imports System.IO

Public Class frmBackupRestore

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        ' Open a Save File Dialog to let the user choose where to save the backup
        Using sfd As New SaveFileDialog()
            sfd.Filter = "SQL File (*.sql)|*.sql"
            sfd.Title = "Save Database Backup"
            sfd.FileName = $"hoteldb_backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.sql"

            If sfd.ShowDialog() = DialogResult.OK Then
                txtBackupPath.Text = sfd.FileName
            End If
        End Using
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        If String.IsNullOrWhiteSpace(txtBackupPath.Text) Then
            MsgBox("Please select a location to save the backup file.", MsgBoxStyle.Exclamation, "Input Required")
            Return
        End If

        ' Get database connection details from our config
        Dim dbDetails As Dictionary(Of String, String) = modDB.GetConnectionDetails()
        If dbDetails.Count = 0 Then
            MsgBox("Could not read database connection details from config.txt.", MsgBoxStyle.Critical, "Error")
            Return
        End If

        Dim server As String = dbDetails("server")
        Dim user As String = dbDetails("user")
        Dim password As String = dbDetails("password")
        Dim dbName As String = dbDetails("database")
        Dim backupPath As String = txtBackupPath.Text

        ' --- IMPORTANT: Path to mysqldump.exe ---
        ' This path might need to be changed depending on where MySQL was installed.
        ' Common paths are checked here.
        Dim mysqldumpPath As String = ""
        Dim possiblePaths As String() = {
            "D:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
            "D:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe",
            "D:\xampp\mysql\bin\mysqldump.exe"
        }

        For Each path As String In possiblePaths
            If File.Exists(path) Then
                mysqldumpPath = path
                Exit For
            End If
        Next

        If String.IsNullOrEmpty(mysqldumpPath) Then
            MsgBox("Could not find mysqldump.exe. Please ensure MySQL Server or XAMPP is installed in a standard location, or add the MySQL bin directory to your system's PATH.", MsgBoxStyle.Critical, "Error")
            Return
        End If

        ' Construct the command line arguments for mysqldump
        Dim arguments As String = $"-h {server} -u {user} -p{password} --databases {dbName} --routines --triggers"

        Try
            ' Create a new process to run the command
            Dim proc As New Process()
            proc.StartInfo.FileName = mysqldumpPath
            proc.StartInfo.Arguments = arguments
            proc.StartInfo.UseShellExecute = False
            proc.StartInfo.RedirectStandardOutput = True
            proc.StartInfo.CreateNoWindow = True ' Run in the background

            proc.Start()

            ' Read the output of the command (the SQL dump)
            Dim sqlDump As String = proc.StandardOutput.ReadToEnd()
            proc.WaitForExit()

            ' Write the output to the selected file
            File.WriteAllText(backupPath, sqlDump)

            MsgBox($"Backup completed successfully!{vbCrLf}File saved to: {backupPath}", MsgBoxStyle.Information, "Success")
            modDB.Logs("Database Backup", "Management", $"Database backup created at {backupPath}")
            Me.Close()

        Catch ex As Exception
            MsgBox($"An error occurred during backup: {ex.Message}", MsgBoxStyle.Critical, "Backup Failed")
        End Try
    End Sub

End Class
