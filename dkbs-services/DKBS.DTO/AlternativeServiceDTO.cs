namespace DKBS.DTO
{
    public class AlternativeServiceDTO
    {
        public int Id { get; set; }
        public int NumberOfPieces { get; set; }
        
        //[MaxLength(255)]
        public string Description { get; set; }

        public BookingDTO Booking { get; set; }
    }
}