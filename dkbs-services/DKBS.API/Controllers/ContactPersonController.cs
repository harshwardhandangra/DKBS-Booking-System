﻿using System;
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
        ///// Get ContactPersonByCustomerId List based on ContactId
        ///// </summary>
        ///// <param name="contactId"></param>
        ///// <returns></returns>
        ///// 
        //[Route("[action]/{contactId}",Name = "GetContactPersonByContactId")]
        //[HttpGet]
        //public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByContactId(string contactId)
        //{
        //    return _choiceRepoistory.GetContactPersons().FindAll(c => c.ContactId == contactId);
        //}


        /// <summary>
        /// Get ContactPersonByCustomerId List based on CustomerId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{accountId}", Name = "GetContactPersonByAccountId")]
        public ActionResult<IEnumerable<ContactPersonDTO>> GetContactPersonByAccountId(string accountId)
        {
            return _choiceRepoistory.GetContactPersons().FindAll(c => c.AccountId == accountId);
        }


        /// <summary>
        /// Creating ContactPerson from CRM
        /// </summary>
        /// <param name="contactPersonDTO"></param>
        /// <returns></returns>
        /// 

        [Authorize]
        [HttpPost]
        public ActionResult<ContactPersonDTO> CreateContactPerson([FromBody] ContactPersonDTO contactPersonDTO)
        {

            try
            {
                if (contactPersonDTO == null)
                {
                    ModelState.AddModelError("ContactPerson", "ContactPerson object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Intentionally commented                                               
                //var contactPersonInDb = _choiceRepoistory.GetById<ContactPerson>(c => c.AccountId == contactPersonDTO.AccountId);

                //if (contactPersonInDb != null)
                //{
                //    ModelState.AddModelError("ContactPerson", $"ContactPerson entry already exist for AccountId {contactPersonDTO.AccountId}.");
                //    return BadRequest(ModelState);
                //}

                var contactPersonInDb = _choiceRepoistory.GetById<ContactPerson>(c => c.ContactId == contactPersonDTO.ContactId && c.AccountId == contactPersonDTO.AccountId);
                if (contactPersonInDb != null)
                {
                    ModelState.AddModelError("ContactPerson", $"ContactPerson entry already exist for ContactId {contactPersonDTO.ContactId}.");
                    return BadRequest(ModelState);
                }

                ContactPerson newContactPerson = _mapper.Map<ContactPersonDTO, ContactPerson>(contactPersonDTO);

                _choiceRepoistory.Attach<ContactPerson>(newContactPerson);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetContactPersonByAccountId", new { newContactPerson.AccountId }, newContactPerson);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating ContactPerson. Please try again or contact adminstrator");
            }

        }

        /// <summary>
        /// Update Contact Person
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactPersonUpdateDTO"></param>
        /// <returns></returns>
        /// 

        [Authorize]
        [HttpPut]
        public IActionResult UpdateContactPerson(string contactId, [FromBody] ContactPersonUpdateDTO contactPersonUpdateDTO)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(contactId))
                {
                    ModelState.AddModelError("ContactId", "ContactId can't be null or empty");
                    return BadRequest(ModelState);
                }

                if (contactPersonUpdateDTO == null)
                {
                    ModelState.AddModelError("ContactPerson", "ContactPerson object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contactPersonInDb = _choiceRepoistory.GetById<ContactPerson>(c => c.ContactId == contactId && c.AccountId == contactPersonUpdateDTO.AccountId);


                if (contactPersonInDb == null)
                {
                    ModelState.AddModelError("ContactPerson", $"No contact person found with AccountId {contactId}");
                    return NotFound(ModelState);
                }

                contactPersonInDb.AccountId = contactPersonUpdateDTO.AccountId;
                contactPersonInDb.Email = contactPersonUpdateDTO.Email;
                contactPersonInDb.FirstName = contactPersonUpdateDTO.FirstName;
                contactPersonInDb.LastName = contactPersonUpdateDTO.LastName;
                contactPersonInDb.MobilePhone = contactPersonUpdateDTO.MobilePhone;
                contactPersonInDb.Telephone = contactPersonUpdateDTO.Telephone;

                _choiceRepoistory.Attach(contactPersonInDb);
                _choiceRepoistory.Complete();

                return NoContent();

            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while updating ContactPerson. Please try again or contact adminstrator");
            }
        }
    }
}
