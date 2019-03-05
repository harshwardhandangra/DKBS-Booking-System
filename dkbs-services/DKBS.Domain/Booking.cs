using System;

namespace DKBS.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }
        public ContactPerson ContactPersons { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public int FlexibleDates { get; set; }
        public string InternalHistory { get; set; }
        public Customer Customer { get; set; }
    }
}