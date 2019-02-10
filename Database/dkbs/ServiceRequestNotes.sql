CREATE TABLE [dbo].[ServiceRequestNotes]
(
	[ServiceRequestNotes_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SRNotesTitle] NCHAR(10) NULL, 
    [SRNotesTitle] NCHAR(10) NULL, 
    [Action] NCHAR(10) NULL, 
    [PlannedStart] NCHAR(10) NULL, 
    [CloseField] NCHAR(10) NULL, 
    [Notify] NCHAR(10) NULL, 
    [PlannedEnd] NCHAR(10) NULL, 
    [CopyToCloseRemark] NCHAR(10) NULL, 
    [ScheduleAction] NCHAR(10) NULL, 
    [LastModified] NCHAR(10) NULL, 
    [LastModifiedBY] NCHAR(10) NULL
)
