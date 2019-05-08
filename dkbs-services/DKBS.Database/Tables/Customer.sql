CREATE TABLE [dbo].[Customer]
(
	[CustomerId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NULL,
	[EmailId] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[IndustryCode] [nvarchar](1000) NULL,
	[ZipCode] [nvarchar](100) NULL,
	[Country] [nvarchar](200) NULL,
	[City] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[LastModifiedBY] [nvarchar](255) NOT NULL,
	[MapId] [int] NULL
)
