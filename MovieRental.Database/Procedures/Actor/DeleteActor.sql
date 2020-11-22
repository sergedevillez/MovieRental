CREATE PROCEDURE [dbo].[DeleteActor]
	@ActorId int
AS
begin
	Delete from Actor where ActorId = @ActorId
end