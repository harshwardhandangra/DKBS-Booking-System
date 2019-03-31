using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// This controller contains all master data.
    /// </summary>
    [Route("choice")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Will take IChoiceRepository as param
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ChoiceController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All regions details.
        /// </summary>
        /// <returns>List of regions.</returns>
        [Route("regions")]
        [HttpGet()]
        public ActionResult<RegionDTO> GetRegions()
        {
           return Ok(_choiceRepoistory.GetRegions());
        }

        /// <summary>
        /// Get All tableset details.
        /// </summary>
        /// <returns>List of tablesets.</returns>
        [Route("tableSets")]
        [HttpGet()]
        public ActionResult<TableSetDTO> GetTableSets()
        {
            return Ok(_choiceRepoistory.GetTableSets());
        }

        /// <summary>
        /// Get All purposes details.
        /// </summary>
        /// <returns>List of purposes.</returns>
        [Route("purposes")]
        [HttpGet()]
        public ActionResult<PurposeDTO> GetPurposes()
        {
            return Ok(_choiceRepoistory.GetPurposes());
        }

        /// <summary>
        /// Get All Tabletypes details.
        /// </summary>
        /// <returns>List of tabletypes.</returns>
        [Route("tabletypes")]
        [HttpGet()]
        public ActionResult<TableTypeDTO> GetTableTypes()
        {
            return Ok(_choiceRepoistory.GetTableTypes());
        }

        /// <summary>
        /// Get All PartnerTypes details.
        /// </summary>
        /// <returns>List of Partnertypes.</returns>
        [Route("partnertypes")]
        [HttpGet()]
        public ActionResult<PartnerTypeDTO> GetPartnerTypes()
        {
            return Ok(_choiceRepoistory.GetPartnerTypes());
        }

        /// <summary>
        /// Get All mailLanguages details.
        /// </summary>
        /// <returns>List of maillanguages.</returns>
        [Route("maillanguages")]
        [HttpGet()]
        public ActionResult<MailLanguageDTO> GetMailLanguages()
        {
            return Ok(_choiceRepoistory.GetMailLanguages());
        }

        /// <summary>
        /// Get All LeadOfOrgins details.
        /// </summary>
        /// <returns>List of LeadOfOrgins.</returns>
        [Route("leadoforigins")]
        [HttpGet()]
        public ActionResult<LeadOfOriginDTO> GetLeadOfOrigins()
        {
            return Ok(_choiceRepoistory.GetLeadOfOrigins());
        }

        /// <summary>
        /// Get All Land details.
        /// </summary>
        /// <returns>List of Lands.</returns>
        [Route("lands")]
        [HttpGet()]
        public ActionResult<LandDTO> GetLandDetails()
        {
            return Ok(_choiceRepoistory.GetLandDetails());
        }

        /// <summary>
        /// Get All ITProcedureStatus details.
        /// </summary>
        /// <returns>List of ITProcedureStatuses.</returns>
        [Route("itprocedurestatus")]
        [HttpGet()]
        public ActionResult<ITProcedureStatusDTO> GetITProcedureStatusDetails()
        {
            return Ok(_choiceRepoistory.GetITProcedureStatuses());
        }

        /// <summary>
        /// Get All IndustryCodes details.
        /// </summary>
        /// <returns>List of IndustryCodes.</returns>
        [Route("industrycodes")]
        [HttpGet()]
        public ActionResult<IndustryCodeDTO> GetIndustryCodes()
        {
            return Ok(_choiceRepoistory.GetIndustryCodes());
        }

        /// <summary>
        /// Get All Flow details.
        /// </summary>
        /// <returns>List of Flows.</returns>
        [Route("flow")]
        [HttpGet()]
        public ActionResult<FlowDTO> GetFlowDetails()
        {
            return Ok(_choiceRepoistory.GetFlowDetails());
        }

        /// <summary>
        /// Get All CrmStatus details.
        /// </summary>
        /// <returns>List of CrmStatuses.</returns>
        [Route("crmstatus")]
        [HttpGet()]
        public ActionResult<CrmStatusDTO> GetCrmStatusDetails()
        {
            return Ok(_choiceRepoistory.GetCrmStatusDetails());
        }

        /// <summary>
        /// Get All CoursePackageType details.
        /// </summary>
        /// <returns>List of CoursePackageTypes.</returns>
        [Route("coursepackagetype")]
        [HttpGet()]
        public ActionResult<CoursePackageTypeDTO> GetCoursePackageTypes()
        {
            return Ok(_choiceRepoistory.GetCoursePackageTypes());
        }

        /// <summary>
        /// Get All ContactPersons details.
        /// </summary>
        /// <returns>List of ContactPersons.</returns>
        [Route("contactpersons")]
        [HttpGet()]
        public ActionResult<ContactPersonDTO> GetContactPersons()
        {
            return Ok(_choiceRepoistory.GetContactPersons());
        }

        /// <summary>
        /// Get All Campaign details.
        /// </summary>
        /// <returns>List of Campaigns.</returns>
        [Route("campaigns")]
        [HttpGet()]
        public ActionResult<CampaignDTO> GetCampaigns()
        {
            return Ok(_choiceRepoistory.GetCampaigns());
        }

        /// <summary>
        /// Get All CenterType details.
        /// </summary>
        /// <returns>List of CenterTypes.</returns>
        [Route("centertypes")]
        [HttpGet()]
        public ActionResult<CenterTypeDTO> GetCenterTypes()
        {
            return Ok(_choiceRepoistory.GetCenterTypes());
        }

        /// <summary>
        /// Get All CenterMatching details.
        /// </summary>
        /// <returns>List of CenterMatchings.</returns>
        [Route("centermatchings")]
        [HttpGet()]
        public ActionResult<CenterMatchingDTO> GetCenterMatchings()
        {
            return Ok(_choiceRepoistory.GetCenterMatchings());
        }

        /// <summary>
        /// Get All CauseOfRemoval details.
        /// </summary>
        /// <returns>List of CauseOfRemovals.</returns>
        [Route("causeofremovals")]
        [HttpGet()]
        public ActionResult<CauseOfRemovalDTO> GetCauseOfRemovals()
        {
            return Ok(_choiceRepoistory.GetCauseOfRemovals());
        }

        /// <summary>
        /// Get All CancellationReason details.
        /// </summary>
        /// <returns>List of CancellationReasons.</returns>
        [Route("cancellationreasons")]
        [HttpGet()]
        public ActionResult<CancellationReasonDTO> GetCancellationReasons()
        {
            return Ok(_choiceRepoistory.GetCancellationReasons());
        }

        /// <summary>
        /// Get All partnerEmployees details.
        /// </summary>
        /// <returns>List of partnerEmployees.</returns>
        [Route("partnerEmployees")]
        [HttpGet()]
        public ActionResult<CancellationReasonDTO> GetPartnerEmployesss()
        {
            return Ok(_choiceRepoistory.GetPartnerEmployees());
        }
    }
}