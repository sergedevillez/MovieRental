CREATE PROCEDURE [dbo].[GetCustomer]
	@CustomerId int
AS
begin
	SELECT FirstName, LastName, Email, Passwd from Customer
	where CustomerId = @CustomerId
end