CREATE PROCEDURE [dbo].[DeleteRental]
	@RentalId int
AS
begin
	Delete From Rental
	Where RentalId = @RentalId
end