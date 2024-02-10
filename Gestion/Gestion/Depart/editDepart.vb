Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices

Public Class editDepart
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
        Close()
    End Sub
    Sub combo()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "Select NUmcommande from Depart order by NUmcommande "
            rd = cmd.ExecuteReader
            txtnumco.Items.Clear()
            While (rd.Read = True)
                txtnumco.Items.Add(rd(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
        End Try
        co.Close()
    End Sub
    Dim pdfData As Byte()
    Private Sub ajouter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        pdfData = DirectCast(Nothing, Byte())
    End Sub


    Sub pde(a As String)

        Dim pdfFile As Byte()
        Try
            co.Open()
            Dim cmd1 As New OleDbCommand("SELECT fil FROM Depart WHERE NUmcommande = " & a & "", co)
            pdfFile = DirectCast(cmd1.ExecuteScalar(), Byte())
        Catch ex As Exception
            MsgBox("Il n'y a pas de fichier dans les données sous-jacentes", MsgBoxStyle.Critical, "Depart")
        End Try
        co.Close()
        lblpath.Text = "Il n'y a pas de fichier dans les données sous-jacentes"
        If pdfFile IsNot Nothing Then
            Try
                co.Open()
                Dim cmd2 As New OleDbCommand("SELECT Pfile FROM Depart WHERE NUmcommande = " & a & "", co)
                lblpath.Text = cmd2.ExecuteScalar()
            Catch ex As Exception
                MsgBox("Il n'y a pas de fichier dans les données sous-jacentes", MsgBoxStyle.Critical, "Depart")
            End Try
            co.Close()
            pdfData = pdfFile

        End If
    End Sub
    Public Sub ScanPDF()



        OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        OpenFileDialog1.Title = "Select a PDF File"
        OpenFileDialog1.ShowDialog()

    End Sub
    Private Sub btnupload_Click(sender As Object, e As EventArgs) Handles btnupload.Click
        ScanPDF()
    End Sub

    Private Sub btnajouter_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        If txtnumco.Text = "" Then
            MsgBox("Il est préférable d'ajouter un numéro de commande", MsgBoxStyle.Information, Title:="Depart ")
        ElseIf txtobjetsende.Text = "" Then
            MsgBox("Mieux vaut ajouter le but de l'expéditeur", MsgBoxStyle.Information, Title:="Depart ")
        ElseIf txtsender.Text = "" Then
            MsgBox("Il vaut mieux ajouter le destinataire", MsgBoxStyle.Information, Title:="Depart ")
        ElseIf pdfData Is Nothing Then
            MsgBox("Mieux vaut ajouter un fichier", MsgBoxStyle.Information, Title:="Depart ")
        Else
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Update Depart set [tresenvoye]='" & txtobjetsende.Text & "', [destinataire]='" & txtsender.Text & "',[Datese]='" & txtdate.Value & "', [Pfile]='" & lblpath.Text & "' , [fil]=@file,CIN='" & admin.cin & "'  where [NUmcommande]=" & txtnumco.Text & ""
                cmd.Parameters.Add("@fil", OleDbType.VarBinary).Value = pdfData
                cmd.ExecuteNonQuery()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
            End Try
            co.Close()
            Gestion.affiche2()
            combo()
            Gestion.countDepart()
            Me.Close()
        End If

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        lblpath.Text = OpenFileDialog1.FileName

        Dim fs As New FileStream(OpenFileDialog1.FileName.ToString, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        pdfData = br.ReadBytes(br.BaseStream.Length)
        btnupload.FillColor = Color.Orange
        btnupload.ForeColor = Color.White
    End Sub

    Private Sub txtnumco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnumco.SelectedIndexChanged

    End Sub

    Private Sub txtnumco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnumco.KeyDown

    End Sub

    Private Sub txtnumco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumco.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtobjetsende_TextChanged(sender As Object, e As EventArgs) Handles txtobjetsende.TextChanged

    End Sub

    Private Sub txtobjetsende_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtobjetsende.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class