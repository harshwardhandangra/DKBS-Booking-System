CREATE TABLE [dbo].[Discussionforum]
(
	[Discussionforum_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DiscussionforumSubject] NVARCHAR(255) NOT NULL, 
    [DiscussionForumBody] NVARCHAR(255) NULL, 
	[MailGroup_Id] INT NULL,
	[Partner_Id] INT NULL,
	[PartnerType_Id] INT NULL,
    [Question] NCHAR(10) NULL, 
    [PartnerItemEditor] NVARCHAR(255) NULL, 
    [LastReplyBy] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_MailGroup_Id FOREIGN KEY ([MailGroup_Id]) REFERENCES MailGroups([MailGroup_Id]),
	CONSTRAINT FK_Partner_Id FOREIGN KEY ([Partner_Id]) REFERENCES Partners([Partners_Id]),
	CONSTRAINT FK_PartnerType_Id FOREIGN KEY ([PartnerType_Id]) REFERENCES PartnerType([PartnerType_Id]),
	)
