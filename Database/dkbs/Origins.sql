CREATE TABLE [dbo].[Origins]
(
	[Origins_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OriginsTitle] NVARCHAR(255) NOT NULL, 
	[Position] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
