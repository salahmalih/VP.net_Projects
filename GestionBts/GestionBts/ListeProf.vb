Imports System.Data.SqlClient
Imports System.Xml
Imports Guna.UI2.WinForms

Public Class ListeProf
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Sub afichelisteProf()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "SELECT * FROM Scol_TEmployes"
            dr = cmd.ExecuteReader
            datagrideListeProf.Rows.Clear()
            While dr.Read = True
                datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub

    Private Sub ListeProf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        afichelisteProf()
        txtRech.PlaceholderText = "Rechercher par  DRPP"
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtRech.TextChanged
        If txtRech.Text > "" Then



            If txtRech.PlaceholderText = "Rechercher par CIN" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where CIN='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    datagrideListeProf.Rows.Clear()
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par  DRPP" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where DRPP='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    datagrideListeProf.Rows.Clear()
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par Code Massar" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where CodeMassar='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par  Nom" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where Nom='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    datagrideListeProf.Rows.Clear()
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par  Prenom" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where Prenom='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    datagrideListeProf.Rows.Clear()
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par  Diplome" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where Diplome='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    datagrideListeProf.Rows.Clear()
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par  Module" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "SELECT * FROM Scol_TEmployes where Module='" & txtRech.Text & "'"
                    dr = cmd.ExecuteReader
                    datagrideListeProf.Rows.Clear()
                    While dr.Read = True
                        datagrideListeProf.Rows.Add(dr("DRPP"), dr("Dossier").Trim(), dr("Echelle").Trim(), dr("CodeMassar").Trim(), dr("CIN").Trim(), dr("Nom").Trim(), dr("Prenom").Trim(), dr("DateNaissance"), dr("Ville").Trim(), dr("LieuNaissance").Trim(), dr("Nationalite").Trim(), dr("Adresse").Trim(), dr("Sexe").Trim(), dr("DateEmbauche"), dr("DateSortie"), dr("DateFinContrat"), dr("NiveauEtudes").Trim(), dr("NCompte").Trim(), dr("Tel"), dr("Email").Trim(), dr("NumeroCNSS").Trim(), dr("Diplome").Trim(), dr("Module").Trim())
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            End If
        End If

    End Sub

    Private Sub datagrideListeProf_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrideListeProf.CellContentClick
        If datagrideListeProf.Columns(e.ColumnIndex).Name = "Drpp1" Then
            txtRech.PlaceholderText = "Rechercher par  DRPP"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Codemassar1" Then
            txtRech.PlaceholderText = "Rechercher par Code Massar"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Dossier1" Then
            txtRech.PlaceholderText = "Rechercher par Dossier"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Echelle1" Then
            txtRech.PlaceholderText = "Rechercher par Echelle"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Cin1" Then
            txtRech.PlaceholderText = "Rechercher par  CIN"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "nom1" Then
            txtRech.PlaceholderText = "Rechercher par  Nom"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Prenom1" Then
            txtRech.PlaceholderText = "Rechercher par  Prenom"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Diplome1" Then
            txtRech.PlaceholderText = "Rechercher par  Diplome"
        ElseIf datagrideListeProf.Columns(e.ColumnIndex).Name = "Module" Then
            txtRech.PlaceholderText = "Rechercher par  Module"
        End If
        If datagrideListeProf.Columns(e.ColumnIndex).Name = "supp01" Then
            Dim txt As String
            txt = datagrideListeProf.CurrentRow.Cells("Drpp1").Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "DELETE FROM [dbo].[Scol_TEmployes] WHERE Scol_TEmployes.DRPP =" & txt & ""

                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelisteProf()
        End If
        If datagrideListeProf.Columns(e.ColumnIndex).Name = "edit1" Then
            With AjouterProf
                .txtDRPP.Text = datagrideListeProf.CurrentRow.Cells("Drpp1").Value()
                .txtDossier.Text = datagrideListeProf.CurrentRow.Cells("Dossier1").Value().Trim()
                .txtEchelle.Text = datagrideListeProf.CurrentRow.Cells("Echelle1").Value().Trim()
                .txtmasare.Text = datagrideListeProf.CurrentRow.Cells("CodeMassar1").Value().Trim()
                .txtcin.Text = datagrideListeProf.CurrentRow.Cells("Cin1").Value().Trim()
                .txtnom.Text = datagrideListeProf.CurrentRow.Cells("nom1").Value().Trim()
                .txtprenom.Text = datagrideListeProf.CurrentRow.Cells("Prenom1").Value().Trim()
                .Guna2DateTimePicker1.Value = CDate(datagrideListeProf.CurrentRow.Cells("DateNaissance1").Value())
                .txtVille.Text = datagrideListeProf.CurrentRow.Cells("ville1").Value().Trim()
                .cmblieu.Text = datagrideListeProf.CurrentRow.Cells("lieunaissance1").Value().Trim()
                If datagrideListeProf.CurrentRow.Cells("Sexe1").Value() = "Garcon" Then
                    .btngarcon.Checked = True
                ElseIf datagrideListeProf.CurrentRow.Cells("Sexe1").Value() = "Fille" Then
                    .btnfille.Checked = True
                End If
                .txtNationalite.Text = datagrideListeProf.CurrentRow.Cells("Nationalite1").Value().Trim()
                .txtadress.Text = datagrideListeProf.CurrentRow.Cells("Adresse1").Value().Trim()
                .DateEmbauche.Value = CDate(datagrideListeProf.CurrentRow.Cells("DateEmbauche1").Value())
                .DateSortie.Value = CDate(datagrideListeProf.CurrentRow.Cells("DateSortie1").Value())
                .DateFinContrat.Value = CDate(datagrideListeProf.CurrentRow.Cells("DateFinContrat1").Value())
                .txtNiveauEtudes.Text = datagrideListeProf.CurrentRow.Cells("NiveauEtudes1").Value().Trim()
                .txtNCompte.Text = datagrideListeProf.CurrentRow.Cells("NCompte1").Value().Trim()
                .txtTel.Text = datagrideListeProf.CurrentRow.Cells("Tel1").Value()
                .txtEmail.Text = datagrideListeProf.CurrentRow.Cells("Email1").Value().Trim()
                .txtDiplome.Text = datagrideListeProf.CurrentRow.Cells("Diplome1").Value().Trim()
                .txtModule.Text = datagrideListeProf.CurrentRow.Cells("Module1").Value().Trim()
                .txtNumeroCNSS.Text = datagrideListeProf.CurrentRow.Cells("NumeroCNSS1").Value().Trim()
                .btnAjouter.Visible = False
                .btnupda.Visible = True
            End With
            Display.Btnajouterprof.PerformClick()

        End If
    End Sub
End Class