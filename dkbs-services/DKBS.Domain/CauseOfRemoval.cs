using System;

namespace DKBS.Domain
{
    public class CauseOfRemoval
    {
        public int CauseOfRemovalId { get; set; }

        public string CauseOfRemovalTitle { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}