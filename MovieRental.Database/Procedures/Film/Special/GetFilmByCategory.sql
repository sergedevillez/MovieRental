CREATE PROCEDURE [dbo].[GetFilmByCategory]
	@CategoryId int
AS
begin
	select Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId] 
	from Film join FilmCategory on Film.FilmId = FilmCategory.FilmId
	where FilmCategory.CategoryId = @CategoryId
end