using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Partner controller
    /// </summary>
    [Route("partner")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;
        /// <summary>
        /// Partner controller
        /// </summary>
        public PartnerController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All partner details.
        /// </summary>
        /// <returns>List of partners.</returns>
        [HttpGet()]
        public ActionResult<PartnerEmployeeDTO> GetPartners()
        {
            return Ok(_choiceRepoistory.GetPartners());
        }
        /// <summary>
        /// Get Partner by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<PartnerDTO> GetPartnerById(int id)
        {
            return _choiceRepoistory.GetPartners().Find(c => c.PartnerId == id);
        }


        /// <summary>
        /// Get Partner List based by user in Partner name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("[action]/{name}", Name = "GetPartnersByName")]
        public ActionResult<IEnumerable<PartnerDTO>> SearchPartnersByName(string name)
        {
            return _choiceRepoistory.GetPartners().FindAll(c => c.PartnerName.Contains(name));
        }

        /// <summary>
        /// Creating Partner
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///
        [Authorize]
        [HttpPost("")]
        public IActionResult CreatePartner([FromBody] CRMPartnerDTO dto)
        {

            try
            {
                if (dto == null)
                {
                    ModelState.AddModelError("Partner", "Partner object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.AccountId == dto.AccountId);

                if (partner != null)
                {
                    ModelState.AddModelError("Partner", $"Partner entry already exist for AccountId {dto.AccountId}.");
                    return BadRequest(ModelState);
                }

                CRMPartner newPartner = _mapper.Map<CRMPartnerDTO, CRMPartner>(dto);
                newPartner.CreatedBy = "CRM";
                newPartner.CreatedDate = DateTime.UtcNow;
                newPartner.LastModified = DateTime.UtcNow;
                newPartner.LastModifiedBy = "CRM";
                _choiceRepoistory.Attach<CRMPartner>(newPartner);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetPartnerByAccountId", new { newPartner.AccountId }, newPartner);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating partner. Please try again or contact adminstrator");
            }
        }

        /// <summary>
        /// Get partner details by account id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}", Name = "GetPartnerByAccountId")]
        public ActionResult<CustomerDTO> GetPartnerByAccountId(string accountId)
        {
            var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.AccountId == accountId);

            if(partner == null)
            {
               return NotFound(accountId);
            }

            return Ok(partner);
        }

        /// <summary>
        /// Creating Partner
        /// </summary>
        /// <param name="partnerDto"></param>
        /// <returns></returns>
        [HttpPost("/partner_rename")]
        public ActionResult<IEnumerable<PartnerDTO>> CreatePartner([FromBody] PartnerDTO partnerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerDto == null)
                return BadRequest();

            var checkPartnerIdinDb = _choiceRepoistory.GetPartners().Find(c => c.PartnerId == partnerDto.PartnerId);

            if (checkPartnerIdinDb != null)
            {
                return BadRequest();
            }

            var centerType = _mapper.Map<CenterTypeDTO, CenterType>(partnerDto.CenterTypeDTO);
            var partnerType = _mapper.Map<PartnerTypeDTO, PartnerType>(partnerDto.PartnerTypeDTO);
            Partner newlyCreatedPartner = new Partner() { PartnerId = partnerDto.PartnerId, PartnerName = partnerDto.PartnerName, CenterType = centerType, EmailId = partnerDto.EmailId, LastModified = partnerDto.LastModified, LastModifiedBy = partnerDto.LastModifiedBy, PartnerType = partnerType, PhoneNumber = partnerDto.PhoneNumber };
            var destination = _mapper.Map<Partner, PartnerDTO>(newlyCreatedPartner);


            _choiceRepoistory.GetPartners().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetPartnersByName", new { name = newlyCreatedPartner.PartnerName }, newlyCreatedPartner);
        }

        /// <summary>
        /// Update partner
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPut("{accountId}")]
        public IActionResult UpdatePartner(string accountId, [FromBody] CRMPartnerDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accountId))
                {
                    ModelState.AddModelError("AccountId", "AccountId can't be null or empty.");
                    return BadRequest(ModelState);
                }

                if (dto == null)
                {
                    ModelState.AddModelError("Partner", "Partner object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var partner = _choiceRepoistory.GetById<CRMPartner>(c => c.AccountId == accountId);

                if (partner == null)
                {
                    ModelState.AddModelError("Partner", $"No Partner found with AccountId {accountId}");
                    return NotFound(ModelState);
                }

                partner.Partnertype = dto.Partnertype;
                partner.MembershipType = dto.MembershipType;
                partner.PartnerName = dto.PartnerName;
                partner.CVR = dto.CVR;
                partner.Telefon = dto.Telefon;
                partner.Centertype = dto.Centertype;

                partner.Address1 = dto.Address1;
                partner.Address2 = dto.Address2;
                partner.Town = dto.Town;

                partner.PostNumber = dto.PostNumber;
                partner.Land = dto.Land;
                partner.StateAgreement = dto.StateAgreement;
                partner.Debitornummer = dto.Debitornummer;
                partner.Debitornummer2 = dto.Debitornummer2;
                partner.Regions = dto.Regions;
                partner.MembershipStartDate = dto.MembershipStartDate;
                partner.PublicURL = dto.PublicURL;
                partner.Email = dto.Email;
                partner.Website = dto.Website;
                partner.PanoramView = dto.PanoramView;
                partner.RecommandedNPGRT60 = dto.RecommandedNPGRT60;
                partner.QualityAssuredNPSGRD30 = dto.QualityAssuredNPSGRD30;
                partner.LastModified = DateTime.UtcNow;
                partner.LastModifiedBy = "CRM";  //later need to change
                _choiceRepoistory.Attach(partner);
                _choiceRepoistory.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating Partner. Please try again or contact adminstrator");
            }
        }

        /// <summary>
        /// Update partner
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <param name="partnerDTO"></param>
        /// <returns></returns>
        [HttpPut("partner_rename/{PartnerId}")]
        public IActionResult UpdatePartner(int PartnerId, [FromBody] PartnerDTO partnerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerDTO == null)
                return BadRequest();

            var partner = _choiceRepoistory.GetPartners().Find(c => c.PartnerId == PartnerId);

            if (partner == null)
            {
                return BadRequest();
            }

            partner = partnerDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }

    }
}
