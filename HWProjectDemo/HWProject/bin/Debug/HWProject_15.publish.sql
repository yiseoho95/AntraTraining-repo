﻿/*
Deployment script for MovieShop

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MovieShop"
:setvar DefaultFilePrefix "MovieShop"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Cast]...';


GO
CREATE TABLE [dbo].[Cast] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (128)  NULL,
    [Gender]      NVARCHAR (MAX)  NULL,
    [TmdbUrl]     NVARCHAR (MAX)  NULL,
    [ProfilePath] NVARCHAR (2084) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Favorite]...';


GO
CREATE TABLE [dbo].[Favorite] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [MovieId] INT NOT NULL,
    [UserId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Genre]...';


GO
CREATE TABLE [dbo].[Genre] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Movie]...';


GO
CREATE TABLE [dbo].[Movie] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (256)  NULL,
    [Overview]         NVARCHAR (MAX)  NULL,
    [Tagline]          NVARCHAR (512)  NULL,
    [Budget]           DECIMAL (18)    NULL,
    [Revenue]          DECIMAL (18)    NULL,
    [ImdbUrl]          NVARCHAR (2084) NULL,
    [TmdbUrl]          NVARCHAR (2084) NULL,
    [PosterUrl]        NVARCHAR (2084) NULL,
    [BackdropUrl]      NVARCHAR (2084) NULL,
    [OriginalLanguage] NVARCHAR (64)   NULL,
    [ReleaseDate]      DATETIME2 (7)   NULL,
    [RunTime]          INT             NULL,
    [Price]            DECIMAL (18)    NULL,
    [CreatedDate]      DATETIME2 (7)   NULL,
    [UpdatedDate]      DATETIME2 (7)   NULL,
    [CreatedBy]        NVARCHAR (MAX)  NULL,
    [UpdatedBy]        NVARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[MovieCast]...';


GO
CREATE TABLE [dbo].[MovieCast] (
    [MovieId]   INT            NOT NULL,
    [CastId]    INT            NOT NULL,
    [Character] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_MovieCast] PRIMARY KEY CLUSTERED ([Character] ASC, [CastId] ASC, [MovieId] ASC)
);


GO
PRINT N'Creating [dbo].[MovieGenre]...';


GO
CREATE TABLE [dbo].[MovieGenre] (
    [MovieId] INT NOT NULL,
    [GenreId] INT NOT NULL,
    CONSTRAINT [PK_MovieGenre] PRIMARY KEY CLUSTERED ([MovieId] ASC, [GenreId] ASC)
);


GO
PRINT N'Creating [dbo].[Purchase]...';


GO
CREATE TABLE [dbo].[Purchase] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [UserId]           INT              NOT NULL,
    [PurchaseNumber]   UNIQUEIDENTIFIER NOT NULL,
    [TotalPrice]       DECIMAL (18)     NOT NULL,
    [PurchaseDateTime] DATETIME2 (7)    NOT NULL,
    [MovieId]          INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Review]...';


GO
CREATE TABLE [dbo].[Review] (
    [MovieId]    INT            NOT NULL,
    [UserId]     INT            NOT NULL,
    [Rating]     DECIMAL (3, 2) NOT NULL,
    [ReviewText] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([MovieId] ASC, [UserId] ASC)
);


GO
PRINT N'Creating [dbo].[Role]...';


GO
CREATE TABLE [dbo].[Role] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (20)  NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Trailer]...';


GO
CREATE TABLE [dbo].[Trailer] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [MovieId]    INT             NOT NULL,
    [TrailerUrl] NVARCHAR (2084) NULL,
    [Name]       NVARCHAR (2084) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [Id]                   INT                IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NULL,
    [HashedPassword]       NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NULL,
    [TwoFactorEnabled]     BIT                NULL,
    [LockoutEndDate]       DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NULL,
    [AccessFailedCount]    INT                NULL,
    [FirstName]            NVARCHAR (128)     NULL,
    [LastName]             NVARCHAR (128)     NULL,
    [DateOfBirth]          DATETIME           NULL,
    [Salt]                 NVARCHAR (128)     NOT NULL,
    [IsLocked]             INT                NOT NULL,
    [LastLogInDateTime]    DATETIME           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[UserRole]...';


GO
CREATE TABLE [dbo].[UserRole] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Favorite_User]...';


GO
ALTER TABLE [dbo].[Favorite]
    ADD CONSTRAINT [FK_Favorite_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Favorite_Movie]...';


GO
ALTER TABLE [dbo].[Favorite]
    ADD CONSTRAINT [FK_Favorite_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Creating [dbo].[FK_MovieCast_Movie]...';


GO
ALTER TABLE [dbo].[MovieCast]
    ADD CONSTRAINT [FK_MovieCast_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Creating [dbo].[FK_MovieCast_Cast]...';


GO
ALTER TABLE [dbo].[MovieCast]
    ADD CONSTRAINT [FK_MovieCast_Cast] FOREIGN KEY ([CastId]) REFERENCES [dbo].[Cast] ([Id]);


GO
PRINT N'Creating [dbo].[FK_GenreMovies_Movie]...';


GO
ALTER TABLE [dbo].[MovieGenre]
    ADD CONSTRAINT [FK_GenreMovies_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Creating [dbo].[FK_GenreMovies_Genre]...';


GO
ALTER TABLE [dbo].[MovieGenre]
    ADD CONSTRAINT [FK_GenreMovies_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Purchases_Movie]...';


GO
ALTER TABLE [dbo].[Purchase]
    ADD CONSTRAINT [FK_Purchases_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Purchases_User]...';


GO
ALTER TABLE [dbo].[Purchase]
    ADD CONSTRAINT [FK_Purchases_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Review_Movie]...';


GO
ALTER TABLE [dbo].[Review]
    ADD CONSTRAINT [FK_Review_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Review_User]...';


GO
ALTER TABLE [dbo].[Review]
    ADD CONSTRAINT [FK_Review_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Trailer_Movie]...';


GO
ALTER TABLE [dbo].[Trailer]
    ADD CONSTRAINT [FK_Trailer_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserRole_User]...';


GO
ALTER TABLE [dbo].[UserRole]
    ADD CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserRole_Role]...';


GO
ALTER TABLE [dbo].[UserRole]
    ADD CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'eccfee78-d79f-440b-9346-7c6fa227afa0')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('eccfee78-d79f-440b-9346-7c6fa227afa0')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
