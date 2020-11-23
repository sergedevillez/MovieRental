CREATE PROCEDURE [dbo].[UpdateRental]
	@RentalId int,
	@RentalDate DateTime,
	@CustomerId int
AS
begin
	Update Rental
	Set RentalDate = @RentalDate,
	CustomerId = @CustomerId
	where RentalId = @RentalId
end