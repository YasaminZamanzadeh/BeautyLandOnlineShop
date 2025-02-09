﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Models.ViewModels.SignupViewModel
{
    public class SignupViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11)]
        public string Phone { get; set; }


    }
}
