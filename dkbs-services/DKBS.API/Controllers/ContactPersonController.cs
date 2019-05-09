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
    /// Contact Parson
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>
        /// Contact Parson
        /// </summary>
        /// <param name="choiceReposiroty"></param>
        /// <param name="mapper"></param>
        public ContactPersonController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All ContactPersons details.
        /// </summary>
        /// <returns>List of ContactPersons.</returns>
        [HttpGet()]
        public ActionResult<ContactPersonDTO> GetContactPersons()
        {
            return Ok(_choiceRepoistory.GetContactPersons());
        }


        ///// <summary>
        ///// Get ContactPerson list based on user input of some characters
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //[HttpGet("{name}", Name = "GetContactPersonByName")]
        //public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByName(string name)
        //{
        //    return _choiceRepoistory.GetContactPersons().FindAll(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
        //}



        /// <summary>
        /// Get ContactPersonByCustomerId List based on CustomerId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}", Name = "GetContactPersonByAccountId")]
        public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByAccountId(string accountId)
        {
            return _choiceRepoistory.GetContactPersons().FindAll(c => c.AccountId == accountId);
        }


        /// <summary>
        /// Creating ContactPerson
        /// </summary>
        /// <param name="contactPersonDTO"></param>
        /// <returns></returns>
        // GET api/ContactPerson/{ContactPerson}
        [HttpPost]
        public ActionResult<IEnumerable<ContactPersonDTO>> CreateContactPerson([FromBody] ContactPersonDTO contactPersonDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (contactPersonDTO == null)
                return BadRequest();


            ContactPerson newContactPerson = _mapper.Map<ContactPersonDTO, ContactPerson>(contactPersonDTO);
            _choiceRepoistory.Attach<ContactPerson>(newContactPerson);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetContactPersonByAccountId", new { accountId = newContactPerson.AccountId }, newContactPerson);
        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="contactPersonDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateContactPerson(string accountId, [FromBody] ContactPersonDTO contactPersonDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (contactPersonDTO == null)
                return BadRequest();

            var contactPersonIdinDb = _choiceRepoistory.GetById<ContactPerson>(c => c.AccountId == accountId);

            if (contactPersonIdinDb == null)
            {
                return BadRequest();
            }

            contactPersonIdinDb.ContactId = contactPersonDTO.ContactId;
            contactPersonIdinDb.Email = contactPersonDTO.Email;
            contactPersonIdinDb.FirstName = contactPersonDTO.FirstName;
            contactPersonIdinDb.LastName = contactPersonDTO.LastName;
            contactPersonIdinDb.MobilePhone = contactPersonDTO.MobilePhone;
            contactPersonIdinDb.Telephone = contactPersonDTO.Telephone;

            _choiceRepoistory.Attach(contactPersonIdinDb);
            _choiceRepoistory.Complete();

            return NoContent();
        }
    }
}
