USE [DOITHotel_BCTFO]
GO

/****** Object:  Table [dbo].[Hotels]    Script Date: 04.04.2024 08:28:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Rating] [float] NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PhysicalAddress] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [CK_ValidRating] CHECK  (([Rating]>=(1) AND [Rating]<=(10)))
GO

ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [CK_ValidRating]
GO


