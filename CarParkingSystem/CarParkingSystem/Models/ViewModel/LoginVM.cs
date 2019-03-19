using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarParkingSystem.Models.ViewModel
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email Address is required.")]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Display(Name ="Password")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter the password.")]
        public string Password { get; set; }

        [Display(Name ="Remember Me?")]
        public bool Remember { get; set; }
    }
}