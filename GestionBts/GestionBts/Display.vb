Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status


Public Class Display
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles btnAjouteremet.Click
        Dim AjouterET As New Form()
        pnl.Controls.Clear()
        AjouterE.TopLevel = False
        AjouterE.WindowState = FormWindowState.Maximized
        AjouterE.Visible = True
        pnl.Controls.Add(AjouterE)
        AjouterE.Show()
        AjouterE.cmbbranche_()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnhome.PerformClick()
    End Sub
    Sub click()
        Dim LIsteAllEt As New Form()
        pnl.Controls.Clear()
        LIsteAllEtude.TopLevel = False
        LIsteAllEtude.WindowState = FormWindowState.Maximized
        LIsteAllEtude.Visible = True
        pnl.Controls.Add(LIsteAllEtude)
        LIsteAllEtude.Show()
    End Sub
    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles btninscription.Click
        Dim inscriptio As New Form()
        pnl.Controls.Clear()
        inscription.TopLevel = False
        inscription.WindowState = FormWindowState.Maximized
        inscription.Visible = True
        pnl.Controls.Add(inscription)
        inscription.Show()
        inscription.aficheEtudiant()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnlisteEtd.Click
        Dim ListeE As New Form()
        pnl.Controls.Clear()
        ListeEtd.TopLevel = False
        ListeEtd.WindowState = FormWindowState.Maximized
        ListeEtd.Visible = True
        pnl.Controls.Add(ListeEtd)
        ListeEtd.Show()
        ListeEtd.afichelaureat()
        ListeEtd.afichelisteEt()
    End Sub

    Private Sub btnlistePro_Click(sender As Object, e As EventArgs) Handles btnlistePro.Click
        Dim ListePro As New Form()
        pnl.Controls.Clear()
        ListeProf.TopLevel = False
        ListeProf.WindowState = FormWindowState.Maximized
        ListeProf.Visible = True
        pnl.Controls.Add(ListeProf)
        ListeProf.Show()
    End Sub

    Private Sub Guna2Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel2.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Btnajouterprof_Click(sender As Object, e As EventArgs) Handles Btnajouterprof.Click
        Dim AjouterPro As New Form()
        pnl.Controls.Clear()
        AjouterProf.TopLevel = False
        AjouterProf.WindowState = FormWindowState.Maximized
        AjouterProf.Visible = True
        pnl.Controls.Add(AjouterProf)
        AjouterProf.Show()

    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        Dim Hom As New Form()
        pnl.Controls.Clear()
        Home.TopLevel = False
        Home.WindowState = FormWindowState.Maximized
        Home.Visible = True
        pnl.Controls.Add(Home)
        Home.Show()
        With Home
            .nomberEtude()
            .nomberLaureats()
            .nomberprof()
            .nomberisnsc()
        End With

    End Sub

    Private Sub lblfermer_MouseHover(sender As Object, e As EventArgs) Handles lblfermer.MouseHover
        ToolTip1.SetToolTip(lblfermer, "Fermer")
    End Sub
    Private Sub lblfermer_Click(sender As Object, e As EventArgs) Handles lblfermer.Click
        Close()
        Form1.Close()

    End Sub

    Private Sub btnmini_Click(sender As Object, e As EventArgs) Handles btnmini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnmini_MouseHover(sender As Object, e As EventArgs) Handles btnmini.MouseHover
        ToolTip1.SetToolTip(btnmini, "Minimized")
    End Sub


End Class
