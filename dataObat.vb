Public Class dataObat
    Dim strsql As String
    Dim info As String
    Private _kode_obat As String
    Private _nama As String
    Private _bentuk As String
    Private _konsumen As String
    Private _manfaat As String
    Private _harga As System.Single
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_obat()
        Get
            Return _kode_obat
        End Get
        Set(ByVal value)
            _kode_obat = value
        End Set
    End Property
    Public Property nama()
        Get
            Return _nama
        End Get
        Set(ByVal value)
            _nama = value
        End Set
    End Property
    Public Property bentuk()
        Get
            Return _bentuk
        End Get
        Set(ByVal value)
            _bentuk = value
        End Set
    End Property
    Public Property konsumen()
        Get
            Return _konsumen
        End Get
        Set(ByVal value)
            _konsumen = value
        End Set
    End Property
    Public Property manfaat()
        Get
            Return _manfaat
        End Get
        Set(ByVal value)
            _manfaat = value
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
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (obat_baru = True) Then
            strsql = "Insert into obat(kode_obat,nama,bentuk,konsumen,manfaat,harga) values ('" & _kode_obat & "','" & _nama & "','" & _bentuk & "','" & _konsumen & "','" & _manfaat & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update obat set kode_obat='" & _kode_obat & "', nama='" & _nama & "', bentuk='" & _bentuk & "', konsumen='" & _konsumen & "', manfaat='" & _manfaat & "', harga='" & _harga & "' where nama='" & _nama & "'"
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
    Public Sub Cariobat(ByVal skode_obat As String)
        DBConnect()
        strsql = "SELECT * FROM obat WHERE kode_obat='" & skode_obat & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            obat_baru = False
            DR.Read()
            kode_obat = Convert.ToString((DR("kode_obat")))
            nama = Convert.ToString((DR("nama")))
            bentuk = Convert.ToString((DR("bentuk")))
            konsumen = Convert.ToString((DR("konsumen")))
            manfaat = Convert.ToString((DR("manfaat")))
            harga = Convert.ToString((DR("harga")))
            MessageBox.Show("Data Sudah Ada")
        Else
            MessageBox.Show("Data Dapat Di Buat.")
            obat_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_obat As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM obat WHERE kode_obat='" & skode_obat & "'"
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
            strsql = "SELECT * FROM obat"
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
