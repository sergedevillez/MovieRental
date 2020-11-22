CREATE PROCEDURE [dbo].[UpdateCategory]
	@CategoryId int,
	@Name nvarchar(25)
AS
begin
	Update Category
	Set Name = @Name
	where CategoryId = @CategoryId
end