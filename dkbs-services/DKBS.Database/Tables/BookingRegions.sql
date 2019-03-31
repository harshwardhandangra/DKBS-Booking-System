CREATE TABLE [dbo].[BookingRegions]
(
	[BookingRegionsId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[RegionId] INT NOT NULL
)
