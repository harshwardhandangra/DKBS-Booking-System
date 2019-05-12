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
        /// Get Customer List based on search character entered by user for company name
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        [HttpGet("{companyName}", Name = "GetCustomersByCompanyName")]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomersByCompanyName(string companyName)
        {
            return _choiceRepoistory.GetCustomers().FindAll(c => c.CompanyName.Contains(companyName));
        }

        /// <summary>
        /// Creating Customer from CRM
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPost]
        public ActionResult<IEnumerable<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO customerDto)
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

            Customer newCustomer = _mapper.Map<CustomerDTO, Customer>(customerDto);

            _choiceRepoistory.Attach<Customer>(newCustomer);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetCustomersByCompanyName", new { accountId = newCustomer.AccountId }, newCustomer);
        }


        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="customerDTO"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPut("{accountId}")]
        public IActionResult UpdateCustomer(string accountId, [FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                ModelState.AddModelError("accountId", "accountId can't be empty");
                return BadRequest(ModelState);
            }

            if (customerDTO == null)
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
                return NotFound();
            }

            customer.Address1 = customerDTO.Address1;
            customer.Address2 = customerDTO.Address2;
            customer.CompanyName = customerDTO.CompanyName;
            customer.Country = customerDTO.Country;
            customer.IndustryCode = customerDTO.IndustryCode;
            customer.PhoneNumber = customerDTO.PhoneNumber;
            customer.PostNumber = customerDTO.PostNumber;
            customer.StateAgreement = customerDTO.StateAgreement;
            customer.Town = customerDTO.Town;

            _choiceRepoistory.Attach(customer);
            _choiceRepoistory.Complete();

            return NoContent();
        }

    }
}