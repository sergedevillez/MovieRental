CREATE PROCEDURE [dbo].[GetAllRating]
AS
begin
	SELECT RatingId, Rating from Rating
end