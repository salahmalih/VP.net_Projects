USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_Suivilaur]    Script Date: 2/10/2024 3:40:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_Suivilaur](
	[NDossier] [int] IDENTITY(1,1) NOT NULL,
	[Matricule] [int] NOT NULL,
	[Ecole] [nchar](100) NULL,
	[Nom] [nchar](100) NULL,
	[DateEntr] [date] NULL,
	[DateSortie] [date] NULL,
 CONSTRAINT [PK_Scol_Suivilaur] PRIMARY KEY CLUSTERED 
(
	[NDossier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

