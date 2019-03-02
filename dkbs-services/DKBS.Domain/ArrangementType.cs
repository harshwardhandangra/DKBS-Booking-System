using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class ArrangementType
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ServiceCatlogueId { get; set; }
        public int NumberOfPerticipants { get; set; }
        public DateTime ToDate{ get; set; }
        public DateTime FromDate { get; set; }
    }
}
