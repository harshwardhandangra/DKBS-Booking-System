CREATE TABLE [dbo].[BookingAndIncidentStatuses]
(
	[BookingAndIncidentStatuses_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookingerIncidentTitle] NVARCHAR(255) NOT NULL, 
    [SLACount] BIT NULL, 
    [ClosedStatus] BIT NULL, 
    [Position] INT NULL, 
    [UsedIn] INT NULL, 
    [InformUserByEmail] NCHAR(10) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NCHAR(10) NOT NULL
)
