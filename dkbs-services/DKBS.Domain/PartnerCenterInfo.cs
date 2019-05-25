using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class PartnerCenterInfo
    {
        //[Key]
        //public int PartnerCenterInfo_Id { get; set; }
        //public int Total_Rooms { get; set; }
        //public int Group_Rooms { get; set; }
        //public DateTime LastModified { get; set; }
        //public string Max_space_at_row_of_chairs { get; set; }
        //public string Maxspace_at_tables { get; set; }
        //public Boolean State_agreement { get; set; }
        //public int MaxAccommodation { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }

        [Key]
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
