﻿CREATE TABLE [dbo].[TableSet]
(
	[TableSetId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TableSetName] NVARCHAR(100) NULL, 
	[CreatedDate] DATETIME NULL,
	[CreatedBy] nvarchar(100),
    [LastModified] DATETIME NULL, 
    [LastModifiedBy] NVARCHAR(100) NULL
)
