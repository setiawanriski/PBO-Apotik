Public Class Detail_Pesanan
    Private Sub GetData()
        oDetailPembeli.getAllData(Data, txtKodePesan.Text)
    End Sub
    Private Sub Clear()
        txtHarga.Clear()
        txtKodeObat.Clear()
        txtKodePesan.Clear()
        txtKuantitas.Clear()
        txtNama.Clear()
        txtTotal.Clear()
        txtKodePesan.Text = nobukti
    End Sub
    Private Sub SimpanDetail()
        oDetailPembeli.kode_obat = txtKodeObat.Text
        oDetailPembeli.kode_pesan = txtKodePesan.Text
        oDetailPembeli.jumlah = txtKuantitas.Text
        oDetailPembeli.total = txtTotal.Text
        detail_pemesanan_baru = True
        oDetailPembeli.Simpan()
    End Sub
    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        SimpanDetail()
        Clear()
        GetData()
    End Sub

    Private Sub Detail_Pesanan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Clear()
    End Sub
    Private Sub txtKodeObat_menu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodeObat.KeyDown
        If (e.KeyCode = Keys.Enter And txtKodeObat.Text <> "") Then
            oObat.Cariobat(txtKodeObat.Text)
            txtHarga.Text = oObat.harga
            txtNama.Text = oObat.nama
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim angka1 As Integer
        Dim angka2 As Integer
        Dim hasil As Integer
        angka1 = CDec(txtKuantitas.Text)
        angka2 = CDec(txtHarga.Text)
        hasil = angka1 * angka2
        txtTotal.Text = hasil
    End Sub
End Class