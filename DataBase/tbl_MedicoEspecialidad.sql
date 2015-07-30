USE [MedicaDB]
GO

/****** Object:  Table [dbo].[MedicoEspecialidad]    Script Date: 30/07/2015 06:06:08 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MedicoEspecialidad](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MedicoId] [numeric](18, 0) NULL,
	[EspecilidadId] [numeric](18, 0) NULL,
 CONSTRAINT [PK_MedicoEspecialidad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MedicoEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_MedicoEspecialidad_Especialidades] FOREIGN KEY([EspecilidadId])
REFERENCES [dbo].[Especialidades] ([EspecialidadId])
GO

ALTER TABLE [dbo].[MedicoEspecialidad] CHECK CONSTRAINT [FK_MedicoEspecialidad_Especialidades]
GO

ALTER TABLE [dbo].[MedicoEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_MedicoEspecialidad_Medico] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([MedicoID])
GO

ALTER TABLE [dbo].[MedicoEspecialidad] CHECK CONSTRAINT [FK_MedicoEspecialidad_Medico]
GO


