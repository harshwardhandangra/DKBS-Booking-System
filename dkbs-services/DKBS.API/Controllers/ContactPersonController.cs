﻿using System;
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
        /// <summary>
        /// Get ContactPerson list based on user input of some characters
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetContactPerson")]
        public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPerson(string name)
        {
            return _choiceRepoistory.GetContactPersons().FindAll(c => c.Name.Contains(name));
        }

        /// <summary>
        /// Get ContactPersonByCustomerId List based on CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet("{CustomerId}", Name = "GetContactPersonByCustomerId")]
        public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByCustomerId(int CustomerId)
        {
            return _choiceRepoistory.GetContactPersons().FindAll(c => c.CustomerId == CustomerId);
        }

        /// <summary>
        /// Creating ContactPerson
        /// </summary>
        /// <param name="contactPersonDTO"></param>
        /// <returns></returns>
        // GET api/ContactPerson/{ContactPerson}
        [HttpPost("{ContactPerson}")]
        public ActionResult<IEnumerable<ContactPersonDTO>> CreateContactPerson([FromBody] ContactPersonDTO contactPersonDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (contactPersonDTO == null)
                return BadRequest();

            var checkContactPersonIdinDb = _choiceRepoistory.GetContactPersons().Find(c => c.ContactPersonId == contactPersonDTO.ContactPersonId);

            if (checkContactPersonIdinDb != null)
            {
                return BadRequest();
            }

            ContactPerson newlyCreatedContactPerson = new ContactPerson() { Name = contactPersonDTO.Name, CustomerId = contactPersonDTO.CustomerId, /*Department = contactPersonDTO.Department,*/ Email = contactPersonDTO.Email, ContactPersonId = contactPersonDTO.ContactPersonId, /*Mobile = contactPersonDTO.Mobile, Position = contactPersonDTO.Position, */Telephone = contactPersonDTO.Telephone };
            var destination = _mapper.Map<ContactPerson, ContactPersonDTO>(newlyCreatedContactPerson);


            _choiceRepoistory.GetContactPersons().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetContactPerson", new { name = newlyCreatedContactPerson.Name }, newlyCreatedContactPerson);
        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="ContactPersonId"></param>
        /// <param name="contactPersonDTO"></param>
        /// <returns></returns>
        [HttpPut("{ContactPersonId}")]
        public IActionResult UpdateContactPerson(int ContactPersonId, [FromBody] ContactPersonDTO contactPersonDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (contactPersonDTO == null)
                return BadRequest();

            var checkContactPersonIdinDb = _choiceRepoistory.GetContactPersons().Find(c => c.ContactPersonId == ContactPersonId);

            if (checkContactPersonIdinDb == null)
            {
                return BadRequest();
            }

            checkContactPersonIdinDb = contactPersonDTO;
            _choiceRepoistory.Complete();

            return NoContent();
        }
    }
}
