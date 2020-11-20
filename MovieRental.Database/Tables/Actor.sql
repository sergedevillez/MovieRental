CREATE TABLE Actor (
  [ActorId] INT NOT NULL IDENTITY,
  [FirstName] NVARCHAR(45) NOT NULL,
  [LastName] NVARCHAR(45) NOT NULL,
  CONSTRAINT PK_Actor PRIMARY KEY ([ActorId])
);
GO

CREATE INDEX [IX_Actor_LastName] ON [dbo].[actor] ([LastName])
