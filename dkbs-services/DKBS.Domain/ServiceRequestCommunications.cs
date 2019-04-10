using System;

namespace DKBS.Domain
{
    public class ServiceRequestCommunications
    {
        public int ServiceRequestCommunicationsId { get; set; }
        public string SRCTitle { get; set; }
        public int BookingId { get; set; }
        public string Communications { get; set; }
        public string FromMyIT { get; set; }
        public string CopyToCloseRemark { get; set; }
        public int ProceduresId { get; set; }
        public string IsPartnerSideCommunication { get; set; }
        public string ProcedureInfoCommunication { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
             
    }
}
