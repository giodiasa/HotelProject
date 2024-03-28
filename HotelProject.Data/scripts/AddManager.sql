USE [DOITHotel_BCTFO]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddNewManager]    Script Date: 29.03.2024 00:52:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddNewManager]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
INSERT INTO Managers(FirstName,LastName)
VALUES(@firstName, @lastName)
END
GO


