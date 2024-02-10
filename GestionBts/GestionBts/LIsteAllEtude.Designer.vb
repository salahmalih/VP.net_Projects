<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LIsteAllEtude
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRech = New Guna.UI2.WinForms.Guna2TextBox()
        Me.datagrideEtudiant = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.CodeMassar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateNaissance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lieunaissance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adresse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telephone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branche = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.edite = New System.Windows.Forms.DataGridViewImageColumn()
        Me.supp = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.datagrideEtudiant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRech
        '
        Me.txtRech.Animated = True
        Me.txtRech.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtRech.BorderRadius = 10
        Me.txtRech.CustomizableEdges = CustomizableEdges1
        Me.txtRech.DefaultText = ""
        Me.txtRech.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRech.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRech.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRech.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRech.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRech.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRech.ForeColor = System.Drawing.Color.Black
        Me.txtRech.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRech.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtRech.Location = New System.Drawing.Point(177, 137)
        Me.txtRech.Name = "txtRech"
        Me.txtRech.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRech.PlaceholderForeColor = System.Drawing.Color.Gray
        Me.txtRech.PlaceholderText = "Rechercher par Code Massar"
        Me.txtRech.SelectedText = ""
        Me.txtRech.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Me.txtRech.Size = New System.Drawing.Size(639, 50)
        Me.txtRech.TabIndex = 1
        Me.txtRech.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'datagrideEtudiant
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.datagrideEtudiant.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagrideEtudiant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagrideEtudiant.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.datagrideEtudiant.ColumnHeadersHeight = 45
        Me.datagrideEtudiant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.datagrideEtudiant.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeMassar, Me.NCin, Me.Nom, Me.Prenom, Me.Sexe, Me.DateNaissance, Me.Lieunaissance, Me.Adresse, Me.Telephone, Me.Email, Me.branche, Me.edite, Me.supp})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(207, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(97, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datagrideEtudiant.DefaultCellStyle = DataGridViewCellStyle3
        Me.datagrideEtudiant.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.datagrideEtudiant.GridColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.datagrideEtudiant.Location = New System.Drawing.Point(0, 256)
        Me.datagrideEtudiant.Name = "datagrideEtudiant"
        Me.datagrideEtudiant.RowHeadersVisible = False
        Me.datagrideEtudiant.RowHeadersWidth = 51
        Me.datagrideEtudiant.RowTemplate.Height = 29
        Me.datagrideEtudiant.Size = New System.Drawing.Size(1041, 420)
        Me.datagrideEtudiant.TabIndex = 0
        Me.datagrideEtudiant.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Orange
        Me.datagrideEtudiant.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.datagrideEtudiant.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.datagrideEtudiant.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.datagrideEtudiant.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.datagrideEtudiant.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.datagrideEtudiant.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.datagrideEtudiant.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.datagrideEtudiant.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.datagrideEtudiant.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.datagrideEtudiant.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.datagrideEtudiant.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.datagrideEtudiant.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.datagrideEtudiant.ThemeStyle.HeaderStyle.Height = 45
        Me.datagrideEtudiant.ThemeStyle.ReadOnly = False
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.Height = 29
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.datagrideEtudiant.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'CodeMassar
        '
        Me.CodeMassar.HeaderText = "Code Massar"
        Me.CodeMassar.MinimumWidth = 6
        Me.CodeMassar.Name = "CodeMassar"
        Me.CodeMassar.Width = 77
        '
        'NCin
        '
        Me.NCin.HeaderText = "CIN"
        Me.NCin.MinimumWidth = 6
        Me.NCin.Name = "NCin"
        Me.NCin.Width = 76
        '
        'Nom
        '
        Me.Nom.HeaderText = "Nom"
        Me.Nom.MinimumWidth = 6
        Me.Nom.Name = "Nom"
        Me.Nom.Width = 77
        '
        'Prenom
        '
        Me.Prenom.HeaderText = "Prenom"
        Me.Prenom.MinimumWidth = 6
        Me.Prenom.Name = "Prenom"
        Me.Prenom.Width = 77
        '
        'Sexe
        '
        Me.Sexe.HeaderText = "Sexe"
        Me.Sexe.MinimumWidth = 6
        Me.Sexe.Name = "Sexe"
        Me.Sexe.Width = 76
        '
        'DateNaissance
        '
        Me.DateNaissance.HeaderText = "Date de Naissance"
        Me.DateNaissance.MinimumWidth = 6
        Me.DateNaissance.Name = "DateNaissance"
        Me.DateNaissance.Width = 77
        '
        'Lieunaissance
        '
        Me.Lieunaissance.HeaderText = "Lieu de Naissance"
        Me.Lieunaissance.MinimumWidth = 6
        Me.Lieunaissance.Name = "Lieunaissance"
        Me.Lieunaissance.Width = 77
        '
        'Adresse
        '
        Me.Adresse.HeaderText = "Adresse"
        Me.Adresse.MinimumWidth = 6
        Me.Adresse.Name = "Adresse"
        Me.Adresse.Width = 77
        '
        'Telephone
        '
        Me.Telephone.HeaderText = "Telephone"
        Me.Telephone.MinimumWidth = 6
        Me.Telephone.Name = "Telephone"
        Me.Telephone.Width = 76
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.Width = 77
        '
        'branche
        '
        Me.branche.HeaderText = "branche"
        Me.branche.MinimumWidth = 6
        Me.branche.Name = "branche"
        Me.branche.Width = 77
        '
        'edite
        '
        Me.edite.HeaderText = ""
        Me.edite.Image = Global.GestionBts.My.Resources.Resources.edit
        Me.edite.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.edite.MinimumWidth = 6
        Me.edite.Name = "edite"
        Me.edite.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.edite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.edite.Width = 76
        '
        'supp
        '
        Me.supp.HeaderText = ""
        Me.supp.Image = Global.GestionBts.My.Resources.Resources.trash_bin
        Me.supp.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.supp.MinimumWidth = 6
        Me.supp.Name = "supp"
        Me.supp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.supp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.supp.Width = 77
        '
        'LIsteAllEtude
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GestionBts.My.Resources.Resources.Sans_titre001
        Me.ClientSize = New System.Drawing.Size(1041, 676)
        Me.Controls.Add(Me.txtRech)
        Me.Controls.Add(Me.datagrideEtudiant)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LIsteAllEtude"
        Me.Text = "LIsteAllEtude"
        CType(Me.datagrideEtudiant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtRech As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents datagrideEtudiant As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents CodeMassar As DataGridViewTextBoxColumn
    Friend WithEvents NCin As DataGridViewTextBoxColumn
    Friend WithEvents Nom As DataGridViewTextBoxColumn
    Friend WithEvents Prenom As DataGridViewTextBoxColumn
    Friend WithEvents Sexe As DataGridViewTextBoxColumn
    Friend WithEvents DateNaissance As DataGridViewTextBoxColumn
    Friend WithEvents Lieunaissance As DataGridViewTextBoxColumn
    Friend WithEvents Adresse As DataGridViewTextBoxColumn
    Friend WithEvents Telephone As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents branche As DataGridViewTextBoxColumn
    Friend WithEvents edite As DataGridViewImageColumn
    Friend WithEvents supp As DataGridViewImageColumn
End Class
