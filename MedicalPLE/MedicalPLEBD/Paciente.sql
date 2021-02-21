
USE [MedicalPLEBD]
GO

/****** Object:  Table [dbo].[Paciente]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Paciente](
[PacienteId] [int] IDENTITY(1,1) NOT NULL,
[TipodocId] [int] NOT NULL,
[NumeroDocumento] [int] NOT NULL,
[NombreApellido] [varchar](400) NOT NULL,
[EstadCivil] [varchar](300) NOT NULL,
[FechaNacimiento] [date] NULL,
[Edad] [int] NOT NULL,
[LugarNacimiento] [varchar](400) NOT NULL,
[Nacionalidad] [varchar](300) NOT NULL,
[Genero] [varchar](300) NOT NULL
,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Tipodoc] FOREIGN KEY([TipodocId])
REFERENCES [dbo].[Tipodoc] ([TipodocId])
GO

ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Tipodoc]
GO



-- <-------------------------------------------------------------------------------------------->

