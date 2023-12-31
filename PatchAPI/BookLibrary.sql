USE [master]
GO
/****** Object:  Database [BookLibrary]    Script Date: 8/18/2023 9:24:30 AM ******/
CREATE DATABASE [BookLibrary]
GO
ALTER DATABASE [BookLibrary] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookLibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookLibrary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [BookLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookLibrary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookLibrary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookLibrary] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookLibrary] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookLibrary]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 8/18/2023 9:24:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[TotalPages] [int] NULL,
	[Rating] [decimal](18, 2) NULL,
	[IsDeleted] [bit] NULL,
	[IsPublished] [bit] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'b4db90be-4f50-4df5-9e56-0097fb469839', N'Harry Potter and the Sorcerer’s Stone', 441, CAST(4.90 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'229bdf1c-8a38-46d7-8534-031b0940b8d1', N'Harry Potter and the Chamber of Secrets', 398, CAST(4.80 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'4354e8a3-8ea4-4da6-b967-0acf523d3248', N'Harry Potter and the Prisoner of Azkaban', 453, CAST(4.85 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'ad96995f-4d38-4fdf-8d91-11053d2c3330', N'Harry Potter and the Goblet of Fire', 412, CAST(4.83 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'b4603e07-d14f-4f9f-866b-145223d65597', N'Harry Potter and the Order of the Phoenix', 471, CAST(4.92 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'd40285b0-15ce-40a8-b5b9-14fde2b0404a', N'Harry Potter and the Half-blood Prince	', 375, CAST(4.87 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Book] ([BookID], [Title], [TotalPages], [Rating], [IsDeleted], [IsPublished]) VALUES (N'e74cf61b-53a6-46ca-91c9-30e7ba6bd41f', N'Harry Potter and the Deathly Hallows', 512, CAST(4.97 AS Decimal(18, 2)), 0, 1)
GO
USE [master]
GO
ALTER DATABASE [BookLibrary] SET  READ_WRITE 
GO
