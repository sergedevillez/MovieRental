CREATE PROCEDURE [dbo].[FilmByTitle]
@title nvarchar(255)

AS
BEGIN
	SELECT * FROM Film WHERE Title = @title;
END
