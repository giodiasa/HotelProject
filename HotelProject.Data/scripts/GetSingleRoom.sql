USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetSingleRoom]    Script Date: 04.04.2024 08:26:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetSingleRoom]
@id INT
AS
BEGIN
	SELECT*FROM Rooms
	WHERE Id = @id
END
GO


