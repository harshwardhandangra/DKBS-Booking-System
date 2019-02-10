CREATE TABLE [dbo].[IndustryCodes]
(
	[IndustryCode_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IndustryCodeTitle] NVARCHAR(255) NOT NULL, 
    [IsNewBranch] BIT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
