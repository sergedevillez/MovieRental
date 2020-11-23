CREATE PROCEDURE [dbo].[CheckUser]
	@Email Nvarchar(320),
	@Passwd Nvarchar(20)
AS
begin
select CustomerId, FirstName, LastName, Email from Customer 
where [Passwd] = HASHBYTES('SHA2_512', dbo.MVSF_GetPreHash() + @Passwd + dbo.MVSF_GetPostHash()) and
Email = @Email
end