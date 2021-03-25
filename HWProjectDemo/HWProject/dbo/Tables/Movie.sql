CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(256) NOT NULL,
	[Overview] NVARCHAR(MAX),
	[Tagline] NVARCHAR(512),
	[Budget] DECIMAL,
	[Revenue] DECIMAL,
	[ImdbUrl] NVARCHAR(2084),
	[TmdbUrl] NVARCHAR(2084),
	[PosterUrl] NVARCHAR(2084),
	[BackdropUrl] NVARCHAR(2084),
	[OriginalLanguage] NVARCHAR(64),
	[ReleaseDate] DATETIME2,
	[RunTime] INT,
	[Price] DECIMAL,
	[CreatedDate] DATETIME2,
	[UpdatedDate] DATETIME2,
	[CreatedBy] NVARCHAR(MAX),
	[UpdatedBy] NVARCHAR(MAX)	
 
)
