CREATE TABLE [dbo].[MovieCast]
(
	[MovieId] INT NOT NULL,
	[CastId] INT NOT NULL,
	[Character] NVARCHAR(450) NOT NULL, 
    CONSTRAINT [FK_MovieCast_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id]), 
    CONSTRAINT [FK_MovieCast_Cast] FOREIGN KEY ([CastId]) REFERENCES [Cast]([Id]), 
    PRIMARY KEY ([MovieId], [CastId], [Character])
   
)
