using System;

namespace DKBS.DTO
{
    public class ProcedureDTO
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public CauseOfRemovalDTO CauseOfRemoval { get; set; }
        public ProcedureReviewTypeDTO ProcedureReviewType { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public BookingDTO Booking { get; set; }
        public PartnerDTO Partner { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}