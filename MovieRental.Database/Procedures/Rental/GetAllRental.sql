CREATE PROCEDURE [dbo].[GetAllRental]
AS
begin
	SELECT RentalId, RentalDate, CustomerId from Rental
end