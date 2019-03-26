using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Customer Controller
    /// </summary>
    public class CustomerController : Controller
    {
        private readonly IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>
        /// Customer Controller
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="choiceReposiroty"></param>
        public CustomerController(IChoiceRepository choiceReposiroty,IMapper mapper)
        {
            _choiceRepoistory = choiceReposiroty;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Customer List based on some character entered by user in Customer name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetCustomer")]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomer(string name)
        {
            return _choiceRepoistory.GetCustomers().FindAll(c => c.Name.Contains(name));
        }

        /// <summary>
        /// Creating Customer
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        // GET api/Customer/{customer}
        [HttpPost("{Customer}")]
        public ActionResult<IEnumerable<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO customerDto)
        {

            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            if (customerDto == null)
                return BadRequest();

            var checkCustomerIdinDb = _choiceRepoistory.GetCustomers().Find(c => c.CustomerId == customerDto.CustomerId);

            if (checkCustomerIdinDb != null)
            {
                return BadRequest();
            }

            Customer newlyCreatedCustomer = new Customer() { Name=customerDto.Name, Address1= customerDto.Address1, Address2 = customerDto.Address2, City = customerDto.City, Country = customerDto.Country, CreatedBy = customerDto.CreatedBy, CreatedDate = customerDto.CreatedDate, CustomerId = customerDto.CustomerId, ZipCode = customerDto.ZipCode, ModifiedBy = customerDto.ModifiedBy, ModifiedDate = customerDto.ModifiedDate };
            var destination = _mapper.Map<Customer, CustomerDTO>(newlyCreatedCustomer);


            _choiceRepoistory.GetCustomers().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetCustomer", new { name = newlyCreatedCustomer.Name }, newlyCreatedCustomer);
        }

    }
}