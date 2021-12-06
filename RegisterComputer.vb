Public Class RegisterComputer
    Public Shared SiteName, SiteAddress As String

    Private Sub RegisterComputer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()

        FetchSites()
        View()
    End Sub
    Sub FetchSites()

        Dim cname As String = ""
        '  Me.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        'Dim lvi As New ListViewItem
        'Dim data As New List(Of String)()
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

            DataGridView2.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try


    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles serial.TextChanged

    End Sub
    Private Function SearchStudent(ByRef reg As String) As List(Of String)
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

    Private Sub dataGridView2_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            SiteName = row.Cells(1).Value.ToString
            SiteAddress = row.Cells(2).Value.ToString
            'id = CInt(row.Cells(0).Value.ToString)
            'MsgBox(SiteName)

        End If
    End Sub
    Private Sub Comfirm_Click(sender As Object, e As EventArgs) Handles Comfirm.Click
        Dim text As String = serial.Text
        Dim cserial, csreg, cname, sname As String

        'MsgBox(SiteName)
        ' MsgBox(text)
        Dim query As String = String.Empty
        Dim data As New List(Of String)()
        Dim studentdata As New List(Of String)()
        data = Search(text)
        If data.ElementAt(0) <> "" And data.ElementAt(1) <> "" Then
            cname = data.ElementAt(0)
            cserial = data.ElementAt(1)
            csreg = data.ElementAt(2)
            ' MsgBox(csreg)
            studentdata = SearchStudent(csreg)
            If studentdata.ElementAt(0) <> "" Then
                sname = studentdata.ElementAt(0)
                ' MsgBox(sname)

                '  MsgBox(data.Count)
                ' Dim address As String = gAddress.Text
                query &= "INSERT INTO Computers_Gate_Student(GateName,GateAddress,Student_name,Student_Reg,ComputerSerial_number)"
                query &= "VALUES (@GateName,@GateAddress,@Student_name,@Student_Reg,@ComputerSerial_number)"

                cm = New OleDb.OleDbCommand

                With cm
                    .Connection = cn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@GateName", siteName)
                    .Parameters.AddWithValue("@GateAddress", SiteAddress)
                    .Parameters.AddWithValue("@Student_name", sname)
                    .Parameters.AddWithValue("@Student_Reg", csreg)
                    ' .Parameters.AddWithValue("@GateName", SiteName)
                    .Parameters.AddWithValue("@ComputerSerial_number", cserial)
                End With
                Try

                    cm.ExecuteNonQuery()
                    MsgBox("Well Inserted")
                    View()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try
            Else
                MsgBox("No  student found!")
            End If
        Else
            MsgBox("Unable to find such Machine!")

        End If


    End Sub
    Private Sub View()
        Try
            Dim sql As String
            cm = New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            sql = "Select * from Computers_Gate_Student"
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