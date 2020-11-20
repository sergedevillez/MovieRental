CREATE TABLE [dbo].[Rental]
(
	[RentalId] INT NOT NULL, 
	[RentalDate] DATETIME2(0) NOT NULL
		CONSTRAINT DF_Rental_RentalDate DEFAULT (SYSDATETIME()),
	[CustomerId] INT NOT NULL,
    CONSTRAINT [PK_Rental] PRIMARY KEY ([RentalId]),
	CONSTRAINT [FK_Rental_Customer] FOREIGN KEY ([CustomerId])
		REFERENCES [Customer]([CustomerId])
)

GO

CREATE INDEX [IX_Rental_CustomerId] ON [dbo].[Rental] ([CustomerId])
