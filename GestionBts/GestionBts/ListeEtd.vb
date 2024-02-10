Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class ListeEtd
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Private Sub ListeEtd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        datagridelaureats.Visible = False
        datagrideEtudiant.Visible = True
        datagridesuivi.Visible = False
        Btnsuivlaureats.FillColor = Color.FromArgb(109, 214, 203)
        Btnsuivlaureats.ForeColor = Color.White
        btnEtudiante.FillColor = Color.FromArgb(255, 148, 37)
        btnEtudiante.ForeColor = Color.White
        btnLaurets.FillColor = Color.FromArgb(109, 214, 203)
        btnLaurets.ForeColor = Color.White
        afichelisteEt()
        afichelaureat()
        afichesuiv()
    End Sub
    Sub afichelisteEt()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
            dr = cmd.ExecuteReader
            datagrideEtudiant.Rows.Clear()
            While dr.Read = True
                datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub
    Sub afichelaureat()

        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select Scol_Laureats.Matricule,Scol_Laureats.Nom,Scol_Laureats.Ecole,Scol_Laureats.DateEntr,Scol_Laureats.DateSortie from Scol_Laureats where  NOT EXISTS (SELECT * FROM Scol_Suivilaur WHERE  Scol_Suivilaur.Matricule=Scol_Laureats.Matricule)"
            dr = cmd.ExecuteReader
            datagridelaureats.Rows.Clear()
            While dr.Read = True
                datagridelaureats.Rows.Add(dr("Matricule"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()

    End Sub
    Sub afichesuiv()

        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select Scol_Suivilaur.NDossier,Scol_Suivilaur.Nom,Scol_Suivilaur.Ecole,Scol_Suivilaur.DateEntr,Scol_Suivilaur.DateSortie  from Scol_Suivilaur"
            dr = cmd.ExecuteReader
            datagridesuivi.Rows.Clear()
            While dr.Read = True
                datagridesuivi.Rows.Add(dr("NDossier"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()

    End Sub

    Private Sub datagrideEtudiant_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrideEtudiant.CellContentClick
        If datagrideEtudiant.Columns(e.ColumnIndex).Name = "NCin" Then
            txtRech.PlaceholderText = "Rechercher par CIN"
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "CodeMassar" Then
            txtRech.PlaceholderText = "Rechercher par Code Massar"
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "Nom" Then
            txtRech.PlaceholderText = "Rechercher par Nom"
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "Prenom" Then
            txtRech.PlaceholderText = "Rechercher par Prenom"
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "branche" Then
            txtRech.PlaceholderText = "Rechercher par brancher"
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "AnneeScolaire" Then
            txtRech.PlaceholderText = "Rechercher par Annee Scolaire"
            afichelisteEt()
        End If
        If datagrideEtudiant.Columns(e.ColumnIndex).Name = "valider" Then
            Dim txt_CodeMassar As String
            txt_CodeMassar = datagrideEtudiant.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Select * from Scol_Inscription,Scol_Etudiant,Scol_Branche where Scol_Branche.IDbranche=Scol_Etudiant.IDbranche and Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar and Scol_Inscription.CodeMassar ='" & txt_CodeMassar & "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    If dr("Annee") = dr("NbrMaxAnneeF") Then

                        Laureats.txtNumero.Text = dr("Numero")

                        Laureats.txtnom.Text = datagrideEtudiant.CurrentRow.Cells(2).Value().Trim() + " " + datagrideEtudiant.CurrentRow.Cells(3).Value().Trim()

                        Laureats.DateEntrer.Value = dr("Dateinscription")
                        Laureats.Datesortie.Value = DateTime.Now
                        Laureats.Show()
                    Else
                        Dim i As Integer = dr("Annee") + 1
                        Dim s As String = dr("NomDiplome")
                        dr.Close()
                        cmd.CommandText = "Delete from  Scol_Inscription where CodeMassar='" & txt_CodeMassar & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Select * from Scol_Branche where Scol_Branche.NomDiplome='" & s & "' and Annee=" & i & " "
                        dr = cmd.ExecuteReader
                        If dr.Read() Then
                            Dim id = dr("IDbranche")
                            dr.Close()
                            cmd.CommandText = "Update  Scol_Etudiant set IDbranche=" & id & "  where CodeMassar='" & txt_CodeMassar & "' "
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "supp" Then
            Dim txt_ma As String
            txt_ma = datagrideEtudiant.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  Scol_Inscription where CodeMassar='" & txt_ma & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "NonValider" Then
            Dim txt_ma As String
            txt_ma = datagrideEtudiant.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  Scol_Inscription where CodeMassar='" & txt_ma & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelisteEt()
        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "edite" Then
            inscription.btnUpdate.Visible = True
            inscription.btnValider.Visible = False
            inscription.txtMassare.Text = datagrideEtudiant.CurrentRow.Cells(0).Value().Trim()
            inscription.txtannesc.Text = datagrideEtudiant.CurrentRow.Cells("AnneeScolaire").Value().Trim()
            inscription.dateInscription.Value = datagrideEtudiant.CurrentRow.Cells("Dateinscription").Value()
            Try
                co.Open()

                cmd.Connection = co
                cmd.CommandText = "SELECT Numero from Scol_Inscription where CodeMassar='" & datagrideEtudiant.CurrentRow.Cells(0).Value().Trim() & "'"
                Dim num As Integer = cmd.ExecuteScalar
                inscription.num = num
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            Display.btninscription.PerformClick()
        End If

    End Sub

    Private Sub btnLaurets_Click(sender As Object, e As EventArgs) Handles btnLaurets.Click
        datagridelaureats.Visible = True
        datagrideEtudiant.Visible = False
        datagridesuivi.Visible = False
        btnLaurets.FillColor = Color.FromArgb(255, 148, 37)
        btnLaurets.ForeColor = Color.White
        btnEtudiante.FillColor = Color.FromArgb(109, 214, 203)
        btnEtudiante.ForeColor = Color.White
        Btnsuivlaureats.FillColor = Color.FromArgb(109, 214, 203)
        Btnsuivlaureats.ForeColor = Color.White
        txtRech.PlaceholderText = "Rechercher par Matricule"
        afichelaureat()
    End Sub
    Private Sub Btnsuivlaureats_Click(sender As Object, e As EventArgs) Handles Btnsuivlaureats.Click
        datagridesuivi.Visible = True
        datagridelaureats.Visible = False
        datagrideEtudiant.Visible = False
        Btnsuivlaureats.FillColor = Color.FromArgb(255, 148, 37)
        Btnsuivlaureats.ForeColor = Color.White
        btnLaurets.FillColor = Color.FromArgb(109, 214, 203)
        btnLaurets.ForeColor = Color.White
        btnEtudiante.FillColor = Color.FromArgb(109, 214, 203)
        btnEtudiante.ForeColor = Color.White
        txtRech.PlaceholderText = "Rechercher par Number Dossier"
        afichesuiv()
    End Sub
    Private Sub btnEtudiante_Click(sender As Object, e As EventArgs) Handles btnEtudiante.Click
        datagridelaureats.Visible = False
        datagrideEtudiant.Visible = True
        datagridesuivi.Visible = False
        btnEtudiante.FillColor = Color.FromArgb(255, 148, 37)
        btnEtudiante.ForeColor = Color.White
        btnLaurets.FillColor = Color.FromArgb(109, 214, 203)
        btnLaurets.ForeColor = Color.White
        Btnsuivlaureats.FillColor = Color.FromArgb(109, 214, 203)
        Btnsuivlaureats.ForeColor = Color.White
        txtRech.PlaceholderText = "Rechercher par Code Massar"
        afichelisteEt()
    End Sub

    Private Sub txtRech_TextChanged(sender As Object, e As EventArgs) Handles txtRech.TextChanged
        If txtRech.Text > "" Then


            If datagrideEtudiant.Visible = True Then
                If txtRech.PlaceholderText = "Rechercher par CIN" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where NCin like '%" & txtRech.Text & "%'  and  Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
                        dr = cmd.ExecuteReader
                        datagrideEtudiant.Rows.Clear()
                        While dr.Read = True
                            datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()

                ElseIf txtRech.PlaceholderText = "Rechercher par Code Massar" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where Scol_Inscription.CodeMassar like '%" & txtRech.Text & "%'  and  Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
                        dr = cmd.ExecuteReader
                        datagrideEtudiant.Rows.Clear()
                        While dr.Read = True
                            datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Prenom" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where Prenom like '%" & txtRech.Text & "%'  and  Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
                        dr = cmd.ExecuteReader
                        datagrideEtudiant.Rows.Clear()
                        While dr.Read = True
                            datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par brancher" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where NomBrancheFR like '%" & txtRech.Text & "%'  and  Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
                        dr = cmd.ExecuteReader
                        datagrideEtudiant.Rows.Clear()
                        While dr.Read = True
                            datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Nom" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where Nom like '%" & txtRech.Text & "%'  and  Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
                        dr = cmd.ExecuteReader
                        datagrideEtudiant.Rows.Clear()
                        While dr.Read = True
                            datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Annee Scolaire" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select *,NomBrancheFR,Dateinscription,AnneeScolaire from Scol_Etudiant,Scol_Branche,Scol_Inscription where AnneeScolaire like '%" & txtRech.Text & "%'  and  Scol_Etudiant.IDbranche=Scol_Branche.IDbranche and  Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar  AND NOT EXISTS (SELECT Numero FROM Scol_Laureats WHERE Scol_Laureats.Numero = Scol_Inscription.Numero)"
                        dr = cmd.ExecuteReader
                        datagrideEtudiant.Rows.Clear()
                        While dr.Read = True
                            datagrideEtudiant.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr("NomBrancheFR"), dr("Dateinscription"), dr("AnneeScolaire"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                End If
            ElseIf datagridelaureats.Visible = True Then
                If txtRech.PlaceholderText = "Rechercher par Matricule" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * from Scol_Laureats where Matricule like %" & txtRech.Text & "% and  NOT EXISTS (SELECT * FROM Scol_Suivilaur WHERE  Scol_Suivilaur.Matricule=Scol_Laureats.Matricule)"
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("Matricule"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Ecole" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * from Scol_Laureats where Ecole like '%" & txtRech.Text & "%' and  NOT EXISTS (SELECT * FROM Scol_Suivilaur WHERE  Scol_Suivilaur.Matricule=Scol_Laureats.Matricule)"
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("Matricule"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Date Entrer" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * from Scol_Laureats where DateEntr like '%" & txtRech.Text & "%' and  NOT EXISTS (SELECT * FROM Scol_Suivilaur WHERE  Scol_Suivilaur.Matricule=Scol_Laureats.Matricule)"
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("Matricule"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par  Date Sortie" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * from Scol_Laureats where DateSortie like '%" & txtRech.Text & "%' and  NOT EXISTS (SELECT * FROM Scol_Suivilaur WHERE  Scol_Suivilaur.Matricule=Scol_Laureats.Matricule)"
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("Matricule"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Nom Laureats" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * from Scol_Laureats where Scol_Laureats.Nom like '%" & txtRech.Text & "%' and  NOT EXISTS (SELECT * FROM Scol_Suivilaur WHERE  Scol_Suivilaur.Matricule=Scol_Laureats.Matricule)"
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("Matricule"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()

                End If
            ElseIf datagridesuivi.Visible = True Then
                If txtRech.PlaceholderText = "Rechercher par Number Dossier" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * Scol_Suivilaur where NDossier like %" & txtRech.Text & "% "
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("NDossier"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Ecole suivi Laureats" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * Scol_Suivilaur where Ecole like '%" & txtRech.Text & "%' "
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("NDossier"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Nom  suivi Laureats" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * Scol_Suivilaur where Nom like '%" & txtRech.Text & "%' "
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("NDossier"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par Date Entrer suivi Laureats" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * Scol_Suivilaur where DateEntr like '%" & txtRech.Text & "%' "
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("NDossier"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                ElseIf txtRech.PlaceholderText = "Rechercher par  Date Sortie suivi Laureats" Then
                    Try
                        co.Open()
                        cmd.Connection = co
                        cmd.CommandText = "select * Scol_Suivilaur where DateSortie like '%" & txtRech.Text & "%' "
                        dr = cmd.ExecuteReader
                        datagridelaureats.Rows.Clear()
                        While dr.Read = True
                            datagridelaureats.Rows.Add(dr("NDossier"), dr("Nom"), dr("Ecole"), dr("DateEntr"), dr("DateSortie"))
                        End While
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    co.Close()
                End If
            End If

        End If
    End Sub

    Private Sub datagridelaureats_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridelaureats.CellContentClick
        If datagridelaureats.Columns(e.ColumnIndex).Name = "Matricule" Then
            txtRech.PlaceholderText = "Rechercher par Matricule"
            afichelaureat()
        ElseIf datagridelaureats.Columns(e.ColumnIndex).Name = "Ecole" Then
            txtRech.PlaceholderText = "Rechercher par Ecole"
            afichelaureat()
        ElseIf datagridelaureats.Columns(e.ColumnIndex).Name = "Noms" Then
            txtRech.PlaceholderText = "Rechercher par Nom Laureats"
            afichelaureat()
        ElseIf datagridelaureats.Columns(e.ColumnIndex).Name = "DateEntr" Then
            txtRech.PlaceholderText = "Rechercher par Date Entrer"
            afichelaureat()
        ElseIf datagridelaureats.Columns(e.ColumnIndex).Name = "DateSortie" Then
            txtRech.PlaceholderText = "Rechercher par  Date Sortie"
            afichelaureat()
        End If
        If datagridelaureats.Columns(e.ColumnIndex).Name = "Emails" Then
            Dim num As Integer
            num = datagridelaureats.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Select Scol_Etudiant.Email,Scol_Etudiant.Nom,Scol_Etudiant.Prenom from Scol_Laureats,Scol_Inscription,Scol_Etudiant where Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar and Scol_Laureats.Numero=Scol_Inscription.Numero and Scol_Laureats.Matricule =" & num & ""
                dr = cmd.ExecuteReader
                If dr.Read Then
                    EmailSend.txtmsgto.Text = dr("Email").Trim()
                    Dim a As String = dr("Prenom")
                    Dim s As String = dr("Nom")
                    EmailSend.Nom = s.Trim() + " " + a.Trim()
                    EmailSend.Show()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
        End If
        If datagridelaureats.Columns(e.ColumnIndex).Name = "suppe" Then
            Dim txt_matr As String
            txt_matr = datagridelaureats.CurrentRow.Cells("Matricule").Value()

            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from Scol_Laureats where Matricule = " & txt_matr & ""
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelaureat()
        End If
        If datagridelaureats.Columns(e.ColumnIndex).Name = "edits" Then
            Dim txt_matr As Integer
            txt_matr = datagridelaureats.CurrentRow.Cells("Matricule").Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Select *,Scol_Laureats.Nom from Scol_Laureats,Scol_Inscription,Scol_Etudiant where Scol_Etudiant.CodeMassar=Scol_Inscription.CodeMassar and Scol_Laureats.Numero=Scol_Inscription.Numero and Scol_Laureats.Matricule =" & txt_matr & ""
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Laureats.txtNumero.Text = dr("Matricule")
                    Laureats.txtnom.Text = dr("Nom")
                    Laureats.DateEntrer.Value = dr("DateEntr")
                    Laureats.Datesortie.Value = dr("DateSortie")
                    Laureats.Label2.Text = "Matricule"
                    Laureats.BtnUpdate.Visible = True
                    Laureats.btnValider.Visible = False
                    Laureats.Show()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelaureat()
        End If

    End Sub

    Private Sub datagridesuivi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridesuivi.CellContentClick
        If datagridesuivi.Columns(e.ColumnIndex).Name = "NDossier" Then
            txtRech.PlaceholderText = "Rechercher par Number Dossier"
        ElseIf datagridesuivi.Columns(e.ColumnIndex).Name = "Ecolee" Then
            txtRech.PlaceholderText = "Rechercher par Ecole suivi Laureats"
        ElseIf datagridesuivi.Columns(e.ColumnIndex).Name = "Nomm" Then
            txtRech.PlaceholderText = "Rechercher par Nom  suivi Laureats"
        ElseIf datagridesuivi.Columns(e.ColumnIndex).Name = "datentrer" Then
            txtRech.PlaceholderText = "Rechercher par Date Entrer suivi Laureats"
        ElseIf datagridesuivi.Columns(e.ColumnIndex).Name = "datsortie" Then
            txtRech.PlaceholderText = "Rechercher par  Date Sortie suivi Laureats"
        End If
        If datagridesuivi.Columns(e.ColumnIndex).Name = "super0" Then
            Dim txtnum As String
            txtnum = datagridesuivi.CurrentRow.Cells("NDossier").Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from Scol_Suivilaur where NDossier = " & txtnum & ""
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichesuiv()
            afichelaureat()
        End If
        afichesuiv()
    End Sub
End Class