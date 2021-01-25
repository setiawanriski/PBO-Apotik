Public Class Login

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        login_valid = oUser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            oUser.Cariadmin(txtUsername.Text, txtPassword.Text)
            If (oUser.tingkat = "admin") Then
                MessageBox.Show("Login Berhasil")
                Dashboard_Admin.Show()
                Me.Hide()
            ElseIf (oUser.tingkat = "user") Then
                MessageBox.Show("Login Berhasil")
                Dashboard_user.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
