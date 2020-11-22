CREATE PROCEDURE [dbo].[AddActorToFilm]
	@FilmId int,
	@ActorId int
AS
begin
	Insert into FilmActor (FilmId, ActorId)
	Values (@FilmId, @ActorId)
end
