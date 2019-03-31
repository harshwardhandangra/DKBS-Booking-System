CREATE TABLE [dbo].[Procedures]
(
	[ProceduresId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProceduresName] VARCHAR(255) NOT NULL, 
    [BookingId] INT NOT NULL,
	[PartnerId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CauseOfRemovalId] INT NOT NULL,
	[ProcedureReviewTypeId] INT NOT NULL,
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL
)
