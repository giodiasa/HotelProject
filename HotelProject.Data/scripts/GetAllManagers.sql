USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllManagers]    Script Date: 04.04.2024 08:25:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[sp_GetAllManagers]
  AS
  BEGIN
  SELECT [Id]
      ,[FirstName]
      ,[LastName]
	  ,[HotelId]
  FROM [DOITHotel_BCTFO].[dbo].[Managers]
  END
GO


