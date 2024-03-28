USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateHotel]    Script Date: 29.03.2024 00:57:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_UpdateHotel]
@id INT,
@name NVARCHAR(50),
@rating FLOAT,
@country NVARCHAR(50),
@city NVARCHAR(50),
@physicalAddress NVARCHAR(50),
@managerId INT
AS
BEGIN
UPDATE Hotels
   SET [Name] = @name
      ,[Rating] = @rating
      ,[Country] = @country
      ,[City] = @city
      ,[PhysicalAddress] = @physicalAddress
      ,[ManagerId] = @managerId
 WHERE Id = @id
 END
GO


