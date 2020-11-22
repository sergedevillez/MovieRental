CREATE PROCEDURE [dbo].[UpdateCurstomer]
	@CustomerId int,
	@FirstName nvarchar(75),
	@LastName nvarchar(75),
	@Email nvarchar(320),
	@Passwd binary(64)
as
begin
	Update Customer 
	Set FirstName = @FirstName, 
	LastName = @LastName, 
	Email = @Email, 
	Passwd =  @Passwd
	where CustomerId = @CustomerId
end