using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Partner controller
    /// </summary>
    [Route("api/[controller]")]
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
        /// <param name="partnerDto"></param>
        /// <returns></returns>
        [HttpPost]
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
        /// <param name="PartnerId"></param>
        /// <param name="partnerDTO"></param>
        /// <returns></returns>
        [HttpPut("{PartnerId}")]
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
