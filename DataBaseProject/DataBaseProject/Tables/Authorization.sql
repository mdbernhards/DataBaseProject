CREATE TABLE [dbo].[Authorization]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Password] NCHAR(10) NULL, 
    [UserID] INT NOT NULL, 
    CONSTRAINT UserAuthorizationFK FOREIGN KEY (UserID) REFERENCES [User]([ID])
)
