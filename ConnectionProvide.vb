Imports System.Data.OleDb
Module modConnection

    Public cn As New OleDb.OleDbConnection
    Public cm As New OleDb.OleDbCommand
    Public dr As OleDbDataReader

    Public Sub connection()
        cn = New OleDb.OleDbConnection
        With cn
            .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\Computer_Cheking1.mdb"
            .Open()
        End With
    End Sub
    Public Sub closeConnection()
        cn.Close()
    End Sub
End Module