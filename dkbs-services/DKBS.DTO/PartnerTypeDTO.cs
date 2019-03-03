using System;

namespace DKBS.DTO
{
    public class PartnerTypeDTO
    {
        public int PartnerTypeId { get; set; }

        public string PartnerTypeTitle { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}