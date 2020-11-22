CREATE PROCEDURE [dbo].[UpdateFilm]
	@FilmId int,
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
	Update Film set 
	Title = @Title, 
	[Description] = @Description, 
	ReleaseYear = @ReleaseYear, 
	LanguageId = @LanguageId, 
	RentalDuration = @RentalDuration, 
	RentalPrice = @RentalPrice,
	[Length] = @Length, 
	ReplacementCost = @ReplacementCost, 
	[RatingId] = @RatingId
end