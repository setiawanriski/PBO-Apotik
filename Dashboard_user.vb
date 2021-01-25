Public Class Dashboard_user


    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btmLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmLogout.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub ButtonItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
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
End Class