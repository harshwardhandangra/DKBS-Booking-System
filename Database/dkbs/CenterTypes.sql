CREATE TABLE [dbo].[CenterTypes]
(
	[CenterType_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CenterTypeTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
