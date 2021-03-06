USE [master]
GO
/****** Object:  Database [ServiceBookingSystem]    Script Date: 11-02-2021 03:24:59 PM ******/
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
/****** Object:  Table [dbo].[AppointBookings]    Script Date: 11-02-2021 03:24:59 PM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 11-02-2021 03:24:59 PM ******/
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
/****** Object:  Table [dbo].[Dealers]    Script Date: 11-02-2021 03:24:59 PM ******/
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
/****** Object:  Table [dbo].[Mechanics]    Script Date: 11-02-2021 03:24:59 PM ******/
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
/****** Object:  Table [dbo].[Services]    Script Date: 11-02-2021 03:24:59 PM ******/
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
/****** Object:  Table [dbo].[Vehicles]    Script Date: 11-02-2021 03:24:59 PM ******/
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
