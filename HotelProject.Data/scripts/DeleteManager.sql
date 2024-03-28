USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteManager]    Script Date: 29.03.2024 00:52:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[sp_DeleteManager]
 @id INT
 AS
 BEGIN
 DELETE Managers
 WHERE Id = @id
 END
GO


