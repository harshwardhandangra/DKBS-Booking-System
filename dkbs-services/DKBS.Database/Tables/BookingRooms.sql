CREATE TABLE [dbo].[BookingRooms]
(
	[BookingRoomsId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[TablesetId] INT NOT NULL,
	[LocationAttraction] NVARCHAR(255) NULL,
	[NumberOfRooms] INT NOT NULL,
    [PerPerson] INT NULL, 
	[ToDate] DATETIME NULL,
	[FromDate] DATETIME NULL, 
    
)
