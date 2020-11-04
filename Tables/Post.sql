CREATE TABLE [dbo].[Post]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NULL, 
    [PostText] TEXT NULL, 
    [CreationDate] DATE NULL, 
    CONSTRAINT UserPostFK FOREIGN KEY (UserID) REFERENCES [User]([ID])
)
