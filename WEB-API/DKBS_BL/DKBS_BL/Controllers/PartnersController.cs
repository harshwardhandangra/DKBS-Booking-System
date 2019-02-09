using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.BL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS_BL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        IDictionary<ulong, string> partners = new Dictionary<ulong, string>();

        public PartnersController()
        {
            partners.Add(1, "abc");
            partners.Add(2, "bcd");
            partners.Add(3, "cde");
            partners.Add(4, "def");
            partners.Add(5, "efg");
            partners.Add(6, "fgh");
            partners.Add(7, "ghi");
            partners.Add(8, "hij");
            partners.Add(9, "ijk");
            partners.Add(10, "jkl");
        }

        // GET: api/Partners , Name = "GetPartnerIdByCompanyName"
        [Route("GetPartnerIdByCompanyName/{companyName}")]
        [HttpGet("{companyName}")]
        public ActionResult<ulong> GetPartnerIdByCompanyName(string companyName)
        {
            if (partners.Values.Contains(companyName))
            {
                return KeyByValue(partners, companyName);
            }
            return 0;
        }

        // GET: api/Partners/5 Name = "GetCompanyNameById"
        [Route("GetCompanyNameById/{id}")]
        [HttpGet("{id}")]
        public ActionResult<string> GetCompanyNameById(ulong id)
        {
            if (partners.Keys.Contains(id))
                return partners[id];
            return string.Empty;
        }
        [HttpGet]
        public IDictionary<ulong, string> GetAllPartnerInfo()
        {
            return partners;
        }
        // POST: api/Partners
        [HttpPost]
        public void SetPartner([FromBody] Partner partner)
        {
            if (!partners.Keys.Contains(partner.Id) && !partners.Values.Contains(partner.CompanyName))
            {
                partners.Add(partner.Id, partner.CompanyName);            
            }            
        }

        private ulong KeyByValue(IDictionary<ulong, string> dict, string val)
        {
            ulong key = 0;
            foreach (KeyValuePair<ulong, string> pair in dict)
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
