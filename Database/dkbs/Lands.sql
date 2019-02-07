CREATE TABLE [dbo].[Lands]
(
	[LandId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LandTitle] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NVARCHAR(255) NULL
)
