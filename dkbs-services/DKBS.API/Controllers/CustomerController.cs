using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DKBS.API.Controllers
{
    /// <summary>
    /// Customer Controller
    /// </summary>
    /// 
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>
        /// Customer Controller
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="choiceReposiroty"></param>
        public CustomerController(IChoiceRepository choiceReposiroty, IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<CustomerDTO> GetCustomers()
        {
            return Ok(_choiceRepoistory.GetCustomers());
        }
        /// <summary>
        /// Get Customer details by account id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}", Name = "GetCustomerByAccountId")]
        public ActionResult<CustomerDTO> GetCustomerByAccountId(string accountId)
        {
            return _choiceRepoistory.GetCustomers().Find(c => c.AccountId == accountId);
        }

        /// <summary>
        /// Creating Customer from CRM
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        ///
        [Authorize]
        [HttpPost]
        public ActionResult<CustomerDTO> CreateCustomer([FromBody] CustomerDTO customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    ModelState.AddModelError("Customer", "Customer object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var customer = _choiceRepoistory.GetById<Customer>(c => c.AccountId == customerDto.AccountId);

                if (customer != null)
                {
                    ModelState.AddModelError("Customer", $"Customer entry already exist for AccountId {customerDto.AccountId}.");
                    return BadRequest(ModelState);
                }

                Customer newCustomer = _mapper.Map<CustomerDTO, Customer>(customerDto);

                _choiceRepoistory.Attach<Customer>(newCustomer);
                _choiceRepoistory.Complete();

                return CreatedAtRoute("GetCustomerByAccountId", new { newCustomer.AccountId }, newCustomer);
            }
            catch (Exception ex)
            {
                // TODO : Add logging and decide on showing ex.message
                return StatusCode(500, "An error occurred while creating Customer. Please try again or contact adminstrator"); 
            }

        }


        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="customerUpdateDTO"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPut("{accountId}")]
        public IActionResult UpdateCustomer(string accountId, [FromBody] CustomerUpdateDTO  customerUpdateDTO)
        {

            try
            {
                if(string.IsNullOrWhiteSpace(accountId))
                {
                    ModelState.AddModelError("AccountId", "AccountId can't be null or empty.");
                    return BadRequest(ModelState);
                }

                if (customerUpdateDTO == null)
                {
                    ModelState.AddModelError("Customer", "Customer object can't be null");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var customer = _choiceRepoistory.GetById<Customer>(c => c.AccountId == accountId);

                if (customer == null)
                {
                    ModelState.AddModelError("Customer", $"No customer found with AccountId {accountId}");
                    return NotFound(ModelState);
                }

                customer.Address1 = customerUpdateDTO.Address1;
                customer.Address2 = customerUpdateDTO.Address2;
                customer.CompanyName = customerUpdateDTO.CompanyName;
                customer.Country = customerUpdateDTO.Country;
                customer.IndustryCode = customerUpdateDTO.IndustryCode;
                customer.PhoneNumber = customerUpdateDTO.PhoneNumber;
                customer.PostNumber = customerUpdateDTO.PostNumber;
                customer.StateAgreement = customerUpdateDTO.StateAgreement;
                customer.Town = customerUpdateDTO.Town;

                _choiceRepoistory.Attach(customer);
                _choiceRepoistory.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating Customer. Please try again or contact adminstrator");
            }
        }

    }
}