USE [master]
GO
/****** Object:  Database [TP4_AlvarezMartinAndres_DB]    Script Date: 10/08/2022 13:00:08 ******/
CREATE DATABASE [TP4_AlvarezMartinAndres_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP4_AlvarezMartinAndres_DB', FILENAME = N'D:\Programación\Sql Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TP4_AlvarezMartinAndres_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP4_AlvarezMartinAndres_DB_log', FILENAME = N'D:\Programación\Sql Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TP4_AlvarezMartinAndres_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP4_AlvarezMartinAndres_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET  MULTI_USER 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET QUERY_STORE = OFF
GO
USE [TP4_AlvarezMartinAndres_DB]
GO
/****** Object:  Table [dbo].[Atencion]    Script Date: 10/08/2022 13:00:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atencion](
	[idDeAtencion] [int] IDENTITY(1,1) NOT NULL,
	[idDeMedico] [int] NOT NULL,
	[idDePaciente] [int] NOT NULL,
	[motivoDeLaConsulta] [varchar](200) NOT NULL,
	[tratamiento] [varchar](200) NOT NULL,
	[diagnostico] [varchar](200) NOT NULL,
	[fechaDeLaAtencion] [datetime] NOT NULL,
 CONSTRAINT [PK_Atencion] PRIMARY KEY CLUSTERED 
(
	[idDeAtencion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 10/08/2022 13:00:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[idDeMedico] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](70) NOT NULL,
	[edad] [int] NOT NULL,
	[dni] [int] NOT NULL,
	[sexo] [varchar](50) NOT NULL,
	[matricula] [int] NOT NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[idDeMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 10/08/2022 13:00:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[idDePaciente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](70) NOT NULL,
	[edad] [int] NOT NULL,
	[dni] [int] NOT NULL,
	[sexo] [varchar](50) NOT NULL,
	[antecedentesMedicos] [varchar](500) NOT NULL,
	[tratamientoEnCurso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[idDePaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurnoMedico]    Script Date: 10/08/2022 13:00:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurnoMedico](
	[fechaTurno] [datetime] NULL,
	[idDeMedico] [int] NULL,
	[idDePaciente] [int] NULL,
	[idDeTurnoMedico] [int] IDENTITY(1,1) NOT NULL,
	[seRealizoAtencionDelTurno] [varchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Atencion] ON 

INSERT [dbo].[Atencion] ([idDeAtencion], [idDeMedico], [idDePaciente], [motivoDeLaConsulta], [tratamiento], [diagnostico], [fechaDeLaAtencion]) VALUES (1, 1, 1, N'Bulto en el abdomen', N'En observación', N'Esperando resultados de los analisis', CAST(N'2022-08-10T01:58:01.000' AS DateTime))
INSERT [dbo].[Atencion] ([idDeAtencion], [idDeMedico], [idDePaciente], [motivoDeLaConsulta], [tratamiento], [diagnostico], [fechaDeLaAtencion]) VALUES (2, 1, 1, N'Trajo los resultados del analasis', N'Medicamento xxx', N'Cancer', CAST(N'2022-08-10T02:58:02.000' AS DateTime))
INSERT [dbo].[Atencion] ([idDeAtencion], [idDeMedico], [idDePaciente], [motivoDeLaConsulta], [tratamiento], [diagnostico], [fechaDeLaAtencion]) VALUES (3, 2, 2, N'Dolor de cabeza', N'Medicamento yyy', N'Esperando resultados de los analisis', CAST(N'2022-08-10T02:58:03.000' AS DateTime))
INSERT [dbo].[Atencion] ([idDeAtencion], [idDeMedico], [idDePaciente], [motivoDeLaConsulta], [tratamiento], [diagnostico], [fechaDeLaAtencion]) VALUES (4, 3, 3, N'Fatiga ', N'Vitaminas aaa', N'falta de vitamina', CAST(N'2000-05-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Atencion] ([idDeAtencion], [idDeMedico], [idDePaciente], [motivoDeLaConsulta], [tratamiento], [diagnostico], [fechaDeLaAtencion]) VALUES (5, 4, 4, N'Dolor de rodilla ', N'Descanso', N'dolor articular', CAST(N'2000-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Atencion] ([idDeAtencion], [idDeMedico], [idDePaciente], [motivoDeLaConsulta], [tratamiento], [diagnostico], [fechaDeLaAtencion]) VALUES (6, 5, 5, N'Descamación en la piel ', N'Pomada xxx', N'Hongos', CAST(N'2000-06-24T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Atencion] OFF
GO
SET IDENTITY_INSERT [dbo].[Medico] ON 

INSERT [dbo].[Medico] ([idDeMedico], [nombre], [edad], [dni], [sexo], [matricula]) VALUES (1, N'Álvarez Martín Andrés', 30, 363434343, N'Hombre', 23232)
INSERT [dbo].[Medico] ([idDeMedico], [nombre], [edad], [dni], [sexo], [matricula]) VALUES (2, N'Roberto de la fuente', 34, 232323211, N'Hombre', 4242)
INSERT [dbo].[Medico] ([idDeMedico], [nombre], [edad], [dni], [sexo], [matricula]) VALUES (3, N'Julia Lopez', 35, 6666666, N'Mujer', 666656)
INSERT [dbo].[Medico] ([idDeMedico], [nombre], [edad], [dni], [sexo], [matricula]) VALUES (4, N'Roberta Lopez', 36, 77777, N'Mujer', 34343)
INSERT [dbo].[Medico] ([idDeMedico], [nombre], [edad], [dni], [sexo], [matricula]) VALUES (5, N'Josefa Hernesta', 22, 22222, N'Mujer', 212122)
SET IDENTITY_INSERT [dbo].[Medico] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([idDePaciente], [nombre], [edad], [dni], [sexo], [antecedentesMedicos], [tratamientoEnCurso]) VALUES (1, N'Roberto juan', 22, 34345234, N'Hombre', N'Antecedentes Medicos de Roberto juan', N'False')
INSERT [dbo].[Paciente] ([idDePaciente], [nombre], [edad], [dni], [sexo], [antecedentesMedicos], [tratamientoEnCurso]) VALUES (2, N'Perez juan', 11, 222222, N'Hombre', N'Antecedentes Medicos de Perez juan', N'False')
INSERT [dbo].[Paciente] ([idDePaciente], [nombre], [edad], [dni], [sexo], [antecedentesMedicos], [tratamientoEnCurso]) VALUES (3, N'Hernesto juan', 33, 44444, N'Hombre', N'Antecedentes Medicos de Hernesto juan', N'False')
INSERT [dbo].[Paciente] ([idDePaciente], [nombre], [edad], [dni], [sexo], [antecedentesMedicos], [tratamientoEnCurso]) VALUES (4, N'Francisco', 21, 3434343, N'Hombre', N'Antecedentes Medicos de Francisco', N'True')
INSERT [dbo].[Paciente] ([idDePaciente], [nombre], [edad], [dni], [sexo], [antecedentesMedicos], [tratamientoEnCurso]) VALUES (5, N'Julia Lopez', 16, 212121, N'Mujer', N'Antecedentes Medicos de Julia Lopez', N'True')
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[TurnoMedico] ON 

INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-08-10T01:58:01.000' AS DateTime), 1, 1, 1, N'False')
INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-08-10T02:58:01.000' AS DateTime), 1, 2, 2, N'False')
INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-08-10T03:58:02.000' AS DateTime), 1, 3, 3, N'False')
INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-08-10T04:58:03.000' AS DateTime), 2, 2, 4, N'False')
INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-05-18T05:02:23.000' AS DateTime), 3, 3, 5, N'False')
INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-05-19T05:02:23.000' AS DateTime), 4, 4, 6, N'False')
INSERT [dbo].[TurnoMedico] ([fechaTurno], [idDeMedico], [idDePaciente], [idDeTurnoMedico], [seRealizoAtencionDelTurno]) VALUES (CAST(N'2022-05-20T05:02:23.000' AS DateTime), 5, 5, 7, N'False')
SET IDENTITY_INSERT [dbo].[TurnoMedico] OFF
GO
ALTER TABLE [dbo].[Atencion]  WITH CHECK ADD  CONSTRAINT [FK_Atencion_Medico] FOREIGN KEY([idDeMedico])
REFERENCES [dbo].[Medico] ([idDeMedico])
GO
ALTER TABLE [dbo].[Atencion] CHECK CONSTRAINT [FK_Atencion_Medico]
GO
ALTER TABLE [dbo].[Atencion]  WITH CHECK ADD  CONSTRAINT [FK_Atencion_Paciente] FOREIGN KEY([idDePaciente])
REFERENCES [dbo].[Paciente] ([idDePaciente])
GO
ALTER TABLE [dbo].[Atencion] CHECK CONSTRAINT [FK_Atencion_Paciente]
GO
ALTER TABLE [dbo].[TurnoMedico]  WITH CHECK ADD  CONSTRAINT [FK_TurnoMedico_Medico] FOREIGN KEY([idDeMedico])
REFERENCES [dbo].[Medico] ([idDeMedico])
GO
ALTER TABLE [dbo].[TurnoMedico] CHECK CONSTRAINT [FK_TurnoMedico_Medico]
GO
ALTER TABLE [dbo].[TurnoMedico]  WITH CHECK ADD  CONSTRAINT [FK_TurnoMedico_Paciente] FOREIGN KEY([idDePaciente])
REFERENCES [dbo].[Paciente] ([idDePaciente])
GO
ALTER TABLE [dbo].[TurnoMedico] CHECK CONSTRAINT [FK_TurnoMedico_Paciente]
GO
USE [master]
GO
ALTER DATABASE [TP4_AlvarezMartinAndres_DB] SET  READ_WRITE 
GO
