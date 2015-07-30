USE [MedicaDB]
GO

/****** Object:  Table [dbo].[Paciente]    Script Date: 30/07/2015 06:06:29 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Paciente](
	[PacienteId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombres] [nchar](500) NOT NULL,
	[ApellidoPaterno] [nchar](100) NOT NULL,
	[ApellidoMaterno] [nchar](100) NULL,
	[Telefono] [numeric](18, 0) NOT NULL,
	[Direccion] [nchar](500) NULL,
	[GeneroID] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Genero] FOREIGN KEY([GeneroID])
REFERENCES [dbo].[Genero] ([GeneroId])
GO

ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Genero]
GO


