CREATE TABLE [dbo].[PartnerEmployee]
(
	[PartnerEmployeeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [EmployeeName] NVARCHAR(255) NOT NULL,
	[JobTitle] NVARCHAR(255) NOT NULL,
	[TelePhoneNumber] NVARCHAR(255) NOT NULL,
	[Email] NVARCHAR(255) NOT NULL,
    [PartnerId] INT NOT NULL,
	[MailGroupId] INT NOT NULL,		 
	[PartnerTypeId] INT NOT NULL,
	[ParticipentTypeId] INT NOT NULL,
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
