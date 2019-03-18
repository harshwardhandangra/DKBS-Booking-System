using DKBS.Data;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DKBS.Domain;

namespace DKBS.Repository
{
    public interface IChoiceRepository
    {
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
    }

    public class ChoiceRepository : IChoiceRepository
    {
        DKBSDbContext _dbContext;
        public ChoiceRepository(DKBSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RegionDTO> GetRegions()
        {
          return  _dbContext.Regions.Select( p  =>  new RegionDTO { Name = p.Name, RegionId = p.RegionId }).ToList();
        }

        public List<TableSetDTO> GetTableSets()
        {
            return _dbContext.TableSet.Select(p => new TableSetDTO { TableSetName = p.TableSetName, TableSetId = p.TableSetId}).ToList();
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
    }
}
