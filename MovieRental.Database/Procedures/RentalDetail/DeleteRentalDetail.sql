CREATE PROCEDURE [dbo].[DeleteRentalDetail]
	@RentalId int,
	@FilmId int
AS
begin
	Delete from RentalDetail 
	Where RentalId = @RentalId and
	FilmId = @FilmId
end