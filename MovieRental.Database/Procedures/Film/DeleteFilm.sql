CREATE PROCEDURE [dbo].[DeleteFilm]
	@FilmId int
AS
begin
	Delete from Film
	where FilmId = @FilmId
end