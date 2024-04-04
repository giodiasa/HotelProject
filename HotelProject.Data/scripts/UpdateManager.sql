USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateManager]    Script Date: 04.04.2024 08:27:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


 CREATE PROCEDURE [dbo].[sp_UpdateManager]
 @id INT,
 @firstName NVARCHAR(50),
 @lastName NVARCHAR(50),
 @hotelId INT
 AS
 BEGIN
 UPDATE Managers
   SET FirstName = @firstName,
      LastName = @lastName,
	  HotelId = @hotelId
 WHERE Id = @id
 END
GO


