using DKBS.Data;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DKBS.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DKBS.Repository
{
    public interface IChoiceRepository
    {
        void Complete();
        List<BookingAlternativeServiceDTO> GetBookingAlternativeServices();
        List<BookingArrangementTypeDTO> GetBookingArrangementTypes();
        List<BookingDTO> GetBookings();
        List<BookingReferenceDTO> GetBookingReferences();
        List<BookingRegionDTO> GetBookingRegions();
        List<ContactPersonDTO> GetContactPeople();
        List<MailGroupDTO> GetMailGroups();
        List<ParticipantTypeDTO> GetParticipantTypes();
        List<ProcedureDTO> GetProcedures();
        List<ProcedureInfoDTO> GetProcedureInfos();
        List<ProcedureReviewTypeDTO> GetProcedureReviewTypes();
        List<ProvisionDTO> GetProvisions();
        List<BookingRoomsDTO> GetBookingRooms();
        List<TownZipCodeDTO> GetTownZipCodes();
        List<TableSetDTO> GetTableSets();
        List<RegionDTO> GetRegions();
        List<PurposeDTO> GetPurposes();
        List<PartnerTypeDTO> GetPartnerTypes();
        List<TableTypeDTO> GetTableTypes();
        List<MailLanguageDTO> GetMailLanguages();
        List<LeadOfOriginDTO> GetLeadOfOrigins();
        List<LandDTO> GetLandDetails();
        List<ITProcedureStatusDTO> GetITProcedureStatuses();
        List<IndustryCodeDTO> GetIndustryCodes();
        List<FlowDTO> GetFlowDetails();
        List<CrmStatusDTO> GetCrmStatusDetails();
        List<CoursePackageTypeDTO> GetCoursePackageTypes();
        List<ContactPersonDTO> GetContactPersons();
        List<CampaignDTO> GetCampaigns();
        List<CenterTypeDTO> GetCenterTypes();
        List<CenterMatchingDTO> GetCenterMatchings();
        List<CauseOfRemovalDTO> GetCauseOfRemovals();
        List<CancellationReasonDTO> GetCancellationReasons();
        List<CustomerDTO> GetCustomers();
        List<PartnerDTO> GetPartners();
        List<PartnerEmployeeDTO> GetPartnerEmployees();
        List<BookingAndStatusDTO> GetBookingAndStatuses();
        List<ServiceCatalogDTO> GetServiceCatalogs();
        List<ServiceRequestCommunicationsDTO> GetServiceRequestCommunications();
        List<ServiceRequestNotesDTO> GetServiceRequestNotes();
        List<SRConversationItemsDTO> GetSRConversationItems();

        void SetBookings(Booking booking);
        void SetPartner(Partner newlyCreatedPartner);
        void SetCenterType(CenterType centerTypeMapped);
        void SetPartnerType(PartnerType partnerTypeMapped);
        void AttachIndustryCode(IndustryCode industryCode);
        void SetCreatedCustomer(Customer newlyCreatedCustomer);
        void SetTableType(TableType newlyCreatedtableType);
        void SetCancellationReason(CancellationReason newlyCreatedCancellationReason);
        void SetCauseOfRemoval(CauseOfRemoval newlyCreatedCancellationReason);
        void SetContactPerson(ContactPerson newlyCreatedContactPerson);
        void SetBookingAndStatus(BookingAndStatus newlyCreatedBookingAndStatus);
        void SetFlow(Flow newlyCreatedFlow);
        void SetMailLanguage(MailLanguage newlyCreatedmailLanguage);
        void SetParticipantType(ParticipantType newlyCreatedParticipantType);
        void SetPurpose(Purpose newlyCreatedPurpose);
        void SetCampaign(Campaign newlyCreatedCampaign);
        void SetLeadOfOrigin(LeadOfOrigin newlyCreatedLeadOfOrigin);
    }

    public class ChoiceRepository : IChoiceRepository
    {
        DKBSDbContext _dbContext;
        IMapper _mapper;
        public ChoiceRepository(DKBSDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }


        public List<RegionDTO> GetRegions()
        {
            return _mapper.Map<List<RegionDTO>>(_dbContext.Regions.ToList());
        }

        public List<TableSetDTO> GetTableSets()
        {
            return _mapper.Map<List<TableSetDTO>>(_dbContext.TableSets.ToList());
        }

        public List<PurposeDTO> GetPurposes()
        {
            return _dbContext.Purpose.Select(p => new PurposeDTO { PurposeName = p.PurposeName, PurposeId = p.PurposeId }).ToList();
        }

        public List<PartnerTypeDTO> GetPartnerTypes()
        {
            return _dbContext.PartnerTypes.Select(p => new PartnerTypeDTO { PartnerTypeTitle = p.PartnerTypeTitle, PartnerTypeId = p.PartnerTypeId }).ToList();
        }

        public List<TableTypeDTO> GetTableTypes()
        {
            return _dbContext.TableTypes.Select(p => new TableTypeDTO { TableTypeName = p.TableTypeName, TableTypeId = p.TableTypeId }).ToList();
        }

        public List<MailLanguageDTO> GetMailLanguages()
        {
            return _dbContext.MailLanguages.Select(p => new MailLanguageDTO { Language = p.Language, MailLanguageId = p.MailLanguageId }).ToList();
        }

        public List<LeadOfOriginDTO> GetLeadOfOrigins()
        {
            return _dbContext.LeadOfOrigins.Select(p => new LeadOfOriginDTO { Name = p.Name, LeadOfOriginId = p.LeadOfOriginId }).ToList();
        }

        public List<LandDTO> GetLandDetails()
        {
            return _dbContext.Land.Select(p => new LandDTO { LandTitle = p.LandTitle, LandId = p.LandId }).ToList();
        }

        public List<ITProcedureStatusDTO> GetITProcedureStatuses()
        {
            return _dbContext.ITProcedureStatuses.Select(p => new ITProcedureStatusDTO { ITProcedureStatusTitle = p.ITProcedureStatusTitle, ITProcedureStatusId = p.ITProcedureStatusId, InternalName = p.InternalName}).ToList();
        }

        public List<IndustryCodeDTO> GetIndustryCodes()
        {
            return _dbContext.IndustryCodes.Select(p => new IndustryCodeDTO { IndustryCodeTitle = p.IndustryCodeTitle, IndustryCodeId = p.IndustryCodeId, IsNewBranch = p.IsNewBranch }).ToList();
        }

        public List<FlowDTO> GetFlowDetails()
        {
            return _dbContext.Flow.Select(p => new FlowDTO { FlowName = p.FlowName, FlowId = p.FlowId }).ToList();
        }

        public List<CrmStatusDTO> GetCrmStatusDetails()
        {
            return _dbContext.CrmStatuses.Select(p => new CrmStatusDTO { CrmStatusTitle = p.CrmStatusTitle, CrmStatusId = p.CrmStatusId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<CoursePackageTypeDTO> GetCoursePackageTypes()
        {
            return _dbContext.CoursePackageTypes.Select(p => new CoursePackageTypeDTO { CoursePackageTypeTitle = p.CoursePackageTypeTitle, CoursePackageTypeId = p.CoursePackageTypeId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<ContactPersonDTO> GetContactPersons()
        {
            return _dbContext.ContactPersons.Select(p => new ContactPersonDTO { Name = p.Name, ContactPersonId = p.ContactPersonId, Department = p.Department, Email = p.Email, Mobile = p.Mobile, Position = p.Position, Telephone = p.Telephone }).ToList();
        }

        public List<CampaignDTO> GetCampaigns()
        {
            return _dbContext.Campaigns.Select(p => new CampaignDTO { Name = p.Name, CampaignId = p.CampaignId }).ToList();
        }

        public List<CenterTypeDTO> GetCenterTypes()
        {
            return _dbContext.CenterTypes.Select(p => new CenterTypeDTO { CenterTypeTitle = p.CenterTypeTitle, CenterTypeId = p.CenterTypeId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<CenterMatchingDTO> GetCenterMatchings()
        {
            return _dbContext.CenterMatchings.Select(p => new CenterMatchingDTO { MatchingCenter = p.MatchingCenter, CenterMatchingId = p.CenterMatchingId }).ToList();
        }

        public List<CauseOfRemovalDTO> GetCauseOfRemovals()
        {
            return _dbContext.CauseOfRemovals.Select(p => new CauseOfRemovalDTO { CauseOfRemovalTitle = p.CauseOfRemovalTitle, CauseOfRemovalId = p.CauseOfRemovalId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<CancellationReasonDTO> GetCancellationReasons()
        {
            return _dbContext.CancellationReasons.Select(p => new CancellationReasonDTO { CancellationReasonName = p.CancellationReasonName, CancellationReasonId = p.CancellationReasonId }).ToList();
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _mapper.Map<List<CustomerDTO>>(_dbContext.Customers.ToList());
        }

        public List<PartnerDTO> GetPartners()
        {
            return _mapper.Map<List<PartnerDTO>>(_dbContext.Partners.ToList());
        }

        public List<PartnerEmployeeDTO> GetPartnerEmployees()
        {
            return _mapper.Map<List<PartnerEmployeeDTO>>(_dbContext.PartnerEmployees.ToList());
        }

        public List<BookingAlternativeServiceDTO> GetBookingAlternativeServices()
        {
            return _mapper.Map<List<BookingAlternativeServiceDTO>>(_dbContext.BookingAlternativeServices.ToList());
        }

        public List<BookingArrangementTypeDTO> GetBookingArrangementTypes()
        {
            return _mapper.Map<List<BookingArrangementTypeDTO>>(_dbContext.BookingArrangementTypes.ToList());
        }

        public List<BookingDTO> GetBookings()
        {
                    var booking = _dbContext.Bookings
                    .Include(x => x.Partner.CenterType)
                    .Include(x => x.Partner.PartnerType)
                    .Include(x => x.Customer.IndustryCode)
                    .Include(x => x.TableType)
                    .Include(x => x.CancellationReason)
                    .Include(x => x.CauseOfRemoval)
                    .Include(x => x.ContactPerson)
                    .Include(x => x.BookingAndStatus)
                    .Include(x => x.Flow)
                    .Include(x => x.MailLanguage)
                    .Include(x => x.PartnerType)
                    .Include(x => x.ParticipantType)
                    .Include(x => x.Purpose)
                    .Include(x => x.LeadOfOrigin)
                    .Include(x => x.Campaign)
                    .ToList();

                List<BookingDTO> bookingDTO = new List<BookingDTO>();

                foreach (var item in booking)
                {
                    var bookingDto = new BookingDTO();

                    CenterTypeDTO centerTypeDto = _mapper.Map<CenterTypeDTO>(item.Partner.CenterType);
                    PartnerTypeDTO partnerTypeDto = _mapper.Map<PartnerTypeDTO>(item.Partner.PartnerType);
                    var partnerDto = new PartnerDTO()
                    {
                        PartnerId = item.Partner.PartnerId,
                        CenterTypeDTO = centerTypeDto,
                        PartnerTypeDTO = partnerTypeDto,
                        EmailId = item.Partner.EmailId,
                        LastModified = item.Partner.LastModified,
                        LastModifiedBy = item.Partner.LastModifiedBy,
                        PartnerName = item.Partner.PartnerName,
                        PhoneNumber = item.Partner.PhoneNumber
                    };
                    IndustryCodeDTO industryCodeDto = _mapper.Map<IndustryCode, IndustryCodeDTO>(item.Customer.IndustryCode);
                    var customerDto = new CustomerDTO()
                    {
                        City = item.Customer.City,
                        IndustryCodeDTO = industryCodeDto,
                        CreatedBy = item.Customer.CreatedBy,
                        Country = item.Customer.Country,
                        CreatedDate = item.Customer.CreatedDate,
                        CustomerName = item.Customer.CustomerName,
                        EmailId = item.Customer.EmailId,
                        LastModifiedBY = item.Customer.LastModifiedBY,
                        LastModifiedDate = item.Customer.LastModifiedDate,
                        PhoneNumber = item.Customer.PhoneNumber
                    };
                    TableTypeDTO tableTypeDTO = _mapper.Map<TableType, TableTypeDTO>(item.TableType);
                    CancellationReasonDTO cancellationReasonDTO = _mapper.Map<CancellationReason, CancellationReasonDTO>(item.CancellationReason);
                    CauseOfRemovalDTO causeOfRemovalDTO = _mapper.Map<CauseOfRemoval, CauseOfRemovalDTO>(item.CauseOfRemoval);
                    ContactPersonDTO contactPersonDTO = _mapper.Map<ContactPerson, ContactPersonDTO>(item.ContactPerson);
                    BookingAndStatusDTO bookingAndStatusDTO = _mapper.Map<BookingAndStatus, BookingAndStatusDTO>(item.BookingAndStatus);
                    FlowDTO flowDTO = _mapper.Map<Flow, FlowDTO>(item.Flow);
                    ParticipantTypeDTO participantTypeDTO = _mapper.Map<ParticipantType, ParticipantTypeDTO>(item.ParticipantType);
                    PurposeDTO purposeDTO = _mapper.Map<Purpose, PurposeDTO>(item.Purpose);
                    LeadOfOriginDTO leadOfOriginDTO = _mapper.Map<LeadOfOrigin, LeadOfOriginDTO>(item.LeadOfOrigin);
                    CampaignDTO campaignDTO = _mapper.Map<Campaign, CampaignDTO>(item.Campaign);
                    MailLanguageDTO mailLanguageDTO = _mapper.Map<MailLanguageDTO>(item.MailLanguage);

                    bookingDto.BookingId = item.BookingId;
                    bookingDto.PartnerDTO = partnerDto;
                    bookingDto.CustomerDTO = customerDto;
                    bookingDto.TableTypeDTO = tableTypeDTO;
                    bookingDto.CancellationReasonDTO = cancellationReasonDTO;
                    bookingDto.CauseOfRemovalDTO = causeOfRemovalDTO;
                    bookingDto.ContactPersonDTO = contactPersonDTO;
                    bookingDto.BookingAndStatusDTO = bookingAndStatusDTO;
                    bookingDto.FlowDTO = flowDTO;
                    bookingDto.ParticipantTypeDTO = participantTypeDTO;
                    bookingDto.PurposeDTO = purposeDTO;
                    bookingDto.LeadOfOriginDTO = leadOfOriginDTO;
                    bookingDto.CampaignDTO = campaignDTO;
                    bookingDto.MailLanguageDTO = mailLanguageDTO;
                    bookingDTO.Add(bookingDto);
            }

            return bookingDTO;


        }

            public List<BookingReferenceDTO> GetBookingReferences()
        {
            return _mapper.Map<List<BookingReferenceDTO>>(_dbContext.BookingReferences.ToList());
        }

        public List<BookingRegionDTO> GetBookingRegions()
        {
            return _mapper.Map<List<BookingRegionDTO>>(_dbContext.BookingRegions.ToList());
        }

        public List<ContactPersonDTO> GetContactPeople()
        {
            return _mapper.Map<List<ContactPersonDTO>>(_dbContext.ContactPersons.ToList());
        }

        public List<MailGroupDTO> GetMailGroups()
        {
            return _mapper.Map<List<MailGroupDTO>>(_dbContext.MailGroups.ToList());
        }

        public List<ParticipantTypeDTO> GetParticipantTypes()
        {
            return _mapper.Map<List<ParticipantTypeDTO>>(_dbContext.ParticipantTypes.ToList());
        }

        public List<ProcedureDTO> GetProcedures()
        {
            return _mapper.Map<List<ProcedureDTO>>(_dbContext.Procedures.ToList());
        }

        public List<ProcedureReviewTypeDTO> GetProcedureReviewTypes()
        {
            return _mapper.Map<List<ProcedureReviewTypeDTO>>(_dbContext.ProcedureReviewTypes.ToList());
        }

        public List<ProvisionDTO> GetProvisions()
        {
            return _mapper.Map<List<ProvisionDTO>>(_dbContext.Provisions.ToList());
        }

        public List<BookingRoomsDTO> GetBookingRooms()
        {
            return _mapper.Map<List<BookingRoomsDTO>>(_dbContext.BookingRooms.ToList());
        }

        public List<TownZipCodeDTO> GetTownZipCodes()
        {
            return _mapper.Map<List<TownZipCodeDTO>>(_dbContext.TownZipCodes.ToList());
        }

        public List<ProcedureInfoDTO> GetProcedureInfos()
        {
            return _mapper.Map<List<ProcedureInfoDTO>>(_dbContext.ProcedureInfos.ToList());
        }

        public List<BookingAndStatusDTO> GetBookingAndStatuses()
        {
            return _mapper.Map<List<BookingAndStatusDTO>>(_dbContext.BookingAndStatuses.ToList());
        }

        public List<ServiceCatalogDTO> GetServiceCatalogs()
        {
            return _mapper.Map<List<ServiceCatalogDTO>>(_dbContext.ServiceCatalogs.ToList());
        }

        public List<ServiceRequestCommunicationsDTO> GetServiceRequestCommunications()
        {
            return _mapper.Map<List<ServiceRequestCommunicationsDTO>>(_dbContext.ServiceRequestCommunications.ToList());
        }

        public List<ServiceRequestNotesDTO> GetServiceRequestNotes()
        {
            return _mapper.Map<List<ServiceRequestNotesDTO>>(_dbContext.ServiceRequestNotes.ToList());
        }

        public List<SRConversationItemsDTO> GetSRConversationItems()
        {
            return _mapper.Map<List<SRConversationItemsDTO>>(_dbContext.SRConversationItems.ToList());
        }

        public void SetBookings(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
        }

        public void SetPartner(Partner newlyCreatedPartner)
        {
            _dbContext.Partners.Add(newlyCreatedPartner);
        }

        public void SetCenterType(CenterType centerTypeMapped)
        {
            _dbContext.CenterTypes.Add(centerTypeMapped);
        }

        public void SetPartnerType(PartnerType partnerTypeMapped)
        {
            _dbContext.PartnerTypes.Add(partnerTypeMapped);
        }

        public void AttachIndustryCode(IndustryCode industryCode)
        {
            _dbContext.IndustryCodes.Add(industryCode);
        }

        public void SetCreatedCustomer(Customer newlyCreatedCustomer)
        {
               _dbContext.Customers.Add(newlyCreatedCustomer);
        }

        public void SetTableType(TableType newlyCreatedtableType)
        {
             _dbContext.TableTypes.Add(newlyCreatedtableType);
        }

        public void SetCancellationReason(CancellationReason newlyCreatedCancellationReason)
        {
            _dbContext.CancellationReasons.Add(newlyCreatedCancellationReason);
        }

        public void SetCauseOfRemoval(CauseOfRemoval newlyCreatedCauseOfRemoval)
        {
            _dbContext.CauseOfRemovals.Add(newlyCreatedCauseOfRemoval);
        }

        public void SetContactPerson(ContactPerson newlyCreatedContactPerson)
        {
            _dbContext.ContactPersons.Add(newlyCreatedContactPerson);
        }

        public void SetBookingAndStatus(BookingAndStatus newlyCreatedBookingAndStatus)
        {
            _dbContext.BookingAndStatuses.Add(newlyCreatedBookingAndStatus);
        }

        public void SetFlow(Flow newlyCreatedFlow)
        {
            _dbContext.Flow.Add(newlyCreatedFlow);
        }

        public void SetMailLanguage(MailLanguage newlyCreatedmailLanguage)
        {
            _dbContext.MailLanguages.Add(newlyCreatedmailLanguage);
        }

        public void SetParticipantType(ParticipantType newlyCreatedParticipantType)
        {
            _dbContext.ParticipantTypes.Add(newlyCreatedParticipantType);      
        }

        public void SetPurpose(Purpose newlyCreatedPurpose)
        {
            _dbContext.Purpose.Add(newlyCreatedPurpose);
        }

        public void SetCampaign(Campaign newlyCreatedCampaign)
        {
             _dbContext.Campaigns.Add(newlyCreatedCampaign);
        }

        public void SetLeadOfOrigin(LeadOfOrigin newlyCreatedLeadOfOrigin)
        {
            _dbContext.LeadOfOrigins.Add(newlyCreatedLeadOfOrigin);
        }
    }
}
