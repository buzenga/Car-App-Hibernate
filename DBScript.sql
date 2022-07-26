USE [master]
GO
/****** Object:  Database [CarManager]    Script Date: 23.07.2022 15:56:26 ******/
CREATE DATABASE [CarManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarManager', FILENAME = N'C:\ProgramData\SOLIDWORKS Electrical\MSSQL12.TEW_SQLEXPRESS\MSSQL\DATA\CarManager.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CarManager_log', FILENAME = N'C:\ProgramData\SOLIDWORKS Electrical\MSSQL12.TEW_SQLEXPRESS\MSSQL\DATA\CarManager_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarManager] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarManager] SET  MULTI_USER 
GO
ALTER DATABASE [CarManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CarManager] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CarManager]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 23.07.2022 15:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [varchar](50) NOT NULL,
	[Producer] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[OwnerID] [int] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 23.07.2022 15:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Owner] ([ID])
GO
USE [master]
GO
ALTER DATABASE [CarManager] SET  READ_WRITE 
GO
