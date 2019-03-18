CREATE TABLE [dbo].[CauseOfRemovals]
(
	[CauseOfRemovalId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CauseOfRemovalTitle] NCHAR(10) NULL,
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
	[LastModified] DATETIME NULL, 
	[LastModifiedBy] NVARCHAR(100) NULL
)
