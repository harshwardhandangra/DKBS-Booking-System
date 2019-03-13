CREATE TABLE [dbo].[TableSets]
(
	[TableSetId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TableSetName] NVARCHAR(100) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(100) NULL
)
