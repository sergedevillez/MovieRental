CREATE PROCEDURE [dbo].[AddRentalDetail]
	@RentalId int,
	@FilmId int,
	@RentalPrice decimal(5,2)
AS
begin
	Insert into RentalDetail (RentalId, FilmId, RentalPrice)
	values (@RentalId, @FilmId, @RentalPrice)
end