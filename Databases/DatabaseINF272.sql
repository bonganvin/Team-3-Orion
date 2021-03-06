USE [master]
GO
/****** Object:  Database [INF272]    Script Date: 11/8/2020 1:56:06 PM ******/
CREATE DATABASE [INF272]

ALTER DATABASE [INF272] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INF272].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INF272] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INF272] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INF272] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INF272] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INF272] SET ARITHABORT OFF 
GO
ALTER DATABASE [INF272] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INF272] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INF272] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INF272] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INF272] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INF272] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INF272] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INF272] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INF272] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INF272] SET  ENABLE_BROKER 
GO
ALTER DATABASE [INF272] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INF272] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INF272] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INF272] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INF272] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INF272] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INF272] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INF272] SET RECOVERY FULL 
GO
ALTER DATABASE [INF272] SET  MULTI_USER 
GO
ALTER DATABASE [INF272] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INF272] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INF272] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INF272] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [INF272] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'INF272', N'ON'
GO
USE [INF272]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdminID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[Surname] [nchar](10) NULL,
	[Title] [nchar](10) NULL,
	[ContactDetails] [nchar](10) NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Batch]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batch](
	[BatchID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[BatchCategoryID] [nchar](10) NULL,
	[Date] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED 
(
	[BatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BatchCategory]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchCategory](
	[BatchCategoryID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_BatchCategory] PRIMARY KEY CLUSTERED 
(
	[BatchCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BatchInspector]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchInspector](
	[InspectorID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[Surname] [nchar](10) NULL,
	[ContactDetails] [nchar](10) NULL,
	[Qualifications] [nchar](10) NULL,
 CONSTRAINT [PK_BatchInspector] PRIMARY KEY CLUSTERED 
(
	[InspectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [nchar](10) NOT NULL,
	[Model] [nchar](10) NULL,
	[ProductionEmployeeID] [nchar](10) NULL,
	[EquipmentConditionID] [nchar](10) NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentCondition]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentCondition](
	[EquipmentConditionID] [nchar](10) NOT NULL,
	[Status] [nchar](10) NULL,
	[ServiceDate] [nchar](10) NULL,
	[ServiceHistory] [nchar](10) NULL,
	[Maintenance] [nchar](10) NULL,
 CONSTRAINT [PK_EquipmentCondition] PRIMARY KEY CLUSTERED 
(
	[EquipmentConditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FinishedProduct]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinishedProduct](
	[FinishedProductID] [nchar](10) NOT NULL,
	[Description] [nchar](10) NULL,
	[Value] [nchar](10) NULL,
	[StandardID] [nchar](10) NULL,
 CONSTRAINT [PK_FinishedProduct] PRIMARY KEY CLUSTERED 
(
	[FinishedProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderID] [nchar](10) NOT NULL,
	[Gender] [nchar](10) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginDetails]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginDetails](
	[LoginID] [nchar](10) NOT NULL,
	[Username] [nchar](10) NULL,
	[PasswordID] [nchar](10) NULL,
 CONSTRAINT [PK_LoginDetails] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Package]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[PackageID] [nchar](10) NOT NULL,
	[Type] [nchar](10) NULL,
	[Size] [nchar](10) NULL,
	[Material] [nchar](10) NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Password]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[PasswordID] [nchar](10) NOT NULL,
	[Password] [nchar](10) NULL,
	[RecoveryID] [nchar](10) NULL,
 CONSTRAINT [PK_Password] PRIMARY KEY CLUSTERED 
(
	[PasswordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PasswordRecovery]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordRecovery](
	[RecoveryID] [nchar](10) NOT NULL,
	[Questions] [nchar](10) NULL,
	[Answers] [nchar](10) NULL,
 CONSTRAINT [PK_PasswordRecovery] PRIMARY KEY CLUSTERED 
(
	[RecoveryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlantForeman]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantForeman](
	[PlantForemanID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[Surname] [nchar](10) NULL,
	[RawMaterialID] [nchar](10) NULL,
	[ContactDetails] [nchar](10) NULL,
 CONSTRAINT [PK_PlantForeman] PRIMARY KEY CLUSTERED 
(
	[PlantForemanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductionEmployee]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionEmployee](
	[ProductionEmployeeID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[Surname] [nchar](10) NULL,
	[Title] [nchar](10) NULL,
	[ContactDetails] [nchar](10) NULL,
 CONSTRAINT [PK_ProductionEmployee] PRIMARY KEY CLUSTERED 
(
	[ProductionEmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductionProcess]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionProcess](
	[ProductionID] [nchar](10) NOT NULL,
	[ProductionEmployeeID] [nchar](10) NULL,
	[Type] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_ProductionProcess] PRIMARY KEY CLUSTERED 
(
	[ProductionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductionStandard]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionStandard](
	[StandardID] [nchar](10) NOT NULL,
	[Description] [nchar](10) NULL,
	[Wheight] [nchar](10) NULL,
	[Specifications] [nchar](10) NULL,
 CONSTRAINT [PK_ProductionStandard] PRIMARY KEY CLUSTERED 
(
	[StandardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RawMaterialsInventory]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RawMaterialsInventory](
	[RawMaterialID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
	[Category] [nchar](10) NULL,
	[Type] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
	[ProductionEmployeeID] [nchar](10) NULL,
 CONSTRAINT [PK_RawMaterialsInventory] PRIMARY KEY CLUSTERED 
(
	[RawMaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ProductionEmployee] UNIQUE NONCLUSTERED 
(
	[RawMaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Storage]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[StorageID] [nchar](10) NOT NULL,
	[BayNumber] [nchar](10) NULL,
	[Size] [nchar](10) NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[StorageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WasteLoad]    Script Date: 11/8/2020 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WasteLoad](
	[WasteLoadID] [nchar](10) NOT NULL,
	[Weight] [nchar](10) NULL,
	[Type] [nchar](10) NULL,
 CONSTRAINT [PK_WasteLoad] PRIMARY KEY CLUSTERED 
(
	[WasteLoadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Equipment]    Script Date: 11/8/2020 1:56:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Equipment] ON [dbo].[Equipment]
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Equipment]
GO
USE [master]
GO
ALTER DATABASE [INF272] SET  READ_WRITE 
GO
