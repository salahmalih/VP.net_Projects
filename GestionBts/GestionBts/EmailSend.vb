Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.InteropServices
Imports MailKit.Net
Imports Microsoft.SqlServer
Imports Org.BouncyCastle.Tls

Public Class EmailSend
    Dim co As New SqlConnection("server=DESKTOP-8GH5IFT\SQLEXPRESS;initial catalog=Scol;integrated security=true")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Public Nom As String


    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub EmailSend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        msgbody.Text = "Cher " & Nom & "," & vbCrLf & vbCrLf &
                       "J'espère que cette lettre vous trouve en bonne santé et que vous vous portez bien. En tant que Directeur brevet de technicien supérieur, je tiens à m'assurer de votre bien-être et de votre réussite académique. Par conséquent, j'aimerais prendre quelques instants pour discuter de votre état actuel et de votre parcours académique jusqu'à présent." & vbCrLf & vbCrLf &
                       "Tout d'abord, comment allez-vous ? J'aimerais savoir comment vous vous sentez tant sur le plan physique que mental. La période des études peut être exigeante et il est important de prendre soin de soi. Si vous rencontrez des difficultés ou des préoccupations, n'hésitez pas à m'en parler. Je suis là pour vous soutenir et vous aider de toutes les manières possibles." & vbCrLf & vbCrLf &
                       "En ce qui concerne votre parcours académique, je voudrais connaître les développements depuis la dernière fois que nous avons discuté. Avez-vous réussi les examens ou les évaluations récentes ? Si oui, félicitations ! Votre persévérance et votre travail acharné ont porté leurs fruits. Je suis très fier(e) de vos réalisations et je vous encourage à continuer sur cette lancée." & vbCrLf & vbCrLf &
                       "Si vous avez obtenu un emploi récemment, je serais ravi de connaître les détails. Quel type de travail faites-vous ? Comment cela correspond-il à vos aspirations et à votre parcours académique ? N'hésitez pas à partager vos réflexions sur cette expérience professionnelle, y compris les défis et les réussites que vous avez rencontrés jusqu'à présent." & vbCrLf & vbCrLf &
                       "Votre parcours académique est une étape importante de votre vie, et je suis ravi(e) . Je crois fermement en votre potentiel et je suis convaincu(e) que vous êtes capable d'accomplir de grandes choses. Rappelez-vous toujours que vous avez le pouvoir de façonner votre avenir et de réaliser vos rêves." & vbCrLf & vbCrLf &
                       "Dans l'attente de vos nouvelles, je vous souhaite le meilleur pour votre avenir académique et professionnel." & vbCrLf & vbCrLf &
                       "Cordialement," & vbCrLf & vbCrLf & "Directeur brevet de technicien supérieur"

    End Sub

    Private Sub msgbody_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("email", "gmailapi")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "Smtp.gmail.com"
            e_mail = New MailMessage
            e_mail.From = New MailAddress(txtEmail.Text)
            e_mail.To.Add(txtmsgto.Text)
            e_mail.Subject = txtmsgsubject.Text
            e_mail.Body = msgbody.Text
            Smtp_Server.Send(e_mail)
            MessageBox.Show("Email sent successfully.")

        Catch ex As Exception
            MessageBox.Show("An error occurred while sending the email: " & ex.Message)
        End Try

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

    Private Sub msgbody_TextChanged(sender As Object, e As EventArgs) Handles msgbody.TextChanged

    End Sub
End Class