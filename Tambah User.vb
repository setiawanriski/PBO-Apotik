Public Class Tambah_User
    Private Sub Reload()
        txtNama.Clear()
        txtPassword.Clear()
        txtUsername.Clear()
        txtUser.Clear()

    End Sub
    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        admin_baru = True
        oUser.Simpan()
        oUser.username = txtNama.Text
        oUser.password = txtPassword.Text
        oUser.nama = txtNama.Text
        oUser.tingkat = cboTingkat.Text
        Reload()
        getData()
    End Sub
    Private Sub getData()
        oUser.getAllData(DataGridView)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        getData()
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        Trx.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click
        Data_Pembelian.Show()
        Me.Close()

    End Sub

    Private Sub btmObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmObat.Click
        Data_Obat.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click

    End Sub

    Private Sub ButtonItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem5.Click
        Login.Show()
        Me.Close()

    End Sub
End Class