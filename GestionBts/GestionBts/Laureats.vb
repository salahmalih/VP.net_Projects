Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.InteropServices

Public Class Laureats
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        If txtEcole.Text > "" Then

            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Insert into Scol_Laureats Values(" & txtNumero.Text & ",'" & txtEcole.Text & "','" & txtnom.Text & "','" & DateEntrer.Value & "','" & Datesortie.Value & "')"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()

        ElseIf txtEcole.Text = "" Then
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Insert into Scol_Laureats Values(" & txtNumero.Text & ",NULL,'" & txtnom.Text & "','" & DateEntrer.Value & "','" & Datesortie.Value & "')"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            co.Close()
            Me.Close()
        End If

    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Insert into Scol_Suivilaur Values(" & txtNumero.Text & ",'" & txtEcole.Text & "','" & txtnom.Text & "','" & DateEntrer.Value & "','" & Datesortie.Value & "')"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        co.Close()
        Me.BtnUpdate.Visible = False
        Me.btnValider.Visible = True
        Me.Label2.Text = "Numero"
        ListeEtd.afichesuiv()
        Me.Close()
    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

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

    Private Sub Laureats_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_TextChanged(sender As Object, e As EventArgs) Handles txtnom.TextChanged

    End Sub

    Private Sub txtnom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnom.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class