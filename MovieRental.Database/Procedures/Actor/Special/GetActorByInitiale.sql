CREATE PROCEDURE [dbo].[GetActorByInitiale]
    @LastNameInitial char,
    @FirstNameInitial char
AS
BEGIN
	SELECT*FROM Actor
	WHERE LastName like @LastNameInitial + '%' and FirstName Like @FirstNameInitial + '%'
END