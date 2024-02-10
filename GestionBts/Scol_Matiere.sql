USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_Matiere]    Script Date: 2/10/2024 3:39:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_Matiere](
	[idIDbranche] [int] NOT NULL,
	[CodeMatiere] [nchar](10) NOT NULL,
	[LibFrancais] [nchar](100) NULL,
	[LibArabe] [nchar](10) NULL,
	[CodeTypeMatiere] [nchar](10) NULL,
	[Remarques] [ntext] NULL,
 CONSTRAINT [PK_Scol_Matiere] PRIMARY KEY CLUSTERED 
(
	[CodeMatiere] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Scol_Matiere]  WITH CHECK ADD  CONSTRAINT [FK_Scol_Matiere_Scol_Programme] FOREIGN KEY([idIDbranche])
REFERENCES [dbo].[Scol_Branche] ([IDbranche])
GO

ALTER TABLE [dbo].[Scol_Matiere] CHECK CONSTRAINT [FK_Scol_Matiere_Scol_Programme]
GO

