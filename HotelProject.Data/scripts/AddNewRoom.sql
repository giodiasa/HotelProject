
CREATE PROCEDURE [dbo].[sp_AddNewRoom]
@name NVARCHAR (50),
@isFree BIT,
@hotelId INT,
@dailyPrice DECIMAL(10,2)
AS
BEGIN
INSERT INTO [dbo].[Rooms]
           ([Name]
           ,[IsFree]
           ,[HotelId]
           ,[DailyPrice])
     VALUES(@name, @isFree, @hotelId, @dailyPrice)
END