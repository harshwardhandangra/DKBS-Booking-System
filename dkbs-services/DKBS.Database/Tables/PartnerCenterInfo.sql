CREATE TABLE [dbo].[PartnerCenterInfo]
(
	[PartnerCenterInfo_Id] INT NOT NULL PRIMARY KEY, 
    [Total Rooms] INT NULL, 
    [Group Rooms] INT NULL, 
    [Max space at row of chairs] NVARCHAR(50) NULL, 
    [Max space at tables] NVARCHAR(50) NULL, 
    [State agreement] BIT NULL, 
    [Max Accommodation] NVARCHAR(50) NULL, 
    [PartnerId] INT NULL,
	CONSTRAINT [FK_PartnerCenterInfo_Partner] FOREIGN KEY ([PartnerId]) REFERENCES [Partner](PartnerId),
)
