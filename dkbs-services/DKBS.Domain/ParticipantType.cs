using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class ParticipantType
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string ParticipantTypeName { get; set; }
    }
}
