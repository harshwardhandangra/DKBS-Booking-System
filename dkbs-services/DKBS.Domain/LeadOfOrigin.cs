﻿using System;

namespace DKBS.Domain
{
    public class LeadOfOrigin
    {
        public int LeadOfOriginId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}