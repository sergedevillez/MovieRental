CREATE PROCEDURE [dbo].[MVSP_RegisterCustomer]
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(320),
	@Passwd VARCHAR(20)
AS
BEGIN
	INSERT INTO [Customer] (LastName, FirstName, Email, Passwd) VALUES (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.MVSF_GetPreHash() + @Passwd + dbo.MVSF_GetPostHash()));
END
