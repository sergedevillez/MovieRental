CREATE PROCEDURE [dbo].[AddCategoryToFilm]
	@FilmId int,
	@CategoryId int
AS
begin
	Insert into FilmCategory ( FilmId, CategoryId)
	Values (@FilmId, @CategoryId)
end
