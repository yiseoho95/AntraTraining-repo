CREATE TABLE [dbo].[Purchase]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] int NOT NULL,
	[PurchaseNumber] UNIQUEIDENTIFIER NOT NULL,
	[TotalPrice] DECIMAL NOT NULL,
	[PurchaseDateTime] DATETIME2 NOT NULL,
	[MovieId] INT NOT NULL,
    CONSTRAINT [FK_Purchases_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id]), 
    CONSTRAINT [FK_Purchases_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
