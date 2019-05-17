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
    /// PartnerEmployee controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerEmployeeController : ControllerBase
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
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> GetPartnerEmployeesByPartnerId(string PartnerId)
        {
            return _choiceRepoistory.GetPartnerEmployees().FindAll(c => c.Partner == PartnerId);
        }

        /// <summary>
        /// Get PartnerEmployee List based on some character entered by user in Partner name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetPartnerEmployee")]
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> GetPartnerEmployees(string name)
        {
            return _choiceRepoistory.GetPartnerEmployees().FindAll(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
        }

        /// <summary>
        /// Creating PartnerEmployee
        /// </summary>
        /// <param name="partnerEmployeeDto"></param>
        /// <returns></returns>
        // GET api/PartnerEmployee/{PartnerEmployee}
        [Authorize]
        [HttpPost()]
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

            //var centerType = _mapper.Map<CenterTypeDTO, CenterType>(partnerEmployeeDto.PartnerDTO.CenterTypeDTO);
            //var partnerType = _mapper.Map<PartnerTypeDTO, PartnerType>(partnerEmployeeDto.PartnerDTO.PartnerTypeDTO);
            
            // TODO: check and use map functionlity of mapping properties
            //var partner = new Partner()
            //{
            //    CenterType = centerType,
            //    PartnerType = partnerType,
            //    EmailId = partnerEmployeeDto.Email,
            //    PartnerId = partnerEmployeeDto.PartnerDTO.PartnerId,
            //    PartnerName = partnerEmployeeDto.PartnerDTO.PartnerName,
            //     PhoneNumber = partnerEmployeeDto.PartnerDTO.PhoneNumber,
            //    LastModified = partnerEmployeeDto.PartnerDTO.LastModified,
            //    LastModifiedBy = partnerEmployeeDto.PartnerDTO.LastModifiedBy
            //};

          //  var participantType = _mapper.Map<ParticipantTypeDTO, ParticipantType>(partnerEmployeeDto.ParticipantTypeDTO);
          //  var mailGroup = _mapper.Map<MailGroupDTO, MailGroup>(partnerEmployeeDto.MailGroup);


            PartnerEmployee newlyCreatedPartnerEmployee = new PartnerEmployee()
            {
                FirstName = partnerEmployeeDto.FirstName,
                LastName = partnerEmployeeDto.LastName,
               // PartnerEmployeeId = partnerEmployeeDto.PartnerEmployeeId,
                Email = partnerEmployeeDto.Email,
               // ParticipantType = participantType,
                JobTitle = partnerEmployeeDto.JobTitle,
              //  PartnerType = partnerType,
                MailGroup = partnerEmployeeDto.MailGroup,
                PESharePointId = partnerEmployeeDto.PESharePointId,
                TelePhoneNumber = partnerEmployeeDto.TelePhoneNumber,
                Partner = partnerEmployeeDto.Partner,
                LastModified = partnerEmployeeDto.LastModified,
                LastModifiedBY = partnerEmployeeDto.LastModifiedBY,
                CreatedBy = partnerEmployeeDto.CreatedBy,
                CreatedOn = partnerEmployeeDto.CreatedOn,
                ModifiedBY = partnerEmployeeDto.ModifiedBY,
                ModifiedOn = partnerEmployeeDto.ModifiedOn,
                SMSNotification = partnerEmployeeDto.SMSNotification,
                EmailNotification = partnerEmployeeDto.EmailNotification,
                Identifier = partnerEmployeeDto.Identifier,
                DeactivatedUser = partnerEmployeeDto.DeactivatedUser,
                
            };

           // var destination = _mapper.Map<PartnerEmployee, PartnerEmployeeDTO>(newlyCreatedPartnerEmployee);
            _choiceRepoistory.SetPartnerEmployees(newlyCreatedPartnerEmployee);
            _choiceRepoistory.Complete();

            CRMPartnerEmployeeDTO cRMPartnerEmployeeDTO = new CRMPartnerEmployeeDTO
            {
                FirstName = newlyCreatedPartnerEmployee.FirstName,
                LastName = newlyCreatedPartnerEmployee.LastName,
                Email = newlyCreatedPartnerEmployee.Email,
                TelePhoneNumber = newlyCreatedPartnerEmployee.TelePhoneNumber,
                // In future we have to get the account Id from Partner
                PartnerId = newlyCreatedPartnerEmployee.Partner,
                PartnerEmployeeId = newlyCreatedPartnerEmployee.PESharePointId,
                JobTitle = newlyCreatedPartnerEmployee.JobTitle,
                MailGroup = newlyCreatedPartnerEmployee.MailGroup,

            };


            return CreatedAtRoute("GetPartnerEmployee", new { name = newlyCreatedPartnerEmployee.FirstName }, newlyCreatedPartnerEmployee);
        }

        /// <summary>
        /// Updating partner employess
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="partnerEmployeeDTO"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{partnerEmployeeId}")]
        public IActionResult UpdatePartnerEmployee(string partnerEmployeeId, [FromBody] PartnerEmployeeDTO partnerEmployeeDTO)
        {

            if (partnerEmployeeDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var checkPartnerIdinDb = _choiceRepoistory.GetById<PartnerEmployee>(c => c.PESharePointId == partnerEmployeeId);//_choiceRepoistory.GetPartnerEmployees().Find(c => c.SharePointId == partnerEmployeeId);

            if (checkPartnerIdinDb == null)
            {
                return BadRequest();
            }

            //checkPartnerIdinDb = partnerEmployeeDTO;


             checkPartnerIdinDb.FirstName = partnerEmployeeDTO.FirstName;
            checkPartnerIdinDb.LastName = partnerEmployeeDTO.LastName;
            // PartnerEmployeeId = partnerEmployeeDto.PartnerEmployeeId,
            checkPartnerIdinDb.Email = partnerEmployeeDTO.Email;
                // ParticipantType = participantType,
                checkPartnerIdinDb.JobTitle = partnerEmployeeDTO.JobTitle;
            //  PartnerType = partnerType,
            checkPartnerIdinDb.MailGroup = partnerEmployeeDTO.MailGroup;


           // checkPartnerIdinDb.SharePointId = partnerEmployeeDTO.SharePointId;


            checkPartnerIdinDb.TelePhoneNumber = partnerEmployeeDTO.TelePhoneNumber;


            checkPartnerIdinDb.Partner = partnerEmployeeDTO.Partner;


                 checkPartnerIdinDb.LastModified = partnerEmployeeDTO.LastModified;


            checkPartnerIdinDb.LastModifiedBY = partnerEmployeeDTO.LastModifiedBY;


            checkPartnerIdinDb.CreatedBy = partnerEmployeeDTO.CreatedBy;


                checkPartnerIdinDb.CreatedOn = partnerEmployeeDTO.CreatedOn;


            checkPartnerIdinDb.ModifiedBY = partnerEmployeeDTO.ModifiedBY;


            checkPartnerIdinDb.ModifiedOn = partnerEmployeeDTO.ModifiedOn;


                checkPartnerIdinDb.SMSNotification= partnerEmployeeDTO.SMSNotification;


            checkPartnerIdinDb.EmailNotification = partnerEmployeeDTO.EmailNotification;
                
               
                checkPartnerIdinDb.Identifier = partnerEmployeeDTO.Identifier;
                


                checkPartnerIdinDb.DeactivatedUser = partnerEmployeeDTO.DeactivatedUser;


            
            _choiceRepoistory.Attach(checkPartnerIdinDb);
            _choiceRepoistory.Complete();

            return NoContent();
        }

    }
}
