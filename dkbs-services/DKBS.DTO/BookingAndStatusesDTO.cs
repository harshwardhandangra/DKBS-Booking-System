using System;

namespace DKBS.DTO
{
    public class BookingAndStatusesDTO
    {
        public int BookingAndStatusesId { get; set; }
        public string BookingerIncidentTitle { get; set; }
        public int SLACount { get; set; }
        public int ClosedStatus { get; set; }
        public string InformUserByEmail { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
