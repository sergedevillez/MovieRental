CREATE PROCEDURE [dbo].[GetFilm]
	@FilmId int 
AS
	SELECT Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId] from Film
	where FilmId = @FilmId
RETURN 0
