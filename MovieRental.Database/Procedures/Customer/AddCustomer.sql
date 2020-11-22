CREATE PROCEDURE [dbo].[AddCustomer]
	@FirstName nvarchar(75),
	@LastName nvarchar(75),
	@Email nvarchar(320),
	@Passwd binary(64)
as
begin
	Insert Into Customer (FirstName, LastName, Email, Passwd) 
	output inserted.CustomerId 
	Values(@FirstName, @LastName, @Email, @Passwd)
end