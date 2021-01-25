Public Class User
    Dim strsql As String
    Dim info As String
    Private _id_admin As Integer
    Private _username As String
    Private _password As String
    Private _password_lama As String
    Private _nama As String
    Private _tingkat As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property password_lama()
        Get
            Return _password_lama
        End Get
        Set(ByVal value)
            _password_lama = value
        End Set
    End Property
    Public Property username()
        Get
            Return _username
        End Get
        Set(ByVal value)
            _username = value
        End Set
    End Property
    Public Property password()
        Get
            Return _password
        End Get
        Set(ByVal value)
            _password = value
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
    Public Property tingkat()
        Get
            Return _tingkat
        End Get
        Set(ByVal value)
            _tingkat = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (admin_baru = True) Then
            strsql = "Insert into admin(username,password,nama,tingkat) values ('" & _username & "','" & _password & "','" & _nama & "','" & _tingkat & "')"
            info = "INSERT"
        Else
            strsql = "update admin set username='" & _username & "', password='" & _password & "', nama='" & _nama & "', tingkat='" & _tingkat & "' where username='" & _username & "'"
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
    Public Sub Update(ByVal suser As String, ByVal supaslama As String, ByVal supassbaru As String)
        Dim pwd_en As String
        pwd_en = getMD5Hash(supaslama)
        Dim pwd_en_baru As String
        pwd_en_baru = getMD5Hash(supassbaru)
        Dim info As String
        DBConnect()
        If (admin_baru = True) Then
            strsql = "update admin set password='" & pwd_en_baru & "' where username='" & suser & "' AND password = " & pwd_en & ""
            info = "INSERT"
        Else
            strsql = "update admin set password='" & pwd_en_baru & "' where username='" & suser & "' AND password = " & pwd_en & ""
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
    Public Sub Cariadmin(ByVal susername As String, ByVal spassword As String)

        DBConnect()
        strsql = "SELECT * FROM admin WHERE username='" & susername & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            admin_baru = False
            DR.Read()
            username = Convert.ToString((DR("username")))
            password = Convert.ToString((DR("password")))
            nama = Convert.ToString((DR("nama")))
            tingkat = Convert.ToString((DR("tingkat")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            admin_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal susername As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM admin WHERE username='" & susername & "'"
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
            strsql = "SELECT * FROM admin"
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
    Public Function Login(ByVal uname As String, ByVal pwd As String) As Boolean
        Dim pwd_en As String
        pwd_en = getMD5Hash(pwd)
        DBConnect()
        strsql = "SELECT * FROM admin WHERE username='" & uname & "' and password ='" & pwd_en & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            login_valid = True
        Else
            login_valid = False
        End If
        DBDisconnect()
        Return login_valid
    End Function

End Class