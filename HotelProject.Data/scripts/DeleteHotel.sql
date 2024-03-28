USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteHotel]    Script Date: 29.03.2024 00:52:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteHotel]
@id INT
AS
BEGIN
DELETE FROM [dbo].[Hotels]
      WHERE Id = @id
END
GO


