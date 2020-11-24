CREATE PROCEDURE [dbo].[GetFilmByLanguage]
	@LanguageId int
AS
begin
	select Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId] 
	from Film
	where Film.LanguageId = @LanguageId
end