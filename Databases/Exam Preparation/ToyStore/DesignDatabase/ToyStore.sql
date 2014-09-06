USE [ToyStore]
GO
/****** Object:  Table [dbo].[AgeRanges]    Script Date: 5.9.2014 г. 20:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeRanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinAge] [tinyint] NOT NULL,
	[MaxAge] [tinyint] NOT NULL,
 CONSTRAINT [PK_AgeRanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5.9.2014 г. 20:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 5.9.2014 г. 20:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Toys]    Script Date: 5.9.2014 г. 20:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Toys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Type] [varchar](50) NULL,
	[AgeRanges_Id] [int] NULL,
	[Categories_Id] [int] NULL,
	[Manufacturers_Id] [int] NOT NULL,
	[Price] [decimal](19, 4) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Manufacturer_Id] [int] NOT NULL,
 CONSTRAINT [PK_Toys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_ManufacturerToy] FOREIGN KEY([Manufacturer_Id])
REFERENCES [dbo].[Manufacturers] ([Id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_ManufacturerToy]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_AgeRanges] FOREIGN KEY([AgeRanges_Id])
REFERENCES [dbo].[AgeRanges] ([Id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_AgeRanges]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_Categories] FOREIGN KEY([Categories_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_Categories]
GO
