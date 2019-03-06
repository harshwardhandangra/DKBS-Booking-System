﻿using System;

namespace DKBS.DTO
{
    public class IndustryCodeDTO
    {
        public int IndustryCodeId { get; set; }

        public string IndustryCodeTitle { get; set; }

        public bool IsNewBranch { get; set; } 

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}