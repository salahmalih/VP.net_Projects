Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class AjouterProf
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click, Label23.Click

    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        Dim i As String
        If btngarcon.Checked = True Then
            i = "Garcon"

        ElseIf btnfille.Checked = True Then
            i = "Fille"
        End If
        If DateEmbauche.Value > DateSortie.Value Then
            MsgBox("La date Embauche est supérieure à la date de sortie")
        ElseIf DateEmbauche.Value > DateFinContrat.Value Then
            MsgBox("La date Embauche est supérieure à la date de Fin Contrat")
        Else
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "INSERT INTO Scol_TEmployes ([Dossier], [DRPP], [Echelle], [CodeMassar], [CIN], [Nom], [Prenom], [DateNaissance], [Ville], [LieuNaissance], [Nationalite], [Adresse], [Sexe], [DateEmbauche], [DateSortie], [DateFinContrat], [NiveauEtudes], [NCompte], [Tel], [Email], [NumeroCNSS], [Diplome], [Module]) VALUES ('" & txtDossier.Text & "','" & txtDRPP.Text & "','" & txtEchelle.Text & "','" & txtmasare.Text & "','" & txtcin.Text & "','" & txtnom.Text & "','" & txtprenom.Text & "','" & Guna2DateTimePicker1.Value & "','" & txtVille.Text & "','" & cmblieu.Text & "','" & txtNationalite.Text & "','" & txtadress.Text & "','" & i & "','" & DateEmbauche.Value & "','" & DateSortie.Value & "','" & DateFinContrat.Value & "','" & txtNiveauEtudes.Text & "','" & txtNCompte.Text & "','" & txtTel.Text & "','" & txtEmail.Text & "','" & txtNumeroCNSS.Text & "','" & txtDiplome.Text & "','" & txtModule.Text & "')"
                cmd.ExecuteNonQuery()
                ListeProf.afichelisteProf()
                BtnEffaceer.PerformClick()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                co.Close()
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim i As String
        If btngarcon.Checked = True Then
            i = "Garcon"
        ElseIf btnfille.Checked = True Then
            i = "Fille"
        End If
        If DateEmbauche.Value > DateSortie.Value Then
            MsgBox("La date Embauche est supérieure à la date de sortie")
        ElseIf DateEmbauche.Value > DateFinContrat.Value Then
            MsgBox("La date Embauche est supérieure à la date de Fin Contrat")
        Else
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "UPDATE Scol_TEmployes SET [Dossier] = '" & txtDossier.Text.Trim & "', [DRPP] = '" & txtDRPP.Text.Trim & "', [Echelle] = '" & txtEchelle.Text.Trim & "', [CodeMassar] = '" & txtmasare.Text.Trim & "', [CIN] = '" & txtcin.Text.Trim & "', [Nom] = '" & txtnom.Text.Trim & "', [Prenom] = '" & txtprenom.Text.Trim & "', [DateNaissance] = '" & Guna2DateTimePicker1.Value & "', [Ville] = '" & txtVille.Text.Trim & "', [LieuNaissance] = '" & cmblieu.Text.Trim & "', [Nationalite] = '" & txtNationalite.Text.Trim & "', [Adresse] = '" & txtadress.Text.Trim & "', [Sexe] = '" & i & "', [DateEmbauche] = '" & DateEmbauche.Value & "', [DateSortie] = '" & DateSortie.Value & "', [DateFinContrat] = '" & DateFinContrat.Value & "', [NiveauEtudes] = '" & txtNiveauEtudes.Text.Trim & "', [NCompte] = '" & txtNCompte.Text.Trim & "', [Tel] = '" & txtTel.Text.Trim & "', [Email] = '" & txtEmail.Text.Trim & "', [NumeroCNSS] = '" & txtNumeroCNSS.Text.Trim & "', [Diplome] = '" & txtDiplome.Text.Trim & "', [Module] = '" & txtModule.Text.Trim & "' WHERE  [DRPP] = '" & txtDRPP.Text.Trim & "'"
                cmd.ExecuteNonQuery()
                ListeProf.afichelisteProf()
                btnupda.Visible = True
                btnAjouter.Visible = False
                Display.btnlistePro.PerformClick()
                BtnEffaceer.PerformClick()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                co.Close()
            End Try

        End If


    End Sub

    Private Sub BtnEffaceer_Click(sender As Object, e As EventArgs) Handles BtnEffaceer.Click
        txtDRPP.Text = ""
        txtDossier.Text = ""
        txtEchelle.Text = ""
        txtmasare.Text = ""
        txtcin.Text = ""
        txtnom.Text = ""
        txtprenom.Text = ""
        Guna2DateTimePicker1.Value = New DateTime(2000, 1, 1)
        txtVille.Text = ""
        cmblieu.Text = ""
        btngarcon.Checked = False
        btnfille.Checked = False
        txtNationalite.Text = ""
        txtadress.Text = ""
        DateEmbauche.Value = DateTime.Now
        DateSortie.Value = DateTime.Now
        DateFinContrat.Value = DateTime.Now
        txtNiveauEtudes.Text = ""
        txtNCompte.Text = ""
        txtTel.Text = ""
        txtEmail.Text = ""
        txtDiplome.Text = ""
        txtModule.Text = ""
        txtNumeroCNSS.Text = ""
    End Sub

    Private Sub AjouterProf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2DateTimePicker1.Value = New DateTime(2000, 1, 1)
        Dim cities() As String = {
"Casablanca", "Rabat", "Fès", "Marrakech", "Agadir", "Tanger", "Meknès", "Oujda", "Kenitra", "Salé",
"Tetouan", "Temara", "Safi", "Mohammedia", "Khouribga", "El Jadida", "Beni Mellal", "Nador", "Settat",
"Larache", "Taza", "Ouarzazate", "Errachidia", "Al Hoceima", "Dakhla", "Laâyoune", "Chefchaouen",
"Ifrane", "El Kelaa des Sraghna", "Taroudant", "Khenifra", "Guelmim", "Khemisset", "Berkane", "Taourirt",
"Sidi Kacem", "Taounate", "Sidi Slimane", "Sidi Bennour", "El Hajeb", "Essaouira", "Safi", "Mohammedia",
"Martil", "Bouznika", "Skhirat", "Tiflet", "Souq Larb'a al Gharb", "Guercif", "Oulad Teima", "Azrou",
"Sefrou", "Youssoufia", "Ouazzane", "Berkane", "Taourirt", "Sidi Yahia El Gharb", "Kasba Tadla",
"Sidi Ifni", "Tinghir", "Imzouren", "Assa", "Sidi Smail", "Boujniba", "Sidi Bennour", "Sidi Taibi",
"Taourirte", "Asilah", "Skhirate-Temara", "Sidi Allal Bahraoui", "Sidi Bouzid", "Ain Harrouda", "Tan-Tan",
"Ait Melloul", "Mediouna", "Zaio", "Oued Zem", "Bouarfa", "El Aioun", "Ouargla"
}
        cmblieu.Items.AddRange(cities)
        AddHandler cmblieu.KeyUp, AddressOf cmblieu_KeyUp
    End Sub

    Private Sub cmblieu_KeyUp(sender As Object, e As KeyEventArgs)

        If cmblieu.Text.Length >= 4 Then

            Dim firstFourChars As String = cmblieu.Text.Substring(0, 4)

            Dim index As Integer = cmblieu.FindString(firstFourChars)
            If index <> -1 Then
                cmblieu.SelectedIndex = index
            End If
        End If
    End Sub


    Private Sub txtprenom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprenom.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtnom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnom.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNationalite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNationalite.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txtVille_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVille.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub cmblieu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmblieu.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txtNCompte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCompte.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtNumeroCNSS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroCNSS.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDRPP_TextChanged(sender As Object, e As EventArgs) Handles txtDRPP.TextChanged

    End Sub

    Private Sub txtDRPP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDRPP.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTel_TextChanged(sender As Object, e As EventArgs) Handles txtTel.TextChanged

    End Sub
End Class