using System;

namespace DKBS.DTO
{
    public class ContactPersonDTO
    {
        public int ContactPersonId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}