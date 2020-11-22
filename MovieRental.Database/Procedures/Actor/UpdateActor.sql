CREATE PROCEDURE [dbo].[UpdateActor]
	@ActorId int,
	@FirstName int,
	@LastName int
AS
begin
	Update Actor
	Set FirstName = @FirstName, LastName = @LastName
	where ActorId = @ActorId
end