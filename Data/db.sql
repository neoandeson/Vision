USE [master]
GO
/****** Object:  Database [Vision]    Script Date: 8/21/2020 4:46:15 PM ******/
CREATE DATABASE [Vision]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vision', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Vision.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vision_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Vision_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Vision] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vision].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vision] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vision] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vision] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vision] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vision] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vision] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vision] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vision] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vision] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vision] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vision] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vision] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vision] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vision] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vision] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Vision] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vision] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vision] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vision] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vision] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vision] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vision] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vision] SET RECOVERY FULL 
GO
ALTER DATABASE [Vision] SET  MULTI_USER 
GO
ALTER DATABASE [Vision] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vision] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vision] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vision] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vision] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Vision', N'ON'
GO
ALTER DATABASE [Vision] SET QUERY_STORE = OFF
GO
USE [Vision]
GO
/****** Object:  Table [dbo].[AccountState]    Script Date: 8/21/2020 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](8) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Note] [nvarchar](100) NULL,
	[TotalDividend] [money] NULL,
	[CurrentPrice] [money] NULL,
	[CurrentValue] [money] NOT NULL,
	[TotalBuy] [money] NULL,
	[TotalSell] [money] NULL,
	[TotalTax] [money] NULL,
	[TotalBuyFee] [money] NULL,
	[TotalSellFee] [money] NULL,
	[Type] [nvarchar](10) NOT NULL,
	[Department] [nvarchar](10) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_AccountState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyOrder]    Script Date: 8/21/2020 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriceSectionId] [int] NOT NULL,
	[Symbol] [nvarchar](8) NOT NULL,
	[OrderNumber] [nvarchar](17) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [int] NOT NULL,
	[InvestType] [int] NOT NULL,
	[Volume] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[TradingFee] [money] NOT NULL,
	[MatchedVol] [int] NOT NULL,
	[T2] [int] NOT NULL,
	[T1] [int] NOT NULL,
	[T0] [int] NOT NULL,
	[Note] [nvarchar](200) NULL,
	[TimerSellDays] [int] NOT NULL,
	[Sold] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_OrderHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 8/21/2020 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PriceSectionId] [int] NOT NULL,
	[SellOrderId] [int] NOT NULL,
	[Symbol] [nvarchar](8) NOT NULL,
	[BuyPrice] [money] NOT NULL,
	[SellPrice] [money] NOT NULL,
	[Volume] [int] NOT NULL,
	[Margin] [money] NOT NULL,
	[BuyTradingFee] [money] NOT NULL,
	[SellTradingFee] [money] NOT NULL,
	[SellTax] [money] NOT NULL,
	[TotalFee] [money] NOT NULL,
	[Revenue] [money] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceSection]    Script Date: 8/21/2020 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceSection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[AccountStateId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Volume] [int] NOT NULL,
	[MatchedVol] [int] NOT NULL,
	[T2] [int] NOT NULL,
	[T1] [int] NOT NULL,
	[T0] [int] NOT NULL,
	[Note] [nvarchar](100) NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_PriceSection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellOrder]    Script Date: 8/21/2020 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](17) NOT NULL,
	[Date] [date] NOT NULL,
	[Symbol] [nvarchar](8) NOT NULL,
	[Volume] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[TradingFee] [money] NOT NULL,
	[Tax] [money] NOT NULL,
	[Value] [money] NOT NULL,
	[Time] [int] NOT NULL,
	[Note] [nvarchar](100) NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_SellOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 8/21/2020 4:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StringValue] [varchar](50) NULL,
	[FloatValue] [float] NULL,
	[Description] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SystemConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountState] ON 

INSERT [dbo].[AccountState] ([Id], [Symbol], [Description], [Note], [TotalDividend], [CurrentPrice], [CurrentValue], [TotalBuy], [TotalSell], [TotalTax], [TotalBuyFee], [TotalSellFee], [Type], [Department], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (1, N'FIT', N'', N'', 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'', N'', 0, CAST(N'2020-08-17T16:27:36.577' AS DateTime), CAST(N'2020-08-17T16:27:36.577' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AccountState] OFF
SET IDENTITY_INSERT [dbo].[BuyOrder] ON 

INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (1, 1, N'FIT', N'123', CAST(N'2015-05-08' AS Date), 110000, 1, 200, 20.0000, 10.0000, 0, 0, 0, 200, N'acvasdf', 2, 0, 0, CAST(N'2020-08-16T16:27:36.870' AS DateTime), CAST(N'2020-08-17T16:27:36.870' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (2, 2, N'FIT', N'124', CAST(N'2015-05-09' AS Date), 100000, 1, 150, 18.0000, 10.0000, 0, 0, 0, 150, N'acvasdf', 2, 0, 0, CAST(N'2020-08-18T17:20:33.080' AS DateTime), CAST(N'2020-08-18T17:20:33.080' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (3, 2, N'FIT', N'125', CAST(N'2015-05-09' AS Date), 110000, 1, 100, 18.0000, 10.0000, 0, 0, 0, 100, N'acvasdf', 2, 0, 0, CAST(N'2020-08-18T16:14:28.380' AS DateTime), CAST(N'2020-08-19T16:14:28.380' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BuyOrder] OFF
SET IDENTITY_INSERT [dbo].[PriceSection] ON 

INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (1, N'FIT', 1, 20.0000, 200, 0, 0, 0, 200, N'', 1, CAST(N'2020-08-17T16:27:36.840' AS DateTime), CAST(N'2020-08-17T16:27:36.840' AS DateTime), 1)
INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (2, N'FIT', 1, 18.0000, 250, 0, 0, 0, 250, N'', 1, CAST(N'2020-08-18T17:20:32.910' AS DateTime), CAST(N'2020-08-18T17:20:32.910' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PriceSection] OFF
SET IDENTITY_INSERT [dbo].[SystemConfig] ON 

INSERT [dbo].[SystemConfig] ([Id], [Name], [StringValue], [FloatValue], [Description], [UpdateDate]) VALUES (1, N'LastUpdateTDate', NULL, NULL, NULL, CAST(N'2020-08-16T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[SystemConfig] OFF
ALTER TABLE [dbo].[BuyOrder] ADD  CONSTRAINT [DF_BuyOrder_MatchedVol]  DEFAULT ((0)) FOR [MatchedVol]
GO
ALTER TABLE [dbo].[PriceSection] ADD  CONSTRAINT [DF_PriceSection_MatchedVol]  DEFAULT ((0)) FOR [MatchedVol]
GO
USE [master]
GO
ALTER DATABASE [Vision] SET  READ_WRITE 
GO
