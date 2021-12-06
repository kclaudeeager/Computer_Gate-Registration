Public Class Sites
    Dim id As Integer = Nothing
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub st_save_Click(sender As Object, e As EventArgs) Handles st_save.Click
        Dim query As String = String.Empty

        Dim siteName As String = sname.Text

        Dim address As String = gAddress.Text
        query &= "INSERT INTO Sites(Site_name,Address)"
        query &= "VALUES (@Site_name,@Address)"


        cm = New OleDb.OleDbCommand

        With cm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = query
            .Parameters.AddWithValue("@Site_name", siteName)
            .Parameters.AddWithValue("@Address", address)

        End With
        Try
            If (gAddress.Text <> Nothing And sname.Text <> Nothing) Then
                cm.ExecuteNonQuery()
                MsgBox("Well Inserted")
                View()
                sname.Clear()
                gAddress.Clear()

            Else
                MsgBox("Please fill all info")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Message")
        End Try
    End Sub
    Private Sub View()
        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            sql = "Select * from Sites"
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
    Sub UpdateSite(ByRef sname As String, ByRef address As String, ByRef s_id As String)
        Dim sql As String
        Try
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            ' MsgBox(s_id)
            sql = "UPDATE Sites SET Site_name='" & sname & "',Address='" & address & "' WHERE Site_Id=" & s_id & ""
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            MsgBox("Site is updated!")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub Sites_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
        View()
    End Sub

    Private Sub dataGridView1_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            gname.Text = row.Cells(1).Value.ToString
            gaddre.Text = row.Cells(2).Value.ToString
            id = CInt(row.Cells(0).Value.ToString)


        End If
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If (id <> Nothing) Then
            DeleteSite(id)
            View()

        Else
            MsgBox("Please select any of the sites from the table below!")
        End If

    End Sub
    Private Sub DeleteSite(ByRef s_id As String)

        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter

            sql = "DELETE * from Sites WHERE Site_Id=" & s_id & ""
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            MsgBox("Site is successfully delted!")
            gname.Clear()
            gaddre.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        Dim sitname, address
        sitname = gname.Text
        address = gaddre.Text


        If (id <> Nothing) Then
            UpdateSite(sitname, address, id)
            View()

        Else
            MsgBox("Please select any of the sites from the table below!")
        End If

    End Sub

    Private Sub sname_TextChanged(sender As Object, e As EventArgs) Handles sname.TextChanged

    End Sub
End Class