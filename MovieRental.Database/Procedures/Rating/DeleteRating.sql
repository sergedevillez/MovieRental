CREATE PROCEDURE [dbo].[DeleteRating]
	@RatingId int
AS
begin
	Delete From Rating
	where RatingId = @RatingId
end