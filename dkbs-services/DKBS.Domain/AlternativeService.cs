namespace DKBS.Domain
{
    public class AlternativeService
    {
        public int Id { get; set; }
        public int NumberOfPieces { get; set; }
        
        //[MaxLength(255)]
        public string Description { get; set; }

        public Booking Booking { get; set; }
    }
}