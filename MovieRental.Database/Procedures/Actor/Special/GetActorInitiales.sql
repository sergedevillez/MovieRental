CREATE PROCEDURE [dbo].[GetActorInitiales]
AS
begin
	select Upper(substring(Actor.FirstName, 1, 1) + '.' + substring(Actor.LastName,1,1)) from Actor
end