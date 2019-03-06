using System;

namespace DKBS.DTO
{
    public class CoursePackageTypeDTO
    {
        public int CoursePackageTypeId { get; set; }

        public string CoursePackageTypeTitle { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}