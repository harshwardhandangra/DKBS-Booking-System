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
    /// PartnerEmployee controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerEmployeeController : Controller
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;
        /// <summary>
        /// PartnerEmployee Controller
        /// </summary>
        public PartnerEmployeeController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All partnerEmployees details.
        /// </summary>
        /// <returns>List of partnerEmployees.</returns>        
        [HttpGet()]
        public ActionResult<PartnerEmployeeDTO> GetPartnerEmployes()
        {
            return Ok(_choiceRepoistory.GetPartnerEmployees());
        }

        /// <summary>
        /// Get GetPartnerEmployeesByPartnerId List based on PartnerId
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        [HttpGet("{PartnerId}", Name = "GetPartnerEmployeesByPartnerId")]
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> GetPartnerEmployeesByPartnerId(int PartnerId)
        {
            return _choiceRepoistory.GetPartnerEmployees().FindAll(c => c.PartnerDTO.PartnerId == PartnerId);
        }

        /// <summary>
        /// Get PartnerEmployee List based on some character entered by user in Partner name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetPartner")]
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> GetPartnerEmployees(string name)
        {
            return _choiceRepoistory.GetPartnerEmployees().FindAll(c => c.EmployeeName.Contains(name));
        }

        /// <summary>
        /// Creating PartnerEmployee
        /// </summary>
        /// <param name="partnerEmployeeDto"></param>
        /// <returns></returns>
        // GET api/PartnerEmployee/{PartnerEmployee}
        [HttpPost("{Partner}")]
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> CreatePartnerEmployee([FromBody] PartnerEmployeeDTO partnerEmployeeDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerEmployeeDto == null)
                return BadRequest();

            var checkPartnerIdinDb = _choiceRepoistory.GetPartnerEmployees().Find(c => c.PartnerEmployeeId == partnerEmployeeDto.PartnerEmployeeId);

            if (checkPartnerIdinDb != null)
            {
                return BadRequest();
            }

            var centerType = _mapper.Map<CenterTypeDTO, CenterType>(partnerEmployeeDto.PartnerDTO.CenterTypeDTO);
            var partnerType = _mapper.Map<PartnerTypeDTO, PartnerType>(partnerEmployeeDto.PartnerDTO.PartnerTypeDTO);
            
            // TODO: check and use map functionlity of mapping properties
            var partner = new Partner()
            {
                CenterType = centerType,
                PartnerType = partnerType,
                EmailId = partnerEmployeeDto.Email,
                PartnerId = partnerEmployeeDto.PartnerDTO.PartnerId,
                PartnerName = partnerEmployeeDto.PartnerDTO.PartnerName,
                 PhoneNumber = partnerEmployeeDto.PartnerDTO.PhoneNumber,
                LastModified = partnerEmployeeDto.PartnerDTO.LastModified,
                LastModifiedBy = partnerEmployeeDto.PartnerDTO.LastModifiedBy
            };

            var participantType = _mapper.Map<ParticipantTypeDTO, ParticipantType>(partnerEmployeeDto.ParticipantTypeDTO);
            var mailGroup = _mapper.Map<MailGroupDTO, MailGroup>(partnerEmployeeDto.MailGroupDTO);


            PartnerEmployee newlyCreatedPartnerEmployee = new PartnerEmployee()
            {
                EmployeeName = partnerEmployeeDto.EmployeeName,
                PartnerEmployeeId = partnerEmployeeDto.PartnerEmployeeId,
                Email = partnerEmployeeDto.Email,
                ParticipantType = participantType,
                JobTitle = partnerEmployeeDto.JobTitle,
                PartnerType = partnerType,
                MailGroup = mailGroup,
                TelePhoneNumber = partnerEmployeeDto.TelePhoneNumber,
                Partner = partner,
                LastModified = partnerEmployeeDto.LastModified,
                LastModifiedBY = partnerEmployeeDto.LastModifiedBY
            };

            var destination = _mapper.Map<PartnerEmployee, PartnerEmployeeDTO>(newlyCreatedPartnerEmployee);
            _choiceRepoistory.GetPartnerEmployees().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetPartner", new { name = newlyCreatedPartnerEmployee.EmployeeName }, newlyCreatedPartnerEmployee);
        }

        /// <summary>
        /// Updating partner employess
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="partnerEmployeeDTO"></param>
        /// <returns></returns>

        [HttpPut("{partnerId}")]
        public IActionResult UpdatePartnerEmployee(int partnerId, [FromBody] PartnerEmployeeDTO partnerEmployeeDTO)
        {

            if (partnerEmployeeDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var checkPartnerIdinDb = _choiceRepoistory.GetPartnerEmployees().Find(c => c.PartnerEmployeeId == partnerId);

            if (checkPartnerIdinDb == null)
            {
                return BadRequest();
            }

            checkPartnerIdinDb = partnerEmployeeDTO;
            _choiceRepoistory.Complete();

            return NoContent();
        }

    }
}
