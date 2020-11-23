CREATE PROCEDURE [dbo].[GetRating]
	@RatingId int
AS
begin
	SELECT RatingId, Rating from Rating
	where RatingId = @RatingId
end