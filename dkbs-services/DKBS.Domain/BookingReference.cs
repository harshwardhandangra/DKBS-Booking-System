namespace DKBS.Domain
{
    public class BookingReference
    {
        public int BookingReferrenceId { get; set; }
        public Booking Booking { get; set; }
        public int RefferId { get; set; }
        public Compaign Compign { get; set; }
       // [MaxLength(500)]
        public string Other { get; set; }
        public LeadOfOrigin LeadOfOrigin { get; set; }
    }
}