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
        /// Get Partner List based on some character entered by user in Partner name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PartnerDTO>> GetPartner(int id)
        {
            return _choiceRepoistory.GetPartners().FindAll(c => c.PartnerName.Contains(id.ToString()));
        }
        /// <summary>
        /// Creating Partner
        /// </summary>
        /// <param name="partnerDto"></param>
        /// <returns></returns>
        // GET api/Partner/{Partner}
        [HttpPost]
        public ActionResult<IEnumerable<PartnerDTO>> CreatePartner([FromBody] PartnerDTO partnerDto)
        {

            if (ModelState.IsValid)
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

            Partner newlyCreatedPartner = new Partner() { PartnerName = partnerDto.PartnerName, PartnerId = partnerDto.PartnerId, /*CenterTypeId = partnerDto.CenterTypeId,*/ EmailId = partnerDto.EmailId, LastModified = partnerDto.LastModified, LastModifiedBy = partnerDto.LastModifiedBy,/* PartnerType = partnerDto.PartnerType,*/ PhoneNumber = partnerDto.PhoneNumber  };
            var destination = _mapper.Map<Partner, PartnerDTO>(newlyCreatedPartner);


            _choiceRepoistory.GetPartners().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetPartners", new { name = newlyCreatedPartner.PartnerName }, newlyCreatedPartner);
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
            if (ModelState.IsValid)
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
