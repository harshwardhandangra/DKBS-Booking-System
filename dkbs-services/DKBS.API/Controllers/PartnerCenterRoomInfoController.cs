﻿using AutoMapper;
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
    /// PartnerCenterRoomInfoController
    /// </summary>
    /// 


    [Route("api/[controller]")]
    [ApiController]
    public class PartnerCenterRoomInfoController : Controller
    {
        private IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// PartnerCenterRoomInfo
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public PartnerCenterRoomInfoController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All GetPartnerCenterRoomInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<PartnerCenterRoomInfoDTO> GetPartnerCenterRoomInfo()
        {
            return Ok(_choiceRepoistory.GetPartnerCenterRoomInfo());
        }

        /// <summary>
        /// Get PartnerCenterRoomInfo_Id by id
        /// </summary>
        /// <param name="PartnerCenterRoomInfo_Id"></param>
        /// <returns></returns>
        [HttpGet("{PartnerCenterRoomInfo_Id}")]
        public ActionResult<PartnerCenterRoomInfoDTO> GetPartnerCenterRoomInfo(int PartnerCenterRoomInfo_Id)
        {
            return _choiceRepoistory.GetPartnerCenterRoomInfo().FirstOrDefault(c => c.PartnerCenterRoomInfo_Id == PartnerCenterRoomInfo_Id);
        }

        /// <summary>
        /// Update UpdatePartnerCenterInfo
        /// </summary>
        /// <param name="PartnerCenterRoomInfo_Id"></param>
        /// <param name="partnerCenterRoomInfoDTO"></param>
        /// <returns></returns>

        [HttpPut("{PartnerCenterInfo_Id}")]
        public IActionResult UpdatepartnerCenterRoomInfo(int PartnerCenterRoomInfo_Id, [FromBody] PartnerCenterRoomInfoDTO partnerCenterRoomInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterRoomInfoDTO == null)
                return BadRequest();

            var partnerCenterRoomInfo = _choiceRepoistory.GetPartnerCenterRoomInfo().Find(c => c.PartnerCenterRoomInfo_Id == PartnerCenterRoomInfo_Id);

            if (partnerCenterRoomInfo == null)
            {
                return BadRequest();
            }

            partnerCenterRoomInfo = partnerCenterRoomInfoDTO;

            _choiceRepoistory.Complete();
            return NoContent();
        }


        /// <summary>
        /// Creating PartnerCenterRoomInfo
        /// </summary>
        /// <param name="partnerCenterRoomInfoDTO"></param>
        /// <returns></returns>
        // GET api/PartnerCenterRoomInfo/{PartnerCenterRoomInfos}
        [HttpPost]
        public ActionResult<IEnumerable<PartnerCenterRoomInfoDTO>> PartnerCenterRoomInfo([FromBody] PartnerCenterRoomInfoDTO partnerCenterRoomInfoDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (partnerCenterRoomInfoDTO == null)
                return BadRequest();

            var checkPartnerCenterRoomInfoIdinDb = _choiceRepoistory.GetPartnerCenterRoomInfo().Find(c => c.PartnerCenterRoomInfo_Id == partnerCenterRoomInfoDTO.PartnerCenterRoomInfo_Id);

            if (checkPartnerCenterRoomInfoIdinDb != null)
            {
                return BadRequest();
            }

            PartnerCenterRoomInfo newlyCreatedPartnerCenterRoomInfo = new PartnerCenterRoomInfo() { PartnerCenterRoomInfo_Id = partnerCenterRoomInfoDTO.PartnerCenterRoomInfo_Id, PartnerId = partnerCenterRoomInfoDTO.PartnerId, Room_Name = partnerCenterRoomInfoDTO.Room_Name, LastModifiedBY = partnerCenterRoomInfoDTO.LastModifiedBY, LastModified = partnerCenterRoomInfoDTO.LastModified };
            var destination = Mapper.Map<PartnerCenterRoomInfo, PartnerCenterRoomInfoDTO>(newlyCreatedPartnerCenterRoomInfo);


            _choiceRepoistory.GetPartnerCenterRoomInfo().Add(destination);
            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetPartnerCenterRoomInfo", new { name = newlyCreatedPartnerCenterRoomInfo.Room_Name }, newlyCreatedPartnerCenterRoomInfo);
        }


    }

}
