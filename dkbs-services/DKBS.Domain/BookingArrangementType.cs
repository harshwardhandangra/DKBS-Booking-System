using System;

namespace DKBS.Domain
{
    public class BookingArrangementType
    {
        public int BookingArrangementTypeId { get; set; }
        public int BookingId { get; set; }
        public int ServiceCatalogueId { get; set; }
        // TODO if it is a table then only need to define the navigation property
        //public int ServiceCatlogueId { get; set; }
        public int NumberOfParticipants { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        
    }
}