Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Module Mymod
    Public myCommand As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter
    Public myData As New DataTable
    Public DR As MySql.Data.MySqlClient.MySqlDataReader
    Public SQL As String
    Public conn As New MySql.Data.MySqlClient.MySqlConnection
    Public cn As New Connection

    'Tabel Order
    '-------------------------------
    Public obat_detail_baru As Boolean
    Public oDataObat As New dataObat
    '--------------------------------
    Public pemesanan_baru As Boolean
    Public oPembeli As New Func_pembelian

    Public detail_pemesanan_baru As Boolean
    Public oDetailPembeli As New Detail_Pemesanan

    Public trx_baru As Boolean
    Public oTrx As New Func_Pesan

    Public obat_baru As Boolean
    Public oObat As New Obat
    'Tabel User
    '--------------------------------
    Public admin_baru As Boolean
    Public oUser As New User
    '--------------------------------

    Public login_valid As Boolean

    Public nobukti As Double
    Public R As Random = New Random


    Public Sub DBConnect()
        cn.Host = "localhost"
        cn.User = "root"
        cn.Password = "TOOR"
        cn.DatabaseName = "apotek_vbnet"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
    Function GenerateRandomString()
        Dim xCharArray() As Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray
        Dim xNoArray() As Char = "0123456789".ToCharArray
        Dim xGenerator As System.Random = New System.Random()
        Dim xStr As String = String.Empty

        While xStr.Length < 12

            If xGenerator.Next(0, 2) = 0 Then
                xStr &= xCharArray(xGenerator.Next(0, xCharArray.Length))
            Else
                xStr &= xNoArray(xGenerator.Next(0, xNoArray.Length))
            End If

        End While
        Return xStr

    End Function
    Public Function getKodePemesanan()
        Dim res As Double
        res = R.Next(1000000, 9999999)
        Return res
    End Function

End Module
