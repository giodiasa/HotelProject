CREATE PROCEDURE [dbo].[sp_UpdateRoom]
@id INT,
@name NVARCHAR (50),
@isFree BIT,
@hotelId INT,
@dailyPrice DECIMAL(10,2)
AS
BEGIN
UPDATE [dbo].[Rooms]
   SET [Name] = @name
      ,[IsFree] = @isFree
      ,[HotelId] = @hotelId
      ,[DailyPrice] = @dailyPrice
 WHERE Id = @id
END

