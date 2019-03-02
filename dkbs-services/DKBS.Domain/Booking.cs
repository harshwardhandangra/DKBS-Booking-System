using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
   public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        //public int ContactPersonId { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public int FlexibleDates { get; set; }
        [MaxLength(500)]
        public string InternalHistory { get; set; }
    }
}
