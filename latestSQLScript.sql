USE [master]
GO
/****** Object:  Database [MyCarDb]    Script Date: 3/8/2021 11:25:10 AM ******/
CREATE DATABASE [MyCarDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyCarDb', FILENAME = N'D:\MyCarDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyCarDb_log', FILENAME = N'D:\MyCarDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyCarDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyCarDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyCarDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyCarDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyCarDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyCarDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyCarDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyCarDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyCarDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyCarDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyCarDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyCarDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyCarDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyCarDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyCarDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyCarDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyCarDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyCarDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyCarDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyCarDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyCarDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyCarDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyCarDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyCarDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyCarDb] SET  MULTI_USER 
GO
ALTER DATABASE [MyCarDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyCarDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyCarDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyCarDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [MyCarDb]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [uniqueidentifier] NOT NULL,
	[LocalAddress] [nvarchar](100) NOT NULL,
	[PincodeId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_PurchaseAddresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Passowrd] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Contact] [varchar](15) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[BankId] [uniqueidentifier] NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarCategories]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarCategories](
	[Category] [nvarchar](50) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifyAt] [datetime] NOT NULL,
	[CreaatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CarCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarCategoryMapper]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarCategoryMapper](
	[Id] [uniqueidentifier] NOT NULL,
	[CarId] [uniqueidentifier] NOT NULL,
	[CarCategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CarCategoryMapper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarPurchases]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarPurchases](
	[CarPurchaseId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DealerId] [uniqueidentifier] NOT NULL,
	[CarVarientId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[PromoId] [uniqueidentifier] NULL,
	[EmiId] [uniqueidentifier] NULL,
	[IsFullPayment] [bit] NOT NULL,
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](12, 3) NOT NULL,
	[Status] [bit] NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CarPurchases] PRIMARY KEY CLUSTERED 
(
	[CarPurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarRents]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRents](
	[CarRentId] [uniqueidentifier] NOT NULL,
	[CarVarientId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[PickupPoint] [uniqueidentifier] NOT NULL,
	[ReturningDate] [datetime] NOT NULL,
	[DropPoint] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[IsPaymentDone] [bit] NOT NULL,
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_CarRents] PRIMARY KEY CLUSTERED 
(
	[CarRentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Name] [nvarchar](50) NOT NULL,
	[ShortDescription] [nvarchar](100) NOT NULL,
	[LongDescription] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[ModifyAt] [datetime] NULL,
	[CreaatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CarCategoryId] [uniqueidentifier] NULL,
	[Brand] [nvarchar](30) NOT NULL,
	[Image] [varchar](4000) NULL,
	[AddressId] [uniqueidentifier] NULL,
	[Kilometers] [decimal](8, 2) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarVarients]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarVarients](
	[Id] [uniqueidentifier] NOT NULL,
	[carId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Status] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Price] [money] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CarVarients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](320) NOT NULL,
	[Query] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [uniqueidentifier] NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[CountryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealers]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealers](
	[DealerId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[VerifiedBy] [uniqueidentifier] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Dealers] PRIMARY KEY CLUSTERED 
(
	[DealerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMIs]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMIs](
	[EmiId] [uniqueidentifier] NOT NULL,
	[BankId] [uniqueidentifier] NOT NULL,
	[CardType] [nvarchar](15) NOT NULL,
	[Period] [int] NOT NULL,
	[Interest] [decimal](7, 4) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Isdeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_EMIs] PRIMARY KEY CLUSTERED 
(
	[EmiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQs](
	[FaqId] [uniqueidentifier] NOT NULL,
	[Question] [nvarchar](100) NOT NULL,
	[Answer] [nvarchar](500) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_FAQs] PRIMARY KEY CLUSTERED 
(
	[FaqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackCategory]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FeedbackCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[TranscationId] [nvarchar](50) NOT NULL,
	[Frequency] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[OfferId] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](20) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pincodes]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pincodes](
	[PincodeId] [uniqueidentifier] NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[Pincode] [int] NOT NULL,
 CONSTRAINT [PK_Pincodes] PRIMARY KEY CLUSTERED 
(
	[PincodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promo]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promo](
	[PromoId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[PromoCode] [varchar](40) NOT NULL,
	[Details] [nvarchar](200) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[Isdeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Promo] PRIMARY KEY CLUSTERED 
(
	[PromoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewId] [uniqueidentifier] NOT NULL,
	[CarId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[Discription] [nvarchar](200) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [nchar](10) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/8/2021 11:25:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Email] [varchar](320) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[IdProof] [varchar](4000) NULL,
	[Points] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Image] [varchar](4000) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'8ea0b8ef-2e5d-4634-8e50-404f18401548', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
GO
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'eb53730d-ba07-41b1-9787-be724cb40160', N'b-38', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
GO
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'2fc1c655-c7af-4926-9659-dc389264a3e8', N'Iscon', N'6ec4327c-e483-4970-884c-c8b99bb178c9', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, 0, 0)
GO
INSERT [dbo].[Addresses] ([AddressId], [LocalAddress], [PincodeId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3386e477-ecf0-4a4c-88df-f962c2bc0eda', N'string', N'6ec4327c-e483-4970-884c-c8b99bb178c9', NULL, NULL, NULL, NULL, 0, 0)
GO
INSERT [dbo].[Admin] ([Id], [Email], [Passowrd], [Name], [Contact], [Role]) VALUES (N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'ram@gmail.com', N'123456', N'Ram', N'9621221615', N'Owner')
GO
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'Used', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', 0, 0)
GO
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'Rent', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0)
GO
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'Subscribe', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99e', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0)
GO
INSERT [dbo].[CarCategories] ([Category], [Id], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Status], [IsDeleted]) VALUES (N'New', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', 0, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'2f2f9165-8b5d-4c0e-8ddb-2693a308028c', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'c3ab966f-b80b-40e4-9207-ae127c5ff11a', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'0a9e9400-49aa-4674-bd99-59612bbe13a8', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'db45dc5c-239b-44eb-bb49-c6eaba053768', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'68385690-6b1c-40ea-8b1f-892bf568b401', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'c8c01071-2e9f-48a4-9b8c-e5e297f9069c', N'015f3c99-1df9-46e5-b23b-b3216e54006e', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(300000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-06T23:59:49.543' AS DateTime), NULL, CAST(N'2021-03-06T23:59:49.543' AS DateTime), NULL, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'678be637-097e-47e0-ba0b-8c9f2ab5b63f', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'28874872-1565-477f-9b8b-8b73385cf485', N'd2309e5f-8dbf-4519-a32e-508951557087', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(100000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-06T13:43:05.960' AS DateTime), NULL, CAST(N'2021-03-06T13:43:05.960' AS DateTime), NULL, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'5fc26a0d-8549-41d1-b167-ac6eb2af996b', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'74f6c930-c2b7-4d90-b106-c4d825fbb439', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(600000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-03-08T10:28:52.903' AS DateTime), NULL, CAST(N'2021-03-08T10:28:52.903' AS DateTime), NULL, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'8146edc1-3c97-44fa-bb0d-b31409a89563', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'01799a80-3804-4299-98cf-9f0ac0b11293', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[CarPurchases] ([CarPurchaseId], [UserId], [DealerId], [CarVarientId], [InvoiceId], [PaymentMethodId], [PromoId], [EmiId], [IsFullPayment], [CurrencyId], [Amount], [Status], [AddressId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'05b951a8-57c0-4667-ae3f-fec72c6c78b4', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'90c25f61-fd5c-4434-a907-61f29fae3513', N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', NULL, NULL, 1, N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(500000.000 AS Decimal(12, 3)), 0, NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'92902763-3ed4-490b-b1a8-63e1caccca45', N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-05T11:38:36.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-05T11:38:36.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(500000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'8afd8ba9-1005-4f27-9023-11cbd37d3f12', CAST(N'2021-03-05T17:30:32.847' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-05T17:30:33.327' AS DateTime), NULL, 0, 0)
GO
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3fa4c941-9028-4a96-af67-9905b8ca5a52', N'30e528fd-0789-487c-9312-5ea1eff03a3b', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-10T10:55:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-25T10:55:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(30000000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'0166782c-5156-43da-9389-da92815901d5', CAST(N'2021-03-08T10:55:59.647' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-08T10:55:59.647' AS DateTime), NULL, 0, 0)
GO
INSERT [dbo].[CarRents] ([CarRentId], [CarVarientId], [UserId], [CurrencyId], [BookingDate], [PickupPoint], [ReturningDate], [DropPoint], [Amount], [IsPaymentDone], [PaymentMethodId], [InvoiceId], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'3728c64c-33e2-4bd9-bc4f-c764f64af14d', N'f906a818-510a-41b6-b104-a33f6994ca64', N'5309fb2f-a419-498f-994e-3604857d4ce6', N'f210d047-9a6e-4e32-8430-ae7abce4bea1', CAST(N'2021-03-07T11:05:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(N'2021-03-19T11:05:00.000' AS DateTime), N'eb53730d-ba07-41b1-9787-be724cb40160', CAST(4800000.00 AS Decimal(10, 2)), 1, N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'fea3d470-5292-4342-b322-427aaafacfd7', CAST(N'2021-03-08T11:06:44.233' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2021-03-08T11:06:44.633' AS DateTime), NULL, 0, 0)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi RS7', N'Sportback Key Specifications', N'Feature highlights of the 2020 Audi RS7 Sportback include a five-seat configuration (offered for the first time), RS adaptive air suspension, flared wheel arches, 21-inch alloy wheels, single-frame grille with honeycomb mesh, rear bumper with integrated diffuser and oval exhaust pipes, panoramic sunroof and LED matrix headlamps.', CAST(N'2021-02-23T19:22:45.867' AS DateTime), CAST(N'2021-02-23T19:34:51.700' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'1a6f5293-f600-4cd0-81a4-1b751c82010f', 0, 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'Audi', N'Car332021 22030 PM.jpg', NULL, NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Ferrari 250 GTO', N'Rarity and motorsport success ', N'The GTO is the ultimate development of Ferrari''s 250 series of sports cars, and in turn it was derived from another successful Ferrari racing car, the 250 GT SWB', CAST(N'2021-02-22T22:49:04.890' AS DateTime), CAST(N'2021-02-22T22:49:04.890' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'Ferrari', N'Car332021 22030 PM.jpg', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Ferrari Dino 246', N'Engine: 2.4-litre V6, 195bhp', N'A claimed top speed of 146mph was competitive for the era, and the Dino was a strong rival for the Porsche 911.', CAST(N'2021-02-22T01:27:09.743' AS DateTime), CAST(N'2021-02-22T14:50:14.027' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'9355c897-7671-4ab8-885e-5341d4abe5ca', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99e', N'Ferrari', N'Car332021 22030 PM.jpg', N'3386e477-ecf0-4a4c-88df-f962c2bc0eda', NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N' Ferrari 125S', N'Five-speed manual, rear wheel drive', N'The 125 name refers to the capacity of a single cylinder - came with a modest 118bhp, but developments of the Colombo V12 were used by Ferrari throughout the company''s sports GT racing, including in the successful 250 GTO and desirable 365 GTB/4', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2021-02-21T21:28:50.593' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', N'Ferrari', N'Car332021 22030 PM.jpg', NULL, NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi A4', N'With the introduction of the A4 facelift', N'The new Audi A4 facelift is based on the B9 generation model that was unveiled back in 2016. Changes to the exterior design include an updated single-frame grille, refreshed front and rear bumpers, new matrix LED headlamps, and reworked tail lights.', CAST(N'2021-02-23T16:42:33.350' AS DateTime), CAST(N'2021-02-23T16:42:33.350' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'4a4c8651-1237-4444-b541-a8ddf2e39e7f', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car332021 22030 PM.jpg', NULL, NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi Q2', N'Smallest SUV', N'Smallest SUV yet at the Geneva Motor Show. Built on Volkswagen’s MQB platform, the Q2 will sit under the Q3 in the German manufacturer’s SUV portfolio', CAST(N'2021-02-22T21:43:40.790' AS DateTime), CAST(N'2021-02-22T21:43:40.790' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'0d87bbf7-bd3e-404e-b64f-be2a2829a990', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car332021 22030 PM.jpg', NULL, NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi X10', N'Elegant design, sumptuous quality', N'Elegant design, sumptuous quality, advanced lightweight construction and an abundance of high-end gadgets exemplify Audi’s flagship offering – the A8L. It is the most luxurious offering in Audi’s portfolio', CAST(N'2021-02-22T01:16:54.230' AS DateTime), CAST(N'2021-02-22T01:16:54.793' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car332021 22030 PM.jpg', NULL, NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Ferrari F355', N'six-speed electrohydraulic clutch auto', N'The six-speed manual is the model of choice, because while the F355 F1 featured an electrohydraulic clutch and race car-inspired paddleshifters, this single clutch auto isn''t the crispest performer', CAST(N'2021-03-05T13:27:43.233' AS DateTime), CAST(N'2021-03-05T13:27:43.233' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', 0, 0, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99d', N'Ferrari', N'Car352021 12743 PM.jpg', N'8ea0b8ef-2e5d-4634-8e50-404f18401548', NULL)
GO
INSERT [dbo].[Cars] ([Name], [ShortDescription], [LongDescription], [CreatedAt], [ModifyAt], [CreaatedBy], [ModifiedBy], [Id], [Status], [IsDeleted], [CarCategoryId], [Brand], [Image], [AddressId], [Kilometers]) VALUES (N'Audi RS Q8', N'High performance range', N'It’s the first performance SUV from the German automaker, and is powered by a 4.0-litre TFSI twin-turbo V8 engine producing 600bhp/800Nm.', CAST(N'2021-02-22T15:45:29.163' AS DateTime), CAST(N'2021-02-22T15:45:29.163' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bb4e1630-d89d-4433-b379-f82653b720e0', 0, 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99f', N'Audi', N'Car332021 22030 PM.jpg', NULL, NULL)
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'c0bd03c8-bf32-40aa-a875-07ded387e75e', N'1a6f5293-f600-4cd0-81a4-1b751c82010f', CAST(N'2021-02-22T15:46:17.513' AS DateTime), CAST(N'2021-02-22T15:46:17.513' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 300000.0000, N'Top Model')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'715b74f9-a479-4394-b309-1061796b42f8', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', CAST(N'2021-02-22T14:43:46.513' AS DateTime), CAST(N'2021-02-22T14:43:46.513' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 900000.0000, N'Model A')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'd44b715e-8e3b-43d6-ba53-4a2ce2fa26d1', N'9355c897-7671-4ab8-885e-5341d4abe5ca', CAST(N'2021-02-23T19:47:59.313' AS DateTime), CAST(N'2021-02-23T19:47:59.313' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 5000000.0000, N'Model B')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'0f9a70c0-0822-4ca2-a5b3-4a595ba83c94', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', CAST(N'2021-02-22T14:44:58.920' AS DateTime), CAST(N'2021-02-22T14:44:58.920' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 200000.0000, N'Model 7')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'30e528fd-0789-487c-9312-5ea1eff03a3b', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', CAST(N'2021-03-05T13:28:19.737' AS DateTime), CAST(N'2021-03-05T13:28:19.737' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 2000000.0000, N'Model F')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'b503f227-544c-41b0-8d7c-7a593cbd9231', N'4a4c8651-1237-4444-b541-a8ddf2e39e7f', CAST(N'2021-02-22T22:49:19.513' AS DateTime), CAST(N'2021-02-22T22:49:19.513' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 600000.0000, N'Model D')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'28874872-1565-477f-9b8b-8b73385cf485', N'0d87bbf7-bd3e-404e-b64f-be2a2829a990', CAST(N'2021-02-22T14:44:38.573' AS DateTime), CAST(N'2021-02-22T14:44:38.573' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 100000.0000, N'Model C1')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'bd4725b3-cab7-4a4d-a391-8fef46a1a99c', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 500000.0000, N'Model C2')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'f906a818-510a-41b6-b104-a33f6994ca64', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', CAST(N'2021-02-23T16:42:51.557' AS DateTime), CAST(N'2021-02-23T16:42:51.557' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 400000.0000, N'Model F2')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'16eec8b7-032a-4eae-8f58-aad67d87887b', N'bb4e1630-d89d-4433-b379-f82653b720e0', CAST(N'2021-02-23T19:34:18.670' AS DateTime), CAST(N'2021-02-23T19:34:14.843' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 5000000.0000, N'Model A2')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'892f7047-860d-40a7-b053-bce3dc8e6ba0', N'dceca9a3-0d69-40eb-b2fd-c887f33f7fbf', CAST(N'2021-02-22T21:43:55.540' AS DateTime), CAST(N'2021-02-22T21:43:55.540' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 600000.0000, N'Model G')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'c8c01071-2e9f-48a4-9b8c-e5e297f9069c', N'832f8ddb-7ec4-4fd7-98ee-d10650409d04', CAST(N'2021-02-22T14:45:08.207' AS DateTime), CAST(N'2021-02-22T14:45:08.207' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 300000.0000, N'Model P')
GO
INSERT [dbo].[CarVarients] ([Id], [carId], [CreatedAt], [ModifiedAt], [CreatedBy], [ModifiedBy], [Status], [IsDeleted], [Price], [Name]) VALUES (N'0e423027-c45c-486f-86f5-fcb482c71d45', N'9355c897-7671-4ab8-885e-5341d4abe5ca', CAST(N'2021-02-22T14:42:09.880' AS DateTime), CAST(N'2021-02-22T14:42:09.547' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, 700000.0000, N'Model Z2')
GO
INSERT [dbo].[Cities] ([CityId], [StateId], [CityName]) VALUES (N'02a68be8-fb5b-4dc7-8fa2-9ae9b9c92560', N'35b70a61-714a-449d-a520-2678b88296db', N'Ahmedabad')
GO
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (N'bb300cee-8c5f-4a52-b5ba-304f094f9e15', N'India')
GO
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [CountryId]) VALUES (N'f210d047-9a6e-4e32-8430-ae7abce4bea1', N'INR', N'bb300cee-8c5f-4a52-b5ba-304f094f9e15')
GO
INSERT [dbo].[Dealers] ([DealerId], [Name], [AddressId], [ContactNo], [IsVerified], [VerifiedBy], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'6cc752cb-295f-4c9e-bd5c-c72b98853baa', N'Darshit', N'2fc1c655-c7af-4926-9659-dc389264a3e8', N'132456789', 1, N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', NULL, NULL, NULL, NULL, 0, 0)
GO
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'869cc59c-881b-42f7-8ad1-0da3cfcd7ea4', N'How many checks are carried out?', N'Our professionally trained and qualified engineers carry out 217 checks on each car & certify cars which meet or are refurbished to our certification criteria. We also check all owner details and documents to ensure genuineness.Sample Condition Report', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'869cc59c-881b-42f7-8ad1-0da3cfcd7ea4', NULL, NULL, 0, 0)
GO
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4438ebb3-7471-429a-b0fd-6c5ba0dd7c53', N'Are the cars accident free?', N'Yes, only accident free cars are Trustmark certified. A car is termed as accidental when during a crash, the main structure of the car (chassis, - front door pillar, central pillar, rear pillar, floor pan or front cross) gets damaged.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bdcf4eb9-4ee0-4291-aee8-d28e165ae4c6', NULL, NULL, 0, 0)
GO
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'35d9a99e-2e8c-4af8-9b89-df65bea5a638', N'Do you give a guarantee on odometer?', N'We don''t offer any guarantee on the odometer. Our Engineers check odometer for tampering if any and verify vehicle service history records as well and only upon satisfaction the TrustMark certification is given.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'07adb1cc-9bb5-430c-85cb-66818f9fed7e', NULL, NULL, 0, 0)
GO
INSERT [dbo].[FAQs] ([FaqId], [Question], [Answer], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'f66488cc-bbb6-4e4e-9954-dfbcad3c0010', N'Where should I go if I have a problem?', N'In the event of a problem please call our Helpline number at 1800 103 9088.', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'35d9a99e-2e8c-4af8-9b89-df65bea5a638', NULL, NULL, 0, 0)
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'fd06527b-6ad0-4b09-8a3c-2acb3bf2c819', N'Renting')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'ce5b19bd-b3a1-4a46-93a0-5da37305c341', N'Subscribing')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'b932f5e1-d0e5-49c1-80a2-75c05f6153f3', N'Website')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'43c2d7cf-5c22-4bda-b623-ca428a6b8174', N'Service')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'f9bfaae6-4c20-4a0b-a1b2-d38f47e04614', N'Others')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'31acae95-e9cd-4b03-8ff4-e1bb7007ad65', N'Buy a new car')
GO
INSERT [dbo].[FeedbackCategory] ([Id], [Category]) VALUES (N'553666af-7988-490d-9d78-ef597937897f', N'Buy a used car')
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'8afd8ba9-1005-4f27-9023-11cbd37d3f12', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'39e99942-55f9-4a20-a167-223252143717', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'f8607529-42eb-4b05-b61c-2fb5d01875af', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'cbaa08cf-0488-4f20-a477-30ea19b74424', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'08d82ed4-b9a6-41bb-a6d8-34e639fad5dd', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'e1960970-beb3-4e2b-83a1-3eb591e8082a', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'fea3d470-5292-4342-b322-427aaafacfd7', N'tok_1ISbkxLfHfDp45gu6AoMUnpc', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'd2309e5f-8dbf-4519-a32e-508951557087', N'tok_1IRvFwLfHfDp45guTybFngxN', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'34bf2706-79c8-4964-b80f-51162052ad48', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'90c25f61-fd5c-4434-a907-61f29fae3513', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'3ffe5f6d-0dbe-4fdd-b623-691536d6c289', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'b2bc1c85-ab81-43f6-a0cf-7d140007f696', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'24694217-d3d9-4fc5-9eab-8a9b8e50d4de', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'17ba9edc-6442-49ab-918b-9b9b288fb340', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'01799a80-3804-4299-98cf-9f0ac0b11293', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'c3ab966f-b80b-40e4-9207-ae127c5ff11a', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'4400192e-5b62-4d16-893d-ae5dec0689c8', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'015f3c99-1df9-46e5-b23b-b3216e54006e', N'tok_1IS4smLfHfDp45gu8nu41tqM', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'74f6c930-c2b7-4d90-b106-c4d825fbb439', N'tok_1ISbB5LfHfDp45guoqsOKQBE', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'db45dc5c-239b-44eb-bb49-c6eaba053768', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'0166782c-5156-43da-9389-da92815901d5', N'tok_1ISbbLLfHfDp45guFunDkE0n', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'dcb30be8-d4e7-4ede-9fad-ddf36ae22d4f', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [TranscationId], [Frequency], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted]) VALUES (N'b9a6a0bc-ba62-43be-a1a6-f5ac00cc1097', N'ch_1IRCnsLfHfDp45gulz5HqbhR', 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[PaymentMethods] ([PaymentMethodId], [Name]) VALUES (N'fad5eda1-5ddf-4b99-9ba7-80ebf658b10f', N'Card')
GO
INSERT [dbo].[Pincodes] ([PincodeId], [CityId], [Pincode]) VALUES (N'6ec4327c-e483-4970-884c-c8b99bb178c9', N'02a68be8-fb5b-4dc7-8fa2-9ae9b9c92560', 380004)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'bcfbf4d9-f57f-46c0-8e12-01b71f7885b1', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'nyc', 4, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4a1d0bf8-3a35-4928-92e1-1ef894361862', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'nyc', 5, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'862def36-63df-4dd2-abec-2205702681ab', N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', NULL, N'good', 3, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'539bcda6-b584-41f9-9291-4701d140450f', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', NULL, N'good', 4, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'7b5b5542-4b00-414e-9977-8e4c0adfc687', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', NULL, N'good', 2, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'bf7859e3-fa2c-47df-bc6d-9197bc26cacc', N'a5a7865d-3a29-4e30-87e7-28b896bb28e4', NULL, N'nyc', 3, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[Reviews] ([ReviewId], [CarId], [UserId], [Title], [Rating], [Discription], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status]) VALUES (N'4b9e3dfa-32c6-420c-bc04-efd661051f4d', N'9355c897-7671-4ab8-885e-5341d4abe5ca', NULL, N'nyc', 5, N'good', CAST(N'2021-02-02T00:00:00.000' AS DateTime), NULL, N'02/02/2021', NULL, 0, 0)
GO
INSERT [dbo].[States] ([StateId], [CountryId], [StateName]) VALUES (N'35b70a61-714a-449d-a520-2678b88296db', N'bb300cee-8c5f-4a52-b5ba-304f094f9e15', N'Gujarat')
GO
INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image]) VALUES (N'8a4e40e4-1159-44e4-9707-2ea14b352d5c', N'ss520553@gmail.com', N'123456', N'Saurabh singh', N'+919621221615', NULL, NULL, 0, CAST(N'2021-03-07T00:57:29.693' AS DateTime), NULL, NULL, NULL, 0, 0, N'User07032021 125729 AM.jpg')
GO
INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image]) VALUES (N'5309fb2f-a419-498f-994e-3604857d4ce6', N'ram@gmail.com', N'123456', N'ram', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-04T15:54:54.707' AS DateTime), NULL, NULL, NULL, 0, 0, N'User342021 35454 PM.jpg')
GO
INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image]) VALUES (N'c2d94db4-081c-4c2d-bc71-6e3a94d32c8e', N'ram23@gmail.com', N'123456', N'ram', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-04T15:54:54.707' AS DateTime), NULL, NULL, NULL, 0, 0, N'User342021 35454 PM.jpg')
GO
INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image]) VALUES (N'bd4725b3-cab7-4a4d-a391-8fef46a1a99a', N'saurabh@gmail.com', N'123456', N'Saurabh', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'bd4725b3-cab7-4a4d-a391-8fef46a1a99b', 0, 0, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [ContactNo], [AddressId], [IdProof], [Points], [CreatedAt], [CreatedBy], [ModifiedAt], [ModifiedBy], [IsDeleted], [Status], [Image]) VALUES (N'2d39e7c0-97ad-4eda-be20-e75e2572d239', N'rutvikoop1@gmail.com', N'123456', N'bharat', N'9621221615', N'eb53730d-ba07-41b1-9787-be724cb40160', NULL, 0, CAST(N'2021-03-04T15:54:54.707' AS DateTime), NULL, NULL, NULL, 1, 0, N'User342021 35454 PM.jpg')
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_AddressId]  DEFAULT (newid()) FOR [AddressId]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_PurchaseAddresses_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_CarPurchaseId]  DEFAULT (newid()) FOR [CarPurchaseId]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_IsFullPayment]  DEFAULT ((0)) FOR [IsFullPayment]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[CarPurchases] ADD  CONSTRAINT [DF_CarPurchases_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CarRents] ADD  CONSTRAINT [DF_CarRents_IsPaymentDone]  DEFAULT ((0)) FOR [IsPaymentDone]
GO
ALTER TABLE [dbo].[CarRents] ADD  CONSTRAINT [DF_CarRents_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CarRents] ADD  CONSTRAINT [DF_CarRents_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_ModifyAt]  DEFAULT (getdate()) FOR [ModifyAt]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Cities] ADD  CONSTRAINT [DF_Cities_CityId]  DEFAULT (newid()) FOR [CityId]
GO
ALTER TABLE [dbo].[ContactUs] ADD  CONSTRAINT [DF_ContactUs_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [DF_Countries_CountryId]  DEFAULT (newid()) FOR [CountryId]
GO
ALTER TABLE [dbo].[Currencies] ADD  CONSTRAINT [DF_Currencies_CurrencyId]  DEFAULT (newid()) FOR [CurrencyId]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_DealerId]  DEFAULT (newid()) FOR [DealerId]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_IsVerified]  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[EMIs] ADD  CONSTRAINT [DF_EMIs_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[EMIs] ADD  CONSTRAINT [DF_EMIs_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[FAQs] ADD  CONSTRAINT [DF_FAQs_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FAQs] ADD  CONSTRAINT [DF_FAQs_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Invoices] ADD  CONSTRAINT [DF_Invoices_Frequency]  DEFAULT ((0)) FOR [Frequency]
GO
ALTER TABLE [dbo].[Invoices] ADD  CONSTRAINT [DF_Invoices_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Offers] ADD  CONSTRAINT [DF_Offers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Offers] ADD  CONSTRAINT [DF_Offers_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[PaymentMethods] ADD  CONSTRAINT [DF_PaymentMethods_PaymentMethodId]  DEFAULT (newid()) FOR [PaymentMethodId]
GO
ALTER TABLE [dbo].[Pincodes] ADD  CONSTRAINT [DF_Pincodes_PincodeId]  DEFAULT (newid()) FOR [PincodeId]
GO
ALTER TABLE [dbo].[Promo] ADD  CONSTRAINT [DF_Promo_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[Promo] ADD  CONSTRAINT [DF_Promo_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_ReviewId]  DEFAULT (newid()) FOR [ReviewId]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[States] ADD  CONSTRAINT [DF_States_StateId]  DEFAULT (newid()) FOR [StateId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Points]  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Pincodes] FOREIGN KEY([PincodeId])
REFERENCES [dbo].[Pincodes] ([PincodeId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Pincodes]
GO
ALTER TABLE [dbo].[CarCategoryMapper]  WITH CHECK ADD  CONSTRAINT [FK_CarCategoryMapper_CarCategories] FOREIGN KEY([CarCategoryId])
REFERENCES [dbo].[CarCategories] ([Id])
GO
ALTER TABLE [dbo].[CarCategoryMapper] CHECK CONSTRAINT [FK_CarCategoryMapper_CarCategories]
GO
ALTER TABLE [dbo].[CarCategoryMapper]  WITH CHECK ADD  CONSTRAINT [FK_CarCategoryMapper_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarCategoryMapper] CHECK CONSTRAINT [FK_CarCategoryMapper_Cars]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Addresses]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_CarVarients] FOREIGN KEY([CarVarientId])
REFERENCES [dbo].[CarVarients] ([Id])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_CarVarients]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([CurrencyId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Currencies]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([DealerId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Dealers]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_EMIs] FOREIGN KEY([EmiId])
REFERENCES [dbo].[EMIs] ([EmiId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_EMIs]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Invoices]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_PaymentMethods]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Promo] FOREIGN KEY([PromoId])
REFERENCES [dbo].[Promo] ([PromoId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Promo]
GO
ALTER TABLE [dbo].[CarPurchases]  WITH CHECK ADD  CONSTRAINT [FK_CarPurchases_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CarPurchases] CHECK CONSTRAINT [FK_CarPurchases_Users]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Addresses] FOREIGN KEY([PickupPoint])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Addresses]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Addresses1] FOREIGN KEY([DropPoint])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Addresses1]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_CarVarients] FOREIGN KEY([CarVarientId])
REFERENCES [dbo].[CarVarients] ([Id])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_CarVarients]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([CurrencyId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Currencies]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Invoices]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_PaymentMethods]
GO
ALTER TABLE [dbo].[CarRents]  WITH CHECK ADD  CONSTRAINT [FK_CarRents_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[CarRents] CHECK CONSTRAINT [FK_CarRents_Users]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Addresses]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarCategories] FOREIGN KEY([CarCategoryId])
REFERENCES [dbo].[CarCategories] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarCategories]
GO
ALTER TABLE [dbo].[CarVarients]  WITH CHECK ADD  CONSTRAINT [FK_CarVarients_Cars] FOREIGN KEY([carId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarVarients] CHECK CONSTRAINT [FK_CarVarients_Cars]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_States]
GO
ALTER TABLE [dbo].[Currencies]  WITH CHECK ADD  CONSTRAINT [FK_Currencies_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Currencies] CHECK CONSTRAINT [FK_Currencies_Countries]
GO
ALTER TABLE [dbo].[Dealers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_Addresses1] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Dealers] CHECK CONSTRAINT [FK_Dealers_Addresses1]
GO
ALTER TABLE [dbo].[Dealers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_Admin] FOREIGN KEY([VerifiedBy])
REFERENCES [dbo].[Admin] ([Id])
GO
ALTER TABLE [dbo].[Dealers] CHECK CONSTRAINT [FK_Dealers_Admin]
GO
ALTER TABLE [dbo].[EMIs]  WITH CHECK ADD  CONSTRAINT [FK_EMIs_Banks] FOREIGN KEY([BankId])
REFERENCES [dbo].[Banks] ([BankId])
GO
ALTER TABLE [dbo].[EMIs] CHECK CONSTRAINT [FK_EMIs_Banks]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_FeedbackCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[FeedbackCategory] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_FeedbackCategory]
GO
ALTER TABLE [dbo].[Pincodes]  WITH CHECK ADD  CONSTRAINT [FK_Pincodes_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[Pincodes] CHECK CONSTRAINT [FK_Pincodes_Cities]
GO
ALTER TABLE [dbo].[Promo]  WITH CHECK ADD  CONSTRAINT [FK_Promo_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Promo] CHECK CONSTRAINT [FK_Promo_Users]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Cars]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD  CONSTRAINT [FK_States_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[States] CHECK CONSTRAINT [FK_States_Countries]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Addresses]
GO
USE [master]
GO
ALTER DATABASE [MyCarDb] SET  READ_WRITE 
GO
