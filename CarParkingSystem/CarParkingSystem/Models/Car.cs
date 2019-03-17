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


        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<CheckIn> Checkins { get; set; }
        public virtual ICollection<CheckOut> CheckOuts { get; set; }
        public virtual ICollection<RegisteredUser> RegisteredUsers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}