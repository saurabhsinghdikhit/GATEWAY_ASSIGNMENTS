USE [master]
GO
/****** Object:  Database [ServiceBookingSystem]    Script Date: 11-02-2021 03:23:34 PM ******/
CREATE DATABASE [ServiceBookingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ServiceBookingSystem', FILENAME = N'C:\Users\Ss520\ServiceBookingSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ServiceBookingSystem_log', FILENAME = N'C:\Users\Ss520\ServiceBookingSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ServiceBookingSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServiceBookingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServiceBookingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServiceBookingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServiceBookingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ServiceBookingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServiceBookingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ServiceBookingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ServiceBookingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServiceBookingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServiceBookingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServiceBookingSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ServiceBookingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ServiceBookingSystem] SET QUERY_STORE = OFF
GO
USE [ServiceBookingSystem]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ServiceBookingSystem]
GO
/****** Object:  Table [dbo].[AppointBookings]    Script Date: 11-02-2021 03:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointBookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[VehicleId] [int] NOT NULL,
	[DealerId] [int] NOT NULL,
	[MechanicId] [int] NULL,
	[ServiceId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_AppointBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11-02-2021 03:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[City] [nvarchar](30) NOT NULL,
	[State] [nvarchar](30) NOT NULL,
	[Zipcode] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](13) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Question] [nvarchar](50) NOT NULL,
	[Answer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealers]    Script Date: 11-02-2021 03:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](70) NOT NULL,
	[City] [nvarchar](30) NOT NULL,
	[State] [nvarchar](30) NOT NULL,
	[Zipcode] [int] NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Mobile] [nvarchar](13) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Dealers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mechanics]    Script Date: 11-02-2021 03:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mechanics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Mobile] [nvarchar](13) NOT NULL,
	[Make] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[DealerId] [int] NOT NULL,
 CONSTRAINT [PK_Mechanics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 11-02-2021 03:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[Duration] [nvarchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 11-02-2021 03:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](12) NOT NULL,
	[Make] [nvarchar](25) NOT NULL,
	[Model] [nvarchar](25) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[ChassisNo] [nvarchar](50) NOT NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AppointBookings] ON 

INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (1, CAST(N'2021-02-11T00:56:00.000' AS DateTime), CAST(N'2021-02-03T00:56:00.000' AS DateTime), 1, 1, 2, 1, 3, NULL, 1)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (2, CAST(N'2021-02-11T03:00:00.000' AS DateTime), CAST(N'2021-02-25T01:00:00.000' AS DateTime), 2, 1, 4, 2, 3, NULL, 1)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (1009, CAST(N'2021-02-12T23:23:00.000' AS DateTime), CAST(N'2021-02-18T23:23:00.000' AS DateTime), 1, 1, 2, 2, 3, NULL, 1)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (1010, CAST(N'2021-07-02T14:57:00.000' AS DateTime), CAST(N'2021-06-24T14:57:00.000' AS DateTime), 1003, 1, 2, 2, 1005, 1, 1)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (1012, CAST(N'2021-04-09T14:49:00.000' AS DateTime), CAST(N'2021-05-21T14:49:00.000' AS DateTime), 1, 2, 2, 2, 3, 1, 1)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (2002, CAST(N'2021-02-03T14:06:00.000' AS DateTime), CAST(N'2021-02-08T14:06:00.000' AS DateTime), 1003, 1, 2, 2, 3, 1, 1)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (2003, CAST(N'2021-02-01T13:15:00.000' AS DateTime), CAST(N'2021-02-03T13:15:00.000' AS DateTime), 1002, 1, NULL, 2, 3, 1, 0)
INSERT [dbo].[AppointBookings] ([Id], [StartTime], [EndTime], [VehicleId], [DealerId], [MechanicId], [ServiceId], [CreatedBy], [UpdatedBy], [Status]) VALUES (2004, CAST(N'2021-02-02T13:23:00.000' AS DateTime), CAST(N'2021-02-02T13:23:00.000' AS DateTime), 1003, 1, NULL, 2, 1005, NULL, 0)
SET IDENTITY_INSERT [dbo].[AppointBookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password], [Question], [Answer]) VALUES (3, N'Saurabh sinha', N'B38,India Colony', N'NAVSARI', N'GUJARAT', 396450, N'ss5205@gmail.com', N'9621221615', N'1234567', N'first pet name?', N'jolly')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password], [Question], [Answer]) VALUES (1005, N'Saurabh singh', N'B38,India Colony', N'NAVSARI', N'GUJARAT', 396450, N'ss520553@gmail.com', N'9621221615', N'123456', N'first pet name?', N'jolly')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Dealers] ON 

INSERT [dbo].[Dealers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password]) VALUES (1, N'Raju', N'navsari', N'navsari', N'gujarat', 396450, N'ss520553@gmail.com', N'9621221615', N'123456')
INSERT [dbo].[Dealers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password]) VALUES (2, N'Ram Singh', N'1338', N'Navsari', N'Gujarat', 396450, N'ss24', N'4356465', N'123456')
INSERT [dbo].[Dealers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password]) VALUES (2003, N'Saurabh singh', N'B38,India Colony', N'NAVSARI', N'GUJARAT', 396450, N'ss520553@gmail.com', N'+919621221615', N'123456')
SET IDENTITY_INSERT [dbo].[Dealers] OFF
GO
SET IDENTITY_INSERT [dbo].[Mechanics] ON 

INSERT [dbo].[Mechanics] ([Id], [Name], [Mobile], [Make], [Email], [DealerId]) VALUES (2, N'Manish', N'9662008331', N'Hero', N'ss520553@gmail.com', 2)
INSERT [dbo].[Mechanics] ([Id], [Name], [Mobile], [Make], [Email], [DealerId]) VALUES (4, N'Saurabh singh', N'+919621221615', N'Yamaha', N'ss520553@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[Mechanics] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Name], [Price], [Duration], [Active]) VALUES (2, N'Engine', CAST(3000.00 AS Decimal(6, 2)), N'3hr', 0)
INSERT [dbo].[Services] ([Id], [Name], [Price], [Duration], [Active]) VALUES (1002, N'Oiling', CAST(1000.00 AS Decimal(6, 2)), N'1Hr', 0)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (1, N'GJ21BB5444', N'Hero', N'Splender', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 3)
INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (2, N'GJ21AP5444', N'Yamaha', N'Fazer', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 3)
INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (1002, N'GJ21AP5444', N'Hero', N'Splender', CAST(N'2021-02-03T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 3)
INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (1003, N'GJ21AP5444', N'Hero', N'Splender', CAST(N'2021-02-10T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 1005)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
ALTER TABLE [dbo].[AppointBookings] ADD  CONSTRAINT [DF_AppointBooking_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [UC_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[AppointBookings]  WITH CHECK ADD  CONSTRAINT [FK_AppointBookings_DealerId] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[AppointBookings] CHECK CONSTRAINT [FK_AppointBookings_DealerId]
GO
ALTER TABLE [dbo].[AppointBookings]  WITH CHECK ADD  CONSTRAINT [FK_AppointBookings_MechanicId] FOREIGN KEY([MechanicId])
REFERENCES [dbo].[Mechanics] ([Id])
GO
ALTER TABLE [dbo].[AppointBookings] CHECK CONSTRAINT [FK_AppointBookings_MechanicId]
GO
ALTER TABLE [dbo].[AppointBookings]  WITH CHECK ADD  CONSTRAINT [FK_AppointBookings_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[AppointBookings] CHECK CONSTRAINT [FK_AppointBookings_VehicleId]
GO
ALTER TABLE [dbo].[Mechanics]  WITH CHECK ADD  CONSTRAINT [FK_Mechanics_DealerId] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[Mechanics] CHECK CONSTRAINT [FK_Mechanics_DealerId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_OwnerId]
GO
USE [master]
GO
ALTER DATABASE [ServiceBookingSystem] SET  READ_WRITE 
GO
