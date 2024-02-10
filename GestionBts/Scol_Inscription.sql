USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_Inscription]    Script Date: 2/10/2024 3:39:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_Inscription](
	[Numero] [bigint] IDENTITY(1,1) NOT NULL,
	[CodeMassar] [nchar](20) NOT NULL,
	[AnneeScolaire] [nchar](10) NULL,
	[Dateinscription] [date] NULL,
 CONSTRAINT [PK_Scol_Inscription] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Scol_Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Scol_Inscription_Scol_Etudiant] FOREIGN KEY([CodeMassar])
REFERENCES [dbo].[Scol_Etudiant] ([CodeMassar])
GO

ALTER TABLE [dbo].[Scol_Inscription] CHECK CONSTRAINT [FK_Scol_Inscription_Scol_Etudiant]
GO

