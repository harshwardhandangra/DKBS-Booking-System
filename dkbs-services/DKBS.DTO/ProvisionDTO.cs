using System;

namespace DKBS.DTO
{
    public class ProvisionDTO
    {
        public int ProvisionId { get; set; }
        public decimal Price { get; set; }
        public BookingDTO BookingDTO { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public PartnerDTO PartnerDTO { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }

    }
}