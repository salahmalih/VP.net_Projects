<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmailSend
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Me.Guna2ResizeForm1 = New Guna.UI2.WinForms.Guna2ResizeForm(Me.components)
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnmini = New System.Windows.Forms.PictureBox()
        Me.lblfermer = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtmsgsubject = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtmsgto = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAjouter = New Guna.UI2.WinForms.Guna2Button()
        Me.msgbody = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmail = New Guna.UI2.WinForms.Guna2TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblfermer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2ResizeForm1
        '
        Me.Guna2ResizeForm1.TargetForm = Me
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 20
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Guna2Panel2.BorderRadius = 10
        Me.Guna2Panel2.Controls.Add(Me.btnmini)
        Me.Guna2Panel2.Controls.Add(Me.lblfermer)
        Me.Guna2Panel2.CustomizableEdges = CustomizableEdges11
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        Me.Guna2Panel2.Size = New System.Drawing.Size(898, 58)
        Me.Guna2Panel2.TabIndex = 3
        '
        'btnmini
        '
        Me.btnmini.BackColor = System.Drawing.Color.Transparent
        Me.btnmini.Image = Global.GestionBts.My.Resources.Resources.minus
        Me.btnmini.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnmini.Location = New System.Drawing.Point(790, 11)
        Me.btnmini.Margin = New System.Windows.Forms.Padding(2)
        Me.btnmini.Name = "btnmini"
        Me.btnmini.Size = New System.Drawing.Size(45, 39)
        Me.btnmini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnmini.TabIndex = 10
        Me.btnmini.TabStop = False
        '
        'lblfermer
        '
        Me.lblfermer.BackColor = System.Drawing.Color.Transparent
        Me.lblfermer.Image = Global.GestionBts.My.Resources.Resources.close
        Me.lblfermer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblfermer.Location = New System.Drawing.Point(839, 11)
        Me.lblfermer.Margin = New System.Windows.Forms.Padding(2)
        Me.lblfermer.Name = "lblfermer"
        Me.lblfermer.Size = New System.Drawing.Size(48, 39)
        Me.lblfermer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lblfermer.TabIndex = 9
        Me.lblfermer.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(30, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 28)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Message Subject"
        '
        'txtmsgsubject
        '
        Me.txtmsgsubject.Animated = True
        Me.txtmsgsubject.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtmsgsubject.BorderRadius = 10
        Me.txtmsgsubject.CustomizableEdges = CustomizableEdges9
        Me.txtmsgsubject.DefaultText = "Demande de nouvelles concernant votre état et votre parcours académique"
        Me.txtmsgsubject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtmsgsubject.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtmsgsubject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtmsgsubject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtmsgsubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtmsgsubject.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtmsgsubject.ForeColor = System.Drawing.Color.Black
        Me.txtmsgsubject.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtmsgsubject.Location = New System.Drawing.Point(203, 211)
        Me.txtmsgsubject.Name = "txtmsgsubject"
        Me.txtmsgsubject.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtmsgsubject.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtmsgsubject.PlaceholderText = ""
        Me.txtmsgsubject.SelectedText = ""
        Me.txtmsgsubject.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        Me.txtmsgsubject.Size = New System.Drawing.Size(542, 45)
        Me.txtmsgsubject.TabIndex = 14
        '
        'txtmsgto
        '
        Me.txtmsgto.Animated = True
        Me.txtmsgto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtmsgto.BorderRadius = 10
        Me.txtmsgto.CustomizableEdges = CustomizableEdges7
        Me.txtmsgto.DefaultText = ""
        Me.txtmsgto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtmsgto.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtmsgto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtmsgto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtmsgto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtmsgto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtmsgto.ForeColor = System.Drawing.Color.Black
        Me.txtmsgto.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtmsgto.Location = New System.Drawing.Point(201, 156)
        Me.txtmsgto.Name = "txtmsgto"
        Me.txtmsgto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtmsgto.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtmsgto.PlaceholderText = ""
        Me.txtmsgto.SelectedText = ""
        Me.txtmsgto.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Me.txtmsgto.Size = New System.Drawing.Size(542, 45)
        Me.txtmsgto.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(73, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 28)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Message To"
        '
        'btnAjouter
        '
        Me.btnAjouter.Animated = True
        Me.btnAjouter.BackColor = System.Drawing.Color.Transparent
        Me.btnAjouter.BorderRadius = 20
        Me.btnAjouter.CustomizableEdges = CustomizableEdges3
        Me.btnAjouter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAjouter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAjouter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAjouter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAjouter.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAjouter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnAjouter.ForeColor = System.Drawing.Color.Black
        Me.btnAjouter.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnAjouter.Location = New System.Drawing.Point(712, 614)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Me.btnAjouter.Size = New System.Drawing.Size(147, 56)
        Me.btnAjouter.TabIndex = 17
        Me.btnAjouter.Text = "Envoyer"
        '
        'msgbody
        '
        Me.msgbody.Animated = True
        Me.msgbody.AutoScroll = True
        Me.msgbody.AutoScrollMargin = New System.Drawing.Size(1, 1)
        Me.msgbody.AutoSize = True
        Me.msgbody.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.msgbody.BorderRadius = 10
        Me.msgbody.CustomizableEdges = CustomizableEdges1
        Me.msgbody.DefaultText = ""
        Me.msgbody.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.msgbody.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.msgbody.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.msgbody.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.msgbody.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.msgbody.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.msgbody.ForeColor = System.Drawing.Color.Black
        Me.msgbody.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.msgbody.Location = New System.Drawing.Point(47, 274)
        Me.msgbody.Multiline = True
        Me.msgbody.Name = "msgbody"
        Me.msgbody.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.msgbody.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.msgbody.PlaceholderText = ""
        Me.msgbody.SelectedText = ""
        Me.msgbody.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Me.msgbody.Size = New System.Drawing.Size(812, 334)
        Me.msgbody.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(140, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 28)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "From "
        '
        'txtEmail
        '
        Me.txtEmail.Animated = True
        Me.txtEmail.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtEmail.BorderRadius = 10
        Me.txtEmail.CustomizableEdges = CustomizableEdges5
        Me.txtEmail.DefaultText = ""
        Me.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.Location = New System.Drawing.Point(208, 91)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmail.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtEmail.PlaceholderText = ""
        Me.txtEmail.SelectedText = ""
        Me.txtEmail.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Me.txtEmail.Size = New System.Drawing.Size(542, 45)
        Me.txtEmail.TabIndex = 14
        '
        'EmailSend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GestionBts.My.Resources.Resources.Sans_titre001
        Me.ClientSize = New System.Drawing.Size(898, 673)
        Me.Controls.Add(Me.msgbody)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtmsgto)
        Me.Controls.Add(Me.txtmsgsubject)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EmailSend"
        Me.Text = "EmailSend"
        Me.Guna2Panel2.ResumeLayout(False)
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblfermer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2ResizeForm1 As Guna.UI2.WinForms.Guna2ResizeForm
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtmsgto As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtmsgsubject As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnAjouter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents msgbody As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmail As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnmini As PictureBox
    Friend WithEvents lblfermer As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
