CREATE PROCEDURE [dbo].[AddCategory]
	@Name nvarchar(25)
AS
begin
	Insert into Category ([Name])
	output inserted.CategoryId
	Values (@Name)
end