CREATE TABLE [dbo].[SRConversationItems]
(
	[SRConversationItems_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SRConversationTitle] NVARCHAR(255) NOT NULL, 
    [ConversationMessage] NVARCHAR(255) NULL, 
    [Sender] NVARCHAR(255) NOT NULL, 
    [CcAddress] NVARCHAR(255) NULL,
	[Booking_Id] INT NOT NULL,
    [ConversationMessageId] NVARCHAR(255) NULL, 
    [Reciever] NVARCHAR(255) NULL, 
    [LastModified] DATETIME NOT NULL, 
    [LastModifiedBY] NCHAR(10) NOT NULL,
	CONSTRAINT FK_Booking_Id FOREIGN KEY ([Booking_Id]) REFERENCES Booking([Booking_Id])
)
