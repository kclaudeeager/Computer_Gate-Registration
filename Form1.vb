Public Class Form1
    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentsToolStripMenuItem.Click
        Dim student As New Students
        student.Show()
    End Sub

    Private Sub ComputersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComputersToolStripMenuItem.Click
        Dim comp As New Computers
        comp.Show()
    End Sub

    Private Sub SitesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SitesToolStripMenuItem.Click
        Dim site As New Sites
        site.Show()

    End Sub

    Private Sub JointTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JointTableToolStripMenuItem.Click
        Dim Computers_student As New Student_Computers
        Computers_student.Show()
    End Sub

    Private Sub AllInfoviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllInfoviewToolStripMenuItem.Click
        Dim siteComputer As New RegisterComputer
        siteComputer.Show()
    End Sub

    Private Sub ViewAllToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim all As New ViewRegisteredComputers

        all.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
