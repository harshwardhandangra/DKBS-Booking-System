CREATE TABLE [dbo].[CoursePackageType]
(
	[CoursePackageType_id] INT NOT NULL PRIMARY KEY, 
    [CoursePackageTypeTitle] NVARCHAR(255) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
