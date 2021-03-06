USE [SportsStore]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/26/2011 11:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (1, N'Watersports                                                                                         ')
INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (2, N'Soccer                                                                                              ')
INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (3, N'Chess                                                                                               ')
INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (5, N'Basketball                                                                                          ')
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[Products]    Script Date: 12/26/2011 11:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Description] [nchar](500) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (2, N'Kayak                                                                                               ', N'A boat for one Person only                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', CAST(275.00 AS Decimal(16, 2)), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (5, N'Lifejacket                                                                                          ', N'Protective and Fashionable.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ', CAST(48.95 AS Decimal(16, 2)), 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (6, N'Socker ball                                                                                         ', N'FIFA approved size                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ', CAST(19.50 AS Decimal(16, 2)), 2)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (7, N'Corner flag                                                                                         ', N'Give  your playing field the professinal look                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ', CAST(34.95 AS Decimal(16, 2)), 2)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (8, N'Thinking Cap                                                                                        ', N'Improve your brain efficiency                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ', CAST(29.95 AS Decimal(16, 2)), 3)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (9, N'Stadium                                                                                             ', N'Flat package 35,000 seat capacity                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ', CAST(79500.00 AS Decimal(16, 2)), 2)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (10, N'Human Chess Table                                                                                   ', N'A fun game for full family                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', CAST(75.00 AS Decimal(16, 2)), 3)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (11, N'Blink-bink king                                                                                     ', N'Gold plated Diamond studded King                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ', CAST(1200.00 AS Decimal(16, 2)), 3)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CategoryID]) VALUES (12, N'Snorkel                                                                                             ', N'Used for under snorkeling                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', CAST(105.00 AS Decimal(16, 2)), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
/****** Object:  ForeignKey [FK_Products_Categories]    Script Date: 12/26/2011 11:43:43 ******/
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
