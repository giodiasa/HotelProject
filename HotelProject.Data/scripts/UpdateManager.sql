USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateManager]    Script Date: 29.03.2024 00:52:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


 CREATE PROCEDURE [dbo].[sp_UpdateManager]
 @id INT,
 @firstName NVARCHAR(50),
 @lastName NVARCHAR(50)
 AS
 BEGIN
 UPDATE Managers
   SET FirstName = @firstName,
      LastName = @lastName
 WHERE Id = @id
 END
GO


