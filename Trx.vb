Public Class Trx
    Private Sub Reload()
        txtKodePesan.Clear()
        nobukti = getKodePemesanan()
        txtKodePesan.Text = nobukti
    End Sub
    Private Sub GetDataTrx()
        oTrx.getAllDataTrx(DataGridView, txtKodePesan.Text)
    End Sub
    Private Sub Trx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Reload()
    End Sub
    Private Sub SimpanPesan()
        pemesanan_baru = True
        oTrx.kode_pesan = txtKodePesan.Text
        oTrx.tanggal = txtTGL.Text
        oTrx.status = cboStatus.Text
        oTrx.Simpan()
        Detail_Pesanan.Show()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        GetDataTrx()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Reload()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanPesan()
        GetDataTrx()
    End Sub

    Private Sub ButtonItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem5.Click
        Login.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        Tambah_User.Show()
        Me.Close()

    End Sub

    Private Sub btmObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmObat.Click
        Data_Obat.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click
        Data_Pembelian.Show()
        Me.Close()
    End Sub
End Class