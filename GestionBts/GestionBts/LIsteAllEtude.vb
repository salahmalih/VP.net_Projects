Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class LIsteAllEtude
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Sub afichelisteEt()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "SELECT *, NomBrancheFR FROM Scol_Etudiant, Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche "
            dr = cmd.ExecuteReader
            datagrideEtudiant.Rows.Clear()
            While dr.Read = True
                datagrideEtudiant.Rows.Add(dr(0).Trim, dr(1).Trim, dr(2).Trim, dr(3).Trim, dr(4).Trim, dr(5), dr(6).Trim, dr(7).Trim, dr(8), dr(9).Trim, dr("NomBrancheFR"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub

    Private Sub LIsteAllEtude_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        afichelisteEt()
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

        End If
        If datagrideEtudiant.Columns(e.ColumnIndex).Name = "supp" Then
            Dim txt_ma As String
            txt_ma = datagrideEtudiant.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  Scol_Etudiant,Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche and CodeMassar='" & txt_ma & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichelisteEt()

        ElseIf datagrideEtudiant.Columns(e.ColumnIndex).Name = "edite" Then
            AjouterE.txtcin.Text = datagrideEtudiant.CurrentRow.Cells("NCin").Value().Trim
            AjouterE.txtmasare.Text = datagrideEtudiant.CurrentRow.Cells("CodeMassar").Value().Trim
            AjouterE.txtnom.Text = datagrideEtudiant.CurrentRow.Cells("Nom").Value().Trim
            AjouterE.txtprenom.Text = datagrideEtudiant.CurrentRow.Cells("Prenom").Value().Trim
            If datagrideEtudiant.CurrentRow.Cells("Sexe").Value() = "Garcon" Then
                AjouterE.btngarcon.Checked = True
            Else
                AjouterE.btnfille.Checked = True
            End If
            AjouterE.Guna2DateTimePicker1.Value = datagrideEtudiant.CurrentRow.Cells("DateNaissance").Value()
            AjouterE.txtadress.Text = datagrideEtudiant.CurrentRow.Cells("Adresse").Value().Trim
            AjouterE.txtEmail.Text = datagrideEtudiant.CurrentRow.Cells("Email").Value().Trim
            AjouterE.cmblieu.Text = datagrideEtudiant.CurrentRow.Cells("Lieunaissance").Value()
            AjouterE.cmbBranche.Text = datagrideEtudiant.CurrentRow.Cells("branche").Value()
            AjouterE.txtTel.Text = datagrideEtudiant.CurrentRow.Cells("Telephone").Value()
            AjouterE.btnUpdate.Visible = True
            AjouterE.btnAjouter.Visible = False
            Display.btnAjouteremet.PerformClick()
        End If

    End Sub
    Private Sub txtRech_TextChanged(sender As Object, e As EventArgs) Handles txtRech.TextChanged
        If txtRech.Text > "" Then



            If txtRech.PlaceholderText = "Rechercher par CIN" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select * from Scol_Etudiant,Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche and NCin like '%" & txtRech.Text & "%'"
                    dr = cmd.ExecuteReader
                    datagrideEtudiant.Rows.Clear()
                    While dr.Read = True
                        datagrideEtudiant.Rows.Add(dr(0).Trim, dr(1).Trim, dr(2).Trim, dr(3).Trim, dr(4).Trim, dr(5), dr(6).Trim, dr(7).Trim, dr(8), dr(9).Trim, dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()

            ElseIf txtRech.PlaceholderText = "Rechercher par Code Massar" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select * from Scol_Etudiant,Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche and CodeMassar like '%" & txtRech.Text & "%' "
                    dr = cmd.ExecuteReader
                    datagrideEtudiant.Rows.Clear()
                    While dr.Read = True
                        datagrideEtudiant.Rows.Add(dr(0).Trim, dr(1).Trim, dr(2).Trim, dr(3).Trim, dr(4).Trim, dr(5), dr(6).Trim, dr(7).Trim, dr(8), dr(9).Trim, dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par Prenom" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select * from Scol_Etudiant,Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche and Prenom like '%" & txtRech.Text & "%' "
                    dr = cmd.ExecuteReader
                    datagrideEtudiant.Rows.Clear()
                    While dr.Read = True
                        datagrideEtudiant.Rows.Add(dr(0).Trim, dr(1).Trim, dr(2).Trim, dr(3).Trim, dr(4).Trim, dr(5), dr(6).Trim, dr(7).Trim, dr(8), dr(9).Trim, dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par brancher" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select * from Scol_Etudiant,Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche and NomBrancheFR like '%" & txtRech.Text & "%' "
                    dr = cmd.ExecuteReader
                    datagrideEtudiant.Rows.Clear()
                    While dr.Read = True
                        datagrideEtudiant.Rows.Add(dr(0).Trim, dr(1).Trim, dr(2).Trim, dr(3).Trim, dr(4).Trim, dr(5), dr(6).Trim, dr(7).Trim, dr(8), dr(9).Trim, dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            ElseIf txtRech.PlaceholderText = "Rechercher par Nom" Then
                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "select * from Scol_Etudiant,Scol_Branche WHERE Scol_Etudiant.IDbranche = Scol_Branche.IDbranche and Nom like '%" & txtRech.Text & "%'"
                    dr = cmd.ExecuteReader
                    datagrideEtudiant.Rows.Clear()
                    While dr.Read = True
                        datagrideEtudiant.Rows.Add(dr(0).Trim, dr(1).Trim, dr(2).Trim, dr(3).Trim, dr(4).Trim, dr(5), dr(6).Trim, dr(7).Trim, dr(8), dr(9).Trim, dr("NomBrancheFR"))
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                co.Close()
            End If


        End If
    End Sub
End Class