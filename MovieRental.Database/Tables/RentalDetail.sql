CREATE TABLE [dbo].[RentalDetail]
(
	[RentalId] INT NOT NULL,
	[FilmId] INT NOT NULL,
	[RentalPrice] DECIMAL(5,2) NOT NULL, 
    CONSTRAINT [PK_RentalDetail] PRIMARY KEY ([FilmId], [RentalId]),
	CONSTRAINT [FK_RentalDetail_Rental] FOREIGN KEY ([RentalId])
		REFERENCES [Rental]([RentalId]),
	CONSTRAINT [FK_RentalDetail_Film] FOREIGN KEY ([FilmId])
		REFERENCES [Film]([FilmId])
)

GO

CREATE INDEX [IX_RentalDetail_FilmId] ON [dbo].[RentalDetail] ([FilmId])

GO

CREATE INDEX [IX_RentalDetail_RentalId] ON [dbo].[RentalDetail] ([RentalId])
