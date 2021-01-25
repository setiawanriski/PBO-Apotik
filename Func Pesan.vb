Public Class Func_Pesan
    Dim strsql As String
    Dim info As String
    Private _kode_pesan As String
    Private _tanggal As String
    Private _status As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_pesan()
        Get
            Return _kode_pesan
        End Get
        Set(ByVal value)
            _kode_pesan = value
        End Set
    End Property
    Public Property tanggal()
        Get
            Return _tanggal
        End Get
        Set(ByVal value)
            _tanggal = value
        End Set
    End Property
    Public Property status()
        Get
            Return _status
        End Get
        Set(ByVal value)
            _status = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (pemesanan_baru = True) Then
            strsql = "Insert into pemesanan(kode_pesan,tanggal,status) values ('" & _kode_pesan & "','" & _tanggal & "','" & _status & "')"
            info = "INSERT"
        Else
            strsql = "update pemesanan set kode_pesan='" & _kode_pesan & "', tanggal='" & _tanggal & "', status='" & _status & "' where tanggal='" & _tanggal & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Caripemesanan(ByVal skode_pesan As String)
        DBConnect()
        strsql = "SELECT * FROM pemesanan WHERE kode_pesan='" & skode_pesan & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            pemesanan_baru = False
            DR.Read()
            kode_pesan = Convert.ToString((DR("kode_pesan")))
            tanggal = Convert.ToString((DR("tanggal")))
            status = Convert.ToString((DR("status")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            pemesanan_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_pesan As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM pemesanan WHERE kode_pesan='" & skode_pesan & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllDataTrx(ByVal dg As DataGridView, ByVal skode_pesan As String)
        Try
            DBConnect()
            strsql = "SELECT * FROM pemesanan WHERE kode_pesan='" & skode_pesan & "'"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
    Public Sub getAllDataAll(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM pemesanan"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
