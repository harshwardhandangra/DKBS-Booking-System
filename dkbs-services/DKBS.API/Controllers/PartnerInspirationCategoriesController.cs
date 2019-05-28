using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKBS.API.Controllers
{

    /// <summary>
    /// PartnerInspirationCategoriesController
    /// </summary>
    /// 


    [Route("api/[controller]")]
    [ApiController]
    public class PartnerInspirationCategoriesController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterRoomInfo
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public PartnerInspirationCategoriesController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All GetPartnerCenterRoomInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<PartnerInspirationCategories> GetPartnerInspirationCategories()
        {
            return Ok(_choiceRepoistory.GetPartnerInspirationCategories());
        }

        /// <summary>
        /// Get PartnerInspirationCategories_Id by id
        /// </summary>
        /// <param name="PartnerInspirationCategories_Id"></param>
        /// <returns></returns>
        [HttpGet("{PartnerInspirationCategories_Id}")]
        public ActionResult<PartnerInspirationCategoriesDTO> GetPartnerInspirationCategories(int PartnerInspirationCategories_Id)
        {
            return _choiceRepoistory.GetPartnerInspirationCategories().FirstOrDefault(c => c.PartnerInspirationCategories_Id == PartnerInspirationCategories_Id);
        }

        /// <summary>
        /// Get PartnerInspirationCategories_Id by PartnerId
        /// </summary>
        /// <param name="PartnerId"></param>
        /// <returns></returns>
        [Route("GetByPartnerId")]
        [HttpGet()]
        public ActionResult<PartnerInspirationCategoriesDTO> GetById(int PartnerId)
        {
            return _choiceRepoistory.GetPartnerInspirationCategories().FirstOrDefault(c => c.PartnerId == PartnerId);
        }


        /// <summary>y
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="PartnerInspirationCategories_Id"></param>
        /// <param name="partnerInspirationCategoriesDTO"></param>
        /// <returns></returns>

        [HttpPut("{PartnerInspirationCategories_Id}")]
        public IActionResult UpdatepartnerCenterRoomInfo(int PartnerInspirationCategories_Id, [FromBody] PartnerInspirationCategoriesDTO partnerInspirationCategoriesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerInspirationCategoriesDTO == null)
            {
                return BadRequest();
            }

            var partnerInspirationCategories = _choiceRepoistory.GetPartnerInspirationCategories().Find(c => c.PartnerInspirationCategories_Id == PartnerInspirationCategories_Id);

            if (partnerInspirationCategories == null)
            {
                return BadRequest();
            }

            partnerInspirationCategories = partnerInspirationCategoriesDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }


        /// <summary>
        /// Creating PartnerCenterRoomInfo
        /// </summary>
        /// <param name="partnerInspirationCategoriesDTO"></param>
        /// <returns></returns>
        // GET api/PartnerInspirationCategories/{PartnerInspirationCategories}
        [HttpPost]
        public ActionResult<IEnumerable<PartnerInspirationCategoriesDTO>> PartnerInspirationCategories([FromBody] PartnerInspirationCategoriesDTO partnerInspirationCategoriesDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerInspirationCategoriesDTO == null)
            {
                return BadRequest();
            }

            var checkPartnerCenterRoomInfoIdinDb = _choiceRepoistory.GetPartnerInspirationCategories().Find(c => c.PartnerInspirationCategories_Id == partnerInspirationCategoriesDTO.PartnerInspirationCategories_Id);

            if (checkPartnerCenterRoomInfoIdinDb != null)
            {
                return BadRequest();
            }

            PartnerInspirationCategories newlypartnerInspirationCategoriesDTO = new PartnerInspirationCategories()
            {
                PartnerInspirationCategories_Id = partnerInspirationCategoriesDTO.PartnerInspirationCategories_Id,
                PartnerId = partnerInspirationCategoriesDTO.PartnerId,
                // Room_Name = partnerInspirationCategoriesDTO.Room_Name,
                Heading = partnerInspirationCategoriesDTO.Heading,
                Description = partnerInspirationCategoriesDTO.Description,
                Price = partnerInspirationCategoriesDTO.Price,
                ApprovalStatus = partnerInspirationCategoriesDTO.ApprovalStatus,
                //LastModifiedBY = partnerCenterRoomInfoDTO.LastModifiedBY,
                //LastModified = partnerCenterRoomInfoDTO.LastModified
            };
            //  var destination = Mapper.Map<PartnerCenterRoomInfo, PartnerCenterRoomInfoDTO>(newlyCreatedPartnerCenterRoomInfo);


            //_choiceRepoistory.GetPartnerCenterRoomInfo().Add(destination);
            //_choiceRepoistory.Complete();

            _choiceRepoistory.SetpartnerInspirationCategories(newlypartnerInspirationCategoriesDTO);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetPartnerCenterRoomInfo", new { name = newlypartnerInspirationCategoriesDTO.Heading }, newlypartnerInspirationCategoriesDTO);
        }

    }
}
