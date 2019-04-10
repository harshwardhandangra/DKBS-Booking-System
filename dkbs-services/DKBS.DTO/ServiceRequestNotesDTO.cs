using System;

namespace DKBS.DTO
{
    public class ServiceRequestNotesDTO
    {
        public int ServiceRequestNotesId { get; set; }
        public string SRNotesTitle { get; set; }
        public int BookingId { get; set; }
        public string  Action { get; set; }
        public string PlannedStart { get; set; }
        public string PlannedEnd { get; set; }
        public string CopyToCloseRemark { get; set; }
        public string ScheduleAction { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
