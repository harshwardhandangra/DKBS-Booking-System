﻿CREATE TABLE [dbo].[PartnerEmployee]
(
	[PartnerEmployeeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [EmployeeName] NVARCHAR(255) NOT NULL,
	[JobTitle] NVARCHAR(255) NOT NULL,
	[TelePhoneNumber] NVARCHAR(255) NOT NULL,
	[Email] NVARCHAR(255) NOT NULL,
    [PartnerId] INT NOT NULL,
	[MailGroupId] INT NOT NULL,		 
	[PartnerTypeId] INT NOT NULL,
	[ParticipantTypeId] INT NOT NULL,
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_PartnerEmployee_Partner] FOREIGN KEY (PartnerId) REFERENCES Partner(PartnerId), 
    CONSTRAINT [FK_PartnerEmployee_MailGroup] FOREIGN KEY (MailGroupId) REFERENCES MailGroup(MailGroupId), 
    CONSTRAINT [FK_PartnerEmployee_PartnerType] FOREIGN KEY (PartnerTypeId) REFERENCES PartnerType(PartnerTypeId), 
    CONSTRAINT [FK_PartnerEmployee_ParticipantType] FOREIGN KEY ([ParticipantTypeId]) REFERENCES ParticipantType(ParticipantTypeId) 
)
