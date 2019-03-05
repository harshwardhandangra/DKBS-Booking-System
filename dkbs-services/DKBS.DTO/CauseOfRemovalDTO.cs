using System;

namespace DKBS.DTO
{
    public class CauseOfRemovalDTO
    {
        public int CauseOfRemovalId { get; set; }

        public string CauseOfRemovalTitle { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}