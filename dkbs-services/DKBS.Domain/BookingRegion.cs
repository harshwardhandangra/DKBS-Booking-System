namespace DKBS.Domain
{
    public class BookingRegion
    {
        public int BookingRegionsId { get; set; }
        public int BookingId { get; set; }
        public int RegionId { get; set; }
    }
}