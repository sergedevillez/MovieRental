CREATE TABLE [dbo].[Customer]
(
	[CustomerId] INT NOT NULL IDENTITY,
	[LastName] NVARCHAR(75) NOT NULL,
	[FirstName] NVARCHAR(75) NOT NULL,
	[Email] NVARCHAR(320) NOT NULL,
	[Passwd] BINARY(64) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerId]),
	CONSTRAINT [UK_Customer_Email] UNIQUE ([Email])
)
