using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Address1 { get; set; }
        [MaxLength(500)]
        public string Address2 { get; set; }
        [MaxLength(50)]
        public string ZipCode { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(200)]
        public string City { get; set; }
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime  CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
