CREATE PROCEDURE [dbo].[GetAllLanguage]
AS
begin
	Select LanguageId, [Name] from [Language]
end