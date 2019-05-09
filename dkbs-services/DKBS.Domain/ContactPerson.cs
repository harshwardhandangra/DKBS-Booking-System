using System;

namespace DKBS.Domain
{
    public class ContactPerson
    {
        public int ContactPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string AccountId { get; set; }
        public string ContactId { get; set; }
    }
}