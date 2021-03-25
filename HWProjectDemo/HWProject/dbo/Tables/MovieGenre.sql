CREATE TABLE [dbo].[MovieGenre]
(
	[MovieId] int not null,
	[GenreId] int not null,
    CONSTRAINT [FK_GenreMovies_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id]),
    CONSTRAINT [FK_GenreMovies_Genre] FOREIGN KEY ([GenreId]) REFERENCES [Genre]([Id]), 
    CONSTRAINT [PK_MovieGenre] PRIMARY KEY ([MovieId], [GenreId])

)
