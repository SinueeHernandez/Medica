USE [MedicaDB]
GO

/****** Object:  Table [dbo].[Consulta]    Script Date: 30/07/2015 06:04:44 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Consulta](
	[ConsultaId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MedicoId] [numeric](18, 0) NOT NULL,
	[PacienteId] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Sintomas] [nchar](500) NULL,
	[Diagnostico] [nchar](500) NULL,
	[Tratamiento] [nchar](500) NULL,
	[Observaciones] [nchar](500) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[ConsultaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Medico] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([MedicoID])
GO

ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Medico]
GO

ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Paciente] ([PacienteId])
GO

ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente]
GO


