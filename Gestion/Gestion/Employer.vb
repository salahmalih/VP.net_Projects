Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Employer
    Dim co As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" & System.Environment.CurrentDirectory & "\Gestion.accdb; Persist Security Info=False;")
    Dim cmd As New OleDb.OleDbCommand
    Dim rd As OleDb.OleDbDataReader

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Guna2Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel2.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub lblfermer_MouseHover(sender As Object, e As EventArgs) Handles lblfermer.MouseHover
        ToolTip1.SetToolTip(lblfermer, "Close")
    End Sub
    Private Sub lblfermer_Click(sender As Object, e As EventArgs) Handles lblfermer.Click
        Gestion.btnHome.PerformClick()
        Gestion.BtnEmployer.FillColor = Color.FromArgb(226, 213, 73)
        Gestion.BtnEmployer.ForeColor = Color.Black
        Close()
    End Sub
    Sub affiche()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Select * from Employ"
            rd = cmd.ExecuteReader
            Employdatagrideview.Rows.Clear()
            While (rd.Read)
                Employdatagrideview.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4), rd(5))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Employé")
        End Try
        co.Close()
    End Sub
    Function userna(ByVal user As String) As Boolean
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Select count(*) from Employ  where username='" & txtUser.Text & "'"
            Dim i As Integer = cmd.ExecuteScalar
            If i > 0 Then
                co.Close()
                Return True
            Else
                co.Close()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Employé")
            co.Close()
        End Try
    End Function
    Private Sub btnajouter_Click(sender As Object, e As EventArgs) Handles btnajouter.Click
        If userna(txtUser.Text) = True Then
            MsgBox("Vuellez change username dija exist")
            Exit Sub
        End If
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "INSERT INTO [Employ](CIN,Nom,Prenom,DateEmbauche,Email,Tel,[username],[password])Values('" & txtcin.Text & "','" & txtnom.Text & "','" & txtPrenom.Text & "','" & dateEmb.Value & "','" & txtEmail.Text & "'," & txtTele.Text & ",'" & txtUser.Text & "','" & TxtPass.Text & "') "
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Employé")
        End Try
        co.Close()
        affiche()
    End Sub

    Private Sub Employer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        affiche()
    End Sub

    Private Sub Employdatagrideview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Employdatagrideview.CellContentClick
        If Employdatagrideview.Columns(e.ColumnIndex).Name = "Supp" Then
            Dim txt_Cin As String
            txt_Cin = Employdatagrideview.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  [Employ] where CIN='" & txt_Cin & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Employé")
            End Try
            co.Close()
            affiche()
        ElseIf Employdatagrideview.Columns(e.ColumnIndex).Name = "edite" Then
            btnupdate.Visible = True
            txtcin.Text = Employdatagrideview.CurrentRow.Cells(0).Value()
            txtnom.Text = Employdatagrideview.CurrentRow.Cells(1).Value()
            txtPrenom.Text = Employdatagrideview.CurrentRow.Cells(2).Value()
            dateEmb.Value = Employdatagrideview.CurrentRow.Cells(3).Value()
            txtEmail.Text = Employdatagrideview.CurrentRow.Cells(4).Value()
            txtTele.Text = Employdatagrideview.CurrentRow.Cells(5).Value()
            txtUser.Enabled = False
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Select username from Employ  where CIN='" & Employdatagrideview.CurrentRow.Cells(0).Value() & "'"
                txtUser.Text = cmd.ExecuteScalar
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Employé")
            End Try
            co.Close()
        End If
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Update   [Employ] set Nom='" & txtnom.Text & "',Prenom='" & txtPrenom.Text & "',DateEmbauche='" & dateEmb.Value & "',Email='" & txtEmail.Text & "',Tel=" & txtTele.Text & ",[username]='" & txtUser.Text & "',[password]='" & TxtPass.Text & "' Where CIN='" & txtcin.Text & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Employé")
        End Try
        btnupdate.Visible = False
        txtUser.Enabled = True

        co.Close()
        affiche()
    End Sub
End Class