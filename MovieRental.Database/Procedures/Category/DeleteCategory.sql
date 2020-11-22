CREATE PROCEDURE [dbo].[DeleteCategory]
	@CategoryId int
AS
begin
	Delete from Category 
	where CategoryId = @CategoryId
end