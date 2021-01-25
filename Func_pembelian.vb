Public Class Func_pembelian
        Dim strsql As String
        Dim info As String
        Private _kode_pesan As String
        Private _id_pemesan As String
        Private _harga As System.Single
        Private _tanggal As String
        Private _status As String
        Private _konfirmasi As String
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
        Public Property id_pemesan()
            Get
                Return _id_pemesan
            End Get
            Set(ByVal value)
                _id_pemesan = value
            End Set
        End Property
        Public Property harga()
            Get
                Return _harga
            End Get
            Set(ByVal value)
                _harga = value
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
        Public Property konfirmasi()
            Get
                Return _konfirmasi
            End Get
            Set(ByVal value)
                _konfirmasi = value
            End Set
        End Property
        Public Sub Simpan()
            Dim info As String
            DBConnect()
            If (pemesanan_baru = True) Then
                strsql = "Insert into pemesanan(kode_pesan,id_pemesan,harga,tanggal,status,konfirmasi) values ('" & _kode_pesan & "','" & _id_pemesan & "','" & _harga & "','" & _tanggal & "','" & _status & "','" & _konfirmasi & "')"
                info = "INSERT"
            Else
                strsql = "update pemesanan set kode_pesan='" & _kode_pesan & "', id_pemesan='" & _id_pemesan & "', harga='" & _harga & "', tanggal='" & _tanggal & "', status='" & _status & "', konfirmasi='" & _konfirmasi & "' where id_pemesan='" & _id_pemesan & "'"
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
                id_pemesan = Convert.ToString((DR("id_pemesan")))
                harga = Convert.ToString((DR("harga")))
                tanggal = Convert.ToString((DR("tanggal")))
                status = Convert.ToString((DR("status")))
                konfirmasi = Convert.ToString((DR("konfirmasi")))
            Else
                MessageBox.Show("Data Tidak Ditemukan.")
                pemesanan_baru = True
            End If
            DBDisconnect()
        End Sub
        Public Sub Hapus(ByVal skode_pesan As String)
            Dim info As String
            DBConnect()
        strsql = "delete detail_pemesanan, pemesanan, pembeli from detail_pemesanan LEFT join pemesanan on detail_pemesanan.kode_pesan = pemesanan.kode_pesan LEFT join pembeli on pemesanan.id_pemesan = pembeli.id WHERE detail_pemesanan.kode_pesan ='" & skode_pesan & "'"
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
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM master_detail_pemesanan INNER JOIN pemesanan ON master_detail_pemesanan.kode_pesan = pemesanan.kode_pesan"
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
