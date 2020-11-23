CREATE PROCEDURE [dbo].[AddLanguage]
	@Name nvarchar(20)
AS
begin
	Insert into [Language] ([Name])
	output inserted.LanguageId
	Values (@Name)
end