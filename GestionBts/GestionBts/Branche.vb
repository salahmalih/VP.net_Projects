Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms

Public Class Branche
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Sub afichBranche()

        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select * from Scol_Branche"
            dr = cmd.ExecuteReader
            Guna2DataGridView1.Rows.Clear()
            While dr.Read = True
                Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
    End Sub

    Private Sub Branche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        afichBranche()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select * from Scol_Branche  where NomBrancheFR='" & txtNombranch.Text & "'"
            Dim s As Integer = cmd.ExecuteScalar
            If s > 0 Then
                MsgBox("Branche dija existe")
                co.Close()
                Exit Sub
            End If
            cmd.CommandText = "Insert into Scol_Branche(NomBrancheFR,Annee,NbrModule,NbrHeure,NbrMaxAnneeF,NomDiplome,TYPEFORMATION)Values('" & txtNombranch.Text & "'," & txtAnnee.Text & "," & txtNbrModule.Text & "," & txtNbrHeure.Text & "," & txtNbrMaxAnneeF.Text & ",'" & txtNomDiplome.Text & "','" & txtTYPEFORMATION.Text & "')"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
        afichBranche()
        AjouterE.cmbbranche_()
        BtnEffaceer.PerformClick()

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If Guna2DataGridView1.Columns(e.ColumnIndex).Name = "supp" Then
            Dim txt_Branche As String
            txt_Branche = Guna2DataGridView1.CurrentRow.Cells(0).Value()

            Try
                co.Open()
                cmd.Connection = co

                cmd.CommandText = "Delete from  Scol_Branche where IDbranche=" & txt_Branche & ""
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            afichBranche()
        End If
        If Guna2DataGridView1.Columns(e.ColumnIndex).Name = "edite" Then
            btnAjouter.Visible = False
            btnUpadate.Visible = True

            txtNombranch.Text = Guna2DataGridView1.CurrentRow.Cells(1).Value()
            txtAnnee.Text = Guna2DataGridView1.CurrentRow.Cells(2).Value()
            txtNbrHeure.Text = Guna2DataGridView1.CurrentRow.Cells(4).Value()
            txtNbrModule.Text = Guna2DataGridView1.CurrentRow.Cells(3).Value()
            txtTYPEFORMATION.Text = Guna2DataGridView1.CurrentRow.Cells(7).Value()
            txtNomDiplome.Text = Guna2DataGridView1.CurrentRow.Cells(6).Value()
            txtNbrMaxAnneeF.Text = Guna2DataGridView1.CurrentRow.Cells(5).Value()
            txt_Branche = Guna2DataGridView1.CurrentRow.Cells(0).Value()
        End If
    End Sub
    Dim txt_Branche As Integer
    Private Sub BtnEffaceer_Click(sender As Object, e As EventArgs) Handles BtnEffaceer.Click

        txtNombranch.Text = ""
        txtAnnee.Text = ""
        txtNbrHeure.Text = ""
        txtNbrModule.Text = ""
        txtTYPEFORMATION.Text = ""
        txtNomDiplome.Text = ""
        txtNbrMaxAnneeF.Text = ""
    End Sub

    Private Sub btnUpadate_Click(sender As Object, e As EventArgs) Handles btnUpadate.Click

        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Update   Scol_Branche  set NomBrancheFR='" & txtNombranch.Text & "',Annee=" & txtAnnee.Text & ",NbrModule=" & txtNbrModule.Text & " ,NbrHeure=" & txtNbrHeure.Text & ",NbrMaxAnneeF=" & txtNbrMaxAnneeF.Text & " ,NomDiplome='" & txtNomDiplome.Text & "',TYPEFORMATION='" & txtTYPEFORMATION.Text & "' where IDbranche=" & txt_Branche & ""
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
        afichBranche()
        btnAjouter.Visible = True
        btnUpadate.Visible = False
        BtnEffaceer.PerformClick()
    End Sub



    Private Sub Guna2Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel2.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub lblfermer_MouseHover(sender As Object, e As EventArgs) Handles lblfermer.MouseHover
        ToolTip1.SetToolTip(lblfermer, "Fermer")
    End Sub
    Private Sub lblfermer_Click(sender As Object, e As EventArgs) Handles lblfermer.Click
        Close()
    End Sub

    Private Sub btnmini_Click(sender As Object, e As EventArgs) Handles btnmini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnmini_MouseHover(sender As Object, e As EventArgs) Handles btnmini.MouseHover
        ToolTip1.SetToolTip(btnmini, "Minimized")
    End Sub
End Class