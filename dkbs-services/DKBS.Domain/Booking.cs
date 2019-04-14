using System;

namespace DKBS.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Partner Partner { get; set; }
        public Customer Customer { get; set; }
        public TableType TableType { get; set; }
        public CancellationReason CancellationReason { get; set; }
        public CauseOfRemoval CauseOfRemoval { get; set; }
        public ContactPerson ContactPerson { get; set; }
        public BookingAndStatus BookingAndStatus { get; set; }
        public Flow Flow { get; set; }
        public MailLanguage MailLanguage { get; set; }
        public PartnerType PartnerType { get; set; }
        public ParticipantType ParticipantType { get; set; }
        public Purpose Purpose { get; set; }
        public LeadOfOrigin LeadOfOrigin { get; set; }
        public Campaign Campaign { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public bool FlexibleDates { get; set; }
        public string InternalHistory { get; set; }

    }
}