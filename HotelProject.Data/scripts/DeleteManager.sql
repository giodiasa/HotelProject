USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteManager]    Script Date: 04.04.2024 08:25:05 ******/
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


