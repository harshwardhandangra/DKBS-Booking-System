using System;

namespace DKBS.DTO
{
    public class PartnerDTO
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string EmailId { get; set; }
        public CenterTypeDTO CenterTypeId { get; set; }
        public PartnerTypeDTO PartnerType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}