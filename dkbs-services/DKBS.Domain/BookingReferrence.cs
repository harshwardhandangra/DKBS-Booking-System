using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class BookingReferrence
    {
        public int BookingReferrenceId { get; set; }
        public int BookingId { get; set; }
        public int RefferId { get; set; }
        public int CompignId { get; set; }
        [MaxLength(500)]
        public string Other { get; set; }
        public int LeadOrignId { get; set; }
        
    }
}
