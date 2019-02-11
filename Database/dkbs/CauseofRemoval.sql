CREATE TABLE [dbo].[CauseofRemoval]
(
	[CauseofRemoval_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CauseofRemovalTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
