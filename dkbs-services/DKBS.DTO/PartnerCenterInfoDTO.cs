using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.DTO
{
    public class PartnerCenterInfoDTO
    {
        public int PartnerCenterInfo_Id { get; set; }
        public int Total_Rooms { get; set; }
        public int Group_Rooms { get; set; }
      //  public DateTime LastModified { get; set; }
        public string Max_space_at_row_of_chairs { get; set; }
        public string Maxspace_at_tables { get; set; }
        public Boolean State_agreement { get; set; }
        public string MaxAccommodation { get; set; }
        public int PartnerId { get; set; }


    }
}
