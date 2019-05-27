using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class PartnerCenterRoomInfo
    {
        [Key]
        public int PartnerCenterRoomInfo_Id { get; set; }
        public int PartnerId { get; set; }
        public string Room_Name { get; set; }
        //public DateTime LastModified { get; set; }
        //public string LastModifiedBY { get; set; }
        public string PartnerCenterRoomInfoSpId { get; set; }

    }
}
