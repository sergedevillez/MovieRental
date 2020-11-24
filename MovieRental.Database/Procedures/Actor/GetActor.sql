CREATE PROCEDURE [dbo].[GetActor]
	@ActorId int
AS
begin
	SELECT ActorId, FirstName, LastName from Actor where ActorId = @ActorId
end