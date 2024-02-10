USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_TEmployes]    Script Date: 2/10/2024 3:40:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_TEmployes](
	[DRPP] [bigint] NOT NULL,
	[CodeMassar] [nchar](20) NOT NULL,
	[Dossier] [nchar](10) NOT NULL,
	[Echelle] [nchar](20) NOT NULL,
	[CIN] [nchar](30) NOT NULL,
	[Nom] [nchar](30) NULL,
	[Prenom] [nchar](30) NULL,
	[DateNaissance] [datetime] NULL,
	[Ville] [nchar](30) NULL,
	[LieuNaissance] [nchar](100) NULL,
	[Nationalite] [nchar](15) NULL,
	[Adresse] [nchar](200) NULL,
	[Sexe] [nchar](10) NULL,
	[DateEmbauche] [datetime] NULL,
	[DateSortie] [datetime] NULL,
	[DateFinContrat] [datetime] NULL,
	[NiveauEtudes] [nchar](50) NULL,
	[NCompte] [nchar](24) NOT NULL,
	[Tel] [bigint] NULL,
	[Email] [nchar](50) NULL,
	[NumeroCNSS] [nchar](10) NOT NULL,
	[Diplome] [nchar](60) NULL,
	[Module] [nchar](50) NULL,
 CONSTRAINT [PK_Grh_TEmployes] PRIMARY KEY CLUSTERED 
(
	[DRPP] ASC,
	[CodeMassar] ASC,
	[Dossier] ASC,
	[Echelle] ASC,
	[CIN] ASC,
	[NCompte] ASC,
	[NumeroCNSS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

