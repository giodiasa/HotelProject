
CREATE PROCEDURE [dbo].[sp_DeleteRoom]
@id INT
AS
BEGIN
DELETE FROM [dbo].[Rooms]
      WHERE Id = @id
END