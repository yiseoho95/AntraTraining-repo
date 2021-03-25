CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserName] NVARCHAR(256) NULL,
	[NormalizedUserName] NVARCHAR(256) NULL,
	[Email] NVARCHAR(256) NULL,
	[NormalizedEmail] NVARCHAR(256) NULL,
	[EmailConfirmed] BIT NULL,
	[HashedPassword] NVARCHAR(MAX) NULL,
	[SecurityStamp] NVARCHAR(MAX) NULL,
	[ConcurrencyStamp] NVARCHAR(MAX) NULL,
	[PhoneNumber] NVARCHAR(MAX) NULL,
	[PhoneNumberConfirmed] BIT NULL,
	[TwoFactorEnabled] BIT NULL,
	[LockoutEndDate] DATETIMEOFFSET NULL,
	[LockoutEnabled] BIT NULL,
	[AccessFailedCount] INT NULL,
	[FirstName] NVARCHAR(128) NULL,
	[LastName] NVARCHAR(128) NULL,
	[DateOfBirth] DATETIME NULL,
	[Salt] NVARCHAR(128) NOT NULL,
	[IsLocked] INT NOT NULL,
	[LastLogInDateTime] DATETIME NULL

)
