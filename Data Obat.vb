Public Class Data_Obat
    Private Sub Reload()
        txtBentukObat.Clear()
        txtHarga.Clear()
        txtKodeHapus.Clear()
        txtManfaat.Clear()
        txtNamaObat.Clear()
        txtKodeObat.Clear()
    End Sub
    Private Sub GetDataObat()
        oDataObat.getAllData(DataObat)
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        Dashboard_admin.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Login.Show()
        Me.Close()
    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Tambah_User.Show()
        Me.Close()
    End Sub

    Private Sub btnListUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dashboard_admin.Show()
        Me.Close()
    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click
        Data_Pembelian.Show()
        Me.Close()
    End Sub

    Private Sub btmObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmObat.Click

    End Sub

    Private Sub Data_Obat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetDataObat()

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        obat_baru = True
        oDataObat.bentuk = txtBentukObat.Text
        oDataObat.harga = txtHarga.Text
        oDataObat.kode_obat = txtKodeObat.Text
        oDataObat.konsumen = cboKonsumen.Text
        oDataObat.nama = txtNamaObat.Text
        oDataObat.manfaat = txtManfaat.Text
        oDataObat.Simpan()
        Reload()
        GetDataObat()
    End Sub

    Private Sub txtKodeObat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodeObat.KeyDown
        If (e.KeyCode = Keys.Enter And txtKodeObat.Text <> "") Then
            oDataObat.Cariobat(txtKodeObat.Text)
            'txtBentukObat.Text = oDataObat.bentuk
            'txtHarga.Text = oDataObat.harga
            'cboKonsumen.Text = oDataObat.konsumen
            'txtNamaObat.Text = oDataObat.nama
            'txtManfaat.Text = oDataObat.manfaat
            'cboKonsumen.Text = oDataObat.konsumen
        End If
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Reload()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        oDataObat.Hapus(txtKodeHapus.Text)
        oDataObat.kode_obat = txtKodeHapus.Text
        MessageBox.Show("Data Berhasil Dihapus")
        GetDataObat()
        Reload()

    End Sub

    Private Sub ButtonItem5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem5.Click
        Login.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        Tambah_User.Show()
        Me.Close()

    End Sub

    Private Sub RibbonControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonControl1.Click

    End Sub
End Class