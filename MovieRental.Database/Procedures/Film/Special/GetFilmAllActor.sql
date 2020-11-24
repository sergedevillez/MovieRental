CREATE PROCEDURE [dbo].[GetFilmAllActor]
	@FilmId int
AS
begin
	SELECT Actor.FirstName, Actor.LastName from FilmActor Join Actor On FilmActor.ActorId = Actor.ActorId
	where FilmActor.FilmId = @FilmId
end