USE [MedicaDB]
GO

/****** Object:  Table [dbo].[Especialidades]    Script Date: 30/07/2015 06:05:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Especialidades](
	[EspecialidadId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[EspecialidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


