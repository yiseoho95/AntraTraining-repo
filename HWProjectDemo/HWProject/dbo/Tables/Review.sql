CREATE TABLE [dbo].[Review]
(
	[MovieId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[Rating] DECIMAL(3,2) NOT NULL,
	[ReviewText] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Review_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id]), 
    CONSTRAINT [FK_Review_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [PK_Review] PRIMARY KEY ([MovieId], [UserId])

)
