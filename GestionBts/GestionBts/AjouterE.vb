Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms

Public Class AjouterE
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Sub cmbbranche_()

        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select IDbranche,NomBrancheFR from Scol_Branche"
            dr = cmd.ExecuteReader
            Dim t As New DataTable
            t.Load(dr)
            cmbBranche.DisplayMember = "NomBrancheFR".Trim
            cmbBranche.ValueMember = "IDbranche".Trim
            cmbBranche.DataSource = t
            cmbBranche.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
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

    Private Sub AjouterE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2DateTimePicker1.Format = DateTimePickerFormat.Custom
        Guna2DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Guna2DateTimePicker1.Value = New DateTime(2000, 1, 1)
        cmbbranche_()
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


    Private Sub BtnEffaceer_Click(sender As Object, e As EventArgs) Handles BtnEffaceer.Click
        txtadress.Text = ""
        txtcin.Text = ""
        txtmasare.Text = ""
        txtnom.Text = ""
        txtprenom.Text = ""
        txtEmail.Text = ""
        txtTel.Text = ""
        cmbBranche.Text = ""
        cmblieu.Text = ""
        btngarcon.Checked = False
        btnfille.Checked = False
        Guna2DateTimePicker1.Value = New DateTime(2000, 1, 1)

    End Sub
    Function cin(ByVal Cn As String) As Boolean
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select NCin from Scol_Etudiant where NCin='" & Cn & "' "
            Dim i As Integer = cmd.ExecuteScalar
            If i > 0 Then
                co.Close()
                Return True
            End If
            co.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            co.Close()
            Return False
        End Try
        co.Close()
    End Function
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        Dim i As String
        If btngarcon.Checked = True Then
            i = "Garcon"

        ElseIf btnfille.Checked = True Then
            i = "Fille"
        End If
        If cin(txtcin.Text) = False Then
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Insert into Scol_Etudiant Values('" & txtmasare.Text.Trim & "','" & txtcin.Text.Trim & "','" & txtnom.Text.Trim & "','" & txtprenom.Text.Trim & "','" & i.Trim & "','" & Guna2DateTimePicker1.Value & "','" & cmblieu.Text.Trim & "','" & txtadress.Text.Trim & "'," & txtTel.Text & ",'" & txtEmail.Text.Trim & "'," & cmbBranche.SelectedValue & ")"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            inscription.aficheEtudiant()
            BtnEffaceer.PerformClick()
        End If

    End Sub

    Private Sub btnBranche_Click(sender As Object, e As EventArgs) Handles btnBranche.Click
        Branche.Show()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim i As String
        If btngarcon.Checked = True Then
            i = "Garcon"

        ElseIf btnfille.Checked = True Then
            i = "Fille"
        End If
        If cin(txtcin.Text) = False Then
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Update  Scol_Etudiant set CodeMassar = '" & txtmasare.Text.Trim & "' , NCin ='" & txtcin.Text.Trim & "' , Nom ='" & txtnom.Text.Trim & "' ,  Prenom = '" & txtprenom.Text.Trim & "' , Sexe='" & i.Trim & "' , DateNaissance = '" & Guna2DateTimePicker1.Value & "' , Lieunaissance = '" & cmblieu.Text.Trim & "' , Adresse ='" & txtadress.Text.Trim & "' , Telephone= " & txtTel.Text & " , Email= '" & txtEmail.Text.Trim & "' , IDbranche=" & cmbBranche.SelectedValue & " Where CodeMassar = '" & txtmasare.Text.Trim & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            inscription.aficheEtudiant()
            Me.btnUpdate.Visible = False
            Me.btnAjouter.Visible = True
            BtnEffaceer.PerformClick()
            Display.btninscription.PerformClick()
        End If

    End Sub
End Class