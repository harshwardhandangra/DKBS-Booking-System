CREATE TABLE [dbo].[ServiceCatalog]
(
	[ServiceCatalog_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CoursePackage] NVARCHAR(255) NULL, 
    [Offered] BIT NULL,
	[Price] DECIMAL(18, 2) NULL,
	[CoursepackageType_ID] INT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
	CONSTRAINT FK_CoursepackageType_ID FOREIGN KEY ([CoursepackageType_ID]) REFERENCES CoursepackageType([CoursepackageType_ID]),
)
