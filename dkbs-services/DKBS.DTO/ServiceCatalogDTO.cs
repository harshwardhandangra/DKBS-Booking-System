using System;

namespace DKBS.DTO
{
    public class ServiceCatalogDTO
    {
        public int ServiceCatalogId { get; set; }
        public string CoursePackage { get; set; }
        public int Offered { get; set; }
        public Decimal Price { get; set; }
        public int CoursepackageTypeID { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
            
    }
}
