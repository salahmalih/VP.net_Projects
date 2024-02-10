USE [Scol]
GO

/****** Object:  Table [dbo].[Scol_Laureats]    Script Date: 2/10/2024 3:39:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scol_Laureats](
	[Matricule] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [bigint] NOT NULL,
	[Ecole] [nchar](50) NULL,
	[Nom] [nchar](50) NULL,
	[DateEntr] [date] NULL,
	[DateSortie] [date] NULL,
 CONSTRAINT [PK_Scol_Laureats] PRIMARY KEY CLUSTERED 
(
	[Matricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Scol_Laureats]  WITH CHECK ADD  CONSTRAINT [FK_Scol_Laureats_Scol_Inscription] FOREIGN KEY([Numero])
REFERENCES [dbo].[Scol_Inscription] ([Numero])
GO

ALTER TABLE [dbo].[Scol_Laureats] CHECK CONSTRAINT [FK_Scol_Laureats_Scol_Inscription]
GO

