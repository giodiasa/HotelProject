USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddNewManager]    Script Date: 04.04.2024 08:24:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddNewManager]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@hotelId INT
AS
BEGIN
INSERT INTO Managers(FirstName,LastName, HotelId)
VALUES(@firstName, @lastName, @hotelId)
END
GO


