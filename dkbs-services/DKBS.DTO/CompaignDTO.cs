using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.DTO
{
    public class CompaignDTO
    {
        public int CompaignId { get; set; }
       // [MaxLength(2255)]
        public string Name { get; set; }
    }
}
