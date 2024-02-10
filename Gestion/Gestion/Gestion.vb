Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Access.Dao
Imports Microsoft.Office.Interop.Excel


Public Class Gestion
    Dim co As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" & System.Environment.CurrentDirectory & "\Gestion.accdb; Persist Security Info=False;")
    Dim cmd As New OleDb.OleDbCommand
    Dim rd As OleDb.OleDbDataReader

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Sub affiche()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select * from Arrivee order by NUmcommande"
            rd = cmd.ExecuteReader
            DataGridView1.Rows.Clear()
            While rd.Read = True
                DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee")
        End Try
        co.Close()
    End Sub
    Sub affiche2()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select * from Depart order by NUmcommande"
            rd = cmd.ExecuteReader
            Departdatagrideview.Rows.Clear()
            While rd.Read = True
                Departdatagrideview.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
        End Try
        co.Close()
    End Sub
    Sub countDepart()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select count(*) from Depart "
            lblcountDepart.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
        End Try
        co.Close()
    End Sub
    Sub countArrivee()
        Try
            co.Open()
            cmd.Connection = co
            cmd.CommandText = "select count(*) from Arrivee "
            lblcountArrivee.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee")
        End Try
        co.Close()
    End Sub

    Private Sub Gestion_Load(sender As Object, e As EventArgs) Handles Me.Load

        panelHome.Show()

        Arrive.Hide()
        Depart.Hide()
        btnHome.FillColor = Color.White
        btnHome.ForeColor = Color.Black
        btnArrivee.FillColor = Color.FromArgb(226, 213, 73)
        btnArrivee.ForeColor = Color.Black
        btnDepart.FillColor = Color.FromArgb(226, 213, 73)
        btnDepart.ForeColor = Color.Black

        affiche()
        affiche2()
        countArrivee()
        countDepart()

    End Sub


    Private Sub Guna2Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Menugestion.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub lblfermer_MouseHover(sender As Object, e As EventArgs) Handles lblfermer.MouseHover
        ToolTip1.SetToolTip(lblfermer, "close")
    End Sub

    Private Sub btnmaxsiz_Click(sender As Object, e As EventArgs) Handles btnmaxsiz.Click

        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub btnmini_Click(sender As Object, e As EventArgs) Handles btnmini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnmaxsiz_MouseHover(sender As Object, e As EventArgs) Handles btnmaxsiz.MouseHover
        ToolTip1.SetToolTip(btnmaxsiz, "Réduire et agrandir la taille du programme")
    End Sub

    Private Sub btnmini_MouseHover(sender As Object, e As EventArgs) Handles btnmini.MouseHover
        ToolTip1.SetToolTip(btnmini, "miniature")
    End Sub
    Private Sub lblfermer_Click(sender As Object, e As EventArgs) Handles lblfermer.Click
        Close()
        admin.Close()

    End Sub

    Private Sub btnajouter_MouseHover(sender As Object, e As EventArgs) Handles btnajouter.MouseHover
        ToolTip1.SetToolTip(btnajouter, "Ajouter Arrivee")
    End Sub

    Private Sub btnaddexel_MouseHover(sender As Object, e As EventArgs) Handles btnaddexel.MouseHover
        ToolTip1.SetToolTip(btnaddexel, "Ajouter Excel pour Arrivee")
    End Sub




    Private Sub btnaddexel_Click(sender As Object, e As EventArgs) Handles btnaddexel.Click
        OpenFileDialog1.Title = "Select Excel File"
        OpenFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim excelPath As String = OpenFileDialog1.FileName
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
        Dim excelConnection As New OleDb.OleDbConnection(connectionString)
        Dim cmd1 As New OleDbCommand("Select * From [Sheet1$]", excelConnection)
        excelConnection.Open()
        Dim dataAdapter As New OleDbDataAdapter(cmd1)
        Dim dataSet As New DataSet()
        dataAdapter.Fill(dataSet)
        excelConnection.Close()
        Try

            For i = 0 To dataSet.Tables(0).Rows.Count - 1
                Dim txtnumco As Integer = dataSet.Tables(0).Rows(i)(0)
                Dim txtsender As String = dataSet.Tables(0).Rows(i)(1)
                Dim txtobjetsende As String = dataSet.Tables(0).Rows(i)(2)
                Dim txtdate As Date = dataSet.Tables(0).Rows(i)(3)


                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "Insert into Arrivee(NUmcommande,expediteur,tresenvoye,Datese) values (" & txtnumco & " , '" & txtsender & "' , '" & txtobjetsende & "' , '" & txtdate & "')"

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee ")
                End Try

                co.Close()
                affiche()
                ajouter.combo()
                edit.combo()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee ")
        End Try
    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Btnextern_Click(sender As Object, e As EventArgs) Handles Btnextern.Click
        Try


            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("sheet1")

                For i = 0 To DataGridView1.RowCount - 2
                    For j = 0 To DataGridView1.ColumnCount - 4
                        For k As Integer = 1 To DataGridView1.Columns.Count - 3
                            xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                        Next
                    Next
                Next

                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)


                MsgBox("Enregistré avec succès" & vbCrLf & " Le fichier est stocké dans :" & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Arrivee")

            End If
        Catch ex As Exception
            MessageBox.Show("Échec de l'enregistrement !!!", "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

    End Sub


    Private Sub btnajouter_Click(sender As Object, e As EventArgs) Handles btnajouter.Click

        If ajouter.CanFocus = True Then
            ajouter.Hide()
            ajouter.Show()
        Else

            ajouter.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DataGridView1.Columns(e.ColumnIndex).Name = "filepdf" Then

            Dim txt_numart As String
            txt_numart = DataGridView1.CurrentRow.Cells(0).Value()
            Dim pdfFile As Byte()

            Try

                co.Open()
                Dim cmd As New OleDbCommand("SELECT fil FROM Arrivee WHERE NUmcommande = @ID", co)
                cmd.Parameters.AddWithValue("@ID", OleDbType.Integer).Value = txt_numart
                Dim pdfData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
                If pdfData IsNot Nothing Then
                    Dim pdfStream As New MemoryStream(pdfData)
                    Dim pdfFil As New FileStream("MyPDF.pdf", FileMode.Create, FileAccess.Write)
                    pdfStream.WriteTo(pdfFil)
                    pdfFil.Close()
                    pdfStream.Close()

                    Dim filePath As String = Path.Combine(Directory.GetCurrentDirectory(), "MyPDF.pdf")
                    Dim startexternal As New Process()
                    startexternal.StartInfo.FileName = filePath
                    startexternal.StartInfo.UseShellExecute = True
                    startexternal.Start()
                Else
                    MsgBox("Fichier introuvable")
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee")
            End Try
            co.Close()

        End If

        If DataGridView1.Columns(e.ColumnIndex).Name = "edite" Then
            Dim txt_numart As String
            txt_numart = DataGridView1.CurrentRow.Cells(0).Value()

            If edit.CanFocus = True Then
                edit.Hide()
                edit.Show()
            Else

                edit.Show()
            End If
            edit.txtnumco.Text = DataGridView1.CurrentRow.Cells(0).Value()
            edit.txtsender.Text = DataGridView1.CurrentRow.Cells(1).Value()
            edit.txtobjetsende.Text = DataGridView1.CurrentRow.Cells(2).Value()
            edit.txtdate.Value = DataGridView1.CurrentRow.Cells(3).Value()
            edit.pde(txt_numart)
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "supp" Then
            Dim txt_numart As String
            txt_numart = DataGridView1.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  Arrivee where NUmcommande=" & txt_numart & ""
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee")
            End Try
            co.Close()
            affiche()
            countArrivee()

            ajouter.combo()
        End If
    End Sub




    Private Sub Departadd_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub btnDepart_Click(sender As Object, e As EventArgs) Handles btnDepart.Click
        Arrive.Hide()
        panelHome.Hide()

        Depart.Show()
        btnArrivee.FillColor = Color.FromArgb(226, 213, 73)
        btnArrivee.ForeColor = Color.Black
        btnDepart.FillColor = Color.White
        btnDepart.ForeColor = Color.Black
        BtnEmployer.FillColor = Color.FromArgb(226, 213, 73)
        BtnEmployer.ForeColor = Color.Black
        btnHome.FillColor = Color.FromArgb(226, 213, 73)
        btnHome.ForeColor = Color.Black
    End Sub

    Private Sub btnArrivee_Click(sender As Object, e As EventArgs) Handles btnArrivee.Click
        Depart.Hide()
        panelHome.Hide()

        Arrive.Show()
        btnArrivee.FillColor = Color.White
        btnArrivee.ForeColor = Color.Black
        btnDepart.FillColor = Color.FromArgb(226, 213, 73)
        btnDepart.ForeColor = Color.Black
        btnHome.FillColor = Color.FromArgb(226, 213, 73)
        btnHome.ForeColor = Color.Black
        BtnEmployer.FillColor = Color.FromArgb(226, 213, 73)
        BtnEmployer.ForeColor = Color.Black

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        panelHome.Show()

        Arrive.Hide()
        Depart.Hide()
        btnHome.FillColor = Color.White
        btnHome.ForeColor = Color.Black
        btnArrivee.FillColor = Color.FromArgb(226, 213, 73)
        btnArrivee.ForeColor = Color.Black
        btnDepart.FillColor = Color.FromArgb(226, 213, 73)
        btnDepart.ForeColor = Color.Black
        BtnEmployer.FillColor = Color.FromArgb(226, 213, 73)
        BtnEmployer.ForeColor = Color.Black
    End Sub

    Private Sub btnaboutus_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Dim filePath As String = "http://Chinwi-services.com"
        Dim startexternal As New Process()
        startexternal.StartInfo.FileName = filePath
        startexternal.StartInfo.UseShellExecute = True
        startexternal.Start()
    End Sub



    Private Sub txtsherch_TextChanged(sender As Object, e As EventArgs) Handles txtsherch.TextChanged
        If txtsherch.Text > "" Then
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "select * from Arrivee where NUmcommande like '%" & txtsherch.Text & "%' or expediteur like '%" & txtsherch.Text & "%' or Datese like '%" & txtsherch.Text & "%'or tresenvoye like '%" & txtsherch.Text & "%'"
                rd = cmd.ExecuteReader
                DataGridView1.Rows.Clear()
                While rd.Read = True
                    DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
                End While
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Arrivee")
            End Try
            co.Close()
        End If

    End Sub

    Private Sub Btnextern_MouseHover(sender As Object, e As EventArgs) Handles Btnextern.MouseHover
        ToolTip1.SetToolTip(Btnextern, "extraire excel")
    End Sub

    Private Sub Departadd_MouseHover(sender As Object, e As EventArgs)
        ToolTip1.SetToolTip(Departadd, "اAjouter Depart")
    End Sub

    Private Sub Dipartaddexel_MouseHover(sender As Object, e As EventArgs)
        ToolTip1.SetToolTip(Dipartaddexel, "Ajouter Excel aux Depart")
    End Sub

    Private Sub Departextraexel_MouseHover(sender As Object, e As EventArgs)
        ToolTip1.SetToolTip(Departextraexel, "extraire excel")
    End Sub

    Private Sub OpenFileDialog2_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog2.FileOk
        Dim excelPath As String = OpenFileDialog2.FileName
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
        Dim excelConnection As New OleDb.OleDbConnection(connectionString)
        Dim cmd1 As New OleDbCommand("Select * From [Sheet1$]", excelConnection)
        excelConnection.Open()
        Dim dataAdapter As New OleDbDataAdapter(cmd1)
        Dim dataSet As New DataSet()
        dataAdapter.Fill(dataSet)
        excelConnection.Close()
        Try

            For i = 0 To dataSet.Tables(0).Rows.Count - 1
                Dim txtnumco As Integer = dataSet.Tables(0).Rows(i)(0)
                Dim txtsender As String = dataSet.Tables(0).Rows(i)(1)
                Dim txtobjetsende As String = dataSet.Tables(0).Rows(i)(2)
                Dim txtdate As Date = dataSet.Tables(0).Rows(i)(3)
                Dim tp As String = dataSet.Tables(0).Rows(i)(4)

                Try
                    co.Open()
                    cmd.Connection = co
                    cmd.CommandText = "Insert into Depart(NUmcommande,tresenvoye,destinataire,Datese,Pfile) values (" & txtnumco & " , '" & txtsender & "' , '" & txtobjetsende & "' , '" & txtdate & "', '" & tp & "')"

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart ")
                End Try

                co.Close()
                affiche2()
                AjouterDepart.combo()
                editDepart.combo()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart ")
        End Try
    End Sub
    Private Sub panelHome_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Depart_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Arrive_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Departadd_Click_1(sender As Object, e As EventArgs) Handles Departadd.Click
        If AjouterDepart.CanFocus = True Then
            AjouterDepart.Hide()
            AjouterDepart.Show()
        Else

            AjouterDepart.Show()
        End If
    End Sub

    Private Sub Departshearch_TextChanged_1(sender As Object, e As EventArgs) Handles Departshearch.TextChanged
        If Departshearch.Text > "" Then
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "select * from Depart where NUmcommande like '%" & Departshearch.Text & "%' or destinataire like '%" & Departshearch.Text & "%' or Datese like '%" & Departshearch.Text & "%'or tresenvoye like '%" & Departshearch.Text & "%'"
                rd = cmd.ExecuteReader
                Departdatagrideview.Rows.Clear()
                While rd.Read = True
                    Departdatagrideview.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
                End While
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
            End Try
            co.Close()
        End If

    End Sub

    Private Sub Dipartaddexel_Click_1(sender As Object, e As EventArgs) Handles Dipartaddexel.Click
        OpenFileDialog2.Title = "Select Excel File"
        OpenFileDialog2.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub Departextraexel_Click_1(sender As Object, e As EventArgs) Handles Departextraexel.Click
        Try


            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("sheet1")

                For i = 0 To Departdatagrideview.RowCount - 2
                    For j = 0 To Departdatagrideview.ColumnCount - 4
                        For k As Integer = 1 To DataGridView1.Columns.Count - 3
                            xlWorkSheet.Cells(1, k) = Departdatagrideview.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = Departdatagrideview(j, i).Value.ToString()
                        Next
                    Next
                Next

                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                MsgBox("Enregistré avec succès" & vbCrLf & " Le fichier est enregistré dans :" & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Depart")

            End If
        Catch ex As Exception
            MessageBox.Show("Échec de l'enregistrement !!!", "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub Departdatagrideview_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles Departdatagrideview.CellContentClick
        If Departdatagrideview.Columns(e.ColumnIndex).Name = "pdfread" Then

            Dim txt_numart As String
            txt_numart = Departdatagrideview.CurrentRow.Cells(0).Value()
            Dim pdfFile As Byte()

            Try

                co.Open()
                Dim cmd As New OleDbCommand("SELECT fil FROM Depart WHERE NUmcommande = @ID", co)
                cmd.Parameters.AddWithValue("@ID", OleDbType.Integer).Value = txt_numart
                Dim pdfData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
                Dim pdfStream As New MemoryStream(pdfData)
                Dim pdfFil As New FileStream("MyPDF.pdf", FileMode.Create, FileAccess.Write)
                pdfStream.WriteTo(pdfFil)
                pdfFil.Close()
                pdfStream.Close()

                Dim filePath As String = Path.Combine(Directory.GetCurrentDirectory(), "MyPDF.pdf")
                Dim startexternal As New Process()
                startexternal.StartInfo.FileName = filePath
                startexternal.StartInfo.UseShellExecute = True
                startexternal.Start()


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
            End Try
            co.Close()

        End If

        If Departdatagrideview.Columns(e.ColumnIndex).Name = "edit1" Then
            Dim txt_numart As String
            txt_numart = Departdatagrideview.CurrentRow.Cells(0).Value()

            If editDepart.CanFocus = True Then
                editDepart.Hide()
                editDepart.Show()
            Else

                editDepart.Show()
            End If
            editDepart.txtnumco.Text = Departdatagrideview.CurrentRow.Cells(0).Value()
            editDepart.txtsender.Text = Departdatagrideview.CurrentRow.Cells(2).Value()
            editDepart.txtobjetsende.Text = Departdatagrideview.CurrentRow.Cells(1).Value()
            editDepart.txtdate.Value = Departdatagrideview.CurrentRow.Cells(3).Value()
            editDepart.pde(txt_numart)
        End If
        If Departdatagrideview.Columns(e.ColumnIndex).Name = "supp1" Then
            Dim txt_numart As String
            txt_numart = Departdatagrideview.CurrentRow.Cells(0).Value()
            Try
                co.Open()
                cmd.Connection = co
                cmd.CommandText = "Delete from  Depart where NUmcommande=" & txt_numart & ""
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Depart")
            End Try
            co.Close()
            affiche2()
            AjouterDepart.combo()
            countDepart()
        End If
    End Sub

    Private Sub Arrive_Paint_1(sender As Object, e As PaintEventArgs) Handles Arrive.Paint

    End Sub

    Private Sub BtnEmployer_Click(sender As Object, e As EventArgs) Handles BtnEmployer.Click
        Adminvb.Show()

        BtnEmployer.FillColor = Color.White
        BtnEmployer.ForeColor = Color.Black
        btnHome.FillColor = Color.FromArgb(226, 213, 73)
        btnHome.ForeColor = Color.Black
        btnArrivee.FillColor = Color.FromArgb(226, 213, 73)
        btnArrivee.ForeColor = Color.Black
        btnDepart.FillColor = Color.FromArgb(226, 213, 73)
        btnDepart.ForeColor = Color.Black

    End Sub

    Private Sub Depart_Paint_1(sender As Object, e As PaintEventArgs) Handles Depart.Paint

    End Sub
End Class