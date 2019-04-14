using System;

namespace DKBS.DTO
{
    public class PartnerEmployeeDTO
    {
        public int PartnerEmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string TelePhoneNumber { get; set; }
        public string Email { get; set; }
        public PartnerDTO PartnerDTO { get; set; }
        public MailGroupDTO MailGroupDTO { get; set; }
        public PartnerTypeDTO PartnerTypeDTO { get; set; }
        public ParticipantTypeDTO ParticipantTypeDTO { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
