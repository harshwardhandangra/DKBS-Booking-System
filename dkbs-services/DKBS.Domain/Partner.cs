﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.Domain
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string EmailId { get; set; }
        public CenterType CenterType { get; set; }
        public PartnerType PartnerType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}