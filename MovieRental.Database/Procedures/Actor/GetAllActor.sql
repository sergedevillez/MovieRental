CREATE PROCEDURE [dbo].[GetAllActor]
AS
begin
	SELECT ActorId, FirstName, LastName from Actor
end