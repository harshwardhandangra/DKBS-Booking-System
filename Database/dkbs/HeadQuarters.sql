CREATE TABLE [dbo].[HeadQuarters]
(
	[Headquarters_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [HeadquartersTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
