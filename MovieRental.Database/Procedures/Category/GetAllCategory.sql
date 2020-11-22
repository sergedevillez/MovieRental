CREATE PROCEDURE [dbo].[GetAllCategory]
AS
begin
	SELECT CategoryId, [Name] from Category
end