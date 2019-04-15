using System;

namespace DKBS.Domain
{
    public class Provision
    {
        public int ProvisionId { get; set; }
        public decimal Price { get; set; }
        public Booking Booking { get; set; }
        public Customer Customer { get; set; }
        public Partner Partner { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }

    }
}