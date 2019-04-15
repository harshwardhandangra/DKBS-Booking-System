using System;

namespace DKBS.Domain
{
    public class ServiceCatalog
    {
        public int ServiceCatalogId { get; set; }
        public string CoursePackage { get; set; }
        public int Offered { get; set; }
        public Decimal Price { get; set; }
        public CoursePackageType CoursePackageType { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
            
    }
}
