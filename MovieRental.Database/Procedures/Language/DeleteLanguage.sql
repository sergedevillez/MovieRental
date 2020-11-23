CREATE PROCEDURE [dbo].[DeleteLanguage]
	@LanguageId int
AS
begin
	Delete from [Language]
	where LanguageId = @LanguageId
end