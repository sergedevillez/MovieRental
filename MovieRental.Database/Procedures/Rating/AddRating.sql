CREATE PROCEDURE [dbo].[AddRating]
	@Rating nvarchar(5)
AS
begin
	Insert into Rating (Rating)
	output inserted.RatingId
	Values (@Rating)
end