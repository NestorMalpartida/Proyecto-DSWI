USE [master]
GO
/****** Object:  Database [bdproyecto]    Script Date: 9/05/2024 18:37 ******/
CREATE DATABASE [bdproyecto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bdproyecto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\bdproyecto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bdproyecto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\bdproyecto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [bdproyecto] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdproyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdproyecto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdproyecto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdproyecto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdproyecto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdproyecto] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdproyecto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdproyecto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdproyecto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdproyecto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdproyecto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdproyecto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdproyecto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdproyecto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdproyecto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdproyecto] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bdproyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdproyecto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdproyecto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdproyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdproyecto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdproyecto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdproyecto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdproyecto] SET RECOVERY FULL 
GO
ALTER DATABASE [bdproyecto] SET  MULTI_USER 
GO
ALTER DATABASE [bdproyecto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdproyecto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bdproyecto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bdproyecto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bdproyecto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bdproyecto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'bdproyecto', N'ON'
GO
ALTER DATABASE [bdproyecto] SET QUERY_STORE = ON
GO
ALTER DATABASE [bdproyecto] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [bdproyecto]
GO
/****** Object:  Table [dbo].[tb_boleta]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_boleta](
	[cod_boleta] [int] IDENTITY(1,1) NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[cod_cliente] [int] NOT NULL,
	[fecha_emision] [date] NOT NULL,
	[cod_producto] [int] NOT NULL,
	[total_pagar] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_tb_boleta] PRIMARY KEY CLUSTERED 
(
	[cod_boleta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_cliente]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_cliente](
	[cod_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[cod_distrito] [int] NOT NULL,
	[direccion] [varchar](128) NOT NULL,
 CONSTRAINT [PK_tb_cliente] PRIMARY KEY CLUSTERED 
(
	[cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_distrito]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_distrito](
	[cod_distrito] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](64) NOT NULL,
 CONSTRAINT [PK_tb_distrito] PRIMARY KEY CLUSTERED 
(
	[cod_distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_marca]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_marca](
	[cod_marca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](64) NOT NULL,
	[cod_pais] [int] NOT NULL,
	[ruc] [varchar](32) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[correo] [varchar](128) NOT NULL,
 CONSTRAINT [PK_tb_marca] PRIMARY KEY CLUSTERED 
(
	[cod_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_pais]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_pais](
	[cod_pais] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](64) NOT NULL,
 CONSTRAINT [PK_tb_pais] PRIMARY KEY CLUSTERED 
(
	[cod_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_producto]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_producto](
	[cod_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](128) NOT NULL,
	[descripcion] [varchar](256) NOT NULL,
	[cod_marca] [int] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_tb_producto] PRIMARY KEY CLUSTERED 
(
	[cod_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_rol]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_rol](
	[cod_rol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](64) NOT NULL,
 CONSTRAINT [PK_tb_rol] PRIMARY KEY CLUSTERED 
(
	[cod_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[cod_rol] [int] NOT NULL,
	[correo] [varchar](128) NOT NULL,
	[contrasena] [char](10) NOT NULL,
	[nombre] [varchar](128) NOT NULL,
	[dni] [char](8) NOT NULL,
	[telefono] [varchar](16) NOT NULL,
 CONSTRAINT [PK_tb_usuario] PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_boleta]  WITH CHECK ADD  CONSTRAINT [FK_tb_boleta_tb_cliente] FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[tb_cliente] ([cod_cliente])
GO
ALTER TABLE [dbo].[tb_boleta] CHECK CONSTRAINT [FK_tb_boleta_tb_cliente]
GO
ALTER TABLE [dbo].[tb_boleta]  WITH CHECK ADD  CONSTRAINT [FK_tb_boleta_tb_producto] FOREIGN KEY([cod_producto])
REFERENCES [dbo].[tb_producto] ([cod_producto])
GO
ALTER TABLE [dbo].[tb_boleta] CHECK CONSTRAINT [FK_tb_boleta_tb_producto]
GO
ALTER TABLE [dbo].[tb_boleta]  WITH CHECK ADD  CONSTRAINT [FK_tb_boleta_tb_usuario] FOREIGN KEY([cod_usuario])
REFERENCES [dbo].[tb_usuario] ([cod_usuario])
GO
ALTER TABLE [dbo].[tb_boleta] CHECK CONSTRAINT [FK_tb_boleta_tb_usuario]
GO
ALTER TABLE [dbo].[tb_cliente]  WITH CHECK ADD  CONSTRAINT [FK_tb_cliente_tb_distrito] FOREIGN KEY([cod_distrito])
REFERENCES [dbo].[tb_distrito] ([cod_distrito])
GO
ALTER TABLE [dbo].[tb_cliente] CHECK CONSTRAINT [FK_tb_cliente_tb_distrito]
GO
ALTER TABLE [dbo].[tb_cliente]  WITH CHECK ADD  CONSTRAINT [FK_tb_cliente_tb_usuario] FOREIGN KEY([cod_usuario])
REFERENCES [dbo].[tb_usuario] ([cod_usuario])
GO
ALTER TABLE [dbo].[tb_cliente] CHECK CONSTRAINT [FK_tb_cliente_tb_usuario]
GO
ALTER TABLE [dbo].[tb_marca]  WITH CHECK ADD  CONSTRAINT [FK_tb_marca_tb_pais] FOREIGN KEY([cod_pais])
REFERENCES [dbo].[tb_pais] ([cod_pais])
GO
ALTER TABLE [dbo].[tb_marca] CHECK CONSTRAINT [FK_tb_marca_tb_pais]
GO
ALTER TABLE [dbo].[tb_producto]  WITH CHECK ADD  CONSTRAINT [FK_tb_producto_tb_marca] FOREIGN KEY([cod_marca])
REFERENCES [dbo].[tb_marca] ([cod_marca])
GO
ALTER TABLE [dbo].[tb_producto] CHECK CONSTRAINT [FK_tb_producto_tb_marca]
GO
ALTER TABLE [dbo].[tb_usuario]  WITH CHECK ADD  CONSTRAINT [FK_tb_usuario_tb_rol] FOREIGN KEY([cod_rol])
REFERENCES [dbo].[tb_rol] ([cod_rol])
GO
ALTER TABLE [dbo].[tb_usuario] CHECK CONSTRAINT [FK_tb_usuario_tb_rol]
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteBoleta]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_deleteBoleta]
@cod_boleta int
as
begin
	delete tb_boleta where cod_boleta = @cod_boleta
end
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteCliente]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_deleteCliente]
@cod_cliente int
as
begin
	delete tb_cliente where cod_cliente = @cod_cliente
end
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteMarca]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_deleteMarca]
@cod_marca int
as
begin
	delete tb_marca where cod_marca = @cod_marca
end
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteProducto]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_deleteProducto]
@cod_producto int
as
begin
	delete tb_producto where cod_producto = @cod_producto
end
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteUsuario]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_deleteUsuario]
@cod_usuario int
as
begin
	delete tb_usuario where cod_usuario = @cod_usuario
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllBoleta]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_findAllBoleta]
as
begin
	select * from tb_boleta
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllCliente]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_findAllCliente]
as
begin
	select * from tb_cliente
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllDistrito]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************END******************/

/*************DISTRITO******************/

create   procedure [dbo].[usp_findAllDistrito]
as
begin
	Select * from tb_distrito
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllMarca]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_findAllMarca]
as
begin
	select * from tb_marca
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllPais]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************END***********************************/

/*************PROCEDIMIENTOS PARA LOS CONTROLLERS******************/

/*************PAÍS******************/

create   procedure [dbo].[usp_findAllPais]
as
begin
	Select * from tb_pais
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllProducto]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_findAllProducto]
as
begin
	select * from tb_Producto
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllRol]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************END******************/

/*************ROL******************/

create   procedure [dbo].[usp_findAllRol]
as
begin
	Select * from tb_rol
end
GO
/****** Object:  StoredProcedure [dbo].[usp_findAllUsuario]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_findAllUsuario]
as
begin
	select * from tb_usuario
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveBoleta]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************END******************/

/*************BOLETA******************/

create   procedure [dbo].[usp_saveBoleta]
@cod_usuario int,
@cod_cliente int,
@fecha_emision date,
@cod_producto int,
@total_pagar decimal(10,2)
as
begin
	insert into tb_boleta values (@cod_usuario, @cod_cliente, @fecha_emision, @cod_producto, @total_pagar)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveCliente]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************END******************/

/*************CLIENTE******************/

create   procedure [dbo].[usp_saveCliente]
@cod_usuario int,
@cod_distrito int,
@direccion varchar(128)
as
begin
	insert into tb_cliente values (@cod_usuario, @cod_distrito, @direccion)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveDistrito]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_saveDistrito]
@descripcion varchar(64)
as
begin
	insert into tb_distrito values (@descripcion)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveMarca]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************END******************/

/*************MARCA******************/

create   procedure [dbo].[usp_saveMarca]
@descripcion varchar(64),
@cod_pais int,
@ruc varchar(32),
@telefono varchar(15),
@correo varchar(128)
as
begin
	insert into tb_marca values (@descripcion, @cod_pais, @ruc, @telefono, @correo)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_savePais]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************PROCEDIMIENTOS PARA INSERTAR SOLO EN SCRIPT******************/
create   procedure [dbo].[usp_savePais]
@descripcion varchar(64)
as
begin
	insert into tb_pais values (@descripcion)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveProducto]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[usp_saveProducto]
@nombre varchar(128),
@cod_marca int,
@descripcion varchar(256),
@precio decimal(10,2)
as
begin
	insert into tb_producto values (@nombre, @descripcion, @cod_marca, @precio)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveRol]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_saveRol]
@descripcion varchar(64)
as
begin
	insert into tb_rol values (@descripcion)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_saveUsuario]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************END******************/


/*************USUARIO******************/

create   procedure [dbo].[usp_saveUsuario]
@cod_rol int,
@correo varchar(128),
@contrasena char(10),
@nombre varchar(128),
@dni char(8),
@telefono varchar(16)
as
begin
	insert into tb_usuario values (@cod_rol, @correo, @contrasena,@nombre, @dni, @telefono)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_updateBoleta]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_updateBoleta]
@cod_boleta int,
@cod_usuario int,
@cod_cliente int,
@fecha_emision date,
@cod_producto int,
@total_pagar decimal(10,2)
as
begin
	update tb_boleta set
	cod_usuario = @cod_usuario, cod_cliente = @cod_cliente, fecha_emision = @fecha_emision, cod_producto = @cod_producto, total_pagar = @total_pagar
	where cod_boleta = @cod_boleta
end
GO
/****** Object:  StoredProcedure [dbo].[usp_updateCliente]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_updateCliente]
@cod_cliente int,
@cod_usuario int,
@cod_distrito int,
@direccion varchar(128)
as
begin
	update tb_cliente set
	cod_usuario = @cod_usuario, cod_distrito = @cod_distrito, direccion = @direccion
	where cod_cliente = @cod_cliente
end
GO
/****** Object:  StoredProcedure [dbo].[usp_updateMarca]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_updateMarca]
@cod_marca int,
@descripcion varchar(64),
@cod_pais int,
@ruc varchar(32),
@telefono varchar(15),
@correo varchar(128)
as
begin
	update tb_marca set
	descripcion = @descripcion, cod_pais = @cod_pais, ruc = @ruc, telefono = @telefono, correo = @correo
	where cod_marca = @cod_marca
end
GO
/****** Object:  StoredProcedure [dbo].[usp_updateProducto]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_updateProducto]
@cod_producto int,
@nombre varchar(128),
@cod_marca int,
@descripcion varchar(256),
@precio decimal(10,2)
as
begin
	update tb_producto set
	nombre = @descripcion, descripcion = @descripcion, cod_marca = @cod_marca, precio = @precio
	where cod_producto = @cod_producto
end
GO
/****** Object:  StoredProcedure [dbo].[usp_updateUsuario]    Script Date: 9/05/2024 18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[usp_updateUsuario]
@cod_usuario int,
@cod_rol int,
@correo varchar(128),
@contrasena char(10),
@nombre varchar(128),
@dni char(8),
@telefono varchar(16)
as
begin
	update tb_usuario set
	cod_rol = @cod_rol, correo = @correo, contrasena = @contrasena, nombre = @nombre, dni = @dni, telefono = @telefono
	where cod_usuario = @cod_usuario
end
GO
USE [master]
GO
ALTER DATABASE [bdproyecto] SET  READ_WRITE 
GO
