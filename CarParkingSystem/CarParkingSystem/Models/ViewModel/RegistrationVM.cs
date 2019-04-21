using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarParkingSystem.Models.ViewModel
{
    public class RegistrationVM
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Name is required.")]
        [Display(Name="Client Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Contact Number Required.")]
        [Display(Name="Contact Number")]
        public string Contact { get; set; }

        [Required]
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name ="Gender")]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Address is Required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Email Address is Required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Car Number.")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Car Number Required.")]
        public string CarNo { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Car Name or Brand Name")]
        [Display(Name="Car Name")]
        public string CarName { get; set; }

        [Display(Name="License Number.")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="License Number required.")]
        public string LicenseNo { get; set; }

        [Display(Name="Deposite Amount")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Depostie the amount.")]
        public double Deposite { get; set; }

        [Display(Name="Password")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Password Required.")]
        [DataType(DataType.Password)]
        [MinLength(7,ErrorMessage ="At least Seven Characters needed.")]
        public string Password { get; set; }


        [Display(Name="Confirm PassWord.")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Confirm Password Required.")]
        [Compare("Password",ErrorMessage ="Confirm Password does not match with the Password.")]
        public string ConfirmPassWord { get; set; }
        
        
    }
}