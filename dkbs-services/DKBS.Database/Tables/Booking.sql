CREATE TABLE [dbo].[Booking]
(
	[BookingId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PartnerId] INT NOT NULL,
	[CustomerId] INT NOT NULL,		 
	[TableTypeId] INT NOT NULL,	
	[CancellationReasonId] INT NOT NULL,
	[CauseOfRemovalId] INT NOT NULL,
	[ContactPersonId] INT NOT NULL,
	[BookinAndStatusId] INT NOT NULL,
	[FlowId] INT NOT NULL,
	[MailLanguageId] INT NOT NULL,
	[PartnerTypeId] INT NOT NULL,
	[ParticipentTypeId] INT NOT NULL,
	[PurposeId] INT NOT NULL,
	[OriginId] INT NOT NULL,
	[CampaignId] INT NOT NULL,
	[ArrivalDateTime] DateTime NULL, 
	[DepartDateTime] DateTime NULL, 
	[FlexibleDates] Bit NULL, 
	[InternalHistory] NVARCHAR(MAX) NULL,
	

)
