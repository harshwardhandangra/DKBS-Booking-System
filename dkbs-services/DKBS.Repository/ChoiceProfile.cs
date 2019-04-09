using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.Repository
{
   public class ChoiceProfile :Profile
    {
        public ChoiceProfile()
        {
            CreateMap<BookingAlternativeService, BookingAlternativeServiceDTO>();
            CreateMap<BookingArrangementType, BookingArrangementTypeDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingReference, BookingReferenceDTO>();
            CreateMap<BookingRegion, BookingRegionDTO>();
            CreateMap<BookingRooms, BookingRoomsDTO>();
            CreateMap<Campaign, CampaignDTO>();
            CreateMap<CancellationReason, CancellationReasonDTO>();
            CreateMap<CauseOfRemoval, CauseOfRemovalDTO>();
            CreateMap<CenterMatching, CenterMatchingDTO>();
            CreateMap<CenterType, CenterTypeDTO>();
            CreateMap<ContactPerson, ContactPersonDTO>();
            CreateMap<CoursePackageType, CoursePackageTypeDTO>();
            CreateMap<CrmStatus, CrmStatusDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Flow, FlowDTO>();
            CreateMap<IndustryCode, IndustryCodeDTO>();
            CreateMap<ITProcedureStatus, ITProcedureStatusDTO>();
            CreateMap<Land , LandDTO>();
            CreateMap<LeadOfOrigin, LeadOfOriginDTO>();
            CreateMap<MailGroup, MailGroupDTO>();
            CreateMap<MailLanguage, MailLanguageDTO>();
            CreateMap<ParticipantType, ParticipantTypeDTO>();
            CreateMap<Partner, PartnerDTO>();
            CreateMap<PartnerEmployee, PartnerEmployeeDTO>();
            CreateMap<PartnerType, PartnerTypeDTO>();
            CreateMap<Procedure, ProcedureDTO>();
            CreateMap<ProcedureInfo, ProcedureInfoDTO>();
            CreateMap<ProcedureReviewType, ProcedureReviewTypeDTO>();
            CreateMap<Provision, ProvisionDTO>();
            CreateMap<Purpose, PurposeDTO>();
            CreateMap<Region, RegionDTO>();
            CreateMap<TableSet, TableSetDTO>();
            CreateMap<TableType, TableTypeDTO>();
            CreateMap<TownZipCode, TownZipCodeDTO>();

        }
    }
}
