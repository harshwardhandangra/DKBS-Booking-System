﻿using System;

namespace DKBS.Domain
{
    public class CauseOfRemoval
    {
        public int CauseOfRemovalId { get; set; }
        public string CauseOfRemovalTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}