
CREATE PROCEDURE [dbo].[sp_GetAllRooms]
AS
BEGIN
SELECT [Id]
      ,[Name]
      ,[IsFree]
      ,[HotelId]
      ,[DailyPrice]
  FROM [dbo].[Rooms]
END