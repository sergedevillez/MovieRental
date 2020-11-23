CREATE PROCEDURE [dbo].[AddRental]
	@RentalDate DateTime = SYSDATETIME,
	@CustomerId int
AS
begin
	Insert into Rental (RentalDate , CustomerId) 
	Values (@RentalDate, @CustomerId)
end