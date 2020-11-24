CREATE PROCEDURE [dbo].[GetFilmByKeyword]
	@Keyword nvarchar
AS
begin
	select * 
	from Film
	where Film.Description Like '%' + @Keyword + '%'
end