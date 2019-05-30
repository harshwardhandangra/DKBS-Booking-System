using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
   public class PartnerServiceCatalogueDTO
    {
        public int Id { get; set; }
        public int ServiceCatalogId { get; set; }
        public int PartnerId { get; set; }
        public bool Offered { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
