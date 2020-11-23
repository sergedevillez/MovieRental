CREATE PROCEDURE [dbo].[GetRentalDetail]
	@RentalId int,
	@FilmId int
AS
begin
	SELECT RentalId, FilmId, RentalPrice from RentalDetail
	Where RentalId = @RentalId and
	FilmId = @FilmId
end