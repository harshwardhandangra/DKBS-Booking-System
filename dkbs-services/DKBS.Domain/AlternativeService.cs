using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class AlternativeService
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int NumberOfPieces { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }        
    }
}
