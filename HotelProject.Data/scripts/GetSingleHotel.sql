USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetSingleHotel]    Script Date: 04.04.2024 08:26:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[sp_GetSingleHotel]
@id INT
AS
BEGIN
	SELECT*FROM Hotels
	WHERE Id = @id
END
GO


