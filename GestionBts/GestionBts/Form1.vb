Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status


Public Class Form1
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles lblhidepass.Click
        txtpassw.PasswordChar = "*"
        lblhidepass.Visible = False
        btnshowpass.Visible = True
    End Sub

    Private Sub btnshowpass_Click(sender As Object, e As EventArgs) Handles btnshowpass.Click
        txtpassw.PasswordChar = ""
        btnshowpass.Visible = False
        lblhidepass.Visible = True
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Select count(*) from login Where username='" & txtuser.Text & "' and passw='" & txtpassw.Text & "'"
            Dim cn As Integer = cmd.ExecuteScalar
            If cn > 0 Then
                Me.Hide()
                Display.Show()
            Else

                cmd.CommandText = "Select count(*)  from login Where username='" & txtuser.Text & "' and passw<>'" & txtpassw.Text & "'"
                cn = cmd.ExecuteScalar
                If cn > 0 Then
                    MsgBox("Mot de passe incorrect", MsgBoxStyle.Critical, Title:="Login")
                Else
                    cmd.CommandText = "Select count(*)  from login Where username<>'" & txtuser.Text & "' and passw='" & txtpassw.Text & "'"
                    cn = cmd.ExecuteScalar
                    If cn > 0 Then
                        MsgBox("Le nom d'utilisateur est incorrect", MsgBoxStyle.Critical, Title:="Login")
                    Else
                        MsgBox("Le nom d'utilisateur et le mot de passe sont incorrects", MsgBoxStyle.Critical, Title:="Login")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Login")
        End Try
        co.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub lblfermer_MouseHover(sender As Object, e As EventArgs) Handles lblfermer.MouseHover
        ToolTip1.SetToolTip(lblfermer, "Fermer")
    End Sub
    Private Sub lblfermer_Click(sender As Object, e As EventArgs) Handles lblfermer.Click
        Close()
    End Sub
End Class
