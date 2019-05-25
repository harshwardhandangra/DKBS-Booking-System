using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
   public class PartnerInspirationCategories
    {

        [Key]
        public int PartnerInspirationCategories_Id { get; set; }
        public int PartnerId { get; set; }
        public string Room_Name { get; set; }
        public int Price { get; set; }
        public Boolean Approval_Status { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }

    }
}
