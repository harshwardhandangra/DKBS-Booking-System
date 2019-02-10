CREATE TABLE [dbo].[MailGroups]
(
	[MailGroup_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MailGroupsTitle] NVARCHAR(255) NOT NULL, 
    [InternalName] NVARCHAR(255) NULL, 
    [IncludeInPartnerEmail] BIT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
