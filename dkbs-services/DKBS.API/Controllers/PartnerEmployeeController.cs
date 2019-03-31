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
        public ActionResult<IEnumerable<PartnerEmployeeDTO>> CreatePartner([FromBody] PartnerEmployeeDTO partnerEmployeeDto)
        {

            if (ModelState.IsValid)
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

            PartnerEmployee newlyCreatedPartnerEmployee = new PartnerEmployee() { EmployeeName = partnerEmployeeDto.EmployeeName, PartnerEmployeeId = partnerEmployeeDto.PartnerEmployeeId, Email = partnerEmployeeDto.Email, ParticipentTypeId = partnerEmployeeDto.ParticipentTypeId, JobTitle = partnerEmployeeDto.JobTitle, PartnerTypeId = partnerEmployeeDto.PartnerTypeId, MailGroupId = partnerEmployeeDto.MailGroupId, TelePhoneNumber = partnerEmployeeDto.TelePhoneNumber, PartnerId = partnerEmployeeDto.PartnerId, LastModified = partnerEmployeeDto.LastModified, LastModifiedBY = partnerEmployeeDto.LastModifiedBY};
            var destination = _mapper.Map<PartnerEmployee, PartnerEmployeeDTO>(newlyCreatedPartnerEmployee);


            _choiceRepoistory.GetPartnerEmployees().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetPartnerEmployees", new { name = newlyCreatedPartnerEmployee.EmployeeName }, newlyCreatedPartnerEmployee);
        }
    }
}
