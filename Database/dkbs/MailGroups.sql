CREATE TABLE [dbo].[MailGroups]
(
	[MailGroupId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MailGroupsTitle] NVARCHAR(255) NULL, 
    [InternalName] NVARCHAR(255) NULL, 
    [IncludeInPartnerEmail] BIT NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NVARCHAR(255) NULL
)
