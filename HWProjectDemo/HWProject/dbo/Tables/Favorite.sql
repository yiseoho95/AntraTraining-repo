CREATE TABLE [dbo].[Favorite]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[MovieId] INT NOT NULL,
	[UserId] INT NOT NULL, 
    CONSTRAINT [FK_Favorite_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Favorite_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id])



)
