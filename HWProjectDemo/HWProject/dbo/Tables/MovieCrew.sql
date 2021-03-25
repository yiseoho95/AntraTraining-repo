CREATE TABLE [dbo].[MovieCrew]
(
	[MovieId] INT NOT NULL,
	[CrewId] INT NOT NULL,
	[Department] NVARCHAR(128) NOT NULL,
	[Job] NVARCHAR(128) NOT NULL, 

    CONSTRAINT [PK_MovieCrew] PRIMARY KEY ([MovieId], [CrewId], [Department], [Job]), 
    CONSTRAINT [FK_MovieCrew_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([Id]), 
    CONSTRAINT [FK_MovieCrew_Crew] FOREIGN KEY ([CrewId]) REFERENCES [Crew]([Id])

)
