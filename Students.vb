Imports System.Data.SqlClient

Public Class Students

    Private Sub st_save_Click(sender As Object, e As EventArgs) Handles st_save.Click
        Dim query As String = String.Empty

        Dim strsName As String = sname.Text

        Dim strReg As String = regno.Text
        query &= "INSERT INTO Student(St_name,Regno)"
        query &= "VALUES (@St_name,@Regno)"


        cm = New OleDb.OleDbCommand

        With cm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = query
            .Parameters.AddWithValue("@St_name", strsName)
            .Parameters.AddWithValue("@Regno", strReg)

        End With
        Try
            If (regno.Text <> Nothing And sname.Text <> Nothing) Then
                cm.ExecuteNonQuery()
                MsgBox("Well Inserted")
                View()
                sname.Clear()
                regno.Clear()

            Else
                MsgBox("Please fill all info")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Message")
        End Try
    End Sub

    Private Sub Students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
        View()
    End Sub

    Private Sub reset_Click(sender As Object, e As EventArgs) Handles reset.Click
        sname.Clear()
        regno.Clear()

    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Dim text As String = searchText.Text

        ' MsgBox(text)
        Dim data As New List(Of String)()
        data = Search(text)
        If data.ElementAt(0) <> "" And data.ElementAt(0) <> "" Then
            search_name.Text = data.ElementAt(0)
            search_reg.Text = data.ElementAt(1)
            '  MsgBox(data.Count)
        Else
            MsgBox("Unable to find such student!")
            search_name.Clear()
            search_reg.Clear()

        End If





    End Sub
    Private Sub dataGridView1_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            search_name.Text = row.Cells(1).Value.ToString
            search_reg.Text = row.Cells(2).Value.ToString
            searchText.Text = row.Cells(2).Value.ToString

        End If
    End Sub
    Private Sub ViewSt_Click(sender As Object, e As EventArgs) Handles ViewSt.Click
        View()
    End Sub
    Private Sub View()
        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            sql = "Select * from Student"
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
    Private Function Search(ByRef reg As String) As List(Of String)
        Dim regno As String = ""
        Dim sname As String = ""
        Dim data As New List(Of String)()
        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter

            sql = "Select * from Student WHERE Regno='" & reg & "'"
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            While dr.Read()
                sname = dr.GetValue(1)
                regno = dr.GetValue(2)
                ' MsgBox(regno)
                Console.WriteLine("Value: {0}", regno)
            End While

            data.Add(sname)
            data.Add(regno)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        Return data

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        actionsReset()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles delete.Click

        DeleteStudent(searchText.Text)
        View()
        actionsReset()

    End Sub
    Private Sub DeleteStudent(ByRef reg As String)

        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter

            sql = "DELETE * from Student WHERE Regno='" & reg & "'"
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            MsgBox("Student with this reg number" & reg & " is delted!")
            search_reg.Clear()
            search_name.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub


    Sub UpdateStudent(ByRef reg As String, ByRef sname As String, ByRef regno As String)
        Dim sql As String
        Try
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter

            sql = "UPDATE Student SET Regno='" & regno & "',St_name='" & sname & "' WHERE Regno='" & reg & "'"
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            MsgBox("Student with this reg number" & reg & " is updated!")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        'search_reg.Enabled = False
        UpdateStudent(searchText.Text, search_name.Text, search_reg.Text)
        View()
        actionsReset()
    End Sub
    Sub actionsReset()
        search_reg.Clear()
        search_name.Clear()
        searchText.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class