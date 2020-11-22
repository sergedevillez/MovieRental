CREATE PROCEDURE [dbo].[AddFilmToActor]
	@FilmId int,
	@ActorId int
AS
	Insert into FilmActor (FilmId, ActorId) 
	Values (@FilmId, @ActorId)
RETURN 0
