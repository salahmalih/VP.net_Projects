﻿Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices
Imports iTextSharp.text.pdf
Imports PdfSharp.Pdf
Imports WIA
Public Class AjouterDepart
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
            cmd.CommandText = "Select NUmcommande from Depart"
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
    Private Sub ajouter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
    End Sub

    Public Sub ScanPDF()



        OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        OpenFileDialog1.Title = "Select a PDF File"
        OpenFileDialog1.ShowDialog()


    End Sub
    Private Sub btnupload_Click(sender As Object, e As EventArgs) Handles btnupload.Click
        ScanPDF()
    End Sub
    Dim pdfData() As Byte
    Private Sub btnajouter_Click(sender As Object, e As EventArgs) Handles btnajouter.Click




        If txtnumco.Text = "" Then
            MsgBox("Il est préférable d'ajouter un numéro de commande", MsgBoxStyle.Information, Title:="Depart ")
        ElseIf txtobjetsende.Text = "" Then
            MsgBox("Mieux vaut ajouter le but de l'expéditeur", MsgBoxStyle.Information, Title:="Depart ")
        ElseIf txtseder.Text = "" Then
            MsgBox("Il vaut mieux ajouter le destinataire", MsgBoxStyle.Information, Title:="Depart ")
        ElseIf pdfData Is Nothing Then
            MsgBox("Mieux vaut ajouter un fichier", MsgBoxStyle.Information, Title:="Depart ")
        Else
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Insert into Depart(NUmcommande,tresenvoye,destinataire,Datese,Pfile,fil,CIN) values (@NUmcommande,@tresenvoye,@destinataire,@Datese,@Pfile,@fil,@CIN)"

                cmd.Parameters.Add("@NUmcommande", OleDbType.Integer).Value = txtnumco.Text
                cmd.Parameters.Add("@tresenvoye", OleDbType.VarChar).Value = txtobjetsende.Text
                cmd.Parameters.Add("@destinataire", OleDbType.VarChar).Value = txtseder.Text
                cmd.Parameters.Add("@Datese", OleDbType.VarChar).Value = txtdate.Value
                cmd.Parameters.Add("@Pfile", OleDbType.VarChar).Value = lblpath.Text
                cmd.Parameters.Add("@fil", OleDbType.VarBinary).Value = pdfData
                cmd.Parameters.Add("@CIN", OleDbType.VarChar).Value = admin.cin
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart ")
            End Try

            co.Close()
            Gestion.countDepart()
            Gestion.affiche2()
            combo()
            Me.Close()
        End If

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        lblpath.Text = OpenFileDialog1.FileName
        Dim fs As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        pdfData = Nothing
        pdfData = br.ReadBytes(br.BaseStream.Length)
        btnupload.FillColor = Color.Orange
        btnupload.ForeColor = Color.White
    End Sub

    Private Sub lblpath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblpath.LinkClicked

    End Sub

    Private Sub txtnumco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnumco.SelectedIndexChanged

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