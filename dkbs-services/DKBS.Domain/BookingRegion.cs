namespace DKBS.Domain
{
    public class BookingRegion
    {
        public int BookingRegionsId { get; set; }
        public Booking Bookings { get; set; }
        public Region Regions { get; set; }
    }
}