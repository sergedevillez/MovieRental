CREATE PROCEDURE [dbo].[GetFilmByActor]
	@ActorId int
AS
begin
	select Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId] 
	from Film join FilmActor on Film.FilmId = FilmActor.FilmId
	where FilmActor.ActorId = @ActorId
end