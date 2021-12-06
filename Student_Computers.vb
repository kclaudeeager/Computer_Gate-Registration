Public Class Student_Computers
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Student_Computers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
        View()
    End Sub
    Private Sub View()
        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            sql = "SELECT Student.St_name, Student.Regno, Computers.Serial_number,Computers.C_Name FROM Student INNER JOIN Computers ON Student.Regno = Computers.Student_Reg"
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm

            da.Fill(dt)

            DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
End Class