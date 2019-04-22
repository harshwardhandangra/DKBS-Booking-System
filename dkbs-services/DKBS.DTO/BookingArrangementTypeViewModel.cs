using DKBS.Domain;
using System;

namespace DKBS.DTO
{
    public class BookingArrangementTypeViewModel
    {
        public ServiceCatalogViewModel ServiceCatalogViewModel { get; set; }
        public int NumberOfParticipants { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
    }
}