USE [master]
GO
/****** Object:  Database [bdproyecto]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_boleta]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_cliente]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_distrito]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_marca]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_pais]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_producto]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_rol]    Script Date: 9/05/2024 12:48 ******/
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
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 9/05/2024 12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[cod_usuario] [int] NOT NULL,
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
USE [master]
GO
ALTER DATABASE [bdproyecto] SET  READ_WRITE 
GO
