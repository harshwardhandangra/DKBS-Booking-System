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
        public int PartnerId { get; set; }
        public int MailGroupId { get; set; }
        public int PartnerTypeId { get; set; }
        public int ParticipentTypeId { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
