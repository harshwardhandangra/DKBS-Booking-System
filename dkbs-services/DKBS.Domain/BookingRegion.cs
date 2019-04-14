namespace DKBS.Domain
{
    public class BookingRegion
    {
        public int BookingRegionId { get; set; }
        public Booking Booking { get; set; }
        public Region Region { get; set; }
    }
}