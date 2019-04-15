using System;

namespace DKBS.Domain
{
    public class BookingRooms
    {
        public int BookingRoomsId { get; set; }
        public TableSet TableSet { get; set; }
        public string LocationAttraction { get; set; }
        public int NumberOfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public Booking Booking { get; set; }
    }
}