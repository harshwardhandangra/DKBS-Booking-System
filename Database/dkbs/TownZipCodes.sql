CREATE TABLE [dbo].[TownZipCodes]
(
	[TownZipCodeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ZipPostalCode] NVARCHAR(255) NULL, 
    [FullInfo] NVARCHAR(255) NULL, 
    [LandId] INT NULL, 
    [TownCityName] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NULL, 
    [LastModifiedBY] NVARCHAR(255) NULL,
	CONSTRAINT FK_LandTownZipCodes FOREIGN KEY ([LandId]) REFERENCES Lands([LandId])
)
