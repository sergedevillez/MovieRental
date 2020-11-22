CREATE PROCEDURE [dbo].[DeleteCustomer]
	@CustomerId int
as
begin
	Delete from Customer where CustomerId = @CustomerId
end
