USE [master]
GO
/****** Object:  Database [EPrescription]    Script Date: 5/6/2017 5:58:44 PM ******/
CREATE DATABASE [EPrescription] ON  PRIMARY 
( NAME = N'EPrescription', FILENAME = N'E:\SQL Data\MSSQL11.MSSQLSERVER\MSSQL\DATA\EPrescription.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EPrescription_log', FILENAME = N'E:\SQL Data\MSSQL11.MSSQLSERVER\MSSQL\DATA\EPrescription_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EPrescription].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EPrescription] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EPrescription] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EPrescription] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EPrescription] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EPrescription] SET ARITHABORT OFF 
GO
ALTER DATABASE [EPrescription] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EPrescription] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EPrescription] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EPrescription] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EPrescription] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EPrescription] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EPrescription] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EPrescription] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EPrescription] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EPrescription] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EPrescription] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EPrescription] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EPrescription] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EPrescription] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EPrescription] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EPrescription] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EPrescription] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EPrescription] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EPrescription] SET RECOVERY FULL 
GO
ALTER DATABASE [EPrescription] SET  MULTI_USER 
GO
ALTER DATABASE [EPrescription] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EPrescription] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EPrescription', N'ON'
GO
USE [EPrescription]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/6/2017 5:58:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[UserRole] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Signature] [varbinary](max) NULL,
	[Location] [nvarchar](10) NULL,
	[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_Users_IsDisabled]  DEFAULT ((0)),
	[Avatar] [varbinary](max) NULL,
	[MobilePhone] [nvarchar](20) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Users] ([UserName], [Password], [UserRole], [FullName], [Email], [DisplayName], [Signature], [Location], [IsDisabled], [Avatar], [MobilePhone]) VALUES (N'User', N'User', N'', N'', N'', N'', NULL, N'', 0, NULL, N'')
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_Users]    Script Date: 5/6/2017 5:58:44 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [EPrescription] SET  READ_WRITE 
GO
