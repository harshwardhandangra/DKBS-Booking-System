CREATE TABLE [dbo].[CenterTypes]
(
	[CenterTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CenterTypeTitle] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NVARCHAR(255) NULL
)
