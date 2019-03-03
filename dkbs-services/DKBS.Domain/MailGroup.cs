using System;

namespace DKBS.Domain
{
    public class MailGroup
    {
        public int MailGroupId { get; set; }

        public string MailGroupTitle { get; set; }

        public string InternalName { get; set; }

        public bool IncludeInPartnerMail { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}