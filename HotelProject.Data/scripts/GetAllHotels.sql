USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllHotels]    Script Date: 04.04.2024 08:25:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllHotels]
AS
BEGIN
SELECT Id,Name,Rating,Country,City,PhysicalAddress
  FROM Hotels
END
GO


