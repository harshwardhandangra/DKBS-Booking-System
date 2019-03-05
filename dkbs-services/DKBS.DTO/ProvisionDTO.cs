using System;

namespace DKBS.DTO
{
    public class ProvisionDTO
    {
        public int ProvisionId { get; set; }

        public decimal Price { get; set; }

        public BookingDTO Booking { get; set; }

        public CustomerDTO Customer { get; set; }

        public PartnerDTO Partner { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

    }
}