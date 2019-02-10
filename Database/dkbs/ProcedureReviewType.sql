CREATE TABLE [dbo].[ProcedureReviewType]
(
	[ProcedureReviewType_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProcedureReviewTypeTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
