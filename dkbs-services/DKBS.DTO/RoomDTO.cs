using System;

namespace DKBS.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public TableSetDTO TableSet { get; set; }
        public string LocalAttraction { get; set; }
        public int NumberOfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public BookingDTO Booking { get; set; }
    }
}