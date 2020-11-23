CREATE PROCEDURE [dbo].[GetAllRentalDetail]
AS
begin
	SELECT RentalId, FilmId, RentalPrice from RentalDetail
end