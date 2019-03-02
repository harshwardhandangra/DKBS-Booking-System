using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class Partners
    {
        public int PartnerId { get; set; }
        [MaxLength(255)]
        public string PartnerName { get; set; }
        [MaxLength(255)]
        public string EmailId    { get; set; }
        public int CenterTypeId { get; set; }
        public int PartnerTypeId { get; set; }
        [MaxLength(255)]
        public string PhoneNumber { get; set; }
        public DateTime LastModified { get; set; }
        [MaxLength(255)]
        public string LastModifiedBy { get; set; }
    }
}
