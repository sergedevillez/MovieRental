CREATE TABLE [dbo].[Rating]
(
	[RatingId] INT NOT NULL IDENTITY,
	[Rating] NVARCHAR(5) NOT NULL, 
    CONSTRAINT [PK_Rating] PRIMARY KEY ([RatingId]), 
    CONSTRAINT [UK_Rating_Rating] UNIQUE ([Rating]),
)


