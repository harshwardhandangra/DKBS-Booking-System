CREATE TABLE [dbo].[Nyheder]
(
	[Nyheder_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NewsTitle] NVARCHAR(255) NOT NULL, 
    [Partners_Id] INT NOT NULL, 
    [PublishAnnouncement] BIT NULL, 
    [ExpirationDate] DATETIME NULL, 
    [Publish] NCHAR(10) NULL, 
    [NewsPublic] BIT NOT NULL, 
    [NewsDescription] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Partners_Id FOREIGN KEY ([Partners_Id]) REFERENCES Partners([Partners_Id]),
)
