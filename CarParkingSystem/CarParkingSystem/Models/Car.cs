using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set;}
        public string CarNo { get; set; }
        public string CarName { get; set; }
        public string LicenseNo { get; set; }
    }
}