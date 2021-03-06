﻿CREATE TABLE [dbo].[Booking]
(
	[Booking_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookingInfo] NVARCHAR(255) NULL, 
    [ProcedureInfo] NCHAR(255) NULL, 
    [CauseOFRemovalId] NCHAR(255) NULL, 
    [Comments] NCHAR(255) NULL, 
    [ParkedUntilDate] NCHAR(255) NULL, 
    [Description] NCHAR(255) NULL, 
    [InternalHistory] NCHAR(255) NULL, 
    [ClosingDate] NCHAR(255) NULL, 
    [AdditionalSeriesText] NCHAR(255) NULL, 
    [IsMainSeriesCase] NCHAR(255) NULL, 
    [MailLanguage] NCHAR(255) NULL, 
    [ArrivalDate] NCHAR(255) NULL, 
    [DepartDate] NCHAR(255) NULL, 
    [IsDateFlexible] NCHAR(255) NULL, 
    [OurNotes] NCHAR(255) NULL, 
    [Purpose] NCHAR(255) NULL, 
    [ParticipantsType] NCHAR(255) NULL, 
    [TableSetting] NCHAR(255) NULL, 
    [Arrangementtype] NCHAR(255) NULL, 
    [Rooms] NCHAR(255) NULL, 
    [AlternativeServices] NCHAR(255) NULL, 
    [AdditionalRequests] NCHAR(255) NULL, 
    [GeographicalArea] NVARCHAR(50) NULL, 
    [BookingResponsible] NCHAR(255) NULL, 
    [IsStateAgreement] NCHAR(255) NULL, 
    [IsRegionsAgreement] NCHAR(255) NULL, 
    [PartnerTypeId] NCHAR(255) NULL, 
    [CenterMatching] NCHAR(255) NULL, 
    [Mobile] NCHAR(255) NULL, 
    [Telephone] NCHAR(255) NULL, 
    [ReferredFirm] VARBINARY(50) NULL, 
    [Address] NCHAR(10) NULL, 
    [ZipCode] NCHAR(10) NULL, 
    [Business] NCHAR(10) NULL, 
    [Case] NCHAR(10) NULL, 
    [Status] NCHAR(10) NULL, 
    [CancellationReason] NCHAR(10) NULL, 
    [OtherReason] NCHAR(10) NULL, 
    [Location] NCHAR(10) NULL, 
    [LocationComment] NCHAR(10) NULL, 
    [ReferredBy] NCHAR(10) NULL, 
    [Refers] NCHAR(10) NULL, 
    [LeadOrigin] NCHAR(10) NULL, 
    [IsGreenKey] NCHAR(10) NULL, 
    [IsAgreementForEmployees] NCHAR(10) NULL, 
    [IsHandicapFriendly] NCHAR(10) NULL, 
    [Lounge] NCHAR(10) NULL, 
    [Games (SR)] NCHAR(10) NULL, 
    [Spa] NCHAR(10) NULL, 
    [Pool] NCHAR(10) NULL, 
    [FitnessRoom] NCHAR(10) NULL, 
    [Casino] NCHAR(10) NULL, 
    [IsGreenAreas] NCHAR(10) NULL, 
    [Aircondition] NCHAR(10) NULL, 
    [CookingSchool] NCHAR(10) NULL, 
    [Golf] NCHAR(10) NULL, 
    [StartDateTime] NCHAR(10) NULL, 
    [Position] NCHAR(10) NULL, 
    [Department] NCHAR(10) NULL, 
    [Executives] NCHAR(10) NULL, 
    [RelatedParentRequest] NCHAR(10) NULL, 
    [TurnOffNotification] NCHAR(10) NULL, 
    [IsNewCustomer (-)] NCHAR(10) NULL, 
    [Communications] NCHAR(10) NULL, 
    [InternalNotes] NCHAR(10) NULL, 
    [Read] NCHAR(10) NULL, 
    [Difference] NCHAR(10) NULL, 
    [locationDate] NCHAR(10) NULL, 
    [ArrivalDate] NCHAR(10) NULL, 
    [Differenceindays] NCHAR(10) NULL, 
    [CommissionRate] NCHAR(10) NULL, 
    [Provisionlink] NCHAR(10) NULL, 
    [Referralcommissionlink] NCHAR(10) NULL, 
    [CommissionStatementsLink] NCHAR(10) NULL, 
    [EvaluationDate] NCHAR(10) NULL, 
    [Status_s] NCHAR(10) NULL, 
    [location _s] NCHAR(10) NULL, 
    [LeadOrigin _s] NCHAR(10) NULL, 
    [Henvistaf_s] NCHAR(10) NULL, 
    [Arrival_s] NCHAR(10) NULL, 
    [Depart_s] NCHAR(10) NULL, 
    [location Date_s] NCHAR(10) NULL, 
    [Response Time Email Offer_s] NCHAR(10) NULL, 
    [Reference] NCHAR(10) NULL, 
    [IsOfferAccepted] NCHAR(10) NULL, 
    [interest Tags_s] NCHAR(10) NULL, 
    [FirmaId_s] NCHAR(10) NULL, 
    [ContactPersonId] NCHAR(10) NULL, 
    [Geography_s] NCHAR(10) NULL 
   

)
