CREATE PROCEDURE [dbo].[GetAllCustomer]
AS
begin
	SELECT FirstName, LastName, Email, Passwd from Customer
end