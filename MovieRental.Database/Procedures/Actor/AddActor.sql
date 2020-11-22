CREATE PROCEDURE [dbo].[AddActor]
	@FirstName nvarchar(45),
	@LastName nvarchar(45)
AS
begin
	Insert into Actor (FirstName, LastName) 
	output inserted.ActorId
	Values (@FirstName, @LastName)
end