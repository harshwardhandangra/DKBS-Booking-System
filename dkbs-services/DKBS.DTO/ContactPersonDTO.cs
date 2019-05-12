﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.DTO
{
    public class ContactPersonDTO
    {
        [JsonIgnore]
        public int ContactPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Account Id is required.")]
        public string AccountId { get; set; }
        [Required(ErrorMessage = "Contact Id is required.")]
        public string ContactId { get; set; }
    }
}