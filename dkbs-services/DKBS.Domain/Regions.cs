using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class Regions
    {
        public int RegionId { get; set; }
        [MaxLength(2255)]
        public string Name { get; set; }
    }
}
