CREATE TABLE [dbo].[IndustryCodes]
(
	[IndustryCodeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IndustryCodeTitle] NVARCHAR(255) NULL, 
    [IsNewBranch] BIT NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NVARCHAR(255) NULL
)
