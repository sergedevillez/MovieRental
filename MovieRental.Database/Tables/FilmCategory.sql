CREATE TABLE [FilmCategory](
  [FilmId] INT NOT NULL,
  [CategoryId] INT NOT NULL,
  CONSTRAINT PK_FilmCategory PRIMARY KEY ([FilmId], [CategoryId]),
  CONSTRAINT [FK_FilmCategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId]),
  CONSTRAINT [FK_FilmCategory_Film] FOREIGN KEY ([FilmId]) REFERENCES [Film]([FilmId])
) 

GO

CREATE INDEX [IX_FilmCategory_FilmId] ON [dbo].[FilmCategory] ([FilmId])

GO

CREATE INDEX [IX_FilmCategory_CategoryId] ON [dbo].[FilmCategory] ([CategoryId])
