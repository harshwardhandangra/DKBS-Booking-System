using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.Domain
{
   public  class BookingRegions
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RegionId { get; set; }
    }
}
