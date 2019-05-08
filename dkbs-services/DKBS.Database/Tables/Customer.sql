CREATE TABLE [dbo].[Customer]
(
	[CustomerId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NOT NULL,
	[Address1] [nvarchar](255) NOT NULL,
	[Address2] [nvarchar](255) NOT NULL,
	[Town] [nvarchar](200) NOT NULL,
	[PostCode] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](255) NOT NULL,
	[Country] [nvarchar](200) NOT NULL,
	[StateAgreement] BIT NOT NULL,
	[AccountId] NVARCHAR(255) NOT NULL,
	[IndustryCode] NVARCHAR(1000) NOT NULL
)
