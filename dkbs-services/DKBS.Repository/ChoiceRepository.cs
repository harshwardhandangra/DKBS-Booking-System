using DKBS.Data;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DKBS.Domain;
using AutoMapper;

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
            return _mapper.Map<List<TableSetDTO>>(_dbContext.TableSet.ToList());
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
            return _dbContext.LeadOfOrigins.Select(p => new LeadOfOriginDTO { Name = p.Name, LeadOrignId = p.LeadOfOriginId }).ToList();
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
            return _dbContext.Campaigns.Select(p => new CampaignDTO { Name = p.Name, CompaignId = p.CampaignId }).ToList();
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
            return _dbContext.CancellationReasons.Select(p => new CancellationReasonDTO { CancellationReasonName = p.CancellationReasonName, Id = p.CancellationReasonId }).ToList();
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
            return _mapper.Map<List<BookingDTO>>(_dbContext.Bookings.ToList());
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
            return _mapper.Map<List<ContactPersonDTO>>(_dbContext.ContactPeople.ToList());
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
    }
}
