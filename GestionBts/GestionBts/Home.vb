Imports System.Data.SqlClient

Public Class Home
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Sub nomberEtude()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select count(*) From Scol_Etudiant"
            lblnomberetude.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub
    Sub nomberLaureats()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select count(*) From Scol_Laureats"
            lblnomberlaureats.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub
    Sub nomberprof()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select count(*) From Scol_TEmployes"
            lblnomberprof.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub

    Sub nomberisnsc()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select count(*) From Scol_Inscription"
            lblnomberinscrits.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nomberEtude()
        nomberLaureats()
        nomberprof()
        nomberisnsc()
    End Sub

    Private Sub lblnomberetude_Click(sender As Object, e As EventArgs) Handles lblnomberetude.Click
        Display.click()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Display.click()
    End Sub


    Private Sub Guna2GradientPanel2_Click(sender As Object, e As EventArgs) Handles Guna2GradientPanel2.Click
        Display.click()
    End Sub


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Display.btnlisteEtd.PerformClick()
        ListeEtd.btnLaurets.PerformClick()
    End Sub

    Private Sub lblnomberlaureats_Click(sender As Object, e As EventArgs) Handles lblnomberlaureats.Click
        Display.btnlisteEtd.PerformClick()
        ListeEtd.btnLaurets.PerformClick()
    End Sub

    Private Sub Guna2GradientPanel1_CausesValidationChanged(sender As Object, e As EventArgs) Handles Guna2GradientPanel1.CausesValidationChanged
        Display.btnlisteEtd.PerformClick()
        ListeEtd.btnLaurets.PerformClick()
    End Sub



    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Display.btnlisteEtd.PerformClick()
        ListeEtd.btnEtudiante.PerformClick()
    End Sub

    Private Sub lblnomberinscrits_Click(sender As Object, e As EventArgs) Handles lblnomberinscrits.Click
        Display.btnlisteEtd.PerformClick()
        ListeEtd.btnEtudiante.PerformClick()
    End Sub

    Private Sub Guna2GradientPanel4_Click(sender As Object, e As EventArgs) Handles Guna2GradientPanel4.Click
        Display.btnlisteEtd.PerformClick()
        ListeEtd.btnEtudiante.PerformClick()
    End Sub


    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Display.btnlistePro.PerformClick()
    End Sub

    Private Sub lblnomberprof_Click(sender As Object, e As EventArgs) Handles lblnomberprof.Click
        Display.btnlistePro.PerformClick()
    End Sub

    Private Sub Guna2GradientPanel3_Click(sender As Object, e As EventArgs) Handles Guna2GradientPanel3.Click
        Display.btnlistePro.PerformClick()
    End Sub
End Class