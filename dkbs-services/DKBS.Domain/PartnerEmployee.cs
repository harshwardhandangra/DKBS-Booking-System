using System;

namespace DKBS.Domain
{
    public class PartnerEmployee
    {      
        public int PartnerEmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string TelePhoneNumber { get; set; }
        public string Email { get; set; }
        public Partner Partner { get; set; }
        public MailGroup MailGroup { get; set; }
        public PartnerType PartnerType  { get; set; }
        public ParticipantType ParticipantType { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
