CREATE TABLE [dbo].[CRMStatuses]
(
	[CRMStatusId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CRMStatusTitle] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NVARCHAR(255) NULL
)
