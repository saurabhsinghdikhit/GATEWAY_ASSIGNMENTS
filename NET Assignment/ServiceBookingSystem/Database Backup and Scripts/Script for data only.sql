USE [ServiceBookingSystem]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password], [Question], [Answer]) VALUES (3, N'Saurabh sinha', N'B38,India Colony', N'NAVSARI', N'GUJARAT', 396450, N'ss5205@gmail.com', N'9621221615', N'1234567', N'first pet name?', N'jolly')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [City], [State], [Zipcode], [Email], [Mobile], [Password], [Question], [Answer]) VALUES (1005, N'Saurabh singh', N'B38,India Colony', N'NAVSARI', N'GUJARAT', 396450, N'ss520553@gmail.com', N'9621221615', N'123456', N'first pet name?', N'jolly')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (1, N'GJ21BB5444', N'Hero', N'Splender', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 3)
INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (2, N'GJ21AP5444', N'Yamaha', N'Fazer', CAST(N'2020-12-12T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 3)
INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (1002, N'GJ21AP5444', N'Hero', N'Splender', CAST(N'2021-02-03T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 3)
INSERT [dbo].[Vehicles] ([Id], [LicensePlate], [Make], [Model], [RegistrationDate], [ChassisNo], [OwnerId]) VALUES (1003, N'GJ21AP5444', N'Hero', N'Splender', CAST(N'2021-02-10T00:00:00.000' AS DateTime), N'jdfgkjsdfgj', 1005)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
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
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Name], [Price], [Duration], [Active]) VALUES (2, N'Engine', CAST(3000.00 AS Decimal(6, 2)), N'3hr', 0)
INSERT [dbo].[Services] ([Id], [Name], [Price], [Duration], [Active]) VALUES (1002, N'Oiling', CAST(1000.00 AS Decimal(6, 2)), N'1Hr', 0)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
