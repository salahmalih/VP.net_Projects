USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_Branche]    Script Date: 2/10/2024 3:38:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_Branche](
	[IDbranche] [int] IDENTITY(1,1) NOT NULL,
	[NomBrancheFR] [varchar](100) NULL,
	[Annee] [int] NULL,
	[NbrModule] [int] NULL,
	[NbrHeure] [int] NULL,
	[NbrMaxAnneeF] [int] NULL,
	[NomDiplome] [nchar](100) NULL,
	[TYPEFORMATION] [nchar](100) NULL,
 CONSTRAINT [PK_Scol_Branche] PRIMARY KEY CLUSTERED 
(
	[IDbranche] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

