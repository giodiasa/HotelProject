USE [DOITHotel_BCTFO]
GO

/****** Object:  Table [dbo].[Rooms]    Script Date: 02.04.2024 17:47:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsFree] [bit] NULL,
	[HotelId] [int] NULL,
	[DailyPrice] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO

ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [CK_ValidDailyPrice] CHECK  (([DailyPrice]>(0)))
GO

ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [CK_ValidDailyPrice]
GO

