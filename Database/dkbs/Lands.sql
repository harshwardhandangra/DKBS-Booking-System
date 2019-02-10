CREATE TABLE [dbo].[Lands]
(
	[Land_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LandTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
