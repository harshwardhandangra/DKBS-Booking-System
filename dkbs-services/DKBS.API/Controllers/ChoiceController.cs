using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// This controller contains all master data.
    /// </summary>
    [Route("choice")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Will take IChoiceRepository as param
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ChoiceController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All regions details.
        /// </summary>
        /// <returns>List of regions.</returns>
        [Route("regions")]
        [HttpGet()]
        public ActionResult<RegionDTO> GetRegions()
        {
           return Ok(_choiceRepoistory.GetRegions());
        }
    }
}