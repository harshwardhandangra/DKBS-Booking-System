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

            CreateMap<Booking, BookingViewModel>();
            CreateMap<TableSet, TableSetViewModel>();
            CreateMap<BookingRoom, BookingRoomViewModel>();
            CreateMap<BookingArrangementType, BookingArrangementTypeViewModel>();
            CreateMap<BookingAlternativeService, BookingAlternativeServiceViewModel>();
            CreateMap<BookingArrangementType, BookingArrangementTypeViewModel>();
            CreateMap<BookingAlternativeService, BookingAlternativeServiceDTO>();
            CreateMap<BookingAndStatus, BookingAndStatusDTO>();
            CreateMap<BookingArrangementType, BookingArrangementTypeDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingReference, BookingReferenceDTO>();
            CreateMap<BookingRegion, BookingRegionDTO>();
            CreateMap<BookingRoom, BookingRoomDTO>();
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
                //.ForMember(dest => dest.CenterTypeDTO, opt => opt.MapFrom(src => src.CenterType))
                //.ForMember(dest => dest.PartnerTypeDTO, opt => opt.MapFrom(src => src.PartnerType))
                //.ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                //.ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.LastModified))
                //.ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.LastModifiedBy))
                //.ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src.PartnerName))
                //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<PartnerEmployee, PartnerEmployeeDTO>();
            CreateMap<PartnerType, PartnerTypeDTO>();
            CreateMap<Procedure, ProcedureDTO>();
            CreateMap<ProcedureInfo, ProcedureInfoDTO>();
            CreateMap<ProcedureReviewType, ProcedureReviewTypeDTO>();
            CreateMap<Provision, ProvisionDTO>();
            CreateMap<Purpose, PurposeDTO>();
            CreateMap<Region, RegionDTO>();
            CreateMap<ServiceCatalog, ServiceCatalogDTO>();
            CreateMap<ServiceRequestCommunication, ServiceRequestCommunicationDTO>();
            CreateMap<ServiceRequestNote, ServiceRequestNoteDTO>();
            CreateMap<SRConversationItem, SRConversationItemDTO>();
            CreateMap<TableSet, TableSetDTO>();
            CreateMap<TableType, TableTypeDTO>();
            CreateMap<TownZipCode, TownZipCodeDTO>();
            CreateMap<Refreshment, RefreshmentsDTO>();

        }
    }
}
