USE [MedicaDB]
GO

/****** Object:  Table [dbo].[Medico]    Script Date: 30/07/2015 06:05:49 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Medico](
	[MedicoID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](500) NULL,
	[ApellidoPaterno] [nchar](500) NULL,
	[ApellidoMaterno] [nchar](500) NOT NULL,
	[Telefono] [numeric](18, 0) NOT NULL,
	[Foto] [binary](500) NULL,
	[Biografia] [nvarchar](max) NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[MedicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


