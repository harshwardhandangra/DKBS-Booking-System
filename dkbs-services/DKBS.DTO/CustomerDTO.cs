﻿using System;

namespace DKBS.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        //public IndustryCodeDTO IndustryCodeDTO { get; set; }
        public string IndustryCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBY { get; set; }
    }
}