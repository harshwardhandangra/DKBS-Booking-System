using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class Region
    {
        public int RegionId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
    }
}
