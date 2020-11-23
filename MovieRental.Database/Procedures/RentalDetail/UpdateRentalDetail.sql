CREATE PROCEDURE [dbo].[UpdateRentalDetail]
	@RentalId int,
	@FilmId int,
	@RentalPrice decimal(5, 2)
AS
begin
	Update RentalDetail
	Set RentalPrice = @RentalPrice
	where RentalId = @RentalId and 
	FilmId = @FilmId
end