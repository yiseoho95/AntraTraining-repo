CREATE TABLE [dbo].[UserRole]
(
	[UserId] INT NOT NULL,
	[RoleId] INT NOT NULL, 
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id]), 
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId])
	


)
