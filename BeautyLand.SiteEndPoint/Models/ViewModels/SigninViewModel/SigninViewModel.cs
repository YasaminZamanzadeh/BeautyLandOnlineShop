using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Models.ViewModels.SigninViewModel
{
    public class SigninViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool IsPersistent { get; set; }
        public string ReturnUrl { get; set; }
    }
}
