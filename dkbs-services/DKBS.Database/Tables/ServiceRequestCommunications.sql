CREATE TABLE [dbo].[ServiceRequestCommunications]
(
	[ServiceRequestCommunicationsId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SRCTitle] NVARCHAR(255) NOT NULL, 
    [BookingId] INT NOT NULL, 
    [Communications] NVARCHAR(255) NULL, 
    [FromMyIT] NCHAR(10) NULL, 
    [CopyToCloseRemark] NCHAR(10) NULL,
	[ProceduresId] INT NOT NULL,
    [IsPartnerSideCommunication] NCHAR(10) NULL, 
    [ProcedureInfoCommunication] NCHAR(10) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Booking_Id1 FOREIGN KEY ([BookingId]) REFERENCES Booking([BookingId]),
	CONSTRAINT FK_Procedures_Id FOREIGN KEY ([ProceduresId]) REFERENCES Procedures([ProceduresId])
)
