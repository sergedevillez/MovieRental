CREATE PROCEDURE [dbo].[GetFilmByTitle]
	@Title nvarchar(max)
AS
begin
	select Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId] 
	from Film
	where Film.Title = @Title
end