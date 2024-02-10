USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_Etudiant]    Script Date: 2/10/2024 3:39:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_Etudiant](
	[CodeMassar] [nchar](20) NOT NULL,
	[NCin] [nchar](20) NOT NULL,
	[Nom] [nchar](50) NOT NULL,
	[Prenom] [nchar](50) NOT NULL,
	[Sexe] [nchar](10) NULL,
	[DateNaissance] [date] NULL,
	[Lieunaissance] [nchar](20) NULL,
	[Adresse] [nchar](100) NULL,
	[Telephone] [bigint] NULL,
	[Email] [nchar](50) NULL,
	[IDbranche] [int] NULL,
 CONSTRAINT [PK_Scol_Etudiant_1] PRIMARY KEY CLUSTERED 
(
	[CodeMassar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Scol_Etudiant]  WITH CHECK ADD  CONSTRAINT [FK_Scol_Etudiant_Scol_Branche] FOREIGN KEY([IDbranche])
REFERENCES [dbo].[Scol_Branche] ([IDbranche])
GO

ALTER TABLE [dbo].[Scol_Etudiant] CHECK CONSTRAINT [FK_Scol_Etudiant_Scol_Branche]
GO

