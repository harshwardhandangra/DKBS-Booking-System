CREATE TABLE [dbo].[Provision]
(
	[Provision_Id] INT NOT NULL PRIMARY KEY, 
    [RecommendedDate] DATETIME NULL, 
    [ArrivalDate] DATETIME NULL, 
    [Partners_Id] INT NOT NULL, 
    [DateOfShipment] DATETIME NULL, 
    [Debtor] INT NULL, 
    [Customers_Id] INT NOT NULL, 
    [Booking_Id] INT NOT NULL, 
    [ModifiedDate] NVARCHAR(255) NOT NULL, 
    [Price] DECIMAL(19, 4) NULL, 
    [Title (is 2 times)] NVARCHAR(255) NULL, 
    [UnitId] INT NULL, 
    [ModifiedBy] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Partners_Id1 FOREIGN KEY ([Partners_Id]) REFERENCES Partners([Partners_Id]),
	CONSTRAINT FK_Booking_Id2 FOREIGN KEY ([Booking_Id]) REFERENCES Booking([Booking_Id]),
)
