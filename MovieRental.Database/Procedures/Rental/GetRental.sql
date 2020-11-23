CREATE PROCEDURE [dbo].[GetRental]
	@RentalId int
AS
begin
	SELECT RentalId, RentalDate, CustomerId from Rental
	Where RentalId = @RentalId
end