USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteHotel]    Script Date: 04.04.2024 08:24:51 ******/
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


