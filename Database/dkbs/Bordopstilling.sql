CREATE TABLE [dbo].[Bordopstilling]
(
	[Bordopstilling_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BordopstillingTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
