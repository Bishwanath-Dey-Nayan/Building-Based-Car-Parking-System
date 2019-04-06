using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarParkingSystem.Models.ViewModel
{
    public class GeneralUserVM
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Name Field Must be filled.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Contact Number is Required.")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Address is Required.")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage =" Car Numbe is Required.")]
        [Display(Name="Car Number")]
        public string CarNo { get; set; }

        public string CarName { get; set; }
        
        [Required(AllowEmptyStrings =false,ErrorMessage ="License No is required")]
        [Display(Name="License Number.")]
        public string LicenseNo { get; set; }

    }
}