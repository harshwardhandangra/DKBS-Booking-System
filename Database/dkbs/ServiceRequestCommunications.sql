CREATE TABLE [dbo].[ServiceRequestCommunications]
(
	[ServiceRequestCommunications_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SRCTitle] NVARCHAR(255) NOT NULL, 
    [Booking_Id] INT NOT NULL, 
    [Communications] NVARCHAR(255) NULL, 
    [FromMyIT] NCHAR(10) NULL, 
    [CopyToCloseRemark] NCHAR(10) NULL,
	[Procedures_Id] INT NOT NULL,
    [IsPartnerSideCommunication] NCHAR(10) NULL, 
    [ProcedureInfoCommunication] NCHAR(10) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Booking_Id1 FOREIGN KEY ([Booking_Id]) REFERENCES Booking([Booking_Id]),
	CONSTRAINT FK_Procedures_Id FOREIGN KEY ([Procedures_Id]) REFERENCES Procedures([Procedures_Id])
)
