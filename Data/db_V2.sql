USE [master]
GO
/****** Object:  Database [Vision]    Script Date: 13/12/2020 6:35:15 PM ******/
CREATE DATABASE [Vision]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vision', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TIENTPSQL\MSSQL\DATA\Vision.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vision_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TIENTPSQL\MSSQL\DATA\Vision_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Vision] SET COMPATIBILITY_LEVEL = 140
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
ALTER DATABASE [Vision] SET AUTO_CLOSE ON 
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
ALTER DATABASE [Vision] SET RECOVERY SIMPLE 
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
ALTER DATABASE [Vision] SET QUERY_STORE = OFF
GO
USE [Vision]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](10) NOT NULL,
	[Company] [nvarchar](7) NOT NULL,
	[Balance] [float] NOT NULL,
	[StockValue] [float] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountState]    Script Date: 13/12/2020 6:35:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyOrder]    Script Date: 13/12/2020 6:35:15 PM ******/
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
	[BuyDate] [datetime] NOT NULL,
	[Sold] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_OrderHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diary]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diary](
	[Id] [int] NOT NULL,
	[RecordTime] [datetime] NOT NULL,
	[AdditionAmount] [float] NOT NULL,
	[OpeningBalance] [float] NOT NULL,
	[EndingBalance] [float] NOT NULL,
	[Interest] [float] NOT NULL,
	[InterestPercent] [float] NOT NULL,
	[Note] [nvarchar](300) NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Holidays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SymbolId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[SymbolName] [nvarchar](10) NOT NULL,
	[MatchTime] [datetime] NOT NULL,
	[OrderNumber] [nvarchar](16) NOT NULL,
	[Type] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Fee] [float] NOT NULL,
	[Tax] [float] NOT NULL,
	[Note] [nvarchar](100) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHis]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SymbolId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[SymbolName] [nvarchar](10) NOT NULL,
	[MatchTime] [datetime] NOT NULL,
	[OrderNumber] [nvarchar](16) NOT NULL,
	[Type] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Fee] [float] NOT NULL,
	[Tax] [float] NOT NULL,
	[Note] [nvarchar](100) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_OrderHis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PriceSectionId] [int] NOT NULL,
	[BuyOrderId] [int] NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceSection]    Script Date: 13/12/2020 6:35:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellOrder]    Script Date: 13/12/2020 6:35:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockSymbol]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockSymbol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_StockSymbol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 13/12/2020 6:35:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 13/12/2020 6:35:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecordTime] [datetime] NOT NULL,
	[Amount] [float] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Note] [nvarchar](200) NULL,
	[OrderNumber] [int] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountState] ON 

INSERT [dbo].[AccountState] ([Id], [Symbol], [Description], [Note], [TotalDividend], [CurrentPrice], [CurrentValue], [TotalBuy], [TotalSell], [TotalTax], [TotalBuyFee], [TotalSellFee], [Type], [Department], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (1, N'HSG', N'tình hình kinh doanh khởi sắc, thêm sóng đầu tư công', N'Chuyển sang xu hướng tăng, nắm giữ đến khi chạm MA20', 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, N'1', N'Thép', 0, CAST(N'2020-09-19T10:17:41.257' AS DateTime), CAST(N'2020-09-19T10:17:41.257' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AccountState] OFF
SET IDENTITY_INSERT [dbo].[BuyOrder] ON 

INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (1, 1, N'HSG', N'6900140920051765', CAST(N'2020-09-14' AS Date), 104300, 1, 300, 12650.0000, 5579.0000, 0, 0, 0, 300, N'vượt kênh xu hướng tích lũy, mô hình cốc tay cầm', 2, CAST(N'2020-09-14T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T10:17:41.527' AS DateTime), CAST(N'2020-09-19T10:17:41.527' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (2, 2, N'HSG', N'6900140920051958', CAST(N'2020-09-14' AS Date), 104500, 1, 50, 12600.0000, 926.0000, 0, 0, 0, 50, N'vượt kênh xu hướng tích lũy, mô hình cốc tay cầm', 2, CAST(N'2020-09-14T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T10:25:01.640' AS DateTime), CAST(N'2020-09-19T10:25:01.640' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (3, 3, N'HSG', N'6900170920070202', CAST(N'2020-09-17' AS Date), 131200, 1, 200, 13600.0000, 3998.0000, 0, 0, 200, 0, N'nhịp điều chỉnh nhẹ theo đhps, mua thêm', 2, CAST(N'2020-09-17T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T10:27:09.413' AS DateTime), CAST(N'2020-09-19T10:27:09.413' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (4, 4, N'HSG', N'6900170920093529', CAST(N'2020-09-17' AS Date), 140000, 1, 100, 13500.0000, 1985.0000, 0, 0, 100, 0, N'nhịp điều chỉnh nhẹ theo đhps, mua thêm', 2, CAST(N'2020-09-17T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T10:28:52.807' AS DateTime), CAST(N'2020-09-19T10:28:52.807' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (5, 5, N'HSG', N'6900170920029369', CAST(N'2020-09-17' AS Date), 94443, 1, 100, 13650.0000, 2007.0000, 0, 0, 100, 0, N'nhịp điều chỉnh nhẹ theo đhps, mua thêm', 2, CAST(N'2020-09-17T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T16:02:14.070' AS DateTime), CAST(N'2020-09-19T16:02:14.070' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (6, 4, N'HSG', N'6900170920095197', CAST(N'2020-09-17' AS Date), 141100, 1, 200, 13500.0000, 3969.0000, 0, 0, 200, 0, N'nhịp điều chỉnh nhẹ theo đhps, mua thêm', 2, CAST(N'2020-09-17T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T16:05:27.367' AS DateTime), CAST(N'2020-09-19T16:05:27.367' AS DateTime), 1)
INSERT [dbo].[BuyOrder] ([Id], [PriceSectionId], [Symbol], [OrderNumber], [Date], [Time], [InvestType], [Volume], [Price], [TradingFee], [MatchedVol], [T2], [T1], [T0], [Note], [TimerSellDays], [BuyDate], [Sold], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (7, 6, N'HSG', N'6900170920096860', CAST(N'2020-09-17' AS Date), 141718, 1, 100, 13550.0000, 1992.0000, 0, 0, 100, 0, N'nhịp điều chỉnh nhẹ theo đhps, mua thêm', 2, CAST(N'2020-09-17T00:00:00.000' AS DateTime), 0, 0, CAST(N'2020-09-19T16:07:56.233' AS DateTime), CAST(N'2020-09-19T16:07:56.233' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BuyOrder] OFF
SET IDENTITY_INSERT [dbo].[Holiday] ON 

INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (1, CAST(N'2020-01-01T07:32:42.443' AS DateTime), N'Tet Duong Lich')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (2, CAST(N'2020-02-12T07:32:42.443' AS DateTime), N'Tet')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (3, CAST(N'2020-02-13T07:32:42.443' AS DateTime), N'Tet')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (4, CAST(N'2020-02-14T07:32:42.443' AS DateTime), N'Tet')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (5, CAST(N'2020-02-15T07:32:42.443' AS DateTime), N'Tet')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (6, CAST(N'2020-02-16T07:32:42.443' AS DateTime), N'Tet')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (7, CAST(N'2020-02-17T07:32:42.443' AS DateTime), N'Tet')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (8, CAST(N'2020-04-21T07:32:42.443' AS DateTime), N'Gio To Hung Vuong')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (9, CAST(N'2020-04-30T07:32:42.443' AS DateTime), N'Thong nhat Dat Nuoc')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (10, CAST(N'2020-05-01T07:32:42.443' AS DateTime), N'Quoc te lao dong')
INSERT [dbo].[Holiday] ([Id], [DateTime], [Name]) VALUES (11, CAST(N'2020-09-02T07:32:42.443' AS DateTime), N'Quoc Khanh')
SET IDENTITY_INSERT [dbo].[Holiday] OFF
SET IDENTITY_INSERT [dbo].[PriceSection] ON 

INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (1, N'HSG', 1, 12650.0000, 300, 0, 0, 0, 300, N'', 1, CAST(N'2020-09-19T10:17:41.483' AS DateTime), CAST(N'2020-09-19T10:17:41.483' AS DateTime), 1)
INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (2, N'HSG', 1, 12600.0000, 50, 0, 0, 0, 50, N'', 1, CAST(N'2020-09-19T10:25:01.630' AS DateTime), CAST(N'2020-09-19T10:25:01.630' AS DateTime), 1)
INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (3, N'HSG', 1, 13600.0000, 200, 0, 0, 200, 0, N'', 1, CAST(N'2020-09-19T10:27:09.403' AS DateTime), CAST(N'2020-09-19T10:27:09.403' AS DateTime), 1)
INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (4, N'HSG', 1, 13500.0000, 300, 0, 0, 300, 0, N'', 1, CAST(N'2020-09-19T10:28:52.790' AS DateTime), CAST(N'2020-09-19T10:28:52.790' AS DateTime), 1)
INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (5, N'HSG', 1, 13650.0000, 100, 0, 0, 100, 0, N'', 1, CAST(N'2020-09-19T16:02:14.003' AS DateTime), CAST(N'2020-09-19T16:02:14.003' AS DateTime), 1)
INSERT [dbo].[PriceSection] ([Id], [Symbol], [AccountStateId], [Price], [Volume], [MatchedVol], [T2], [T1], [T0], [Note], [UserId], [CreateDate], [UpdateDate], [Status]) VALUES (6, N'HSG', 1, 13550.0000, 100, 0, 0, 100, 0, N'', 1, CAST(N'2020-09-19T16:07:56.223' AS DateTime), CAST(N'2020-09-19T16:07:56.223' AS DateTime), 1)
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
