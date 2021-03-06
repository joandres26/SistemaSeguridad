USE [SistemaSeguridad]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NULL,
	[Foto] [image] NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[idEstado] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReporteEntregado]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReporteEntregado](
	[IdEntrega] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdArticulo] [int] NOT NULL,
	[Celular] [int] NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReporteEntrehado] PRIMARY KEY CLUSTERED 
(
	[IdEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReporteExtravio]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReporteExtravio](
	[IdReporte] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Celular] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[NombreContacto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReporteExtravio] PRIMARY KEY CLUSTERED 
(
	[IdReporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/12/2018 21:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido1] [varchar](50) NOT NULL,
	[Apellido2] [varchar](50) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulo] ON 

INSERT [dbo].[Articulo] ([IdArticulo], [IdCategoria], [IdEstado], [Descripcion], [Marca], [Foto]) VALUES (1, 2, 2, N'Galaxy 6', N'Samsung', NULL)
INSERT [dbo].[Articulo] ([IdArticulo], [IdCategoria], [IdEstado], [Descripcion], [Marca], [Foto]) VALUES (2, 1, 1, N'Camisa Amarilla', NULL, NULL)
INSERT [dbo].[Articulo] ([IdArticulo], [IdCategoria], [IdEstado], [Descripcion], [Marca], [Foto]) VALUES (3, 2, 2, N'Iphone 4', N'Iphone', NULL)
INSERT [dbo].[Articulo] ([IdArticulo], [IdCategoria], [IdEstado], [Descripcion], [Marca], [Foto]) VALUES (4, 1, 1, N'Legos', N'Toys', NULL)
INSERT [dbo].[Articulo] ([IdArticulo], [IdCategoria], [IdEstado], [Descripcion], [Marca], [Foto]) VALUES (5, 2, 1, N'Galaxy 8', N'Samsung', NULL)
SET IDENTITY_INSERT [dbo].[Articulo] OFF
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion]) VALUES (1, N'Ropa')
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion]) VALUES (2, N'Dispositivo Movil')
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion]) VALUES (3, N'Juguete')
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion]) VALUES (4, N'Lentes de sol')
INSERT [dbo].[Estado] ([idEstado], [Descripcion]) VALUES (1, N'Custodia')
INSERT [dbo].[Estado] ([idEstado], [Descripcion]) VALUES (2, N'Entregado')
INSERT [dbo].[Estado] ([idEstado], [Descripcion]) VALUES (3, N'Desechado')
SET IDENTITY_INSERT [dbo].[ReporteEntregado] ON 

INSERT [dbo].[ReporteEntregado] ([IdEntrega], [IdUsuario], [Fecha], [IdArticulo], [Celular], [Email]) VALUES (1, 3, CAST(N'2018-01-23' AS Date), 2, 88997744, N'koko@gmail.com')
INSERT [dbo].[ReporteEntregado] ([IdEntrega], [IdUsuario], [Fecha], [IdArticulo], [Celular], [Email]) VALUES (2, 3, CAST(N'2018-12-17' AS Date), 3, 77441122, N'wendr@gmail.com')
INSERT [dbo].[ReporteEntregado] ([IdEntrega], [IdUsuario], [Fecha], [IdArticulo], [Celular], [Email]) VALUES (3, 3, CAST(N'2018-12-17' AS Date), 2, 11993311, N'Ejemplo@gmail.com')
INSERT [dbo].[ReporteEntregado] ([IdEntrega], [IdUsuario], [Fecha], [IdArticulo], [Celular], [Email]) VALUES (4, 3, CAST(N'2018-12-17' AS Date), 3, 339922, N'Els@gmail.com')
INSERT [dbo].[ReporteEntregado] ([IdEntrega], [IdUsuario], [Fecha], [IdArticulo], [Celular], [Email]) VALUES (5, 3, CAST(N'2018-12-12' AS Date), 3, 11553311, N'asd@gmail.com')
SET IDENTITY_INSERT [dbo].[ReporteEntregado] OFF
SET IDENTITY_INSERT [dbo].[ReporteExtravio] ON 

INSERT [dbo].[ReporteExtravio] ([IdReporte], [IdUsuario], [Fecha], [Descripcion], [Celular], [Email], [NombreContacto]) VALUES (1, 3, CAST(N'2018-01-01' AS Date), N'Telefono samsung galaxy 7', N'88665544', N'ejemplo@gmail.com', N'Ricardo')
INSERT [dbo].[ReporteExtravio] ([IdReporte], [IdUsuario], [Fecha], [Descripcion], [Celular], [Email], [NombreContacto]) VALUES (2, 3, CAST(N'2018-02-10' AS Date), N'Pantalon cafe marca volkon', N'66332244', N'Example@gmail.com', N'Josue')
INSERT [dbo].[ReporteExtravio] ([IdReporte], [IdUsuario], [Fecha], [Descripcion], [Celular], [Email], [NombreContacto]) VALUES (3, 3, CAST(N'2018-12-17' AS Date), N'Legos rojos', N'77441122', N'a@asd.com', N'Pedro Jimenez')
SET IDENTITY_INSERT [dbo].[ReporteExtravio] OFF
INSERT [dbo].[Rol] ([IdRol], [Descripcion]) VALUES (1, N'Administrador')
INSERT [dbo].[Rol] ([IdRol], [Descripcion]) VALUES (2, N'Custodia')
INSERT [dbo].[Rol] ([IdRol], [Descripcion]) VALUES (3, N'Invitado')
INSERT [dbo].[Usuario] ([idUsuario], [Nombre], [Apellido1], [Apellido2], [Contrasenia], [IdRol]) VALUES (1, N'Adm', N'Adm', N'Adm', N'Adm', 1)
INSERT [dbo].[Usuario] ([idUsuario], [Nombre], [Apellido1], [Apellido2], [Contrasenia], [IdRol]) VALUES (2, N'Custodia', N'Custodia', N'Custodia', N'Custodia', 2)
INSERT [dbo].[Usuario] ([idUsuario], [Nombre], [Apellido1], [Apellido2], [Contrasenia], [IdRol]) VALUES (3, N'Felipe (Invitado)', N'Invitado', N'Invitado', N'Invitado', 3)
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Categoria]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Estado]
GO
ALTER TABLE [dbo].[ReporteEntregado]  WITH CHECK ADD  CONSTRAINT [FK_ReporteEntrehado_Articulo] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulo] ([IdArticulo])
GO
ALTER TABLE [dbo].[ReporteEntregado] CHECK CONSTRAINT [FK_ReporteEntrehado_Articulo]
GO
ALTER TABLE [dbo].[ReporteEntregado]  WITH CHECK ADD  CONSTRAINT [FK_ReporteEntrehado_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReporteEntregado] CHECK CONSTRAINT [FK_ReporteEntrehado_Usuario]
GO
ALTER TABLE [dbo].[ReporteExtravio]  WITH CHECK ADD  CONSTRAINT [FK_ReporteExtravio_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReporteExtravio] CHECK CONSTRAINT [FK_ReporteExtravio_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
