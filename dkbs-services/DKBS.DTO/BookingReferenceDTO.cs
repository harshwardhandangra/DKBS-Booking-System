namespace DKBS.DTO
{
    public class BookingReferenceDTO
    {
        public int BookingReferrenceId { get; set; }
        public int BookingId { get; set; }
        public int ContactPersonId { get; set; }
        public int CampignId { get; set; }
       // [MaxLength(500)]
        public string Other { get; set; }
        public int LeadOfOriginId { get; set; }
    }      
}