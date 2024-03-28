USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllManagers]    Script Date: 29.03.2024 00:52:32 ******/
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
  FROM [DOITHotel_BCTFO].[dbo].[Managers]
  END
GO


