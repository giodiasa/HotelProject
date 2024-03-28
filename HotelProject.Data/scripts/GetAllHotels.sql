USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllHotels]    Script Date: 29.03.2024 00:52:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllHotels]
AS
BEGIN
SELECT Id,Name,Rating,Country,City,PhysicalAddress,ManagerId
  FROM Hotels
END
GO


