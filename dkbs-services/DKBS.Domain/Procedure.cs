using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class Procedure
    {
        public int ProcedureId { get; set; }
        [MaxLength(255)]
        public string ProcedureName { get; set; }
        public int BookingId { get; set; }
        public int PartnerId { get; set; }
        public int CustomerId { get; set; }
        public int CauseOfRemovalId { get; set; }
        public int ProcedureReviewTypeId { get; set; }
        public DateTime LastModified { get; set; }
         [MaxLength(255)]
        public string LastModifiedBy { get; set; }
    }
}
