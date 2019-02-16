using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS_BL.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IDictionary<long, string> Customers = new Dictionary<long, string>();

        public CustomerController()
        {
            Customers.Add(1, "abc");
            Customers.Add(2, "bcd");
            Customers.Add(3, "cde");
            Customers.Add(4, "def");
            Customers.Add(5, "efg");
            Customers.Add(6, "fgh");
            Customers.Add(7, "ghi");
            Customers.Add(8, "hij");
            Customers.Add(9, "ijk");
            Customers.Add(10, "jkl");
        }

        // GET: api/Partners , Name = "GetPartnerIdByCompanyName"
        [Route("GetCustomerIdByCustomerName/{customerName}")]
        [HttpGet("{companyName}")]
        public ActionResult<long> GetCustomerIdByCustomerName(string customerName)
        {
            if (Customers.Values.Contains(customerName))
            {
                return KeyByValue(Customers, customerName);
            }
            return 0;
        }

        // GET: api/Partners/5 Name = "GetCompanyNameById"
        [Route("GetCustomerNameById/{id}")]
        [HttpGet("{id}")]
        public ActionResult<string> GetCustomerNameById(long id)
        {
            if (Customers.Keys.Contains(id))
                return Customers[id];
            return string.Empty;
        }
        [HttpGet]
        public ICollection<Customer> GetAllCustomerInfo()
        {
            ICollection<Customer> customerCollection = new List<Customer>();
            foreach (long key in Customers.Keys)
            {
                Customer cust = new Customer();
                cust.Id = key;
                cust.CustomerName = Customers[key];
                customerCollection.Add(cust);
            }
            return customerCollection;
        }
        // POST: api/Partners
        [HttpPost]
        public void SetCustomer([FromBody] Customer customer)
        {
            if (!Customers.Keys.Contains(customer.Id) && !Customers.Values.Contains(customer.CustomerName))
            {
                Customers.Add(customer.Id, customer.CustomerName);
            }
        }

        private long KeyByValue(IDictionary<long, string> dict, string val)
        {
            long key = 0;
            foreach (KeyValuePair<long, string> pair in dict)
            {
                if (pair.Value == val)
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }

    }
}
