CREATE TABLE [dbo].[BookingReference]
(
	[BookingReferenceId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BookingId] INT NOT NULL,
	[ContactPersonId] INT NOT NULL,
	[CampaignId] INT NOT NULL,
	[Other] NVARCHAR(255) NULL,
	[LeadOfOriginId] INT NOT NULL,    
    
)
