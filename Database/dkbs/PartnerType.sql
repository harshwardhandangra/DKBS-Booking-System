CREATE TABLE [dbo].[PartnerType]
(
	[PartnerType_Id] INT NOT NULL PRIMARY KEY, 
    [PartnerTypeTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
