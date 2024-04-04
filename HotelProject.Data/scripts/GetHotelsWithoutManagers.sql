USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetHotelsWithoutManager]    Script Date: 04.04.2024 08:45:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetHotelsWithoutManager]
AS
BEGIN
SELECT Hotels.Id,Name,Rating,Country,City,PhysicalAddress
FROM Hotels
LEFT JOIN Managers
ON Hotels.Id = Managers.HotelId
WHERE Managers.HotelId IS NULL
END
GO


