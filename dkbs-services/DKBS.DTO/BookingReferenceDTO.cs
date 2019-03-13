
namespace DKBS.DTO
{
    public class BookingReferenceDTO
    {
        public int BookingReferrenceId { get; set; }
        public BookingDTO Booking { get; set; }
        public int RefferId { get; set; }
        public CampaignDTO Compign { get; set; }
       // [MaxLength(500)]
        public string Other { get; set; }
        public LeadOfOriginDTO LeadOfOrigin { get; set; }
    }
}