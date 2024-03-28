USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddNewHotel]    Script Date: 29.03.2024 00:50:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddNewHotel]
@name NVARCHAR(50),
@rating FLOAT,
@country NVARCHAR(50),
@city NVARCHAR(50),
@physicalAddress NVARCHAR(50),
@managerId INT
AS
BEGIN
INSERT INTO Hotels
           ([Name]
           ,[Rating]
           ,[Country]
           ,[City]
           ,[PhysicalAddress]
           ,[ManagerId])
     VALUES(@name, @rating, @country, @city, @physicalAddress,@managerId)
END
GO


