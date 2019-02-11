CREATE TABLE [dbo].[TownZipCodes]
(
	[TownZipCode_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ZipPostalCode] NVARCHAR(255) NOT NULL, 
    [FullInfo] NVARCHAR(255) NULL,
	[Land_Id] INT NULL, 
    [TownCityName] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_LandTownZipCodes FOREIGN KEY ([Land_Id]) REFERENCES Lands([Land_Id])
)
