using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
    public class Purpose
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string PurposeName { get; set; }
    }
}
