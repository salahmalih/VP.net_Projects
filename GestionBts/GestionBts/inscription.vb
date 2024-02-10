Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class inscription
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim codemasare As String
    Private Sub inscription_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aficheEtudiant()
        Dim d As Date = DateTime.Now
        Dim a As String = d.Year.ToString + "/" + (d.Year + 1).ToString
        txtannesc.Text = a
    End Sub

    Sub aficheEtudiant()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "SELECT *, NomBrancheFR FROM Scol_Etudiant, Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche AND NOT EXISTS (SELECT CodeMassar FROM Scol_Inscription WHERE Scol_Etudiant.CodeMassar = Scol_Inscription.CodeMassar)"
            dr = cmd.ExecuteReader
            Guna2DataGridView1.Rows.Clear()
            While dr.Read()
                Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub





    Private Sub txtMassare_TextChanged(sender As Object, e As EventArgs) Handles txtMassare.TextChanged
        If txtMassare.Text > "" Then
            If lblEtud.Text = "Code Massar" Then

                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select *,NomBrancheFR from Scol_Etudiant,Scol_Branche where Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  CodeMassar like '%" & txtMassare.Text & "%' AND NOT EXISTS (SELECT CodeMassar FROM Scol_Inscription WHERE Scol_Etudiant.CodeMassar = Scol_Inscription.CodeMassar)"
                    dr = cmd.ExecuteReader
                    Guna2DataGridView1.Rows.Clear()
                    While dr.Read = True
                        codemasare = dr(0)
                        Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()


            ElseIf lblEtud.Text = "CIN" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select *,NomBrancheFR from Scol_Etudiant,Scol_Branche where Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  NCin like '%" & txtMassare.Text & "%' AND NOT EXISTS (SELECT CodeMassar FROM Scol_Inscription WHERE Scol_Etudiant.CodeMassar = Scol_Inscription.CodeMassar)"
                    dr = cmd.ExecuteReader
                    Guna2DataGridView1.Rows.Clear()
                    While dr.Read = True
                        codemasare = dr(0)
                        Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf lblEtud.Text = "Nom" Then
                Try
                    co.Open()
                    cmd.Connection = co

                    cmd.CommandText = "select *,NomBrancheFR from Scol_Etudiant,Scol_Branche where Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Nom like '%" & txtMassare.Text & "%' AND NOT EXISTS (SELECT CodeMassar FROM Scol_Inscription WHERE Scol_Etudiant.CodeMassar = Scol_Inscription.CodeMassar)"
                    dr = cmd.ExecuteReader
                    Guna2DataGridView1.Rows.Clear()
                    While dr.Read = True
                        codemasare = dr(0)
                        Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf lblEtud.Text = "brancher" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select *,NomBrancheFR from Scol_Etudiant,Scol_Branche where Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and NomBrancheFR like '%" & txtMassare.Text & "%' AND NOT EXISTS (SELECT CodeMassar FROM Scol_Inscription WHERE Scol_Etudiant.CodeMassar = Scol_Inscription.CodeMassar)"
                    dr = cmd.ExecuteReader
                    Guna2DataGridView1.Rows.Clear()
                    While dr.Read = True
                        codemasare = dr(0)
                        Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()


            ElseIf lblEtud.Text = "Prenom" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select *,NomBrancheFR from Scol_Etudiant,Scol_Branche where Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and Prenom like '%" & txtMassare.Text & "%' AND NOT EXISTS (SELECT CodeMassar FROM Scol_Inscription WHERE Scol_Etudiant.CodeMassar = Scol_Inscription.CodeMassar)"
                    dr = cmd.ExecuteReader
                    Guna2DataGridView1.Rows.Clear()
                    While dr.Read = True
                        codemasare = dr(0)
                        Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()

            End If


        End If
    End Sub



    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick

        If Guna2DataGridView1.Columns(e.ColumnIndex).Name = "NCin" Then
            lblEtud.Text = "CIN"
            aficheEtudiant()

        ElseIf Guna2DataGridView1.Columns(e.ColumnIndex).Name = "CodeMassar" Then
            lblEtud.Text = "Code Massar"
            aficheEtudiant()

        ElseIf Guna2DataGridView1.Columns(e.ColumnIndex).Name = "Nom" Then
            lblEtud.Text = "Nom"
            aficheEtudiant()

        ElseIf Guna2DataGridView1.Columns(e.ColumnIndex).Name = "Prenom" Then
            lblEtud.Text = "Prenom"
            aficheEtudiant()

        ElseIf Guna2DataGridView1.Columns(e.ColumnIndex).Name = "branche" Then
            lblEtud.Text = "brancher"
            aficheEtudiant()

        End If




        If Guna2DataGridView1.Columns(e.ColumnIndex).Name = "supp" Then
            Dim txt_CodeMassar As String
            txt_CodeMassar = Guna2DataGridView1.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  Scol_Etudiant where CodeMassar='" & txt_CodeMassar & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            aficheEtudiant()

        ElseIf Guna2DataGridView1.Columns(e.ColumnIndex).Name = "edite" Then
            AjouterE.txtcin.Text = Guna2DataGridView1.CurrentRow.Cells("NCin").Value().Trim
            AjouterE.txtmasare.Text = Guna2DataGridView1.CurrentRow.Cells("CodeMassar").Value().Trim
            AjouterE.txtnom.Text = Guna2DataGridView1.CurrentRow.Cells("Nom").Value().Trim
            AjouterE.txtprenom.Text = Guna2DataGridView1.CurrentRow.Cells("Prenom").Value().Trim
            If Guna2DataGridView1.CurrentRow.Cells("Sexe").Value() = "Garcon" Then
                AjouterE.btngarcon.Checked = True
            Else
                AjouterE.btnfille.Checked = True
            End If
            AjouterE.Guna2DateTimePicker1.Value = Guna2DataGridView1.CurrentRow.Cells("DateNaissance").Value()
            AjouterE.txtadress.Text = Guna2DataGridView1.CurrentRow.Cells("Adresse").Value().Trim
            AjouterE.txtEmail.Text = Guna2DataGridView1.CurrentRow.Cells("Email").Value().Trim
            AjouterE.cmblieu.Text = Guna2DataGridView1.CurrentRow.Cells("Lieunaissance").Value()
            AjouterE.cmbBranche.Text = Guna2DataGridView1.CurrentRow.Cells("branche").Value().Trim()
            AjouterE.txtTel.Text = Guna2DataGridView1.CurrentRow.Cells("Telephone").Value()
            AjouterE.btnUpdate.Visible = True
            AjouterE.btnAjouter.Visible = False
            Display.btnAjouteremet.PerformClick()
        End If
    End Sub

    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click

        If Guna2DataGridView1.CurrentRow.Cells(0).Selected Then
            Try
                co.Open()
                cmd.Connection = co
                codemasare = Guna2DataGridView1.CurrentRow.Cells(0).Value()
                cmd.CommandText = "Insert into Scol_Inscription Values('" & codemasare & "','" & txtannesc.Text & "','" & dateInscription.Value & "')"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            ListeEtd.afichelisteEt()
            aficheEtudiant()
        Else
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Insert into Scol_Inscription Values('" & codemasare & "','" & txtannesc.Text & "','" & dateInscription.Value & "')"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            ListeEtd.afichelisteEt()
            aficheEtudiant()
        End If

    End Sub
    Public num As Integer
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            co.Open()
            cmd.Connection = co

            cmd.CommandText = "Update  Scol_Inscription set CodeMassar='" & codemasare & "',AnneeScolaire='" & txtannesc.Text & "', Dateinscription='" & dateInscription.Value & "' where Numero=" & num & ""
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
        ListeEtd.afichelisteEt()
        aficheEtudiant()
        btnUpdate.Visible = False
        btnValider.Visible = True
        btnEffacer.PerformClick()
    End Sub

    Private Sub btnEffacer_Click(sender As Object, e As EventArgs) Handles btnEffacer.Click
        Dim d As Date = DateTime.Now
        Dim a As String = d.Year.ToString + "/" + (d.Year + 1).ToString
        txtannesc.Text = a
        txtMassare.Text = ""

        dateInscription.Value = DateTime.Now
    End Sub

    Private Sub Guna2DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentDoubleClick
        If lblEtud.Text = "Code Massar" Then
            If Guna2DataGridView1.SelectedCells(0).Selected = True Then
                txtMassare.Text = Guna2DataGridView1.SelectedCells(0).Value.trim
            End If

        ElseIf lblEtud.Text = "CIN" Then
            If Guna2DataGridView1.SelectedCells(1).Selected = True Then
                txtMassare.Text = Guna2DataGridView1.SelectedCells(1).Value.trim
            End If

        ElseIf lblEtud.Text = "Nom" Then
            If Guna2DataGridView1.SelectedCells(2).Selected = True Then
                txtMassare.Text = Guna2DataGridView1.SelectedCells(2).Value.trim
            End If

        ElseIf lblEtud.Text = "brancher" Then
            If Guna2DataGridView1.SelectedCells(10).Selected = True Then
                txtMassare.Text = Guna2DataGridView1.SelectedCells(10).Value.trim
            End If


        ElseIf lblEtud.Text = "Prenom" Then
            If Guna2DataGridView1.SelectedCells(3).Selected = True Then
                txtMassare.Text = Guna2DataGridView1.SelectedCells(3).Value.trim
            End If

        End If
    End Sub
End Class