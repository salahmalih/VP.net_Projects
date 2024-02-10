Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data.OleDb
Imports System.Data
Imports System.Reflection.Metadata.Ecma335

Public Class admin
    Dim co As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" & System.Environment.CurrentDirectory & "\Gestion.accdb; Persist Security Info=False;")
    Dim cmd As New OleDb.OleDbCommand
    Dim rd As OleDb.OleDbDataReader
    Private Sub lblfermer_Click(sender As Object, e As EventArgs) Handles lblfermer.Click
        Close()
    End Sub
    Private Sub lblfermer_MouseHover(sender As Object, e As EventArgs) Handles lblfermer.MouseHover
        ToolTip1.SetToolTip(lblfermer, "Close")
    End Sub

    Private Sub btnhide_Click(sender As Object, e As EventArgs) Handles btnhide.Click
        txtpassw.PasswordChar = "*"
        btnshow.Visible = True
    End Sub
    Private Sub btnhide_MouseHover(sender As Object, e As EventArgs) Handles btnhide.MouseHover
        ToolTip1.SetToolTip(btnhide, "Masquer le mot de passe")
    End Sub
    Private Sub btnshow_Click(sender As Object, e As EventArgs) Handles btnshow.Click
        txtpassw.PasswordChar = ""
        btnshow.Visible = False
    End Sub

    Private Sub btnshow_MouseHover(sender As Object, e As EventArgs) Handles btnshow.MouseHover
        ToolTip1.SetToolTip(btnshow, "Afficher le mot de passe")
    End Sub

    Private Sub txtuser_MouseEnter(sender As Object, e As EventArgs) Handles txtuser.MouseEnter
        If txtuser.Text = "UserName" Then
            txtuser.Text = ""
        End If
    End Sub

    Private Sub txtuser_MouseHover1(sender As Object, e As EventArgs) Handles txtuser.MouseHover
        ToolTip1.SetToolTip(txtuser, "Entrez votre nom d'utilisateur")

    End Sub
    Private Sub txtuser_MouseLeave(sender As Object, e As EventArgs) Handles txtuser.MouseLeave
        If txtuser.Text = "" Then
            txtuser.Text = "UserName"
        End If
    End Sub
    Private Sub txtpassw_MouseEnter(sender As Object, e As EventArgs) Handles txtpassw.MouseEnter
        If txtpassw.Text = "Password" Then
            txtpassw.Text = ""
        End If
    End Sub
    Private Sub txtpassw_MouseHover(sender As Object, e As EventArgs) Handles txtpassw.MouseHover
        ToolTip1.SetToolTip(txtpassw, "tapez votre mot de passe")
    End Sub
    Private Sub txtpassw_MouseLeave(sender As Object, e As EventArgs) Handles txtpassw.MouseLeave
        If txtpassw.Text = "" Then
            txtpassw.Text = "Password"
        End If
    End Sub
    Function cin() As String
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Select CIN From [Employ] Where username='" & txtuser.Text & "'"
            Return cmd.ExecuteScalar
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub Btnlogin_Click_1(sender As Object, e As EventArgs) Handles Btnlogin.Click
        Dim count As Integer
        Try

            If txtuser.Text = "UserName" And txtpassw.Text = "Password" Then

                MsgBox("Veuillez saisir le nom d'utilisateur et le mot de passe corrects", MsgBoxStyle.Exclamation, Title:="Login")
            Else
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "select count(*) from Employ where username='" & txtuser.Text & "' and  password='" & txtpassw.Text & "' "
                count = cmd.ExecuteScalar()
                If (count > 0) Then
                    Gestion.Show()
                    Me.Hide()
                    co.Close()
                    Exit Sub
                End If
                cmd.CommandText = "SELECT count(*) FROM Employ WHERE  [username] ='" & txtuser.Text & "' AND [password]  <>'" & txtpassw.Text & "' "
                count = cmd.ExecuteScalar()
                If (count > 0) Then
                    MsgBox(" Mot de passe incorrect", MsgBoxStyle.Critical, Title:="Login")
                    co.Close()
                    Exit Sub
                End If
                cmd.CommandText = "SELECT count(*) FROM Employ WHERE [username]   <> '" & txtuser.Text & "' AND [password] ='" & txtpassw.Text & "' "
                count = cmd.ExecuteScalar()
                If (count > 0) Then
                    MsgBox("Le nom d'utilisateur est incorrect ", MsgBoxStyle.Critical, Title:="Login")
                    co.Close()
                    Exit Sub
                End If
                cmd.CommandText = "SELECT count(*) FROM Employ  WHERE [username]   <> '" & txtuser.Text & "' AND [password]  <> '" & txtpassw.Text & "' "
                count = cmd.ExecuteScalar()
                If (count > 0) Then
                    MsgBox("Le nom d'utilisateur et le mot de passe sont incorrects", MsgBoxStyle.Critical, Title:="Login")
                    co.Close()
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Login")
        End Try
        co.Close()
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub
End Class
