using System;

namespace DKBS.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public ContactPersonDTO ContactPersons { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public int FlexibleDates { get; set; }
        public string InternalHistory { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}