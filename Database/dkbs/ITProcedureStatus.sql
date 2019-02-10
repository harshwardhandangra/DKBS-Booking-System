CREATE TABLE [dbo].[ITProcedureStatus]
(
	[ITProcedureStatus_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ITProcedureStatusTitle] NVARCHAR(255) NOT NULL, 
    [InternalName] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
