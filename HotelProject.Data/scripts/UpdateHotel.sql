USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateHotel]    Script Date: 04.04.2024 08:27:02 ******/
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
@physicalAddress NVARCHAR(50)
AS
BEGIN
UPDATE Hotels
   SET [Name] = @name
      ,[Rating] = @rating
      ,[Country] = @country
      ,[City] = @city
      ,[PhysicalAddress] = @physicalAddress
 WHERE Id = @id
 END
GO


