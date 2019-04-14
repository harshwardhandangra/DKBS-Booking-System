using System;

namespace DKBS.Domain
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}