CREATE PROCEDURE [dbo].[UpdateLanguage]
	@LanguageId int,
	@Name nvarchar(20)
AS
begin
	Update [Language]
	Set [Name] = @Name
end