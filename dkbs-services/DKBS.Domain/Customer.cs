using System;

namespace DKBS.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string PostNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public bool StateAgreement { get; set; }
        public string AccountId { get; set; }
        public string IndustryCode { get; set; }

    }
}