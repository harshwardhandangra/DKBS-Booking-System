CREATE TABLE [dbo].[Employee]
(
	[Employee_Id] INT NOT NULL PRIMARY KEY, 
    [EmpTitle] NCHAR(10) NULL, 
    [EmpName] NCHAR(10) NULL, 
    [JobTitle] NCHAR(10) NULL, 
    [TelephoneNumber] NCHAR(10) NULL, 
    [Email] NCHAR(10) NULL, 
    [PartnerName] NCHAR(10) NULL, 
    [MailGroupsId] NCHAR(10) NULL, 
    [Identifier] NCHAR(10) NULL, 
    [DeactivateUser] NCHAR(10) NULL, 
    [PartnertypeId] NCHAR(10) NULL, 
    [PartnerLookupField] NCHAR(10) NULL, 
    [FbaUserCredentials] NCHAR(10) NULL, 
    [SModifiedBy] NCHAR(10) NULL, 
    [SModified] NCHAR(10) NULL, 
    [LastModified] NCHAR(10) NULL, 
    [LastModifiedBY] NCHAR(10) NULL
)
