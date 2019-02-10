CREATE TABLE [dbo].[CoursePackage]
(
	[CoursePackage_Id] INT NOT NULL PRIMARY KEY, 
    [CoursePackageTitle] NVARCHAR(255) NULL, 
    [CoursePackage(English)] NVARCHAR(255) NULL, 
    [Offered] BIGINT NULL, 
	[Price] DECIMAL(18, 2) NULL,
    [CoursepackageID] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
