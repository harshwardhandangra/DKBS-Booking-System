﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.DTO
{
    public class ContactPersonUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Account Id is required.")]
        public string AccountId { get; set; }

        public int SharePointId { get; set; }
    }
}
