using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Provision
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ProvisionController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Provision
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ProvisionController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get provision by id
        /// </summary>
        /// <param name="provisionId"></param>
        /// <returns></returns>
        [HttpGet("{provisionId}")]
        public ActionResult<ProvisionDTO> GetProvision(int provisionId)
        {
            return _choiceRepoistory.GetProvisions().FirstOrDefault(c => c.ProvisionId == provisionId);
        }

        /// <summary>
        /// Update provision
        /// </summary>
        /// <param name="provisionId"></param>
        /// <param name="provisionDTO"></param>
        /// <returns></returns>

        [HttpPut("{provisionId}")]
        public IActionResult UpdateProvision(int provisionId, [FromBody] ProvisionDTO provisionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (provisionDTO == null)
                return BadRequest();

            var provision = _choiceRepoistory.GetProvisions().Find(c => c.ProvisionId == provisionId);

            if (provision == null)
            {
                return BadRequest();
            }

            provision = provisionDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }
    }
}