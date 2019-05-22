using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.DTO
{
    public class CustomerDTO
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string PostNumber { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public bool StateAgreement { get; set; }
        [Required(ErrorMessage = "Account Id is required.")]
        public string AccountId { get; set; }
        [Required]
        public string IndustryCode { get; set; }
        public int SharePointId { get; set; }
    }
}