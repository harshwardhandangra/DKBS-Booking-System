using System;

namespace DKBS.DTO
{
    public class ArrangementTypeDTO
    {
        public int ArrangementTypeId { get; set; }

        // TODO if it is a table then only need to define the navigation property
        //public int ServiceCatlogueId { get; set; }
        public int NumberOfPerticipants { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public BookingDTO Booking { get; set; }
    }
}