USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetSingleManager]    Script Date: 04.04.2024 08:26:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetSingleManager]
@id INT
AS
BEGIN
	SELECT*FROM Managers
	WHERE Id = @id
END
GO


