using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class Rooms
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int TableSetId { get; set; }
        [MaxLength(255)]
        public string LocalAttraction { get; set; }
        public int NumberPfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
    }
}
