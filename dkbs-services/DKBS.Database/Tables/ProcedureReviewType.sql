CREATE TABLE [dbo].[ProcedureReviewType]
(
	[ProcedureReviewTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProcedureReviewTypeTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
