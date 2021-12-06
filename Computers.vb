Public Class Computers
    Private Sub C_save_Click(sender As Object, e As EventArgs) Handles C_save.Click
        Dim query As String = String.Empty

        Dim compname As String = crname.Text
        Dim registregno As String = regno.Text

        Dim compSerial As String = crserial.Text
        query &= "INSERT INTO Computers(C_Name,Serial_number,Student_Reg)"
        query &= "VALUES (@C_Name,@Serial_number,@Student_Reg)"


        cm = New OleDb.OleDbCommand

        With cm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = query
            .Parameters.AddWithValue("@C_Name", compname)
            .Parameters.AddWithValue("@Serial_number", compSerial)
            .Parameters.AddWithValue("@Student_Reg", registregno)

        End With
        Try
            If (crname.Text <> Nothing And regno.Text <> Nothing And crserial.Text <> Nothing) Then
                cm.ExecuteNonQuery()
                MsgBox("Well Inserted")
                View()
                crserial.Clear()
                crname.Clear()
                regno.Clear()


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
            sql = "Select * from Computers"
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
    Private Sub crname_TextChanged(sender As Object, e As EventArgs) Handles crname.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub regno_TextChanged(sender As Object, e As EventArgs) Handles regno.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter


    End Sub

    Private Sub Computers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
        View()

    End Sub
    Private Function Search(ByRef serial As String) As List(Of String)
        Dim regno As String = ""
        Dim cname As String = ""
        Dim cserial As String = ""
        Dim data As New List(Of String)()
        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter

            sql = "Select * from Computers WHERE Serial_number='" & serial & "'"
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            While dr.Read()
                cname = dr.GetValue(1)
                cserial = dr.GetValue(2)
                regno = dr.GetValue(3)
                ' MsgBox(regno)
                Console.WriteLine("Value: {0}", regno)
            End While

            data.Add(cname)
            data.Add(cserial)
            data.Add(regno)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        Return data

    End Function
    Sub UpdateComputer(ByRef compname As String, ByRef serial As String, ByRef searserial As String, ByRef registregno As String)
        Dim sql As String
        Try
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            ' MsgBox(s_id)
            sql = "UPDATE Computers SET C_Name='" & compname & "',Serial_number='" & serial & "',Student_Reg='" & registregno & "' WHERE Serial_number='" & searserial & "'"
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

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Dim text As String = searchText.Text
        MsgBox(text)
        ' MsgBox(text)
        Dim data As New List(Of String)()
        data = Search(text)
        If data.ElementAt(0) <> "" And data.ElementAt(0) <> "" Then
            cname.Text = data.ElementAt(0)
            cserial.Text = data.ElementAt(1)
            regRegno.Text = data.ElementAt(2)
            '  MsgBox(data.Count)
        Else
            MsgBox("Unable to find such student!")
            cname.Clear()
            cserial.Clear()

        End If

    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        Dim comp As String = cname.Text
        Dim serial As String = cserial.Text
        Dim serialSearch As String = searchText.Text
        Dim regn As String = regRegno.Text
        UpdateComputer(comp, serial, serialSearch, regn)
        View()

    End Sub
    Private Sub dataGridView1_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            cname.Text = row.Cells(1).Value.ToString
            cserial.Text = row.Cells(2).Value.ToString
            searchText.Text = row.Cells(2).Value.ToString
            regRegno.Text = row.Cells(3).Value.ToString

        End If
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        DeleteStudent(searchText.Text)
    End Sub
    Private Sub DeleteStudent(ByRef serial As String)

        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter

            sql = "DELETE * from Computers WHERE Serial_number='" & serial & "'"
            cm.Connection = cn
            cm.CommandText = sql
            da.SelectCommand = cm
            dr = cm.ExecuteReader
            MsgBox("Student with this serail number" & serial & " is delted!")
            cname.Clear()
            cserial.Clear()
            regRegno.Clear()
            searchText.Clear()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

End Class