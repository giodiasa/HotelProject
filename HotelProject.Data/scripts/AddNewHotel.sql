USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddNewHotel]    Script Date: 04.04.2024 08:24:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddNewHotel]
@name NVARCHAR(50),
@rating FLOAT,
@country NVARCHAR(50),
@city NVARCHAR(50),
@physicalAddress NVARCHAR(50)
AS
BEGIN
INSERT INTO Hotels
           ([Name]
           ,[Rating]
           ,[Country]
           ,[City]
           ,[PhysicalAddress])
     VALUES(@name, @rating, @country, @city, @physicalAddress)
END
GO


