CREATE PROCEDURE [dbo].[GetActor]
	@ActorId int
AS
begin
	SELECT ActorId, Firstname, LastName from Actor where ActorId = @ActorId
end