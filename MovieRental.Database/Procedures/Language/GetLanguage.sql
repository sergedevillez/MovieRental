CREATE PROCEDURE [dbo].[GetLanguage]
	@LanguageId int
AS
begin
	SELECT LanguageId, [Name] from [Language]
	where LanguageId = @LanguageId
end