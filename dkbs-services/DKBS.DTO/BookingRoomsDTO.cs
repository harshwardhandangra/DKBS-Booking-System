using System;

namespace DKBS.DTO
{
    public class BookingRoomsDTO
    {
        public int BookingRoomsId { get; set; }
        public int  TableSetId { get; set; }
        public string LocalAttraction { get; set; }
        public int NumberOfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public int BookingId { get; set; }
    }
}