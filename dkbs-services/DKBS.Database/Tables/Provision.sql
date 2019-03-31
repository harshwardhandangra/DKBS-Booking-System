CREATE TABLE [dbo].[Provision]
(
	[ProvisionId] INT NOT NULL PRIMARY KEY,   
    [PartnersId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [BookingId] INT NOT NULL,     
    [Price] DECIMAL(19, 4) NULL,     
    [LastModified] NVARCHAR(255) NOT NULL, 
    [LastModifiedBy] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Partners_Id1 FOREIGN KEY ([PartnersId]) REFERENCES Partners([PartnerId]),
	CONSTRAINT FK_Booking_Id2 FOREIGN KEY ([BookingId]) REFERENCES Booking([BookingId]),
)
