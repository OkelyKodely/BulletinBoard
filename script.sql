USE [master]
GO
/****** Object:  Database [Board]    Script Date: 11/2/2016 10:55:28 PM ******/
CREATE DATABASE [Board]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Board', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Board.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Board_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Board_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Board] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Board].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Board] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Board] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Board] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Board] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Board] SET ARITHABORT OFF 
GO
ALTER DATABASE [Board] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Board] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Board] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Board] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Board] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Board] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Board] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Board] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Board] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Board] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Board] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Board] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Board] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Board] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Board] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Board] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Board] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Board] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Board] SET RECOVERY FULL 
GO
ALTER DATABASE [Board] SET  MULTI_USER 
GO
ALTER DATABASE [Board] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Board] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Board] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Board] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Board', N'ON'
GO
USE [Board]
GO
/****** Object:  Table [dbo].[BoardListing]    Script Date: 11/2/2016 10:55:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BoardListing](
	[Name] [varchar](50) NULL,
	[Title] [varchar](50) NULL,
	[id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BoardView]    Script Date: 11/2/2016 10:55:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardView](
	[id] [int] NULL,
	[material] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Henry Kim', N'Sepulchre', 1)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Base Case', N'New Guy', 2)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Harry Wilson', N'Boss', 3)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Danny Glover', N'Secretary', 4)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Daniel Cho', N'Assistant', 5)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Old Guy', N'TBD', 7)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'New Guy', N'CEO', 6)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'', N'', 8)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'', N'', 9)
INSERT [dbo].[BoardListing] ([Name], [Title], [id]) VALUES (N'Stefan', N'HeTheMan', 10)
INSERT [dbo].[BoardView] ([id], [material]) VALUES (6, N'Let''s tell')
INSERT [dbo].[BoardView] ([id], [material]) VALUES (6, N'Another one...')
INSERT [dbo].[BoardView] ([id], [material]) VALUES (7, N'In the news the other day there was a freak accident on western ave. where a hatchback collided with a bicycle in an oncoming election year... the collision was severe enough to wreck the bike and luckily no one was injured though the car did suffer some heinous transformations ;)')
INSERT [dbo].[BoardView] ([id], [material]) VALUES (8, N'')
INSERT [dbo].[BoardView] ([id], [material]) VALUES (10, N'In ASP.NET we find monads rising to the top of popularity as it never did the past 6 years.')
USE [master]
GO
ALTER DATABASE [Board] SET  READ_WRITE 
GO
