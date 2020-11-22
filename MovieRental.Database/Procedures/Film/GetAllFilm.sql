CREATE PROCEDURE [dbo].[GetAllFilm]
AS
begin
	SELECT Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId] from Film
end