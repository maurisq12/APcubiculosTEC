USE [CubiculosTEC]
 
/****** Object:  Table [dbo].[Administradores]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Administradores](
	[idAdministradores] [int] IDENTITY(1,1) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[idAdministradores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[Cubiculos]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Cubiculos](
	[idCubiculo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idEstado] [smallint] NOT NULL,
	[capacidad] [int] NOT NULL,
	[tiempoMaximo] [time](0) NULL,
 CONSTRAINT [PK_Cubiculos] PRIMARY KEY CLUSTERED 
(
	[idCubiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[EstadosCubiculo]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[EstadosCubiculo](
	[idEstado] [smallint] IDENTITY(1,1) NOT NULL,
	[estadoActual] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadosCubiculo] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[EstadosEstudiante]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[EstadosEstudiante](
	[idEstadoEstudiante] [smallint] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadosEstudiante] PRIMARY KEY CLUSTERED 
(
	[idEstadoEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Estudiantes](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido1] [varchar](50) NOT NULL,
	[apellido2] [varchar](50) NOT NULL,
	[edad] [smallint] NOT NULL,
	[fechaDeNacimiento] [date] NOT NULL,
	[idEstadoEstudiante] [smallint] NOT NULL,
 CONSTRAINT [PK_Estudiantes] PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[Reservaciones]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Reservaciones](
	[idCubiculo] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[fechaDeUso] [date] NOT NULL,
	[horaInicio] [time](0) NOT NULL,
	[horaFinal] [time](0) NOT NULL,
	[confirmacion] [bit] NOT NULL,
	[fechaDeReservacion] [date] NOT NULL,
	[idReservacion] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Reservaciones] PRIMARY KEY CLUSTERED 
(
	[idReservacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[ServiciosCubiculo]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[ServiciosCubiculo](
	[idServicioEspecial] [smallint] NOT NULL,
	[idReservacion] [int] NOT NULL
) ON [PRIMARY]
 
/****** Object:  Table [dbo].[ServiciosEspeciales]    Script Date: 3/18/2023 7:31:22 PM ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[ServiciosEspeciales](
	[idServicioEspecial] [smallint] IDENTITY(1,1) NOT NULL,
	[servicioEspecial] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ServiciosEspeciales] PRIMARY KEY CLUSTERED 
(
	[idServicioEspecial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
ALTER TABLE [dbo].[Cubiculos]  WITH CHECK ADD  CONSTRAINT [FK_Cubiculos_EstadosCubiculo] FOREIGN KEY([idEstado])
REFERENCES [dbo].[EstadosCubiculo] ([idEstado])
 
ALTER TABLE [dbo].[Cubiculos] CHECK CONSTRAINT [FK_Cubiculos_EstadosCubiculo]
 
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_Estudiantes_EstadosEstudiante] FOREIGN KEY([idEstadoEstudiante])
REFERENCES [dbo].[EstadosEstudiante] ([idEstadoEstudiante])
 
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [FK_Estudiantes_EstadosEstudiante]
 
ALTER TABLE [dbo].[Reservaciones]  WITH CHECK ADD  CONSTRAINT [FK_Reservaciones_Cubiculos] FOREIGN KEY([idCubiculo])
REFERENCES [dbo].[Cubiculos] ([idCubiculo])
 
ALTER TABLE [dbo].[Reservaciones] CHECK CONSTRAINT [FK_Reservaciones_Cubiculos]
 
ALTER TABLE [dbo].[Reservaciones]  WITH CHECK ADD  CONSTRAINT [FK_Reservaciones_Estudiantes] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Estudiantes] ([idEstudiante])
 
ALTER TABLE [dbo].[Reservaciones] CHECK CONSTRAINT [FK_Reservaciones_Estudiantes]
 
ALTER TABLE [dbo].[ServiciosCubiculo]  WITH CHECK ADD  CONSTRAINT [FK_ServiciosCubiculo_Reservaciones] FOREIGN KEY([idReservacion])
REFERENCES [dbo].[Reservaciones] ([idReservacion])
 
ALTER TABLE [dbo].[ServiciosCubiculo] CHECK CONSTRAINT [FK_ServiciosCubiculo_Reservaciones]
 
ALTER TABLE [dbo].[ServiciosCubiculo]  WITH CHECK ADD  CONSTRAINT [FK_ServiciosCubiculo_ServiciosEspeciales] FOREIGN KEY([idServicioEspecial])
REFERENCES [dbo].[ServiciosEspeciales] ([idServicioEspecial])
 
ALTER TABLE [dbo].[ServiciosCubiculo] CHECK CONSTRAINT [FK_ServiciosCubiculo_ServiciosEspeciales]
 
