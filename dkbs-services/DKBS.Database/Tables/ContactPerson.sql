CREATE TABLE [dbo].[ContactPerson]
(
	[ContactPersonId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Position] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Telephone] [nvarchar](50) NULL,
	[CustomerId] [int] NULL,
	[MapId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime] NULL,
	[LastModifiedBy] [nvarchar](100) NULL
)
