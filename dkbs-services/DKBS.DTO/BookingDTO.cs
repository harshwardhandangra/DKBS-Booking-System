using System;

namespace DKBS.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public PartnerDTO PartnerDTO { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public TableTypeDTO TableTypeDTO { get; set; }
        public CancellationReasonDTO CancellationReasonDTO { get; set; }
        public CauseOfRemovalDTO CauseOfRemovalDTO { get; set; }
        public ContactPersonDTO ContactPersonDTO { get; set; }
        public BookingAndStatusDTO BookingAndStatusDTO { get; set; }
        public FlowDTO FlowDTO { get; set; }
        public MailLanguageDTO MailLanguageDTO { get; set; }
        public PartnerTypeDTO PartnerTypeDTO { get; set; }
        public ParticipantTypeDTO ParticipantTypeDTO { get; set; }
        public PurposeDTO PurposeDTO { get; set; }
        public LeadOfOriginDTO LeadOfOriginDTO { get; set; }
        public CampaignDTO CampaignDTO { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public bool FlexibleDates { get; set; }
        public string InternalHistory { get; set; }
    }
}