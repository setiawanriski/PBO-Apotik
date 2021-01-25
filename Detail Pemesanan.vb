Public Class Detail_Pemesanan
    Dim strsql As String
    Dim info As String
    Private _id As Integer
    Private _kode_pesan As String
    Private _kode_obat As String
    Private _jumlah As Integer
    Private _total As Integer
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
    Public Property kode_obat()
        Get
            Return _kode_obat
        End Get
        Set(ByVal value)
            _kode_obat = value
        End Set
    End Property
    Public Property jumlah()
        Get
            Return _jumlah
        End Get
        Set(ByVal value)
            _jumlah = value
        End Set
    End Property
    Public Property total()
        Get
            Return _total
        End Get
        Set(ByVal value)
            _total = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (detail_pemesanan_baru = True) Then
            strsql = "INSERT INTO `master_detail_pemesanan` (`kode_pesan`, `kode_obat`, `jumlah`, `total`) VALUES ('" & _kode_pesan & "','" & _kode_obat & "','" & _jumlah & "','" & _total & "')"
            info = "INSERT"
        Else
            strsql = "update master_detail_pemesanan set kode_pesan='" & _kode_pesan & "', kode_obat='" & _kode_obat & "', jumlah='" & _jumlah & "', total='" & _total & "' where kode_pesan='" & _kode_pesan & "'"
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

    Public Sub Caridetail_pemesanan(ByVal skode_pesan As String)
        DBConnect()
        strsql = "SELECT * FROM master_detail_pemesanan WHERE kode_pesan='" & skode_pesan & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            detail_pemesanan_baru = False
            DR.Read()
            kode_pesan = Convert.ToString((DR("kode_pesan")))
            kode_obat = Convert.ToString((DR("kode_obat")))
            jumlah = Convert.ToString((DR("jumlah")))
            total = Convert.ToString((DR("total")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            detail_pemesanan_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_pesan As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM master_detail_pemesanan WHERE kode_pesan='" & skode_pesan & "'"
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
    Public Sub getAllData(ByVal dg As DataGridView, ByVal skode_pesan As String)
        Try
            DBConnect()
            strsql = "SELECT * FROM master_detail_pemesanan WHERE kode_pesan='" & skode_pesan & "'"
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
