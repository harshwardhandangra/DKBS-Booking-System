﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKBS.Domain
{
    public class IndustryCode
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IndustryCodeId { get; set; }
        public string IndustryCodeTitle { get; set; }
        public bool IsNewBranch { get; set; } 
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}