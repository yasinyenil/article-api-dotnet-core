USE [master]
GO
/****** Object:  Database [ArticleDB]    Script Date: 1/15/2020 5:47:30 PM ******/
CREATE DATABASE [ArticleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArticleDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ArticleDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArticleDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ArticleDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArticleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArticleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArticleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArticleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArticleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArticleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArticleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArticleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArticleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArticleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArticleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArticleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArticleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArticleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArticleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArticleDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ArticleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArticleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArticleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArticleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArticleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArticleDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ArticleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArticleDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ArticleDB] SET  MULTI_USER 
GO
ALTER DATABASE [ArticleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArticleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArticleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArticleDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArticleDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ArticleDB', N'ON'
GO
USE [ArticleDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/15/2020 5:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/15/2020 5:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 1/15/2020 5:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/15/2020 5:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200113185115_FirstMigration', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200114071435_SecondMigration', N'2.2.6-servicing-10079')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [CreationDate], [ModifiedDate], [IsActive]) VALUES (1, N'Sağlık', CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Categories] ([Id], [Name], [CreationDate], [ModifiedDate], [IsActive]) VALUES (2, N'Yazılım', CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Categories] ([Id], [Name], [CreationDate], [ModifiedDate], [IsActive]) VALUES (3, N'Bilim', CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [Description], [UserId], [CategoryId], [CreationDate], [ModifiedDate], [IsActive]) VALUES (1, N'Hello world', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1, 1, CAST(N'2020-01-15T10:50:14.6733760' AS DateTime2), CAST(N'2020-01-15T10:50:14.6743713' AS DateTime2), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Description], [UserId], [CategoryId], [CreationDate], [ModifiedDate], [IsActive]) VALUES (2, N'Hola', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1, 2, CAST(N'2020-01-15T11:41:51.1841341' AS DateTime2), CAST(N'2020-01-15T11:41:51.1842375' AS DateTime2), 0)
INSERT [dbo].[Posts] ([Id], [Title], [Description], [UserId], [CategoryId], [CreationDate], [ModifiedDate], [IsActive]) VALUES (3, N'Merhaba Dünya', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 1, 3, CAST(N'2020-01-15T11:42:08.6382742' AS DateTime2), CAST(N'2020-01-15T11:42:08.6382750' AS DateTime2), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Description], [UserId], [CategoryId], [CreationDate], [ModifiedDate], [IsActive]) VALUES (4, N'Merhaba Dünya', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 2, 1, CAST(N'2020-01-15T11:42:56.4959243' AS DateTime2), CAST(N'2020-01-15T11:42:56.4959250' AS DateTime2), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Description], [UserId], [CategoryId], [CreationDate], [ModifiedDate], [IsActive]) VALUES (5, N'Merhaba Satürn ', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 3, 1, CAST(N'2020-01-15T11:43:26.4298646' AS DateTime2), CAST(N'2020-01-15T11:43:26.4298649' AS DateTime2), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Description], [UserId], [CategoryId], [CreationDate], [ModifiedDate], [IsActive]) VALUES (9, N'Merhaba NASA', N'Buraya makale yazılacak', 4, 2, CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2020-01-15T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [CreationDate], [ModifiedDate], [IsActive]) VALUES (1, N'Yasin', N'Yenil', N'yasyen', N'123456', CAST(N'2020-01-14T10:25:34.6126390' AS DateTime2), CAST(N'2020-01-14T10:25:34.6158652' AS DateTime2), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [CreationDate], [ModifiedDate], [IsActive]) VALUES (2, N'Post', N'Man', N'postman', N'123456', CAST(N'2020-01-15T11:40:32.8563401' AS DateTime2), CAST(N'2020-01-15T11:40:32.8575174' AS DateTime2), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [CreationDate], [ModifiedDate], [IsActive]) VALUES (3, N'Visual', N'Studio', N'vs', N'123456', CAST(N'2020-01-15T11:40:52.6995065' AS DateTime2), CAST(N'2020-01-15T11:40:52.6995073' AS DateTime2), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [CreationDate], [ModifiedDate], [IsActive]) VALUES (4, N'VsCode', N'Electron', N'electron', N'123456', CAST(N'2020-01-15T11:41:19.1343914' AS DateTime2), CAST(N'2020-01-15T11:41:19.1343917' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Name]    Script Date: 1/15/2020 5:47:30 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_CategoryId]    Script Date: 1/15/2020 5:47:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Posts_CategoryId] ON [dbo].[Posts]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_UserId]    Script Date: 1/15/2020 5:47:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Posts_UserId] ON [dbo].[Posts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_UserName]    Script Date: 1/15/2020 5:47:30 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF__Categorie__Creat__38996AB5]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF__Posts__CreationD__3E52440B]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [ArticleDB] SET  READ_WRITE 
GO
