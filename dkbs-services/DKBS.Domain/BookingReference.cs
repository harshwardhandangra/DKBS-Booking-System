namespace DKBS.Domain
{
    public class BookingReference
    {
        public int BookingReferenceId { get; set; }
        public int BookingId { get; set; }
        public int ContactPersonId { get; set; }
        public int CampignId { get; set; }
       // [MaxLength(500)]
        public string Other { get; set; }
        public LeadOfOrigin LeadOfOrigin { get; set; }
    }      
}