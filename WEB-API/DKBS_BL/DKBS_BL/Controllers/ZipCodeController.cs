using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.Controllers
{
    [Route("api/ZipCode")]
    [ApiController]
    public class ZipCodeController : ControllerBase
    {
        IDictionary<long, int> zipCodes = new Dictionary<long, int>();

        public ZipCodeController()
        {
            zipCodes.Add(1, 505001);
            zipCodes.Add(2, 505327);
            zipCodes.Add(3, 500047);
            zipCodes.Add(4, 500038);
            zipCodes.Add(5, 500040);
            zipCodes.Add(6, 505328);
            zipCodes.Add(7, 505329);
            zipCodes.Add(8, 505326);
            zipCodes.Add(9, 505325);
            zipCodes.Add(10, 505324);

        }
        // GET: api/ZipCode
        [HttpGet]
        public ICollection<Zip> Get()
        {
            ICollection<Zip> zipCodeCollection = new List<Zip>();
            foreach (long key in zipCodes.Keys)
            {
                Zip zip = new Zip();
                zip.Id = key;
                zip.ZipCode = zipCodes[key];
                zipCodeCollection.Add(zip);
            }
            return zipCodeCollection;
        }

         // POST: api/ZipCode
        [HttpPost]
        public void SetZipCode([FromBody] Zip zipCode)
        {
            if (!zipCodes.Keys.Contains(zipCode.Id) && !zipCodes.Values.Contains(zipCode.ZipCode))
            {
                zipCodes.Add(zipCode.Id, zipCode.ZipCode);
            }
        }
      
    }
}
