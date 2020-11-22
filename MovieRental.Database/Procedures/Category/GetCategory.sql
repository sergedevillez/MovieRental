CREATE PROCEDURE [dbo].[GetCategory]
	@CategoryId int
AS
begin
	SELECT @CategoryId, Name from Category
	where CategoryId = @CategoryId
end