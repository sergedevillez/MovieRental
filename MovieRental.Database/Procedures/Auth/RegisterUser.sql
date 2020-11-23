CREATE PROCEDURE [dbo].[RegisterUser]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email Nvarchar(320),
	@Passwd Nvarchar(20)
AS
begin
	insert into Customer (FirstName, LastName, Email, [Passwd]) 
	values (@FirstName, @LastName, @Email, HASHBYTES('SHA2_512', dbo.MVSF_GetPreHash() + @Passwd + dbo.MVSF_GetPostHash()))
end