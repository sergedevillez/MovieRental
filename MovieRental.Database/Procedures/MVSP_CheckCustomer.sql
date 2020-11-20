CREATE PROCEDURE [dbo].[MVSP_CheckCustomer]
	@Email NVARCHAR(320),
	@Passwd VARCHAR(20)
AS
BEGIN
	SELECT [CustomerId], [LastName], [FirstName], [Email] FROM [Customer] WHERE [Email] = @Email and PAsswd = HASHBYTES('SHA2_512', dbo.MVSF_GetPreHash() + @Passwd + dbo.MVSF_GetPostHash());
END
