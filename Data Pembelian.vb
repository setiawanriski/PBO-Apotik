Public Class Data_Pembelian

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        Dashboard_admin.Show()
        Me.Close()

    End Sub
    Private Sub GetData()
        oPembeli.getAllData(DataBeli)
    End Sub
    Private Sub Reload()
        txtIDPemesanan.Clear()
    End Sub

    Private Sub Data_Pembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        oPembeli.Hapus(txtIDPemesanan.Text)
        oPembeli.id_pemesan = txtIDPemesanan.Text
        Reload()
        GetData()
        MessageBox.Show("Data Berhasil Dihapus")
    End Sub

    Private Sub btnListUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        User_List.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Tambah_User.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Login.Show()
        Me.Close()
    End Sub


    Private Sub btmObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmObat.Click
        Data_Obat.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem5.Click
        Login.Show()
        Me.Close()

    End Sub

    Private Sub ButtonItem4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        Tambah_User.Show()
        Me.Close()

    End Sub

    
End Class