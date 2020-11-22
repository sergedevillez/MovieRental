CREATE PROCEDURE [dbo].[AddFilm]
	@Title nvarchar(255), 
	@Description nvarchar(max), 
	@ReleaseYear int, 
	@LanguageId int, 
	@RentalDuration int = 3, 
	@RentalPrice decimal(4,2) = 4.99,
	@Length int, 
	@ReplacementCost decimal(5,2) = 19.99, 
	@RatingId int = 1
AS
begin
	Insert into Film (Title , [Description], ReleaseYear, LanguageId, RentalDuration, RentalPrice,
	[Length], ReplacementCost, [RatingId])
	output inserted.FilmId
	Values (@Title , @Description, @ReleaseYear, @LanguageId, @RentalDuration, @RentalPrice,
	@Length, @ReplacementCost, @RatingId)
end