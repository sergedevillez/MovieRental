CREATE TABLE [Film](
  [FilmId] int NOT NULL IDENTITY,
  [Title] NVARCHAR(255) NOT NULL,
  [Description] NVARCHAR(MAX) NULL,
  [ReleaseYear] INT NULL,
  [LanguageId] INT NOT NULL,
  [RentalDuration] INT NOT NULL
	CONSTRAINT DF_Film_RentalDuration DEFAULT (3),
  [RentalPrice] DECIMAL(4,2) NOT NULL 
	CONSTRAINT DF_Film_RentalRate DEFAULT (4.99),
  [Length] INT NULL,
  [ReplacementCost] DECIMAL(5,2) NOT NULL 
	CONSTRAINT DF_Film_ReplacementCost DEFAULT (19.99),
  [RatingId] INT NOT NULL 
	CONSTRAINT DF_Film_RatingId Default (1),
  CONSTRAINT PK_Film PRIMARY KEY ([FilmId]),
  CONSTRAINT [FK_Film_Language] FOREIGN KEY ([LanguageId]) REFERENCES [Language]([LanguageId]),
  CONSTRAINT [FK_Film_Rating] FOREIGN KEY ([RatingId]) REFERENCES [Rating]([RatingId])
)

GO

CREATE INDEX [IX_Film_Title] ON [dbo].[Film] ([Title])

GO

CREATE INDEX [IX_Film_LanguageId] ON [dbo].[Film] ([LanguageId])
