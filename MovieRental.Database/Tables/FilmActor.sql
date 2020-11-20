CREATE TABLE [FilmActor](
  [ActorId] INT NOT NULL,
  [FilmId] INT NOT NULL,
  CONSTRAINT PK_FilmActor PRIMARY KEY ([ActorId], [FilmId]),
  CONSTRAINT [FK_FilmActor_Actor]FOREIGN KEY ([ActorId]) REFERENCES [Actor]([ActorId]),
  CONSTRAINT [FK_FilmActor_Film]FOREIGN KEY ([FilmId]) REFERENCES [Film]([FilmId])
)

GO

CREATE INDEX [IX_FilmActor_ActorId] ON [dbo].[FilmActor] ([ActorId])

GO

CREATE INDEX [IX_FilmActor_FilmId] ON [dbo].[FilmActor] ([FilmId])
