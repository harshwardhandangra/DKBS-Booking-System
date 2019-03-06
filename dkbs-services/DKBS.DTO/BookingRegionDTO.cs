
namespace DKBS.DTO
{
    public class BookingRegionDTO
    {
        public int BookingRegionsId { get; set; }
        public BookingDTO Bookings { get; set; }
        public RegionDTO Regions { get; set; }
    }
}