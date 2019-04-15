CREATE TABLE [dbo].[BookingArrangementTypes]
(
	[BookingArrangementTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[ServiceCatalogueId] INT NOT NULL,
	[NumberOfParticipants] INT NOT NULL,
    [ToDate] DATETIME NULL,
	[FromDate] DATETIME NULL, 
    
)
