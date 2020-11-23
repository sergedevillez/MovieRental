CREATE PROCEDURE [dbo].[UpdateRating]
	@RatingId int,
	@Rating nvarchar(5)
AS
begin
	Update Rating
	Set Rating = @Rating
end
